
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.SteelSlashs
{
    public class SteelSlash : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "锻钢刃" );
            DisplayName.AddTranslation( English , "Slash · Steel" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.useTime = Item.useAnimation;
            Item.UseSound = null;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<SteelSlashChop>( );
            Item.shootSpeed = 8f;
            Item.value = Item.sellPrice( 0 , 1 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<SlashSoul>( ) , 2 ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 2 ).
                AddIngredient( ItemID.StoneBlock , 6 ).
                AddTile( TileID.WorkBenches ).
                Register( );

            CreateRecipe( ).
               AddIngredient( ModContent.ItemType<SlashSoul>( ) , 2 ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 2 ).
               AddIngredient( ItemID.StoneBlock , 6 ).
               AddTile( TileID.WorkBenches ).
               Register( );
            base.AddRecipes( );
        }
    }
}
