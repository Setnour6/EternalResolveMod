using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular.UI.Chats
{
    public class EkandaChat : Control
    {
        public string Text = "";

        public EkandaChat( string text )
        {
            int height = 0;
            string[ ] data = Text.Split( "\n" );
            if ( data.Length > 0 )
                height = data.Length * FontAssets.MouseText.Value.MeasureString( "口" ).Y.ToInt( );
            else
                height = FontAssets.MouseText.Value.MeasureString( text ).Y.ToInt( );
            Text = text;
            SetSize( FontAssets.MouseText.Value.MeasureString( Text ).X.ToInt( ) , height );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.End( );
            spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.Additive , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null );
            spriteBatch.DrawString( FontAssets.MouseText.Value , Text , Position , Color );
            spriteBatch.End( );
            spriteBatch.Begin( );
            base.Draw( spriteBatch );
        }
    }
}
