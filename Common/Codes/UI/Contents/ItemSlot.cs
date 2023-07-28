using EternalResolve.Common.Codes.UI.Events;
using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Codes.UI.Contents
{
    /// <summary>
    /// 物品框.
    /// </summary>
    public class ItemSlot : TextureButton
    {
        public Item Item;

        /// <summary>
        /// 开启物品缩放.
        /// </summary>
        public bool ItemScale { get; set; } = true;

        public override void Initialization( )
        {
            Item = FrontDevice.EmptyItem.Clone( );
            base.Initialization( );
        }

        public override void LeftClick( UIMouseEvent mouseEvent , Control control )
        {
            if ( Item.type == Main.mouseItem.type && Item.type != ItemID.None && Item.stack < Item.maxStack )
            {
                Engine.PlaySound( SoundID.Grab , -1 , -1 , 1 , 1f , 0f );
                Item.stack += Main.mouseItem.stack;
                Main.mouseItem = new Item( );
                return;
            }
            if ( Main.mouseItem.type == ItemID.None && Item.type != ItemID.None )
            {
                Engine.PlaySound( SoundID.Grab , -1 , -1 , 1 , 1f , 0f );
                Main.mouseItem = Item;
                Item = new Item( );
                return;
            }
            if ( Main.mouseItem.type != ItemID.None && Item.type == ItemID.None )
            {
                Engine.PlaySound( SoundID.Grab , -1 , -1 , 1 , 1f , 0f );
                Item = Main.mouseItem.Clone( );
                Main.mouseItem = new Item( );
                return;
            }
            if ( Main.mouseItem.type != ItemID.None && Item.type != ItemID.None )
            {
                Engine.PlaySound( SoundID.Grab , -1 , -1 , 1 , 1f , 0f );
                Item mouseItem = Main.mouseItem;
                Main.mouseItem = Item;
                Item = mouseItem;
            }
        }

        public override void RightClick( UIMouseEvent mouseEvent , Control control )
        {
            Main.LocalPlayer.mouseInterface = true;
            if ( Item.type != ItemID.None && Item.stack > 1 && Main.mouseItem.IsAir )
            {
                Engine.PlaySound( SoundID.MenuTick , -1 , -1 , 1 , 1f , 0f );
                Item item = new Item( );
                item.SetDefaults( Item.type );
                Main.mouseItem = item;
                Main.mouseItem.stack = 1;
                Item.stack -= 1;
            }
            else if ( Item.type == ItemID.None && Main.mouseItem.type != ItemID.None && Main.mouseItem.stack > 1 )
            {
                Engine.PlaySound( SoundID.MenuTick , -1 , -1 , 1 , 1f , 0f );
                Item Item = new Item( );
                Item.SetDefaults( Main.mouseItem.type );
                Item.stack = 1;
                Main.mouseItem.stack -= 1;
            }
            else if ( Item.type == Main.mouseItem.type && Item.stack < Item.maxStack )
            {
                Engine.PlaySound( SoundID.MenuTick , -1 , -1 , 1 , 1f , 0f );
                Main.mouseItem.stack -= 1;
                Item.stack += 1;
            }
            base.RightClick( mouseEvent , control );
        }

        public override void Update( )
        {
            if ( Item != null && Item.type != ItemID.None )
            {
                Main.LocalPlayer.VanillaUpdateInventory( Item );
            }
            base.Update( );
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            base.Draw( spriteBatch );
            if ( Item != null && Item.type != ItemID.None )
            {
                Texture2D _itemImage = TextureAssets.Item[ Item.type ].Value;
                Rectangle _itemFrame;
                if ( Main.itemAnimations[ Item.type ] != null )
                    _itemFrame = Main.itemAnimations[ Item.type ].GetFrame( _itemImage );
                else
                    _itemFrame = Terraria.Utils.Frame( TextureAssets.Item[ Item.type ].Value , 1 , 1 , 0 , 0 );
                Vector2 _itemSize = Terraria.Utils.Size( _itemFrame );
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
                Main.spriteBatch.Draw( _itemImage , Position + Size / 2f - _itemSize / 2f , new Rectangle?( _itemFrame ) , Color.White , 0f , Vector2.Zero , _scaleFactor , 0 , 0f );
                if ( Item.stack > 1 )
                    Terraria.Utils.DrawBorderStringFourWay( Main.spriteBatch , FontAssets.ItemStack.Value , Item.stack.ToString( ) , Rectangle.X + 10 , Rectangle.Y + Rectangle.Height - 20 , Color.White , Color.Black , Vector2.Zero , 1 );
            }
        }

        public override void PostDraw( SpriteBatch spriteBatch )
        {
            if ( Superior.Manager.ControlAt( ) == this )
            {
                if ( Item.type != ItemID.None )
                    Item.GetGlobalItem<ItemToolTipHack>( ).ToolTip.
                        Draw( Item , FrontDevice.Input.MousePosition.X.ToInt( ) + 32 , FrontDevice.Input.MousePosition.Y.ToInt( ) + 32 );
            }
            base.PostDraw( spriteBatch );
        }
    }
}