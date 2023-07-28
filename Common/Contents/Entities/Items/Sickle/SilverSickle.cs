using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Sickle
{
    public class SilverSickle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "银镰刀" );
            Tooltip.SetDefault( "" +
                "放置于背包时移动速度增加12%" );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.damage += 2;
            Item.value = Item.sellPrice( 0 , 0 , 80 );
        }
        public override void UpdateInventory( Player player )
        {
            player.moveSpeed += 0.12f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.SilverBar , 12 ).
            AddTile( TileID.Anvils ).
            Register( );
        }
    }
}