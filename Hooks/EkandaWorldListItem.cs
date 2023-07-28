using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.IO;
using Terraria.Localization;
using Terraria.UI;

namespace EternalResolve.Hooks
{
    internal class EkandaWorldListItem : UIWorldListItem
    {
        private WorldFileData _data;
        public EkandaWorldListItem( WorldFileData data , int orderInList , bool canBePlayed ) : base( data , orderInList , canBePlayed )
        {
            _data = data;
        }
        /// <summary>
        /// 用于替换世界图标
        /// </summary>
        /// <param name="texture"></param>
        internal void SetIcon( Asset<Texture2D> texture )
        {
            UIImage _worldIcon = (UIImage) typeof( UIWorldListItem ).GetField( "_worldIcon" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( this );
            _worldIcon.SetImage( texture );
            typeof( UIWorldListItem ).GetField( "_worldIcon" , BindingFlags.Instance | BindingFlags.NonPublic ).SetValue( this , _worldIcon );
        }
        private void DrawPanel( SpriteBatch spriteBatch , Vector2 position , float width )
        {
            Asset<Texture2D> _innerPanelTexture = (Asset<Texture2D>) typeof( UIWorldListItem ).GetField( "_innerPanelTexture" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( this );
            spriteBatch.Draw( _innerPanelTexture.Value , position , new Rectangle?( new Rectangle( 0 , 0 , 8 , _innerPanelTexture.Height( ) ) ) , Color.White );
            spriteBatch.Draw( _innerPanelTexture.Value , new Vector2( position.X + 8f , position.Y ) , new Rectangle?( new Rectangle( 8 , 0 , 8 , _innerPanelTexture.Height( ) ) ) , Color.White , 0f , Vector2.Zero , new Vector2( ( width - 16f ) / 8f , 1f ) , SpriteEffects.None , 0f );
            spriteBatch.Draw( _innerPanelTexture.Value , new Vector2( position.X + width - 8f , position.Y ) , new Rectangle?( new Rectangle( 16 , 0 , 8 , _innerPanelTexture.Height( ) ) ) , Color.White );
        }
        protected override void DrawSelf( SpriteBatch spriteBatch )
        {
            if ( (bool) typeof( UIPanel ).GetField( "_needsTextureLoading" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( this ) )
            {
                typeof( UIPanel ).GetField( "_needsTextureLoading" , BindingFlags.Instance | BindingFlags.NonPublic ).SetValue( this , false );
                typeof( UIPanel ).GetMethod( "LoadTextures" , BindingFlags.Instance | BindingFlags.NonPublic ).Invoke( this , null );
            }
            Asset<Texture2D> _backgroundTexture = (Asset<Texture2D>) typeof( UIPanel ).GetField( "_backgroundTexture" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( this ),
                _borderTexture = (Asset<Texture2D>) typeof( UIPanel ).GetField( "_borderTexture" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( this );
            MethodInfo method = typeof( UIPanel ).GetMethod( "DrawPanel" , BindingFlags.Instance | BindingFlags.NonPublic );
            if ( _backgroundTexture != null )
            {
                method.Invoke( this , new object[ ] { spriteBatch , _backgroundTexture.Value , BackgroundColor } );
            }
            if ( _borderTexture != null )
            {
                method.Invoke( this , new object[ ] { spriteBatch , _borderTexture.Value , BorderColor } );
            }

            CalculatedStyle innerDimensions = GetInnerDimensions( );
            CalculatedStyle dimensions = ( (UIImage) typeof( UIWorldListItem ).GetField( "_worldIcon" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( this ) ).GetDimensions( );
            float num = dimensions.X + dimensions.Width;
            Utils.DrawBorderString( spriteBatch , _data.Name , new Vector2( num + 6f , dimensions.Y - 2f ) , _data.IsValid ? Color.White : Color.Gray , 1f , 0f , 0f , -1 );
            spriteBatch.Draw( ( (Asset<Texture2D>) typeof( UIWorldListItem ).GetField( "_dividerTexture" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( this ) ).Value , new Vector2( num , innerDimensions.Y + 21f ) , null , Color.White , 0f , Vector2.Zero , new Vector2( ( GetDimensions( ).X + GetDimensions( ).Width - num ) / 8f , 1f ) , SpriteEffects.None , 0f );
            Vector2 vector = new Vector2( num + 6f , innerDimensions.Y + 29f );
            float num2 = 100f;
            DrawPanel( spriteBatch , vector , num2 );

            //以下是世界难度，注释掉的地方是原版难度
            string text = "永恒意志";
            //switch (this._data.GameMode)
            //{
            //	case 1:
            //		text = Language.GetTextValue("UI.Expert");
            //		color2 = Main.mcColor;
            //		break;
            //	case 2:
            //		text = Language.GetTextValue("UI.Master");
            //		color2 = Main.hcColor;
            //		break;
            //	case 3:
            //		text = Language.GetTextValue("UI.Creative");
            //		color2 = Main.creativeModeColor;
            //		break;
            //	default:
            //		text = Language.GetTextValue("UI.Normal");
            //		break;
            //}
            Utils.DrawBorderString( spriteBatch , text , vector + new Vector2( num2 * 0.5f - FontAssets.MouseText.Value.MeasureString( text ).X * 0.5f , 3f ) , Color.White , 1f , 0f , 0f , -1 );

            //以下是世界大小
            vector.X += num2 + 5f;
            float num3 = 150f + ( !GameCulture.FromCultureName( GameCulture.CultureName.English ).IsActive ? 40f : 0f );
            DrawPanel( spriteBatch , vector , num3 );
            string textValue = Language.GetTextValue( "Ekanda神殿");
            Utils.DrawBorderString( spriteBatch , textValue , vector + new Vector2( num3 * 0.5f - FontAssets.MouseText.Value.MeasureString( textValue ).X * 0.5f , 3f ) , Color.White , 1f , 0f , 0f , -1 );

            //以下是创建日期，被注释掉的是原来的文本
            vector.X += num3 + 5f;
            float num4 = innerDimensions.X + innerDimensions.Width - vector.X;
            DrawPanel( spriteBatch , vector , num4 );
            string arg = !GameCulture.FromCultureName( GameCulture.CultureName.English ).IsActive ? _data.CreationTime.ToShortDateString( ) : _data.CreationTime.ToString( "d MMMM yyyy" );
            string textValue2 = /*Language.GetTextValue("UI.WorldCreatedFormat", arg)*/"供奉Ekanda之地";
            Utils.DrawBorderString( spriteBatch , textValue2 , vector + new Vector2( num4 * 0.5f - FontAssets.MouseText.Value.MeasureString( textValue2 ).X * 0.5f , 3f ) , Color.White , 1f , 0f , 0f , -1 );
            vector.X += num4 + 5f;
        }
    }
}
