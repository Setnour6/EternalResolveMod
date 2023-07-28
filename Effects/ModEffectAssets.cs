using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;

namespace EternalResolve.Effects
{
    public class ModEffectAssets : ModSystem
    {
        public static Effect[ ] Effect = new Effect[ 2 ];

        public override void PostSetupContent( )
        {
            for ( int count = 0; count < Effect.Length; count++ )
            {
                Effect[ count ] = GetEffect( "Effect-" + count );
            }
            base.PostSetupContent( );
        }
        public static Effect GetEffect( string path )
        {
            return ModContent.Request<Effect>( "EternalResolve/Effects/" + path , AssetRequestMode.ImmediateLoad ).Value;
        }
    }
}
