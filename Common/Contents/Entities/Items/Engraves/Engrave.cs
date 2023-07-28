using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class Engrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "空的刻印" );
            DisplayName.AddTranslation( English , "Engrave" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 99;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 3 );
            Item.maxStack = 1;
            Item.value = Item.sellPrice( 0 , 0 , 50 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 2 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 4 ).
                AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}