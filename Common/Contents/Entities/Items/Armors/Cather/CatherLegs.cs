using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Cather
{
    /// <summary>
    /// 凯尔特战靴.
    /// </summary>
    [AutoloadEquip( new EquipType[ ] { EquipType.Legs } )]
    public class CatherLegs : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "凯特尔战靴" );
            Tooltip.AddTranslation( Chinese ,
                "当你造成一次近战的暴击: \n" +
                "回复 1 生命值\n" +
                "回复 1 法力值" );

            DisplayName.AddTranslation( English , "Cather Legs" );
            Tooltip.AddTranslation( English ,
                "When you make a melee crit: \n" +
                "Re 1 lifeValue\n" +
                "Re 1 manaValue" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.maxStack = 1;
            Item.defense = 2;
            Item.value = Item.sellPrice( 0 , 2 );
        }
    }
}