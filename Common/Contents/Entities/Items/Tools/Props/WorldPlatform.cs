using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;

namespace EternalResolve.Common.Contents.Entities.Items.Tools.Props
{
    public class WorldPlatform : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "世界平台生成器" );
            DisplayName.AddTranslation( English , "World Platform" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.useAnimation = 10;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.shoot = ProjectileID.WoodenArrowFriendly;
            Item.shootSpeed = 1;
            base.SetDefaults( );
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int mouseY = Main.MouseWorld.Y.ToInt( ) / 16;
            if ( Main.netMode != NetmodeID.MultiplayerClient )
            {
                for ( int count = 0; count < Main.tile.Width; count++ ) // Main.tile.GetLength -> Main.tile.width
                {
                    WorldGen.PlaceTile( count , mouseY , TileID.Platforms );
                }
            }
            else
            {
                if ( Language.ActiveCulture == EternalResolve.Chinese )
                    Main.NewText( "该物品在多人模式下禁用！" , Color.Red );
                else
                    Main.NewText( "This item is ban on MutiMode." , Color.Red );
            }
            return false;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Wood , 99 ).
                Register( );
            base.AddRecipes( );
        }
    }
}