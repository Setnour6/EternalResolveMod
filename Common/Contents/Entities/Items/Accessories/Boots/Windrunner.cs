using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Boots
{
    public class Windrunner : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "风行者" );
            Tooltip.AddTranslation( Chinese ,
                "增加跳跃高度\n" +
                "增加跳跃速度\n" +
                "增加你10%的移动速度\n" +
                "\"你跑得很快, \n" +
                "但是和香港记者比你还差的远.\"" );

            DisplayName.AddTranslation( English , "Wind Runner" );
            Tooltip.AddTranslation( English ,
                "Add jump power\n" +
                "Add jump speed\n" +
                "Add your 10% moveSpeed\n" +
                "\"But... Hong Kong reporters faster than you.\"" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 4 );
            Item.defense = 2;
            Item.value = Item.sellPrice( 0 , 2 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.moveSpeed += 0.1f;
            player.maxRunSpeed += 0.1f;
            player.jumpSpeedBoost += 2f;
            player.maxFallSpeed -= 1f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.Feather , 8 ).
            AddIngredient( ItemID.Silk , 6 ).
            AddIngredient( ModContent.ItemType<WoodenBoots>( ) , 1 ).
            AddTile( TileID.WorkBenches ).
            Register( );
        }
    }
}
