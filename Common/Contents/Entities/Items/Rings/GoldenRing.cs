using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class GoldenRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "金戒" );
            Tooltip.AddTranslation( Chinese , "魔能上限增加1500" );

            DisplayName.AddTranslation( English , " Golden Ring" );
            Tooltip.AddTranslation( English , "Mana Maxvalue add 1500" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 1500;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.GoldBar , 6 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}