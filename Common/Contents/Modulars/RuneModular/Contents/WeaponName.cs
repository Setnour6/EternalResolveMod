using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameContent;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Contents
{
    public class WeaponName : Control
    {
        public string Text { get; set; } = "";

        public override void Draw( SpriteBatch spriteBatch )
        {
            DynamicSpriteFontExtensionMethods.DrawString( spriteBatch , FontAssets.DeathText.Value , this.Text , base.Position , base.Color );
            base.Draw( spriteBatch );
        }
    }
}
