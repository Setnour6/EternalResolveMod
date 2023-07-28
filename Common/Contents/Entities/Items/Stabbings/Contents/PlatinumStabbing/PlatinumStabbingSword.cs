using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.PlatinumStabbing
{
    public class PlatinumStabbingSword : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "铂金刺剑" );
            DisplayName.AddTranslation( English , "Platinum Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 2 );
            Item.damage = 4;
            Item.knockBack = 0;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.PlatinumBar , 24 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}