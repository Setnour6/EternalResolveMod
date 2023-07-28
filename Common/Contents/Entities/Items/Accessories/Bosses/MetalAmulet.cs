using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Bosses
{
    public class MetalAmulet : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "金属吊坠" );
            Tooltip.AddTranslation( Chinese ,
                "增加你5%的攻击力\n" +
                "\"反射着冷酷的色泽.\"" );

            DisplayName.AddTranslation( English , "Metal Amulet" );
            Tooltip.AddTranslation( English ,
                "Add 5% damage Value\n" +
                "\"Reflects a cold color.\"" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 3 );
            Item.defense = 2;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetDamage( DamageClass.Generic ) += 0.05f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.IronBar , 6 ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ItemID.LeadBar , 6 ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}
