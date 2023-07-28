using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.CandlelightWishs
{
    public class CandlelightWish : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "烛火之愿" );
            DisplayName.AddTranslation( English , "Candlelight's Wish" );
            Tooltip.AddTranslation( Chinese , "象征着对和平与美好生活的期盼与向往" );
            Tooltip.AddTranslation( English , "" +
                "It symbolizes the expectation \n" +
                "and yearning for peace and a better life." );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 4 );
            Item.damage += 10;
            Item.crit = 48;
            Item.useTime = Item.useAnimation;
            Item.UseSound = null;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<CandlelightWish_Cut>( );
            Item.shootSpeed = 8f;
            base.SetDefaults( );
        }
    }
}
