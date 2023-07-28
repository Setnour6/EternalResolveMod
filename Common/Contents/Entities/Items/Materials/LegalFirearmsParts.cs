using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Materials
{
    public class LegalFirearmsParts : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "合法枪械部件" );
            Tooltip.AddTranslation( Chinese , "百分百合法，但是很贵。" );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.value = Item.buyPrice( 0 , 50 , 0 , 0 );
        }
    }
}