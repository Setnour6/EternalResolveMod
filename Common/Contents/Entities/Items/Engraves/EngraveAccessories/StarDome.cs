using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves.EngraveAccessories
{
    public class StarDome : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "星穹" );
            DisplayName.AddTranslation( English , "Star Dome" );
            Tooltip.AddTranslation( Chinese , "允许你在太空时使用正常重力无限飞行" );
            Tooltip.AddTranslation( English , "Allows you to fly infinitely with normal gravity while in space" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 5 );
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            if ( player.ZoneSkyHeight )
            {
                player.gravity = 0.4f;
                player.wingTime = 2;
            }
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.SoulofFlight , 128 ).
                AddIngredient( ItemID.CrystalBall , 1 ).
                AddIngredient( ItemID.FallenStar , 49 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 16 ).
                AddTile( TileID.MythrilAnvil ).
                Register( );
            base.AddRecipes( );
        }
    }
}
