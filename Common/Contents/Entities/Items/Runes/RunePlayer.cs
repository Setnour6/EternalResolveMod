using EternalResolve.Common.Contents.Modulars.RuneModular;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Runes
{
    public class RunePlayer : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( Player.HeldItem != null && Player.HeldItem.type != ItemID.None )
            {
                for ( int count = 0; count < 6; count++ )
                {
                    if ( Player.HeldItem.GetGlobalItem<ItemRune>( ).Runes[count].type != ItemID.None )
                        Player.HeldItem.GetGlobalItem<ItemRune>( ).Runes[ count ].ModItem.ModifyHitNPC( Player , target , ref damage , ref knockback , ref crit );
                }
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }

        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Player.HeldItem != null && Player.HeldItem.type != ItemID.None )
            {
                for ( int count = 0; count < 6; count++ )
                {
                    if ( Player.HeldItem.GetGlobalItem<ItemRune>( ).Runes[ count ].type != ItemID.None )
                        Player.HeldItem.GetGlobalItem<ItemRune>( ).Runes[ count ].ModItem.ModifyHitNPC( Player , target , ref damage , ref knockback , ref crit );
                }
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
}
