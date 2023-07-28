using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.ShiningStars
{
    public class ShiningStar_Pro : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "渺纱之星" );
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 11;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 0;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 2 , 2 );
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = false;
            Projectile.aiStyle = -1;
            Projectile.scale = 0.6f;
            Projectile.light = 0.45f;
            Projectile.timeLeft = 60;
        }
        public override void AI( )
        {
            if ( Projectile.timeLeft == 60 )
            {
                Projectile.ai[ 0 ] = Main.MouseWorld.X;
                Projectile.ai[ 1 ] = Main.MouseWorld.Y;
            }
            Vector2 target = new Vector2( Projectile.ai[ 0 ] , Projectile.ai[ 1 ] );
            if ( Vector2.Distance( Projectile.position , target ) < 10f )
            {
                Projectile.Kill( );
            }
            Projectile.position = SymUtils.GetCloser( Projectile.position , target , 1f + 10f / Vector2.Distance( Projectile.position , target ) , 9f );
        }
        public override void Kill( int timeLeft )
        {
            for ( int angle = 0; angle < 12; angle++ )
            {
                Vector2 position = Projectile.position;
                position += Utils.RotatedByRandom( new Vector2( 5f , 0f ) , 6.283 ) * Utils.NextFloat( Main.rand , 0.9f , 1.1f );
                Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 88 , 0f , 0f , 0 , Color.White , 1.25f ) ];
                dust.velocity = ( position - Projectile.position ) / 3f;
                dust.noGravity = true;
            }
        }
        public override bool PreDraw( ref Color lightColor )
        {
            Vector2 drawOrigin = new Vector2( TextureAssets.Projectile[ Projectile.type ].Value.Width , TextureAssets.Projectile[ Projectile.type ].Value.Height );
            int i = 0;
            while ( i < 10 && !( Projectile.oldPos[ i ] == Vector2.Zero ) )
            {
                Vector2 targetDrawPosition = Projectile.oldPos[ i ] + new Vector2( 3f , Projectile.gfxOffY ) - Main.screenPosition;
                Vector2 currentDrawPosition = Projectile.position + new Vector2( 3f , Projectile.gfxOffY ) - Main.screenPosition;
                float sizeFix = 2f;
                sizeFix /= ( 1 + i );
                sizeFix -= 1f;
                float sizeFix2 = 11f;
                sizeFix2 /= ( 1 + i );
                sizeFix2 -= 1f;
                Color color = new Color( 76 , 104 , 244 );
                color = new Color( color.R , color.G , color.B , (int) ( 255f * sizeFix ) ) * sizeFix2 * 0.9f;
                int j = 0;
                while ( j < Vector2.Distance( currentDrawPosition , targetDrawPosition ) / 10f )
                {
                    Main.spriteBatch.Draw( TextureAssets.Projectile[ Projectile.type ].Value , SymUtils.GetCloser( targetDrawPosition , currentDrawPosition , (float) j , Vector2.Distance( currentDrawPosition , targetDrawPosition ) / 5f ) , null , color , Projectile.rotation , drawOrigin , Projectile.scale * 0.5f , SpriteEffects.None , 0f );
                    j++;
                }
                i++;
            }
            return false;
        }
    }
}