using EternalResolve.Assets.Textures.Prays;
using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Common.Contents.Modulars.PrayModular
{
    public class PrayPanel : Control
    {
        public Vector2 Target;
        public override void Initialization( )
        {
            SetSize( 976 , 570 );
            base.Initialization( );
        }
        public override void Update( )
        {
            Velocity = ( Target - Position ) * 0.09f;
            Position += Velocity;
            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( PrayAssets.Panel , Position , Color );
            if ( Modular.PrayInterface.PrayType == 0 ||
                Modular.PrayInterface.PrayType == 1 ||
                Modular.PrayInterface.PrayType == 2 )
            {
                spriteBatch.Draw( PrayAssets.Image[ Modular.PrayInterface.PrayType ] , Position + new Vector2( 30 , 34 ) , Color.White );
            }
            base.Draw( spriteBatch );
        }
    }
}
