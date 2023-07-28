using EternalResolve.Assets.Textures.Runes;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Contents.Entities.Items.Runes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Contents
{
    /// <summary>
    /// 武器信息面板.
    /// </summary>
    public class InformationPanel : Control
    {
        public WeaponSlot Slot = new WeaponSlot( );

        public WeaponName Text = new WeaponName( );

        public CompleteSetText CompleteSetText = new CompleteSetText( );

        public override void Initialization( )
        {
            SetSize( 237 , 305 );
            Text.SubPosition = new Vector2( 134f , 30f );
            Register( Text );
            Slot.SubPosition = new Vector2( 8f , 8f );
            Register( Slot );
            CompleteSetText = new CompleteSetText( );
            CompleteSetText.SubPosition = new Vector2( 20 , 140f );
            Register( CompleteSetText );
            base.Initialization( );
        }

        public override void Update( )
        {
            if ( Slot.Item.type != ItemID.None )
            {
                Text.Text = Slot.Item.Name;
            }
            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( RuneAssets.InformationPanel , Position , Color );
            base.Draw( spriteBatch );
        }
    }
}
