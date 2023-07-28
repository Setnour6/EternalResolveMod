using EternalResolve.Common.Contents.Entities.Items.Armors.Cather;
using EternalResolve.Common.Contents.Entities.Items.Summons.Impacts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Boxs
{
    public class OpeningBox_Effect : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "起始" );
            Main.projFrames[ Projectile.type ] = 39;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 48 , 36 );
        }
        public override Color? GetAlpha( Color lightColor )
        {
            return new Color?( Color.White );
        }

        public override void AI( )
        {
            Projectile.velocity.Y = Projectile.velocity.Y * 0.995f;
            if ( Projectile.velocity.Y > -0.16f )
                Projectile.velocity.Y = 0f;
            Projectile.frameCounter++;
            if ( Projectile.frameCounter > 3 )
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if ( Projectile.frame >= 12 && _timer < 3 )
            {
                Projectile.frame = 0;
                _timer++;
                if ( _timer == 3 )
                {
                    Projectile.frame = 3;
                }
            }
            if ( Projectile.frame == 21 && !_drop )
            {
                _drop = true;
                ERItemManager.CreateItem( Projectile.Center , ModContent.ItemType<Impact>( ) );
                ERItemManager.CreateItem( Projectile.Center , ModContent.ItemType<CatherHead>( ) );
                ERItemManager.CreateItem( Projectile.Center , ModContent.ItemType<CatherArmor>( ) );
                ERItemManager.CreateItem( Projectile.Center , ModContent.ItemType<CatherLegs>( ) );
            }
            if ( Projectile.frame >= 39 && _timer >= 3 )
                Projectile.Kill( );
        }
        private int _timer;
        private bool _drop = false;
    }
}
