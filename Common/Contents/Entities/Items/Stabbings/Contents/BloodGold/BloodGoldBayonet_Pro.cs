using Microsoft.Xna.Framework;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.BloodGold
{
    public class BloodGoldBayonet_Pro : StabbingProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.GetGlobalProjectile<StabbingDrawer>( ).Color = Color.Red;
            base.SetDefaults( );
            Projectile.localNPCHitCooldown = 5;
        }
    }
}