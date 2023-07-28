using EternalResolve.Common.Contents.Entities.Items;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Tiles.EkandaBricks
{
    public class EkandaBrick : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "埃坎达神殿砖" );
            DisplayName.AddTranslation( English , "Ekanda Brick" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBrick( 8 , ModContent.TileType<EkandaBrick_Tile>( ) );
            //  Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
        public override bool CanUseItem( Player player )
        {
            return true; // Item.GetGlobalItem<AntiCheating>( ).FormalChannel;
        }
    }
}
