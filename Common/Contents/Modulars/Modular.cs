using System.Collections.Generic;
using System.IO;
using EternalResolve.Assets.Textures.Runes;
using EternalResolve.Common.Contents.Modulars.EkandaModular;
using EternalResolve.Common.Contents.Modulars.EkandaModular.UI;
using EternalResolve.Common.Contents.Modulars.ManaModular;
using EternalResolve.Common.Contents.Modulars.PrayModular;
using EternalResolve.Common.Contents.Modulars.RefineSystemModular;
using EternalResolve.Common.Contents.Modulars.RuneModular.Contents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace EternalResolve.Common.Contents.Modulars
{
    public class Modular : ModSystem
    {
        public static Modular Instace;

        /// <summary>
        /// 指示符印系统是否处于交互状态.
        /// </summary>
        public static bool RuneInteracting { get; set; } = false;

        /// <summary>
        /// 指示祈愿系统是否处于交互状态.
        /// </summary>
        public static bool PrayInteracting { get; set; } = false;

        /// <summary>
        /// 指示武器精炼系统是否处于唤出状态.
        /// </summary>
        public static bool RefineSystemInteracting { get; set; } = false;

        /// <summary>
        /// 指示EkandaUI是否处于唤出状态.
        /// </summary>
        public static bool EkandaInteracting { get; set; } = false;

        public static EkandaInterface EkandaInterface;

        public static RuneInterface RuneInterface;

        public static PrayInterface PrayInterface;

        public static RefineSystemInterface RefineSystemInterface;

        public static OtherSystemInterface OtherSystemInterface;

        public override void Load( )
        {
            Instace = this;
            base.Load( );
        }

        public override void PostSetupContent( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                RuneInterface = new RuneInterface( );
                RuneInterface.Initialization( );

                PrayInterface = new PrayInterface( );
                PrayInterface.Initialization( );

                OtherSystemInterface = new OtherSystemInterface( );
                OtherSystemInterface.Initialization( );

                EkandaInterface = new EkandaInterface( );
                EkandaInterface.Initialization( );

                RefineSystemInterface = new RefineSystemInterface( );
                RefineSystemInterface.Initialization( );
            }
            base.PostSetupContent( );
        }

        public override void UpdateUI( GameTime gameTime )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                OtherSystemInterface.Update( gameTime );
                if ( EkandaInteracting )
                    EkandaInterface.Update( gameTime );
                if ( RuneInteracting )
                    RuneInterface.Update( gameTime );
                if ( PrayInteracting )
                    PrayInterface.Update( gameTime );
                if ( !PrayInteracting && !RuneInteracting )
                    RefineSystemInterface.Update( gameTime );
            }
            base.UpdateUI( gameTime );
        }

        public override void PostDrawInterface( SpriteBatch spriteBatch )
        {
            RefineSystemInterface.Draw( Main.gameTimeCache );
            base.PostDrawInterface( spriteBatch );
        }

        public override void ModifyInterfaceLayers( List<GameInterfaceLayer> layers )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                layers.Insert( layers.FindIndex( layer => layer.Name.Equals( "Vanilla: Mouse Text" ) ) , new OtherSystemInterfaceDrawer( ) );
                layers.Insert( layers.FindIndex( layer => layer.Name.Equals( "Vanilla: Mouse Text" ) ) , new EkandaInterfaceDrawer( ) );
                layers.Add( new RuneInterfaceDrawer( ) );
                layers.Add( new PrayInterfaceDrawer( ) );
                layers.Add( new ChangeAnimation( ) );
            }
            base.ModifyInterfaceLayers( layers );
        }
    }

    public class OtherSystemInterfaceDrawer : GameInterfaceLayer
    {
        public OtherSystemInterfaceDrawer( ) : base( "EternalResolve:OtherSystem" , InterfaceScaleType.UI )
        {
        }
        protected override bool DrawSelf( )
        {
            Main.spriteBatch.End( );
            Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.NonPremultiplied , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null );
            Modular.OtherSystemInterface.Draw( Main.gameTimeCache );
            return true;
        }
    }

    public class EkandaInterfaceDrawer : GameInterfaceLayer
    {
        public EkandaInterfaceDrawer( ) : base( "EternalResolve:EkandaInterface" , InterfaceScaleType.UI )
        {
        }
        protected override bool DrawSelf( )
        {
            Main.spriteBatch.End( );
            Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.NonPremultiplied , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null );
            if ( Modular.EkandaInteracting )
                Modular.EkandaInterface.Draw( Main.gameTimeCache );
            return true;
        }
    }

    public class RuneInterfaceDrawer : GameInterfaceLayer
    {
        public RuneInterfaceDrawer( ) : base( "EternalResolve:RuneInterface" , InterfaceScaleType.UI )
        {
        }
        protected override bool DrawSelf( )
        {
            if ( Modular.RuneInteracting )
            {
                Main.spriteBatch.End( );
                Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.NonPremultiplied , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null );
                Modular.RuneInterface.Draw( Main.gameTimeCache );
                Main.spriteBatch.Draw( RuneAssets.RuneMouse , FrontDevice.Input.MousePosition , Color.White );
            }
            return true;
        }
    }

    public class PrayInterfaceDrawer : GameInterfaceLayer
    {
        public PrayInterfaceDrawer( ) : base( "EternalResolve:PrayInterface" , InterfaceScaleType.UI )
        {
        }
        protected override bool DrawSelf( )
        {
            if ( Modular.PrayInteracting )
            {
                Main.spriteBatch.End( );
                Main.spriteBatch.Begin( SpriteSortMode.Deferred , BlendState.NonPremultiplied , SamplerState.PointClamp , DepthStencilState.None , RasterizerState.CullNone , null );
                Modular.PrayInterface.Draw( Main.gameTimeCache );
                Main.spriteBatch.Draw( RuneAssets.RuneMouse , FrontDevice.Input.MousePosition , Color.White );
            }
            return true;
        }
    }

    public class ChangeAnimation : GameInterfaceLayer
    {
        static int Alpha = 0;
        public static void PlayChangeAnimation( )
        {
            Alpha = 255;
        }
        public ChangeAnimation( ) : base( "EternalResolve:ChangAnimation" , InterfaceScaleType.UI )
        {

        }
        protected override bool DrawSelf( )
        {
            if ( Alpha > 0 )
                Alpha -= 30;
            if ( Alpha <= 0 )
                Alpha = 0;
            Main.spriteBatch.Draw( TextureAssets.MagicPixel.Value , new Rectangle( 0 , 0 , Main.screenWidth , Main.screenHeight ) , new Color( 0 , 0 , 0 , Alpha ) );
            return true;
        }
    }
}
