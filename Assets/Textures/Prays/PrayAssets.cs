using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.Prays
{
    public class PrayAssets : ModAssets
    {
        public static Texture2D[ ] BackGround = new Texture2D[ 3 ];

        public static Texture2D[ ] Button = new Texture2D[ 3 ];

        public static Texture2D Icon;

        public static Texture2D Top;

        public static Texture2D Panel;

        public static Texture2D TO1;

        public static Texture2D TO10;

        public static Texture2D Close;

        public static Texture2D ItemPanel;

        public static Texture2D PrayTextPanel;

        public static Texture2D[ ] Image = new Texture2D[ 3 ];

        public override void Load( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                for ( int count = 0; count < BackGround.Length; count++ )
                    BackGround[ count ] = GetAsset( "BackGround-" + count );
                for ( int count = 0; count < Button.Length; count++ )
                    Button[ count ] = GetAsset( "Button_" + count );
                for ( int count = 0; count < Image.Length; count++ )
                    Image[ count ] = GetAsset( "Image-" + count );

                Icon = GetAsset( "Icon" );
                Top = GetAsset( "Top" );
                Panel = GetAsset( "Panel" );
                TO1 = GetAsset( "TO1" );
                TO10 = GetAsset( "TO10" );
                Close = GetAsset( "Close" );
                ItemPanel = GetAsset( "ItemPanel" );
                PrayTextPanel = GetAsset( "PrayTextPanel" );
            }
        }
        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/Prays/" + name ).Value;
        }
    }
}
