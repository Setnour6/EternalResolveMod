using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace EternalResolve.Common.Codes
{
    /// <summary>
    /// 表示一个引擎插件.
    /// </summary>
    public class EngineComponent
    {
        public virtual void Initialization( )
        {
        }

        bool _updateStarted = false;
        public void Update( GameTime gameTime )
        {
            if ( !_updateStarted )
            {
                UpdateStart( );
                _updateStarted = true;
            }
            if ( this != null )
                PreUpdate( );
            if ( this != null )
                Update( );
            if ( this != null )
                PostUpdate( );
        }
        public virtual void UpdateStart( )
        {

        }
        public virtual void PreUpdate( )
        {
        }
        public virtual void Update( )
        {
        }
        public virtual void PostUpdate( )
        {
        }

        bool _drawStarted = false;
        public void Draw( GameTime gameTime )
        {
            if ( !_drawStarted )
            {
                DrawStart( Main.spriteBatch );
                _drawStarted = true;
            }
            if ( this != null )
                PreDraw( Main.spriteBatch );
            if ( this != null )
                Draw( Main.spriteBatch );
            if ( this != null )
                PostDraw( Main.spriteBatch );
        }
        public virtual void DrawStart( SpriteBatch spriteBatch )
        {

        }
        public virtual void PreDraw( SpriteBatch spriteBatch )
        {
        }
        public virtual void Draw( SpriteBatch spriteBatch )
        {
        }
        public virtual void PostDraw( SpriteBatch spriteBatch )
        {
        }
    }
}
