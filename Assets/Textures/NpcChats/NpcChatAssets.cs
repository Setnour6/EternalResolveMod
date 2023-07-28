using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.NpcChats
{
    public class NpcChatAssets : ModAssets
    {
        public static Texture2D Panel;
        public static Texture2D PanelSlot;
        public static Texture2D Button;
        public override void Load( )
        {
            Panel = GetAsset( "Panel" );
            PanelSlot = GetAsset( "PanelSlot" );
            Button = GetAsset( "PanelSlot" );
            base.Load( );
        }
        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/NpcChats/" + name ).Value;
        }
    }
}
