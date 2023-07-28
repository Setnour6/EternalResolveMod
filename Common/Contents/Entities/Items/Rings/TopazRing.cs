using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class TopazRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "黄玉戒指" );
            Tooltip.AddTranslation( Chinese , "" +
                "魔能上限增加1750\n" +
                "获得自发光" );

            DisplayName.AddTranslation( English , "Topaz Ring" );
            Tooltip.AddTranslation( English , "" +
                "Mana Maxvalue add 1750\n" +
                "Get a light" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 , 25 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 1750;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );

        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            Lighting.AddLight( player.Center , 0.1f , 0.1f , 0.1f );
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DefaultRing>( ) , 1 ).
                AddIngredient( ItemID.Sapphire , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}