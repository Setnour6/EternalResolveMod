using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace EternalResolve.Assets.Textures.Extras
{
    public class ExtraAssets : ModAssets
    {
        public static Texture2D[ ] Extra = new Texture2D[ 14 ];

        public override void Load( )
        {
            if ( Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                for ( int count = 0; count < Extra.Length; count++ )
                {
                    Extra[ count ] = GetAsset( "Extra_" + count );
                }
            }
            base.Load( );
        }
        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/Extras/" + name ).Value;
        }
    }
}
