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

namespace EternalResolve.Common.Contents.Modulars.RuneModular.RuneSlots
{
    public class WeaponRuneSlot : ItemSlot
    {
        public Texture2D Image;

        public bool OnPickUp = false;

        public override void Initialization( )
        {
            Image = RuneAssets.Slots[ 4 ];
            Width = 94;
            Height = 94;
            base.Initialization( );
        }

        public override void PreUpdate( )
        {
            if ( Superior.ControlAt( ) != this && FrontDevice.Input.MouseLeftClick )
                OnPickUp = false;
            if ( FrontDevice.Input.MouseState.ScrollWheelValue != FrontDevice.Input.OldMouseState.ScrollWheelValue )
                OnPickUp = false;
            base.PreUpdate( );
        }

        public override void LeftClick( UIMouseEvent mouseEvent , Control control )
        {
            //    Engine.PlaySound( SoundAssets.RuneSystem_Open );
            if ( OnPickUp && Interactive )
            {
                for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                {
                    for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
                    {
                        if ( Item.type != ItemID.None && Modular.RuneInterface.Inventory.Slot[ x , y ].Item.type == ItemID.None )
                        {
                            Modular.RuneInterface.Inventory.Slot[ x , y ].Item = Item.Clone( );
                            Item.SetDefaults( 0 );
                            break;
                        }
                    }
                }
            }
            OnPickUp = true;
        }
        public override void RightClick( UIMouseEvent mouseEvent , Control control )
        {
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
                if ( OnPickUp )
                {
                    Main.spriteBatch.Draw( RuneAssets.Slots[ 4 ] , Position , null , Color.White , 0f , Vector2.Zero , 1 , 0 , 0f );
                }
                Main.spriteBatch.Draw( TextureAssets.Item[ Item.type ].Value , Position , new Rectangle?( rectangle ) , Color.White , 0f , Vector2.Zero , 1 , 0 , 0f );
                Vector2 drawPos = Position + Size / 2 - RuneAssets.RuneTypeList[ (int) Item.GetGlobalItem<RuneItem>( ).RuneType ].Size( ) / 2;
                Main.spriteBatch.Draw( RuneAssets.RuneTypeList[ (int) Item.GetGlobalItem<RuneItem>( ).RuneType ] , drawPos , Color.White );
            }
        }
        public override void PostDraw( SpriteBatch spriteBatch )
        {
        }
    }
}