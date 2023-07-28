using log4net.Repository.Hierarchy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.Prism
{
    public class PrismLightProjectile : ModProjectile
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.SetDefault( "幻光镜" );
            Main.projFrames[ Projectile.type ] = 5;
        }
        public override void SetDefaults( )
        {
            Projectile.width = 22;
            Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Magic;
        }
        public override void AI( )
        {
            Projectile.frameCounter++;
            int num = Projectile.ai[ 0 ] < 180f ? 6 : 1;
            if ( Projectile.frameCounter >= num )
            {
                Projectile.frameCounter = 0;
                Projectile projectile = Projectile;
                int num2 = projectile.frame + 1;
                projectile.frame = num2;
                if ( num2 >= 5 )
                {
                    Projectile.frame = 0;
                }
            }
            Player player = Main.player[ Projectile.owner ];
            float num3 = 1.5707964f;
            Vector2 vector = player.RotatedRelativePoint( player.MountedCenter , true );
            float num4 = 30f;
            if ( Projectile.ai[ 0 ] > 90f )
            {
                num4 = 15f;
            }
            if ( Projectile.ai[ 0 ] > 120f )
            {
                num4 = 5f;
            }

			Projectile.damage = (player.inventory[player.selectedItem].damage * (int)player.GetDamage( DamageClass.Magic ).Additive ); // Additive magic damage, might be better.
            Projectile.ai[ 0 ] += 1f;
            Projectile.ai[ 1 ] += 1f;
            bool flag = false;
            if ( Projectile.ai[ 0 ] % num4 == 0f )
            {
                flag = true;
            }
            int soundDelay = 10;
            bool flag2 = false;
            if ( Projectile.ai[ 0 ] % num4 == 0f )
            {
                flag2 = true;
            }
            if ( Projectile.ai[ 1 ] >= 1f )
            {
                Projectile.ai[ 1 ] = 0f;
                flag2 = true;
                if ( Main.myPlayer == Projectile.owner )
                {
                    float scaleFactor = player.inventory[ player.selectedItem ].shootSpeed * Projectile.scale;
                    Vector2 vector2 = vector;
                    Vector2 value = Main.screenPosition + new Vector2( Main.mouseX , Main.mouseY ) - vector2;
                    if ( player.gravDir == -1f )
                    {
                        value.Y = Main.screenHeight - Main.mouseY + Main.screenPosition.Y - vector2.Y;
                    }
                    Vector2 vector3 = Vector2.Normalize( value );
                    if ( float.IsNaN( vector3.X ) || float.IsNaN( vector3.Y ) )
                    {
                        vector3 = -Vector2.UnitY;
                    }
                    vector3 = Vector2.Normalize( Vector2.Lerp( vector3 , Vector2.Normalize( Projectile.velocity ) , 0.92f ) );
                    vector3 *= scaleFactor;
                    if ( vector3.X != Projectile.velocity.X || vector3.Y != Projectile.velocity.Y )
                    {
                        Projectile.netUpdate = true;
                    }
                    Projectile.velocity = vector3;
                }
            }
            if ( Projectile.soundDelay <= 0 )
            {
                Projectile.soundDelay = soundDelay;
                Projectile.soundDelay *= 2;
                if ( Projectile.ai[ 0 ] != 1f )
                {
                    SoundEngine.PlaySound( SoundID.Item15 , Projectile.position );
                }
            }
            if ( flag2 && Main.myPlayer == Projectile.owner )
            {
                bool flag3 = !flag || player.CheckMana( player.inventory[ player.selectedItem ].mana , true , false );
                if ( player.channel && flag3 && !player.noItems && !player.CCed )
                {
                    if ( Projectile.ai[ 0 ] == 1f )
                    {
                        Vector2 center = Projectile.Center;
                        Vector2 vector4 = Vector2.Normalize( Projectile.velocity );
                        if ( float.IsNaN( vector4.X ) || float.IsNaN( vector4.Y ) )
                        {
                            vector4 = -Vector2.UnitY;
                        }
                        int damage = Projectile.damage;
                        for ( int i = 0; i < 7; i++ )
                        {
                            Projectile.NewProjectile( null , center.X , center.Y , vector4.X , vector4.Y , ModContent.ProjectileType<PrismLight>( ) , damage , Projectile.knockBack , Projectile.owner , (float) i , (float) Projectile.whoAmI );
                        }
                        Projectile.netUpdate = true;
                    }
                }
                else
                {
                    Projectile.Kill( );
                }
            }
            Projectile.position = player.RotatedRelativePoint( player.MountedCenter , true ) - Projectile.Size / 2f;
            Projectile.rotation = Utils.ToRotation( Projectile.velocity ) + num3;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            player.ChangeDir( Projectile.direction );
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 2;
            player.itemAnimation = 2;
            player.itemRotation = (float) Math.Atan2( (double) ( Projectile.velocity.Y * (float) Projectile.direction ) , (double) ( Projectile.velocity.X * (float) Projectile.direction ) );
        }

        public override bool PreDraw( ref Color lightColor )
        {

            Vector2 mountedCenter = Main.player[ Projectile.owner ].MountedCenter;
            Color color = Lighting.GetColor( (int) ( (double) Projectile.position.X + (double) Projectile.width * 0.5 ) / 16 , (int) ( ( (double) Projectile.position.Y + (double) Projectile.height * 0.5 ) / 16.0 ) );
            if ( Projectile.hide && !ProjectileID.Sets.DontAttachHideToAlpha[ Projectile.type ] )
            {
                color = Lighting.GetColor( (int) mountedCenter.X / 16 , (int) ( mountedCenter.Y / 16f ) );
            }
            SpriteEffects effects = SpriteEffects.None;
            if ( Projectile.spriteDirection == -1 )
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Texture2D texture2D = TextureAssets.Projectile[ Projectile.type ].Value;
            int num = TextureAssets.Projectile[ Projectile.type ].Value.Height / Main.projFrames[ Projectile.type ];
            int y = num * Projectile.frame;
            Vector2 vector = Utils.Floor( Projectile.position + new Vector2( (float) Projectile.width , (float) Projectile.height ) / 2f + Vector2.UnitY * Projectile.gfxOffY - Main.screenPosition );
            Main.spriteBatch.Draw( texture2D , vector , new Rectangle?( new Rectangle( 0 , y , texture2D.Width , num ) ) , Projectile.GetAlpha( color ) , Projectile.rotation , new Vector2( (float) texture2D.Width / 2f , (float) num / 2f ) , Projectile.scale , effects , 0f );
            float scaleFactor = (float) Math.Cos( (double) ( 6.2831855f * ( Projectile.ai[ 0 ] / 30f ) ) ) * 2f + 2f;
            if ( Projectile.ai[ 0 ] > 120f )
            {
                scaleFactor = 4f;
            }
            for ( float num6 = 0f; num6 < 4f; num6 += 1f )
            {
                Main.spriteBatch.Draw( texture2D , vector + Vector2.UnitY.RotatedBy( (double) ( num6 * 6.2831855f / 4f ) , default( Vector2 ) ) * scaleFactor , new Rectangle?( new Rectangle( 0 , y , texture2D.Width , num ) ) , Utils.MultiplyRGBA( Projectile.GetAlpha( color ) , new Color( 255 , 255 , 255 , 0 ) ) * 0.03f , Projectile.rotation , new Vector2( (float) texture2D.Width / 2f , (float) num / 2f ) , Projectile.scale , effects , 0f );
            }
            return false;
        }
        public override Color? GetAlpha( Color lightColor )
        {
            return new Color?( Color.White );
        }
    }
}
