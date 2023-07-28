using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.GhostWords
{
    public class GhostGodArrow : ERProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.tileCollide = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.light = 1.2f;
            Main.projFrames[ Projectile.type ] = 8;
        }
        public override void AI( )
        {
            Dust dust = Dust.NewDustDirect( Projectile.Center , 0 , 0 , 180 , 0f , 0f , 0 , new Color( 255 , 255 , 255 ) , 1.5f );
            dust.noGravity = true;
            dust.fadeIn = 1f;
            dust.position = Projectile.Center;
            Projectile.frame++;
            Projectile.rotation = Utils.ToRotation( Projectile.velocity );
            if ( Projectile.frame >= Main.projFrames[ Projectile.type ] - 1 )
            {
                Projectile.frame = 0;
            }
            base.AI( );
        }

        // Token: 0x060007AA RID: 1962 RVA: 0x00025609 File Offset: 0x00023809
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            target.AddBuff( ModContent.BuffType<AbnormalVitality>( ) , 120 , false );
            base.OnHitNPC( target , damage , knockback , crit );
        }

        // Token: 0x060007AB RID: 1963 RVA: 0x00025F4C File Offset: 0x0002414C
        public override void Kill( int timeLeft )
        {
            for ( int count = 0; count < 15; count++ )
            {
                Vector2 position = Projectile.Center;
                Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 206 , -Projectile.velocity.X / 8f , -Projectile.velocity.Y / 8f , 0 , new Color( 0 , 17 , 255 ) , 3.092105f ) ];
                dust.noGravity = true;
                dust.fadeIn = 3f;
            }
            Projectile.NewProjectile( new ERProjectileSource( ) , Projectile.Center , Vector2.Zero , ModContent.ProjectileType<GhostGodArrowHitEffect>( ) , 0 , 0f , Main.myPlayer , 0f , 0f );
            base.Kill( timeLeft );
        }
    }
}
