using EternalResolve.Common.Codes.UI.Events;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;

namespace EternalResolve.Common.Codes.UI
{
    /// <summary>
    /// 表示一个UI控件.
    /// </summary>
    public class Control : Element
    {
        /// <summary>
        /// 控件现可进行交互.
        /// </summary>
        public bool Interactive { get; set; } = false;

        /// <summary>
        /// 控件上一帧的交互状态.
        /// </summary>
        public bool OldInteractive { get; set; } = false;

        /// <summary>
        /// 控件是否可被拖动？
        /// </summary>
        public bool DropPermit { get; set; } = false;

        /// <summary>
        /// 控件是否锁定子元素的坐标？
        /// </summary>
        public bool LockSubControl { get; set; } = true;

        /// <summary>
        /// 表示控件所属管理器.
        /// </summary>
        public ControlOperator Manager;

        /// <summary>
        /// 控件相对于父控件的横位置坐标.
        /// </summary>
        public int SubPositionX { get; set; } = 0;

        /// <summary>
        /// 控件相对于父控件的纵位置坐标.
        /// </summary>
        public int SubPosititonY { get; set; } = 0;

        /// <summary>
        /// 控件相对于父控件的位置坐标.
        /// </summary>
        public Vector2 SubPosition
        {
            get
            {
                return new Vector2( SubPositionX , SubPosititonY );
            }
            set
            {
                SubPositionX = value.X.ToInt( );
                SubPosititonY = value.Y.ToInt( );
            }
        }

        /// <summary>
        /// 控件的上级控件, 控件只可以拥有一个上级控件.
        /// </summary>
        public Control Superior;

        /// <summary>
        /// 控件的子控件.控件可以拥有多个子控件.
        /// </summary>
        public List<Control> SubControls = new List<Control>( );

        /// <summary>
        /// 返回控件的最上级的子控件.如没有子控件可寻, 若该控件目前可交互, 则返回自己.
        /// </summary>
        public virtual Control ControlAt( )
        {
            Control target = null;
            for ( int sub = SubControls.Count - 1; sub >= 0; sub-- )
            {
                if ( SubControls[ sub ].ControlAt( ) == null )
                {
                    target = null;
                }
                else if ( SubControls[ sub ].ControlAt( ) != null )
                {
                    target = SubControls[ sub ].ControlAt( );
                    return target;
                }
            }
            if ( Interactive )
            {
                return this;
            }
            return target;
        }

        /// <summary>
        /// 将一个具有指定引用的控件注册进该控件.
        /// <para>被注册的控件将会成为该控件的子控件.</para>
        /// </summary>
        /// <param name="control"></param>
        public virtual void Register( Control control )
        {
            control.Manager = Manager;
            control.Superior = this;
            SubControls.Add( control );
        }

        /// <summary>
        /// 将具有指定引用的控件从该控件的子控件列表内删除.
        /// </summary>
        /// <param name="element"></param>
        public void Remove( Control element )
        {
            SubControls.Remove( element );
        }

        /// <summary>
        /// 代表控件自身所绑定的事件.
        /// </summary>
        /// <param name="theEvent"></param>
        /// <param name="element"></param>
        public delegate void ElementEvent( UIEvent theEvent , Control element );

        /// <summary>
        /// 控件所绑定的、逻辑刷新时的事件.
        /// </summary>
        public event ElementEvent UpdatedEvent;

        /// <summary>
        /// 代表控件所绑定的关于鼠标的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        /// <param name="element"></param>
        public delegate void MouseEvent( UIMouseEvent mouseEvent , Control element );

