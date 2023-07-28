using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class TerraYoyo : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "无垠" );
            Tooltip.AddTranslation( Chinese , "" +
                "念天地之悠悠，独怆然而涕下.\n" +
                "获得200点破甲" );
            DisplayName.AddTranslation( English , "Vast Yoyo" );
            Tooltip.AddTranslation( English , "" +
                "When I think about the long time of heaven and earth, I weep alone.\n" +
                "Gain 200 armor breaking" );
        }
        public override void SetDefaults( )
        {
            ToYoyo( 7 , ModContent.ProjectileType<YoyoProjectiles.TerraYoyo>( ) );
        }
        public override void HoldItem( Player player )
        {
            player.GetArmorPenetration(DamageClass.Generic) += 200;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<BrillianceYoyo>( ) , 1 ).
            AddIngredient( ModContent.ItemType<ForeverNight>( ) , 1 ).
            AddIngredient( ModContent.ItemType<OldYoyo>( ) , 1 ).
            AddTile( 134 ).
            Register( );
        }
    }
}
