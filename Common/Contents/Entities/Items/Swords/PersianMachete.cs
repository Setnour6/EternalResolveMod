using EternalResolve.Common.Contents.Modulars;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Swords
{
    public class PersianMachete : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "波斯弯刀" );
            DisplayName.AddTranslation( English , "Persian Machete" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.damage += 2;
            Item.useTime -= 1;
            Item.useAnimation -= 1;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
    }
}