        /// <summary>
        /// 控件所绑定的、左键单击的事件.
        /// </summary>
        public event MouseEvent LeftClickEvent;
        /// <summary>
        /// 控件所绑定的、左键长按的事件.
        /// </summary>
        public event MouseEvent LeftPressedEvent;
        /// <summary>
        /// 控件所绑定的、右键单击的事件.
        /// </summary>
        public event MouseEvent RightClickEvent;
        /// <summary>
        /// 控件所绑定的、右键长按的事件.
        /// </summary>
        public event MouseEvent RightPressedEvent;
        /// <summary>
        /// 控件所绑定的、鼠标悬浮于该控件上时的事件.
        /// </summary>
        public event MouseEvent HoverEvent;
        /// <summary>
        /// 控件所绑定的、鼠标刚进入判定范围内时的事件.
        /// </summary>
        public event MouseEvent IntoElementEvent;
        /// <summary>
        /// 控件所绑定的、鼠标刚离开判定范围时的事件.
        /// </summary>
        public event MouseEvent LeaveElementEvent;
        /// <summary>
        /// 控件所绑定的、开始拖动控件时的事件.
        /// </summary>
        public event MouseEvent DropStartEvent;
        /// <summary>
        /// 控件所绑定的、结束拖动控件时的事件.
        /// </summary>
        public event MouseEvent DropEndEvent;

        /// <summary>
        /// 设置大小.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public void SetSize( int width , int height )
        {
            Width = width;
            Height = height;
        }

        public override void Initialization( )
        {
            LeftClickEvent += LeftClick;
            LeftPressedEvent += LeftPressed;
            RightClickEvent += RightClick;
            RightPressedEvent += RightPressed;
            HoverEvent += Hover;
            IntoElementEvent += Into;
            LeaveElementEvent += Leave;
            DropStartEvent += DropStart;
            DropEndEvent += DropEnd;
            UpdatedEvent += Updated;
            foreach ( Control element in SubControls )
                element.Initialization( );
        }

        /// <summary>
        /// 调用控件所绑定的关于逻辑刷新的事件.
        /// </summary>
        /// <param name="theEvent"></param>
        public virtual void UIElementUpdated( UIEvent theEvent )
        {
            UpdatedEvent.Invoke( theEvent , this );
        }
        public virtual void Updated( UIEvent theEvent , Control element )
        {

        }

        /// <summary>
        /// 调用控件所绑定的鼠标左键长按的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseLeftPressed( UIMouseEvent mouseEvent )
        {
            LeftPressedEvent.Invoke( mouseEvent , this );
        }
        public virtual void LeftPressed( UIMouseEvent mouseEvent , Control element )
        {
        }

        /// <summary>
        /// 调用控件所绑定的鼠标左键单击的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseLeftClick( UIMouseEvent mouseEvent )
        {
            LeftClickEvent?.Invoke( mouseEvent , this );
        }
        /// <summary>
        /// 控件被左键单击时执行.
        /// </summary>
        /// <param name="mouseEvent"></param>
        /// <param name="element"></param>
        public virtual void LeftClick( UIMouseEvent mouseEvent , Control element )
        {

        }

        /// <summary>
        /// 调用控件所绑定的鼠标右键单击的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseRightClick( UIMouseEvent mouseEvent )
        {
            RightClickEvent?.Invoke( mouseEvent , this );
        }
        /// <summary>
        /// 控件被右键单击时执行.
        /// </summary>
        /// <param name="mouseEvent"></param>
        /// <param name="element"></param>
        public virtual void RightClick( UIMouseEvent mouseEvent , Control element )
        {

        }

        /// <summary>
        /// 调用控件所绑定的鼠标右键长按的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseRightPressed( UIMouseEvent mouseEvent )
        {
            RightPressedEvent.Invoke( mouseEvent , this );
        }
        public virtual void RightPressed( UIMouseEvent mouseEvent , Control element )
        {
        }

        /// <summary>
        /// 调用控件所绑定的鼠标悬浮于其上的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseHover( UIMouseEvent mouseEvent )
        {
            Main.mouseLeft = false;
            Main.mouseLeftRelease = false;
            Main.LocalPlayer.mouseInterface = true;
            Main.LocalPlayer.delayUseItem = true;
            HoverEvent?.Invoke( mouseEvent , this );
        }
        public virtual void Hover( UIMouseEvent mouseEvent , Control element )
        {

        }

