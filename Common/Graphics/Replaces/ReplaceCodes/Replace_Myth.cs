using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.GameContent;

namespace EternalResolve.Common.Graphics.Replaces.ReplaceCodes
{
    public class Replace_Myth
    {
        static Asset<Texture2D>[ ] InventoryBacks = new Asset<Texture2D>[ 18 ];
        public static void Replace( )
        {
            InventoryBacks[ 0 ] = TextureAssets.InventoryBack;
            InventoryBacks[ 1 ] = TextureAssets.InventoryBack2;
            InventoryBacks[ 2 ] = TextureAssets.InventoryBack3;
            InventoryBacks[ 3 ] = TextureAssets.InventoryBack4;
            InventoryBacks[ 4 ] = TextureAssets.InventoryBack5;
            InventoryBacks[ 5 ] = TextureAssets.InventoryBack6;
            InventoryBacks[ 6 ] = TextureAssets.InventoryBack7;
            InventoryBacks[ 7 ] = TextureAssets.InventoryBack8;
            InventoryBacks[ 8 ] = TextureAssets.InventoryBack9;
            InventoryBacks[ 9 ] = TextureAssets.InventoryBack10;
            InventoryBacks[ 10 ] = TextureAssets.InventoryBack11;
            InventoryBacks[ 11 ] = TextureAssets.InventoryBack12;
            InventoryBacks[ 12 ] = TextureAssets.InventoryBack13;
            InventoryBacks[ 13 ] = TextureAssets.InventoryBack14;
            InventoryBacks[ 14 ] = TextureAssets.InventoryBack15;
            InventoryBacks[ 15 ] = TextureAssets.InventoryBack16;
            InventoryBacks[ 16 ] = TextureAssets.InventoryBack17;
            InventoryBacks[ 17 ] = TextureAssets.InventoryBack18;
            TextureAssets.InventoryBack = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back0" );
            TextureAssets.InventoryBack2 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back2" );
            TextureAssets.InventoryBack3 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back3" );
            TextureAssets.InventoryBack4 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back4" );
            TextureAssets.InventoryBack5 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back5" );
            TextureAssets.InventoryBack6 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back6" );
            TextureAssets.InventoryBack7 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back7" );
            TextureAssets.InventoryBack8 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back8" );
            TextureAssets.InventoryBack9 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back9" );
            TextureAssets.InventoryBack10 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back10" );
            TextureAssets.InventoryBack11 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back11" );
            TextureAssets.InventoryBack12 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back12" );
            TextureAssets.InventoryBack13 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back13" );
            TextureAssets.InventoryBack14 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back14" );
            TextureAssets.InventoryBack15 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back15" );
            TextureAssets.InventoryBack16 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back16" );
            TextureAssets.InventoryBack17 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back17" );
            TextureAssets.InventoryBack18 = ReplaceSystem.GetTexture( "MythModIconReplaces/Inventory_Back18" );
        }
        public static void UnLoad( )
        {
            TextureAssets.InventoryBack = InventoryBacks[ 0 ];
            TextureAssets.InventoryBack2 = InventoryBacks[ 1 ];
            TextureAssets.InventoryBack3 = InventoryBacks[ 2 ];
            TextureAssets.InventoryBack4 = InventoryBacks[ 3 ];
            TextureAssets.InventoryBack5 = InventoryBacks[ 4 ];
            TextureAssets.InventoryBack6 = InventoryBacks[ 5 ];
            TextureAssets.InventoryBack7 = InventoryBacks[ 6 ];
            TextureAssets.InventoryBack8 = InventoryBacks[ 7 ];
            TextureAssets.InventoryBack9 = InventoryBacks[ 8 ];
            TextureAssets.InventoryBack10 = InventoryBacks[ 9 ];
            TextureAssets.InventoryBack11 = InventoryBacks[ 10 ];
            TextureAssets.InventoryBack12 = InventoryBacks[ 11 ];
            TextureAssets.InventoryBack13 = InventoryBacks[ 12 ];
            TextureAssets.InventoryBack14 = InventoryBacks[ 13 ];
            TextureAssets.InventoryBack15 = InventoryBacks[ 14 ];
            TextureAssets.InventoryBack16 = InventoryBacks[ 15 ];
            TextureAssets.InventoryBack17 = InventoryBacks[ 16 ];
            TextureAssets.InventoryBack18 = InventoryBacks[ 17 ];
        }

    }
}
