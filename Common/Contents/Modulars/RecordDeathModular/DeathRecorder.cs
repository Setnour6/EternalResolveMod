/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.RecordDeathModular
{
    public class DeathRecorder_Player : ModPlayer
    {
        static RenderTarget2D renderTarget2D;
        public override void UpdateEquips( )
        {
            if ( Player.active )
            {
                renderTarget2D = Main.screenTarget;
                renderTarget2D = new RenderTarget2D( Main.instance.GraphicsDevice , 512 , 512 );
                DeathRecorder.Record.Add( renderTarget2D );
            }
            base.UpdateEquips( );
        }
        public override void Kill( double damage , int hitDirection , bool pvp , PlayerDeathReason damageSource )
        {
            if ( !Directory.Exists( "PNGSS" ) )
            {
                Directory.CreateDirectory( "PNGSS" );
            }

            StreamWriter streamWriter;
            for ( int count = 0; count < DeathRecorder.Record.Count; count++ )
            {
                streamWriter = new StreamWriter( "PNGSS/P" + count + ".png" );
                DeathRecorder.Record[ count ].SaveAsPng( streamWriter.BaseStream , DeathRecorder.Record[ count ].Width , DeathRecorder.Record[ count ].Height );
            }
            base.Kill( damage , hitDirection , pvp , damageSource );
        }
    }
    public class DeathRecorder : ModSystem
    {
        public static List<RenderTarget2D> Record = new List<RenderTarget2D>();

        public override void UpdateUI( GameTime gameTime )
        {
            if ( Record.Count > 5 )
            {
                Record[ 0 ].Dispose( );
                Record.RemoveAt( 0 );
            }

            base.UpdateUI( gameTime );
        }
    }
}*/