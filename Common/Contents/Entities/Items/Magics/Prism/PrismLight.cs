using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.Prism
{
    public class PrismLight : ModProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.width = 18;
            Projectile.height = 18;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 0;
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            target.immune[ Projectile.owner ] = 5;
        }
        public override void AI( )
        {
            Vector2? vector = default;
            if ( Utils.HasNaNs( Projectile.velocity ) || Projectile.velocity == Vector2.Zero )
            {
                Projectile.velocity = -Vector2.UnitY;
            }
            if ( Projectile.type != ModContent.ProjectileType<PrismLight>( ) || !Main.projectile[ (int) Projectile.ai[ 1 ] ].active || Main.projectile[ (int) Projectile.ai[ 1 ] ].type != ModContent.ProjectileType<PrismLightProjectile>( ) )
            {
                Projectile.Kill( );
                return;
            }
            float num = (float) (int) Projectile.ai[ 0 ] - 2.5f;
            Vector2 value = Vector2.Normalize( Main.projectile[ (int) Projectile.ai[ 1 ] ].velocity );
            Projectile projectile = Main.projectile[ (int) Projectile.ai[ 1 ] ];
            float num2 = num * 0.5235988f;
            Vector2 value2 = Vector2.Zero;
            float num3;
            float y;
            float num4;
            float scaleFactor;
            if ( projectile.ai[ 0 ] < 180f )
            {
                num3 = 1f - projectile.ai[ 0 ] / 180f;
                y = 20f - projectile.ai[ 0 ] / 180f * 14f;
                if ( projectile.ai[ 0 ] < 120f )
                {
                    num4 = 20f - 4f * ( projectile.ai[ 0 ] / 120f );
                    Projectile.Opacity = projectile.ai[ 0 ] / 120f * 0.4f;
                }
                else
                {
                    num4 = 16f - 10f * ( ( projectile.ai[ 0 ] - 120f ) / 60f );
                    Projectile.Opacity = 0.4f + ( projectile.ai[ 0 ] - 120f ) / 60f * 0.6f;
                }
                scaleFactor = -22f + projectile.ai[ 0 ] / 180f * 20f;
            }
            else
            {
                num3 = 0f;
                num4 = 1.75f;
                y = 6f;
                Projectile.Opacity = 1f;
                scaleFactor = -2f;
            }
            float num5 = ( projectile.ai[ 0 ] + num * num4 ) / ( num4 * 6f ) * 6.2831855f;
            num2 = Vector2.UnitY.RotatedBy( num5 , default ).Y * 0.5235988f * num3;
            value2 = ( Vector2.UnitY.RotatedBy( num5 , default ) * new Vector2( 4f , y ) ).RotatedBy( projectile.velocity.ToRotation( ) , default );
            Projectile.position = projectile.Center + value * 16f - Projectile.Size / 2f + new Vector2( 0f , -Main.projectile[ (int) Projectile.ai[ 1 ] ].gfxOffY );
            Projectile.position += projectile.velocity.ToRotation( ).ToRotationVector2( ) * scaleFactor;
            Projectile.position += value2;
            Projectile.velocity = Vector2.Normalize( projectile.velocity ).RotatedBy( num2 , default );
            Projectile.scale = 1.8f * ( 1f - num3 );
            Projectile.damage = projectile.damage;
            if ( projectile.ai[ 0 ] >= 180f )
            {
                Projectile.damage *= 3;
                vector = new Vector2?( projectile.Center );
            }
            if ( !Collision.CanHitLine( Main.player[ Projectile.owner ].Center , 0 , 0 , projectile.Center , 0 , 0 ) )
            {
                vector = new Vector2?( Main.player[ Projectile.owner ].Center );
            }
            Projectile.friendly = projectile.ai[ 0 ] > 30f;
            if ( Utils.HasNaNs( Projectile.velocity ) || Projectile.velocity == Vector2.Zero )
            {
                Projectile.velocity = -Vector2.UnitY;
            }
            float num6 = Utils.ToRotation( Projectile.velocity );
            Projectile.rotation = num6 - 1.5707964f;
            Projectile.velocity = num6.ToRotationVector2( );
            float num7 = 2f;
            float num8 = 0f;
            Vector2 vector2 = Projectile.Center;
            if ( vector != null )
            {
                vector2 = vector.Value;
            }
            float[ ] array = new float[ (int) num7 ];
            Collision.LaserScan( vector2 , Projectile.velocity , num8 * Projectile.scale , 2400f , array );
            float num9 = 0f;
            for ( int i = 0; i < array.Length; i++ )
            {
                num9 += array[ i ];
            }
            num9 /= num7;
            float amount = 0.75f;
            Projectile.localAI[ 1 ] = MathHelper.Lerp( Projectile.localAI[ 1 ] , num9 , amount );
            if ( Math.Abs( Projectile.localAI[ 1 ] - num9 ) < 100f && Projectile.scale > 0.15f )
            {
                Color color = Main.hslToRgb( 16.94f , 1f , 0.902f );
                color.A = 16;
                Vector2 vector3 = Projectile.Center + Projectile.velocity * ( Projectile.localAI[ 1 ] - 14.5f * Projectile.scale );
                float x = Main.rgbToHsl( new Color( 255 , 250 , 205 ) ).X;
                for ( int j = 0; j < 2; j++ )
                {
                    float num10 = Utils.ToRotation( Projectile.velocity ) + ( Main.rand.Next( 2 ) == 1 ? -1f : 1f ) * 1.5707964f;
                    float num11 = (float) Main.rand.NextDouble( ) * 0.8f + 1f;
                    Vector2 vector4 = new Vector2( (float) Math.Cos( num10 ) * num11 , (float) Math.Sin( num10 ) * num11 );
                    int num12 = Dust.NewDust( vector3 , 0 , 0 , 261 , vector4.X , vector4.Y , 0 , new Color( 255 , 250 , 205 ) , 1f );
                    Main.dust[ num12 ].color = color;
                    Main.dust[ num12 ].scale = 1.1f;
                    if ( Projectile.scale > 1f )
                    {
                        Main.dust[ num12 ].velocity *= Projectile.scale;
                        Main.dust[ num12 ].scale *= Projectile.scale;
                    }
                    Main.dust[ num12 ].noGravity = true;
                    if ( Projectile.scale != 1.4f )
                    {
                        Dust dust = Dust.CloneDust( num12 );
                        dust.color = Color.Orange;
                        dust.scale /= 2f;
                    }
                    float num13 = ( x + Main.rand.NextFloat( ) * 0.4f ) % 1f;
                    Main.dust[ num12 ].color = Color.Lerp( color , Main.hslToRgb( 0.54f , 1f , 0.902f ) , Projectile.scale / 1.4f );
                }
                if ( Main.rand.Next( 5 ) == 0 )
                {
                    Vector2 value3 = Utils.RotatedBy( Projectile.velocity , 1.5707963705062866 , default( Vector2 ) ) * ( (float) Main.rand.NextDouble( ) - 0.5f ) * (float) Projectile.width;
                    int num14 = Dust.NewDust( vector3 + value3 - Vector2.One * 4f , 8 , 8 , 261 , 0f , 0f , 100 , new Color( 255 , 250 , 205 ) , 1f );
                    Main.dust[ num14 ].velocity *= 0.5f;
                    Main.dust[ num14 ].velocity.Y = -Math.Abs( Main.dust[ num14 ].velocity.Y );
                }
                DelegateMethods.v3_1 = color.ToVector3( ) * 0.3f;
                float num15 = 0.1f * (float) Math.Sin( (double) ( Main.time * 20f ) );
                Vector2 vector5 = new Vector2( Projectile.velocity.Length( ) * Projectile.localAI[ 1 ] , (float) Projectile.width * Projectile.scale );
                float num16 = Utils.ToRotation( Projectile.velocity );
                Utils.PlotTileLine( Projectile.Center , Projectile.Center + Projectile.velocity * Projectile.localAI[ 1 ] , (float) Projectile.width * Projectile.scale , new Utils.TileActionAttempt( DelegateMethods.CastLight ) );
                return;
            }
        }
        public override bool PreDraw( ref Color lightColor )
        {
            if ( Projectile.velocity == Vector2.Zero )
            {
                return false;
            }
            Texture2D texture2D = TextureAssets.Projectile[ Projectile.type ].Value;
            float num = Projectile.localAI[ 1 ];
            Color value = Main.hslToRgb( 1f , 1f , 1f );
            value.A = 0;
            Vector2 value2 = Utils.Floor( Projectile.Center );
            value2 += Projectile.velocity * Projectile.scale * 10.5f;
            num -= Projectile.scale * 14.5f * Projectile.scale;
            Vector2 vector = new Vector2( Projectile.scale );
            DelegateMethods.f_1 = 1f;
            DelegateMethods.c_1 = value * 25f * Projectile.Opacity;
            Vector2[ ] oldPos = Projectile.oldPos;
            Utils.DrawLaser( Main.spriteBatch , texture2D , value2 - Main.screenPosition , value2 + Projectile.velocity * num - Main.screenPosition , vector , new Utils.LaserLineFraming( DelegateMethods.RainbowLaserDraw ) );
            DelegateMethods.c_1 = new Color( 255 , 250 , 205 , 127 ) * 0.75f * Projectile.Opacity;
            Utils.DrawLaser( Main.spriteBatch , texture2D , value2 - Main.screenPosition , value2 + Projectile.velocity * num - Main.screenPosition , vector / 2f , new Utils.LaserLineFraming( DelegateMethods.RainbowLaserDraw ) );

            return base.PreDraw( ref lightColor );
        }
        public override void CutTiles( )
        {
            DelegateMethods.tilecut_0 = (Terraria.Enums.TileCuttingContext) 2;
            Vector2 velocity = Projectile.velocity;
            Utils.PlotTileLine( Projectile.Center , Projectile.Center + velocity * Projectile.localAI[ 1 ] , (float) Projectile.width * Projectile.scale , new Utils.TileActionAttempt( DelegateMethods.CutTiles ) );
        }
        public override bool? Colliding( Rectangle projHitbox , Rectangle targetHitbox )
        {
            if ( projHitbox.Intersects( targetHitbox ) )
            {
                return new bool?( true );
            }
            float num = 0f;
            if ( Collision.CheckAABBvLineCollision( targetHitbox.TopLeft( ) , targetHitbox.Size( ) , Projectile.Center , Projectile.Center + Projectile.velocity * Projectile.localAI[ 1 ] , 22f * Projectile.scale , ref num ) )
            {
                return new bool?( true );
            }
            return new bool?( false );
        }
    }
}
