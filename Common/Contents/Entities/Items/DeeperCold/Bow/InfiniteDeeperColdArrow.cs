using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.DeeperCold.Bow
{
    /// <summary>
    /// 无限深寒箭
    /// </summary>
    public class InfiniteDeeperColdArrow : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "无限深寒箭" );
            Tooltip.AddTranslation( Chinese , "取之不尽\n在雪地使用必定造成暴击" );

            DisplayName.AddTranslation( English , "Infinite Deeper Cold Arrow" );
            Tooltip.AddTranslation( English , "When used in snow, it will cause critical" );

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 99;
        }

        public override void SetDefaults( )
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 1;
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<DeeperColdArrow_Pro>( );
            Item.shootSpeed = 12f;
            Item.ammo = AmmoID.Arrow;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<DeeperColdArrow>( ) , 999 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 12 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}