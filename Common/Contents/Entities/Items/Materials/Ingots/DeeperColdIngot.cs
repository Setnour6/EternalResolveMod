using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Materials.Ingots
{
    /// <summary>
    /// 深寒集合
    /// </summary>
    public class DeeperColdIngot : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "深寒集合" );
            Tooltip.AddTranslation( Chinese , "违反熵增定律" );

            DisplayName.AddTranslation( English , "Deeper Cold Ingot" );
            Tooltip.AddTranslation( English , "Violation of the law of entropy increase" );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( 16 ).
                AddIngredient( ItemID.SnowBlock , 96 ).
                AddIngredient( ItemID.IceBlock , 48 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
        }
    }
}