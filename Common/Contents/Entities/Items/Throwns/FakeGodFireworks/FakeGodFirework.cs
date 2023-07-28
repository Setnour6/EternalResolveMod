using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Throwns.FakeGodFireworks
{
    public class FakeGodFirework : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "伪神焰火" );
            DisplayName.AddTranslation( English , "Fake God Firework" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 5 );
            Item.damage += 30;
            Item.useTime += 3;
            Item.useAnimation += 3;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<FakeGodFirework_Pro>( );
            Item.shootSpeed = 15.99f;
            Item.value = Item.sellPrice( 0 , 5 , 75 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.ShadowFlameKnife ).
                AddIngredient( ItemID.ShadowFlameHexDoll ).
                AddTile( TileID.MythrilAnvil ).
                Register( );
            base.AddRecipes( );
        }
    }
}