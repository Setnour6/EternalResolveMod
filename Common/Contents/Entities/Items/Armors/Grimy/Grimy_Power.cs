using EternalResolve.Common.Contents.Modulars.ManaModular;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Grimy
{
    public class Grimy_Power : ModPlayer
    {
        protected override bool CloneNewInstances => true;

        public bool GrimyHead = false;

        public bool GrimyBody = false;

        public bool Grimylegs = false;

        public override void ResetEffects( )
        {
            if ( Player.head == ModContent.ItemType<GrimyHead>( ) )
                GrimyHead = true;
            else
                GrimyHead = false;

            if ( Player.body == ModContent.ItemType<GrimyArmor>( ) )
                GrimyBody = true;
            else
                GrimyBody = false;

            if ( Player.legs == ModContent.ItemType<GrimyLegs>( ) )
                Grimylegs = true;
            else
                Grimylegs = false;

            base.ResetEffects( );
        }
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            if ( Player.GetModPlayer<Grimy_Power>( ).GrimyBody )
            {
                if ( Main.rand.Next( 10 ) == 5 )
                {
                    Player.HealEffect( damage );
                    Player.statLife += damage;
                    return false;
                }
            }
            return true;
        }

        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( Player.GetModPlayer<Grimy_Power>( ).GrimyHead )
            {
                damage += Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue / 1000;
                if ( item.DamageType == DamageClass.Melee )
                {
                    int value = Main.rand.Next( 4 , 7 );
                    Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue += value;
                    if ( Language.ActiveCulture == EternalResolve.Chinese )
                        CombatText.NewText( target.getRect( ) , Color.MediumPurple , "魔能 +" + value );
                    else
                        CombatText.NewText( target.getRect( ) , Color.MediumPurple , "Mana +" + value );
                }
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }

        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Player.GetModPlayer<Grimy_Power>( ).GrimyHead )
            {
                damage += Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue / 1000;
                if ( proj.DamageType == DamageClass.Melee )
                {
                    int value = Main.rand.Next( 4 , 7 );
                    Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue += value;
                    if ( Language.ActiveCulture == EternalResolve.Chinese )
                        CombatText.NewText( target.getRect( ) , Color.MediumPurple , "魔能 +" + value );
                    else
                        CombatText.NewText( target.getRect( ) , Color.MediumPurple , "Mana +" + value );
                }
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
}