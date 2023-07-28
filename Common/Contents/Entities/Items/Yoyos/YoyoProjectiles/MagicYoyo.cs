using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos.YoyoProjectiles
{
    public class MagicYoyo : ModProjectile
    {
        public override void SetStaticDefaults( )
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ Projectile.type ] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[ Projectile.type ] = 200f;
            ProjectileID.Sets.YoyosTopSpeed[ Projectile.type ] = 14f;
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
                    int num = Dust.NewDust( new Vector2( Projectile.position.X , Projectile.position.Y ) , 1 , 1 , 57 , 0f , 0f , 100 , default( Color ) , 1f );
                    int num2 = Dust.NewDust( new Vector2( Projectile.position.X , Projectile.position.Y ) , 1 , 1 , 58 , 0f , 0f , 100 , default( Color ) , 1f );
                    int num3 = Dust.NewDust( new Vector2( Projectile.position.X , Projectile.position.Y ) , 1 , 1 , 15 , 0f , 0f , 100 , default( Color ) , 1f );
                    Main.dust[ num ].noGravity = true;
                    Main.dust[ num ].velocity *= 0f;
                    Main.dust[ num2 ].noGravity = true;
                    Main.dust[ num2 ].velocity *= 0f;
                    Main.dust[ num3 ].noGravity = true;
                    Main.dust[ num3 ].velocity *= 0f;
                }
            }
            if ( Projectile.ai[ 1 ] % 6f == 0f )
            {
                Projectile.NewProjectile( new ERProjectileSource( ) , Projectile.Center.X , Projectile.Center.Y , (float) Main.rand.Next( -5 , 5 ) , (float) Main.rand.Next( -5 , 5 ) , ModContent.ProjectileType<MagicYoyoPower>( ) , 15 , 3f , Projectile.owner , 0f , 0f );
            }
        }
        public override void Kill( int timeLeft )
        {
            int num = Dust.NewDust( Projectile.position + Projectile.velocity , Projectile.width , Projectile.height , 57 , (float) ( Projectile.direction * 2 ) , 0f , 150 , default( Color ) , 1f );
            Main.dust[ num ].noGravity = true;
            int num2 = Dust.NewDust( Projectile.position + Projectile.velocity , Projectile.width , Projectile.height , 58 , (float) ( Projectile.direction * 2 ) , 0f , 150 , default( Color ) , 1f );
            Main.dust[ num2 ].noGravity = true;
            int num3 = Dust.NewDust( Projectile.position + Projectile.velocity , Projectile.width , Projectile.height , 15 , (float) ( Projectile.direction * 2 ) , 0f , 150 , default( Color ) , 1f );
            Main.dust[ num3 ].noGravity = true;
        }

        // Token: 0x06000482 RID: 1154 RVA: 0x00018E3C File Offset: 0x0001703C
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            int num = Dust.NewDust( Projectile.position + Projectile.velocity , Projectile.width , Projectile.height , 57 , (float) ( Projectile.direction * 2 ) , 0f , 150 , default( Color ) , 1f );
            Main.dust[ num ].noGravity = true;
            int num2 = Dust.NewDust( Projectile.position + Projectile.velocity , Projectile.width , Projectile.height , 58 , (float) ( Projectile.direction * 2 ) , 0f , 150 , default( Color ) , 1f );
            Main.dust[ num2 ].noGravity = true;
            int num3 = Dust.NewDust( Projectile.position + Projectile.velocity , Projectile.width , Projectile.height , 15 , (float) ( Projectile.direction * 2 ) , 0f , 150 , default( Color ) , 1f );
            Main.dust[ num3 ].noGravity = true;
        }
    }
}