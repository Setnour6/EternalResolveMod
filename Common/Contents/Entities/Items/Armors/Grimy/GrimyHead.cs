using EternalResolve.Common.Contents.Modulars.ManaModular;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Grimy
{
    [AutoloadEquip( new EquipType[ ] { EquipType.Head } )]
    public class GrimyHead : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "尘封的遗志" );
            Tooltip.AddTranslation( Chinese ,
                "获得20%伤害减免\n" +
                "手持近战类武器时获得3000魔能上限提升\n" +
                "使用近战武器造成伤害时会回复魔能值" );
        }
        public override void SetDefaults( )
        {
            ToItem( 8 );
            Item.maxStack = 1;
            Item.defense = 20;
            Item.value = Item.sellPrice( 1 );
        }
        public override void UpdateEquip( Player player )
        {
            player.endurance += 0.2f;
            if ( player.HeldItem.DamageType == DamageClass.Melee )
            {
                player.GetModPlayer<PlayerMana>( ).ManaMax += 3000;
            }
        }
        public override bool IsArmorSet( Item head , Item body , Item legs )
        {
            return
                body.type == ModContent.ItemType<GrimyArmor>( ) &&
                legs.type == ModContent.ItemType<GrimyLegs>( );
        }
        public override void UpdateArmorSet( Player player )
        {
            player.setBonus = "" +
                "【 伪神 】\n" +
                "击杀怪物会对这套盔甲进行唤醒\n" +
                "唤醒进度达到100%后\n" +
                "按下B键获得为时16秒的短暂登神\n" +
                "登神期间:\n" +
                " 你获得500%的近战伤害加成\n" +
                " 你获得128点防御值\n" +
                " 你获得56点生命回复\n" +
                " 你获得24%伤害减免\n" +
                "登神结束后\n" +
                "你将获得30分钟的减益:\n" +
                " 移动速度减少50%\n" +
                " 近战伤害减少50%\n" +
                " 生命回复归零\n" +
                " 减少64点防御值\n" +
                " 受到的伤害增加50%";
            player.statDefense += 4;
            player.armorPenetration += 20;
        }
    }
}
