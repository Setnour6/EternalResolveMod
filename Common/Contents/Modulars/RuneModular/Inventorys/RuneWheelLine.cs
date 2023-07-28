using EternalResolve.Assets.Textures.Runes;
using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Inventorys
{
    public class RuneWheelLine : Control
    {
        public RuneWheel Wheel;

        public override void Initialization( )
        {
            LockSubControl = false;
            SetSize( 8 , 540 );
            Wheel = new RuneWheel( );
            Register( Wheel );
            base.Initialization( );
        }

        public override void Update( )
        {
            base.Update( );
            if ( Wheel.PositionX != PositionX - 6 )
                Wheel.PositionX = PositionX - 6;
            if ( Wheel.PositionY < PositionY )
                Wheel.PositionY = PositionY;
            else if ( Wheel.PositionY > PositionY + Height )
                Wheel.PositionY = PositionY + Height;

            if ( FrontDevice.Input.MouseState.ScrollWheelValue > FrontDevice.Input.OldMouseState.ScrollWheelValue )
                Wheel.VelocityY -= 1;
            else if ( FrontDevice.Input.MouseState.ScrollWheelValue < FrontDevice.Input.OldMouseState.ScrollWheelValue )
                Wheel.VelocityY += 1;

            Wheel.Position += Wheel.Velocity;
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( RuneAssets.Wheels[ 1 ] , Position , Color );
            base.Draw( spriteBatch );
        }
    }
}
