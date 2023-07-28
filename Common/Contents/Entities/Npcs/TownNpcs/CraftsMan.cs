using EternalResolve.Common.Contents.Entities.Items;
using EternalResolve.Common.Contents.Entities.Items.Electrics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace EternalResolve.Common.Contents.Entities.Npcs.TownNpcs
{
    [AutoloadHead]
    public class CraftsMan : ModNPC
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( EternalResolve.Chinese , "Az-20" );
            DisplayName.AddTranslation( EternalResolve.English , "Az-20" );
            Main.npcFrameCount[ NPC.type ] = 25;
            NPCID.Sets.ExtraFramesCount[ NPC.type ] = 5;
            NPCID.Sets.AttackFrameCount[ NPC.type ] = 4;
            NPCID.Sets.DangerDetectRange[ NPC.type ] = 1000;
            NPCID.Sets.AttackType[ NPC.type ] = 0;
            NPCID.Sets.AttackTime[ NPC.type ] = 80;
            NPCID.Sets.AttackAverageChance[ NPC.type ] = 10;
        }
        public override void FindFrame( int frameHeight )
        {
            if ( NPC.frame.Y == frameHeight * 2 )
            {
                NPC.frame.Y = frameHeight * 7;
            }
        }
        int currentframe = 0;
        public override void UpdateLifeRegen( ref int damage )
        {
            NPC.lifeRegen += 50;
        }
        int cooldown = 0;
        public int Timer = 10;
        public Vector2 NPCC;
        bool Attack = false;
        int AttackLoop = 0;
        public override void SendExtraAI( BinaryWriter writer )
        {
            base.SendExtraAI( writer );
            if ( Main.netMode == NetmodeID.Server || Main.dedServ )
            {
                writer.Write( currentframe );
                writer.Write( Attack );
                writer.Write( Timer );
                writer.Write( cooldown );
            }
        }
        public override void ReceiveExtraAI( BinaryReader reader )
        {
            base.ReceiveExtraAI( reader );
            if ( Main.netMode == NetmodeID.MultiplayerClient )
            {
                currentframe = reader.ReadInt32( );
                Attack = reader.ReadBoolean( );
                Timer = reader.ReadInt32( );
                cooldown = reader.ReadInt32( );
            }
        }
        public override bool PreAI( )
        {
            int Player = Main.myPlayer;
            bool CanAttack = false;
            float Dist2 = -1f;
            float Dist3 = -1f;
            int num9;
            int TTarget = -1;
            int TTarget2 = -1;
            for ( int l = 0; l < 200; l++ )
            {
                if ( !Main.npc[ l ].active || Main.npc[ l ].friendly || Main.npc[ l ].damage <= 0 || !( Main.npc[ l ].Distance( base.NPC.Center ) < NPCID.Sets.DangerDetectRange[ NPC.type ] ) || ( !Main.npc[ l ].noTileCollide && !Collision.CanHit( base.NPC.Center , 0 , 0 , Main.npc[ l ].Center , 0 , 0 ) ) )
                    continue;
                CanAttack = true;
                float Dist = Main.npc[ l ].Center.X - base.NPC.Center.X;
                if ( Dist < 0f && ( Dist2 == -1f || Dist > Dist2 ) )
                {
                    Dist2 = Dist;
                    if ( Main.npc[ l ].CanBeChasedBy( this ) )
                        TTarget = l;
                }

                if ( Dist > 0f && ( Dist3 == -1f || Dist < Dist3 ) )
                {
                    Dist3 = Dist;
                    if ( Main.npc[ l ].CanBeChasedBy( this ) )
                        TTarget2 = l;
                }
                NPC.spriteDirection = Main.npc[ l ].position.X >= NPC.position.X ? 1 : -1;
            }
            if ( cooldown >= 0 )
                cooldown--;
            if ( cooldown <= 0 )
                cooldown = 0;
            if ( CanAttack && cooldown <= 0 )
            {
                AnimationType = NPC.type;
                Attack = true;
                NPC.velocity.X *= 0;
                if ( currentframe <= 0 )
                {
                    currentframe = 0;
                }
                Timer++;
                if ( Timer >= 3 )
                {
                    currentframe++;
                    Timer = 0;
                }
                int damage = 15;
                num9 = ( ( Dist2 == -1f ) ? 1 : ( ( Dist3 != -1f ) ? ( Dist3 < 0f - Dist2 ).ToDirectionInt( ) : ( -1 ) ) );
                int target = -1;
                if ( num9 == 1 && NPC.spriteDirection == 1 )
                    target = TTarget2;

                if ( num9 == -1 && NPC.spriteDirection == -1 )
                    target = TTarget;
                Vector2 vector = Vector2.Zero;
                if ( target != -1 )
                    vector = NPC.DirectionTo( Main.npc[ target ].Center + new Vector2( 0f , 0f * MathHelper.Clamp( NPC.Distance( Main.npc[ target ].Center ) / NPCID.Sets.DangerDetectRange[ NPC.type ] , 0f , 1f ) ) );

                if ( vector.HasNaNs( ) || Math.Sign( vector.X ) != NPC.spriteDirection )
                    vector = new Vector2( NPC.spriteDirection , 0f );

                vector *= 15;
                if ( currentframe >= 8 && currentframe <= 10 && Timer == 1 )
                {
                    int ProjID = ProjectileID.RocketSnowmanI;
                    if ( Main.netMode != NetmodeID.MultiplayerClient )
                    {
                        Projectile.NewProjectile( new ERProjectileSource( ) , NPC.Center.X + (float) ( NPC.spriteDirection * 16 ) , NPC.Center.Y - 2f , vector.X + (float) Main.rand.Next( -20 , 11 ) * 0.3f , vector.Y + (float) Main.rand.Next( -20 , 11 ) * 0.3f , ProjID , damage , 5f , Player );
                    }
                }
                if ( currentframe >= 10 && AttackLoop <= 7 )
                {
                    AttackLoop++;
                    currentframe = 8;
                }
                if ( currentframe >= 14 )
                {
                    currentframe = 0;
                    cooldown = 80;
                }
                return false;
            }
            else
            {
                AttackLoop = 0;
                Attack = false;
                currentframe = 0;
                AnimationType = NPCID.Merchant;
                return true;
            }
        }
        public override void SetDefaults( )
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 26;
            NPC.height = 38;
            NPC.aiStyle = 7;
            NPC.damage = 0;
            NPC.defense = 360;
            NPC.lifeMax = 1500;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
        }
        public override bool CanTownNPCSpawn( int numTownNPCs , int money )
        {
            for ( int k = 0; k < 255; k++ )
            {
                Player player = Main.player[ k ];
                if ( player.active )
                {
                    if ( NPC.downedBoss1 )
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public override string TownNPCName( )
        {
            return "Az-20";
        }
        public override string GetChat( )
        {
            WeightedRandom<string> chat = new WeightedRandom<string>( );
            {
                Player player = Main.player[ Main.myPlayer ];
                if ( Language.ActiveCulture == EternalResolve.Chinese )
                {
                    if ( !Main.bloodMoon && !Main.eclipse )
                    {
                        chat.Add( "今天还有很多事要做." );
                        if ( Main.time < 16200.0 )
                        {
                            chat.Add( "这个清晨很完美." );
                            if ( Main.raining )
                            {
                                chat.Add( "清晨的雨...可以让你的心更加平静." );
                            }
                        }
                        else if ( Main.time > 37800.0 )
                        {
                            chat.Add( "太热了, 这个时候的仪器如果一直工作一定会出问题." );
                        }
                        if ( !Main.dayTime )
                        {
                            chat.Add( "有很多需要研究的东西." );
                            chat.Add( "不用管那些怪物." );
                            chat.Add( "它们对我构不成威胁." );
                        }
                        chat.Add( "嗯...这把锤子很趁手." );
                        chat.Add( "来到这里, 并非我的自愿." );
                        if ( Main.raining )
                        {
                            chat.Add( "飞鱼的翅膀经过处理后可以当做砂纸使用." );
                        }
                        if ( BirthdayParty.PartyIsUp )
                        {
                            chat.Add( "派对女孩的泡泡机是我造的." );
                            chat.Add( "还行, 这种派对偶尔办办也是不错的." );
                            chat.Add( "火药很危险, 所以要用到对的地方." );
                        }
                    }
                    if ( Main.eclipse )
                    {
                        chat.Add( "..." );
                        chat.Add( "......" );
                        chat.Add( "我现在非常想杀人." );
                    }
                }
                else
                {
                    if ( !Main.bloodMoon && !Main.eclipse )
                    {
                        chat.Add( "There's still a lot to do today." );
                        if ( Main.time < 16200.0 )
                        {
                            chat.Add( "This morning is perfect." );
                            if ( Main.raining )
                            {
                                chat.Add( "The early morning rain... Can make your heart more calm." );
                            }
                        }
                        else if ( Main.time > 37800.0 )
                        {
                            chat.Add( "It's too hot. If the instrument works all the time, there will be problems." );
                        }
                        if ( !Main.dayTime )
                        {
                            chat.Add( "There is a lot to study." );
                            chat.Add( "Don't worry about the monsters." );
                            chat.Add( "They don't pose a threat to me." );
                        }
                        chat.Add( "Well... This hammer is handy." );
                        chat.Add( "It was not my will to come here." );
                        if ( Main.raining )
                        {
                            chat.Add( "The wings of flying fish can be used as sandpaper after treatment." );
                        }
                        if ( BirthdayParty.PartyIsUp )
                        {
                            chat.Add( "I made the party girl's bubble machine." );
                            chat.Add( "OK, it's good to have this kind of Party occasionally." );
                            chat.Add( "Gunpowder is dangerous, so use it in the right place." );
                        }
                    }
                    if ( Main.eclipse )
                    {
                        chat.Add( "..." );
                        chat.Add( "......" );
                        chat.Add( "I really want to kill now." );
                    }
                }
                return chat;
            }
        }

        public override void SetChatButtons( ref string button , ref string button2 )
        {
            button = Language.GetTextValue( "LegacyInterface.28" );
        }
        public override void OnChatButtonClicked( bool firstButton , ref bool shop )
        {
            if ( firstButton )
            {
                shop = true;
            }
        }

        public override void SetupShop( Chest shop , ref int nextSlot )
        {
            shop.item[ nextSlot ].SetDefaults( ItemID.RocketBoots );
            nextSlot++;
            shop.item[ nextSlot ].SetDefaults( ModContent.ItemType<Battery>( ) );
            nextSlot++;

        }

        public override bool PreDraw( SpriteBatch spriteBatch , Vector2 screenPos , Color drawColor )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                Texture2D texture2D = TextureAssets.Npc[ NPC.type ].Value;
                Texture2D texture2D2 = ModContent.Request<Texture2D>( "EternalResolve/Common/" +
                    "Contents/Entities/Npcs/TownNpcs/CraftsMan_Attack" ).Value;
                SpriteEffects spriteEffects = SpriteEffects.None;
                if ( NPC.spriteDirection == 1 )
                {
                    spriteEffects = SpriteEffects.FlipHorizontally;
                }
                Vector2 vector11 = new Vector2( (float) ( TextureAssets.Npc[ NPC.type ].Value.Width / 2 ) , (float) ( TextureAssets.Npc[ NPC.type ].Value.Height / Main.npcFrameCount[ NPC.type ] / 2 ) );
                if ( Attack )
                    spriteBatch.Draw( texture2D2 , NPC.Bottom - Main.screenPosition + new Vector2( -(float) TextureAssets.Npc[ NPC.type ].Value.Width * NPC.scale / 2f + vector11.X * NPC.scale , -(float) TextureAssets.Npc[ NPC.type ].Value.Height * NPC.scale / (float) Main.npcFrameCount[ NPC.type ] + 12f + vector11.Y * NPC.scale + 0 + NPC.gfxOffY ) , new Rectangle?( new Rectangle( 0 , currentframe * 52 , 90 , 52 ) ) , drawColor , NPC.rotation , vector11 , NPC.scale , spriteEffects , 0f );
                else
                    spriteBatch.Draw( texture2D , NPC.Bottom - Main.screenPosition + new Vector2( -(float) TextureAssets.Npc[ NPC.type ].Value.Width * NPC.scale / 2f + vector11.X * NPC.scale , -TextureAssets.Npc[ NPC.type ].Value.Height * NPC.scale / (float) Main.npcFrameCount[ NPC.type ] + 4f + vector11.Y * NPC.scale + 0 + NPC.gfxOffY ) , new Rectangle?( NPC.frame ) , drawColor , NPC.rotation , vector11 , NPC.scale , spriteEffects , 0f );
            }
            return false;
        }
        public override void HitEffect( int hitDirection , double damage )
        {
            int num5;
            if ( base.NPC.life > 0 )
            {
                int num552 = 0;
                while ( (double) num552 < damage / (double) base.NPC.lifeMax * 100.0 )
                {
                    Dust.NewDust( base.NPC.position , base.NPC.width , base.NPC.height , 106 , hitDirection , -1f , 0 , default , 1f );
                    num5 = num552;
                    num552 = num5 + 1;
                }
                return;
            }
            if ( base.NPC.life <= 0 )
            {
                for ( int num553 = 0; num553 < 50; num553 = num5 + 1 )
                {
                    int num526 = Dust.NewDust( base.NPC.position , base.NPC.width , base.NPC.height , 106 , 2.5f * (float) hitDirection , -2.5f , 0 , default( Color ) , 1f );
                    Dust dust = Main.dust[ num526 ];
                    dust.velocity *= 1.4f;
                    Main.dust[ num526 ].noGravity = true;
                    num5 = num553;
                }
                int num527 = Gore.NewGore( new Vector2( base.NPC.position.X + (float) ( base.NPC.width / 2 ) - 24f , base.NPC.position.Y + (float) ( base.NPC.height / 2 ) - 24f ) , default( Vector2 ) , Main.rand.Next( 11 , 13 ) , 1f );
                Main.gore[ num527 ].scale = 1f;
                Gore gore10 = Main.gore[ num527 ];
                gore10.velocity.X = gore10.velocity.X + 1f;
                Gore gore11 = Main.gore[ num527 ];
                gore11.velocity.Y = gore11.velocity.Y + 1f;
                num527 = Gore.NewGore( new Vector2( base.NPC.position.X + (float) ( base.NPC.width / 2 ) - 24f , base.NPC.position.Y + (float) ( base.NPC.height / 2 ) - 24f ) , default( Vector2 ) , Main.rand.Next( 11 , 13 ) , 1f );
                Main.gore[ num527 ].scale = 1f;
                Gore gore12 = Main.gore[ num527 ];
                gore12.velocity.X = gore12.velocity.X - 1f;
                Gore gore13 = Main.gore[ num527 ];
                gore13.velocity.Y = gore13.velocity.Y + 1f;
                num527 = Gore.NewGore( new Vector2( base.NPC.position.X + (float) ( base.NPC.width / 2 ) - 24f , base.NPC.position.Y + (float) ( base.NPC.height / 2 ) - 24f ) , default( Vector2 ) , Main.rand.Next( 11 , 13 ) , 1f );
                Main.gore[ num527 ].scale = 1f;
                Gore gore14 = Main.gore[ num527 ];
                gore14.velocity.X = gore14.velocity.X + 1f;
                Gore gore15 = Main.gore[ num527 ];
                gore15.velocity.Y = gore15.velocity.Y - 1f;
                num527 = Gore.NewGore( new Vector2( base.NPC.position.X + (float) ( base.NPC.width / 2 ) - 24f , base.NPC.position.Y + (float) ( base.NPC.height / 2 ) - 24f ) , default( Vector2 ) , Main.rand.Next( 11 , 13 ) , 1f );
                Main.gore[ num527 ].scale = 1f;
                Gore gore16 = Main.gore[ num527 ];
                gore16.velocity.X = gore16.velocity.X - 1f;
                Gore gore17 = Main.gore[ num527 ];
                gore17.velocity.Y = gore17.velocity.Y - 1f;
                return;
            }
        }
    }
}