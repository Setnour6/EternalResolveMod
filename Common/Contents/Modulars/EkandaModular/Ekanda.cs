using System.Collections.Generic;
using System.Windows.Forms;
using EternalResolve.Assets.Textures.Ekanda;
using EternalResolve.Common.Contents.Entities.Tiles.EkandaBricks;
using EternalResolve.Common.Contents.Modulars.EkandaModular.UI;
using EternalResolve.Common.Contents.Modulars.SubWorlds;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular
{
    public class EkandaClean : GlobalNPC
    {
        public override void EditSpawnRate( Player player , ref int spawnRate , ref int maxSpawns )
        {
            if ( SubWorld_Ekanda.InEkandaWorld )
            {
                spawnRate = 0;
                maxSpawns *= 0;
            }
            else
            {
                spawnRate /= 1;
                maxSpawns *= 1;
            }
            base.EditSpawnRate( player , ref spawnRate , ref maxSpawns );
        }
    }

    public class Ekanda : ModSystem
    {
        public Vector2 ScreenTarget = Vector2.Zero;

        Vector2 _screenVelocity = Vector2.Zero;

        public Vector2 ScreenPosition = Vector2.Zero;

        int _screenTimer = 6;
        public override void ModifyScreenPosition( )
        {
            if ( SubWorld_Ekanda.InEkandaWorld && Main.LocalPlayer.getRect( ).Intersects( new Rectangle( 34044 , 3274 , 300 , 400 ) ) )
            {
                if ( ScreenPosition == Vector2.Zero )
                    ScreenPosition = Main.screenPosition;
                if ( _screenTimer > 0 )
                    _screenTimer--;
                if ( _screenTimer == 0 )
                {
                    ScreenTarget = new Vector2( 34218  , 3024 ) - (Main.ScreenSize ).ToVector2() / 2;
                    Vector2 targetPos = ScreenTarget;
                    _screenVelocity = ( targetPos - ScreenPosition ) * 0.16f;
                    ScreenPosition += _screenVelocity;
                    Main.screenPosition = ScreenPosition;
                    Modular.EkandaInteracting = true;
                }
            }
            else if ( SubWorld_Ekanda.InEkandaWorld )
            {
                if ( ScreenPosition == Vector2.Zero )
                    ScreenPosition = Main.screenPosition;
                if ( _screenTimer > 0 )
                    _screenTimer--;
                if ( _screenTimer == 0 )
                {
                    Vector2 targetPos = Main.LocalPlayer.position - FrontDevice.Form.ScreenCenter;
                    _screenVelocity = ( targetPos - ScreenPosition ) * 0.26f;
                    ScreenPosition += _screenVelocity;
                    Main.screenPosition = ScreenPosition;
                }
            }
            else
            {
                _screenTimer = 6;
            }
            base.ModifyScreenPosition( );
        }

        public static int _questNum = 0;

        public static Quest EkandaQuest = new Quest( );

        public override void LoadWorldData( TagCompound tag )
        {
            if ( !SubWorld.Loading )
            {
                _questNum = tag.GetInt( "_questNum" );
            }
            EkandaQuest = Quest.Quests[ _questNum ];
            EkandaQuest.Init( );
            base.LoadWorldData( tag );
        }

        public override void SaveWorldData( TagCompound tag )
        {
            if ( !SubWorld.Loading )
            {
                tag.Add( "_questNum" , _questNum );
            }
            else
            {
                SubWorld_Ekanda.InEkandaWorld = false;
                SubWorld.InSubWorld = false;
            }
        }

        public override void Load( )
        {
            On.Terraria.Main.DrawRain += Main_DrawRain;
            On.Terraria.Main.DrawTiles += Main_DrawTiles;
            base.Load( );
        }

        private void Main_DrawRain( On.Terraria.Main.orig_DrawRain orig , Main self )
        {
            orig.Invoke( self );
            if ( SubWorld_Ekanda.InEkandaWorld )
            {
                for ( int count = 7; count < 9; count++ )
                {
                    Main.spriteBatch.Draw( EkandaAssets.BG[ count ] ,
                        new Vector2( Main.spawnTileX * 16 ,  Main.spawnTileY * 16 ) - Main.screenPosition
                        -  new Vector2( 392 , 1292 ),
                        Color.White );
                }
            }
        }

        private void Main_DrawTiles( On.Terraria.Main.orig_DrawTiles orig , Main self , bool solidLayer , bool forRenderTargets , bool intoRenderTargets , int waterStyleOverride )
        {
            orig.Invoke( self , solidLayer , forRenderTargets , intoRenderTargets , waterStyleOverride );
            if ( SubWorld_Ekanda.InEkandaWorld )
            {
                for ( int count = 0; count < 7; count++ )
                {
                    Main.spriteBatch.Draw( EkandaAssets.BG[ count ] ,
                          new Point16( Main.spawnTileX , Main.spawnTileY ).ToVector2( ) * 16 - Main.screenPosition
                           -new Vector2( 200 , 1100 ) , Color.White );
                }
            }
        }

        public override void Unload( )
        {
            On.Terraria.Main.DrawRain -= Main_DrawRain;
            On.Terraria.Main.DrawTiles -= Main_DrawTiles;
            base.Unload( );
        }

    }

    public class EkandaPlayer : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public override bool CanUseItem( Item item )
        {
            if ( SubWorld_Ekanda.InEkandaWorld )
            {
                if ( item.axe > 0 || item.pick > 0 || item.hammer > 0 || item.fishingPole > 0 || item.createTile > -1 )
                {
                    return false;
                }
            }
            return true;
        }

        public override void PostUpdate( )
        {
            if ( Main.LocalPlayer.getRect( ).Intersects( new Rectangle( 34044 , 3274 , 300 , 400 ) ) )
            {
                Modular.EkandaInteracting = true;
            }
            else
                Modular.EkandaInteracting = false;
            base.PostUpdate( );
        }
    }
}