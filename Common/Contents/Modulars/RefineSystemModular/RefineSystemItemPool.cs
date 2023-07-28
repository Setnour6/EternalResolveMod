using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.UI.Events;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSystemItemPool : Control
    {
        public List<RefineSoul> Souls = new List<RefineSoul>( );

        public override void Initialization( )
        {
            SetSize( 292 , 280 );
            base.Initialization( );
        }
        public override void LeftClick( UIMouseEvent mouseEvent , Control element )
        {
            if ( Main.mouseItem.type == ItemID.None )
            {
                Item Item;
                for ( int count = 0; count < Souls.Count; count++ )
                {
                    Item = Souls[ count ].Item;
                    if ( Item != null && Item.type != ItemID.None )
                    {
                        Texture2D _itemImage = TextureAssets.Item[ Item.type ].Value;
                        Rectangle _itemFrame;
                        if ( Main.itemAnimations[ Item.type ] != null )
                            _itemFrame = Main.itemAnimations[ Item.type ].GetFrame( _itemImage );
                        else
                            _itemFrame = TextureAssets.Item[ Item.type ].Value.Frame( 1 , 1 , 0 , 0 );
                        Vector2 v = Position + Souls[ count ].Pos - _itemFrame.Size( ) / 2;
                        Rectangle rectangle = new Rectangle( v.X.ToInt( ) , v.Y.ToInt( ) , _itemFrame.Width , _itemFrame.Height );
                        if ( rectangle.IntersectMouse( ) )
                        {
                            Item item = Souls[ count ].Item.Clone( );
                            item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                            Main.mouseItem = item;
                            Souls.RemoveAt( count );
                        }
                    }
                }
            }
            else if ( Main.mouseItem != null && Main.mouseItem.type != ItemID.None )
            {
                Item item = Main.mouseItem.Clone( );
                item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                AddItem( item , FrontDevice.Input.MousePosition - Position );
                Main.mouseItem.SetDefaults( 0 );
                SoundEngine.PlaySound( SoundID.NPCHit11 );
            }
            base.LeftClick( mouseEvent , element );
        }
        public override void Update( )
        {
            for ( int count = 0; count < Souls.Count; count++ )
            {
                Souls[ count ].Update( );
            }

            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            base.Draw( spriteBatch );
            for ( int count = 0; count < Souls.Count; count++ )
            {
                Item Item = Souls[ count ].Item;
                if ( Item != null && Item.type != ItemID.None )
                {
                    Texture2D _itemImage = TextureAssets.Item[ Item.type ].Value;
                    Rectangle _itemFrame;
                    if ( Main.itemAnimations[ Item.type ] != null )
                        _itemFrame = Main.itemAnimations[ Item.type ].GetFrame( _itemImage );
                    else
                        _itemFrame = TextureAssets.Item[ Item.type ].Value.Frame( 1 , 1 , 0 , 0 );
                    Vector2 _itemSize = _itemFrame.Size( );
                    Souls[ count ].DrawItem( _itemImage , Position + Souls[ count ].Pos - _itemSize / 2f , _itemFrame );
                }
            }
        }

        public void AddItem( Item item , Vector2 vector2 )
        {
            Souls.Add( new RefineSoul( vector2 , item ) );
        }
    }
}