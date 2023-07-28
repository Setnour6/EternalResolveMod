using EternalResolve.Common.Contents.Modulars.EkandaModular;
using EternalResolve.Common.Stellaris;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using On.Terraria.Graphics.Effects;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Hooks
{
    public class BloomLightSystem : ModSystem
    {
        public override void Load( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                GraphicsDevice = Main.graphics.GraphicsDevice;
                FilterManager.EndCapture += FilterManager_EndCapture;
            }
            base.Load( );
        }
        private void FilterManager_EndCapture( FilterManager.orig_EndCapture orig , Terraria.Graphics.Effects.FilterManager self , RenderTarget2D finalTexture , RenderTarget2D screenTarget1 , RenderTarget2D screenTarget2 , Color clearColor )
        {
            if ( SubWorld_Ekanda.InEkandaWorld )
            {
                if ( this.bloom == null )
                {
                    this.InitShader( );
                }
                w = screenTarget1.Width;
                h = screenTarget1.Height;
                _w = (int) ( (float) BloomLightSystem.w / BloomLightSystem.resFactor );
                _h = (int) ( (float) BloomLightSystem.h / BloomLightSystem.resFactor );
                this.r0 = new RenderTarget2D( this.GraphicsDevice , BloomLightSystem.w , BloomLightSystem.h );
                this.GraphicsDevice.SetRenderTarget( this.r0 );
                Main.spriteBatch.Begin( (SpriteSortMode) 1 , BlendState.AlphaBlend );
                this.GraphicsDevice.Textures[ 0 ] = screenTarget1;
                this.DrawCurrentTex( (float) BloomLightSystem.w , (float) BloomLightSystem.h , 0f , 0f );
                Main.spriteBatch.End( );
                this.r1 = new RenderTarget2D( this.GraphicsDevice , BloomLightSystem.w , BloomLightSystem.h );
                this.GraphicsDevice.SetRenderTarget( this.r1 );
                this.GraphicsDevice.Clear( Color.Transparent );
                this.GraphicsDevice.Textures[ 1 ] = this.r0;
                this.bloom.ApplyLuminanceFilter( );
                this.DrawCurrentTex( (float) BloomLightSystem.w , (float) BloomLightSystem.h , 0f , 0f );
                this.r2 = new RenderTarget2D( this.GraphicsDevice , BloomLightSystem._w , BloomLightSystem._h );
                this.GraphicsDevice.SetRenderTarget( this.r2 );
                this.bloom.LightSourceCoord.SetValue( new Vector2( 0.5f , 0.5f ) );
                this.GraphicsDevice.Textures[ 0 ] = this.r1;
                this.bloom.ApplyGodRay( );
                this.DrawCurrentTex( (float) BloomLightSystem.w , (float) BloomLightSystem.h , 0f , 0f );
                this.r2 = this.Blur( this.r2 , 5 , 1 , true );
                this.GraphicsDevice.SetRenderTarget( screenTarget1 );
                this.GraphicsDevice.Clear( clearColor );
                this.GraphicsDevice.Textures[ 0 ] = this.r2;
                this.bloom.ApplyMixTwoImage( );
                this.DrawCurrentTex( (float) BloomLightSystem.w , (float) BloomLightSystem.h , 0f , 0f );
                this.r0.Dispose( );
                RenderTarget2D renderTarget2D = this.r1;
                if ( renderTarget2D != null )
                {
                    renderTarget2D.Dispose( );
                }
                RenderTarget2D renderTarget2D2 = this.r2;
                if ( renderTarget2D2 != null )
                {
                    renderTarget2D2.Dispose( );
                }
            }
            orig.Invoke( self , finalTexture , screenTarget1 , screenTarget2 , clearColor );
        }

        public override void Unload( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                FilterManager.EndCapture -= new FilterManager.hook_EndCapture( this.FilterManager_EndCapture );
            }
            base.Unload( );
        }

        public RenderTarget2D Blur( RenderTarget2D r1 , int recursionDepth = 0 , int type = 1 , bool dispose = true )
        {
            RenderTarget2D r2 = new RenderTarget2D( this.GraphicsDevice , BloomLightSystem._w , BloomLightSystem._h );
            this.GraphicsDevice.SetRenderTarget( r2 );
            this.GraphicsDevice.Clear( Color.Transparent );
            this.GraphicsDevice.Textures[ 0 ] = r1;
            this.bloom.CurrentTechnique.Passes[ type ].Apply( );
            this.DrawCurrentTex( (float) BloomLightSystem.w , (float) BloomLightSystem.h , 0f , 0f );
            if ( dispose )
            {
                r1.Dispose( );
            }
            if ( type == 1 )
            {
                return this.Blur( r2 , recursionDepth , 2 , true );
            }
            if ( recursionDepth > 0 )
            {
                return this.Blur( r2 , recursionDepth - 1 , 1 , true );
            }
            return r2;
        }

        public void DrawCurrentTex( float width , float height , float originX = 0 , float originY = 0 )
        {
            Color c = Color.White;
            GraphicsDevice.DrawUserIndexedPrimitives( PrimitiveType.TriangleStrip ,
                new VertexPositionColorTexture[ ]{
                    new VertexPositionColorTexture(new Vector3(originX, originY, 0), c, new Vector2(0, 0)),
                    new VertexPositionColorTexture(new Vector3(originX + width, originY, 0), c, new Vector2(1, 0)),
                    new VertexPositionColorTexture(new Vector3(originX + width, originY + height, 0), c, new Vector2(1, 1)),
                    new VertexPositionColorTexture(new Vector3(originX, originY + height, 0), c, new Vector2(0, 1))} ,
                0 , 4 , new int[ ] { 1 , 2 , 0 , 3 } , 0 , 2 );
        }

        private void InitShader( )
        {
            this.bloom = new BloomEffect( this.GraphicsDevice , ModContent.GetFileBytes( "EternalResolve/Effects/Effect-0.fxb" ) );
            this.bloom.InitDefaultValue( );
            this.bloom.RayWeight.SetValue( 0.9f );
            this.bloom.RayIntensity.SetValue( 0.1f );
        }

        private BloomEffect bloom;

        private GraphicsDevice GraphicsDevice;

        private static float resFactor = 4f;

        private static int _w;

        private static int w;

        private static int _h;

        private static int h;

        private RenderTarget2D r0;

        private RenderTarget2D r1;

        private RenderTarget2D r2;
    }
}