using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSoul
    {
        public Vector2 Target;

        public Item Item;

        public Vector2 Pos;

        public Vector2 Vel;

        public float Rot = 0f;

        public RefineSoul( Vector2 pos , Item item )
        {
            Pos = pos;
            Vel = Vector2.Zero;
            Target = pos;
            Item = item;
        }

        public void Update( )
        {
            Vel = ( Target - Pos ) * 0.09f;
            Pos += Vel;
            Rot = Vel.ToRotation( );
        }
        public void DrawItem( Texture2D image , Vector2 pos , Rectangle rec )
        {
            Main.spriteBatch.Draw( image , pos , new Rectangle?( rec ) , Color.White , 0f , Vector2.Zero , 1f , 0 , 0f );
        }
    }
}
