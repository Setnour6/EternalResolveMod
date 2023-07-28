using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class StarHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "星之纹章" );
            Tooltip.AddTranslation( Chinese , "增加8%魔法伤害" );

            DisplayName.AddTranslation( English , "Star Heraldry" );
            Tooltip.AddTranslation( English , "Increases magic damage by 8%" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetDamage( DamageClass.Magic ) += 0.08f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 5 ).
                AddIngredient( ItemID.FallenStar , 4 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.LeadBar , 5 ).
                AddIngredient( ItemID.FallenStar , 4 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
