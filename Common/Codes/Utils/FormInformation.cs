using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Codes.Utils
{
    /// <summary>
    /// 包含了一些有用的方法, 旨在提高编码效率.
    /// </summary>
    public class FormInformation
    {
        /// <summary>
        /// 屏幕分辨率宽度.
        /// </summary>
        public int ScreenWidth
        {
            get
            {
                if ( Main.netMode != NetmodeID.Server )
                    return Main.graphics.GraphicsDevice.Viewport.Width;
                return 0;
            }
        }

        /// <summary>
        /// 屏幕分辨率高度.
        /// </summary>
        public int ScreenHeight
        {
            get
            {
                if ( Main.netMode != NetmodeID.Server )
                    return Main.graphics.GraphicsDevice.Viewport.Height;
                return 0;
            }
        }

        /// <summary>
        /// 屏幕中心坐标.
        /// </summary>
        public Vector2 ScreenCenter
        {
            get
            {
                if ( Main.netMode != NetmodeID.Server )
                    return new Vector2( ScreenWidth / 2 , ScreenHeight / 2 );
                return Vector2.Zero;
            }
        }

        public Rectangle Screen
        {
            get
            {
                if ( Main.netMode != NetmodeID.Server )
                    return new Rectangle( 0 , 0 , ScreenWidth , ScreenHeight );
                return Rectangle.Empty;
            }
        }

        /// <summary>
        /// 从设备获取信息.
        /// </summary>
        internal void GetInformationFromDevice( )
        {

        }
    }
}
