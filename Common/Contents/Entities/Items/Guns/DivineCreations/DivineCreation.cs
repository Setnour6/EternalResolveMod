using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Guns.DivineCreations
{
    public class DivineCreation : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "神造物" );
            DisplayName.AddTranslation( English , "Divine Creation" );
            Tooltip.AddTranslation( Chinese , "" +
                "距离他的诞生已经过去了二十六年...\n" +
                "它 则是随着那一片天光\n" +
                "应声而来。" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToGun( 7 );
            Item.damage = 26;
            Item.crit = 22;
            Item.useTime = 2;
            Item.useAnimation = 2;
            base.SetDefaults( );
        }
        public override Vector2? HoldoutOffset( )
        {
            return new Vector2( -8 , 0 );
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            Vector2 v = Vector2.Normalize( velocity );

            type = ModContent.ProjectileType<DivineCreation_Pro>( );
            velocity *= 1 - Main.rand.NextFloat( 0.1f , 0.2f );
            position += v * 80 + Main.rand.NextVector2Unit( ) * 10;
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
    }
}