using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings
{
    public class StabbingDrawer : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        protected override bool CloneNewInstances => true;

		public override GlobalProjectile Clone(Projectile from, Projectile to)
		{
			return base.Clone(from, to);
		}

		public bool IsStabbing = false;

        public Color Color = Color.White;

        public override void PostDraw( Projectile projectile , Color lightColor )
        {
            Main.spriteBatch.End( );
            Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.AlphaBlend , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null , Main.GameViewMatrix.TransformationMatrix );
            if ( projectile.active && projectile.GetGlobalProjectile<StabbingDrawer>( ).IsStabbing )
            {
                UnifiedRandom rand = Main.rand;
                int num2 = 2;
                Vector2 val = projectile.Center - projectile.rotation.ToRotationVector2( ) * (float) num2;
                float num3 = rand.NextFloat( );
                float num4 = Utils.GetLerpValue( 0f , 0.3f , num3 , clamped: true ) * Utils.GetLerpValue( 1f , 0.5f , num3 , clamped: true );
                Texture2D value = TextureAssets.Item[ Main.player[ projectile.owner ].HeldItem.type ].Value;
                Vector2 val3 = value.Size( ) / 2f;
                float num5 = rand.NextFloatDirection( );
                float num6 = 8f + MathHelper.Lerp( 0f , 20f , num3 ) + rand.NextFloat( ) * 6f;
                float num7 = projectile.rotation + num5 * ( (float) Math.PI * 2f ) * 0.04f;
                float num8 = num7 + (float) Math.PI / 4f;
                Vector2 val4 = val + num7.ToRotationVector2( ) * num6 + rand.NextVector2Circular( 8f , 8f ) - Main.screenPosition;
                SpriteEffects val5 = (SpriteEffects) 0;
                if ( projectile.rotation < -(float) Math.PI / 2f || projectile.rotation > (float) Math.PI / 2f )
                {
                    num8 += (float) Math.PI / 2f;
                    val5 = ( val5 | SpriteEffects.FlipHorizontally );
                }
                if( !Main.player[ projectile.owner ].HeldItem.noUseGraphic )
                {
                    Main.spriteBatch.Draw( value , val4 , null , Color.White , num8 , val3 , 1f , val5 , 0f );
                }
                Main.spriteBatch.End( );
                Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.AlphaBlend , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null , Main.GameViewMatrix.TransformationMatrix );
                for ( int j = 0; j < 1; j++ )
                {
                    float num9 = rand.NextFloat( );
                    float num10 = Utils.GetLerpValue( 0f , 0.3f , num9 , clamped: true ) * Utils.GetLerpValue( 1f , 0.5f , num9 , clamped: true );
                    float num11 = Utils.GetLerpValue( 0f , 0.3f , num9 , clamped: true ) * Utils.GetLerpValue( 1f , 0.5f , num9 , clamped: true );
                    float num12 = MathHelper.Lerp( 0.6f , 1f , num11 );
                    Texture2D value2 = TextureAssets.Projectile[ projectile.type ].Value;
                    Vector2 val7 = value2.Size( ) / 2f;
                    float num14 = rand.NextFloat( ) * 2f;
                    float num15 = rand.NextFloatDirection( );
                    Vector2 val10 = new Vector2( 1.4f + num14 , 1f ) * num12;
                    int num16 = 50;
                    Vector2 val11 = projectile.rotation.ToRotationVector2( ) * (float) ( ( j >= 1 ) ? 56 : 0 );
                    float num17 = 0.03f - (float) j * 0.012f;
                    float num18 = 30f + MathHelper.Lerp( 0f , (float) num16 , num9 ) + num14 * 16f;
                    float num19 = projectile.rotation + num15 * ( (float) Math.PI * 2f ) * num17;
                    float num20 = num19;
                    Vector2 val12 = val + num19.ToRotationVector2( ) * num18 + rand.NextVector2Circular( 20f , 20f ) + val11 - Main.screenPosition;
                    SpriteEffects val13 = 0;
                    Color color = projectile.GetGlobalProjectile<StabbingDrawer>( ).Color;
                    Main.spriteBatch.Draw( value2 , val12 , null , new Color( color.R , color.G , color.B , 0 ) , num20 , val7 , val10 , val13 , 0f );
                }
            }
        }
    }
}
