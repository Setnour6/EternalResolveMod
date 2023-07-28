using EternalResolve.Common.Contents.Entities.Npcs.Bosses.Treacherous.Contents;
using EternalResolve.Common.Graphics.Replaces;
using EternalResolve.Hooks;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve
{
    /// <summary>
    /// 模组主类.
    /// </summary>
    public class EternalResolve : Mod
    {
        /// <summary>
        /// 实例.
        /// </summary>
        public static EternalResolve Instance { get; set; }

        public static GameCulture Chinese = GameCulture.FromCultureName( GameCulture.CultureName.Chinese );

        public static GameCulture English = GameCulture.FromCultureName( GameCulture.CultureName.English );

        public EternalResolve( )
        {
            Instance = this;
        }

        public override void Load( )
        {
            //  string dt = TimeInformation.GetNetDateTime( );
            // TimeInformation.Now = Convert.ToDateTime( dt );
            if ( FrontDevice.Game.Sever )
                return;
            DirectoryCheck.LoadData( );
            DynamicIcon.LoadData( );
            SkyManager.Instance[ "EternalResolve:RealEyeCustomSky" ] = new RealEye_CustomSky( );
            base.Load( );
        }

        public override void PostSetupContent( )
        {
            if ( FrontDevice.Game.Sever )
                return;
            ReplaceSystem.PostSetupContent( );
            base.PostSetupContent( );
        }

        public override void Unload( )
        {
            if ( FrontDevice.Game.Sever )
                return;
            ReplaceSystem.Unload( );
            DynamicIcon.UnLoad( );
            base.Unload( );
        }
    }
}