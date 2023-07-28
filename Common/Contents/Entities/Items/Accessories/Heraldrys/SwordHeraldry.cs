using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class SwordHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "剑之纹章" );
            Tooltip.AddTranslation( Chinese , "增加8%近战伤害" );

            DisplayName.AddTranslation( English , "Sword Heraldry" );
            Tooltip.AddTranslation( English , "Increases melee damage by 8%" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetDamage( DamageClass.Melee ) += 0.08f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 5 ).
                AddIngredient( ItemID.IronBroadsword , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.LeadBar , 5 ).
                AddIngredient( ItemID.LeadBroadsword , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
