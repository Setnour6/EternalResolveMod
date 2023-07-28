using Terraria;
using Terraria.ID;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class StarShineHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "星耀徽章" );
            Tooltip.AddTranslation( Chinese , "" +
                "减少15%魔力消耗\n" +
                "增加40点魔力上限" );

            DisplayName.AddTranslation( English , "Star Shine Heraldry" );
            Tooltip.AddTranslation( English , "" +
            "Reduces mana cost by 15% \n" +
            "Increase the magic limit by 40 points" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.statManaMax2 += 40;
            player.manaCost *= 0.85f;
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
