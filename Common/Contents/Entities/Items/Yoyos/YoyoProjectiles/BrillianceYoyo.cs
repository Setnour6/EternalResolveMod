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
    public class BrillianceYoyo : ModProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.CloneDefaults( 549 );
            Projectile.width = 16;
            Projectile.scale = 1.1f;
            Projectile.height = 16;
            Projectile.light = 0.65f;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 99;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 15;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ Projectile.type ] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[ Projectile.type ] = 400f;
            ProjectileID.Sets.YoyosTopSpeed[ Projectile.type ] = 26f;
        }
        public override void AI( )
        {
            Projectile.rotation = Utils.ToRotation( Projectile.velocity );
            base.AI( );
        }
        public override void PostDraw( Color lightColor )
        {
            Texture2D image = TextureAssets.Projectile[ Projectile.type ].Value;
            Main.spriteBatch.End( );
            default( TrailDrawer ).Draw( Projectile , Color.Gold , 2.8f , 40f , ExtraAssets.Extra[ 13 ] , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 7 ] );
            Main.spriteBatch.Begin( );
            Main.spriteBatch.Draw( image , Projectile.Center - Main.screenPosition , null , Color.White , (float) Projectile.rotation * 3.14f / 4f , Projectile.Size / 2f , 1f , SpriteEffects.None , 1f );
            base.PostDraw( lightColor );
        }
    }
}