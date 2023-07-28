using EternalResolve.Common.Contents.Entities.Buffs.Additions.Defenses;
using EternalResolve.Common.Contents.Modulars;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Runes.Normal.SwordMan
{
    public class Defenser : BasicRune
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "攻守兼备" );

            DisplayName.AddTranslation( English , "Strong Shield" );
        }
        public override void SetDefaults( )
        {
            base.SetDefaults( );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
        }
        public override void UpdateInventory( Player player )
        {
            ChineseRuneTip = "近战攻击命中敌人时, 获得" +
                ( (int) Item.GetGlobalItem<RuneItem>( ).RuneType + 1 ) +
                "点防御\n 持续三秒";

            EnglishRuneTip = "When a melee attack hits the enemy, you gain" +
                ( (int) Item.GetGlobalItem<RuneItem>( ).RuneType + 1 ) +
                " defense\n keep three seconds";

            base.UpdateInventory( player );
        }
        public override void ModifyHitNPC( Player player , NPC target , ref int damage , ref float knockBack , ref bool crit )
        {
            if ( player.HeldItem.DamageType == DamageClass.Melee && player.HeldItem.shoot == 0 )
            {
                switch ( Item.GetGlobalItem<RuneItem>( ).RuneType )
                {
                    case RuneType.Rough:
                        player.AddBuff( ModContent.BuffType<Defense_1>( ) , 180 );
                        break;
                    case RuneType.Ordinary:
                        player.AddBuff( ModContent.BuffType<Defense_2>( ) , 180 );
                        break;
                    case RuneType.Excellent:
                        player.AddBuff( ModContent.BuffType<Defense_3>( ) , 180 );
                        break;
                    case RuneType.Preeminent:
                        player.AddBuff( ModContent.BuffType<Defense_4>( ) , 180 );
                        break;
                    case RuneType.Legend:
                        player.AddBuff( ModContent.BuffType<Defense_5>( ) , 180 );
                        break;
                }
            }
            base.ModifyHitNPC( player , target , ref damage , ref knockBack , ref crit );
        }
    }
}
