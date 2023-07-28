using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.DeeperCold.Rod
{
    public class DeeperColdRod : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "深寒杖" );
            Tooltip.AddTranslation( Chinese , "" +
                "在雪地使用将返还魔力" );

            DisplayName.AddTranslation( English , "Deeper Cold Rod" );
            Tooltip.AddTranslation( English , "" +
                "When used in snow, it will no use mana" );

            Terraria.Item.staff[ Item.type ] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToRod( 4 );
            Item.damage = 18;
            Item.crit = 8;
            Item.mana = 20;
            Item.useTime = 5;
            Item.reuseDelay = 14;
            Item.useAnimation = 12;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<DeeperColdRod_Pro>( );
            Item.shootSpeed = 10f;
            Item.value = Item.sellPrice( 0 , 1 );
            Terraria.Item.staff[ Item.type ] = true;
            base.SetDefaults( );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            if ( player.ZoneSnow )
            {
                player.ManaEffect( Item.mana );
                player.statMana += Item.mana;
            }
            position += Main.rand.NextVector2Unit( ) * 50;
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
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
