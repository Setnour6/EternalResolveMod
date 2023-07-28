using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class MushroomYoyo : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "蘑菇悠悠球" );
            Tooltip.AddTranslation( Chinese , "敲中敌人能恢复些许血量" );

            DisplayName.AddTranslation( English , "Mushroom Yoyo" );
            Tooltip.AddTranslation( English , "Hitting the enemy can restore some health" );

        }
        public override void SetDefaults( )
        {
            ToYoyo( 1 , ModContent.ProjectileType<YoyoProjectiles.MushroomYoyo>( ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( 5 , 2 ).
            Register( );
        }
    }
}
