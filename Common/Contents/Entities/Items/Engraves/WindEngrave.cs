using EternalResolve.Common.Contents.Entities.Items.Accessories;
using EternalResolve.Common.Contents.Entities.Items.Accessories.Boots;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class WindEngrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "风之刻印" );
            Tooltip.AddTranslation( Chinese , "" +
                "增加你20%的移动速度\n" +
                "获得永久羽落效果\n" +
                "在有风的时候, 你获得10%的伤害加成" );

            DisplayName.AddTranslation( English , "Wind Engrave" );

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
            player.maxRunSpeed += 0.20f;
            player.moveSpeed += 0.20f;
            player.AddBuff( BuffID.Featherfall , 1 );
            if ( Main.windSpeedTarget > 0 )
            {
                player.GetDamage( DamageClass.Generic ) += 0.1f;
            }
            base.UpdateAccessory( player , hideVisual );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Windrunner>( ) , 1 ).
                AddIngredient( ItemID.Aglet , 1 ).
                AddIngredient( ModContent.ItemType<Rkatsiteli>( ) , 1 ).
                AddIngredient( ItemID.PaperAirplaneA , 4 ).
                AddTile( TileID.Anvils ).
                Register( );

            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Windrunner>( ) , 1 ).
                AddIngredient( ItemID.Aglet , 1 ).
                AddIngredient( ModContent.ItemType<Rkatsiteli>( ) , 1 ).
                AddIngredient( ItemID.PaperAirplaneB , 4 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}
