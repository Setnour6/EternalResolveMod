using EternalResolve.Assets.Textures.Systems.RefineSystems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineDust
    {
        public static List<RefineDust> dusts = new List<RefineDust>( );

        public Vector2 Pos;

        public Vector2 Vel;

        public float Rot = 0;

        public float Scale = 1f;

        public Color Color;

        public static void NewDust( Vector2 pos , Vector2 vel , float rot , float scale , Color color )
        {
            RefineDust dust = new RefineDust( )
            {
                Pos = pos ,
                Vel = vel ,
                Rot = rot ,
                Scale = scale ,
                Color = color
            };
            dusts.Add( dust );
        }

        public void Update( )
        {
            Pos += Vel;
            Rot += 0.4f;
            Scale -= 0.04f;
            if ( Scale < 0.02f )
                dusts.Remove( this );
            Vel *= 0.98f;
        }
        public void Draw( )
        {
            Main.spriteBatch.Draw( RefineAssets.Dust , Pos , null , Color , Rot , Vector2.One * 4 , Scale , SpriteEffects.None , 1f );
        }
    }
}
