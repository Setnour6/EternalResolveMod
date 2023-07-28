using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.SteelAnvils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.ShiningStars
{
    public class ShiningStar : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "闪耀之星" );
            DisplayName.AddTranslation( English , "Shining Star" );
            Terraria.Item.staff[ Item.type ] = true;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToRod( 2 );
            Item.crit = 8;
            Item.useAnimation = 16;
            Item.useTime = 8;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ShiningStar_Pro>( );
            Item.shootSpeed = 1f;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            velocity = Vector2.Zero;
            position = new Vector2( Main.MouseWorld.X , Main.MouseWorld.Y - 0.5f * (float) Main.screenHeight * Main.UIScale ) + Utils.RotatedByRandom( new Vector2( 200f , 0f ) , 6.283 );
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.FallenStar , 49 ).
            AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 5 ).
            AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 6 ).
            AddTile( ModContent.TileType<SteelAnvil_Tile>( ) ).
            Register( );
        }
    }
}