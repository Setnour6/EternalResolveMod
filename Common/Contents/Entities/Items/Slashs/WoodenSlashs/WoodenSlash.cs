
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.WoodenSlashs
{
    public class WoodenSlash : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "练习用刀" );
            DisplayName.AddTranslation( English , "Slash · Practice" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 2 );
            Item.damage = 9;
            Item.useTime = Item.useAnimation;
            Item.UseSound = null;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<WoodenSlashChop>( );
            Item.shootSpeed = 8f;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<SlashSoul>( ) , 2 ).
                AddIngredient( ItemID.IronBar , 2 ).
                AddIngredient( ItemID.WoodenSword , 1 ).
                AddTile( TileID.WorkBenches ).
                Register( );

            CreateRecipe( ).
               AddIngredient( ModContent.ItemType<SlashSoul>( ) , 2 ).
               AddIngredient( ItemID.LeadBar , 2 ).
               AddIngredient( ItemID.WoodenSword , 1 ).
               AddTile( TileID.WorkBenches ).
               Register( );
            base.AddRecipes( );
        }
    }
}
