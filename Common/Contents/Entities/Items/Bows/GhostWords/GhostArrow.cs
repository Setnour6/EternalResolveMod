using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.GhostWords
{
    public class GhostArrow : ERProjectile
    {
        public override void SetDefaults( )
        {
            ToProjectile( 14 , 12 );
        }
        public override void AI( )
        {
            Projectile.rotation = Utils.ToRotation( Projectile.velocity ) + 1.57f;
            Dust dust = Dust.NewDustDirect( Projectile.Center , 0 , 0 , DustID.DungeonSpirit , 0f , 0f , 0 , new Color( 255 , 255 , 255 ) , 1.5f );
            dust.noGravity = true;
            dust.fadeIn = 1f;
            dust.position = Projectile.Center;
            base.AI( );
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            target.AddBuff( ModContent.BuffType<AbnormalVitality>( ) , 120 , false );
            base.OnHitNPC( target , damage , knockback , crit );
        }
        public override void Kill( int timeLeft )
        {
            for ( int count = 0; count < 15; count++ )
            {
                Vector2 position = Projectile.Center;
                Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 206 , -Projectile.velocity.X / 8f , -Projectile.velocity.Y / 8f , 0 , new Color( 0 , 17 , 255 ) , 3.092105f ) ];
                dust.noGravity = true;
                dust.fadeIn = 3f;
            }
            Projectile.NewProjectile( null , Projectile.Center , -Projectile.velocity / 100f , ModContent.ProjectileType<GhostArrowHitEffect>( ) , 0 , 0f , Main.myPlayer , 0f , 0f );
            base.Kill( timeLeft );
        }
    }
}