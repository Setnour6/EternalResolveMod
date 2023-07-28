using EternalResolve.Common.Contents.Entities.Items;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Tiles.RefiningWorkbenchs
{
    /// <summary>
    /// 武器精炼工作台; 用于打开武器精炼系统.
    /// </summary>
    public class RefiningWorkbench : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "武器精炼工作台" );
            Tooltip.AddTranslation( Chinese , "" +
                "可用于打开武器精炼系统\n" +
                "无论你有多少该物品\n" +
                "它们总是打开同一个精炼系统" );
            DisplayName.AddTranslation( English , "Weapon Refining Workbench" );
            Tooltip.AddTranslation( English , "" +
                "Allow you to open the Weapon Refining system" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBrick( 4 , ModContent.TileType<RefiningWorkbench_Tile>( ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 16 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}
