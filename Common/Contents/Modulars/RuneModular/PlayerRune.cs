using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items.Runes;
using EternalResolve.Common.Contents.Modulars.SubWorlds;
using EternalResolve.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars.RuneModular
{
    public class PlayerRune : ModPlayer
    {
        protected override bool CloneNewInstances => true;

        public IList<Item> RunesCache = new List<Item>( );

        public override void SaveData( TagCompound tag )
        {
            for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
            {
                for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                {
                    if ( Modular.RuneInterface.Inventory.Slot[ x , y ].Item.Clone( ).ModItem != null &&
                       Modular.RuneInterface.Inventory.Slot[ x , y ].Item.Clone( ).type != ItemID.None )
                    {
                        tag.Add( "EternalResolve:PlayerRunes" + x + "_" + y , Modular.RuneInterface.Inventory.Slot[ x , y ].Item.Clone( ).ModItem.Name );
                        tag.Add( "EternalResolve:PlayerRunesLevel" + x + "_" + y , (int) Modular.RuneInterface.Inventory.Slot[ x , y ].Item.Clone( ).
                            GetGlobalItem<RuneItem>( ).RuneType );
                    }
                    else
                        tag.Add( "EternalResolve:PlayerRunes" + x + "_" + y , "None" );
                }
            }
            for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
            {
                for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                {
                    Modular.RuneInterface.Inventory.Slot[ x , y ].Item.SetDefaults( 0 );
                }
            }
            base.SaveData( tag );
        }

        public override void LoadData( TagCompound tag )
        {
            ModItem rune;
            for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
            {
                for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                {
                    if ( ModContent.TryFind( "EternalResolve" , tag.GetString( "EternalResolve:PlayerRunes" + x + "_" + y ) , out rune ) )
                    {
                        Player.GetModPlayer( this ).RunesCache.Add( rune.Item.Clone( ) );

                        Player.GetModPlayer( this ).RunesCache[ Player.GetModPlayer<PlayerRune>( ).RunesCache.Count - 1 ].
                            GetGlobalItem<RuneItem>( ).RuneType = (RuneType) tag.GetInt( "EternalResolve:PlayerRunesLevel" + x + "_" + y );
                    }
                    else
                    {
                        Player.GetModPlayer( this ).RunesCache.Add( FrontDevice.EmptyItem.Clone( ) );
                    }
                }
            }
            base.LoadData( tag );
        }

        public override void OnEnterWorld( Player player )
        {
            if ( !SubWorld.InSubWorld )
            {
                for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
                {
                    for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                    {
                        Modular.RuneInterface.Inventory.Slot[ x , y ].Item.SetDefaults(
                            Player.GetModPlayer( this ).RunesCache[ x * Modular.RuneInterface.Inventory.Slot.GetLength( 1 ) + y ].Clone( ).type
                            );
                        Modular.RuneInterface.Inventory.Slot[ x , y ].Item.GetGlobalItem<RuneItem>( ).RuneType =
                            Player.GetModPlayer( this ).RunesCache[ x * Modular.RuneInterface.Inventory.Slot.GetLength( 1 ) + y ].Clone( ).GetGlobalItem<RuneItem>( ).RuneType;
                    }
                }
            }
            base.OnEnterWorld( player );
        }

        internal string CreateUUID( )
        {
            string result = "";
            string[ ] texts = new string[ 8 ];
            for ( int stringCount = 0; stringCount < texts.Length; stringCount++ )
            {
                texts[ stringCount ] =
                    CsharpUtils.CharacterTable[ Main.rand.Next( CsharpUtils.CharacterTable.Length - 1 ) ] +
                    CsharpUtils.CharacterTable[ Main.rand.Next( CsharpUtils.CharacterTable.Length - 1 ) ] +
                    CsharpUtils.CharacterTable[ Main.rand.Next( CsharpUtils.CharacterTable.Length - 1 ) ];
            }
            foreach ( string text in texts )
            {
                result += text;
            }
            return result;
        }

        public override void PreUpdate( )
        {
            if ( Modular.RuneInteracting )
            {
                Player.mouseInterface = true;
                Player.delayUseItem = true;
                Player.controlDown = false;
                Player.controlHook = false;
                Player.controlJump = false;
                Player.controlUp = false;
                Player.controlLeft = false;
                Player.controlRight = false;
                Player.controlUseItem = false;
                Player.delayUseItem = true;
                Main.mouseLeft = false;
                Main.mouseLeftRelease = false;
                Main.mouseRight = false;
                Main.mouseRightRelease = false;
                Main.playerInventory = false;
                PlayerInput.ScrollWheelDelta = 0;
                PlayerInput.ScrollWheelDeltaForUI = 0;
                PlayerInput.MouseInfo = new MouseState( );
                PlayerInput.MouseInfoOld = new MouseState( );
                PlayerInput.ScrollWheelValue = 0;
                PlayerInput.ScrollWheelValueOld = 1;
                base.PreUpdate( );
            }
        }

        public override void UpdateEquips( )
        {
            for ( int count = 0; count < Modular.RuneInterface.WeaponRune.Slot.Length; count++ )
            {
                if ( Modular.RuneInterface.WeaponRune.Slot[ count ].Item.type != ItemID.None )
                    if ( Modular.RuneInterface.WeaponRune.Slot[ count ].Item.GetGlobalItem<RuneItem>( ).CompleteSet.Check( ) )
                    {
                        Modular.RuneInterface.WeaponRune.Slot[ count ].Item.GetGlobalItem<RuneItem>( ).CompleteSet.UpdateInventory( Player );
                    }
            }
            base.UpdateEquips( );
        }

        public override void PostUpdate( )
        {
            if ( Modular.RuneInteracting )
            {
                Player.mouseInterface = true;
                Player.delayUseItem = true;
                Player.controlDown = false;
                Player.controlHook = false;
                Player.controlJump = false;
                Player.controlUp = false;
                Player.controlLeft = false;
                Player.controlRight = false;
                Player.controlUseItem = false;
                Player.delayUseItem = true;
                Main.mouseLeft = false;
                Main.mouseLeftRelease = false;
                Main.mouseRight = false;
                Main.mouseRightRelease = false;
                Main.playerInventory = false;
                PlayerInput.ScrollWheelDelta = 0;
                PlayerInput.ScrollWheelDeltaForUI = 0;
                PlayerInput.MouseInfo = new MouseState( );
                PlayerInput.MouseInfoOld = new MouseState( );
                PlayerInput.GamepadScrollValue = 0;
                PlayerInput.ScrollWheelValue = 0;
                PlayerInput.ScrollWheelValueOld = 1;
            }
            base.PostUpdate( );
        }
    }
}