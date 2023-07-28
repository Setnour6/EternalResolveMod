using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.DreamInterpreters
{
    public class DreamInterpreter_Gun : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "梦境诠释者" );
            DisplayName.AddTranslation( English , "Achieving Dream" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToGun( 5 );
            Item.damage += 10;
            Item.useAnimation = 7;
            Item.useTime = 7;
            Item.shootSpeed = 15.99f;
            Item.value = Item.sellPrice( 0 , 15 );
            base.SetDefaults( );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2( -16 , 0 );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            position = player.Center + Main.rand.NextVector2Unit( ) * 7;
            Vector2 velOverride = ( Main.MouseWorld - player.Center );
            velOverride.Normalize( );
            velocity = velOverride * 15.99f;
            type = ModContent.ProjectileType<DreamInterpreter_Pro>( );
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<RealSilverIngot>( ) , 6 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 6 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<RealTungstenIngot>( ) , 6 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddIngredient( ModContent.ItemType<Guding>( ) , 6 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );
            base.AddRecipes( );
        }
    }
}
