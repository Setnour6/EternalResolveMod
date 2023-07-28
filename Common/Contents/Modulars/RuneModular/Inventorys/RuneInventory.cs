using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Inventorys
{
    public class RuneInventory : Control
    {
        private static readonly RasterizerState OverflowHiddenRasterizerState = new RasterizerState
        {
            CullMode = CullMode.None ,
            ScissorTestEnable = true
        };

        public RuneSlot[ , ] Slot = new RuneSlot[ 3 , 400 ];

        public override void Initialization( )
        {
            SetSize( 330 , 48800 );
            LoadSlots( );
            base.Initialization( );
        }
        public void LoadSlots( )
        {
            for ( int x = 0; x < Slot.GetLength( 0 ); x++ )
            {
                for ( int y = 0; y < Slot.GetLength( 1 ); y++ )
                {
                    Slot[ x , y ] = new RuneSlot( );
                    Slot[ x , y ].SubPosition = new Vector2( 116 * x , 130 * y );
                    Register( Slot[ x , y ] );
                }
            }
        }
        protected override void UpdateSubControls( )
        {
            int countY = ( ( Main.screenHeight / 2 - 234 ) - PositionY ).ToInt( ) / 130;
            if ( countY < 0 )
                countY = 0;
            int targetY = countY + 6;
            if ( targetY > 400 )
                targetY = 400;
            for ( int x = 0; x < Slot.GetLength( 0 ); x++ )
            {
                for ( int y = countY; y < targetY; y++ )
                {
                    Slot[ x , y ].CalculationInteractive( );
                    Slot[ x , y ].Update( Main.gameTimeCache );
                }
            }
            foreach ( Control slot in Slot )
            {
                if ( LockSubControl )
                    slot.Position = Position + slot.SubPosition;
            }
        }
        protected override void DrawSubControls( )
        {
            int countY = ( ( Main.screenHeight / 2 - 234 ) - PositionY ).ToInt( ) / 130;
            if ( countY < 0 )
                countY = 0;
            int targetY = countY + 6;
            if ( targetY > 400 )
                targetY = 400;
            for ( int x = 0; x < Slot.GetLength( 0 ); x++ )
            {
                for ( int y = countY; y < targetY; y++ )
                {
                    Slot[ x , y ].Draw( Main.gameTimeCache );
                }
            }
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            SamplerState anisotropicClamp = SamplerState.AnisotropicClamp;
            Rectangle clippingRectangle = new Rectangle( FrontDevice.Form.ScreenWidth / 2 + 254 , FrontDevice.Form.ScreenHeight / 2 - 236 , 342 , 652 );
            spriteBatch.End( );
            spriteBatch.GraphicsDevice.ScissorRectangle = clippingRectangle;
            spriteBatch.GraphicsDevice.RasterizerState = OverflowHiddenRasterizerState;
            spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.AlphaBlend , anisotropicClamp , DepthStencilState.None , OverflowHiddenRasterizerState , null );
            base.Draw( spriteBatch );
            spriteBatch.End( );
            spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.NonPremultiplied , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null );

        }
    }
}