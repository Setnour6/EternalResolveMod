using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Sickle
{
    public class IronSickle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "学徒镰刀" );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.IronBar , 8 ).
            AddTile( TileID.Anvils ).
            Register( );
        }
    }
}