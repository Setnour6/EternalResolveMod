using EternalResolve.Common.Contents.Entities.Items.HitEffects;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.RedRiots
{
    public class RedRiotPowerFrame : GlobalProjectile
    {
        protected override bool CloneNewInstances => true;

        public override bool InstancePerEntity => true;

        public override GlobalProjectile Clone( Projectile from, Projectile to )
        {
            return base.Clone( from, to );
        }

        public int Timer = 0;

        public int FrameSpeed = 0;

    }

    public class RedRiotPower : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "刀锋" );
            DisplayName.AddTranslation( English , "Slash Chop" );
            Main.projFrames[ Projectile.type ] = 15;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 200 , 200 );
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = -1;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 120;
            Projectile.damage = 0;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 11;
        }
        public override bool PreAI( )
        {
            Player player = Main.player[ Projectile.owner ];
            Vector2 vector = player.RotatedRelativePoint( player.MountedCenter , true );
            RedRiotPowerFrame ProjectileFrame = Projectile.GetGlobalProjectile<RedRiotPowerFrame>( );
            ProjectileFrame.Timer++;
            ProjectileFrame.FrameSpeed = 3;
            if ( ProjectileFrame.Timer % ProjectileFrame.FrameSpeed == 0 )
            {
                ProjectileFrame.Timer = 0;
                Projectile.frame += 1;
            }
            if ( Projectile.frame > 15 )
            {
                Projectile.Kill( );
            }
            PlayerFrame( Projectile.frame );
            GiveDamage( Projectile.frame );
            PlaySound( Projectile.frame );
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
                    changeFrame = Main.rand.Next( 1 , 4 );
                    break;
                case 2:
                    changeFrame = Main.rand.Next( 1 , 4 );
                    break;
                case 3:
                    changeFrame = Main.rand.Next( 1 , 4 );
                    break;
                case 4:
                    changeFrame = Main.rand.Next( 1 , 4 );
                    break;
                case 5:
                    changeFrame = Main.rand.Next( 1 , 4 );
                    break;
                case 6:
                    changeFrame = Main.rand.Next( 1 , 4 );
                    break;
                case 7:
                    changeFrame = 3;
                    break;
                case 8:
                    changeFrame = 3;
                    break;
                case 9:
                    changeFrame = 3;
                    break;
                case 10:
                    changeFrame = 3;
                    break;
                case 11:
                    changeFrame = 3;
                    break;
                case 12:
                    changeFrame = 3;
                    break;
                case 13:
                    changeFrame = 3;
                    break;
                case 14:
                    changeFrame = 3;
                    break;
            }
            player.bodyFrame.Y = player.bodyFrame.Height * changeFrame;
        }
        public void PlaySound( int frame )
        {
            switch ( frame )
            {
                case 2:
                    Engine.PlaySound( SoundID.Item71 , Projectile.Center );
                    break;
                case 3:
                    Engine.PlaySound( SoundID.Item71 , Projectile.Center );
                    break;
                case 5:
                    Engine.PlaySound( SoundID.Item71 , Projectile.Center );
                    break;
                case 7:
                    Engine.PlaySound( SoundID.Item71 , Projectile.Center );
                    break;
                case 10:
                    Engine.PlaySound( SoundID.Item71 , Projectile.Center );
                    break;
            }
        }

        public void GiveDamage( int frame )
        {
            Player player = Main.player[ Projectile.owner ];
            RedRiotPowerFrame projectileFrame = Projectile.GetGlobalProjectile<RedRiotPowerFrame>( );
            foreach ( NPC npc in Main.npc )
            {
                if ( npc.getRect( ).Intersects( Projectile.getRect( ) ) && projectileFrame.Timer == 2
                    && ( !npc.friendly || npc.type == NPCID.Angler ) && npc.active && !npc.dontTakeDamage )
                {
                    switch ( frame )
                    {
                        case 2:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage / 16 , npc );
                            break;
                        case 3:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage / 8 , npc );
                            break;
                        case 4:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage / 4 , npc );
                            break;
                        case 5:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage / 2 , npc );
                            break;
                        case 6:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage / 2 , npc );
                            break;
                        case 7:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage , npc );
                            break;
                        case 8:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage * 2 , npc );
                            break;
                        case 10:
                            Projectile.NewProjectile( null , npc.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
                            Hit( Projectile.damage * 4 , npc , true );
                            break;
                    }
                }
            }
        }
        public void Hit( int damage , NPC npc , bool crit = false )
        {
            Player player = Main.player[ Projectile.owner ];
            int life = Main.rand.Next( 5 , 10 );
            player.statLife += life;
            player.HealEffect( life );
            player.ApplyDamageToNPC( npc , damage , Projectile.knockBack , Projectile.direction , crit );
        }
    }
}
