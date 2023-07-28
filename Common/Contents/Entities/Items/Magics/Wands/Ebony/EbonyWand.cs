using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.Wands.Ebony
{
    public class EbonyWand : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "乌木法杖" );
            DisplayName.AddTranslation( English , "Ebony Wand" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            Terraria.Item.staff[ Item.type ] = true;
        }
        public override void SetDefaults( )
        {
            ToRod( 2 );
            Item.damage -= 1;
            Item.useAnimation = 32;
            Item.useTime = 32;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item118;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<EbonyWand_Pro>( );
            Item.shootSpeed = 6f;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.Ebonwood , 12 ).
            AddTile( TileID.WorkBenches ).
            Register( );
            base.AddRecipes( );
        }
    }
}
