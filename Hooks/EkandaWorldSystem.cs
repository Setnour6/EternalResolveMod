using EternalResolve.Common.Codes.UI.Events;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using ReLogic.OS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.GameContent.UI.States;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI;
using UIMouseEvent = Terraria.UI.UIMouseEvent;

namespace EternalResolve.Hooks
{
    public class EkandaWorldSystem : ModSystem
    {
        public override void Load( )
        {
          //  On.Terraria.GameContent.UI.States.UIWorldSelect.UpdateWorldsList += UIWorldSelect_UpdateWorldsList;
            base.Load( );
        }
        public override void Unload( )
        {
        //    On.Terraria.GameContent.UI.States.UIWorldSelect.UpdateWorldsList -= UIWorldSelect_UpdateWorldsList;
            base.Unload( );
        }
        private void UIWorldSelect_UpdateWorldsList( On.Terraria.GameContent.UI.States.UIWorldSelect.orig_UpdateWorldsList orig , Terraria.GameContent.UI.States.UIWorldSelect self )
        {
            UIList _worldList = (UIList) typeof( UIWorldSelect ).GetField( "_worldList" , BindingFlags.Instance | BindingFlags.NonPublic ).GetValue( self );
            _worldList.Clear( );
            IOrderedEnumerable<WorldFileData> orderedEnumerable = new List<WorldFileData>( Main.WorldList ).OrderByDescending( new Func<WorldFileData , bool>( ( fileData ) => (bool) typeof( UIWorldSelect ).GetMethod( "CanWorldBePlayed" , BindingFlags.Instance | BindingFlags.NonPublic ).Invoke( self , new object[ ] { fileData } ) ) ).ThenByDescending( ( WorldFileData x ) => x.IsFavorite ).ThenBy( ( WorldFileData x ) => x.Name ).ThenBy( ( WorldFileData x ) => x.GetFileName( true ) );
            int num = 0;
            foreach ( WorldFileData item in orderedEnumerable )
            {
                if ( item.GetFileName( ).Contains( "Ekanda_sub" ) )
                {
                    item.Name = "Ekanda 神殿";
                    EkandaWorldListItem worldListItem = new EkandaWorldListItem( item , num++ , (bool) typeof( UIWorldSelect ).GetMethod( "CanWorldBePlayed" , BindingFlags.Instance | BindingFlags.NonPublic ).Invoke( self , new object[ ] { item } ) );
                //    worldListItem.SetIcon( ModContent.Request<Texture2D>( "Common/Systems/UIElements/IconCorruption" , AssetRequestMode.ImmediateLoad ) );
                    _worldList.Add( worldListItem );
                }
                else
                    _worldList.Add( new UIWorldListItem( item , num++ , (bool) typeof( UIWorldSelect ).GetMethod( "CanWorldBePlayed" , BindingFlags.Instance | BindingFlags.NonPublic ).Invoke( self , new object[ ] { item } ) ) );
            }
            if ( !orderedEnumerable.Any( ) )
            {
                string vanillaWorldsPath = Path.Combine( ReLogic.OS.Platform.Get<IPathService>( ).GetStoragePath( "Terraria" ) , "Worlds" );
                bool _currentlyMigratingFiles = (bool) typeof( UIWorldSelect ).GetField( "_currentlyMigratingFiles" , BindingFlags.Static | BindingFlags.NonPublic ).GetValue( null );
                if ( Directory.Exists( vanillaWorldsPath ) && Directory.GetFiles( vanillaWorldsPath , "*.wld" ).Any<string>( ) )
                {
                    UIPanel autoMigrateButton = new UIPanel( );
                    autoMigrateButton.Width.Set( 0f , 1f );
                    autoMigrateButton.Height.Set( 50f , 0f );
                    UIText migrateText = new UIText( ( !_currentlyMigratingFiles ) ? Language.GetText( "tModLoader.MigrateWorldsText" ) : Language.GetText( "tModLoader.MigratingWorldsText" ) , 1f , false );
                    autoMigrateButton.OnClick += delegate ( UIMouseEvent a , UIElement b )
                    {
                        if ( !_currentlyMigratingFiles )
                        {
                            typeof( UIWorldSelect ).GetField( "_currentlyMigratingFiles" , BindingFlags.Static | BindingFlags.NonPublic ).SetValue( null , true );
                            migrateText.SetText( Language.GetText( "tModLoader.MigratingWorldsText" ) );
                            TaskFactory factory = Task.Factory;
                            factory.StartNew( delegate ( )
                            {
                                IEnumerable<string> vanillaWorldFiles = from s in Directory.GetFiles( vanillaWorldsPath , "*.*" )
                                                                        where s.EndsWith( ".wld" ) || s.EndsWith( ".twld" ) || s.EndsWith( ".bak" )
                                                                        select s;
                                foreach ( string file in vanillaWorldFiles )
                                {
                                    File.Copy( file , Path.Combine( Main.WorldPath , Path.GetFileName( file ) ) , true );
                                }
                                typeof( UIWorldSelect ).GetField( "_currentlyMigratingFiles" , BindingFlags.Static | BindingFlags.NonPublic ).SetValue( null , false );
                                Main.menuMode = 6;
                            } , TaskCreationOptions.PreferFairness );
                        }
                    };
                    autoMigrateButton.Append( migrateText );
                    _worldList.Add( autoMigrateButton );
                    UIText noWorldsMessage = new UIText( Language.GetText( "tModLoader.MigrateWorldsMessage" ) , 1f , false );
                    noWorldsMessage.Width.Set( 0f , 1f );
                    noWorldsMessage.Height.Set( 300f , 0f );
                    noWorldsMessage.MarginTop = 20f;
                    noWorldsMessage.OnClick += delegate ( UIMouseEvent a , UIElement b )
                    {
                        Utils.OpenFolder( Main.WorldPath );
                        Utils.OpenFolder( vanillaWorldsPath );
                    };
                    _worldList.Add( noWorldsMessage );
                }
            }
            typeof( UIWorldSelect ).GetField( "_worldList" , BindingFlags.Instance | BindingFlags.NonPublic ).SetValue( self , _worldList );
        }
    }
}
