using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.Menus
{
    public class MenuAssets : ModAssets
    {
        public static Texture2D Panel;

        public static Texture2D Out;

        public static Texture2D In;

        public static Texture2D LuckDraw;

        public static Texture2D DailyTask;

        public static Texture2D PanelLine;

        public static Texture2D IOBorder;

        public static Texture2D LuckDrawBorder;


        public override void Load( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                Panel = GetAsset( "Panel" );
                Out = GetAsset( "Out" );
                In = GetAsset( "In" );
                LuckDraw = GetAsset( "LuckDraw" );
                DailyTask = GetAsset( "DailyTask" );
                PanelLine = GetAsset( "PanelLine" );
                IOBorder = GetAsset( "IOBorder" );
                LuckDrawBorder = GetAsset( "LuckDrawBorder" );
            }
            base.Load( );
        }
        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/Menus/" + name ).Value;
        }
    }
}
