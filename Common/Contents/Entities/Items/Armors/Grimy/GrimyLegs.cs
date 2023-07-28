using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Grimy
{
    [AutoloadEquip( new EquipType[ ] { EquipType.Legs } )]
    public class GrimyLegs : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "尘封的遗念" );
            Tooltip.AddTranslation( Chinese ,
                "你会从魔能值获得0.1%的伤害提升\n" +
                "1000码范围内有敌人时获得12%移动速度" );
        }
        public override void SetDefaults( )
        {
            ToItem( 8 );
            Item.maxStack = 1;
            Item.defense = 22;
            Item.value = Item.sellPrice( 1 );
        }
        public override void UpdateEquip( Player player )
        {
            foreach ( NPC npc in Main.npc )
            {
                if ( npc.active && !npc.friendly && Vector2.Distance( player.Center , npc.Center ) < 1000 )
                {
                    player.moveSpeed += 0.12f;
                    player.maxRunSpeed += 0.12f;
                    break;
                }
            }
            base.UpdateEquip( player );
        }
    }
}
