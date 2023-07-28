using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos
{
    public class MagicYoyo : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "附魔悠悠球" );
            DisplayName.AddTranslation( English , "Magic Yoyo" );
        }
        public override void SetDefaults( )
        {
            ToYoyo( 2 , ModContent.ProjectileType<YoyoProjectiles.MagicYoyo>( ) );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.EnchantedSword ).
                AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}