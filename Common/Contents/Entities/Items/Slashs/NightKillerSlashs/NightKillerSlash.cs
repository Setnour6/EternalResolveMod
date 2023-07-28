using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.NightKillerSlashs
{
    public class NightKillerSlash : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "利刃 · 斩夜" );
            Tooltip.AddTranslation( Chinese , "对蝙蝠必定暴击" );

            DisplayName.AddTranslation( English , "Slash · Night Killer" );
            Tooltip.AddTranslation( English , "It must be a crit to bat" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.damage += 2;
            Item.useTime = 9;
            Item.useAnimation = 9;
            Item.UseSound = null;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<NightKillerSlashChop>( );
            Item.shootSpeed = 8f;
            Item.value = Item.sellPrice( 0 , 1 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.BatBanner , 1 ).
                AddIngredient( ItemID.Diamond , 6 ).
                AddIngredient( ModContent.ItemType<Broken>( ) , 1 ).
                AddIngredient( ModContent.ItemType<SlashSoul>( ) , 16 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}
