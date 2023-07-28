using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Tools.Axes
{
    public class DurableAxe : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "结实的斧头" );
            DisplayName.AddTranslation( English , "Durable Axe" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 1 );
            Item.axe = 9;
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Wood , 16 ).
                AddIngredient( ItemID.IronBar , 8 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );

            CreateRecipe( ).
                AddIngredient( ItemID.Wood , 16 ).
                AddIngredient( ItemID.LeadBar , 8 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );

            base.AddRecipes( );
        }
    }
}
