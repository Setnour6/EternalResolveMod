using Microsoft.Xna.Framework;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.HitEffects
{
    public class Cut_HitEffect : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "尘世-命中特效" );
            Main.projFrames[ Projectile.type ] = 3;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToProjectile( 82 , 82 );
            Projectile.friendly = false;
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
