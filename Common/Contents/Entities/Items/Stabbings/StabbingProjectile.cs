using Microsoft.Xna.Framework;
using System;
using System.IO;
using Terraria;
using Terraria.Audio;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings
{
    public class StabbingProjectile : ERProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 4;
            Projectile.GetGlobalProjectile<StabbingDrawer>( ).IsStabbing = true;
        }
        public virtual int SoundTimer { get; private set; } = 6;
        public override void SendExtraAI( BinaryWriter writer )
        {
            writer.Write( SoundTimer );
            base.SendExtraAI( writer );
        }
        public override void ReceiveExtraAI( BinaryReader reader )
        {
            SoundTimer = reader.ReadInt32( );
            base.ReceiveExtraAI( reader );
        }
        public override void AI( )
        {
            Player player = Main.player[ Projectile.owner ];
            float num = (float) Math.PI / 2f;
            Vector2 val = player.RotatedRelativePoint( player.MountedCenter );
            int num2 = 2;
            float num3 = 0f;
            num = 0f;
            Projectile.ai[ 0 ] += 1f;
            if ( Projectile.ai[ 0 ] >= 8f )
            {
                Projectile.ai[ 0 ] = 0f;
            }
            num2 = 9;
            num3 = Main.rand.NextFloatDirection( ) * ( (float) Math.PI * 2f ) * 0.05f;
            Projectile.soundDelay--;
            if ( Projectile.soundDelay <= 0 )
            {
                SoundEngine.PlaySound( SoundID.Item1 , Projectile.Center );
                Projectile.soundDelay = SoundTimer;
            }
            if ( Main.myPlayer == Projectile.owner )
            {
                if ( player.channel && !player.noItems && !player.CCed )
                {
                    float num46 = 1f;
                    num46 = player.inventory[ player.selectedItem ].shootSpeed * Projectile.scale;
                    Vector2 val31 = Main.MouseWorld - val;
                    val31.Normalize( );
                    if ( val31.HasNaNs( ) )
                    {
                        val31 = Vector2.UnitX * (float) player.direction;
                    }
                    val31 *= num46;
                    if ( val31.X != Projectile.velocity.X || val31.Y != Projectile.velocity.Y )
                    {
                        Projectile.netUpdate = true;
                    }
                    Projectile.velocity = val31;
                }
                else
                {
                    Projectile.Kill( );
                }
            }
            DelegateMethods.v3_1 = new Vector3( 0.5f , 0.5f , 0.5f );
            Utils.PlotTileLine( Projectile.Center - Projectile.velocity , Projectile.Center + Projectile.velocity.SafeNormalize( Vector2.Zero ) * 80f , 16f , DelegateMethods.CastLightOpen );
            Projectile.position = player.RotatedRelativePoint( player.MountedCenter , reverseRotation: false , addGfxOffY: false ) - Projectile.Size / 2f;
            Projectile.rotation = Projectile.velocity.ToRotation( ) + num;
            Projectile.spriteDirection = Projectile.direction;
            Projectile.timeLeft = 2;
            player.ChangeDir( Projectile.direction );
            player.heldProj = Projectile.whoAmI;
            player.SetDummyItemTime( num2 );
            player.itemRotation = MathHelper.WrapAngle( (float) Math.Atan2( Projectile.velocity.Y * (float) Projectile.direction , Projectile.velocity.X * (float) Projectile.direction ) + num3 );
            player.itemAnimation = num2 - (int) Projectile.ai[ 0 ];
        }
        public override bool? Colliding( Rectangle projHitbox , Rectangle targetHitbox )
        {
            for ( int j = 1; j <= 4; j++ )
            {
                Rectangle val6 = projHitbox;
                Vector2 val7 = Projectile.velocity.SafeNormalize( Vector2.Zero ) * Projectile.width * j;
                val6.Offset( (int) val7.X , (int) val7.Y );
                if ( val6.Intersects( targetHitbox ) )
                {
                    return true;
                }
            }
            return false;
        }
        public override void CutTiles( )
        {
            DelegateMethods.tilecut_0 = TileCuttingContext.AttackProjectile;
            Vector2 end = Projectile.Center + Projectile.velocity.SafeNormalize( Vector2.UnitX ) * 220f * Projectile.scale;
            Utils.PlotTileLine( Projectile.Center , end , 80f * Projectile.scale , DelegateMethods.CutTiles );
        }
        public override bool PreDraw( ref Color lightColor )
        {
            return false;
        }
    }
}
