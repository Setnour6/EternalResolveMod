using EternalResolve.Assets.Textures.Extras;
using EternalResolve.Common.Graphics.Vertexs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos.YoyoProjectiles
{
    public class TerraYoyo : ModProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.CloneDefaults( 550 );
            Projectile.width = 16;
            Projectile.scale = 1.1f;
            Projectile.height = 16;
            Projectile.light = 0.65f;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 99;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 30;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ Projectile.type ] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[ Projectile.type ] = 600f;
            ProjectileID.Sets.YoyosTopSpeed[ Projectile.type ] = 32f;
        }
        public override void AI( )
        {
            Projectile.ai[ 1 ] += 1f;
            rot++;
            if ( Projectile.ai[ 1 ] % 6f == 0f )
            {
                Projectile.NewProjectile( null , Projectile.Center.X , Projectile.Center.Y , Main.rand.Next( -5 , 5 ) , Main.rand.Next( -5 , 5 ) , 604 , 70 , 3f , Projectile.owner , 0f , 0f ); // is it better to use a different entity source?
                Projectile.ai[ 1 ] = 0f;
            }
            Projectile.rotation = Utils.ToRotation( Projectile.velocity ) + 3.1415926f / 180 * 45;
        }
        public override void PostDraw( Color lightColor )
        {
            Texture2D image = TextureAssets.Projectile[ Projectile.type ].Value;
            default( TrailDrawer ).Draw( Projectile , Color.GreenYellow , 2.8f , 40f , ExtraAssets.Extra[ 13 ] , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 7 ] );
            Main.spriteBatch.Draw( image , Projectile.Center - Main.screenPosition , null , Color.White , rot * 3.14f / 4f , Projectile.Size / 2f , 1f , SpriteEffects.None , 1f );
            base.PostDraw( lightColor );
        }
        private int rot;
    }
}