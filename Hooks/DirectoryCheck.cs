using System.IO;
using Terraria;

namespace EternalResolve.Hooks
{
    public class DirectoryCheck
    {
        public static void LoadData( )
        {
            CheckDirectory( Main.WorldPath + "/SubWorlds" );
        }
        public static void CheckDirectory( string text )
        {
            if ( !Directory.Exists( text ) )
                Directory.CreateDirectory( text );
        }
    }
}
