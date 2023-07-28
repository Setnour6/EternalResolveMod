using EternalResolve.Assets.Textures.Runes;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using EternalResolve.Common.Contents.Modulars.RuneModular.Inventorys;
using EternalResolve.Common.Contents.Modulars.RuneModular.RuneSlots;
using EternalResolve.Common.Graphics.Replaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Contents
{
    /// <summary>
    /// 符印系统.
    /// </summary>
    public class RuneInterface : ControlOperator
    {
        public InformationPanel InformationPanel;

        public RuneInventory Inventory;

        public RuneWheelLine RuneWheelLine;

        public WeaponRune WeaponRune;

        public override void Initialization( )
        {
            _time = 0;

            int screenCenterX = FrontDevice.Form.ScreenCenter.X.ToInt( );
            int screenCenterY = FrontDevice.Form.ScreenCenter.Y.ToInt( );
            Inventory = new RuneInventory( );
            Inventory.Position = new Vector2( screenCenterX / 2 + 266 , screenCenterY - 234 );
            Register( Inventory );
            RuneWheelLine = new RuneWheelLine( );
            RuneWheelLine.Position = new Vector2( screenCenterX / 2 + 632 , screenCenterY - 224 );
            Register( RuneWheelLine );
            WeaponRune = new WeaponRune( );
            WeaponRune.Position = new Vector2( screenCenterX / 2 - 161 , screenCenterY / 2 - 150 );
            Register( WeaponRune );
            InformationPanel = new InformationPanel( );
            InformationPanel.Position = new Vector2( screenCenterX - 694 , screenCenterY - 242 );
            Register( InformationPanel );
            base.Initialization( );
        }
        public override void PreUpdate( )
        {
            int screenCenterX = FrontDevice.Form.ScreenCenter.X.ToInt( );
            int screenCenterY = FrontDevice.Form.ScreenCenter.Y.ToInt( );
            InformationPanel.Position = new Vector2( screenCenterX - 694 , screenCenterY - 242 );
            Inventory.PositionX = screenCenterX + 266;
            RuneWheelLine.Position = new Vector2( screenCenterX + 632 , screenCenterY - 224 );
            WeaponRune.Position = new Vector2( screenCenterX - 161 , screenCenterY - 150 );
            int originY = screenCenterY - 234;
            float wheelY = 1 - ( ( ( RuneWheelLine.Height - RuneWheelLine.Wheel.Height ) - ( RuneWheelLine.Wheel.PositionY - originY ) ) / ( RuneWheelLine.Height - RuneWheelLine.Wheel.Height ) );
            int inventoryY = ( wheelY * 46460 ).ToInt( );
            Inventory.PositionY = ( ( screenCenterY / 2 - 234 ) - inventoryY + 10 * 130 - 60 );
            base.PreUpdate( );
        }
        float _time;
        public override void PreDraw( SpriteBatch spriteBatch )
        {
            _time += 0.001f;

            int screenCenterX = FrontDevice.Form.ScreenCenter.X.ToInt( );
            int screenCenterY = FrontDevice.Form.ScreenCenter.Y.ToInt( );

            spriteBatch.Draw( RuneAssets.BackGrounds[ 0 ] , new Vector2( screenCenterX - 960 , screenCenterY - 540 ) , Color.White );
            spriteBatch.End( );
            spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.Additive );
            spriteBatch.Draw( RuneAssets.BlockBG , new Vector2( screenCenterX - 960 , screenCenterY - 540 ) , Color.Gray );
            spriteBatch.End( );
            Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.NonPremultiplied , SamplerState.LinearClamp , DepthStencilState.None , RasterizerState.CullNone , null );

            spriteBatch.Draw( RuneAssets.BackGrounds[ 1 ] , new Vector2( screenCenterX - 960 , screenCenterY - 540 ) , Color.White );

            spriteBatch.Draw( RuneAssets.BackGrounds[ 2 ] , new Vector2( screenCenterX - 960 , 0 ) , Color.White );
            spriteBatch.Draw( RuneAssets.BackGrounds[ 3 ] , new Vector2( screenCenterX - 960 , screenCenterY - 540 ) , Color.White );


            base.PreDraw( spriteBatch );
            spriteBatch.Draw( RuneAssets.Top , new Rectangle( 0 , 0 , screenCenterX * 2 , 80 ) , Color.White );
            spriteBatch.Draw( RuneAssets.ShadowOfTop , new Rectangle( 0 , 80 , screenCenterX * 2 , 80 ) , Color.White );
            spriteBatch.Draw( RuneAssets.Lines[ 0 ] , new Vector2( screenCenterX - 212 , screenCenterY + 190 ) , Color.White );
            spriteBatch.Draw( RuneAssets.Lines[ 1 ] , new Vector2( screenCenterX + 226 , screenCenterY - 222 ) , Color.White );
            spriteBatch.Draw( RuneAssets.Text , new Vector2( screenCenterX - 180 , screenCenterY - 230 ) , Color.White );
            spriteBatch.Draw( RuneAssets.Icon , new Vector2( screenCenterX - 30 , 10 ) , Color.White );
        }
        public override void PostDraw( SpriteBatch spriteBatch )
        {
            int countY = ( ( Main.screenHeight / 2 - 234 ) - Inventory.PositionY ).ToInt( ) / 130;
            if ( countY < 0 )
                countY = 0;
            int targetY = countY + 6;
            if ( targetY > 400 )
                targetY = 400;

            spriteBatch.End( );
            Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.AlphaBlend , SamplerState.LinearClamp , DepthStencilState.None , RasterizerState.CullNone , null );
            for ( int x = 0; x < Inventory.Slot.GetLength( 0 ); x++ )
            {
                for ( int y = countY; y < targetY; y++ )
                {
                    if ( Inventory.Slot[ x , y ].OnPickUp && Inventory.Slot[ x , y ].Item.type != ItemID.None )
                    {
                        Inventory.Slot[ x , y ].Item.GetGlobalItem<ItemToolTipHack>( ).BackGround =
                            ReplaceSystem.GetTexture( "ItemSlots/Replace_ItemSlot_4" ).Value;

                        Inventory.Slot[ x , y ].Item.GetGlobalItem<ItemToolTipHack>( ).ToolTip.Draw( Inventory.Slot[ x , y ].Item , Inventory.Slot[ x , y ].PositionX.ToInt( ) + 50 , Inventory.Slot[ x , y ].PositionY.ToInt( ) + 50 );
                    }
                }
            }
            for ( int count = 0; count < Modular.RuneInterface.WeaponRune.Slot.Length; count++ )
            {
                if ( Modular.RuneInterface.WeaponRune.Slot[ count ].OnPickUp && Modular.RuneInterface.WeaponRune.Slot[ count ].Item != null && Modular.RuneInterface.WeaponRune.Slot[ count ].Item.type != ItemID.None )
                {
                    Modular.RuneInterface.WeaponRune.Slot[ count ].Item.GetGlobalItem<ItemToolTipHack>( ).BackGround =
                        ReplaceSystem.GetTexture( "ItemSlots/Replace_ItemSlot_4" ).Value;
                    Modular.RuneInterface.WeaponRune.Slot[ count ].Item.GetGlobalItem<ItemToolTipHack>( ).ToolTip.Draw( Modular.RuneInterface.WeaponRune.Slot[ count ].Item , Modular.RuneInterface.WeaponRune.Slot[ count ].PositionX.ToInt( ) + 50 , Modular.RuneInterface.WeaponRune.Slot[ count ].PositionY.ToInt( ) + 50 );
                }
            }
            base.PostDraw( spriteBatch );
        }
    }
}
