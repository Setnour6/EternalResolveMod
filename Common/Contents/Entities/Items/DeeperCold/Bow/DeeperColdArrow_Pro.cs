using EternalResolve.Assets.Textures.Extras;
using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Graphics.Vertexs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.DeeperCold.Bow
{
    public class DeeperColdArrow_Pro : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "深寒箭" ); // The English name of the projectile
            DisplayName.AddTranslation( English , "Deeper Cold Arrow" ); // The English name of the projectile
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 10;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 4 , 4 );
            Projectile.tileCollide = false;
            Projectile.penetrate = 10;
            Projectile.extraUpdates = 2;
            base.SetDefaults( );
        }
        public override void ModifyHitNPC( NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Main.player[ Projectile.owner ].ZoneSnow )
                crit = true;
            target.buffImmune[ BuffID.Frostburn ] = false;
            target.AddBuff( BuffID.Frostburn , 180 );
            base.ModifyHitNPC( target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
        public override void AI( )
        {
            Projectile.rotation = Projectile.velocity.ToRotation( );
            Projectile.ai[ 0 ]++;
            if ( Projectile.ai[ 0 ] <= 6 )
            {
                Projectile.velocity *= 1.08f;
            }
            else
                Projectile.velocity *= 0.93f;

            if ( Projectile.velocity.Length( ) < 2f )
            {
                Projectile.ai[ 1 ]++;
            }
            if ( Projectile.ai[ 1 ] >= 36 )
            {
                Projectile.alpha += 15;
            }
            if ( Projectile.alpha >= 254 )
                Projectile.Kill( );

            base.AI( );
        }
        public override bool PreDraw( ref Color lightColor )
        {
            TrailDrawer trailDrawer = new TrailDrawer( );
            trailDrawer.Projectile = Projectile;
            trailDrawer.Texture0 = ExtraAssets.Extra[ 13 ];
            trailDrawer.Texture1 = ExtraAssets.Extra[ 13 ];
            trailDrawer.Texture2 = ExtraAssets.Extra[ 13 ];
            trailDrawer.TrailColor = Color.CadetBlue;
            trailDrawer.Opacity = 3f;
            trailDrawer.Saturation = 1.0f;
            trailDrawer.Width = 32;
            trailDrawer.Draw( );
            return false;
        }
        public override void Kill( int timeLeft )
        {
            ModUtils.DustCircle( DustID.TintableDustLighted , Projectile.position , 0.3f , 360 );
            base.Kill( timeLeft );
        }
    }
}