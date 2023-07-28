using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Throwns.Frisbees
{
    public class FrisbeeProjectile : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "利刃飞盘" );
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 10;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 0;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 28 , 28 );
            Projectile.penetrate = -1;
            Projectile.aiStyle = 3;
        }
        public override bool PreDraw( ref Color lightColor )
        {
            Texture2D t = TextureAssets.Projectile[ Projectile.type ].Value;
            int frameHeight = t.Height / Main.projFrames[ Projectile.type ];
            SpriteEffects effects = SpriteEffects.None;
            if ( Projectile.spriteDirection < 0 )
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            if ( Projectile.localAI[ 0 ] < 0f )
            {
                effects |= SpriteEffects.FlipVertically;
            }
            Vector2 origin = new Vector2( (float) ( t.Width / 2 ) , (float) ( frameHeight / 2 ) );
            int length = Math.Min( 10 , 2 + (int) Projectile.oldVelocity.Length( ) );
            for ( int i = length; i >= 0; i-- )
            {
                Vector2 drawPos = Projectile.Center - Main.screenPosition - Projectile.oldVelocity * (float) i * 0.5f;
                float trailOpacity = Projectile.Opacity - 0.05f - 0.95f / (float) length * (float) i;
                if ( i != 0 )
                {
                    trailOpacity /= 2f;
                }
                if ( trailOpacity > 0f )
                {
                    float colMod = 0.4f + 0.6f * trailOpacity;
                    Main.spriteBatch.Draw( t , Utils.ToVector2( Utils.ToPoint( drawPos ) ) , new Rectangle?( new Rectangle( 0 , frameHeight * Projectile.frame , t.Width , frameHeight ) ) , new Color( 1f * colMod , 1f * colMod , 1f , 0.5f ) * trailOpacity , Projectile.rotation , origin , Projectile.scale * ( 1f - 0.09f * i ) , effects , 0f );
                }
            }
            return false;
        }
    }
}
