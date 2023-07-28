using EternalResolve.Common.Codes.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;

namespace EternalResolve.Common.Codes.UI
{
    /// <summary>
    /// 表示一个控件执行器.
    /// </summary>
    public class ControlOperator : EngineComponent
    {
        /// <summary>
        /// 该执行器内的元素列表.
        /// </summary>
        public List<Control> Controls = new List<Control>( );

        /// <summary>
        /// 获得上一帧鼠标所悬浮的、在界面最顶层的UI元素.
        /// </summary>
        /// <returns></returns>
        public Control OldAtControl;

        /// <summary>
        /// 获得目前可交互的、在该运行器内最顶层的控件.
        /// </summary>
        /// <returns></returns>
        public virtual Control ControlAt( )
        {
            Control target = null;
            for ( int element = Controls.Count - 1; element >= 0; element-- )
            {
                if ( Controls[ element ].ControlAt( ) != null )
                {
                    target = Controls[ element ].ControlAt( );
                    break;
                }
            }
            return target;
        }

        /// <summary>
        /// 将一个具有指定引用的元素注册至该状态管理器.
        /// </summary>
        /// <param name="control"></param>
        public void Register( Control control )
        {
            control.Manager = this;
            Controls.Add( control );
        }

        public override void Initialization( )
        {
            for ( int Count = 0; Count < Controls.Count; Count++ )
                Controls[ Count ].Initialization( );
        }

        public override void Update( )
        {
            OldAtControl = ControlAt( );
            for ( int Count = 0; Count < Controls.Count; Count++ )
            {
                Controls[ Count ].CalculationInteractive( );
                Controls[ Count ].Update( Main.gameTimeCache );
            }
            ControlEventOperat( );
        }

        /// <summary>
        /// 控件事件执行.
        /// </summary>
        private void ControlEventOperat( )
        {
            Control control = ControlAt( );
            if ( control != null )
            {
                control.CalculationInteractive( );
                if ( control != null )
                {
                    if ( control.Interactive && FrontDevice.Input.MouseLeftClick )
                    {
                        control.MouseLeftClick( new UIMouseEvent( control ) );
                        if ( control != null )
                            control.MouseDropEnd( new UIMouseEvent( control ) );
                    }
                    else if ( control.Interactive && FrontDevice.Input.MouseLeftPressed )
                    {
                        control.MouseLeftPressed( new UIMouseEvent( control ) );
                        if ( control != null )
                            control.MouseDropStart( new UIMouseEvent( control ) );
                    }
                    if ( control != null )
                    {
                        if ( control.Interactive && FrontDevice.Input.MouseRightClick )
                            control.MouseRightClick( new UIMouseEvent( control ) );
                        else if ( control.Interactive && FrontDevice.Input.MouseRightPressed )
                            control.MouseRightPressed( new UIMouseEvent( control ) );
                        if ( control.Interactive && FrontDevice.Input.MouseReleased )
                            control.MouseHover( new UIMouseEvent( control ) );
                        if ( control != null )
                        {
                            if ( control.Interactive && !control.OldInteractive )
                                control.MouseInto( new UIMouseEvent( control ) );
                        }
                    }
                }
            }
            if ( OldAtControl != null )
            {
                if ( control == null && OldAtControl.Interactive )
                    OldAtControl.MouseLeave( new UIMouseEvent( OldAtControl ) );
            }
        }

        public override void Draw( SpriteBatch spriteBatch )
        {
            for ( int Count = 0; Count < Controls.Count; Count++ )
                Controls[ Count ].Draw( Main.gameTimeCache );
        }
    }
}
