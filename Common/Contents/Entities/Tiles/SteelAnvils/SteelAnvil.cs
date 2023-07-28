using EternalResolve.Common.Contents.Entities.Items;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils
{
    public class SteelAnvil : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "锻钢砧" );
            DisplayName.AddTranslation( English , "Steel Anvil" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBrick( 4 , ModContent.TileType<SteelAnvil_Tile>( ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 6 ).
            AddTile( TileID.WorkBenches ).
            Register( );
        }
    }
}
