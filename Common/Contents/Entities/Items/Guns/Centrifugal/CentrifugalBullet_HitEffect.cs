using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.Centrifugal
{
    public class CentrifugalBullet_HitEffect : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "离心-命中特效" );
            Main.projFrames[ Projectile.type ] = 6;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 5;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 0;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToProjectile( 64 , 64 );
            Projectile.tileCollide = false;
            Projectile.friendly = false;
            Projectile.light = 0.2f;
            base.SetDefaults( );
        }
        public override void AI( )
        {
            Projectile.velocity *= 0.9f;
            Projectile.frameCounter++;
            if ( Projectile.frameCounter % 2 == 0 )
            {
                Projectile.frame++;
                if ( Projectile.frame > 6 )
                    Projectile.Kill( );
            }
            Projectile.rotation = Projectile.ai[ 0 ];
            base.AI( );
        }
        public override bool PreDraw( ref Color lightColor )
        {
            lightColor = Color.White;
            return true;
        }
    }
}