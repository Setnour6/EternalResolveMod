using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;

namespace EternalResolve.Common.Contents.Modulars.ManaModular
{
    public class OtherSystemInterface : ControlOperator
    {
        public ManaBar ManaBar;

        public override void Initialization( )
        {
            ManaBar = new ManaBar( );
            ManaBar.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 , 50 );
            Register( ManaBar );

            base.Initialization( );
        }
    }
}
