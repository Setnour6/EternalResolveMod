using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class ForeverNight : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "永夜" );
            DisplayName.AddTranslation( English , "Forever Night" );
        }

        public override void SetDefaults( )
        {
            ToYoyo( 4 , ModContent.ProjectileType<YoyoProjectiles.ForeverNight>( ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( 3279 , 1 ).
            AddIngredient( 3281 , 1 ).
            AddIngredient( ModContent.ItemType<SkyBlueYoyo>( ) , 1 ).
            AddIngredient( 3282 , 1 ).
            AddTile( 16 ).
            Register( );

            CreateRecipe( ).
            AddIngredient( 3280 , 1 ).
            AddIngredient( 3281 , 1 ).
            AddIngredient( ModContent.ItemType<SkyBlueYoyo>( ) , 1 ).
            AddIngredient( 3282 , 1 ).
            AddTile( 16 ).
            Register( );
        }
    }
}