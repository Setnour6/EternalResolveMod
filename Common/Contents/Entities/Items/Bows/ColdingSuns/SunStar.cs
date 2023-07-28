using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.ColdingSuns
{
    public class SunStar : ERProjectile
    {
        public override void SetDefaults( )
        {
            ToProjectile( 9 , 9 );
            Projectile.tileCollide = true;
            Projectile.aiStyle = 1;
            Projectile.light = 0.8f;
            Projectile.localNPCHitCooldown = 12;
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 10;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 2;
            base.SetDefaults( );
        }
        int whoAmlCache = 0;
        int count = 0;
        public override void AI( )
        {
            if ( NPC.downedMechBoss1 )
                Projectile.aiStyle = -1;
            if ( NPC.downedMechBoss2 )
                Projectile.extraUpdates = 2;

            if ( count < 1 )
            {
                ModUtils.DustCircle( DustID.TintableDustLighted , Projectile.Center , 2 , 360 );
                int whoAml = Projectile.NewProjectile( Projectile.GetSource_FromAI() , Projectile.Center , Projectile.velocity ,
                    ModContent.ProjectileType<SunStarTrail>( ) , 0 , 0 , Projectile.owner , 0 , 0 );
                count = 1;
                whoAmlCache = whoAml;
            }
            if ( Projectile.velocity != Vector2.Zero )
                Projectile.rotation = Projectile.velocity.ToRotation( );
            Main.projectile[ whoAmlCache ].velocity = Projectile.velocity;
            base.AI( );
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            if ( NPC.downedSlimeKing )
            {
                if ( target.buffImmune[ BuffID.OnFire ] )
                    target.buffImmune[ BuffID.OnFire ] = false;
                target.AddBuff( BuffID.OnFire , 60 );
            }
            if ( NPC.downedEmpressOfLight )
            {
                if ( target.buffImmune[ BuffID.OnFire3 ] )
                    target.buffImmune[ BuffID.OnFire3 ] = false;
                target.AddBuff( BuffID.OnFire3 , 120 );
            }
            ModUtils.DustCircle( DustID.TintableDustLighted , Projectile.position , 0.1f , 360 );
            base.OnHitNPC( target , damage , knockback , crit );
        }
        public override void Kill( int timeLeft )
        {
            Main.projectile[ whoAmlCache ].velocity = Vector2.Zero;
            ModUtils.DustCircle( DustID.TintableDustLighted , Projectile.position , 0.1f , 360 );

            base.Kill( timeLeft );
        }
        public override bool PreDraw( ref Color lightColor )
        {
            return false;
        }
        public override void PostDraw( Color lightColor )
        {
            Main.spriteBatch.Draw( TextureAssets.Projectile[ Projectile.type ].Value ,
    Projectile.position - TextureAssets.Projectile[ Projectile.type ].Value.Size( ) / 2 + Vector2.One * 4.5f , Color.White );
            base.PostDraw( lightColor );
        }
    }
}