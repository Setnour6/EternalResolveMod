using EternalResolve.Assets.Textures.Systems.RefineSystems;
using EternalResolve.Common.Codes.UI.Contents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSystemSlot : ItemSlot
    {
        public RefineSystemSlot( Texture2D image )
        {
            Texture = image;
        }
        public override void Initialization( )
        {
            SetSize( 52 , 56 );
            base.Initialization( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            if ( Texture != null )
                spriteBatch.Draw( Texture , Position , Color );

            if ( Item != null && Item.type != ItemID.None )
            {
                Texture2D _itemImage = TextureAssets.Item[ Item.type ].Value;
                Rectangle _itemFrame;
                if ( Main.itemAnimations[ Item.type ] != null )
                    _itemFrame = Main.itemAnimations[ Item.type ].GetFrame( _itemImage );
                else
                    _itemFrame = TextureAssets.Item[ Item.type ].Value.Frame( 1 , 1 , 0 , 0 );
                Vector2 _itemSize = _itemFrame.Size( );
                float _scaleFactor = 1f;
                if ( ( _itemSize.X > Rectangle.Width || _itemSize.Y > Rectangle.Height ) && ItemScale )
                {
                    if ( _itemSize.X > _itemSize.Y )
                        _scaleFactor = _itemSize.X / Rectangle.Width;
                    else
                        _scaleFactor = _itemSize.Y / Rectangle.Height;
                    _scaleFactor = 0.8f / _scaleFactor;
                    _itemSize *= _scaleFactor;
                }
                Main.spriteBatch.Draw( RefineAssets.Slot , Position , Color.White );
                Main.spriteBatch.Draw( _itemImage , Position + Size / 2f - _itemSize / 2f , new Rectangle?( _itemFrame ) , Color.White , 0f , Vector2.Zero , _scaleFactor , 0 , 0f );
                if ( Item.stack > 1 )
                    Utils.DrawBorderStringFourWay( Main.spriteBatch , FontAssets.ItemStack.Value , Item.stack.ToString( ) , Rectangle.X + 10 , Rectangle.Y + Rectangle.Height - 20 , Color.White , Color.Black , Vector2.Zero , 1 );
            }
        }
    }
}
