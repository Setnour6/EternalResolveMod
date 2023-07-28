using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Materials.Ingots
{
    /// <summary>
    /// 锻钢锭.
    /// </summary>
    public class ForgedSteelIngot : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "锻钢锭" );
            Tooltip.AddTranslation( Chinese , "唯美暴烈的工业气息" );
            DisplayName.AddTranslation( English , "Forged Ingot" );
            Tooltip.AddTranslation( English , "Beautiful and violent industrial atmosphere" );
        }
        public override void SetDefaults( )
        {
            ToItem( 3 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddRecipeGroup( RecipeGroupID.IronBar , 4 ).
            AddTile( TileID.Anvils ).
            Register( );

            CreateRecipe( ).
            AddIngredient( ItemID.IronOre , 6 ).
            AddTile( TileID.Furnaces ).
            Register( );

            CreateRecipe( ).
            AddIngredient( ItemID.LeadOre , 6 ).
            AddTile( TileID.Furnaces ).
            Register( );
        }
    }
}