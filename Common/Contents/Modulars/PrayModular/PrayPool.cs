using EternalResolve.Common.Codes.Utils;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.PrayModular
{
    public class PrayItem
    {
        public int ID = 0;
        public int Stack = 0;
        public int Check = 0;
        public PrayItem( int id , int stack , int check )
        {
            ID = id;
            Stack = stack;
            Check = check;
        }
    }
    public class PrayPool : ModSystem
    {
        public static PrayItem GetPrayItem( int type )
        {
            for ( int count = 0; count < Pool[ type ].Count; count++ )
            {
                if ( count < Pool[ type ].Count - 1 )
                {
                    if ( Main.rand.Next( 1000 ) < Pool[ type ][ count ].Check )
                    {
                        return Pool[ type ][ count ];
                    }
                }
                else if ( count == Pool[ type ].Count - 1 )
                {
                    return Pool[ type ][ count ];
                }
            }
            return null;
        }
        public static List<List<PrayItem>> Pool = new List<List<PrayItem>>( )
        {
            new List<PrayItem>()
            {
            },//世界池子
            new List<PrayItem>()
            {
            } ,//定制池子
            new List<PrayItem>()
            {
            }//常驻池子
        };

        public override void PostSetupContent( )
        {
            Item item = new Item( );
            for ( int count = 0; count < Main.maxItemTypes - 1; count++ )
            {
                item.SetDefaults( count );
                Pool[ 0 ].Add( new PrayItem( count , 1 , 1 + 72 - item.rare * 9 ) );
            }
            for ( int count = 0; count < ItemLoader.ItemCount - 1; count++ )
            {
                item.SetDefaults( count );
                if ( item.Clone( ).IsWeapon( ) )
                {
                    Pool[ 1 ].Add( new PrayItem( count , 1 , 1 + 72 - item.rare * 9 ) );
                }
            }
            for ( int count = 0; count < ItemLoader.ItemCount - 1; count++ )
            {
                item.SetDefaults( count );
                Pool[ 2 ].Add( new PrayItem( count , 1 , 1 + 72 - item.rare * 9 ) );
            }
            Pool[ 0 ].Add( new PrayItem( ItemID.Seaweed , 1 , 1000 ) );
            Pool[ 1 ].Add( new PrayItem( ItemID.OldShoe , 1 , 1000 ) );
            Pool[ 2 ].Add( new PrayItem( ItemID.WoodenSword , 1 , 1000 ) );

            base.PostSetupContent( );
        }
    }
}