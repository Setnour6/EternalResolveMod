using EternalResolve.Assets.Textures.Prays;
using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameContent;

namespace EternalResolve.Common.Contents.Modulars.PrayModular
{
    public class PrayTextPanel : Control
    {
        public int Timer = 0;
        public bool IsActive = false;
        public Vector2 Target;
        public static Texture2D[ ] Image = new Texture2D[ 3 ];
        public override void Initialization( )
        {
            SetSize( 400 , 210 );
            base.Initialization( );
        }
        public override void Update( )
        {
            if ( Timer > 0 )
                Timer--;
            if ( Timer == 0 )
                Target = FrontDevice.Form.ScreenCenter - Size / 2 - Vector2.UnitY * 1000;
            else
                Target = FrontDevice.Form.ScreenCenter - Size / 2;
            Velocity = ( Target - Position ) * 0.09f;
            Position += Velocity;

            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( PrayAssets.PrayTextPanel , Position , Color );
            spriteBatch.DrawString( FontAssets.MouseText.Value , "拥有的洁玥石数量不足" , Position + Size / 2 -
               FontAssets.MouseText.Value.MeasureString( "拥有的洁玥石数量不足" ) / 2 , Color.Gray );
            base.Draw( spriteBatch );
        }
    }
}