using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Npcs
{
    public class YunSlime : ERNpc
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "云史莱姆" );

            DisplayName.AddTranslation( English , "Cloud Slime" );

            Main.npcFrameCount[ NPC.type ] = 4;

            base.SetStaticDefaults( );
        }

        public override void SetDefaults( )
        {
            NPC.knockBackResist = 0.5f;
            NPC.damage = 15;
            NPC.defense = 5;
            NPC.lifeMax = 120;
            NPC.lifeRegen = 1;
            NPC.width = 62;
            NPC.height = 48;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath7;
        }

        public override void AI( )
        {
            Player player = Main.player[ NPC.target ];
            NPC.TargetClosest( true );
            NPC.frameCounter += 1.0;
            if ( NPC.frameCounter % 10.0 == 0.0 )
            {
                NPC npc = NPC;
                npc.frame.Y = npc.frame.Y + 48;
            }
            if ( NPC.frame.Y > 144 )
            {
                NPC.frame.Y = 0;
            }
            Progressive( NPC , player.Center - NPC.Center , 120f );
        }

        public static void Progressive( NPC npc , Vector2 target , float speed )
        {
            float progressiveFactor = 20f;
            Vector2 targetPos = Vector2.Normalize( target ) * progressiveFactor;
            npc.velocity = ( npc.velocity * ( speed - 1f ) + targetPos ) / speed;
        }

        public override void OnHitByItem( Player player , Item item , int damage , float knockback , bool crit )
        {
            NPC.ai[ 0 ] = 1f;
            base.OnHitByItem( player , item , damage , knockback , crit );
        }

        public override void OnHitByProjectile( Projectile projectile , int damage , float knockback , bool crit )
        {
            NPC.ai[ 0 ] = 1f;
            base.OnHitByProjectile( projectile , damage , knockback , crit );
        }

        public override void ModifyNPCLoot( NPCLoot npcLoot )
        {
            npcLoot.Add( ItemDropRule.Common( 751 , 1 , 1 , 6 ) );
            base.ModifyNPCLoot( npcLoot );
        }

        public override float SpawnChance( NPCSpawnInfo spawnInfo )
        {
            if ( Main.player[ Main.myPlayer ].ZoneSkyHeight )
            {
                return 0.15f;
            }
            return 0f;
        }

        public static Vector2 Dush( Vector2 end , NPC npc )
        {
            float num = ( end - npc.Center ).ToRotation( );
            float X = (float) Math.Cos( num );
            float Y = (float) Math.Sin( num );
            return new Vector2( X , Y );
        }
    }
}
