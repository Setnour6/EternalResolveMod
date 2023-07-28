using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Contents.Entities.Items.Runes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.Contents
{
    public class CompleteSetText : Control
    {
        public string Text = "";

        public override void Update( )
        {
            Text = "符印套装属性: \n";

            for ( int count = 0; count < Modular.RuneInterface.WeaponRune.Slot.Length; count++ )
            {
                if( Modular.RuneInterface.WeaponRune.Slot[ count ].Item.type != ItemID.None )
                    if ( Modular.RuneInterface.WeaponRune.Slot[ count ].Item.GetGlobalItem<RuneItem>( ).CompleteSet.Check( ) )
                    {
                        Text += Modular.RuneInterface.WeaponRune.Slot[ count ].Item.GetGlobalItem<RuneItem>( ).CompleteSet.Text( ) + "\n";
                    }
            }
            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            base.Draw( spriteBatch );
            spriteBatch.End( );
            spriteBatch.Begin( SpriteSortMode.BackToFront , BlendState.AlphaBlend , SamplerState.PointClamp , null , null );
            spriteBatch.DrawString( FontAssets.MouseText.Value , Text , Position , Color.White );
        }
    }
}
