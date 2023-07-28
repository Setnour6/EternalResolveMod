using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class GelYoyo : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "大团凝胶" );
            Tooltip.AddTranslation( Chinese , "" +
                "黏在敌人身上\n" +
                "抛出去可是件难事...\n" +
                "但是你要知道，收回来也许更麻烦。" );
            DisplayName.AddTranslation( English , "Gel Yoyo" );
            Tooltip.AddTranslation( English , "" +
                "Stick to the enemy \n " +
                "It's hard to throw it out... \n" +
                "But you know, it may be more troublesome to take it back." );
        }
        public override void SetDefaults( )
        {
            ToYoyo( 1 , ModContent.ProjectileType<YoyoProjectiles.GelYoyo>( ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( 23 , 32 ).
            Register( );
        }
    }
}
