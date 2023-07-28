using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.ManaBars
{
    public class ManaBarAssets : ModAssets
    {
        /// <summary>
        /// 满
        /// </summary>
        public static Texture2D Bar0;

        /// <summary>
        /// 空
        /// </summary>
        public static Texture2D Bar1;
        public override void Load( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                Bar0 = GetAsset( "Bar0" );
                Bar1 = GetAsset( "Bar1" );
            }
            base.Load( );
        }
        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/ManaBars/" + name ).Value;
        }
    }
}
