using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos.YoyoProjectiles
{
    public class GelYoyo : ModProjectile
    {
        public override void SetStaticDefaults( )
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ Projectile.type ] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[ Projectile.type ] = 200f;
            ProjectileID.Sets.YoyosTopSpeed[ Projectile.type ] = 16f;
        }
        public override void SetDefaults( )
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.scale = 1f;
        }
        public override void AI( )
        {
            float num = Projectile.Center.X;
            float num2 = Projectile.Center.Y;
            float num3 = 600f;
            bool flag = false;
            for ( int i = 0; i < 200; i++ )
            {
                if ( Main.npc[ i ].CanBeChasedBy( Projectile , false ) && Collision.CanHit( Projectile.Center , 1 , 1 , Main.npc[ i ].Center , 1 , 1 ) )
                {
                    float num4 = Main.npc[ i ].position.X + (float) ( Main.npc[ i ].width / 2 );
                    float num5 = Main.npc[ i ].position.Y + (float) ( Main.npc[ i ].height / 2 );
                    float num6 = Math.Abs( Projectile.position.X + (float) ( Projectile.width / 2 ) - num4 ) + Math.Abs( Projectile.position.Y + (float) ( Projectile.height / 2 ) - num5 );
                    if ( num6 < num3 )
                    {
                        num3 = num6;
                        num = num4;
                        num2 = num5;
                        flag = true;
                    }
                }
            }
            if ( flag )
            {
                float num10 = 18f;
                Vector2 vector = new Vector2( Projectile.position.X + (float) Projectile.width * 0.5f , Projectile.position.Y + (float) Projectile.height * 0.5f );
                float num7 = num - vector.X;
                float num8 = num2 - vector.Y;
                float num9 = (float) Math.Sqrt( (double) ( num7 * num7 + num8 * num8 ) );
                num9 = num10 / num9;
                num7 *= num9;
                num8 *= num9;
                Projectile.velocity.X = ( Projectile.velocity.X * 20f + num7 ) / 21f;
                Projectile.velocity.Y = ( Projectile.velocity.Y * 20f + num8 ) / 21f;
            }
        }
    }
}