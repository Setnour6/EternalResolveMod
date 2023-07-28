using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.Systems.RefineSystems
{
    public class RefineAssets : ModAssets
    {
        public static Texture2D Panel;

        public static Texture2D PanelSlot;

        public static Texture2D Slot;

        public static Texture2D Button;

        public static Texture2D Bar;

        public static Texture2D Bar2;

        public static Texture2D Close;

        public static Texture2D CheckMouseItem;

        public static Texture2D Dust;

        public override void Load( )
        {
            Panel = GetAsset( "Panel" );
            PanelSlot = GetAsset( "PanelSlot" );
            Slot = GetAsset( "Slot" );
            Button = GetAsset( "Button" );
            Bar = GetAsset( "Bar" );
            Bar2 = GetAsset( "Bar2" );
            Close = GetAsset( "Close" );
            CheckMouseItem = GetAsset( "CheckMouseItem" );
            Dust = GetAsset( "Dust" );

            base.Load( );
        }
        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/Systems/RefineSystems/" + name ).Value;
        }
    }
}
