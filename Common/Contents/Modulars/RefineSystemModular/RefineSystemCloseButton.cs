using EternalResolve.Assets.Textures.Systems.RefineSystems;
using EternalResolve.Common.Codes.UI.Contents;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSystemCloseButton : TextureButton
    {
        public override void Initialization( )
        {
            SetSize( 20 , 20 );
            Texture = RefineAssets.Close;
            base.Initialization( );
        }
    }
}
