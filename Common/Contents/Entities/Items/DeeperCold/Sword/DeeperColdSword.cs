using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.DeeperCold.Sword
{
    public class DeeperColdSword : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "深寒" );
            Tooltip.AddTranslation( Chinese , "" +
                "当你在雪地造成暴击, 你获得12防御值, 持续5秒\n" +
                "剑气必定附加霜火\n" +
                "该物品存在你的背包内时, 你无视冻伤、霜火" );

            DisplayName.AddTranslation( English , "Deeper cold Bow" );
            Tooltip.AddTranslation( English , "" +
                "Increase 12 defense for 5 seconds when crit in the snow biome\n" +
                "Immune to Chilled and Frostburn when placed in inventory" );

            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 4 );
            Item.shoot = ModContent.ProjectileType<DeeperColdSword_Pro>( );
            Item.shootSpeed = 12;
            base.SetDefaults( );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            position += Main.rand.NextVector2Unit( ) * 10;
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
    }
}
