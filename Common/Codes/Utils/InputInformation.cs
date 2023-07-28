using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace EternalResolve.Common.Codes.Utils
{
    public class InputInformation
    {
        /// <summary>
        /// 这一帧的鼠标状态.
        /// </summary>
        public MouseState MouseState = new MouseState( );

        /// <summary>
        /// 上一帧的鼠标状态.
        /// </summary>
        public MouseState OldMouseState = new MouseState( );

        /// <summary>
        /// 鼠标的位置.
        /// </summary>
        public Vector2 MousePosition { get; set; }


        public Rectangle MouseRec
        {
            get
            {
                return new Rectangle( MousePosition.X.ToInt( ) , MousePosition.Y.ToInt( ) , 1 , 1 );
            }
        }

        /// <summary>
        /// 表示鼠标左键单击.
        /// </summary>
        public bool MouseLeftClick { get; set; } = false;
        /// <summary>
        /// 表示鼠标左键长按.
        /// </summary>
        public bool MouseLeftPressed { get; set; } = false;
        /// <summary>
        /// 表示鼠标右键单击.
        /// </summary>
        public bool MouseRightClick { get; set; } = false;
        /// <summary>
        /// 表示鼠标右键长按.
        /// </summary>
        public bool MouseRightPressed { get; set; } = false;
        /// <summary>
        /// 表示鼠标双键松开.
        /// </summary>
        public bool MouseReleased { get; set; } = false;

        /// <summary>
        /// 这一帧键盘状态.
        /// </summary>
        public KeyboardState KeyboardState = new KeyboardState( );

        /// <summary>
        /// 上一帧键盘状态.
        /// </summary>
        public KeyboardState OldKeyboardState = new KeyboardState( );

        /// <summary>
        /// 判断某个键是否被单击.
        /// </summary>
        /// <param name="keys">键.</param>
        /// <returns></returns>
        public bool IsKeyClick( Keys keys )
        {
            return KeyboardState.IsKeyUp( keys ) && OldKeyboardState.IsKeyDown( keys );
        }

        /// <summary>
        /// 从设备获取信息.
        /// </summary>
        public void GetInformationFromDevice( )
        {
            MousePosition = new Vector2( MouseState.X , MouseState.Y );
            OldMouseState = MouseState;
            MouseState = Mouse.GetState( );
            OldKeyboardState = KeyboardState;
            KeyboardState = Keyboard.GetState( );
            MouseLeftClick = false;
            MouseLeftPressed = false;
            MouseRightClick = false;
            MouseRightPressed = false;
            MouseReleased = false;
            if ( MouseState.LeftButton.Released( ) && OldMouseState.LeftButton.Pressed( ) )
                MouseLeftClick = true;
            if ( MouseState.LeftButton.Pressed( ) && OldMouseState.LeftButton.Pressed( ) )
                MouseLeftPressed = true;
            if ( MouseState.RightButton.Released( ) && OldMouseState.RightButton.Pressed( ) )
                MouseRightClick = true;
            if ( MouseState.RightButton.Pressed( ) && OldMouseState.RightButton.Pressed( ) )
                MouseRightPressed = true;
            if ( MouseState.LeftButton.Released( ) && OldMouseState.LeftButton.Released( ) && MouseState.RightButton.Released( ) && OldMouseState.RightButton.Released( ) )
                MouseReleased = true;
        }

        /// <summary>
        /// 重置设备信息.
        /// </summary>
        public void ResetInfomation( )
        {
            MouseLeftClick = false;
            MouseLeftPressed = false;
            MouseRightClick = false;
            MouseRightPressed = false;
            MouseReleased = false;
        }
    }
}
