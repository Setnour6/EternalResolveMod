using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.RottenGold
{
    public class RottenGoldBayonet : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "魔金刺剑" );
            DisplayName.AddTranslation( English , "Demonite Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 3 );
            Item.damage = 10;
            Item.knockBack = 0;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.shoot = ModContent.ProjectileType<RottenGoldBayonet_Pro>( );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.DemoniteBar , 48 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}