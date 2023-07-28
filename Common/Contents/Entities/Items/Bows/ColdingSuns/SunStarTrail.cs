using EternalResolve.Assets.Textures.Extras;
using EternalResolve.Common.Graphics.Vertexs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.ColdingSuns
{
    public class SunStarTrail : ERProjectile
    {
        public override void SetDefaults( )
        {
            ToProjectile( 2 , 2 );
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 20;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            base.SetDefaults( );
        }
        public override void AI( )
        {
            if ( NPC.downedMechBoss1 )
                Projectile.aiStyle = -1;
            if ( NPC.downedMechBoss2 )
                Projectile.extraUpdates = 2;

            for ( int count = 0; count < 5; count++ )
                Dust.NewDust( Projectile.position , 0 , 0 , DustID.WitherLightning , Projectile.velocity.X * 0.01f , Projectile.velocity.Y * 0.01f , 100 , new Color( 255 , 255 , 255 , 30 ) , 0.05f );

            for ( int i = Projectile.oldPos.Length - 1; i > 0; --i )
                Projectile.oldRot[ i ] = Projectile.oldRot[ i - 1 ];
            Projectile.oldRot[ 0 ] = Projectile.rotation;

            if ( Projectile.velocity != Vector2.Zero )
                Projectile.rotation = Projectile.velocity.ToRotation( );
            if ( Projectile.oldPos[ 19 ] == Projectile.position )
                Projectile.Kill( );
            if ( Projectile.velocity == Vector2.Zero )
                Dust.NewDust( Projectile.position , 0 , 0 , DustID.TintableDustLighted
                    , Main.rand.NextFloatDirection( ) , Main.rand.NextFloatDirection( ) , 100 , new Color( 255 , 255 , 255 , 30 ) , 1f );

            base.AI( );
        }
        public override void PostDraw( Color lightColor )
        {
            if ( !NPC.downedBoss3 )
            {
                default( TrailDrawer ).Draw( Projectile , Color.Blue , 2.8f , 40f , ExtraAssets.Extra[ 13 ] , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 4 ] );
            }
            else
            {
                default( TrailDrawer ).Draw( Projectile , Color.Gold , 2.8f , 40f , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 3 ] , ExtraAssets.Extra[ 4 ] );
            }
            base.PostDraw( lightColor );
        }
    }
}