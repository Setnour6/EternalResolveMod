using EternalResolve.Assets.Textures.Extras;
using EternalResolve.Common.Graphics.Vertexs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.DivineCreations
{
    public class DivineCreation_Pro : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "神造物" );
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 11;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 2 , 2 );
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
            Projectile.aiStyle = -1;
            Projectile.light = 0.45f;
            Projectile.netUpdate = true;
            Projectile.extraUpdates = 2;
            Projectile.timeLeft = 120;
        }
        public override void AI( )
        {
            Projectile.rotation = Projectile.velocity.ToRotation( );
            if ( Projectile.timeLeft == 120 )
            {
                SoundEngine.PlaySound( SoundID.Item40 , Projectile.Center );
                for ( int count = 0; count < 6; count++ )
                {
                    Vector2 position = Projectile.position;
                    position += Utils.RotatedByRandom( new Vector2( 5f , 0f ) , 6.283 ) * Utils.NextFloat( Main.rand , 0.9f , 1.1f );
                    Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , DustID.TintableDustLighted , 0f , 0f , 0 , Color.White , 1.25f ) ];
                    dust.velocity = Projectile.velocity / 4;
                    dust.noGravity = true;
                }
            }
        }
        public override void Kill( int timeLeft )
        {
            for ( int angle = 0; angle < 24; angle++ )
            {
                Vector2 position = Projectile.position;
                position += Utils.RotatedByRandom( new Vector2( 5f , 0f ) , 6.283 ) * Utils.NextFloat( Main.rand , 0.9f , 1.1f );
                Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , DustID.TintableDustLighted , 0f , 0f , 0 , Color.White , 1.25f ) ];
                dust.velocity = ( position - Projectile.position ) / 3f;
                dust.noGravity = true;
            }
        }
        public override bool PreDraw( ref Color lightColor )
        {
            TrailDrawer trailDrawer = new TrailDrawer( );
            trailDrawer.Projectile = Projectile;
            trailDrawer.Texture0 = ExtraAssets.Extra[ 13 ];
            trailDrawer.Texture1 = ExtraAssets.Extra[ 13 ];
            trailDrawer.Texture2 = ExtraAssets.Extra[ 13 ];
            trailDrawer.TrailColor = Color.CadetBlue;
            trailDrawer.Opacity = 3f;
            trailDrawer.Saturation = 1.0f;
            trailDrawer.Width = 16;
            trailDrawer.Draw( );
            return false;
        }
    }
}
