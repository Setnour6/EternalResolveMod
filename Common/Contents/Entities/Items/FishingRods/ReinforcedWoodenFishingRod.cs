using EternalResolve.Common.Contents.Entities.Items.Materials;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.FishingRods
{
    /// <summary>
    /// 加固木钓竿.
    /// </summary>
    public class ReinforcedWoodenFishingRod : ModItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "加固木钓竿" );
            Tooltip.SetDefault( "Colin制造的第一把鱼竿,\n可以甩出三个吊钩;\n在白天时渔力翻倍." );
        }

        public override void SetDefaults( )
        {
            Item.width = 56;
            Item.height = 20;
            Item.knockBack = 8f;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.useStyle = 1;
            Item.value = 2000;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<ReinforcedBuoy>( );
            Item.shootSpeed = 10f;
            Item.fishingPole = 19;
        }

        public override void HoldItem( Player player )
        {
            if ( Main.dayTime )
            {
                Item.fishingPole = 38;
                return;
            }
            Item.fishingPole = 19;
        }

        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            float num = 0.783f;
            float num2 = (float) Math.Sqrt( velocity.X * velocity.X + velocity.Y * velocity.Y );
            double num3 = Math.Atan2( velocity.X , velocity.Y ) - num / 2f;
            double num4 = num / 40f;
            for ( int i = 0; i < 5; i++ )
            {
                double num5 = num3 + num4 * i;
                Projectile.NewProjectile( null , position.X , position.Y , num2 * (float) Math.Sin( num5 ) , num2 * (float) Math.Cos( num5 ) , type , damage , knockback , player.whoAmI , 0f , 0f );
            }
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }

        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.WoodFishingPole , 1 ).
                AddIngredient( ItemID.IronBar , 1 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) ).
                AddTile( TileID.WorkBenches ).
                Register( );

            CreateRecipe( ).
                AddIngredient( ItemID.WoodFishingPole , 1 ).
                AddIngredient( ItemID.LeadBar , 1 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) ).
                AddTile( TileID.WorkBenches ).
                Register( );
        }
    }
}
