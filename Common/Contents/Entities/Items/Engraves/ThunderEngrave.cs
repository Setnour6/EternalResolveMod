using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves
{
    public class ThunderEngrave : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "雷之刻印" );
            DisplayName.AddTranslation( English , "Thunder Engrave" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 5 );
            Item.defense = 3;
            Item.value = Item.sellPrice( 0 , 2 );
            base.SetDefaults( );
        }
    }
}
