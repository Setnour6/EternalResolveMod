using EternalResolve.Assets.Textures.Runes;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.UI.Contents;
using EternalResolve.Common.Codes.UI.Events;
using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items.Runes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Inventorys
{
    public class RuneSlot : ItemSlot
    {
        public Texture2D Image;

        public bool OnPickUp = false;

        public override void Initialization( )
        {
            ItemScale = false;
            Image = RuneAssets.Slots[ 2 ];
            Width = 94;
            Height = 94;
            if ( Item == null || Item.type == ItemID.None )
                Item = FrontDevice.EmptyItem.Clone( );
            base.Initialization( );
        }
        public override void LeftClick( UIMouseEvent mouseEvent , Control control )
        {
            // SoundAssets.RuneSystem_Open.Play( );
            if ( OnPickUp && Interactive )
            {
                for ( int count = 0; count < Modular.RuneInterface.WeaponRune.Slot.Length; count++ )
                {
                    if ( Modular.RuneInterface.WeaponRune.Slot[ count ].Item.type == Item.type  )
                    {
                        OnPickUp = true;
                        return;
                    }
                }
                for ( int count = 0; count < Modular.RuneInterface.WeaponRune.Slot.Length; count++ )
                {
                    if ( Item.type != ItemID.None && Modular.RuneInterface.WeaponRune.Slot[ count ].Item.type == ItemID.None )
                    {
                        Modular.RuneInterface.WeaponRune.Slot[ count ].Item = Item.Clone( );
                        Item.SetDefaults( 0 );
                        break;
                    }
                }
            }
            OnPickUp = true;
        }
        public override void RightPressed( UIMouseEvent mouseEvent , Control element )
        {
            if ( Item.alpha <= 5 )
            {
                Item.SetDefaults( 0 );
            }
            else
                Item.alpha -= 5;
            base.RightPressed( mouseEvent , element );
        }
        public override void PostUpdate( )
        {
            if ( !FrontDevice.Input.MouseRightPressed )
                Item.alpha = 255;

            base.PostUpdate( );
        }
        public override void PreUpdate( )
        {
            if ( Superior.ControlAt( ) != this && FrontDevice.Input.MouseLeftClick )
                OnPickUp = false;
            if ( FrontDevice.Input.MouseState.ScrollWheelValue != FrontDevice.Input.OldMouseState.ScrollWheelValue )
                OnPickUp = false;
            base.PreUpdate( );
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( Image , Position , Color.White );
            if ( Item != null && Item.type != ItemID.None )
            {
                Texture2D ItemImage = TextureAssets.Item[ Item.type ].Value;
                Rectangle rectangle =
                    ( Main.itemAnimations[ Item.type ] != null ) ?
                    Main.itemAnimations[ Item.type ].GetFrame( ItemImage ) :
                    Utils.Frame( TextureAssets.Item[ Item.type ].Value , 1 , 1 , 0 , 0 );
                Vector2 ItemSize = Utils.Size( rectangle );
                Main.spriteBatch.Draw( RuneAssets.Slots[ 3 ] , Position , null , Color.White , 0f , Vector2.Zero , 1f , 0 , 0f );
                if ( OnPickUp )
                {
                    Main.spriteBatch.Draw( RuneAssets.Slots[ 4 ] , Position , null , Color.White , 0f , Vector2.Zero , 1f , 0 , 0f );
                }
                Main.spriteBatch.Draw( TextureAssets.Item[ Item.type ].Value , Position , new Rectangle?( rectangle ) , new Color( 255 , 255 , 255 , Item.alpha ) , 0f , Vector2.Zero , 1f , 0 , 0f );
                Vector2 drawPos = Position + Size / 2 - RuneAssets.RuneTypeList[ (int) Item.GetGlobalItem<RuneItem>( ).RuneType ].Size( ) / 2;
                Main.spriteBatch.Draw( RuneAssets.RuneTypeList[ (int) Item.GetGlobalItem<RuneItem>( ).RuneType ] , drawPos , Color.White );
            }
        }
        public override void PostDraw( SpriteBatch spriteBatch )
        {
        }
    }
}