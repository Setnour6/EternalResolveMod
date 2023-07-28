using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.SilverStabbing
{
    public class SilverStabbingSword : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "银刺剑" );
            DisplayName.AddTranslation( English , "Silver Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 1 );
            Item.damage = 2;
            Item.knockBack = 1f;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.SilverBar , 32 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}