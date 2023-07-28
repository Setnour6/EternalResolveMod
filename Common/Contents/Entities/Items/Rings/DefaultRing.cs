using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class DefaultRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "普通戒指" );
            Tooltip.AddTranslation( Chinese , "魔能上限增750" );

            DisplayName.AddTranslation( English , "Default Ring" );
            Tooltip.AddTranslation( English , "Mana Maxvalue add 750" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 2 );
            Item.value = Item.sellPrice( 0 , 0 , 80 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 750;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 6 ).
                AddTile( TileID.Anvils ).
                Register( );

            CreateRecipe( ).
                AddIngredient( ItemID.LeadBar , 6 ).
                AddTile( TileID.Anvils ).
                Register( );

            base.AddRecipes( );
        }
    }
}