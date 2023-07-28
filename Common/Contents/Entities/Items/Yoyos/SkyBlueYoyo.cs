using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class SkyBlueYoyo : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "天蓝球" );
            DisplayName.AddTranslation( English , "Sky Blue" );
        }
        public override void SetDefaults( )
        {
            ToYoyo( 4 , ModContent.ProjectileType<YoyoProjectiles.SkyBlueYoyo>( ) );
            Item.damage += 8;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( 148 , 3 ).
            AddIngredient( 147 , 20 ).
            AddIngredient( 154 , 45 ).
            AddIngredient( 150 , 40 ).
            AddTile( 16 ).
            Register( );
        }
    }
}
