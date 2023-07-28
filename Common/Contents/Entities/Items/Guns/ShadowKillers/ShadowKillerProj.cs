using EternalResolve.Assets.Textures.Extras;
using EternalResolve.Common.Graphics.Vertexs;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.ShadowKillers
{
    public class ShadowKillerProj : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "暗影杀" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToProjectile( 16 , 16 );
            Projectile.aiStyle = -1;
            Projectile.light = 0.8f;
            Projectile.localNPCHitCooldown = 12;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 16;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            base.SetDefaults( );
        }
        public override void AI( )
        {
            Projectile.velocity *= 1.01f;
            Projectile.rotation = Projectile.velocity.ToRotation( ) + 3.14f;
            base.AI( );
        }
        public override void Kill( int timeLeft )
        {
            for ( int count = 0; count < 10; count++ )
            {
                Dust dust;
                Vector2 position = Projectile.Center;
                dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 223 , Main.rand.Next( 10 ) , Main.rand.Next( 10 ) , 0 , new Color( 0 , 42 , 255 ) , 0.2f ) ];
                dust.noGravity = true;
                dust.fadeIn = 0.42632f;
            }
            for ( int count = 0; count < 10; count++ )
            {
                Dust dust;
                Vector2 position = Projectile.Center;
                dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 223 , -Main.rand.Next( 10 ) , Main.rand.Next( 10 ) , 0 , new Color( 0 , 42 , 255 ) , 0.2f ) ];
                dust.noGravity = true;
                dust.fadeIn = 0.42632f;
            }
            for ( int count = 0; count < 10; count++ )
            {
                Dust dust;
                Vector2 position = Projectile.Center;
                dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 223 , Main.rand.Next( 10 ) , -Main.rand.Next( 10 ) , 0 , new Color( 0 , 42 , 255 ) , 0.2f ) ];
                dust.noGravity = true;
                dust.fadeIn = 0.42632f;
            }
            for ( int count = 0; count < 10; count++ )
            {
                Dust dust;
                Vector2 position = Projectile.Center;
                dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 223 , -Main.rand.Next( 10 ) , -Main.rand.Next( 10 ) , 0 , new Color( 0 , 42 , 255 ) , 0.2f ) ];
                dust.noGravity = true;
                dust.fadeIn = 0.42632f;
            }
            base.Kill( timeLeft );
        }
        public override bool PreDraw( ref Color lightColor )
        {
            return true;
        }
        public override void PostDraw( Color lightColor )
        {
            if ( Projectile.ai[ 0 ] == 0f )
            {
                default( TrailDrawer ).Draw( Projectile , Color.Purple , 2.8f , 40f , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 4 ] );
            }
            else if ( Projectile.ai[ 0 ] == 1f )
            {
                default( TrailDrawer ).Draw( Projectile , Color.Red , 2.8f , 40f , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 4 ] );
            }

            base.PostDraw( lightColor );
        }
    }
}
