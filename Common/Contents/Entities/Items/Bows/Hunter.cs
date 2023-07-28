using EternalResolve.Common.Contents.Entities.Items.Materials;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Bows
{
    public class Hunter : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "猎弓" );
            Tooltip.AddTranslation( Chinese , "" +
                "\"啊，这有只兔子。\"\n" +
                "有10%几率将箭矢转化为高速骨箭。" );

            DisplayName.AddTranslation( English , "Hunter" );
            Tooltip.AddTranslation( English , "" +
                "\"Ah! There is a rabbit here !!!\"\n" +
                "Has a 10% chance to convert the arrow into a high-speed bone arrow." );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToBow( 1 );
            Item.damage += 2;
            Item.useTime += 9;
            Item.useAnimation += 9;
            Item.value = Item.sellPrice( 0 , 0 , 50 );
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if ( Main.rand.Next( 10 ) == 5 )
                type = ProjectileID.BoneArrow;
            return base.Shoot( player , source , position , velocity , type , damage , knockback );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.WoodenBow , 1 ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
                AddTile( TileID.Anvils ).
                Register( );
        }
    }
}
