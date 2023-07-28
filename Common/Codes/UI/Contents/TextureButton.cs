using EternalResolve.Common.Codes.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Codes.UI.Contents
{
    public class TextureButton : Control
    {
        public Texture2D Texture { get; set; }

        public Texture2D Border { get; set; }

        public override void LeftClick( UIMouseEvent mouseEvent , Control element )
        {
            Engine.PlaySound( SoundID.MenuTick );
            base.LeftClick( mouseEvent , element );
        }

        public override void PreDraw( SpriteBatch spriteBatch )
        {
            if ( Border != null && Interactive )
                spriteBatch.Draw( Border , Position + Size / 2 - Border.Size( ) / 2 , Color );
            base.PreDraw( spriteBatch );
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            if ( Texture != null )
                spriteBatch.Draw( Texture , Position , Color );
            base.Draw( spriteBatch );
        }
    }
}
