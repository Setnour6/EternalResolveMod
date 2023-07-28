using EternalResolve.Common.Contents.Entities.Items.Tools.Picks;
using EternalResolve.Common.Contents.Entities.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace EternalResolve.Common.Plots
{
    public class Plot_0_Player : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public bool IsDown = false;

        bool _started = false;
        public override void PreUpdate( )
        {
            if ( IsDown )
            {
                Player.bodyFrame.Y = 0;
                Player.bodyFrameCounter = 0;
                Player.direction = 1;
                Player.velocity = Vector2.Zero;
                Player.mouseInterface = true;
                Player.delayUseItem = true;
                Player.controlDown = false;
                Player.controlHook = false;
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
            }
            base.PreUpdate( );
        }

        public override void PostUpdate( )
        {
            if( IsDown && !_started )
            {
                _started = true;
                Main.LocalPlayer.Bottom = new Vector2( Main.LocalPlayer.position.X , Main.LocalPlayer.position.Y + 86 );
                Main.LocalPlayer.fullRotation = MathF.PI / 2f * (float) ( -Main.LocalPlayer.direction );
            }
            else if( !IsDown )
            {
                Main.LocalPlayer.fullRotation = 0;
            }
            if ( IsDown )
            {
                Player.position.X = Main.spawnTileX * 16;
                Player.position.Y = (Main.spawnTileY + 2) * 16;
                Player.legFrame.Y = 0;
                Player.bodyFrame.Y = 0;
                Player.bodyFrameCounter = 0;
                Player.direction = 1;
                Player.velocity = Vector2.Zero;
                Player.mouseInterface = true;
                Player.delayUseItem = true;
                Player.controlDown = false;
                Player.controlHook = false;
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
                if ( Player.controlJump )
                {
                    IsDown = false;
                    Player.position.X = Main.spawnTileX * 16;
                    Player.position.Y = ( Main.spawnTileY - 4 ) * 16;
                }
            }
            base.PostUpdate( );
        }

        public override void OnEnterWorld( Player player )
        {
            if( !Plot_0.PLOT_0_0 )
            {
                player.GetModPlayer<Plot_0_Player>( ).IsDown = true;
                for ( int count = 0; count < player.inventory.Length ; count++ )
                {
                    player.inventory[ count ].SetDefaults( 0 );
                }
                Plot_0.PLOT_0_0 = true;
            }
            base.OnEnterWorld( player );
        }
    }

    public class Plot_0_World : GenPass
    {
        public Plot_0_World( ) : base( "EternalResolve:CreatePlot0" , 1 )
        {
        }

        protected override void ApplyPass( GenerationProgress progress , GameConfiguration configuration )
        {
            progress.Message = "正在建造 你苏醒时的平地...";
            for ( int x = 0; x < 34; x++ )
            {
                for ( int y = 0; y < 42; y++ )
                {
                    WorldGen.KillTile( Main.spawnTileX - 17 + x , Main.spawnTileY + 1 - y , false , false , true );
                    WorldGen.KillWall( Main.spawnTileX - 17 + x , Main.spawnTileY + 1 - y , true );
                }
            }
            for ( int x = 0; x < 32; x++ )
            {
                for ( int y = 0; y < 32; y++ )
                {
                    WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY + 1 , 0 , true , true );
                    if ( !( x < 7 || x > 25 ) || x == 31 )
                    {
                        WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY + 1 , 2 , true , true );
                    }
                    switch ( y )
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                            if ( x > 6 && x < 26 )
                                WorldGen.PlaceWall( Main.spawnTileX - 16 + x , Main.spawnTileY - y , WallID.Dirt , true );
                            if ( x < 8 || x > 24 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 0 , true , true );
                            if ( x == 0 || x == 31 || x == 7 || x == 25 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 2 , true , true );
                            break;
                        case 7:
                        case 8:
                        case 9:
                            if ( x > 9 && x < 23 )
                                WorldGen.PlaceWall( Main.spawnTileX - 16 + x , Main.spawnTileY - y , WallID.Dirt , true );
                            if ( x > 1 && x < 11 || x > 21 && x < 30 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 0 , true , true );
                            if ( x == 0 || x == 10 || x == 20 || x == 31 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 2 , true , true );
                            break;
                        case 10:
                            if ( x > 7 && x < 24 )
                                WorldGen.PlaceWall( Main.spawnTileX - 16 + x , Main.spawnTileY - y , WallID.Dirt , true );
                            if ( x > 4 && x < 12 || x > 19 && x < 28 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 0 , true , true );
                            break;
                        case 11:
                            if ( x > 6 && x < 26 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 0 , true , true );
                            if ( x > 6 && x < 26 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 2 , true , true );
                            break;
                        case 12:
                            if ( x > 7 && x < 24 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 0 , true , true );
                            if ( x > 7 && x < 24 )
                                WorldGen.PlaceTile( Main.spawnTileX - 16 + x , Main.spawnTileY - y , 2 , true , true );
                            break;
                    };
                }
            }
            WorldGen.PlaceTile( Main.spawnTileX - 4 , Main.spawnTileY - 5 , TileID.Torches , true , true );
            WorldGen.PlaceTile( Main.spawnTileX , Main.spawnTileY , ModContent.TileType<BrokenPick_Tile>( ) , true , true );
            WorldGen.PlaceTile( Main.spawnTileX - 4 , Main.spawnTileY , ModContent.TileType<Corpse_Tile>( ) , true , true );
            Main.dayTime = false;
        }
    }

    public class Plot_0 : ModSystem
    {
        public static bool PLOT_0_0 = false;

        public override void PreUpdateEntities( )
        {
            if ( Main.LocalPlayer.GetModPlayer<Plot_0_Player>( ).IsDown )
            {
                Main.LocalPlayer.controlLeft = false;
                Main.LocalPlayer.controlRight = false;
            }
            base.PreUpdateEntities( );
        }

        public override void PostUpdateEverything( )
        {
            if( Main.LocalPlayer.GetModPlayer<Plot_0_Player>().IsDown )
            {
                Main.LocalPlayer.controlLeft = false;
                Main.LocalPlayer.controlRight = false;
            }
            base.PostUpdateEverything( );
        }

        public override void LoadWorldData( TagCompound tag )
        {
            PLOT_0_0 = tag.GetBool( "PLOT_0_0" );

            base.LoadWorldData( tag );
        }

        public override void SaveWorldData( TagCompound tag )
        {
            tag.Add( "PLOT_0_0" , PLOT_0_0 );

            base.SaveWorldData( tag );
        }

        public override void ModifyWorldGenTasks( List<GenPass> tasks , ref float totalWeight )
        {
            tasks.Add( new Plot_0_World( ) );
            base.ModifyWorldGenTasks( tasks , ref totalWeight );
        }
    }


}