using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Materials.Ingots
{
    public class Guding : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "埃坎达合金" );
            DisplayName.AddTranslation( English , "Ekanda Alloy" );
        }
        public override void SetDefaults( )
        {
            ToItem( 6 );
            Item.value = Item.sellPrice( 0 , 2 );
        }
    }
}