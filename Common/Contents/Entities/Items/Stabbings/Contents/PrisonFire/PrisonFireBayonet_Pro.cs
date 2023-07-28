using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.PrisonFire
{
    public class PrisonFireBayonet_Pro : StabbingProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.GetGlobalProjectile<StabbingDrawer>( ).Color = Color.Orange;
            base.SetDefaults( );
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            target.buffImmune[ BuffID.OnFire ] = false;
            target.AddBuff( BuffID.OnFire , 240 );
            base.OnHitNPC( target , damage , knockback , crit );
        }
    }
}