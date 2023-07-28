using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Cather
{
    /// <summary>
    /// 凯尔特战甲.
    /// </summary>
    [AutoloadEquip( EquipType.Body )]
    public class CatherArmor : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "凯特尔战甲" );
            DisplayName.AddTranslation( English , "CatherArmor" );
            Tooltip.AddTranslation( Chinese ,
                "若你的生命值低于50点: \n" +
                "获得5%的移动速度加成\n" +
                "获得2%的伤害减免" );
            Tooltip.AddTranslation( English , "" +
                "If your health is less than 50 points: \n" +
                "5% movement speed bonus\n" +
                "Gain 2% damage reduction" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.maxStack = 1;
            Item.defense = 3;
            Item.value = Item.sellPrice( 0 , 2 );
        }
        public override void UpdateEquip( Player player )
        {
            if ( player.statLife < 50 )
            {
                player.moveSpeed += 0.05f;
                player.endurance += 0.02f;
            }
        }
    }
}