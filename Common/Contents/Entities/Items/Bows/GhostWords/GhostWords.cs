using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.GhostWords
{
    public class GhostWords : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "鬼读 · 殛曌" );
            DisplayName.AddTranslation( English , "GHosT WoRD · Gi CieR" );
        }
        public override void SetDefaults( )
        {
            ToBow( 8 );
            Item.damage = 147;
            Item.channel = true;
            Item.useAmmo = AmmoID.None;
            Item.shoot = ModContent.ProjectileType<GhostBow>( );
            Item.shootSpeed = 10f;
            Item.noUseGraphic = true;
            Item.noMelee = true;
        }
        public override bool AltFunctionUse( Player player )
        {
            return true;
        }
        public override bool CanUseItem( Player player )
        {
            if ( player.altFunctionUse == 2 )
            {
                ToBow( 8 );
                Item.damage = 147;
                Item.channel = true;
                Item.useAmmo = AmmoID.None;
                Item.shoot = ModContent.ProjectileType<GhostGodArrow>( );
                Item.shootSpeed = 10f;
                Item.useTime = 48;
                Item.noUseGraphic = true;
                Item.noMelee = true;
            }
            else
            {
                ToBow( 8 );
                Item.damage = 147;
                Item.channel = true;
                Item.useAmmo = AmmoID.None;
                Item.shoot = ModContent.ProjectileType<GhostBow>( );
                Item.shootSpeed = 10f;
                Item.noUseGraphic = true;
                Item.noMelee = true;
            }
            return base.CanUseItem( player );
        }
    }
}
