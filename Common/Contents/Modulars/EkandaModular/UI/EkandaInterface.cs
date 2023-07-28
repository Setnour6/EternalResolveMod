using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Contents.Modulars.EkandaModular.UI.Chats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular.UI
{
    public class EkandaInterface : ControlOperator
    {
        public EkandaChatList EkandaChatList = new EkandaChatList( );
        public override void Initialization( )
        {
            EkandaChatList.Position = FrontDevice.Form.ScreenCenter - Vector2.UnitY * 100;
            Register( EkandaChatList );
            base.Initialization( );
        }
        public override void Update( )
        {
            EkandaChatList.Position = FrontDevice.Form.ScreenCenter - Vector2.UnitY * 100;
            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            if ( Modular.EkandaInteracting )
            {
                base.Draw( spriteBatch );
            }
        }
    }
}
