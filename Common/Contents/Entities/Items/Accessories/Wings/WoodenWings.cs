using Terraria;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Wings
{
    [AutoloadEquip( EquipType.Wings )]
    public class WoodenWings : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "木制机械翼" );
            Tooltip.AddTranslation( Chinese , "总比不能飞好." );

            DisplayName.AddTranslation( English , "Wooden Wings" );
            Tooltip.AddTranslation( English , "Better than not fly." );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 2 );
            Item.defense = 2;
            Item.value = Item.sellPrice( 0 , 0 , 25 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.wingTimeMax = 126;  //2.1秒
        }
        public override void VerticalWingSpeeds( Player player , ref float ascentWhenFalling , ref float ascentWhenRising , ref float maxCanAscendMultiplier , ref float maxAscentMultiplier , ref float constantAscend )
        {
            ascentWhenFalling = 0.1f;
            ascentWhenRising = 1f;
            maxCanAscendMultiplier = 0.1f;
            maxAscentMultiplier = 1f;
            constantAscend = 0.1f;
        }
        public override void HorizontalWingSpeeds( Player player , ref float speed , ref float acceleration )
        {
            speed = 0.1f;
            acceleration = 0.1f;
        }
    }
}