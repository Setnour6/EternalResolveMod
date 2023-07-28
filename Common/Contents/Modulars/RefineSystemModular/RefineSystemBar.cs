using EternalResolve.Assets.Textures.Systems.RefineSystems;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSystemBar : Control
    {
        public override void Initialization( )
        {
            SetSize( 200 , 24 );
            base.Initialization( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( RefineAssets.Bar , Position , Color );
            if ( Modular.RefineSystemInterface.Panel.
                WeaponSlot.Item != null && Modular.RefineSystemInterface.Panel.
                WeaponSlot.Item.type != ItemID.None )
            {
                spriteBatch.Draw( RefineAssets.Bar2 , new Rectangle(
                    PositionX.ToInt( ) , PositionY.ToInt( ) ,
                    ( 200f * Modular.RefineSystemInterface.Panel.
                WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).Exp / Modular.RefineSystemInterface.Panel.
                WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).ExpMax ).ToInt( ) , 24 ) , Color );
            }
            if ( Modular.RefineSystemInterface.Panel.WeaponSlot.Item != null &&
               Modular.RefineSystemInterface.Panel.WeaponSlot.Item.type != ItemID.None )
            {
                string text = "该物品无法进行精炼";
                Color color = Color.DarkGray;
                if ( Modular.RefineSystemInterface.Panel.WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).CanLevelUp )
                {
                    if ( Modular.RefineSystemInterface.Panel.WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).Level <
                        Modular.RefineSystemInterface.Panel.WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).LevelMax )
                    {
                        text =
                            "Lv." + Modular.RefineSystemInterface.Panel.WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).Level + " | " +
                            Modular.RefineSystemInterface.Panel.WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).Exp + " / " +
                            Modular.RefineSystemInterface.Panel.WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).ExpMax;
                        color = Color.Black;
                    }
                    else
                    {
                        text = "该物品已精炼完成";
                        color = Color.OrangeRed;
                    }
                }
                else
                {
                    text = "该物品无法进行精炼";
                    color = Color.Red;
                }
                Vector2 textSize = FontAssets.MouseText.Value.MeasureString( text );
                Vector2 drawPos = Position + Size / 2 - textSize / 2;
                Utils.DrawBorderStringFourWay( spriteBatch , FontAssets.MouseText.Value , text , drawPos.X , drawPos.Y , Color.White , color , Vector2.Zero , 1f );
            }
            base.Draw( spriteBatch );
        }
    }
}