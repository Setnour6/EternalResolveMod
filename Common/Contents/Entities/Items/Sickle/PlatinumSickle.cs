using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Sickle
{
    public class PlatinumSickle : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "铂金镰" );
            Tooltip.AddTranslation( Chinese , "伤害提升目标10%的防御" );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.damage += 5;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void ModifyHitNPC( Player player , NPC target , ref int damage , ref float knockBack , ref bool crit )
        {
            damage += target.defense / 10;
            base.ModifyHitNPC( player , target , ref damage , ref knockBack , ref crit );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.PlatinumBar , 12 ).
            AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
            AddTile( TileID.Anvils ).
            Register( );
        }
    }
}