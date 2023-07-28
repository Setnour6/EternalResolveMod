using EternalResolve.Assets.Textures.Extras;
using EternalResolve.Common.Graphics.Vertexs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.Breezes
{
    public class BreezeArrow_Pro : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 10;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            base.SetStaticDefaults( );
        }

        public override void SetDefaults( )
        {
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 1;
            Projectile.width = 14;
            Projectile.height = 1;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = 3;
            Projectile.timeLeft = 600;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.scale = 1f;
            Projectile.extraUpdates = 1;
            Projectile.light = 0.6f;
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            Player player = Main.player[ Main.myPlayer ];
            player.ApplyDamageToNPC( target , (int) ( target.life * 1E-05f ) , player.HeldItem.knockBack , 1 , Main.rand.NextBool( ) );
            for ( int i = 0; i < 35; i++ )
            {
                Vector2 position = Projectile.Center;
                Dust dust = Main.dust[ Dust.NewDust( position , -(int) Projectile.velocity.X / 4 , -(int) Projectile.velocity.Y / 8 , DustID.WitherLightning , -Projectile.velocity.X / 4f , -Projectile.velocity.Y / 8f , 0 , new Color( 255 , 255 , 255 , 30 ) , 0.2f ) ];
                dust.noGravity = true;
                dust.fadeIn = 0.42632f;
                Dust dust2 = Main.dust[ Dust.NewDust( position , -(int) Projectile.velocity.X / 4 , -(int) Projectile.velocity.Y / 8 , DustID.WitherLightning , -Projectile.velocity.X / 4f , -Projectile.velocity.Y / 8f , 0 , new Color( 255 , 255 , 255 , 30 ) , 0.2f ) ];
                dust2.noGravity = true;
                dust2.fadeIn = 0.42632f;
            }
        }
        public override void Kill( int timeLeft )
        {
            SoundEngine.PlaySound( SoundID.Item5 , Projectile.position );
            //  ModUtils.DustCircle( DustID.TintableDustLighted , Projectile.position , 0.1f , 360 );
        }

        public override void AI( )
        {
            Projectile.velocity *= 1.001f;
            Projectile.rotation = Utils.ToRotation( Projectile.velocity ) + 1.5707964f;
        }
        public override bool PreDraw( ref Color lightColor )
        {
            default( TrailDrawer ).Draw( Projectile , Color.CadetBlue , 1f , 0.5f , ExtraAssets.Extra[ 13 ] , ExtraAssets.Extra[ 13 ] , ExtraAssets.Extra[ 13 ] );
            return base.PreDraw( ref lightColor );
        }
    }
}