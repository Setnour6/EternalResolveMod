using Microsoft.Xna.Framework;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs
{
    public class HitEffect : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "命中特效" );
            Main.projFrames[ Projectile.type ] = 3;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToProjectile( 82 , 82 );
            Projectile.friendly = false;
            Projectile.light = 0.2f;
            base.SetDefaults( );
        }
        public override void AI( )
        {
            Projectile.frameCounter++;
            if ( Projectile.frameCounter % 2 == 0 )
            {
                Projectile.frame++;
                if ( Projectile.frame > 3 )
                    Projectile.Kill( );
            }
            Projectile.rotation = Projectile.ai[ 0 ];
            base.AI( );
        }
        public override Color? GetAlpha( Color lightColor )
        {
            return new Color( lightColor.R , lightColor.G , lightColor.B , 0 );
        }
    }
}