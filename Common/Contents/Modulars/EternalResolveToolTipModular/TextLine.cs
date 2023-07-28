using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using ReLogic.Graphics;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular
{
    public class TextLine : Line
    {
        public override int X { get; set; } = 0;

        public override int Y { get; set; } = 0;

        public override int Width
        {
            get
            {
                string[ ] data = Text.Split( "\n" );
                int[ ] widths = new int[ data.Length ];
                if ( data.Length > 0 )
                {
                    for ( int count = 0; count < data.Length; count++ )
                    {
                        widths[ count ] = Font.MeasureString( Text.Split( "\n" )[ count ] ).X.ToInt( );
                    }
                    return widths.Max( );
                }
                return Font.MeasureString( Text ).X.ToInt( );
            }
        }

        public override int Height
        {
            get
            {
                string[ ] data = Text.Split( "\n" );
                if ( data.Length > 0 )
                    return data.Length * Font.MeasureString( "口" ).Y.ToInt( );
                return Font.Size( ).Y.ToInt( );
            }
        }

        public int Spacing { get; private set; } = 6;

        public string Text { get; set; } = "";

        public Color Color { get; set; } = Color.Black;

        public DynamicSpriteFont Font { get; private set; }

        public TextLine( string text , Color color )
        {
            Text = text;
            Color = color;
            Font = FontAssets.MouseText.Value;
        }

        public override void Draw( )
        {
            if ( Text.Contains( "\n" ) )
            {
                for ( int count = 0; count < Text.Split( "\n" ).Length; count++ )
                {
                    if ( !ModContent.GetInstance<ClientSideConfig>( ).mouseDrawItemTooltip )
                        Utils.DrawBorderStringFourWay( Main.spriteBatch , FontAssets.MouseText.Value ,
                           Text.Split( "\n" )[ count ] , X , Y + Font.Size( ).Y.ToInt( ) * count , Color , Color.Black , Vector2.Zero );
                    else
                        Main.spriteBatch.DrawString( Font , Text.Split( "\n" )[ count ] , new Vector2( X , Y + Font.Size( ).Y.ToInt( ) * count ) , Color );
                }
            }
            else if ( !ModContent.GetInstance<ClientSideConfig>( ).mouseDrawItemTooltip )
                Utils.DrawBorderStringFourWay( Main.spriteBatch , FontAssets.MouseText.Value ,
                   Text , X , Y , Color , Color.Black , Vector2.Zero );
            else
                Main.spriteBatch.DrawString( Font , Text , new Vector2( X , Y ) , Color );
        }
    }
}
