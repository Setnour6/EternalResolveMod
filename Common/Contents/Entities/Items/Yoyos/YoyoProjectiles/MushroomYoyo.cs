using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Yoyos.YoyoProjectiles
{
    public class MushroomYoyo : ModProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.CloneDefaults( 541 );
            Projectile.width = 16;
            Projectile.scale = 1.1f;
            Projectile.height = 16;
            Projectile.penetrate = -1;
            Projectile.aiStyle = 99;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ Projectile.type ] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[ Projectile.type ] = 200f;
            ProjectileID.Sets.YoyosTopSpeed[ Projectile.type ] = 12f;

        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            int num = Main.rand.Next( 1 , 2 );
            if ( target.type == NPCID.TargetDummy )
            {
                return;
            }
            Player player = Main.player[ Projectile.owner ];
            player.statLife += num;
            player.HealEffect( num , true );
        }
    }
}