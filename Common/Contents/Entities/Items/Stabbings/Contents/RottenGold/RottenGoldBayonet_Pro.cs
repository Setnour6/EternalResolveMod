using Microsoft.Xna.Framework;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.RottenGold
{
    public class RottenGoldBayonet_Pro : StabbingProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.GetGlobalProjectile<StabbingDrawer>( ).Color = new Color( 211 , 145 , 255 );
            base.SetDefaults( );
            Projectile.localNPCHitCooldown = 5;
        }
    }
}