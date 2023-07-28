using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Materials.Ingots
{
    public class RealTungstenIngot : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "方镇钨锭" );
        }
        public override void SetDefaults( )
        {
            ToItem( 6 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.TungstenBar , 1 ).
            AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 4 ).
            AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
            Register( );
        }
    }
}