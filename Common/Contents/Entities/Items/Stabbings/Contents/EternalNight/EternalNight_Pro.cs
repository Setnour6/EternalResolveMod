using Microsoft.Xna.Framework;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.EternalNight
{
    public class EternalNight_Pro : StabbingProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.GetGlobalProjectile<StabbingDrawer>( ).Color = new Color( 209 , 94 , 255 );
            base.SetDefaults( );
            Projectile.localNPCHitCooldown = 5;
        }
    }
}