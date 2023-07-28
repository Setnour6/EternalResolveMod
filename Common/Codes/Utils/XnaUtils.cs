using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EternalResolve.Common.Codes.Utils
{
    /// <summary>
    /// 包含了一些有用的方法, 旨在提高编码效率.
    /// </summary>
    public static class XnaUtils
    {
        /// <summary>
		/// 线性插值。相当于maxi等分线段。这个方法将返回线段中第i段的位置
		/// </summary>
        public static Vector2 GetCloser( float x , float y , float targetx , float targety , float i , float maxi )
        {
            x *= maxi - i;
            x /= maxi;
            y *= maxi - i;
            y /= maxi;
            targetx *= i;
            targetx /= maxi;
            targety *= i;
            targety /= maxi;
            return new Vector2( x + targetx , y + targety );
        }

        /// <summary>
		/// 线性插值。相当于maxi等分线段。这个方法将返回线段中第i段的位置
		/// </summary>
        public static Vector2 GetCloser( Vector2 current , Vector2 target , float i , float maxi )
        {
            current *= maxi - i;
            current /= maxi;
            target *= i;
            target /= maxi;
            return current + target;
        }

        /// <summary>
        /// 按下.
        /// </summary>
        /// <param name="buttonState"></param>
        /// <returns></returns>
        public static bool Pressed( this ButtonState buttonState )
        {
            return buttonState == ButtonState.Pressed;
        }

        /// <summary>
        /// 松开.
        /// </summary>
        /// <param name="buttonState"></param>
        /// <returns></returns>
        public static bool Released( this ButtonState buttonState )
        {
            return buttonState == ButtonState.Released;
        }

        /// <summary>
        /// 表示这个按钮的状态为 被单击.
        /// </summary>
        /// <param name="buttonState">这一帧按钮的状态.</param>
        /// <param name="oldButtonState">上一帧按钮的状态.</param>
        /// <returns></returns>
        public static bool Click( this ButtonState buttonState , ButtonState oldButtonState )
        {
            return buttonState.Released( ) && oldButtonState.Pressed( );
        }

        /// <summary>
        /// 鼠标被松开了.
        /// </summary>
        /// <param name="mouseState">这一帧鼠标的状态.</param>
        /// <param name="oldMouseState">上一帧鼠标的状态.</param>
        /// <returns></returns>
        public static bool Released( this MouseState mouseState , MouseState oldMouseState )
        {
            return mouseState.LeftButton.Released( ) && oldMouseState.LeftButton.Released( ) &&
                mouseState.RightButton.Released( ) && oldMouseState.RightButton.Released( );
        }

        /// <summary>
        /// 当前帧鼠标被松开了.
        /// </summary>
        /// <param name="mouseState">鼠标的状态.</param>
        /// <returns></returns>
        public static bool Released( this MouseState mouseState )
        {
            return mouseState.LeftButton.Released( ) && mouseState.RightButton.Released( );
        }

        /// <summary>
        /// 表示左右键正在进行操作.
        /// </summary>
        /// <param name="mouseState">鼠标的状态.</param>
        /// <returns></returns>
        public static bool Interacting( this MouseState mouseState )
        {
            return mouseState.LeftButton.Pressed( ) || mouseState.RightButton.Pressed( );
        }

        /// <summary>
        /// 鼠标与这个矩形发生了重叠.
        /// </summary>
        /// <param name="rectangle">矩形.</param>
        /// <returns></returns>
        public static bool IntersectMouse( this Rectangle rectangle )
        {
            return rectangle.Intersects( new Rectangle( FrontDevice.Input.MousePosition.X.ToInt( ) + 1 , FrontDevice.Input.MousePosition.Y.ToInt( ) + 1 , 0 , 0 ) );
        }

        /// <summary>
        /// 上一帧鼠标与这个矩形发生了重叠.
        /// </summary>
        /// <param name="rectangle">矩形.</param>
        /// <returns></returns>
        public static bool OldIntersectMouse( this Rectangle rectangle )
        {
            return rectangle.Intersects( new Rectangle( FrontDevice.Input.OldMouseState.X + 1 , FrontDevice.Input.OldMouseState.Y + 1 , 0 , 0 ) );
        }


        /// <summary>
        /// 九片式绘制.
        /// </summary>
        /// <param name="spriteBatch">纹理绘制管道.</param>
        /// <param name="image">纹理.</param>
        /// <param name="x">绘制纹理左上角的 X 坐标.</param>
        /// <param name="y">绘制纹理左上角的 Y 坐标.</param>
        /// <param name="width">宽度.</param>
        /// <param name="height">高度.</param>
        /// <param name="borderSize">裁区范围.</param>
        public static void DrawNinePieces( this SpriteBatch spriteBatch , Texture2D image , int x , int y , int width , int height , int borderSize )
        {
            //右上角矩形绘制起点
            Vector2 rightTopStartPoting = new Vector2( ( x + width - borderSize ) , y );
            //左下角矩形绘制起点
            Vector2 leftBottomStartPoting = new Vector2( x , ( y + height - borderSize ) );
            //右下角矩形绘制起点
            Vector2 rightBottomStartPoting = new Vector2( ( x + width - borderSize ) , ( y + height - borderSize ) );
            //截取图片右上角
            Rectangle rightTopIntercept = new Rectangle( image.Width - borderSize , 0 , borderSize , borderSize );
            //截取图片左下角
            Rectangle leftBottomIntercept = new Rectangle( 0 , image.Height - borderSize , borderSize , borderSize );
            //截取图片右下角
            Rectangle rightBottomIntercept = new Rectangle( image.Width - borderSize , image.Height - borderSize , borderSize , borderSize );
            //左上角
            spriteBatch.Draw( image , new Vector2( x , y ) , new Rectangle( 0 , 0 , borderSize , borderSize ) , Color.White );
            //右上角
            spriteBatch.Draw( image , rightTopStartPoting , rightTopIntercept , Color.White );
            //左下角
            spriteBatch.Draw( image , leftBottomStartPoting , leftBottomIntercept , Color.White );
            //右下角
            spriteBatch.Draw( image , rightBottomStartPoting , rightBottomIntercept , Color.White );
            //上
            spriteBatch.Draw( image , new Rectangle( x + borderSize , y , width - borderSize * 2 , borderSize ) , new Rectangle( borderSize , 0 , 2 , borderSize ) , Color.White );
            //右
            spriteBatch.Draw( image , new Rectangle( x + width - borderSize , y + borderSize , borderSize , height - borderSize * 2 ) , new Rectangle( image.Width - borderSize , borderSize , borderSize , 2 ) , Color.White );
            //下
            spriteBatch.Draw( image , new Rectangle( x + borderSize , y + height - borderSize , width - borderSize * 2 , borderSize ) , new Rectangle( borderSize , image.Height - borderSize , 2 , borderSize ) , Color.White );
            //左
            spriteBatch.Draw( image , new Rectangle( x , y + borderSize , borderSize , height - borderSize * 2 ) , new Rectangle( 0 , borderSize , borderSize , 2 ) , Color.White );
            //中
            spriteBatch.Draw( image , new Rectangle( x + borderSize , y + borderSize , width - borderSize * 2 , height - borderSize * 2 ) , new Rectangle( borderSize , borderSize , 2 , 2 ) , Color.White );
        }
    }
}