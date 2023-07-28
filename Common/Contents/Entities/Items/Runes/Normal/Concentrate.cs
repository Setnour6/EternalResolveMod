using EternalResolve.Common.Contents.Entities.Buffs.Additions.CritDamages;
using EternalResolve.Common.Contents.Modulars;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Runes.Normal
{
    public class Concentrate : BasicRune
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "全神贯注" );
            DisplayName.AddTranslation( English , "Concentrate" );
        }
        public override void SetDefaults( )
        {
            base.SetDefaults( );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
        }
        public override void UpdateInventory( Player player )
        {
            ChineseRuneTip = "若你没有移动，则获得10%暴击伤害";
            EnglishRuneTip = "if you don't move，gain 10% critical hit damage";

            base.UpdateInventory( player );
        }
        public override void HoldItem( Player player )
        {
            if ( player.velocity.X == 0 )
            {
                player.AddBuff( ModContent.BuffType<CritDamage_10>( ) , 60 );
            }
            base.HoldItem( player );
        }
    }
}
