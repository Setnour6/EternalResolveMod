using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.BloodGold
{
    public class BloodGoldBayonet : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "血金刺剑" );
            DisplayName.AddTranslation( English , "Blood Gold Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 3 );
            Item.damage = 10;
            Item.knockBack = 0;
            Item.shoot = ModContent.ProjectileType<BloodGoldBayonet_Pro>( );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.CrimtaneBar , 48 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}