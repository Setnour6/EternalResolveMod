using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos.YoyoProjectiles
{
    public class SkyBlueYoyo : ModProjectile
    {
        public override void SetStaticDefaults( )
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ Projectile.type ] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[ Projectile.type ] = 350f;
            ProjectileID.Sets.YoyosTopSpeed[ Projectile.type ] = 20f;
        }
        public override void SetDefaults( )
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
        }
        public override void AI( )
        {
            Projectile.localAI[ 0 ] += 1f;
            if ( Projectile.localAI[ 0 ] > 4f )
            {
                for ( int i = 0; i < 3; i++ )
                {
                    int num = Dust.NewDust( new Vector2( Projectile.position.X , Projectile.position.Y ) , 16 , 16 , 29 , 0f , 0f , 100 , default( Color ) , 1f );
                    Main.dust[ num ].noGravity = true;
                    Main.dust[ num ].velocity *= 0f;
                }
            }
        }
    }
}