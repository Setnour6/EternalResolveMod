using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class BowHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "箭矢纹章" );
            Tooltip.AddTranslation( Chinese , "增加8%远程伤害" );
            DisplayName.AddTranslation( English , "Arc BowHeraldry" );
            Tooltip.AddTranslation( English , "" +
                "Add 8% ranged damage" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetDamage( DamageClass.Ranged ) += 0.08f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 5 ).
                AddIngredient( ItemID.IronBow , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.LeadBar , 5 ).
                AddIngredient( ItemID.LeadBow , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
