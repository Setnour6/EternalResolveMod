using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.PrayModular
{
    public class PrayPlayer : ModPlayer
    {
        protected override bool CloneNewInstances => true;

        public override void PreUpdate( )
        {
            if ( Modular.PrayInteracting )
            {
                Player.mouseInterface = true;
                Player.delayUseItem = true;
                Player.controlDown = false;
                Player.controlHook = false;
                Player.controlJump = false;
                Player.controlUp = false;
                Player.controlLeft = false;
                Player.controlRight = false;
                Player.controlUseItem = false;
                Player.delayUseItem = true;
                Main.mouseLeft = false;
                Main.mouseLeftRelease = false;
                Main.mouseRight = false;
                Main.mouseRightRelease = false;
                Main.playerInventory = true;
                PlayerInput.ScrollWheelDelta = 0;
                PlayerInput.ScrollWheelDeltaForUI = 0;
                PlayerInput.MouseInfo = new MouseState( );
                PlayerInput.MouseInfoOld = new MouseState( );
                PlayerInput.ScrollWheelValue = 0;
                PlayerInput.ScrollWheelValueOld = 1;
                base.PreUpdate( );
            }
        }

        public override void PostUpdate( )
        {
            if ( !Modular.PrayInteracting && FrontDevice.Input.IsKeyClick( Keys.F3 ) )
            {
                Modular.PrayInteracting = true;
                Modular.PrayInterface.PrayButton_0.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , -1000 );
                Modular.PrayInterface.PrayButton_1.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , -1000 );
                Modular.PrayInterface.PrayButton_2.Position = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , -1000 );

                Modular.PrayInterface.PrayButton_0.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 500 , FrontDevice.Form.ScreenHeight / 2 - 404 );
                Modular.PrayInterface.PrayButton_1.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 - 131 , FrontDevice.Form.ScreenHeight / 2 - 404 );
                Modular.PrayInterface.PrayButton_2.Target = new Vector2( FrontDevice.Form.ScreenWidth / 2 + 238 , FrontDevice.Form.ScreenHeight / 2 - 404 );

                ChangeAnimation.PlayChangeAnimation( );
            }
            if ( Modular.RuneInteracting )
            {
                Player.mouseInterface = true;
                Player.delayUseItem = true;
                Player.controlDown = false;
                Player.controlHook = false;
                Player.controlJump = false;
                Player.controlUp = false;
                Player.controlLeft = false;
                Player.controlRight = false;
                Player.controlUseItem = false;
                Player.delayUseItem = true;
                Main.mouseLeft = false;
                Main.mouseLeftRelease = false;
                Main.mouseRight = false;
                Main.mouseRightRelease = false;
                Main.playerInventory = true;
                PlayerInput.ScrollWheelDelta = 0;
                PlayerInput.ScrollWheelDeltaForUI = 0;
                PlayerInput.MouseInfo = new MouseState( );
                PlayerInput.MouseInfoOld = new MouseState( );
                PlayerInput.GamepadScrollValue = 0;
                PlayerInput.ScrollWheelValue = 0;
                PlayerInput.ScrollWheelValueOld = 1;
            }
            base.PostUpdate( );
        }
    }
}
