using EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.BloodGold;
using EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.PrisonFire;
using EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.RottenGold;
using EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.Vegetation;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.EternalNight
{
    public class EternalNight : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "永夜西洋剑" );
            DisplayName.AddTranslation( English , "Eternal Night Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 4 );
            Item.damage = 12;
            Item.knockBack = 0;
            Item.value = Item.sellPrice( 0 , 2 , 75 );
            Item.shoot = ModContent.ProjectileType<EternalNight_Pro>( );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<PrisonFireBayonet>( ) , 1 ).
                AddIngredient( ModContent.ItemType<VegetationBayonet>( ) , 1 ).
                AddIngredient( ModContent.ItemType<BloodGoldBayonet>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<PrisonFireBayonet>( ) , 1 ).
                AddIngredient( ModContent.ItemType<VegetationBayonet>( ) , 1 ).
                AddIngredient( ModContent.ItemType<RottenGoldBayonet>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}