using Terraria;
using Terraria.ID;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class InsectHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "甲虫徽章" );
            Tooltip.AddTranslation( Chinese , "增加1个仆从位和1个哨兵位" );

            DisplayName.AddTranslation( English , "Insect Heraldry" );
            Tooltip.AddTranslation( English , "Add 1 servant position and 1 sentry position" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.maxMinions += 1;
            player.maxTurrets += 1;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.GoldBar , 8 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.PlatinumBar , 8 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
