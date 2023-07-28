using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Materials.Ingots
{
    public class RealSilverIngot : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "流光银锭" );
        }
        public override void SetDefaults( )
        {
            ToItem( 6 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.SilverBar , 1 ).
            AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 4 ).
            AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
            Register( );
        }
    }
}
