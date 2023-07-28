using EternalResolve.Common.Contents.Entities.Items.Stabbings;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.DreamInterpreters
{
    public class DreamInterpreter_SwordPro : StabbingProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.GetGlobalProjectile<StabbingDrawer>( ).Color = new Color( 71 , 193 , 255 );
            base.SetDefaults( );
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            for ( int angle = 0; angle < 24; angle++ )
            {
                Vector2 position = target.Center;
                position += Utils.RotatedByRandom( new Vector2( 5f , 0f ) , 6.283 ) * Utils.NextFloat( Main.rand , 0.9f , 1.1f );
                Dust dust = Main.dust[ Dust.NewDust( position , 0 , 0 , DustID.TintableDustLighted , 0f , 0f , 0 , Color.White , 1.25f ) ];
                dust.noGravity = true;
            }
            base.OnHitNPC( target , damage , knockback , crit );
        }
    }
}