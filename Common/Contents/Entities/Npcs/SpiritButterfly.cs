using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Npcs
{
    public class SpiritButterfly : ERNpc
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "幽灵蝴蝶" );
            DisplayName.AddTranslation( English , "Spirit Butterfly" );
            Main.npcFrameCount[ NPC.type ] = 8;
        }

        public override void SetDefaults( )
        {
            NPC.knockBackResist = 0.5f;
            NPC.damage = 40;
            NPC.defense = 10;
            NPC.lifeMax = 180;
            NPC.lifeRegen = 1;
            NPC.width = 48;
            NPC.height = 48;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.HitSound = SoundID.NPCHit5;
            NPC.DeathSound = SoundID.NPCDeath7;
        }

        public override void AI( )
        {
            Player player = Main.player[ NPC.target ];
            NPC.TargetClosest( true );
            NPC.spriteDirection = NPC.direction;
            NPC.frameCounter += 1.0;
            if ( NPC.frameCounter % 5.0 == 0.0 )
            {
                NPC npc = NPC;
                npc.frame.Y = npc.frame.Y + 48;
            }
            if ( NPC.frame.Y > 336 )
            {
                NPC.frame.Y = 0;
            }
            bool flag19 = false;
            if ( NPC.justHit )
            {
                NPC.ai[ 2 ] = 0f;
            }
            int num284 = (int) ( ( NPC.position.X + (float) ( NPC.width / 2 ) ) / 16f ) + NPC.direction * 2;
            int num285 = (int) ( ( NPC.position.Y + (float) NPC.height ) / 16f );
            bool flag20 = true;
            int num286 = 3;
            int num288;
            for ( int num287 = num285; num287 < num285 + num286; num287 = num288 + 1 )
            {
                // Below commented out to fix CS0200 - Property or indexer '' cannot be assigned to -- it is read only.
                //if ( Main.tile[ num284 , num287 ] == null )
                //{
                //    Main.tile[ num284 , num287 ] = new Tile( );
                //}
                if ( ( Main.tile[ num284 , num287 ].IsActuated && Main.tileSolid[ (int) Main.tile[ num284 , num287 ].TileType ] ) || Main.tile[ num284 , num287 ].LiquidAmount > 0 ) // IsActive -> IsActuated.
                {
                    flag20 = false;
                    break;
                }
                num288 = num287;
            }
            if ( Main.player[ NPC.target ].npcTypeNoAggro[ NPC.type ] )
            {
                bool flag21 = false;
                for ( int num289 = num285; num289 < num285 + num286 - 2; num289 = num288 + 1 )
                {
					// Below commented out to fix CS0200 - Property or indexer '' cannot be assigned to -- it is read only.
					//if ( Main.tile[ num284 , num289 ] == null )
					//{
					//    Main.tile[ num284 , num289 ] = new Tile( );
					//}
					if ( ( Main.tile[ num284 , num289 ].IsActuated && Main.tileSolid[ (int) Main.tile[ num284 , num289 ].TileType ] ) || Main.tile[ num284 , num289 ].LiquidAmount > 0) // IsActive -> IsActuated.
					{
                        flag21 = true;
                        break;
                    }
                    num288 = num289;
                }
                NPC.directionY = Utils.ToDirectionInt( !flag21 );
            }
            if ( flag19 )
            {
                flag20 = true;
                if ( NPC.type == 268 )
                {
                    NPC.velocity.Y = NPC.velocity.Y + 2f;
                }
            }
            if ( flag20 )
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.1f;
                if ( NPC.velocity.Y > 3f )
                {
                    NPC.velocity.Y = 3f;
                }
            }
            else
            {
                if ( NPC.directionY < 0 && NPC.velocity.Y > 0f )
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.1f;
                }
                if ( NPC.velocity.Y < -4f )
                {
                    NPC.velocity.Y = -4f;
                }
            }
            if ( NPC.collideX )
            {
                NPC.velocity.X = NPC.oldVelocity.X * -0.4f;
                if ( NPC.direction == -1 && NPC.velocity.X > 0f && NPC.velocity.X < 1f )
                {
                    NPC.velocity.X = 1f;
                }
                if ( NPC.direction == 1 && NPC.velocity.X < 0f && NPC.velocity.X > -1f )
                {
                    NPC.velocity.X = -1f;
                }
            }
            if ( NPC.collideY )
            {
                NPC.velocity.Y = NPC.oldVelocity.Y * -0.25f;
                if ( NPC.velocity.Y > 0f && NPC.velocity.Y < 1f )
                {
                    NPC.velocity.Y = 1f;
                }
                if ( NPC.velocity.Y < 0f && NPC.velocity.Y > -1f )
                {
                    NPC.velocity.Y = -1f;
                }
            }
            float num290 = 2f;
            if ( NPC.direction == -1 && NPC.velocity.X > -num290 )
            {
                NPC.velocity.X = NPC.velocity.X - 0.1f;
                if ( NPC.velocity.X > num290 )
                {
                    NPC.velocity.X = NPC.velocity.X - 0.1f;
                }
                else if ( NPC.velocity.X > 0f )
                {
                    NPC.velocity.X = NPC.velocity.X + 0.05f;
                }
                if ( NPC.velocity.X < -num290 )
                {
                    NPC.velocity.X = -num290;
                }
            }
            else if ( NPC.direction == 1 && NPC.velocity.X < num290 )
            {
                NPC.velocity.X = NPC.velocity.X + 0.1f;
                if ( NPC.velocity.X < -num290 )
                {
                    NPC.velocity.X = NPC.velocity.X + 0.1f;
                }
                else if ( NPC.velocity.X < 0f )
                {
                    NPC.velocity.X = NPC.velocity.X - 0.05f;
                }
                if ( NPC.velocity.X > num290 )
                {
                    NPC.velocity.X = num290;
                }
            }
            if ( NPC.directionY == -1 && NPC.velocity.Y > -num290 )
            {
                NPC.velocity.Y = NPC.velocity.Y - 0.04f;
                if ( NPC.velocity.Y > num290 )
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.05f;
                }
                else if ( NPC.velocity.Y > 0f )
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.03f;
                }
                if ( NPC.velocity.Y < -num290 )
                {
                    NPC.velocity.Y = -num290;
                }
            }
            else if ( NPC.directionY == 1 && NPC.velocity.Y < num290 )
            {
                NPC.velocity.Y = NPC.velocity.Y + 0.04f;
                if ( NPC.velocity.Y < -num290 )
                {
                    NPC.velocity.Y = NPC.velocity.Y + 0.05f;
                }
                else if ( NPC.velocity.Y < 0f )
                {
                    NPC.velocity.Y = NPC.velocity.Y - 0.03f;
                }
                if ( NPC.velocity.Y > num290 )
                {
                    NPC.velocity.Y = num290;
                }
            }
            Lighting.AddLight( (int) NPC.position.X / 16 , (int) NPC.position.Y / 16 , 0.4f , 0f , 0.25f );
        }
        public override void OnHitByItem( Player player , Item item , int damage , float knockback , bool crit )
        {
            for ( int i = 0; i < 5; i++ )
            {
                Vector2 position = NPC.Center - new Vector2( (float) ( NPC.width / 2 ) , (float) ( NPC.height / 2 ) );
                Dust dust = Main.dust[ Dust.NewDust( position , 30 , 30 , 71 , 0f , 0f , 0 , new Color( 255 , 255 , 255 ) , 1f ) ];
            }
        }
        public override void OnHitByProjectile( Projectile projectile , int damage , float knockback , bool crit )
        {
            for ( int i = 0; i < 5; i++ )
            {
                Vector2 position = NPC.Center - new Vector2( (float) ( NPC.width / 2 ) , (float) ( NPC.height / 2 ) );
                Dust dust = Main.dust[ Dust.NewDust( position , 30 , 30 , 71 , 0f , 0f , 0 , new Color( 255 , 255 , 255 ) , 1f ) ];
            }
        }
        public override void OnKill( )
        {
            for ( int i = 0; i < 15; i++ )
            {
                Vector2 position = NPC.Center - new Vector2( (float) ( NPC.width / 2 ) , (float) ( NPC.height / 2 ) );
                Dust dust = Main.dust[ Dust.NewDust( position , 30 , 30 , 71 , 0f , 0f , 0 , new Color( 255 , 255 , 255 ) , 1f ) ];
            }
            base.OnKill( );
        }
        public override void ModifyNPCLoot( NPCLoot npcLoot )
        {
            npcLoot.Add( ItemDropRule.Common( 520 , 1 , 1 , 3 ) );
            npcLoot.Add( ItemDropRule.Common( 521 , 1 , 1 , 3 ) );

            base.ModifyNPCLoot( npcLoot );
        }
        public override float SpawnChance( NPCSpawnInfo spawnInfo )
        {
            if ( Main.LocalPlayer.ZoneHallow )
            {
                return 0.03f;
            }
            return 0f;
        }
    }
}
