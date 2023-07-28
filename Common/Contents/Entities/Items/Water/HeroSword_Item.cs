namespace EternalResolve.Common.Contents.Entities.Items.Water
{
    public class HeroSword_Item : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "英雄剑" );
            DisplayName.AddTranslation( English , "Hero Sword" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            base.SetDefaults( );
        }
    }
}
