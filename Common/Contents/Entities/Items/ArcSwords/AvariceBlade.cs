using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.ArcSwords
{
    public class AvariceBlade : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "贪婪之刃" );
            Tooltip.AddTranslation( Chinese , "" +
                "你拥有的铂金币越多 伤害越高\n" +
                "该武器不接受任何其他形式的伤害加成" );
            DisplayName.AddTranslation( English , "Avarice Blade" );
            Tooltip.AddTranslation( English , "" +
                "The more platinum coins you have, the higher the damage\n" +
                "This weapon does not accept form any other damage bonus" );
        }
        public override void SetDefaults( )
        {
            Item.damage = 20;
            Item.width = 34;
            Item.height = 38;
            Item.rare = 11;
            Item.crit = 4;
            Item.autoReuse = true;
            Item.useStyle = 1;
            Item.DamageType = DamageClass.Melee;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.knockBack = 4f;
            Item.UseSound = SoundID.Item1;
        }
        public override void HoldItem( Player player )
        {
            int num = 0;
            for ( int i = 0; i < player.inventory.Length; i++ )
            {
                if ( player.inventory[ i ].type == ItemID.PlatinumCoin )
                {
                    num += player.inventory[ i ].stack;
                }
            }
            Item.damage = 20 + (int) ( ( (float) Math.Log( num + 1 ) ) * 100 );
            base.HoldItem( player );
        }
    }
}