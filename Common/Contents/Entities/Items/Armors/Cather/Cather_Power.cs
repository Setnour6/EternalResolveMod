using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Cather
{
    public class Cather_Power : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public bool CatherPower = false;

        public override void ResetEffects( )
        {
            if ( Player.legs == ModContent.ItemType<CatherLegs>( ) )
                CatherPower = true;
            else
                CatherPower = false;
            base.ResetEffects( );
        }
        public override void ModifyHitByNPC( NPC npc , ref int damage , ref bool crit )
        {
            if ( Player.GetModPlayer<Cather_Power>( ).CatherPower && crit )
            {
                Player.HealEffect( 1 );
                Player.statLife += 1;
                Player.ManaEffect( 1 );
                Player.statMana += 1;
            }
            base.ModifyHitByNPC( npc , ref damage , ref crit );
        }
    }
}