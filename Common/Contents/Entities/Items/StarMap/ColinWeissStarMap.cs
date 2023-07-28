using EternalResolve.Common.Contents.Modulars;

namespace EternalResolve.Common.Contents.Entities.Items.StarMap
{
    public class ColinWeissStarMap : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "STAR MAP - TESTING ITEM" );
            DisplayName.AddTranslation( English , "STAR MAP - TESTING ITEM" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 7 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
    }
}
