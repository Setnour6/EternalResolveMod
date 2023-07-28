using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection;
using Terraria;
using Terraria.DataStructures;
using Terraria.Graphics;
using Terraria.Graphics.Shaders;

namespace EternalResolve.Common.Graphics.Vertexs
{
    // Token: 0x02000150 RID: 336
    public class TrailShaderData : ShaderData
    {
        // Token: 0x06000716 RID: 1814 RVA: 0x00022F2C File Offset: 0x0002112C
        private static Matrix GetNormalizedTransformationmatrix( SpriteViewMatrix matrix )
        {
            Viewport viewport = (Viewport) TrailShaderData.vpinfo.GetValue( matrix );
            Vector2 vector = new Vector2( (float) viewport.Width , (float) viewport.Height );
            Matrix matrix2 = Matrix.CreateOrthographicOffCenter( 0f , vector.X , vector.Y , 0f , 0f , 1f );
            return Matrix.Invert( matrix.EffectMatrix ) * matrix.ZoomMatrix * matrix2;
        }

        // Token: 0x06000717 RID: 1815 RVA: 0x00022FA4 File Offset: 0x000211A4
        public TrailShaderData( Ref<Effect> shader , string passName ) : base( shader , passName )
        {
        }

        // Token: 0x06000718 RID: 1816 RVA: 0x00022FF0 File Offset: 0x000211F0
        public virtual void Apply( DrawData? drawData = null )
        {
            base.Shader.Parameters[ "uColor" ].SetValue( this._uColor );
            base.Shader.Parameters[ "uSaturation" ].SetValue( this._uSaturation );
            base.Shader.Parameters[ "uSecondaryColor" ].SetValue( this._uSecondaryColor );
            base.Shader.Parameters[ "uTime" ].SetValue( (float) ( Main._drawInterfaceGameTime.TotalGameTime.TotalSeconds % 3600.0 ) );
            base.Shader.Parameters[ "uOpacity" ].SetValue( this._uOpacity );
            base.Shader.Parameters[ "uShaderSpecificData" ].SetValue( this._shaderSpecificData );
            if ( drawData != null )
            {
                DrawData value = drawData.Value;
                Vector4 zero = Vector4.Zero;
                if ( drawData.Value.sourceRect != null )
                {
                    zero = new Vector4( (float) value.sourceRect.Value.X , (float) value.sourceRect.Value.Y , (float) value.sourceRect.Value.Width , (float) value.sourceRect.Value.Height );
                }
                base.Shader.Parameters[ "uSourceRect" ].SetValue( zero );
                base.Shader.Parameters[ "uWorldPosition" ].SetValue( Main.screenPosition + value.position );
                base.Shader.Parameters[ "uImageSize0" ].SetValue( new Vector2( (float) value.texture.Width , (float) value.texture.Height ) );
            }
            else
            {
                base.Shader.Parameters[ "uSourceRect" ].SetValue( new Vector4( 0f , 0f , 4f , 4f ) );
            }
            if ( this._uImage0 != null )
            {
                Main.graphics.GraphicsDevice.Textures[ 0 ] = this._uImage0;
                Main.graphics.GraphicsDevice.SamplerStates[ 0 ] = SamplerState.LinearWrap;
                base.Shader.Parameters[ "uImageSize0" ].SetValue( new Vector2( (float) this._uImage0.Width , (float) this._uImage0.Height ) );
            }
            if ( this._uImage1 != null )
            {
                Main.graphics.GraphicsDevice.Textures[ 1 ] = this._uImage1;
                Main.graphics.GraphicsDevice.SamplerStates[ 1 ] = SamplerState.LinearWrap;
                base.Shader.Parameters[ "uImageSize1" ].SetValue( new Vector2( (float) this._uImage1.Width , (float) this._uImage1.Height ) );
            }
            if ( this._uImage2 != null )
            {
                Main.graphics.GraphicsDevice.Textures[ 2 ] = this._uImage2;
                Main.graphics.GraphicsDevice.SamplerStates[ 2 ] = SamplerState.LinearWrap;
                base.Shader.Parameters[ "uImageSize2" ].SetValue( new Vector2( (float) this._uImage2.Width , (float) this._uImage2.Height ) );
            }
            if ( this._useProjectionMatrix )
            {
                base.Shader.Parameters[ "uMatrixTransform0" ].SetValue( TrailShaderData.GetNormalizedTransformationmatrix( Main.GameViewMatrix ) );
            }
            base.Apply( );
        }

