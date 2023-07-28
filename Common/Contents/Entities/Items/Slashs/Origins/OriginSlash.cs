using EternalResolve.Common.Contents.Modulars;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs.Origins
{
    public class OriginSlash : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "起源" );
            DisplayName.AddTranslation( English , "Origin Slash" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 2 );
            Item.damage = 9;
            Item.useTime = Item.useAnimation;
            Item.UseSound = null;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<OriginSlashChop>( );
            Item.shootSpeed = 8f;
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
            Item.value = Item.sellPrice( 0 , 1 );
            base.SetDefaults( );
        }
    }
}
