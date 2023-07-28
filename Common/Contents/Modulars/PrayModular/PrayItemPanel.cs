using EternalResolve.Assets.Textures.Prays;
using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace EternalResolve.Common.Contents.Modulars.PrayModular
{
    public class PrayItemPanel : Control
    {
        public Vector2 Target;
        public Item item;
        public override void Initialization( )
        {
            SetSize( 100 , 420 );
            item = FrontDevice.EmptyItem.Clone( );
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
            spriteBatch.Draw( PrayAssets.ItemPanel , Position , Color );
            spriteBatch.Draw( TextureAssets.Item[ item.type ].Value , Position + Size / 2 - TextureAssets.Item[ item.type ].Value.Size( ) / 2 , Color );
            base.Draw( spriteBatch );
        }
    }
}
