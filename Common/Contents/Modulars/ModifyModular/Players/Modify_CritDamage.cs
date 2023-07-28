using EternalResolve.Common.Codes.Utils;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Players
{
    public class Modify_CritDamage : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public float CritDamage = 1.5f;

        public override void ResetEffects( )
        {
            Player.GetModPlayer<Modify_CritDamage>( ).CritDamage = 1.5f;
            base.ResetEffects( );
        }
        public override void ModifyHitNPC( Item Item , Terraria.NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( crit )
            {
                damage /= 2;
                damage = ( damage * CritDamage ).ToInt( );
            }
            base.ModifyHitNPC( Item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , Terraria.NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( crit )
            {
                damage /= 2;
                damage = ( damage * CritDamage ).ToInt( );

            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
        public void AddCritDamage( float critDamage )
        {
            Player.GetModPlayer<Modify_CritDamage>( ).CritDamage += critDamage;
        }
    }
    public static class AddPlayerCritDamage
    {
        public static void AddCritDamage( this Player player , float critDamage )
        {
            player.GetModPlayer<Modify_CritDamage>( ).AddCritDamage( critDamage );
        }
    }
}
