using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.IronStabbing
{
    public class IronStabbingSword : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "铁刺剑" );
            DisplayName.AddTranslation( English , "Iron Rapier" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToStabbing( 1 );
            Item.damage = 2;
            Item.knockBack = 0;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 32 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}