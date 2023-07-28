using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.SubWorlds
{
    public class SubWorldSystem : ModSystem
    {
        public override void Load( )
        {
            Main.OnPostDraw += Main_OnPostDraw;
            base.Load( );
        }

        private void Main_OnPostDraw( GameTime obj )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                if ( SubWorld.Loading )
                {
                    Main.spriteBatch.Begin( );
                    Main.graphics.GraphicsDevice.Clear( Color.Gray );
                    Main.spriteBatch.DrawString( FontAssets.DeathText.Value , "Loading" , FrontDevice.Form.ScreenCenter -
                        FontAssets.DeathText.Value.MeasureString( "Loading" ) / 2 , Color.White );
                    Main.spriteBatch.End( );
                }
            }
        }

        public override void Unload( )
        {
            Main.OnPostDraw -= Main_OnPostDraw;
            base.Unload( );
        }
    }

    /// <summary>
    /// 子世界.
    /// </summary>
    public class SubWorld
    {
        /// <summary>
        /// 指示现在是否有世界正在加载.
        /// </summary>
        public static bool Loading { get; internal set; } = false;

        public static bool InSubWorld { get; internal set; } = false;

        public string Name { get; internal set; } = "";

        string _mainWorldPath;

        public virtual void Init( )
        {

        }

        public virtual void Play( )
        {
            Loading = true;
            InSubWorld = true;
            Save( );
            _mainWorldPath = Main.worldPathName;
            Main.ActiveWorldFileData = new WorldFileData( Main.WorldPath + "/SubWorlds/" + Name + "_sub.wld" , false );
            WorldGen.playWorld( );
        }

        public virtual void CreateWorld( )
        {

        }

        public void Save( )
        {
            WorldFile.SaveWorld( );
        }

        public virtual void Exit( )
        {
            Loading = true;
            InSubWorld = false;
            Save( );
            Player.SavePlayer( Main.ActivePlayerFileData , false );
            Main.ActiveWorldFileData = new WorldFileData( _mainWorldPath , false );
            WorldGen.saveAndPlay( );
            WorldGen.playWorld( );
        }
    }
}