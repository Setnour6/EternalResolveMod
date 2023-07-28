using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Sickle
{
    public class TanslateSickle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "学徒镰刀" );
            Tooltip.SetDefault( "" );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.LeadBar , 8 ).
            AddTile( TileID.Anvils ).
            Register( );
        }
    }
}