        // Token: 0x06000719 RID: 1817 RVA: 0x00023392 File Offset: 0x00021592
        public TrailShaderData UseColor( float r , float g , float b )
        {
            return this.UseColor( new Vector3( r , g , b ) );
        }

        // Token: 0x0600071A RID: 1818 RVA: 0x000233A2 File Offset: 0x000215A2
        public TrailShaderData UseColor( Color color )
        {
            return this.UseColor( color.ToVector3( ) );
        }

        // Token: 0x0600071B RID: 1819 RVA: 0x000233B1 File Offset: 0x000215B1
        public TrailShaderData UseColor( Vector3 color )
        {
            this._uColor = color;
            return this;
        }

        // Token: 0x0600071C RID: 1820 RVA: 0x000233BB File Offset: 0x000215BB
        public TrailShaderData UseImage0( Texture2D texture )
        {
            this._uImage0 = texture;
            return this;
        }

        // Token: 0x0600071D RID: 1821 RVA: 0x000233C5 File Offset: 0x000215C5
        public TrailShaderData UseImage1( Texture2D texture )
        {
            this._uImage1 = texture;
            return this;
        }

        // Token: 0x0600071E RID: 1822 RVA: 0x000233CF File Offset: 0x000215CF
        public TrailShaderData UseImage2( Texture2D texture )
        {
            this._uImage2 = texture;
            return this;
        }

        // Token: 0x0600071F RID: 1823 RVA: 0x000233D9 File Offset: 0x000215D9
        public TrailShaderData UseOpacity( float alpha )
        {
            this._uOpacity = alpha;
            return this;
        }

        // Token: 0x06000720 RID: 1824 RVA: 0x000233E3 File Offset: 0x000215E3
        public TrailShaderData UseSecondaryColor( float r , float g , float b )
        {
            return this.UseSecondaryColor( new Vector3( r , g , b ) );
        }

        // Token: 0x06000721 RID: 1825 RVA: 0x000233F3 File Offset: 0x000215F3
        public TrailShaderData UseSecondaryColor( Color color )
        {
            return this.UseSecondaryColor( color.ToVector3( ) );
        }

        // Token: 0x06000722 RID: 1826 RVA: 0x00023402 File Offset: 0x00021602
        public TrailShaderData UseSecondaryColor( Vector3 color )
        {
            this._uSecondaryColor = color;
            return this;
        }

        // Token: 0x06000723 RID: 1827 RVA: 0x0002340C File Offset: 0x0002160C
        public TrailShaderData UseProjectionMatrix( bool doUse )
        {
            this._useProjectionMatrix = doUse;
            return this;
        }

        // Token: 0x06000724 RID: 1828 RVA: 0x00023416 File Offset: 0x00021616
        public TrailShaderData UseSaturation( float saturation )
        {
            this._uSaturation = saturation;
            return this;
        }

        // Token: 0x06000725 RID: 1829 RVA: 0x00023420 File Offset: 0x00021620
        public virtual TrailShaderData GetSecondaryShader( Entity entity )
        {
            return this;
        }

        // Token: 0x06000726 RID: 1830 RVA: 0x00023423 File Offset: 0x00021623
        public TrailShaderData UseShaderSpecificData( Vector4 specificData )
        {
            this._shaderSpecificData = specificData;
            return this;
        }

        // Token: 0x04000130 RID: 304
        private static FieldInfo vpinfo = typeof( SpriteViewMatrix ).GetField( "_viewport" , BindingFlags.Instance | BindingFlags.NonPublic );

        // Token: 0x04000131 RID: 305
        public Vector3 _uColor = Vector3.One;

        // Token: 0x04000132 RID: 306
        public Vector3 _uSecondaryColor = Vector3.One;

        // Token: 0x04000133 RID: 307
        public float _uSaturation = 1f;

        // Token: 0x04000134 RID: 308
        public float _uOpacity = 1f;

        // Token: 0x04000135 RID: 309
        public Texture2D _uImage0;

        // Token: 0x04000136 RID: 310
        public Texture2D _uImage1;

        // Token: 0x04000137 RID: 311
        public Texture2D _uImage2;

        // Token: 0x04000138 RID: 312
        public bool _useProjectionMatrix;

        // Token: 0x04000139 RID: 313
        public Vector4 _shaderSpecificData = Vector4.Zero;
    }
}
