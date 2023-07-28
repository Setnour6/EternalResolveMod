using EternalResolve.Assets.Textures.Systems.RefineSystems;
using EternalResolve.Common.Codes.UI;
using EternalResolve.Common.Codes.UI.Contents;
using EternalResolve.Common.Codes.UI.Events;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSystemButton : TextureButton
    {
        public override void Initialization( )
        {
            SetSize( 172 , 56 );
            Texture = RefineAssets.Button;
            base.Initialization( );
        }
        public override void PreUpdate( )
        {
            Color = Microsoft.Xna.Framework.Color.White;
            base.PreUpdate( );
        }
        public override void LeftPressed( UIMouseEvent mouseEvent , Control element )
        {
            Color = Microsoft.Xna.Framework.Color.Gray;
            base.LeftPressed( mouseEvent , element );
        }
    }
}
