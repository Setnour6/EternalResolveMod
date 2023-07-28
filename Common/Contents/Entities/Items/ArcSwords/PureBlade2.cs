namespace EternalResolve.Common.Contents.Entities.Items.ArcSwords
{
    public class PureBlade2 : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "刀" );
            Tooltip.AddTranslation( Chinese ,
                "是啊 你也很单纯" );
            DisplayName.AddTranslation( English , "Pure Blade" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 2 );
            Item.useTime -= 8;
            Item.useAnimation -= 8;
            base.SetDefaults( );
        }
    }
}
