using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos.YoyoProjectiles
{
    public class ForeverNight : ModProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.CloneDefaults( 563 );
            Projectile.width = 16;
            Projectile.scale = 1.1f;
            Projectile.height = 16;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 99;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 15;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ Projectile.type ] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[ Projectile.type ] = 400f;
            ProjectileID.Sets.YoyosTopSpeed[ Projectile.type ] = 22f;
        }
        public override void AI( )
        {
            Projectile.localAI[ 0 ] += 1f;
            rot++;
            if ( Projectile.localAI[ 0 ] > 4f )
            {
                for ( int i = 0; i < 3; i++ )
                {
                    int num = Dust.NewDust( new Vector2( Projectile.position.X , Projectile.position.Y ) , 16 , 16 , 62 , 0f , 0f , 100 , default( Color ) , 1f );
                    Main.dust[ num ].noGravity = true;
                    Main.dust[ num ].velocity *= 0f;
                }
            }
            Projectile.rotation = Utils.ToRotation( Projectile.velocity );
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            for ( int i = 0; i < 25; i++ )
            {
                Dust.NewDust( Projectile.position + Projectile.velocity , 1 , 1 , 62 , Projectile.velocity.X * 0.2f , Projectile.velocity.Y * 0.2f , 0 , default( Color ) , 1f );
            }
        }
        public override void PostDraw( Color lightColor )
        {
            /*Texture2D image = Main.projectileTexture[ Projectile.type ];
			spriteBatch.End( );
			default( TrailDrawer ).Draw( Projectile , Color.Purple , 8f , 0.5f , EAssets.Extras[ 3 ] , EAssets.Extras[ 2 ] , EAssets.Extras[ 7 ] );
			spriteBatch.Begin( );
			spriteBatch.Draw( image , Projectile.Center - Main.screenPosition , null , Color.White , (float)this.rot * 3.14f / 4f , Projectile.Size / 2f , 1f , SpriteEffects.None , 1f );
			*/
            base.PostDraw( lightColor );
        }
        private int rot;
    }
}
