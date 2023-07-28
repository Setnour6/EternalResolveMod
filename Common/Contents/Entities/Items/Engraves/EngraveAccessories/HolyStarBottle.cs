using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves.EngraveAccessories
{
    public class HolyStarBottle_PowerForItem : GlobalItem
    {
        public override void GrabRange( Item item , Player player , ref int grabRange )
        {
            if ( item.type == ItemID.FallenStar && player.GetModPlayer<HolyStarBottle_Power>( ).Enable )
                grabRange *= 10000;
            base.GrabRange( item , player , ref grabRange );
        }
    }
    public class HolyStarBottle_Power : ModPlayer
    {
        public bool Enable = false;

        public override bool CloneNewInstances => true;

        public override void ResetEffects( )
        {
            Enable = false;
            base.ResetEffects( );
        }
    }
    public class HolyStarBottle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "圣星瓶" );
            DisplayName.AddTranslation( English , "Holy Star Bottle" );

            Tooltip.AddTranslation( Chinese , "允许你更快速地收集坠星" );
            Tooltip.AddTranslation( English , "Allows you to collect falling stars more quickly" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 2 );
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetModPlayer<HolyStarBottle_Power>( ).Enable = true;
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.FallenStar , 49 ).
                AddIngredient( ItemID.Bottle , 1 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}