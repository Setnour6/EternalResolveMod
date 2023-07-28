using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class AmmoHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "弹丸徽章" );
            Tooltip.AddTranslation( Chinese , "" +
                "装备后远程暴击率增加10%" );
            DisplayName.AddTranslation( English , "Ammo Heraldry" );
            Tooltip.AddTranslation( English , "" +
                "Add 10% ranged crit" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.accessory = true;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetCritChance( DamageClass.Ranged ) += 10;
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