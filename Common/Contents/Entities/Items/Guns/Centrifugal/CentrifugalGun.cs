
using EternalResolve.Common.Contents.Entities.Items.Engraves;
using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.Centrifugal
{
    public class CentrifugalGun : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "离心枪" );
            Tooltip.AddTranslation( Chinese , "攻击必令目标附带霜火" );

            DisplayName.AddTranslation( English , "Centrifugal Gun" );
            Tooltip.AddTranslation( English , "The attack must be accompanied by frost and fire" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToGun( 5 );
            Item.damage += 20;
            Item.useAnimation = 16;
            Item.useTime = 16;
            Item.value = Item.sellPrice( 0 , 15 );
            base.SetDefaults( );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            type = ModContent.ProjectileType<CentrifugalBullet>( );
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddIngredient( ModContent.ItemType<IceEngrave>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 6 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}