using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items.HitEffects;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Summons.Impacts
{
    public class Impact_Summon : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "人间" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToProjectile( 38 , 38 );
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.netUpdate = true;
            base.SetDefaults( );
        }
        public override bool PreAI( )
        {
            Impact_Power Impact_Power = Main.player[ Projectile.owner ].GetModPlayer<Impact_Power>( );
            Player Player = Impact_Power.Player;
            if ( Player.HeldItem.type == ModContent.ItemType<Impact>( ) || !Player.HasItem( ModContent.ItemType<Impact>( ) ) )
            {
                Vector2 targetPos = Player.Center;
                Projectile.velocity = ( targetPos - Projectile.Center ) * 0.3f + Player.velocity;
                if ( Vector2.Distance( Projectile.Center , Player.Center ) < 1 )
                    Projectile.Kill( );
            }
            return Player.HeldItem.type != ModContent.ItemType<Impact>( );
        }
        public override void AI( )
        {
            Player Player = Main.player[ Projectile.owner ];
            NPC target = null;
            float Timer = (float) Main.time * 0.1f;
            Projectile.ai[ 0 ]++;
            foreach ( NPC npc in Main.npc )
            {
                if ( npc.active && npc.life > 2 && !npc.friendly && Vector2.Distance( Player.Center , npc.Center ).ToInt( ) < 600 )
                {
                    Projectile.ai[ 1 ] = 1;
                    if ( target == null )
                        target = npc;
                    break;
                }
                else
                {
                    Projectile.ai[ 1 ] = 0;
                    target = null;
                }
            }
            if ( Player.GetModPlayer<Impact_Power>( ).PowerType == 1 && Projectile.ai[ 1 ] == 1 )
            {
                Projectile.friendly = true;
                if ( Projectile.ai[ 0 ] % 60 == 0 )
                {
                    Projectile.velocity = Vector2.Normalize( target.Center - Projectile.Center ) * 30;
                }
                else
                {
                    Projectile.rotation = ( target.Center - Projectile.Center ).ToRotation( ) - 3.1415926f / 180 * 45;
                    Projectile.velocity.Y += Projectile.Center.Y < target.Center.Y ? -0.05f : 0.05f;
                    Projectile.velocity *= 0.90f;
                }
            }
            else if ( Player.GetModPlayer<Impact_Power>( ).PowerType == 0 || Projectile.ai[ 1 ] == 0 )
            {
                Projectile.friendly = false;
                /*      if ( Player.velocity.Length( ) == 0 )
                      {
                          var targetPos = Player.Center + Timer.ToRotationVector2( ) * 50f;
                          Projectile.rotation = Projectile.velocity.ToRotation( ) - 3.1415926f / 180 * 225;
                          Projectile.velocity = ( targetPos - Projectile.Center ) * 0.3f;
                      }
                      else if ( Player.velocity.Length( ) > 0 )
                      {*/
                var targetPos = Player.Center + Vector2.UnitX * 20 * -Player.direction;
                Projectile.rotation = 3.1415926f / 180 * ( 45 + Player.direction * 10 );
                Projectile.velocity = ( targetPos - Projectile.Center ) * 0.3f;
                //   }
            }
            base.AI( );
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            Projectile.NewProjectile( new ERProjectileSource( ) , target.Center , new Vector2( 0 , 0f ) , ModContent.ProjectileType<Cut_HitEffect>( ) , 0 , 0 , Main.LocalPlayer.whoAmI , Main.rand.NextFloat( ) , 0 );
            base.OnHitNPC( target , damage , knockback , crit );
        }
    }
}