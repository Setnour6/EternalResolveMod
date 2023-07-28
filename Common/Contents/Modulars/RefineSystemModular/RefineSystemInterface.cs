using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSystemInterface : ControlOperator
    {
        public RefineSystemPanel Panel;
        public override void Initialization( )
        {
            Panel = new RefineSystemPanel( );
            Panel.Position = FrontDevice.Form.ScreenCenter - new Vector2( 310 , 160 ) - Vector2.UnitY * 1000;
            Panel.Target = FrontDevice.Form.ScreenCenter - new Vector2( 310 , 160 ) - Vector2.UnitY * 1000;
            Register( Panel );
            base.Initialization( );
        }
        public override void Update( )
        {
            if ( FrontDevice.Input.MouseLeftClick && !Panel.Rectangle.IntersectMouse( ) &&
                Main.mouseItem.type == ItemID.None && !Main.LocalPlayer.mouseInterface )
            {
                Modular.RefineSystemInteracting = false;
            }

            if ( Modular.RefineSystemInteracting )
                Panel.Target = FrontDevice.Form.ScreenCenter - Panel.Size / 2;
            else
                Panel.Target = FrontDevice.Form.ScreenCenter - Panel.Size / 2 - Vector2.UnitY * 1000;
            base.Update( );
        }
    }
}