using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.Ekanda
{
    public class EkandaAssets : ModAssets
    {
        public static Texture2D[ ] Stone = new Texture2D[ 9 ];

        public static Texture2D[ ] BG = new Texture2D[ 9 ];

        public static Texture2D Door;

        public override void Load( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                for ( int count = 0; count < Stone.Length; count++ )
                {
                    Stone[ count ] = GetAsset( "EkandaStone_" + count );
                }
                for ( int count = 0; count < BG.Length; count++ )
                {
                    BG[ count ] = GetAsset( "BG_" + count );
                }
                Door = GetAsset( "Door" );
            }
            base.Load( );
        }

        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/Ekanda/" + name ).Value;
        }
    }
}