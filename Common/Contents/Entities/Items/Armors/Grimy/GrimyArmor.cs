using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Grimy
{
    [AutoloadEquip( EquipType.Body )]
    public class GrimyArmor : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "尘封的遗愿" );
            Tooltip.AddTranslation( Chinese ,
                "当你受到攻击, 你将有10%的几率回避本次攻击\n" +
                "并且恢复等同于本次攻击100%伤害值的生命值\n" +
                "1000码范围内有敌人时获得20点生命回复" );
        }
        public override void SetDefaults( )
        {
            ToItem( 8 );
            Item.maxStack = 1;
            Item.defense = 26;
            Item.value = Item.sellPrice( 1 );
        }
        public override void UpdateEquip( Player player )
        {
            foreach ( NPC npc in Main.npc )
            {
                if ( npc.active && !npc.friendly && Vector2.Distance( player.Center , npc.Center ) < 1000 )
                {
                    player.lifeRegen += 20;
                    break;
                }
            }
            base.UpdateEquip( player );
        }
    }
}
