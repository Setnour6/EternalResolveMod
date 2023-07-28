using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.TheDestructionOfMeteoriteThunder
{
    public class TDMT_Pro : StabbingProjectile
    {
        public override void SetDefaults( )
        {
            Projectile.GetGlobalProjectile<StabbingDrawer>( ).Color = new Color( 15 , 128 , 241 );
            base.SetDefaults( );
        }
        public override void OnHitNPC( NPC target , int damage , float knockback , bool crit )
        {
            Projectile.NewProjectile( Projectile.GetSource_OnHit(target) , target.Center , new Vector2( 0.01f , 0f ) , ModContent.ProjectileType<TDMT_Pro_TH>( ) , damage / 3 , 0.5f , Main.myPlayer , target.Center.X , target.Center.Y );
            base.OnHitNPC( target , damage , knockback , crit );
        }
    }
}