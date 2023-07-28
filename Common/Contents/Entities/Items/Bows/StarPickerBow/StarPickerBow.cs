using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows.StarPickerBow
{
    public class StarPickerBow : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "摘星者" );
            Tooltip.AddTranslation( Chinese , "" +
                "你的攻击对生命值低于50%的敌人必定造成暴击" );

            DisplayName.AddTranslation( English , "Star Picker" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToBow( 6 );
            Item.damage += 3;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.UseSound = SoundID.Item5;
            Item.shootSpeed = 10;
            Item.value = Item.sellPrice( 2 );
            Item.shoot = ModContent.ProjectileType<StarPickerBow_Pro>( );
            Item.shootSpeed = 14f;
            base.SetDefaults( );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2( -6 , 0 );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            position = player.Center + Main.rand.NextVector2Unit( ) * 20;
            type = ModContent.ProjectileType<StarPickerBow_Pro>( );
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
    }
}
