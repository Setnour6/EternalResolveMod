using EternalResolve.Assets.Textures.StarTeleportPlatforms;
using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Tiles.Bricks.GuJi;
using EternalResolve.Common.Contents.Modulars.EkandaModular;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;

namespace EternalResolve.Common.Contents.Modulars.StarTeleprotPlatformModular
{
    public class StarTeleprotPlatform : ModSystem
    {
        int frame = 0;

        int timer = 0;

        public override void Load( )
        {
            On.Terraria.Main.DrawTiles += Main_DrawTiles;
            base.Load( );
        }

        private void Main_DrawTiles( On.Terraria.Main.orig_DrawTiles orig , Main self , bool solidLayer , bool forRenderTargets , bool intoRenderTargets , int waterStyleOverride )
        {
            Point16 pos = new Point16( Main.maxTilesX - 200 , 200 );

            if ( Vector2.Distance( Main.LocalPlayer.Center , pos.ToVector2( ) * 16 + new Vector2( 200 , 704 ) ) < 500 )
            {
                timer++;
                if ( timer % 2 == 0 && frame < 14 )
                    frame++;
            }
            else if( frame > 0 )
            {
                timer--;
                if ( timer % 2 == 0 )
                    frame--;
            }

            for ( int count = StarTeleprotPlatformAssets.StarTeleportPlatFormParts.Length - 1; count >= 0; count-- )
            {
                Main.spriteBatch.Draw( StarTeleprotPlatformAssets.StarTeleportPlatFormParts[ count ] , pos.ToVector2( ) * 16 - Main.screenPosition + new Vector2( 0 , -4 ) , Color.White );
            }
            Main.spriteBatch.Draw( StarTeleprotPlatformAssets.TeleprotPlatform,
                pos.ToVector2( ) * 16 - Main.screenPosition + new Vector2( 331 , 704 ) ,
                new Rectangle( 0 , 96 * frame , 80 , 96 )
                , Color.White );

            orig.Invoke( self , solidLayer , forRenderTargets , intoRenderTargets , waterStyleOverride );
        }

        public override void UpdateUI( GameTime gameTime )
        {
            Point16 pos = new Point16( Main.maxTilesX - 200 , 200 );

            Point p = (pos.ToVector2( ) * 16 - Main.screenPosition + new Vector2( 331 , 704 )).ToPoint();
            if ( FrontDevice.Input.MouseRightClick )
            {
                if( frame == 14 && new Rectangle( p .X - 192 , p.Y - 192, 80 , 96 ).IntersectMouse( ) )
                {
                    SubWorld_Ekanda.EnterEkandaWorld( );
                }
            }
            base.UpdateUI( gameTime );
        }

        public override void Unload( )
        {
            On.Terraria.Main.DrawTiles -= Main_DrawTiles;
            base.Unload( );
        }

        public override void ModifyWorldGenTasks( List<GenPass> tasks , ref float totalWeight )
        {
            tasks.Add( new StarTeleprotPlatformCreate( ) );

            base.ModifyWorldGenTasks( tasks , ref totalWeight );
        }
    }

    public class StarTeleprotPlatformCreate : GenPass
    {
        public StarTeleprotPlatformCreate( ) : base( "EternalResolve:StarTeleprotPlatformCreate" , 1 )
        {
        }

        protected override void ApplyPass( GenerationProgress progress , GameConfiguration configuration )
        {
            Point16 pos = new Point16( Main.maxTilesX - 200 , Main.maxTilesY - 950 );
            progress.Message = "正在建造 星门";
            for ( int x = pos.X - 300; x < pos.X + 160; x++ )
            {
                for ( int y = 0; y < Main.maxTilesY; y++ )
                {
                    WorldGen.KillTile( x , y , false , false , true );
                }
            }
            for ( int x = pos.X - 300; x < pos.X + 160; x++ )
            {
                for ( int y = 238; y < Main.maxTilesY; y++ )
                {
                    WorldGen.PlaceTile( x , y , ModContent.TileType<GuJiBrick2_Tile>( ) , true );
                }
            }
        }
    }
    

}