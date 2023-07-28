using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.PrisonFire
{
    public class PrisonFireBayonet : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "狱火刺剑" );
            DisplayName.AddTranslation( English , "Hell Fire Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 3 );
            Item.damage = 12;
            Item.knockBack = 0;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.shoot = ModContent.ProjectileType<PrisonFireBayonet_Pro>( );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.HellstoneBar , 48 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}