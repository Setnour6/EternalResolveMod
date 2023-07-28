using EternalResolve.Common.Contents.Entities.Items.HitEffects;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.SteelSlashs
{
    public class SteelSlashChopFrame : GlobalProjectile
    {
        public override bool CloneNewInstances => true;

        public override bool InstancePerEntity => true;

        public override GlobalProjectile Clone( )
        {
            return base.Clone( );
        }

        public int Timer = 0;

        public int FrameSpeed = 0;

    }
    public class SteelSlashChop : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "刀锋" );
            DisplayName.AddTranslation( English , "Slash Chop" );
            Main.projFrames[ Projectile.type ] = 16;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 200 , 200 );
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 11;
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            Projectile.NewProjectile( new ERProjectileSource( ) , target.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
            base.OnHitNPC( target , damage , knockback , crit );
        }
        public override bool PreAI( )
        {
            Player player = Main.player[ Projectile.owner ];
            Vector2 vector = player.RotatedRelativePoint( player.MountedCenter , true );
            SteelSlashChopFrame ProjectileFrame = Projectile.GetGlobalProjectile<SteelSlashChopFrame>( );
            ProjectileFrame.FrameSpeed = 2;
            ProjectileFrame.Timer++;
            PlayerFrame( Projectile.frame );
            PlaySound( Projectile.frame );
            if ( ProjectileFrame.Timer % ProjectileFrame.FrameSpeed == 0 )
            {
                ProjectileFrame.Timer = 0;
                Projectile.frame += 1;
            }
            if ( Projectile.frame > 16 )
            {
                Projectile.Kill( );
            }
            Projectile.position = player.MountedCenter - Projectile.Size / 2f + new Vector2( player.direction * 30 , 0 );
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            player.ChangeDir( Projectile.direction );
            player.heldProj = Projectile.whoAmI;
            player.channel = true;
            player.itemTime = player.HeldItem.useTime + 2;
            player.itemAnimation = player.HeldItem.useAnimation + 2;
            player.itemRotation = (float) Math.Atan2( ( Projectile.velocity.Y * Projectile.direction ) , ( Projectile.velocity.X * Projectile.direction ) );
            return false;
        }
        public void PlayerFrame( int frame )
        {
            Player player = Main.player[ Projectile.owner ];
            int changeFrame = 0;
            switch ( frame )
            {
                case 1:
                    changeFrame = 1;
                    break;
                case 2:
                    changeFrame = 2;
                    break;
                case 3:
                    changeFrame = 3;
                    break;
                case 4:
                    changeFrame = 4;
                    break;
                case 5:
                    changeFrame = 4;
                    break;
                case 6:
                    changeFrame = 4;
                    break;
                case 7:
                    changeFrame = 3;
                    break;
                case 8:
                    changeFrame = 1;
                    break;
                case 9:
                    changeFrame = 1;
                    break;
                case 10:
                    changeFrame = 1;
                    break;
                case 11:
                    changeFrame = 1;
                    break;
                case 12:
                    changeFrame = 1;
                    break;
                case 13:
                    changeFrame = 2;
                    break;
                case 14:
                    changeFrame = 3;
                    break;
                case 15:
                    changeFrame = 4;
                    break;
                case 16:
                    changeFrame = 4;
                    break;
            }
            player.bodyFrame.Y = player.bodyFrame.Height * changeFrame;
        }
        public void PlaySound( int frame )
        {
            switch ( frame )
            {
                case 2:
                    Engine.PlaySound( SoundID.Item1 , Projectile.Center );
                    break;
                case 7:
                    Engine.PlaySound( SoundID.Item1 , Projectile.Center );
                    break;
                case 12:
                    Engine.PlaySound( SoundID.Item1 , Projectile.Center );
                    break;
            }
        }
    }
}
