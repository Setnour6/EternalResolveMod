using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Tiles.AdvancedWorkbenchs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.Breezes
{
    public class Breeze : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "轻风" );
            Tooltip.AddTranslation( Chinese , "" +
                "\"我内心的暴乱慢慢平静\n" +
                "   只剩下几声叹息, 无话可说, 不如不说.\"\n" +
                "持握时, 获得40%的移动速度\n" +
                "在有风的时候, \n" +
                "   你所攻击的任何敌人都会为你提供一定的属性加成\n" +
                "这把武器无法在地狱使用" );

            DisplayName.AddTranslation( English , "Breeze" );
            Tooltip.AddTranslation( English , "" +
                "The storm at last sank to a gentle wind. \n" +
                "Gain 40% movement speed when you holding the Breeze\n" +
                "When there is wind, \n" +
                "   any enemy you attack will give you a certain attribute bonus\n" +
                "This weapon cannot be used in hell" );

        }

        public override void SetDefaults( )
        {
            ToBow( 4 );
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useTime = 5;
            Item.reuseDelay = 14;
            Item.useAnimation = 12;

            Item.shoot = ModContent.ProjectileType<BreezeArrow_Pro>( );
            Item.shootSpeed = 20f;
            Item.knockBack = 2.4f;
            Item.UseSound = SoundID.Item5;
            Item.useAmmo = AmmoID.Arrow;
            Item.noMelee = true;
            Item.channel = true;
            Item.autoReuse = true;
        }

        public override bool CanUseItem( Player player )
        {
            return !player.ZoneUnderworldHeight;
        }

        public override void HoldItem( Player player )
        {
            player.maxRunSpeed += 0.4f;
            player.accRunSpeed += 0.4f;

            Dust dust = Dust.NewDustPerfect( Main.LocalPlayer.Center , 20 , new Vector2?( new Vector2( 0f , 0f ) ) , 0 , new Color( 255 , 255 , 255 ) , 1f );
            dust.noGravity = true;
            dust.fadeIn = 1f;
            base.HoldItem( player );
        }

        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            type = ModContent.ProjectileType<BreezeArrow_Pro>( );
            Engine.PlaySound( SoundID.Item5 , player.Center );
            position += new Vector2( (float) ( Main.rand.NextBool( ) ? -(float) Main.rand.Next( 16 ) : Main.rand.Next( 16 ) ) , (float) ( Main.rand.NextBool( ) ? -(float) Main.rand.Next( 16 ) : Main.rand.Next( 16 ) ) );
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }

        public override Vector2? HoldoutOffset( )
        {
            return new Vector2?( new Vector2( -12f , 1.1f ) );
        }

        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Hunter>( ) , 1 ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 2 ).
                AddIngredient( ModContent.ItemType<RealSilverIngot>( ) , 8 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );

            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<Hunter>( ) , 1 ).
                AddIngredient( ModContent.ItemType<ForgedSteelIngot>( ) , 2 ).
                AddIngredient( ModContent.ItemType<RealTungstenIngot>( ) , 8 ).
                AddIngredient( ModContent.ItemType<Origin>( ) , 1 ).
                AddTile( ModContent.TileType<AdvancedWorkbench_Tile>( ) ).
                Register( );

        }
    }
}
