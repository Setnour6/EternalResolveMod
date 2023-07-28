using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class DiamondRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "钻石戒指" );
            Tooltip.AddTranslation( Chinese , "" +
                "魔能上限增加1750" );

            DisplayName.AddTranslation( English , "Emerald Ring" );
            Tooltip.AddTranslation( English , "" +
                "Mana Maxvalue add 1750" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.defense = 7;
            Item.value = Item.sellPrice( 0 , 1 , 25 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 1750;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );

        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DefaultRing>( ) , 1 ).
                AddIngredient( ItemID.Diamond , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}