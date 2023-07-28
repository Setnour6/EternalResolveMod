using EternalResolve.Assets.Textures.Runes;
using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Inventorys
{
    public class RuneWheel : Control
    {
        public override void Initialization( )
        {
            SetSize( 20 , 52 );
            DropPermit = true;
            base.Initialization( );
        }

        public override void Update( )
        {
            Velocity *= 0.8f;
            base.Update( );
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( RuneAssets.Wheels[ 0 ] , Position , Color );
            base.Draw( spriteBatch );
        }
    }
}
