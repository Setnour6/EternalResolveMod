using EternalResolve.Common.Contents.Entities.Buffs.Others;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Foods
{
    /// <summary>
    /// 烈酒.
    /// </summary>
    public class Liquor : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "烈酒" );

            DisplayName.AddTranslation( English , "Liquor" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 2 );
            Item.maxStack = 30;
            Item.useAnimation = 17;
            Item.useTime = 17;
            Item.useStyle = ItemUseStyleID.EatFood;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
            Item.value = Item.buyPrice( 0 , 0 , 50 , 0 );
            base.SetDefaults( );
        }
        public override bool? UseItem( Player player )
        {
            player.AddBuff( ModContent.BuffType<Drunk>( ) , 3600 );
            return player.itemAnimation == 0;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Ale , 16 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 8 ).
                AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}
