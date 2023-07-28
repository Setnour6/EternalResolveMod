using EternalResolve.Common.Contents.Modulars.SubWorlds;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars
{
    public class DebugMode : ModSystem
    {
        internal static bool Debug = true;

        public override void PostDrawFullscreenMap( ref string mouseText )
        {
            if ( Debug )
            {
                if ( Main.mouseRight )
                {
                    int mapWidth = Main.maxTilesX * 16;
                    int mapHeight = Main.maxTilesY * 16;
                    Vector2 cursorPosition = new Vector2( (float) Main.mouseX , (float) Main.mouseY );
                    cursorPosition.X -= (float) ( Main.screenWidth / 2 );
                    cursorPosition.Y -= (float) ( Main.screenHeight / 2 );
                    Vector2 cursorWorldPosition = Main.mapFullscreenPos;
                    cursorPosition /= 16f;
                    cursorPosition *= 16f / Main.mapFullscreenScale;
                    cursorWorldPosition += cursorPosition;
                    cursorWorldPosition *= 16f;
                    Player player = Main.player[ Main.myPlayer ];
                    cursorWorldPosition.Y -= (float) player.height;
                    if ( cursorWorldPosition.X < 0f )
                    {
                        cursorWorldPosition.X = 0f;
                    }
                    else if ( cursorWorldPosition.X + (float) player.width > (float) mapWidth )
                    {
                        cursorWorldPosition.X = (float) ( mapWidth - player.width );
                    }
                    if ( cursorWorldPosition.Y < 0f )
                    {
                        cursorWorldPosition.Y = 0f;
                    }
                    else if ( cursorWorldPosition.Y + (float) player.height > (float) mapHeight )
                    {
                        cursorWorldPosition.Y = (float) ( mapHeight - player.height );
                    }
                    if ( Main.netMode == 0 )
                    {
                        player.Teleport( cursorWorldPosition , 1 , 0 );
                        player.position = cursorWorldPosition;
                        player.velocity = Vector2.Zero;
                        player.fallStart = (int) ( player.position.Y / 16f );
                        return;
                    }
                    base.PostDrawFullscreenMap( ref mouseText );
                }
            }
        }
    }
    public class DebugMode_Player : ModPlayer
    {
        public override void OnEnterWorld( Player player )
        {
            if ( Main.netMode == NetmodeID.SinglePlayer )
            {
                SubWorld.Loading = false;
                if ( !Main.worldPathName.Contains( "_sub" ) )
                {
                    SubWorld.InSubWorld = false;
                }
            }

            base.OnEnterWorld( player );
        }
    }
}