using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular
{
    public class SpacingLine : Line
    {
        public override int X { get; set; } = 0;

        public override int Y { get; set; } = 0;

        public override int Width { get; set; } = 0;

        public override int Height { get; set; } = 0;

        public Texture2D Image { get; private set; } = ModContent.Request<Texture2D>( "EternalResolve/Assets/Textures/Line-0" ).Value;

        public int Spacing { get; private set; } = 6;

        public Color Color { get; private set; } = Color.White;

        public override void Draw( )
        {
            if ( !ModContent.GetInstance<ClientSideConfig>( ).mouseDrawItemTooltip )
                Image = ModContent.Request<Texture2D>( "EternalResolve/Assets/Textures/Line-1" ).Value;
            Main.spriteBatch.Draw( Image , new Rectangle( X , Y - 8 , Width , 2 ) , Color );
        }

        public SpacingLine Clone( )
        {
            SpacingLine spacingLine = new SpacingLine( );
            spacingLine.X = X;
            spacingLine.Y = Y;
            spacingLine.Width = Width;
            spacingLine.Height = Height;
            return spacingLine;
        }
    }
}
