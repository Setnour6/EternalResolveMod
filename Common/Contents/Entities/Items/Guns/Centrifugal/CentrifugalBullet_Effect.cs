using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.Centrifugal
{
    public class CentrifugalBullet_Effect : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "" );
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 11;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 0;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToProjectile( 2 , 2 );
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            base.SetDefaults( );
        }
        public override void AI( )
        {
            if ( Projectile.oldPos[ 10 ] == Projectile.position )
                Projectile.Kill( );
            base.AI( );
        }
        public override void PostDraw( Color lightColor )
        {
            Vector2 drawOrigin = new Vector2( TextureAssets.Projectile[ Projectile.type ].Value.Width , Projectile.height );
            for ( int k = 0; k < 10; k++ )
            {
                if ( Projectile.oldPos[ k ] == Vector2.Zero )
                    break;
                Vector2 targetDrawPosition = Projectile.oldPos[ k ] + new Vector2( 3f , Projectile.gfxOffY ) - Main.screenPosition;
                Vector2 currentDrawPosition = Projectile.position + new Vector2( 3f , Projectile.gfxOffY ) - Main.screenPosition;
                float sizeFix = 2;
                sizeFix /= 1 + k;
                sizeFix -= 1;
                float sizeFix2 = 11;
                sizeFix2 /= 1 + k;
                sizeFix2 -= 1;
                Color color = new Color( 76 , 104 , 244 );
                color = new Color( color.R , color.G , color.B , (int) ( 255 * sizeFix ) ) * sizeFix2 * 0.9f;
                for ( int i = 0; i < Vector2.Distance( currentDrawPosition , targetDrawPosition ) / 10; i++ )
                {
                    Main.spriteBatch.Draw( ModContent.Request<Texture2D>( "EternalResolve/Assets/Textures/Point" ).Value
                        , XnaUtils.GetCloser( targetDrawPosition , currentDrawPosition , i , Vector2.Distance( currentDrawPosition , targetDrawPosition ) / 5 ) , null , color , Projectile.rotation , drawOrigin , Projectile.scale * 0.5f , SpriteEffects.None , 0f );
                    ;
                }
            }
            base.PostDraw( lightColor );
        }
    }
}