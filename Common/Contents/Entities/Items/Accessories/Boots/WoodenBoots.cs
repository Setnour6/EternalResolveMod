using Terraria;
using Terraria.ID;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Boots
{
    public class WoodenBoots : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "木靴子" );
            DisplayName.AddTranslation( English , "WoodenBoots" );
            Tooltip.AddTranslation( Chinese , "增加8%移动速度" );
            Tooltip.AddTranslation( English , "Add your 8% move speed." );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 1 );
            Item.defense = 1;
            Item.value = Item.sellPrice( 0 , 0 , 25 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.moveSpeed += 0.08f;
            player.maxRunSpeed += 0.08f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Wood , 20 ).
                AddTile( TileID.WorkBenches ).
                Register( );
        }
    }
}
