using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Graphics.Vertexs
{
    public class VertexLoader : ModSystem
    {
        public static Effect PixelShader;

        public static TrailShaderData TrailShaderData;

        public override void Load( )
        {
            PixelShader = ModContent.Request<Effect>( "EternalResolve/Effects/PixelShader" , AssetRequestMode.ImmediateLoad ).Value;
            TrailShaderData = new TrailShaderData( new Ref<Effect>( PixelShader ) , "MagicMissile" ).UseProjectionMatrix( true );

            base.Load( );
        }
    }
}