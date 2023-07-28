using EternalResolve.Common.Contents.Modulars;
using Terraria;

namespace EternalResolve.Common.Contents.Entities.Items.Swords
{
    public class GrowAgain : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "重生" );
            DisplayName.AddTranslation( English , "Grow Again" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 4 );
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
    }
}
