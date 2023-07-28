using EternalResolve.Assets.Textures.Prays;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.UI.Events;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Common.Contents.Modulars.PrayModular
{
    public class PrayButton_1 : Control
    {
        public Vector2 Target;

        public override void Initialization( )
        {
            SetSize( 262 , 854 );
            base.Initialization( );
        }
        public override void CalculationInteractive( )
        {
            if ( new Rectangle( PositionX.ToInt( ) + 30 , PositionY.ToInt( ) + 104 , 202 , 660 ).IntersectMouse( ) )
                Interactive = true;
            else
                Interactive = false;
        }
        public override void LeftClick( UIMouseEvent mouseEvent , Control element )
        {
            PrayInterface.ChangeType( 1 );
            base.LeftClick( mouseEvent , element );
        }
        public override void LeftPressed( UIMouseEvent mouseEvent , Control element )
        {
            if ( Scale > 1f )
                Scale -= EasingUtils.EaseInQuad( 0.9f - Scale ).ToFloat( );
            base.LeftPressed( mouseEvent , element );
        }
        public override void Hover( UIMouseEvent mouseEvent , Control element )
        {
            Scale += EasingUtils.EaseInQuad( 1.1f - Scale ).ToFloat( );
            base.Hover( mouseEvent , element );
        }
        public override void Update( )
        {
            Velocity = ( Target - Position ) * 0.09f;
            Position += Velocity;

            if ( Scale > 1f && ( FrontDevice.Input.MouseReleased || !Interactive ) )
                Scale -= EasingUtils.EaseInQuad( 1f - Scale ).ToFloat( );
            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( PrayAssets.Button[ 1 ] , DrawPosition , null , Color , 0f , Size / 2 , Scale , SpriteEffects.None , 1f );
            base.Draw( spriteBatch );
        }
    }
}