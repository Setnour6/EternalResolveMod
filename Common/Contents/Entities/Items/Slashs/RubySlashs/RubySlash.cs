
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.RubySlashs
{
    public class RubySlash : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "利刃 · 红玉" );
            Tooltip.AddTranslation( Chinese , "对史莱姆必定暴击" );

            DisplayName.AddTranslation( English , "Slash · Ruby" );
            Tooltip.AddTranslation( English , "It must be a crit to slime" );

        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.damage += 2;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.UseSound = null;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<RubySlashChop>( );
            Item.shootSpeed = 8f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.Ruby , 1 ).
            AddIngredient( ItemID.IronBar , 6 ).
            AddIngredient( ItemID.Gel , 99 ).
            AddIngredient( ModContent.ItemType<Broken>( ) , 1 ).
            AddIngredient( ModContent.ItemType<SlashSoul>( ) , 4 ).
            AddTile( TileID.Anvils ).
            Register( );

            CreateRecipe( ).
            AddIngredient( ItemID.Ruby , 1 ).
            AddIngredient( ItemID.LeadBar , 6 ).
            AddIngredient( ItemID.Gel , 99 ).
            AddIngredient( ModContent.ItemType<Broken>( ) , 1 ).
            AddIngredient( ModContent.ItemType<SlashSoul>( ) , 4 ).
            AddTile( TileID.Anvils ).
            Register( );

        }
    }
}
