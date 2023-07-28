using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Runtime.InteropServices;
using Terraria;

namespace EternalResolve.Common.Graphics.Vertexs
{
    [StructLayout( LayoutKind.Sequential , Size = 1 )]
    public struct TrailDrawer()
    {
        public Projectile Projectile { get; set; }

        public Color TrailColor { get; set; }

        public float Saturation { get; set; } = 16;

        public float Opacity { get; set; } = 16;

        public float Width { get; set; } = 32;

        public Texture2D Texture0 { get; set; }

        public Texture2D Texture1 { get; set; }

        public Texture2D Texture2 { get; set; }

        public void Draw( )
        {
            TrailShaderData magicMissile = VertexLoader.TrailShaderData;
            magicMissile.UseImage0( Texture0 );
            magicMissile.UseImage1( Texture1 );
            magicMissile.UseImage2( Texture2 );
            magicMissile.UseSaturation( -Saturation );
            magicMissile.UseOpacity( Opacity );
            magicMissile.Apply( null );
            _vertexStrip.PrepareStripWithProceduralPadding( Projectile.oldPos , Projectile.oldRot ,
                new VertexStrip.StripColorFunction( StripColors ) , new VertexStrip.StripHalfWidthFunction( StripWidth ) ,
                -Main.screenPosition + Projectile.Size / 2f , true );
            _vertexStrip.DrawTrail( );
            Main.pixelShader.CurrentTechnique.Passes[ 0 ].Apply( );
        }

        public void Draw( Projectile proj , Color color , float saturation , float opacity , Texture2D t1 , Texture2D t2 , Texture2D t3 )
        {
            TrailColor = color;
            TrailShaderData magicMissile = VertexLoader.TrailShaderData;
            magicMissile.UseImage0( t1 );
            magicMissile.UseImage1( t2 );
            magicMissile.UseImage2( t3 );
            magicMissile.UseSaturation( saturation );
            magicMissile.UseOpacity( opacity );
            magicMissile.Apply( null );
            _vertexStrip.PrepareStripWithProceduralPadding( proj.oldPos , proj.oldRot , new VertexStrip.StripColorFunction( StripColors ) , new VertexStrip.StripHalfWidthFunction( StripWidth ) , -Main.screenPosition + proj.Size / 2f , true );
            _vertexStrip.DrawTrail( );
            Main.pixelShader.CurrentTechnique.Passes[ 0 ].Apply( );
        }

        private Color StripColors( float progressOnStrip )
        {
            Color result = Color.Lerp( Color.White , TrailColor , ModUtils.GetLerpValue( -0.2f , 0.5f , progressOnStrip , true ) ) * ( 1f - ModUtils.GetLerpValue( 0f , 0.98f , progressOnStrip , false ) );
            result.A = 0;
            return result;
        }

        public static Color HslToRgb( Vector3 hslVector )
        {
            return HslToRgb( hslVector.X , hslVector.Y , hslVector.Z );
        }

        public static Color HslToRgb( float Hue , float Saturation , float Luminosity )
        {
            byte r;
            byte g;
            byte b;
            if ( Saturation == 0f )
            {
                r = (byte) Math.Round( (double) Luminosity * 255.0 );
                g = (byte) Math.Round( (double) Luminosity * 255.0 );
                b = (byte) Math.Round( (double) Luminosity * 255.0 );
            }
            else
            {
                double num5 = (double) Hue;
                double num2;
                if ( (double) Luminosity < 0.5 )
                {
                    num2 = (double) Luminosity * ( 1.0 + (double) Saturation );
                }
                else
                {
                    num2 = (double) ( Luminosity + Saturation - Luminosity * Saturation );
                }
                double t = 2.0 * (double) Luminosity - num2;
                double num3 = num5 + 0.3333333333333333;
                double num4 = num5;
                double c = num5 - 0.3333333333333333;
                num3 = Main.hue2rgb( num3 , t , num2 );
                num4 = Main.hue2rgb( num4 , t , num2 );
                double num6 = Main.hue2rgb( c , t , num2 );
                r = (byte) Math.Round( num3 * 255.0 );
                g = (byte) Math.Round( num4 * 255.0 );
                b = (byte) Math.Round( num6 * 255.0 );
            }
            return new Color( (int) r , (int) g , (int) b );
        }

        private float StripWidth( float progressOnStrip )
        {
            float num = 1f;
            float lerpValue = ModUtils.GetLerpValue( 0f , 0.2f , progressOnStrip , true );
            num *= 1f - ( 1f - lerpValue ) * ( 1f - lerpValue );
            return MathHelper.Lerp( 0f , Width , num );
        }

        private static VertexStrip _vertexStrip = new VertexStrip( );
    }
}
