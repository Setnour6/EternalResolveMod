using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.GhostWords
{
    public class GhostGodArrowHitEffect : ERProjectile
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
            Projectile.width = 80;
            Projectile.height = 78;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.light = 1.2f;
            Main.projFrames[ Projectile.type ] = 12;
        }

        // Token: 0x060007AE RID: 1966 RVA: 0x00026080 File Offset: 0x00024280
        public override void AI( )
        {
            this.timer++;
            if ( this.timer % 2 == 0 )
            {
                Projectile.frame++;
            }
            if ( Projectile.frame > Main.projFrames[ Projectile.type ] )
            {
                Projectile.Kill( );
            }
            base.AI( );
        }

        // Token: 0x060007AF RID: 1967 RVA: 0x000052C6 File Offset: 0x000034C6
        public override bool PreKill( int timeLeft )
        {
            return false;
        }

        // Token: 0x0400014A RID: 330
        private int timer;
    }
}
