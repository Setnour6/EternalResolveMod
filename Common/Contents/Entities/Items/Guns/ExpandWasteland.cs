using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Guns
{
    public class ExpandWasteland : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "扩荒" );
            DisplayName.AddTranslation( English , "Expand Wasteland" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToGun( 3 );
            Item.damage = 4;
            Item.useAmmo = AmmoID.Bullet;
            Item.shootSpeed = 30f;
            Item.UseSound = SoundID.Item11;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.scale = 0.7f;
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            type = 104;
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2?( new Vector2( -3f , -3f ) );
        }
    }
}
