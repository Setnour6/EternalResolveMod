using EternalResolve.Common.Contents.Entities.Buffs.Additions.MoveSpeeds;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.DeeperCold.Bow
{
    public class DeeperColdBow_Power : ModPlayer
    {
        protected override bool CloneNewInstances => true;

        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Player.HeldItem.type == ModContent.ItemType<DeeperColdBow>( ) )
            {
                if ( crit )
                {
                    Player.AddBuff( ModContent.BuffType<MoveSpeed_12>( ) , 180 );
                }
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
    public class DeeperColdBow : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "深寒" );
            Tooltip.AddTranslation( Chinese , "" +
                "当你在雪地造成暴击, 你获得12%移动速度, 持续3秒\n" +
                "该物品存在你的背包内时, 你无视冻伤、霜火" );

            DisplayName.AddTranslation( English , "Deeper cold Bow" );
            Tooltip.AddTranslation( English , "" +
                "Increase 12% move speed for 3 seconds when crit in the snow biome\n" +
                "Immune to Chilled and Frostburn when placed in inventory" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToBow( 4 );
            Item.damage += 1;
            Item.shootSpeed = 11;
            base.SetDefaults( );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DeeperColdIngot>( ) , 8 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 2 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}