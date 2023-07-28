using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Npcs.Bosses.Eye.Contents
{
    public class RealEye_CustomSky : CustomSky
    {
        private bool isActive = false;
        private float intensity = 0f;
        public override void Update( GameTime gameTime )
        {
            if ( intensity < 1f )
            {
                intensity += 0.01f;
            }
        }
        public override void Reset( )
        {
            isActive = false;
            intensity -= 0.01f;
        }
        public override bool IsActive( )
        {
            if ( Main.gameMenu )
            {
                intensity -= 0.01f;
                if ( intensity < 0f )
                {
                    intensity = 0f;
                    Deactivate( );
                }
            }
            return isActive;
        }
        public override void Activate( Vector2 position , params object[ ] args )
        {
            isActive = true;
            if ( intensity >= 1 )
                intensity = 1;
        }
        public override void Draw( SpriteBatch spriteBatch , float minDepth , float maxDepth )
        {
            if ( maxDepth >= 0 && minDepth < 0 )
            {
                Main.spriteBatch.Draw(
                    TextureAssets.BlackTile.Value ,
                    new Rectangle( 0 , 0 , Main.screenWidth , Main.screenHeight ) ,
                     Color.Black * intensity * 0.4f );
            }
            if ( maxDepth >= 0.01f && minDepth < 0.05f )
            {
                Texture2D tex = ModContent.Request<Texture2D>( "EternalResolve/Assets/Textures/Sky/RealEyeSky" ).Value;
                Main.spriteBatch.Draw( tex , new Rectangle( 0 , 0 , Main.screenWidth , Main.screenHeight ) , Color.White * intensity );
            }
        }
        public override void Deactivate( params object[ ] args )
        {
            isActive = false;
        }
        public override Color OnTileColor( Color inColor )
        {
            return Color.Purple;
        }
        public override float GetCloudAlpha( )
        {
            return 0f;
        }
    }
}