using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.ArcSwords
{
    public class PureBlade : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "刀" );
            Tooltip.AddTranslation( Chinese , "" +
                "就如同它的名字\n" +
                "就是单纯的一把刀\n" +
                "没什么特殊的\n" +
                "只能用来切水果\n" +
                "不 许 杀 人 哟 ~" );
            DisplayName.AddTranslation( English , "Pure Blade" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 2 );
            Item.useTime -= 5;
            Item.useAnimation -= 5;
            base.SetDefaults( );
        }
        public override void ModifyHitNPC( Player player , NPC target , ref int damage , ref float knockBack , ref bool crit )
        {
            if ( target.type == NPCID.Nymph )
                Item.SetDefaults( ModContent.ItemType<PureBlade2>( ) );
            base.ModifyHitNPC( player , target , ref damage , ref knockBack , ref crit );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 16 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 2 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.LeadBar , 16 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 2 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}