using EternalResolve.Assets.Textures.NpcChats;
using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;

namespace EternalResolve.Hooks.NpcChats
{
    public class NpcChatPanel : Control
    {

        public override void Initialization( )
        {
            SetSize( 1000 , 150 );
            base.Initialization( );
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( NpcChatAssets.Panel , Position , Color.White );
            spriteBatch.Draw( NpcChatAssets.PanelSlot , Position , Color.White );
            spriteBatch.DrawString( FontAssets.MouseText.Value , Main.npcChatText , Position + new Vector2( 150 , 26 ) , Color.White );
            base.Draw( spriteBatch );
        }
    }
}