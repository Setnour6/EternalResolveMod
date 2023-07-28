using EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.IronStabbing;
using EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.LeadStabbing;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.Vegetation
{
    public class VegetationBayonet : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "草木刺剑" );
            DisplayName.AddTranslation( English , "Vegetation Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 3 );
            Item.damage = 12;
            Item.knockBack = 0;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.shoot = ModContent.ProjectileType<VegetationBayonet_Pro>( );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Vine , 12 ).
                AddIngredient( ModContent.ItemType<IronStabbingSword>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.Vine , 12 ).
                AddIngredient( ModContent.ItemType<LeadStabbingSword>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
