using Microsoft.Xna.Framework.Graphics;

namespace EternalResolve.Assets.Textures.StarTeleportPlatforms
{
    public class StarTeleprotPlatformAssets : ModAssets
    {
        public static Texture2D[ ] StarTeleportPlatFormParts = new Texture2D[ 13 ];

        public static Texture2D TeleprotPlatform;

        public override void Load( )
        {
            for ( int count = 0; count < StarTeleportPlatFormParts.Length; count++ )
            {
                StarTeleportPlatFormParts[ count ] = GetAsset( "StarTeleportPlatFormPart" + count );
            }
            TeleprotPlatform = GetAsset( "TeleprotPlatform" );
            base.Load( );
        }
        public static Texture2D GetAsset( string name )
        {
            return ModAssetsLoader.GetTexture( "Textures/StarTeleportPlatforms/" + name ).Value;
        }
    }
}
