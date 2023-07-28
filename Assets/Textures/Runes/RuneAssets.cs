using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace EternalResolve.Assets.Textures.Runes
{
    public class RuneAssets : ModAssets
    {
        public static Texture2D BlockBG;

        public static Texture2D[ ] BackGrounds = new Texture2D[ 4 ];

        public static Texture2D[ ] Lines = new Texture2D[ 2 ];

        public static Texture2D[ ] Slots = new Texture2D[ 6 ];

        public static Texture2D[ ] Wheels = new Texture2D[ 2 ];

        public static Texture2D InformationPanel;

        public static Texture2D Text;

        public static Texture2D Top;

        public static Texture2D RuneMouse;

        public static Texture2D Icon;

        public static Texture2D ShadowOfTop;

        public static Texture2D Rough;

        public static Texture2D Ordinary;

        public static Texture2D Excellent;

        public static Texture2D Preeminent;

        public static Texture2D Legend;

        public static List<Texture2D> RuneTypeList = new List<Texture2D>( );

        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/Runes/" + name ).Value;
        }
        public override void Load( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                BlockBG = GetAsset( "BlockBG" );
                for ( int count = 0; count < BackGrounds.Length; count++ )
                    BackGrounds[ count ] = GetAsset( "BackGround-" + count );
                for ( int count = 0; count < Lines.Length; count++ )
                    Lines[ count ] = GetAsset( "Line-" + count );
                for ( int count = 0; count < Slots.Length; count++ )
                    Slots[ count ] = GetAsset( "Slot-" + count );
                for ( int count = 0; count < Wheels.Length; count++ )
                    Wheels[ count ] = GetAsset( "Wheel-" + count );
                InformationPanel = GetAsset( "InformationPanel" );
                Text = GetAsset( "Text" );
                Top = GetAsset( "Top" );
                RuneMouse = GetAsset( "RuneMouse" );
                Icon = GetAsset( "Icon" );
                ShadowOfTop = GetAsset( "ShadowOfTop" );

                Rough = GetAsset( "Rough" );
                RuneTypeList.Add( Rough );

                Ordinary = GetAsset( "Ordinary" );
                RuneTypeList.Add( Ordinary );

                Excellent = GetAsset( "Excellent" );
                RuneTypeList.Add( Excellent );

                Preeminent = GetAsset( "Preeminent" );
                RuneTypeList.Add( Preeminent );

                Legend = GetAsset( "Legend" );
                RuneTypeList.Add( Legend );

            }
            base.Load( );
        }
    }
}
