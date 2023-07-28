using EternalResolve.Common.Contents.Modulars;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Swords
{
    public class Meltdown : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "熔毁" );
            DisplayName.AddTranslation( English , "Meltdown" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 3 );
            Item.damage += 3;
            Item.value = Item.sellPrice( 0 , 0 , 75 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            base.SetDefaults( );
        }
        public override void OnHitNPC( Player player , NPC target , int damage , float knockBack , bool crit )
        {
            target.AddBuff( BuffID.OnFire , 120 );
            base.OnHitNPC( player , target , damage , knockBack , crit );
        }
    }
}