        /// <summary>
        /// 调用控件所绑定的鼠标刚悬浮于其上的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseInto( UIMouseEvent mouseEvent )
        {
            IntoElementEvent?.Invoke( mouseEvent , this );
        }
        public virtual void Into( UIMouseEvent mouseEvent , Control element )
        {

        }

        /// <summary>
        /// 调用控件所绑定的鼠标刚离开于其上的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseLeave( UIMouseEvent mouseEvent )
        {
            LeaveElementEvent?.Invoke( mouseEvent , this );
        }
        public virtual void Leave( UIMouseEvent mouseEvent , Control element )
        {

        }

        /// <summary>
        /// 调用控件所绑定的鼠标开始拖动控件时的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseDropStart( UIMouseEvent mouseEvent )
        {
            DropStartEvent?.Invoke( mouseEvent , this );
        }
        public virtual void DropStart( UIMouseEvent mouseEvent , Control element )
        {
            if ( !Rectangle.OldIntersectMouse( ) && FrontDevice.Input.OldMouseState.LeftButton.Pressed( ) )
                cantDrop = true;
            if ( DropPermit && isClicked )
            {

                positionCacheX = FrontDevice.Input.MousePosition.X.ToInt( ) - PositionX.ToInt( );
                positionCacheY = FrontDevice.Input.MousePosition.Y.ToInt( ) - PositionY.ToInt( );
                if ( !cantDrop )
                    inDrop = true;
                isClicked = false;
            }
        }

        /// <summary>
        /// 调用控件所绑定的鼠标结束拖动控件时的事件.
        /// </summary>
        /// <param name="mouseEvent"></param>
        public virtual void MouseDropEnd( UIMouseEvent mouseEvent )
        {
            DropEndEvent?.Invoke( mouseEvent , this );
        }
        public virtual void DropEnd( UIMouseEvent mouseEvent , Control element )
        {
            if ( DropPermit )
            {
                positionCacheX = 0;
                positionCacheY = 0;
                inDrop = false;
                isClicked = true;
            }
        }

        protected int positionCacheX = 0;
        protected int positionCacheY = 0;
        protected bool isClicked = true;
        protected bool inDrop = false;
        protected bool cantDrop = false;

        /// <summary>
        /// 计算该控件的交互状态.
        /// </summary>
        public virtual void CalculationInteractive( )
        {
            if ( Rectangle.IntersectMouse( ) )
                Interactive = true;
            else
                Interactive = false;
        }

        public override void PreUpdate( )
        {
            OldInteractive = Interactive;
            base.PreUpdate( );
        }

        /// <summary>
        /// 执行子控件的逻辑刷新.
        /// </summary>
        protected virtual void UpdateSubControls( )
        {
            foreach ( Control sub in SubControls )
            {
                sub.CalculationInteractive( );
                if ( LockSubControl && !sub.DropPermit )
                    sub.Position = Position + sub.SubPosition;
                sub.Update( Main.gameTimeCache );
            }
        }

        public override void Update( )
        {
            if ( inDrop )
                Position = FrontDevice.Input.MousePosition - new Vector2( positionCacheX , positionCacheY );
            cantDrop = false;
            UIElementUpdated( new UIEvent( this ) );
            UpdateSubControls( );
        }

        public override void PostUpdate( )
        {
            if ( !FrontDevice.Input.MouseLeftPressed )
            {
                inDrop = false;
                isClicked = true;
                positionCacheX = 0;
                positionCacheY = 0;
            }
            Position += Velocity;
        }

        /// <summary>
        /// 执行子控件的纹理绘制.
        /// </summary>
        protected virtual void DrawSubControls( )
        {
            foreach ( Control sub in SubControls )
                sub.Draw( Main.gameTimeCache );
        }

        /// <summary>
        /// 执行控件的纹理绘制.
        /// </summary>
        /// <param name="spriteBatch"></param>
        public override void Draw( SpriteBatch spriteBatch )
        {
            DrawSubControls( );
        }
    }
}