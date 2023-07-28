using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class ArcHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "弧线徽章" );
            Tooltip.AddTranslation( Chinese , "" +
                "增加6%近战暴击率\n" +
                "增加8%近战速度" );
            DisplayName.AddTranslation( English , "Arc Heraldry" );
            Tooltip.AddTranslation( English , "" +
                "Add 6% melee crit\n" +
                "Add 8% melee speed" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetCritChance( DamageClass.Melee ) += 6;
            player.meleeSpeed += 0.08f;
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
