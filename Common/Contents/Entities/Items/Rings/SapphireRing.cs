using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class SapphireRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "蓝宝石戒指" );
            Tooltip.AddTranslation( Chinese , "" +
                "魔能上限增加1750\n" +
                "增加 60 最大魔力值" );

            DisplayName.AddTranslation( English , "Sapphire Ring" );
            Tooltip.AddTranslation( English , "" +
                "Mana Maxvalue add 1750\n" +
                "Add 60 magic value max" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.lifeRegen += 5;
            Item.value = Item.sellPrice( 0 , 1 , 25 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 1750;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );

        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.statManaMax2 += 60;
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