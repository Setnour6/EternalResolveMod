using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Hooks.NpcChats
{
    public class NpcChatInterface : ControlOperator
    {
        public NpcChatPanel Panel;
        public override void Initialization( )
        {
            Panel = new NpcChatPanel( );
            Panel.Position = FrontDevice.Form.ScreenCenter + Vector2.UnitY * 150 - Vector2.UnitX * 500;
            Register( Panel );
            base.Initialization( );
        }
        public override void Update( )
        {

            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {

            base.Draw( spriteBatch );
        }
    }
}
