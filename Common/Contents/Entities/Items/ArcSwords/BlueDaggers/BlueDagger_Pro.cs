using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.ArcSwords.BlueDaggers
{
    public class BlueDagger_Pro : ModProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.width = 68;
            Projectile.height = 64;
            Projectile.aiStyle = 75;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.ownerHitCheck = true;
            Projectile.localNPCHitCooldown = 8;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.light = 0.8f;
        }
        public override void AI( )
        {
            Main.projFrames[ Projectile.type ] = 28;
            Player player = Main.player[ Projectile.owner ];
            Vector2 value = player.RotatedRelativePoint( player.MountedCenter , true );
            float num = 0f;
            if ( Projectile.spriteDirection == -1 )
            {
                num = 3.1415927f;
            }
            int num2 = Projectile.frame + 1;
            Projectile.frame = num2;
            if ( num2 >= Main.projFrames[ Projectile.type ] )
            {
                Projectile.frame = 0;
            }
            Projectile.soundDelay--;
            if ( Projectile.soundDelay <= 0 )
            {
                SoundEngine.PlaySound( SoundID.Item1 , Projectile.Center );
                Projectile.soundDelay = 12;
            }
            if ( Main.myPlayer == Projectile.owner )
            {
                if ( player.channel && !player.noItems && !player.CCed )
                {
                    float scaleFactor = 1f;
                    if ( player.inventory[ player.selectedItem ].shoot == Projectile.type )
                    {
                        scaleFactor = player.inventory[ player.selectedItem ].shootSpeed * Projectile.scale;
                    }
                    Vector2 vector = Main.MouseWorld - value;
                    vector.Normalize( );
                    if ( vector.HasNaNs( ) )
                    {
                        vector = Vector2.UnitX * player.direction;
                    }
                    vector *= scaleFactor;
                    if ( vector.X != Projectile.velocity.X || vector.Y != Projectile.velocity.Y )
                    {
                        Projectile.netUpdate = true;
                    }
                    Projectile.velocity = vector;
                }
                else
                {
                    Projectile.Kill( );
                }
            }
            Projectile.Center += Projectile.velocity * 3f;
            Projectile.position = player.RotatedRelativePoint( player.MountedCenter , true ) - Projectile.Size / 2f;
            Projectile.rotation = Projectile.velocity.ToRotation( ) + num;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            player.ChangeDir( Projectile.direction );
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float) Math.Atan2( Projectile.velocity.Y * Projectile.direction , Projectile.velocity.X * Projectile.direction );
        }
    }
}
