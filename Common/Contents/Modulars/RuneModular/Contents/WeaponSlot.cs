using EternalResolve.Assets.Textures.Runes;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Contents
{
    public class WeaponSlot : Control
    {
        public Item Item { get; set; }

        public bool ItemScale { get; set; }

        public override void Initialization( )
        {
            Item = FrontDevice.EmptyItem.Clone( );
            Width = 104;
            Height = 104;
            base.Initialization( );
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( RuneAssets.Slots[ 0 ] , base.Position , base.Color );
            base.Draw( spriteBatch );
            if ( this.Item.type != 0 )
            {
                Texture2D ItemImage = TextureAssets.Item[ this.Item.type ].Value;
                Rectangle rectangle = ( Main.itemAnimations[ this.Item.type ] != null ) ? Main.itemAnimations[ this.Item.type ].GetFrame( ItemImage , -1 ) : TextureAssets.Item[ this.Item.type ].Value.Frame( 1 , 1 , 0 , 0 , 0 , 0 );
                Vector2 ItemSize = rectangle.Size( );
                float scaleFactor = 1f;
                if ( ( ItemSize.X > (float) base.Rectangle.Width || ItemSize.Y > (float) base.Rectangle.Height ) && this.ItemScale )
                {
                    scaleFactor = ( ( ItemSize.X > ItemSize.Y ) ? ( ItemSize.X / (float) base.Rectangle.Width ) : ( ItemSize.Y / (float) base.Rectangle.Height ) );
                    scaleFactor = 0.8f / scaleFactor;
                    ItemSize *= scaleFactor;
                }
                Main.spriteBatch.Draw( ItemImage , base.Position + base.Size / 2f - ItemSize / 2f , new Rectangle?( rectangle ) , Color.White , 0f , Vector2.Zero , scaleFactor , 0 , 0f );
            }
        }
    }
}