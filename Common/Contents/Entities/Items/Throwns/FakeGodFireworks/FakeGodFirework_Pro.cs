using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Throwns.FakeGodFireworks
{
    public class FakeGodFirework_Pro : ERProjectile
    {
        public override void SetDefaults( )
        {
            ToProjectile( 26 , 26 );
            Projectile.aiStyle = 1;
            base.SetDefaults( );
        }
        public override void AI( )
        {
            for ( int count = 0; count < 6; count++ )
                Dust.NewDustPerfect( Projectile.Center , DustID.Shadowflame , -Projectile.velocity / 4 , 120 );
            base.AI( );
        }
        public override void Kill( int timeLeft )
        {
            for ( int count = 0; count < 16; count++ )
                Dust.NewDust( Projectile.Center , 0 , 0 , DustID.Shadowflame , Main.rand.NextVector2Unit( ).X * 16 , Main.rand.NextVector2Unit( ).Y * 16 , 120 );
            for ( int count = 0; count < 16; count++ )
                Dust.NewDust( Projectile.Center , 0 , 0 , DustID.Shadowflame , -Projectile.velocity.X / 4 , -Projectile.velocity.Y / 4 , 120 );
            base.Kill( timeLeft );
        }
        public override void ModifyHitNPC( NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            Engine.PlaySound( SoundID.Item45 , Projectile.Center );
            target.StrikeNPC( damage / 2 , 0 , 0 , true );
            target.AddBuff( BuffID.ShadowFlame , 120 );
            if ( crit )
            {
                Projectile.NewProjectile( null ,
                    target.Center , -Vector2.UnitY * 10 , 496 , damage , knockback , Projectile.owner , 0 , 0 );
            }
            base.ModifyHitNPC( target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
}