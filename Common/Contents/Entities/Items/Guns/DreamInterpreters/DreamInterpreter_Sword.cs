using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.DreamInterpreters
{
    public class DreamInterpreter_Sword : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "梦境诠释者" );
            DisplayName.AddTranslation( English , "Achieving Dream" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 5 );
            Item.damage += 4;
            Item.value = Item.sellPrice( 0 , 15 );
            Item.shoot = ModContent.ProjectileType<DreamInterpreter_SwordPro>( );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<RealSilverIngot>( ) , 6 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 6 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<RealTungstenIngot>( ) , 6 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 6 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}