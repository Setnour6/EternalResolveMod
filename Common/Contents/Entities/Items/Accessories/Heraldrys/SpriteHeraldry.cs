using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class SpriteHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "灵之纹章" );
            Tooltip.AddTranslation( Chinese , "增加8%召唤伤害" );

            DisplayName.AddTranslation( English , "Sprite Heraldry" );
            Tooltip.AddTranslation( English , "Increases summon damage by 8%" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetDamage( DamageClass.Summon ) += 0.08f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 5 ).
                AddIngredient( ItemID.ManaCrystal , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.LeadBar , 5 ).
                AddIngredient( ItemID.ManaCrystal , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
