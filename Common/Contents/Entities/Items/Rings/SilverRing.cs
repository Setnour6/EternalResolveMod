using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class SilverRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "银戒" );
            Tooltip.AddTranslation( Chinese , "魔能上限增加1000" );

            DisplayName.AddTranslation( English , " Silver Ring" );
            Tooltip.AddTranslation( English , "Mana Maxvalue add 1000" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 2 );
            Item.value = Item.sellPrice( 0 , 0 , 85 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 1000;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.SilverBar , 6 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}
