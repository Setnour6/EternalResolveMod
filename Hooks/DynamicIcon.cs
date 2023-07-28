using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;
using Terraria.UI.Chat;

namespace EternalResolve.Hooks
{
    public class DynamicIcon
    {
        private static string[ ] myNewName;
        private static int nameFrame = 0, time = 0, iconFrame = 0;
        private static Asset<Texture2D>[ ] icon = new Asset<Texture2D>[ 48 ];

        public static void LoadData( )
        {
            string[ ] s = StringToArray( EternalResolve.Instance.Name + " v" + ( ( EternalResolve.Instance.Version != null ) ? EternalResolve.Instance.Version.ToString( ) : null ) );
            myNewName = StringToColorString(
                new Color[ ] { new Color(230,78 ,0), new Color(199, 100, 34), new Color(149 ,136, 89),new Color(109 ,165 ,134),
            new Color(81, 186 ,165),new Color(32 ,221 ,219),new Color(0 ,245 ,255)} , s );
            for ( int i = 0; i < icon.Length; i++ )
            {
                icon[ i ] = ModContent.Request<Texture2D>( "EternalResolve/Assets/Textures/Icons/Icon_" + i );
            }
            On.Terraria.Main.DrawMenu += Main_DrawMenu;
        }
        private static void Main_DrawMenu( On.Terraria.Main.orig_DrawMenu orig , Terraria.Main self , Microsoft.Xna.Framework.GameTime gameTime )
        {
            FieldInfo uiStateField = Main.MenuUI.GetType( ).GetField( "_history" , BindingFlags.NonPublic | BindingFlags.Instance );
            List<UIState> _history = (List<UIState>) uiStateField.GetValue( Main.MenuUI );
            UIState myMod = new UIState( );
            for ( int x = 0; x < _history.Count; x++ )
            {
                myMod = _history[ x ];
                if ( myMod.ToString( ) == "Terraria.ModLoader.UI.UIMods" )
                {
                    List<UIElement> elements = (List<UIElement>) myMod.GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( myMod );
                    List<UIElement> uiElements = (List<UIElement>) elements[ 0 ].GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( elements[ 0 ] );
                    UIPanel uiPanel = (UIPanel) uiElements[ 0 ];
                    List<UIElement> myModUIPanel = uiPanel.GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( uiPanel ) as List<UIElement>;
                    UIList uiList = (UIList) myModUIPanel[ 0 ];
                    List<UIElement> myUIModItem;
                    //Asset<Texture2D> icon;
                    for ( int i = 0; i < uiList._items.Count; i++ )
                    {
                        if ( uiList._items[ i ].GetType( ).GetField( "_mod" , BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( uiList._items[ i ] ).ToString( ) == EternalResolve.Instance.Name )
                        {
                            myUIModItem = (List<UIElement>) uiList._items[ i ].GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).GetValue( uiList._items[ i ] );

                            float _modIconAdjust = ( ModContent.Request<Texture2D>( "EternalResolve/icon" ).Value == null ? 0 : 85 );
                            UIElement badUnloader = myUIModItem.Find( ( UIElement e ) => e.ToString( ) == "Terraria.ModLoader.UI.UIHoverImage" && e.Top.Pixels == 3 );
                            for ( int j = 0; j < myUIModItem.Count; j++ )
                            {
                                string name = EternalResolve.Instance.DisplayName + " v" + ( ( EternalResolve.Instance.Version != null ) ? EternalResolve.Instance.Version.ToString( ) : null ),
                                    myName = myNewName[ myNewName.Length - 1 - nameFrame ];

                                if ( ( ( myUIModItem[ j ] is UIText ) && ( myUIModItem[ j ] as UIText ).Text == name ) || ( badUnloader != null && myUIModItem[ j ] is ModNameText ) )
                                {
                                    myUIModItem.RemoveAt( j );
                                    ModNameText modNameText = new ModNameText( myName , 1f , Color.White , FontAssets.MouseText.Value );
                                    modNameText.Left = new StyleDimension( _modIconAdjust + ( badUnloader == null ? 0f : 35f ) , 0f );
                                    modNameText.Top.Pixels = 5f;
                                    uiList._items[ i ].Append( modNameText );
                                }
                                else if ( myUIModItem[ j ] is ModNameText )
                                {
                                    ( (ModNameText) myUIModItem[ j ] ).Text = myName;
                                }
                                if ( myUIModItem[ j ] is UIImage )
                                {
                                    if ( ( myUIModItem[ j ].Width.Pixels == 104 && myUIModItem[ j ].Height.Pixels == 104 ) || ( myUIModItem[ j ].Width.Pixels == 80 && myUIModItem[ j ].Height.Pixels == 80 ) )
                                    {
                                        myUIModItem.RemoveAt( j );
                                        ModIcon modIcon = new ModIcon( icon[ iconFrame ].Value );
                                        modIcon.Left.Pixels = 0f;
                                        modIcon.Top.Pixels = 0f;
                                        uiList._items[ i ].Append( modIcon );
                                        ( modIcon as UIImage ).SetImage( icon[ iconFrame ] );
                                    }
                                }
                            }
                            uiList._items[ i ].GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).SetValue( uiList._items[ i ] , myUIModItem );
                        }
                    }
                    myModUIPanel[ 0 ] = uiList;
                    uiPanel.GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).SetValue( uiPanel , myModUIPanel );
                    uiElements[ 0 ] = uiPanel;
                    elements[ 0 ].GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).SetValue( elements[ 0 ] , uiElements );
                    myMod.GetType( ).GetField( "Elements" , BindingFlags.NonPublic | BindingFlags.Instance ).SetValue( myMod , elements );
                    _history[ x ] = myMod;
                    uiStateField.SetValue( Main.MenuUI , _history );
                }
            }
            time++;
            if ( time % 6 == 0 )
            {
                nameFrame++;
                iconFrame++;
                time = 0;
            }
            if ( nameFrame >= myNewName.Length )
                nameFrame = 0;
            if ( iconFrame > 47 )
                iconFrame = 0;

            orig( self , gameTime );
        }
        public static void UnLoad( )
        {
            On.Terraria.Main.DrawMenu -= Main_DrawMenu;
        }
        public static string[ ] StringToColorString( Color[ ] colors , string[ ] texts )
        {
            List<Color> sortColor = colors.ToList( );
            sortColor.Sort( ( now , next ) => ( now.R * 0.299f + now.G * 0.587f + now.B * 0.114f ).CompareTo( next.R * 0.299f + next.G * 0.587f + next.B * 0.114f ) );
            Color[ ] needColor = new Color[ sortColor.Count ];
            int iAdd = 0;
            int colorCount = needColor.Length / 2;
            for ( int i = 0; i <= colorCount; i++ )
            {
                if ( ( colorCount + i ) < needColor.Length )
                {
                    needColor[ colorCount + i ] = sortColor[ iAdd ];
                }
                if ( iAdd < ( sortColor.Count - 1 ) )
                    iAdd++;

                //if ((colorCount - i) > 0)
                {
                    needColor[ colorCount - i ] = sortColor[ iAdd ];
                }
                if ( iAdd < ( sortColor.Count - 1 ) )
                    iAdd++;
            }
            List<string> s = new List<string>( );
            string add;
            for ( int x = 0; x < needColor.Length; x++ )
            {
                add = "";
                for ( int i = 0; i < texts.Length; i++ )
                {
                    add += "[c/" + needColor[ ( x + i ) % needColor.Length ].Hex3( ) + ":" + texts[ i ] + "]";
                }
                s.Add( add );
            }
            return s.ToArray( );
        }
        public static string[ ] StringToArray( string text )
        {
            string[ ] s = new string[ text.Length ];
            for ( int i = 0; i < s.Length; i++ )
                s[ i ] = text[ i ].ToString( );
            return s;
        }
    }

    public class ModNameText : UIElement
    {
        public string Text;
        public float Size;
        public Color Color;
        public DynamicSpriteFont DynamicSpriteFont;
        public ModNameText( string text , float size , Color color , DynamicSpriteFont dynamicSpriteFont )
        {
            Text = text;
            Size = size;
            Color = color;
            DynamicSpriteFont = dynamicSpriteFont;
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            CalculatedStyle dimensions = GetDimensions( );
            ChatManager.DrawColorCodedStringWithShadow( spriteBatch , DynamicSpriteFont , Text , new Vector2( dimensions.X , dimensions.Y ) , Color , 0 , Vector2.Zero , new Vector2( Size ) );
            base.Draw( spriteBatch );
        }
    }

    public class ModIcon : UIImage
    {
        public Texture2D Icon;
        public ModIcon( Texture2D icon ) : base( icon )
        {
            Icon = icon;
            Width.Pixels = 104;
            Height.Pixels = 104;
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            CalculatedStyle dimensions = GetDimensions( );
            spriteBatch.Draw( Icon , new Rectangle( dimensions.X.ToInt( ) , dimensions.Y.ToInt( ) , 80 , 80 ) , Color.White );
        }
    }

}
