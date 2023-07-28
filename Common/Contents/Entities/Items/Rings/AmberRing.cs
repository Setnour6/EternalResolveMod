using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class AmberRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "琥珀戒指" );
            Tooltip.AddTranslation( Chinese , "" +
                "魔能上限增加2000\n" +
                "当你位于沙漠, 你将获得跳跃加成" );

            DisplayName.AddTranslation( English , "Amber Ring" );
            Tooltip.AddTranslation( English , "" +
                "Mana Maxvalue add 2000" +
                "When you are in the desert , you will gain jump speed boost " );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 , 25 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 2000;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            if ( player.ZoneDesert )
            {
                player.jumpSpeedBoost += 0.1f;
            }
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DefaultRing>( ) , 1 ).
                AddIngredient( ItemID.Amber , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}