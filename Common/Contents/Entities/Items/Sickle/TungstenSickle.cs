using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Sickle
{
    public class TungstenSickle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "钨镰刀" );
            Tooltip.SetDefault( "" +
                "放置于背包时移动速度增加12%" );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.damage += 2;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateInventory( Player player )
        {
            player.moveSpeed += 0.12f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.TungstenBar , 12 ).
            AddTile( TileID.Anvils ).
            Register( );
        }
    }
}