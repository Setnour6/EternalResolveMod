using EternalResolve.Assets.Textures.ManaBars;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.UI.Events;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;

namespace EternalResolve.Common.Contents.Modulars.ManaModular
{
    public class ManaBar : Control
    {
        bool _isHover = false;
        public override void Initialization( )
        {
            SetSize( 98 , 30 );
            DropPermit = true;
            base.Initialization( );
        }
        public override void Hover( UIMouseEvent mouseEvent , Control element )
        {
            _isHover = true;
            base.Hover( mouseEvent , element );
        }
        public override void PreUpdate( )
        {
            _isHover = false;
            base.PreUpdate( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( ManaBarAssets.Bar1 , Position , Color );
            spriteBatch.Draw( ManaBarAssets.Bar0 , Position , new Rectangle( 0 , 0 ,
                ( ( (float) Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue /
                (float) Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaMax )
                * 98 ).ToInt( )
                , 30 ) , Color );

            Vector2 fontSize = FontAssets.MouseText.Value.MeasureString(
              Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue
                    + " / " + Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaMax
                );
            if ( _isHover )
                Utils.DrawBorderStringFourWay( Main.spriteBatch , FontAssets.MouseText.Value ,
                    Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue
                    + " / " + Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaMax , Position.X + Width / 2 - fontSize.X / 2 , Position.Y + 44 , Color.White , Color.Purple , Vector2.Zero );
            base.Draw( spriteBatch );
        }
    }
}
