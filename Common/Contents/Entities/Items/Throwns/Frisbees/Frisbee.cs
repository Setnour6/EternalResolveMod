using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Throwns.Frisbees
{
    public class Frisbee : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "利刃飞盘" );
            DisplayName.AddTranslation( English , "Frisbee" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            Item.CloneDefaults( ItemID.LightDisc );
            Item.damage = 14;
            Item.useAnimation += 5;
            Item.useTime += 5;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.shoot = ModContent.ProjectileType<FrisbeeProjectile>( );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
           AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 6 ).
            AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
           Register( );
            CreateRecipe( ).
           AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 6 ).
            AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
            Register( );
        }
    }
}