using EternalResolve.Assets.Textures.Prays;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Contents.Entities.Items.Currencies;
using EternalResolve.Common.Contents.Modulars.CleanBeadStoneModular;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.PrayModular
{
    public class PrayInterface : ControlOperator
    {
        public PrayButton_0 PrayButton_0;

        public PrayButton_1 PrayButton_1;

        public PrayButton_2 PrayButton_2;

        public PrayPanel PrayPanel;

        public PrayTo1 To1;

        public PrayTo10 To10;

        public PrayClose PrayClose;

        public int PrayType = -1;

        public PrayItemPanel[ ] ItemPanels;

        bool _inPray = false;

        public PrayTextPanel TextPanel;

        public static void ChangeType( int type )
        {
            Modular.PrayInterface.PrayType = type;
            Modular.PrayInterface.PrayButton_0.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , -1000 );
            Modular.PrayInterface.PrayButton_1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , -1000 );
            Modular.PrayInterface.PrayButton_2.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , -1000 );
        }

        public static void ResetType( )
        {
            Modular.PrayInterface.PrayType = -1;
            Modular.PrayInterface.PrayButton_0.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , FrontDevice.Form.ScreenHeight / 2 - 404 );
            Modular.PrayInterface.PrayButton_1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , FrontDevice.Form.ScreenHeight / 2 - 404 );
            Modular.PrayInterface.PrayButton_2.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , FrontDevice.Form.ScreenHeight / 2 - 404 );
        }

        public override void Initialization( )
        {
            ItemPanels = new PrayItemPanel[ 10 ];
            for ( int count = 0; count < ItemPanels.Length; count++ )
            {
                ItemPanels[ count ] = new PrayItemPanel( );
                ItemPanels[ count ].Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 + count * 100 , -1000 );
                ItemPanels[ count ].Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 + count * 100 , -1000 );
                Register( ItemPanels[ count ] );
            }
            PrayButton_0 = new PrayButton_0( );
            PrayButton_0.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , -1000 );
            PrayButton_0.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , FrontDevice.Form.ScreenHeight / 2 - 404 );
            Register( PrayButton_0 );

            PrayButton_1 = new PrayButton_1( );
            PrayButton_1.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , -1000 );
            PrayButton_1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , FrontDevice.Form.ScreenHeight / 2 - 404 );
            Register( PrayButton_1 );

            PrayButton_2 = new PrayButton_2( );
            PrayButton_2.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , -1000 );
            PrayButton_2.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , FrontDevice.Form.ScreenHeight / 2 - 404 );
            Register( PrayButton_2 );

            PrayPanel = new PrayPanel( );
            PrayPanel.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 488 , -1000 );
            PrayPanel.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 488 , -1000 );
            PrayPanel.UpdatedEvent += PrayPanel_UpdatedEvent;
            void PrayPanel_UpdatedEvent( Codes.UI.Events.UIEvent theEvent , Control element )
            {
                if ( PrayType != -1 && PrayType != 5 )
                    PrayPanel.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 488 , FrontDevice.Form.ScreenHeight / 2 - 284 );
                else
                    PrayPanel.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 488 , -1000 );
            }
            Register( PrayPanel );

            To1 = new PrayTo1( );
            To1.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 200 , FrontDevice.Form.ScreenHeight + 1000 );
            To1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 200 , FrontDevice.Form.ScreenHeight + 1000 );
            To1.UpdatedEvent += To1_UpdatedEvent;
            void To1_UpdatedEvent( Codes.UI.Events.UIEvent theEvent , Control element )
            {
                if ( PrayType != -1 && !_inPray )
                    To1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 300 , FrontDevice.Form.ScreenHeight / 2 + 300 );
                else
                    To1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 300 , FrontDevice.Form.ScreenHeight + 1000 );
            }
            To1.LeftClickEvent += To1_LeftClickEvent;
            void To1_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                if ( Main.LocalPlayer.GetModPlayer<RecordCurrency>( ).CleanBeadStone > 0 )
                {
                    Main.LocalPlayer.GetModPlayer<RecordCurrency>( ).CleanBeadStone -= 1;
                    Main.LocalPlayer.GetModPlayer<RecordCurrency>( ).MinimumGuarantee += 1;
                    _inPray = true;
                    _itemCount = 10;
                    PrayItem itemID = PrayPool.GetPrayItem( PrayType );
                    ItemPanels[ 4 ].item.SetDefaults( itemID.ID );
                    ItemPanels[ 4 ].Target.X = FrontDevice.Form.ScreenWidth / 2 - 50;
                    ItemPanels[ 4 ].Target.Y = FrontDevice.Form.ScreenHeight / 2 - 210;
                    Item item = new Item( );
                    item.SetDefaults( itemID.ID );
                    item.stack = itemID.Stack;
                    item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                    Main.LocalPlayer.QuickSpawnItem( item );
                    PrayType = 5;
                }
                else
                {
                    TextPanel.Timer = 180;
                }
            }
            Register( To1 );

            To10 = new PrayTo10( );
            To10.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 60 , FrontDevice.Form.ScreenHeight + 1000 );
            To10.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 60 , FrontDevice.Form.ScreenHeight + 1000 );
            To10.UpdatedEvent += To10_UpdatedEvent;
            void To10_UpdatedEvent( Codes.UI.Events.UIEvent theEvent , Control element )
            {
                if ( PrayType != -1 && !_inPray )
                    To10.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 60 , FrontDevice.Form.ScreenHeight / 2 + 300 );
                else
                    To10.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 60 , FrontDevice.Form.ScreenHeight + 1000 );
            }
            To10.LeftClickEvent += To10_LeftClickEvent;
            void To10_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                if ( Main.LocalPlayer.GetModPlayer<RecordCurrency>( ).CleanBeadStone >= 10 )
                {
                    Main.LocalPlayer.GetModPlayer<RecordCurrency>( ).CleanBeadStone -= 10;
                    Main.LocalPlayer.GetModPlayer<RecordCurrency>( ).MinimumGuarantee += 10;
                    for ( int count = 0; count < ItemPanels.Length; count++ )
                    {
                        _inPray = true;
                        PrayItem itemID = PrayPool.GetPrayItem( PrayType );
                        ItemPanels[ count ].item.SetDefaults( itemID.ID );
                        Item item = new Item( );
                        item.SetDefaults( itemID.ID );
                        item.stack = itemID.Stack;
                        item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                        Main.LocalPlayer.QuickSpawnItem( item );
                    }
                    PrayType = 5;
                }
                else
                {
                    TextPanel.Timer = 180;
                }
            }
            Register( To10 );

            PrayClose = new PrayClose( );
            PrayClose.Position = new Vector2( FrontDevice.Form.ScreenWidth + 1000 , FrontDevice.Form.ScreenHeight / 2 - 300 );
            PrayClose.Target = new Vector2( FrontDevice.Form.ScreenWidth + 1000 , FrontDevice.Form.ScreenHeight / 2 - 300 );
            PrayClose.UpdatedEvent += PrayClose_UpdatedEvent;
            void PrayClose_UpdatedEvent( Codes.UI.Events.UIEvent theEvent , Control element )
            {
                if ( PrayType != -1 && !_inPray )
                    PrayClose.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 500 , FrontDevice.Form.ScreenHeight / 2 - 300 );
                else
                    PrayClose.Target = new Vector2( FrontDevice.Form.ScreenWidth + 1000 , FrontDevice.Form.ScreenHeight / 2 - 300 );
            }
            PrayClose.LeftClickEvent += PrayClose_LeftClickEvent;
            void PrayClose_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                ResetType( );
            }
            Register( PrayClose );

            TextPanel = new PrayTextPanel( );
            TextPanel.Position = FrontDevice.Form.ScreenCenter - TextPanel.Size / 2 - Vector2.UnitY * 1000;
            TextPanel.Target = FrontDevice.Form.ScreenCenter - TextPanel.Size / 2 - Vector2.UnitY * 1000;
            Register( TextPanel );
            base.Initialization( );
        }


        int _timer = 0;
        int _itemCount = 0;
        public override void Update( )
        {
            if ( _inPray )
            {
                _timer++;
                if ( _itemCount < 10 && _timer % 12 == 0 )
                {
                    ItemPanels[ _itemCount ].Target.Y = FrontDevice.Form.ScreenHeight / 2 - 210;
                    _itemCount += 1;
                }
            }
            if ( Modular.PrayInteracting && FrontDevice.Input.IsKeyClick( Keys.Escape ) )
            {
                PrayType = -1;
                _inPray = false;
                _timer = 0;
                _itemCount = 0;
                for ( int count = 0; count < ItemPanels.Length; count++ )
                {
                    ItemPanels[ count ].Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 + count * 100 , -1000 );
                    ItemPanels[ count ].Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 + count * 100 , -1000 );
                }
                Modular.PrayInteracting = false;
                ChangeAnimation.PlayChangeAnimation( );
            }
            if ( PrayType == 5 && FrontDevice.Input.MouseLeftClick )
            {
                PrayType = -1;
                _inPray = false;
                _timer = 0;
                _itemCount = 0;
                for ( int count = 0; count < ItemPanels.Length; count++ )
                {
                    ItemPanels[ count ].Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 + count * 100 , -1000 );
                    ItemPanels[ count ].Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 + count * 100 , -1000 );
                }
                Modular.PrayInterface.PrayButton_0.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , -1000 );
                Modular.PrayInterface.PrayButton_1.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , -1000 );
                Modular.PrayInterface.PrayButton_2.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , -1000 );
                Modular.PrayInterface.PrayButton_0.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , FrontDevice.Form.ScreenHeight / 2 - 404 );
                Modular.PrayInterface.PrayButton_1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , FrontDevice.Form.ScreenHeight / 2 - 404 );
                Modular.PrayInterface.PrayButton_2.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , FrontDevice.Form.ScreenHeight / 2 - 404 );
            }
            base.Update( );
        }
        public override void PreDraw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( PrayAssets.BackGround[ 0 ] , new Rectangle( 0 , 0 , FrontDevice.Form.ScreenWidth , FrontDevice.Form.ScreenHeight ) , Color.White );
            spriteBatch.Draw( PrayAssets.BackGround[ 1 ] , new Rectangle( 0 , 0 , FrontDevice.Form.ScreenWidth , FrontDevice.Form.ScreenHeight ) , Color.White );
            spriteBatch.Draw( PrayAssets.BackGround[ 2 ] , new Rectangle( 0 , 0 , FrontDevice.Form.ScreenWidth , FrontDevice.Form.ScreenHeight ) , Color.White );
            if ( PrayType == 5 )
            {
                spriteBatch.DrawString( FontAssets.MouseText.Value , "单击以继续" , FrontDevice.Form.ScreenCenter
                    - new Vector2( FontAssets.MouseText.Value.MeasureString( "单击以继续" ).X / 2 , -300 ) , Color.White );
            }
            base.PreDraw( spriteBatch );
        }
        public override void PostDraw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( PrayAssets.Top , new Rectangle( 0 , 0 , FrontDevice.Form.ScreenWidth , 80 ) , Color.White );
            spriteBatch.Draw( PrayAssets.Icon , new Vector2( FrontDevice.Form.ScreenWidth / 2 - 30 , 10 ) , Color.White );
            spriteBatch.Draw( TextureAssets.Item[ ModContent.ItemType<CleanStone>( ) ].Value , Vector2.One * 25 , Color.White );
            spriteBatch.DrawString( FontAssets.MouseText.Value , "x" + Main.
                LocalPlayer.GetModPlayer<RecordCurrency>( ).CleanBeadStone , Vector2.One * 25 + Vector2.UnitX * 50 , Color.Gray );


            base.PostDraw( spriteBatch );
        }
    }
}
