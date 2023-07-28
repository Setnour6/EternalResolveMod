using EternalResolve.Common.Contents.Entities.Items.DeeperCold.Rod;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.DeeperCold.Bow
{
    public class DeeperColdArrow : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "深寒箭" );
            Tooltip.AddTranslation( Chinese , "在雪地使用必定造成暴击" );

            DisplayName.AddTranslation( English , "Deeper Cold Arrow" );
            Tooltip.AddTranslation( English , "When used in snow, it will cause critical" );

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 99;
        }

        public override void SetDefaults( )
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 8;
            Item.height = 8;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 1.5f;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<DeeperColdRod_Pro>( );
            Item.shootSpeed = 12f;
            Item.ammo = AmmoID.Arrow;
        }

        public override void AddRecipes( )
        {
            CreateRecipe( 64 ).
                AddIngredient( ModContent.ItemType<DeeperColdIngot>( ) , 1 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}