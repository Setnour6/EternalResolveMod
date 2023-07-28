using EternalResolve.Common.Contents.Entities.Items.Runes;
using EternalResolve.Common.Contents.Modulars;
using System.IO;
using System.Text;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.IO
{
    public class RuneIO
    {
        public static void SaveData( Player player )
        {
            if ( Main.ActivePlayerFileData.Path != null )
            {
                string filename = "";
                StringBuilder path = new StringBuilder( Main.ActivePlayerFileData.Path );
                path.Remove( Main.ActivePlayerFileData.Path.IndexOf( ".plr" ) , 4 );
                filename = path.ToString( ) + ".trd";
                FileStream fileStream = new FileStream( filename , FileMode.Create );
                BinaryWriter bw = new BinaryWriter( fileStream );
                for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
                {
                    for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                    {
                        if ( Modular.RuneInterface.Inventory.Slot[ x , y ].Item.ModItem != null &&
                           Modular.RuneInterface.Inventory.Slot[ x , y ].Item.type != ItemID.None )
                        {
                            string index = Modular.RuneInterface.Inventory.Slot[ x , y ].Item.ModItem.Name;
                            bw.Write( index );
                            int runeOfLevel = (int) Modular.RuneInterface.Inventory.Slot[ x , y ].Item.
                                GetGlobalItem<RuneItem>( ).RuneType;
                            bw.Write( runeOfLevel );
                        }
                        else
                            bw.Write( "None" );
                    }
                }
                bw.Close( );
                fileStream.Close( );
            }
        }
        public static void LoadData( Player player )
        {
            string filename = "";
            StringBuilder path = new StringBuilder( Main.ActivePlayerFileData.Path );
            path.Remove( Main.ActivePlayerFileData.Path.IndexOf( ".plr" ) , 4 );
            filename = path.ToString( ) + ".trd";
            if ( !File.Exists( filename ) )
            {
                for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
                {
                    for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                    {
                        Modular.RuneInterface.Inventory.Slot[ x , y ].Item.SetDefaults( 0 );
                    }
                }
            }
            else
            {
                FileStream fileStream = new FileStream( filename , FileMode.Open );
                BinaryReader bw = new BinaryReader( fileStream );
                ModItem value;
                for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
                {
                    for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                    {
                        Modular.RuneInterface.Inventory.Slot[ x , y ].Item.SetDefaults( 0 );
                    }
                }
                for ( int x = 0; x < Modular.RuneInterface.Inventory.Slot.GetLength( 0 ); x++ )
                {
                    for ( int y = 0; y < Modular.RuneInterface.Inventory.Slot.GetLength( 1 ); y++ )
                    {
                        if ( ModContent.TryFind( "EternalResolve" , bw.ReadString( ) , out value ) )
                        {
                            Modular.RuneInterface.Inventory.Slot[ x , y ].Item.SetDefaults( value.Type );
                            Modular.RuneInterface.Inventory.Slot[ x , y ].Item.GetGlobalItem<RuneItem>( ).RuneType = (RuneType) bw.ReadInt32( );
                        }
                        else
                        {
                            Modular.RuneInterface.Inventory.Slot[ x , y ].Item.SetDefaults( 0 );
                        }
                    }
                }
                bw.Close( );
                fileStream.Close( );
            }
        }
    }
}