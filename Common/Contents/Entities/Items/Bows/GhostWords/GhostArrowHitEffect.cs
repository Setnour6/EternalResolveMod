using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.GhostWords
{
    public class GhostArrowHitEffect : ERProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.light = 0.5f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 30;
            Projectile.timeLeft = 600;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.width = 100;
            Projectile.height = 74;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.light = 1.2f;
            Main.projFrames[ Projectile.type ] = 5;
        }
        public override void AI( )
        {
            Projectile.frame++;
            Projectile.rotation = Utils.ToRotation( Projectile.velocity ) + 1.5707964f;
            if ( Projectile.frame > Main.projFrames[ Projectile.type ] )
            {
                Projectile.Kill( );
            }
            base.AI( );
        }
        public override bool PreKill( int timeLeft )
        {
            return false;
        }
    }
}
