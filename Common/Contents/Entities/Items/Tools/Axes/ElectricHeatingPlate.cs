using EternalResolve.Common.Contents.Entities.Items.Electrics;

namespace EternalResolve.Common.Contents.Entities.Items.Tools.Axes
{
    public class ElectricHeatingPlate : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "高温电热板" );
            DisplayName.AddTranslation( English , "Electric Heating Plate" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 4 );
            Item.axe = 25;
            Item.GetGlobalItem<ItemElectric>( ).CanCharge = true;
            Item.GetGlobalItem<ItemElectric>( ).ElectricValueMax = 500;
            base.SetDefaults( );
        }
    }
}
