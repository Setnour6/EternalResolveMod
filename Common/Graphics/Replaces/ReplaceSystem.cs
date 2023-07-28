using EternalResolve.Common.Graphics.Replaces.ReplaceCodes;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Graphics.Replaces
{
    /// <summary>
    /// 替换原版资源的系统.
    /// </summary>
    public class ReplaceSystem
    {
        public static Asset<Texture2D> GetTexture( string path )
        {
            return ModContent.Request<Texture2D>( "EternalResolve/Common/Graphics/Replaces/ReplaceContents/" + path );
        }
        public static void PostSetupContent( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                Replace_ItemSlots.Replace( );
                Replace_Items.Replace( );
            }
        }
        public static void Unload( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                Replace_Myth.UnLoad( );
                Replace_ItemSlots.UnLoad( );
                Replace_Items.UnLoad( );
            }
        }
    }
}