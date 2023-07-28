using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos.YoyoProjectiles
{
    public class MagicYoyoPower : ModProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.CloneDefaults( 604 );
            Projectile.width = 16;
            Projectile.scale = 1.1f;
            Projectile.height = 16;
            Projectile.alpha = 112;
            Projectile.penetrate = -1;
            Projectile.light = 1f;
            Projectile.aiStyle = 99;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 15;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            Projectile.timeLeft = 60;
        }
        public override bool PreDraw( ref Color lightColor )
        {
            Texture2D texture2D = TextureAssets.Projectile[ Projectile.type ].Value;
            int num = texture2D.Height / Main.projFrames[ Projectile.type ];
            SpriteEffects spriteEffects = SpriteEffects.None;
            if ( Projectile.spriteDirection < 0 )
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
            if ( Projectile.localAI[ 0 ] < 0f )
            {
                spriteEffects |= SpriteEffects.FlipVertically;
            }
            Vector2 origin = new Vector2( (float) ( texture2D.Width / 2 ) , (float) ( num / 2 ) );
            int num2 = Math.Min( 45 , 2 + (int) Projectile.oldVelocity.Length( ) );
            for ( int i = num2; i >= 0; i-- )
            {
                Vector2 v = Projectile.Center - Main.screenPosition - Projectile.oldVelocity * (float) i * 0.5f;
                float num3 = Projectile.Opacity - 0.05f - 0.95f / (float) num2 * (float) i;
                if ( i != 0 )
                {
                    num3 /= 2f;
                }
                if ( num3 > 0f )
                {
                    float num4 = 0.4f + 0.6f * num3;
                    Main.spriteBatch.Draw( texture2D , Utils.ToVector2( Utils.ToPoint( v ) ) , new Rectangle?( new Rectangle( 0 , num * Projectile.frame , texture2D.Width , num ) ) , new Color( 1f * num4 , 1f * num4 , 1f , 0.5f ) * num3 , Projectile.rotation , origin , Projectile.scale * ( 1f + 0.02f * (float) i ) , spriteEffects , 0f );
                }
            }
            return false;
        }
    }
}
