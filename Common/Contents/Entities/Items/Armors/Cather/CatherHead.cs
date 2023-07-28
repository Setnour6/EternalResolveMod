using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Cather
{
    /// <summary>
    /// 凯尔特战盔.
    /// </summary>
    [AutoloadEquip( new EquipType[ ] { EquipType.Head } )]
    public class CatherHead : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "凯特尔战盔" );
            Tooltip.AddTranslation( Chinese ,
                "当你身处出生点200格范围内: \n" +
                "获得5%的移动速度加成\n" +
                "获得2%的伤害减免." );

            DisplayName.AddTranslation( English , "Cather Head" );
            Tooltip.AddTranslation( English ,
            "When you are within 200 squares of your birth point: \n" +
            "Gain 5% movement speed bonus \n" +
            "Gain 2% damage reduction." );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.maxStack = 1;
            Item.defense += 2;
            Item.value = Item.sellPrice( 0 , 2 );
        }
        public override void UpdateEquip( Player player )
        {
            if ( Vector2.Distance( player.position , new Vector2( player.SpawnX , player.SpawnY ) ) < 200 * 16 )
            {
                player.moveSpeed += 0.05f;
                player.endurance += 0.02f;
            }
        }
    }
}