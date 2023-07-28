using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items;
using EternalResolve.Common.Contents.Entities.Items.Runes;
using EternalResolve.Common.Contents.Entities.Items.Runes.Normal;
using EternalResolve.Common.Contents.Entities.Items.Tools.Picks;
using EternalResolve.Common.Contents.Entities.Tiles.Bricks.GuJi;
using EternalResolve.Common.Contents.Modulars;
using EternalResolve.Common.Contents.Modulars.CleanBeadStoneModular;
using EternalResolve.Common.Contents.Modulars.EkandaModular;
using EternalResolve.Common.Contents.Modulars.RuneModular;
using EternalResolve.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using ReLogic.Content;
using System;
using System.Threading;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Commands
{
    public class Debug : ModCommand
    {
        public override CommandType Type
            => CommandType.Chat;

        public override string Command
            => "Debug";

        public override string Usage
            => "/Debug <code>";

        public override string Description
            => "开发人员使用";


        bool _test = true;
        public override void Action( CommandCaller caller , string input , string[ ] args )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                if ( input.Contains( "DEBUG_ANTICHEATING_CHANGE" ) )
                {
                    AntiCheatingSystem.Enable = !AntiCheatingSystem.Enable;
                    DebugMode.Debug = !DebugMode.Debug;
                    Main.NewText( "AniCheating Enable: " + AntiCheatingSystem.Enable.ToString( ) );
                }
                else if ( input.Contains( "DEBUG_TIME_CHANGE" ) )
                {
                    Main.dayTime = !Main.dayTime;
                    Main.time = 60;
                    Main.NewText( "Time is change." );
                }
                else if ( input.Contains( "T" ) )
                {
                    SubWorld_Ekanda.EnterEkandaWorld( );
                }
                else if ( input.Contains( "C" ) && _test )
                {
                    SubWorld_Ekanda.ExitWorld( );
                }
                else if ( input.Contains( "R" ) && _test )
                {
                    Main.NewText( Ekanda._questNum );
                }
            }
        }
    }
}