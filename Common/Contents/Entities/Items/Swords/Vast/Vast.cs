using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Swords.Vast
{
    public class Vast_Draw : ModSystem
    {
    }
    public class Vast : ERItem
    {
        public override void SetDefaults( )
        {
            ToSword( 4 );
            Item.shoot = ModContent.ProjectileType<Vast_Pro>( );
            Item.shootSpeed = 1;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            base.SetDefaults( );
        }
    }
    public class Vast_Pro : ERProjectile
    {
        public override void SetDefaults( )
        {
            ToProjectile( 58 , 58 );
            Projectile.penetrate = -1;
            Projectile.timeLeft = 200;
            Projectile.extraUpdates = 10;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 0;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 70;
            base.SetDefaults( );
        }
        private Vector2 v_1 = new Vector2( -56 , -35 );
        private Vector2 v2 = Vector2.Zero;
        private bool Dir = false;
        private int Pdir = 1;
        private float Prot = 0;

        public override void AI( )
        {
            Player player = Main.LocalPlayer;
            if ( !Dir )
            {
                Pdir = Math.Sign( Main.mouseX - player.Center.X + Main.screenPosition.X );
                Vector2 vc = -( new Vector2( Main.mouseX , Main.mouseY ) - player.Center + Main.screenPosition );
                Prot = (float) Math.Atan2( vc.Y , vc.X );
                if ( Pdir == 1 )
                {
                    Prot += (float) ( Math.PI );
                }
                Dir = true;
            }
            Vector2 v0 = v_1.RotatedBy( 1.6 / 170d * Math.PI * ( 200 - Projectile.timeLeft ) );
            if ( Projectile.timeLeft < 30 )
            {
                Projectile.Kill( );
                v0 = v_1.RotatedBy( 1.6 * Math.PI );
            }
            //  Projectile.spriteDirection = Pdir;
            v0.X *= Pdir;
            Vector2 v1 = new Vector2( v0.X , v0.Y * 0.5f ).RotatedBy( Prot ) - new Vector2( 29 , 29 );
            Projectile.position = player.Center + v1 + Vector2.One * 29;
            v2 = Projectile.Center - player.Center;
            v2.X *= Pdir;
            float Rot = (float) ( Math.Atan2( v2.Y , v2.X ) + Math.PI / 4d * Pdir );
            Projectile.rotation = Rot + 45.ToRad( );
            Projectile.velocity = v2.RotatedBy( Math.PI / 2d ) / v2.Length( );
            base.AI( );
        }
    }
}