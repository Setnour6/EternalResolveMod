using EternalResolve.Common.Contents.Modulars.SubWorlds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular
{
    public class SubWorld_Ekanda_Ry : ModSystem
    {
        public override void OnModLoad( )
        {
            byte[ ] world = ModContent.GetFileBytes( "EternalResolve/Assets/Worlds/Ekanda_sub.wld" );
            File.WriteAllBytes( Main.WorldPath + "/SubWorlds/Ekanda_sub.wld" , world );

            byte[ ] worldData2 = ModContent.GetFileBytes( "EternalResolve/Assets/Worlds/Ekanda_sub.twld" );
            File.WriteAllBytes( Main.WorldPath + "/SubWorlds/Ekanda_sub.twld" , worldData2 );

            base.OnModLoad( );
        }
    }
    public class SubWorld_Ekanda : SubWorld
    {
        public static bool InEkandaWorld = false;

        static string _mainWorldPath;

        static int x;

        static int y;

        public static void EnterEkandaWorld( )
        {
            Loading = true;
			x = Main.tile.Width;   // Main.tile.GetLength( 0 ) -> Main.tile.width
			y = Main.tile.Width + 1; // Main.tile.GetLength( 1 ) -> Main.tile.width + 1
			WorldFile.SaveWorld( );
            _mainWorldPath = Main.worldPathName;
            Main.ActiveWorldFileData = new WorldFileData( Main.WorldPath + "/SubWorlds/Ekanda_sub.wld" , false );
            WorldGen.playWorld( );
            InSubWorld = true;
            InEkandaWorld = true;
        }
        public static void ExitWorld( )
        {
            Loading = true;
            WorldFile.SaveWorld( );
            Player.SavePlayer( Main.ActivePlayerFileData , false );
            Main.ActiveWorldFileData = new WorldFileData( _mainWorldPath , false );
            //Main.tile = new Tile[ x , y ]; // commented out until a solution is found
            WorldGen.playWorld( );
            InSubWorld = false;
            InEkandaWorld = false;
        }
    }
}