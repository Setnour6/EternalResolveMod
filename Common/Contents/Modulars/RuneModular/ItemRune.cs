using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items.Runes;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars.RuneModular
{
    public class ItemRune : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

        public IList<Item> Runes = new List<Item>();

        public bool AtCheckRune = false;

        public override void SetDefaults( Item item )
        {
            item.GetGlobalItem<ItemRune>( ).Runes = new List<Item>();
            if ( Main.netMode != NetmodeID.Server )
            {
                for ( int count = 0; count < 6; count++ )
                {
                    item.GetGlobalItem<ItemRune>( ).Runes.Add( FrontDevice.EmptyItem.Clone( ) );
                }
                item.GetGlobalItem<ItemRune>( ).AtCheckRune = false;
            }
            base.SetDefaults( item );
        }
        public override void SaveData( Item item , TagCompound tag )
        {
            for ( int count = 0; count < 6; count++ )
            {
                if( item.GetGlobalItem<ItemRune>( ).Runes[ count ].type != ItemID.None )
                    tag.Add( "EternalResolve:ItemRune" + count , item.GetGlobalItem<ItemRune>( ).Runes[count].ModItem.Name );
                else
                    tag.Add( "EternalResolve:ItemRune" + count , "None" );
            }
            for ( int count = 0; count < Runes.Count; count++ )
            {
                if ( Runes[ count ] != null && Runes[ count ].type != ItemID.None )
                    tag.Add( "EternalResolve:ItemRune" + count + "RuneLevel" , (int) Runes[ count ].GetGlobalItem<RuneItem>( ).RuneType );
            }
        }

        public override void LoadData( Item item , TagCompound tag )
        {
            ModItem modItem;
            for ( int count = 0; count < 6; count++ )
            {
                string data = tag.GetString( "EternalResolve:ItemRune" + count );
                if ( ModContent.TryFind( "EternalResolve" , data , out modItem ) )
                    item.GetGlobalItem<ItemRune>( ).Runes[ count ].SetDefaults( modItem.Type );
                else
                    item.GetGlobalItem<ItemRune>( ).Runes[ count ].SetDefaults( 0 );
            }
            for ( int count = 0; count < 6; count++ )
            {
                item.GetGlobalItem<ItemRune>( ).Runes[ count ].GetGlobalItem<RuneItem>( ).RuneType =
                    (RuneType) tag.GetInt( "EternalResolve:ItemRune" + count + "RuneLevel" );
            }
            base.LoadData( item , tag );
        }

        public override void HoldItem( Item item , Player player )
        {
            if ( item != null && item.type != ItemID.None )
            {
                for ( int count = 0; count < item.GetGlobalItem<ItemRune>( ).Runes.Count; count++ )
                {
                    if ( item.GetGlobalItem<ItemRune>( ).Runes[ count ].type != ItemID.None )
                        item.GetGlobalItem<ItemRune>( ).Runes[ count ].ModItem.HoldItem( player );
                }
            }
            base.HoldItem( item , player );
        }

        public override void UpdateInventory( Item item , Player player )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                if ( item != null && item.type != ItemID.None )
                {
                    if ( Main.HoverItem != null && Main.HoverItem.type != ItemID.None )
                    {
                        if ( item.IsWeapon( ) && item.UUID( ) == Main.HoverItem.UUID( ) )
                        {
                            if ( !Modular.RuneInteracting && FrontDevice.Input.IsKeyClick( Keys.P ) )
                            {
                                Modular.RuneInteracting = true;
                                item.GetGlobalItem<ItemRune>( ).AtCheckRune = true;
                                Modular.RuneInterface.InformationPanel.Slot.Item = item.Clone( );
                                for ( int count = 0; count < 6; count++ )
                                {
                                    Modular.RuneInterface.WeaponRune.Slot[ count ].Item = item.GetGlobalItem<ItemRune>( ).Runes[count].Clone( );
                                }
                                ChangeAnimation.PlayChangeAnimation( );
                            }
                        }
                    }
                    else if ( Modular.RuneInteracting && (FrontDevice.Input.IsKeyClick( Keys.P ) || FrontDevice.Input.IsKeyClick( Keys.Escape )) )
                    {
                        if ( item.GetGlobalItem<ItemRune>( ).AtCheckRune )
                        {
                            for ( int count = 0; count < 6; count++ )
                            {
                                item.GetGlobalItem<ItemRune>( ).Runes[count] = Modular.RuneInterface.WeaponRune.Slot[ count ].Item.Clone( );
                            }
                            item.GetGlobalItem<ItemRune>( ).AtCheckRune = false;
                            Modular.RuneInteracting = false;
                        }
                        ChangeAnimation.PlayChangeAnimation( );
                    }
                }
            }

            if ( item != null && item.type != ItemID.None )
            {
                for ( int count = 0; count < 6; count++ )
                {
                    if ( item.GetGlobalItem<ItemRune>( ).Runes[count].type != ItemID.None )
                        item.GetGlobalItem<ItemRune>( ).Runes[ count ].ModItem.UpdateInventory( player );
                }
            }
            base.UpdateInventory( item , player );
        }
    }
}
