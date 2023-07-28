using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Armors.Others
{
    [AutoloadEquip( new EquipType[ ] { EquipType.Head } )]
    public class TheCowboyHat : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "牛仔帽" );

            DisplayName.AddTranslation( English , "A cowboy hat" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.maxStack = 1;
            Item.defense = 1;
            Item.value = Item.sellPrice( 0 , 0 , 99 , 99 );
        }
    }
}