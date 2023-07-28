using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.EternalSnowMountain
{
    public class CoinValueAssets : ModAssets
    {
        public static Texture2D Value1;

        public static Texture2D Value5;

        public static Texture2D Value10;

        public static Texture2D Value20;

        public static Texture2D Value50;

        public static Texture2D Value100;

        public override void Load( )
        {
            Value1 = GetAsset( "Value1" );
            Value5 = GetAsset( "Value5" );
            Value10 = GetAsset( "Value10" );
            Value20 = GetAsset( "Value20" );
            Value50 = GetAsset( "Value50" );
            Value100 = GetAsset( "Value100" );
            base.Load( );
        }

        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/EternalSnowMountain/" + name ).Value;
        }
    }
}