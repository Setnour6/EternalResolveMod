using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Npcs.Bosses.Treacherous
{
    public class RealEye : ERNpc
    {
        /// <summary>
        /// 死亡读秒.
        /// </summary>
        public int DeathReadSeconds = 60;//死亡读秒

        /// <summary>
        /// Boss的状态由该值表示.
        /// 0 进场
        /// 1 开场白 字幕&特写镜头
        /// 2 跟随并发射弹幕 附带屏幕震颤&模糊 
        /// 3 快速不规则冲刺
        /// 4 画圆发射弹幕 小弹幕画炫酷特效
        /// 5 高速左右冲刺
        /// 6 高速上下冲刺
        /// 7 大吼 进入第二阶段
        /// 8 对战中字幕&特写镜头
        /// 9 简单地跟随并发射弹幕 无特效
        /// 10 停留原地 束缚玩家场地 弹幕游戏
        /// 曲末 进入第二阶段
        /// </summary>
        public int State;

        public int SecondCounter = 0;

        public int SecondCounter2 = 0;

        /// <summary>
        /// 秒计时器.
        /// </summary>
        public int Second = 0;

        /// <summary>
        /// 移动的目标.
        /// </summary>
        public Vector2 MoveTarget;

        /// <summary>
        /// 表示死亡阶段开始.
        /// </summary>
        public bool DeathUpdate = false;

        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "真视之眼" );
            DisplayName.AddTranslation( English , "Realy Eye" );
            base.SetStaticDefaults( );
        }
        //32 22
        public override void SetDefaults( )
        {
            NPC.damage = 50;
            NPC.defense = 40;
            NPC.knockBackResist = -1f;
            NPC.lifeMax = 50000;
            NPC.width = 102;
            NPC.height = 102;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.boss = true;
            Music = MusicLoader.GetMusicSlot( Mod , "Assets/Music/RealEyeI" );
            NPC.HitSound = SoundID.NPCHit18;
            NPC.DeathSound = SoundID.NPCDeath10;
            NPCID.Sets.TrailCacheLength[ NPC.type ] = 10;
            NPCID.Sets.TrailingMode[ NPC.type ] = 2;
            State = 0;
            base.SetDefaults( );
        }
        public override void AI( )
        {
            NPC.TargetClosest( false );
            Player Player = Main.player[ NPC.target ];

            SecondCounter2 = SecondCounter;
            SecondCounter = DateTime.Now.Second;
            if ( SecondCounter != SecondCounter2 )
                Second++;
            //秒计时器部分.

            NPC.frameCounter++;
            int _height = 202;
            NPC.frame.Y = _height * (int) ( NPC.frameCounter / 4 );
            if ( NPC.frameCounter > 18 )
                NPC.frameCounter = 0;

            switch ( State )
            {
                case 0:
                    if ( Second < 3 )
                    {
                        NPC.Center = Player.Center - Vector2.UnitY * 1000; //音乐响起 真视之眼悬浮于玩家上方的高空.
                    }
                    if ( Second == 3 )
                    {
                        MoveTarget = Player.Center - Vector2.UnitY * 400; //三秒后 降落一定高度.
                        NPC.ai[ 1 ] = 1;
                    }
                    if ( NPC.ai[ 1 ] == 1 )
                    {
                        NPC.velocity = ( MoveTarget - NPC.Center ) * 0.09f;
                        SkyManager.Instance.Activate( "EternalResolve:RealEyeCustomSky" );
                    }
                    break;
            };
            if ( DeathUpdate )
            {
                DeathReadSeconds--;
            }
            base.AI( );
        }

        public void ChangeState( int state )
        {
            NPC.ai[ 0 ] = 0;
            NPC.ai[ 1 ] = 0;
            NPC.ai[ 2 ] = 0;
            NPC.ai[ 3 ] = 0;
            State = state;
        }

        public override bool PreDraw( SpriteBatch spriteBatch , Vector2 screenPos , Color drawColor )
        {

            return false;
        }
        public override void PostDraw( SpriteBatch spriteBatch , Vector2 screenPos , Color drawColor )
        {

            base.PostDraw( spriteBatch , screenPos , drawColor );
        }
        public override bool PreKill( )
        {
            SkyManager.Instance.Deactivate( "EternalResolve:RealEyeCustomSky" );
            return true;
        }
        public override void SendExtraAI( BinaryWriter writer )
        {
            writer.Write( DeathReadSeconds ); //对死亡读秒进行多人同步.
            writer.Write( State ); //对状态进行多人联机同步.
            writer.Write( SecondCounter ); //对读秒器进行多人联机同步.
            writer.Write( SecondCounter2 ); //对读秒器2进行多人联机同步.
            writer.Write( Second ); //对秒计时器进行多人联机同步.

            base.SendExtraAI( writer );
        }
        public override void ReceiveExtraAI( BinaryReader reader )
        {
            DeathReadSeconds = reader.ReadInt32( ); //对死亡读秒进行多人同步.
            State = reader.ReadInt32( ); //对状态进行多人联机同步.
            SecondCounter = reader.ReadInt32( ); //对读秒器进行多人联机同步.
            SecondCounter2 = reader.ReadInt32( ); //对读秒器2进行多人联机同步.
            Second = reader.ReadInt32( ); //对秒计时器进行多人联机同步.

            base.ReceiveExtraAI( reader );
        }
    }
}
