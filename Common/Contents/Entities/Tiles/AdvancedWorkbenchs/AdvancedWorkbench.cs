using EternalResolve.Common.Contents.Entities.Items;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs
{
    public class AdvancedWorkbench : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "高级工作台" );
            DisplayName.AddTranslation( English , "Advanced Workbench" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBrick( 4 , ModContent.TileType<AdvancedWorkbench_Tile>( ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 8 ).
            AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
            AddIngredient( ItemID.WorkBench , 1 ).
            AddIngredient( ItemID.IronAnvil , 1 ).
            AddIngredient( ModContent.ItemType<SteelAnvil>( ) ).
            AddIngredient( TileID.Furnaces , 1 ).
            Register( );

            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 8 ).
            AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
            AddIngredient( ItemID.WorkBench , 1 ).
            AddIngredient( ItemID.LeadAnvil , 1 ).
            AddIngredient( ModContent.ItemType<SteelAnvil>( ) ).
            AddIngredient( TileID.Furnaces , 1 ).
            Register( );
        }
    }
}