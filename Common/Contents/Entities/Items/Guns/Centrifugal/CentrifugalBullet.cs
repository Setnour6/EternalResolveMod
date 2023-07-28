using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.Centrifugal
{
    public class CentrifugalBullet : ERProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "渺纱之星" );
            ProjectileID.Sets.TrailCacheLength[ Projectile.type ] = 11;
            ProjectileID.Sets.TrailingMode[ Projectile.type ] = 0;
        }
        public override void SetDefaults( )
        {
            ToProjectile( 2 , 2 );
            Projectile.penetrate = 10;
        }
        int whoAmlCache = 0;
        int count = 0;
        public override void AI( )
        {
            if ( count < 1 )
            {
                int whoAml = Projectile.NewProjectile( null , Projectile.position , Projectile.velocity ,
                    ModContent.ProjectileType<CentrifugalBullet_Effect>( ) , 0 , 0 , Projectile.owner , 0 , 0 );
                count = 1;
                whoAmlCache = whoAml;
            }
            base.AI( );
        }
        public override void ModifyHitNPC( NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            target.buffImmune[ BuffID.Frostburn ] = false;
            target.AddBuff( BuffID.Frostburn , 120 );
            Projectile.NewProjectile( null , Projectile.position , Vector2.Zero , // is it better to use a different entity source?
                ModContent.ProjectileType<CentrifugalBullet_HitEffect>( ) , 0 , 0 , Projectile.owner , Main.rand.NextFloat( ) * 3.1415926f , 0 );
            base.ModifyHitNPC( target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
        public override void Kill( int timeLeft )
        {
            Main.projectile[ whoAmlCache ].velocity = Vector2.Zero;
            Projectile.NewProjectile( null , Projectile.position , Vector2.Zero ,
                ModContent.ProjectileType<CentrifugalBullet_HitEffect>( ) , 0 , 0 , Projectile.owner , Main.rand.NextFloat( ) * 3.1415926f , 0 );
            base.Kill( timeLeft );
        }
    }
}