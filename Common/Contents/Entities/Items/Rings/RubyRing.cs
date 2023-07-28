using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class RubyRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "红宝石戒指" );
            Tooltip.AddTranslation( Chinese , "" +
                "魔能上限增加1750\n" +
                "增加 20 生命上限" );

            DisplayName.AddTranslation( English , "Ruby Ring" );
            Tooltip.AddTranslation( English , "" +
                "Mana Maxvalue add 1750\n" +
                "Add 20 life max" );

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
            player.statLifeMax2 += 20;
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DefaultRing>( ) , 1 ).
                AddIngredient( ItemID.Ruby , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}