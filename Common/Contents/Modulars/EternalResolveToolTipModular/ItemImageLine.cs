using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular
{
    public class ItemImageLine : Line
    {
        public override int X { get; set; } = 0;

        public override int Y { get; set; } = 0;

        public override int DrawType => 1;

        public Item Item;

        public ItemImageLine( Item item )
        {
            Item = item;
        }
        public override void CheckSize( )
        {
            Texture2D _itemImage = TextureAssets.Item[ Item.type ].Value;
            Rectangle _itemFrame;
            if ( Main.itemAnimations[ Item.type ] != null )
                _itemFrame = Main.itemAnimations[ Item.type ].GetFrame( _itemImage );
            else
                _itemFrame = Utils.Frame( TextureAssets.Item[ Item.type ].Value , 1 , 1 , 0 , 0 );
            Vector2 _itemSize = Utils.Size( _itemFrame );
            Width = _itemFrame.Width;
            Height = _itemFrame.Height + 12;
            base.CheckSize( );
        }
        public override void Draw( )
        {
            Texture2D _itemImage = TextureAssets.Item[ Item.type ].Value;
            Rectangle _itemFrame;
            if ( Main.itemAnimations[ Item.type ] != null )
                _itemFrame = Main.itemAnimations[ Item.type ].GetFrame( _itemImage );
            else
                _itemFrame = Terraria.Utils.Frame( TextureAssets.Item[ Item.type ].Value , 1 , 1 , 0 , 0 );
            Vector2 _itemSize = Terraria.Utils.Size( _itemFrame );
            Width = _itemFrame.Width;
            Height = _itemFrame.Height + 12;
            Main.spriteBatch.Draw( _itemImage , new Vector2( X , Y ) , new Rectangle?( _itemFrame ) , Color.White );
            base.Draw( );
        }
    }
}