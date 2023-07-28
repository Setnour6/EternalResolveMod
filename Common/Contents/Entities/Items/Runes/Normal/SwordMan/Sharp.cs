using EternalResolve.Common.Contents.Modulars;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Runes.Normal.SwordMan
{
    public class Sharp : BasicRune
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "锋利" );
            DisplayName.AddTranslation( English , "Sharp" );
        }
        public override void SetDefaults( )
        {
            base.SetDefaults( );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
            Item.GetGlobalItem<RuneItem>( ).CompleteSet = new Swordsman( );
        }
        public override void UpdateInventory( Player player )
        {
            ChineseRuneTip = "每次近战攻击附带你武器稀有度的真实伤害.";
            EnglishRuneTip = "Each melee attack is accompanied by real damage of weapon rarity.";

            base.UpdateInventory( player );
        }
        public override void ModifyHitNPC( Player player , NPC target , ref int damage , ref float knockBack , ref bool crit )
        {
            if ( player.HeldItem.type != ItemID.None && player.HeldItem.DamageType == DamageClass.Melee )
            {
                target.life -= player.HeldItem.rare;
                target.checkDead( );
                CombatText.NewText( target.getRect( ) , Color.White , player.HeldItem.rare );
            }
            base.ModifyHitNPC( player , target , ref damage , ref knockBack , ref crit );
        }
    }
}