using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace EternalResolve.Common.Codes
{
    /// <summary>
    /// 表示引擎中可扩展、可控制逻辑刷新与纹理绘制的元素.
    /// </summary>
    public class Element : EngineComponent
    {
        /// <summary>
        /// 元素的横坐标.
        /// </summary>
        public float PositionX { get; set; } = 0;

        /// <summary>
        /// 元素的纵坐标.
        /// </summary>
        public float PositionY { get; set; } = 0;

        /// <summary>
        /// 元素的坐标.
        /// </summary>
        public Vector2 Position
        {
            get
            {
                return new Vector2( PositionX , PositionY );
            }
            set
            {
                PositionX = value.X;
                PositionY = value.Y;
            }
        }

        /// <summary>
        /// 元素中心坐标.
        /// </summary>
        public Vector2 Center
        {
            get
            {
                return Position + Size / 2;
            }
        }

        /// <summary>
        /// 元素的宽.
        /// </summary>
        public int Width { get; set; } = 0;

        /// <summary>
        /// 元素的高.
        /// </summary>
        public int Height { get; set; } = 0;

        /// <summary>
        /// 元素的长宽所表示的向量值.
        /// </summary>
        public Vector2 Size
        {
            get
            {
                return new Vector2( Width , Height );
            }
            set
            {
                Width = value.X.ToInt( );
                Height = value.Y.ToInt( );
            }
        }

        /// <summary>
        /// 元素的纹理缩放.
        /// </summary>
        public float Scale = 1f;

        /// <summary>
        /// 元素的绘制坐标.
        /// </summary>
        public Vector2 DrawPosition
        {
            get
            {
                return Position + Size / 2;
            }
        }

        /// <summary>
        /// 元素的横向分速度.
        /// </summary>
        public float VelocityX { get; set; } = 0;

        /// <summary>
        /// 元素的纵向分速度.
        /// </summary>
        public float VelocityY { get; set; } = 0;

        /// <summary>
        /// 元素的速度.
        /// </summary>
        public Vector2 Velocity
        {
            get
            {
                return new Vector2( VelocityX , VelocityY );
            }
            set
            {
                VelocityX = value.X;
                VelocityY = value.Y;
            }
        }

        /// <summary>
        /// 储存元素速度列表的上限.
        /// </summary>
        public int VelocityCacheCount { get; set; } = 0;

        /// <summary>
        /// 一个存储元素速度的列表，一帧存储一个，由元素的 VelocityCacheCount 控制存储上限.
        /// </summary>
        public List<Vector2> Velocitys { get; set; } = new List<Vector2>( );

        /// <summary>
        /// 获取元素的基础矩形.
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle( PositionX.ToInt( ) , PositionY.ToInt( ) , Width , Height );
            }
        }

        /// <summary>
        /// 元素的颜色.
        /// </summary>
        public Color Color { get; set; } = Color.White;

        public override void PostUpdate( )
        {
            if ( VelocityCacheCount > 0 )
            {
                if ( Velocitys.Count < VelocityCacheCount )
                    Velocitys.Add( Velocity );
                else
                {
                    Velocitys.RemoveAt( Velocitys.Count - 1 );
                    Velocitys.Add( Velocity );
                }
            }
            base.PostUpdate( );
        }
    }
}
