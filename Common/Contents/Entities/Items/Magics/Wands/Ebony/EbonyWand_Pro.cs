using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.Wands.Ebony
{
    public class EbonyWand_Pro : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "魔力" );
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 11;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 0;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 2 , 2 );
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.aiStyle = 1;
            Projectile.scale = 0.6f;
            Projectile.light = 0.45f;
            Projectile.timeLeft = 120;
        }
        public override void AI( )
        {
            if ( Projectile.timeLeft == 120 )
            {
                for ( int angle = 0; angle < 12; angle++ )
                {
                    Vector2 position = Projectile.position;
                    position += Utils.RotatedByRandom( new Vector2( 5f , 0f ) , 6.283 ) * Utils.NextFloat( Main.rand , 0.9f , 1.1f );
                    Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 88 , 0f , 0f , 0 , Color.Gray , 1.25f ) ];
                    dust.velocity = ( position - Projectile.position ) / 3f;
                    dust.noGravity = true;
                }
            }
        }
        public override void Kill( int timeLeft )
        {
            Engine.PlaySound( SoundID.NPCDeath3 , Projectile.Center );
            for ( int angle = 0; angle < 12; angle++ )
            {
                Vector2 position = Projectile.position;
                position += Utils.RotatedByRandom( new Vector2( 5f , 0f ) , 6.283 ) * Utils.NextFloat( Main.rand , 0.9f , 1.1f );
                Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , 88 , 0f , 0f , 0 , Color.Gray , 1.25f ) ];
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
                Color color = new Color( 188 , 188 , 188 );
                color = new Color( color.R , color.G , color.B , (int) ( 255f * sizeFix ) ) * sizeFix2 * 0.9f;
                int j = 0;
                while ( j < Vector2.Distance( currentDrawPosition , targetDrawPosition ) / 10f )
                {
                    Main.spriteBatch.Draw( TextureAssets.Projectile[ Projectile.type ].Value , SymUtils.GetCloser( targetDrawPosition , currentDrawPosition , j , Vector2.Distance( currentDrawPosition , targetDrawPosition ) / 5f ) , null , color , Projectile.rotation , drawOrigin , 0.3f - i * 0.03f , SpriteEffects.None , 0f );
                    j++;
                }
                i++;
            }
            return false;
        }
    }
}