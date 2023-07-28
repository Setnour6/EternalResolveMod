using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.FishingRods
{
    /// <summary>
    /// 漫游者钓竿.
    /// </summary>
    public class RoverFishingRod : ModItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "漫游者钓竿" );
            Tooltip.SetDefault( "可以甩出5个吊钩;" );
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
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<RoverBuoy>( );
            Item.shootSpeed = 10f;
            Item.fishingPole = 80;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float num = 0.783f;
            float num2 = (float) Math.Sqrt( velocity.X * velocity.X + velocity.Y * velocity.Y );
            double num3 = Math.Atan2( velocity.X , velocity.Y ) - num / 2f;
            double num4 = num / 40f;
            for ( int i = 0; i < 5; i++ )
            {
                double num5 = num3 + num4 * i;
                Projectile.NewProjectile( null , position.X , position.Y , num2 * (float) Math.Sin( num5 ) , num2 * (float) Math.Cos( num5 ) , type , damage , knockback , player.whoAmI , 0f , 0f ); // source from ai is better?
            }
            return false;
        }
    }
}