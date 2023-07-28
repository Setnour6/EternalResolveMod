using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.GhostWords
{
    public class GhostBow : ERProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.light = 0.5f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 30;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.width = 180;
            Projectile.height = 94;
        }
        public override void AI( )
        {
            Player player = Main.player[ Projectile.owner ];
            Projectile.Center = player.Center;
            Main.projFrames[ Projectile.type ] = 21;
            Vector2 vector = player.RotatedRelativePoint( player.MountedCenter , true );
            float w = ( Projectile.spriteDirection == -1 ) ? 3.1415925f : 0f;
            Projectile.frame++;
            if ( Projectile.frame + 1 >= Main.projFrames[ Projectile.type ] )
            {
                Projectile.frame = 0;
            }
            if ( Main.myPlayer == Projectile.owner )
            {
                if ( player.channel && !player.noItems && !player.CCed )
                {
                    Vector2 vector2 = Main.MouseWorld - vector;
                    vector2.Normalize( );
                    if ( Utils.HasNaNs( vector2 ) )
                    {
                        vector2 = Vector2.UnitX * (float) player.direction;
                    }
                    if ( vector2.X != Projectile.velocity.X || vector2.Y != Projectile.velocity.Y )
                    {
                        Projectile.netUpdate = true;
                    }
                    Projectile.velocity = vector2;
                }
                else
                {
                    Projectile.Kill( );
                }
            }
            if ( Projectile.frame == 17 )
            {
                Engine.PlaySound( SoundID.Item5 );
                for ( int count = 0; count < 15; count++ )
                {
                    Dust dust = Dust.NewDustDirect( Projectile.Center , 0 , 0 , 180 , 0f , 0f , 0 , new Color( 255 , 255 , 255 ) , 1.5f );
                    dust.noGravity = true;
                    dust.fadeIn = 1f;
                }
                Projectile.NewProjectile( Projectile.GetSource_FromAI() , player.Center , Projectile.velocity * 30f , ModContent.ProjectileType<GhostArrow>( ) , Projectile.damage , Projectile.knockBack , Main.myPlayer , 0f , 0f );
            }
            Projectile.position = player.RotatedRelativePoint( player.MountedCenter , true ) - Projectile.Size / 2f;
            Projectile.rotation = Utils.ToRotation( Projectile.velocity ) + w;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            player.ChangeDir( Projectile.direction );
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float) Math.Atan2( (double) ( Projectile.velocity.Y * (float) Projectile.direction ) , (double) ( Projectile.velocity.X * (float) Projectile.direction ) );
            base.AI( );
        }
    }
}