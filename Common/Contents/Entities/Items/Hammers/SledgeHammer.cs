using EternalResolve.Common.Contents.Modulars;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Hammers
{
    public class SledgeHammer : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "拆迁锤" );
            DisplayName.AddTranslation( English , "Sledge Hammer" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.value = Item.sellPrice( 0 , 1 );
            Item.hammer = 65;
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
    }
}