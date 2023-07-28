using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Contents.Entities.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Localization;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular.UI.Chats
{
    public class EkandaChatList : Control
    {
        public int Page = 0;

        public EkandaChatList( )
        {
            Position = FrontDevice.Form.ScreenCenter - Size / 2;
        }

        public EkandaChat Chat;

        public EkandaChat EkandaQuest;

        public EkandaChat QuestText;

        public EkandaChat QuestCheck;

        public EkandaChat TpToHome;

        public EkandaChat SpaceLine;

        public EkandaChat Exit;

        public override void Initialization( )
        {
            SpaceLine = new EkandaChat( " " );
            Register( SpaceLine );

            Chat = new EkandaChat( Language.ActiveCulture == EternalResolve.Chinese ? "" : "" );
            Register( Chat );

            EkandaQuest = new EkandaChat( Language.ActiveCulture == EternalResolve.Chinese ? "任务" : "Quest" );
            EkandaQuest.LeftClickEvent += EkandaQuest_LeftClickEvent;
            void EkandaQuest_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                Page = 1;
            }

            Register( EkandaQuest );

            TpToHome = new EkandaChat( Language.ActiveCulture == EternalResolve.Chinese ? "返回主世界" : "Back to the main world" );
            TpToHome.LeftClickEvent += TpToHome_LeftClickEvent;
            void TpToHome_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                SubWorld_Ekanda.ExitWorld( );
                FrontDevice.Input.MouseLeftClick = false;
            }
            Register( TpToHome );

            QuestText = new EkandaChat( "" );
            Register( QuestText );

            QuestCheck = new EkandaChat( Language.ActiveCulture == EternalResolve.Chinese ? "完成任务" : "Inspection quest" );
            QuestCheck.LeftClickEvent += QuestCheck_LeftClickEvent;
            void QuestCheck_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                if ( Ekanda.EkandaQuest.UpdateCheckEvent( ) )
                {
                    List<Item> loot = Ekanda.EkandaQuest.QuestLoot( );
                    for ( int count = 0; count < loot.Count; count++ )
                    {
                        ERItemManager.CreateItem( Main.LocalPlayer.Center , loot[ count ].type , loot[ count ].stack );
                    }
                    Ekanda._questNum += 1;
                    Ekanda.EkandaQuest = Quest.Quests[ Ekanda._questNum ];
                    Ekanda.EkandaQuest.Init( );
                }
            }
            QuestCheck.UpdatedEvent += QuestCheck_UpdatedEvent;
            void QuestCheck_UpdatedEvent( Codes.UI.Events.UIEvent theEvent , Control element )
            {
                if ( Ekanda.EkandaQuest.UpdateCheckEvent( ) )
                {
                    QuestCheck.Color = Color.White;
                }
                else
                {
                    QuestCheck.Color = Color.Gray;
                }
            }
            Register( QuestCheck );

            Exit = new EkandaChat( Language.ActiveCulture == EternalResolve.Chinese ? "返回" : "Back" );
            Exit.LeftClickEvent += Exit_LeftClickEvent;
            void Exit_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                Page = 0;
            }
            Register( Exit );

            base.Initialization( );
        }


        protected override void UpdateSubControls( )
        {
            for ( int count = 0; count < SubControls.Count; count++ )
            {
                SubControls[ count ].CalculationInteractive( );
                if ( LockSubControl )
                    SubControls[ count ].Position = Position
                        + new Vector2( -SubControls[ count ].Width / 2 , ( SubControls[ count ].Height + 4 ) * count );
                SubControls[ count ].Update( Main.gameTimeCache );
            }
        }

        public override void Update( )
        {
            SubControls.Clear( );
            switch ( Page )
            {
                case 0:
                    {
                        Register( Chat );
                        Register( SpaceLine );
                        Register( EkandaQuest );
                        Register( SpaceLine );
                        Register( SpaceLine );
                        Register( TpToHome );
                    }
                    break;
                case 1:
                    {
                        QuestText = new EkandaChat( Ekanda.EkandaQuest.QuestName + ": " + Ekanda.EkandaQuest.QuestText );
                        QuestText.Initialization( );
                        Register( QuestText );
                        Register( SpaceLine );
                        Register( SpaceLine );
                        Register( QuestCheck );
                        Register( Exit );
                    }
                    break;
            }
            base.Update( );
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.End( );
            spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.Additive , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null );
            base.Draw( spriteBatch );
            spriteBatch.End( );
            spriteBatch.Begin( );
        }
    }
}