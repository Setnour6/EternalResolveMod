using EternalResolve.Common.Contents.Entities.Items.Engraves.EngraveAccessories;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class StarEngrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "星之刻印" );
            DisplayName.AddTranslation( English , "Star Engrave" );

            Tooltip.AddTranslation( Chinese , "" +
                "允许你更快速地收集落星\n" +
                "允许你在太空时使用正常重力无限飞行\n" +
                "你的攻击处决小白龙\n" +
                "允许你更快速地收集飞行之魂" );

            Tooltip.AddTranslation( English , "" +
                "Your attack will execute the little white dragon\n" +
                "Allows you to collect soul of flight more quickly\n" +
                "Allows you to collect falling stars more quickly\n" +
                "Allows you to fly infinitely with normal gravity while in space"
                );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 5 );
            Item.defense = 3;
            Item.value = Item.sellPrice( 0 , 2 );
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetModPlayer<DragonRelic_Power>( ).Enable = true;
            player.GetModPlayer<DragonBloodEssence_Power>( ).Enable = true;

            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<HolyStarBottle>( ) , 1 ).
                AddIngredient( ModContent.ItemType<StarDome>( ) , 1 ).
                AddIngredient( ModContent.ItemType<DragonBloodEssence>( ) , 1 ).
                AddIngredient( ModContent.ItemType<DragonRelic>( ) , 1 ).
                AddIngredient( ItemID.ShinyRedBalloon , 1 ).
                AddIngredient( ItemID.Cloud , 64 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}
