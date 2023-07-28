using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class BrillianceYoyo : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "光辉" );
            Tooltip.AddTranslation( Chinese , "增加25点破甲" );

            DisplayName.AddTranslation( English , "Brilliance" );
            Tooltip.AddTranslation( English , "Gain 25 armor breaking" );

        }
        public override void SetDefaults( )
        {
            ToYoyo( 6 , ModContent.ProjectileType<YoyoProjectiles.BrillianceYoyo>( ) );
        }
        public override void HoldItem( Player player )
        {
            player.GetArmorPenetration(DamageClass.Generic) += 25;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( 1225 , 16 ).
            AddTile( 16 ).
            Register( );
        }
    }
}