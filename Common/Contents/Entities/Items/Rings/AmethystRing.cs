using EternalResolve.Common.Contents.Modulars.RingModular;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Rings
{
    public class AmethystRing : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "紫晶戒指" );
            Tooltip.AddTranslation( Chinese , "" +
                "魔能上限增加2500" );

            DisplayName.AddTranslation( English , "Amethyst Ring" );
            Tooltip.AddTranslation( English , "" +
                "Mana Maxvalue add 2500" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.value = Item.sellPrice( 0 , 1 , 25 );
            Item.GetGlobalItem<RingItem>( ).ManaAdd = 2500;
            Item.GetGlobalItem<RingItem>( ).IsRing = true;
            base.SetDefaults( );

        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DefaultRing>( ) , 1 ).
                AddIngredient( ItemID.Amethyst , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}