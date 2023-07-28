using EternalResolve.Common.Contents.Modulars;
using EternalResolve.Common.Contents.Modulars.ModifyModular.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items
{
    public class ERItemManager
    {
        public static void CreateAuthenticationItem( Vector2 position , int type )
        {
            DropItemInstanced2( position , type );
        }
        public static void CreateItem( Vector2 position , int type )
        {
            DropItemInstanced( position , type );
        }
        public static void CreateItem( Vector2 position , int type , int stack = 1 )
        {
            DropItemInstanced( position , type , stack );
        }

        public static void DropItemInstanced( Vector2 Position , int itemType , int itemStack = 1 )
        {
            if ( Main.netMode == NetmodeID.MultiplayerClient || Main.netMode == NetmodeID.Server )
            {
                int num = Item.NewItem(null, Position , itemType , itemStack , noBroadcast: false );
                Main.timeItemSlotCannotBeReusedFor[ num ] = 0;
                for ( int i = 0; i < 255; i++ )
                {
                    if ( Main.player[ i ].active )
                    {
                        NetMessage.SendData( MessageID.InstancedItem , i , -1 , null , num );
                    }
                }
            }
            else if ( Main.netMode == NetmodeID.SinglePlayer )
            {
                int num = Item.NewItem(null, Position , itemType , itemStack , noBroadcast: false );
                Main.item[ num ].GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                Main.item[ num ].CreateUUID( );
            }
        }

        public static void DropItemInstanced2( Vector2 Position , int itemType , int itemStack = 1 )
        {
            if ( Main.netMode == NetmodeID.MultiplayerClient || Main.netMode == NetmodeID.Server )
            {
                int num = Item.NewItem(null, Position , itemType , itemStack , noBroadcast: false );
                Main.timeItemSlotCannotBeReusedFor[ num ] = 0;
                for ( int i = 0; i < 255; i++ )
                {
                    if ( Main.player[ i ].active )
                    {
                        NetMessage.SendData( MessageID.InstancedItem , i , -1 , null , num );
                    }
                }
            }
            else if ( Main.netMode == NetmodeID.SinglePlayer )
            {
                int num = Item.NewItem(null, Position , itemType , itemStack , noBroadcast: false );
                Main.item[ num ].GetGlobalItem<Modify_Authentication>( ).Authentication = true;
                Main.item[ num ].GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                Main.item[ num ].CreateUUID( );
            }
        }
    }
}
