using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class CopperRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "铜戒" );
            Tooltip.AddTranslation( Chinese , "魔能上限增加500" );

            DisplayName.AddTranslation( English , "Copper Ring" );
            Tooltip.AddTranslation( English , "Mana Maxvalue add 500" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 1 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 500;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.CopperBar , 6 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}