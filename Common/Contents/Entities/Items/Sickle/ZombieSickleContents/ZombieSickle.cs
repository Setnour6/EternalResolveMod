using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Sickle.ZombieSickleContents
{
    public class ZombieSickle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "尸骨镰" );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.damage += 2;
            Item.useTime = Item.useAnimation;
            Item.UseSound = null;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<ZombieSickle_Pro>( );
            Item.shootSpeed = 8f;
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.ZombieArm ).
                AddIngredient( ModContent.ItemType<IronSickle>( ) ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.ZombieArm ).
                AddIngredient( ModContent.ItemType<TanslateSickle>( ) ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}
