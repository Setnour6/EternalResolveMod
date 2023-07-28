using EternalResolve.Common.Contents.Entities.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows
{
    public class SteamBow : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "蒸汽弓" );
            Tooltip.AddTranslation( Chinese ,
                "\"啊，这有只G胖。\"\n" +
                "有10%几率将箭矢转化为狱岩箭" );
            DisplayName.AddTranslation( English , "Steam Bow" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToBow( 2 );
            Item.useAnimation += 8;
            Item.useTime += 8;
            Item.crit -= 10;
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            if ( Main.rand.Next( 10 ) == 5 )
            {
                type = 41;
            }
            base.ModifyShootStats( player , ref position , ref velocity , ref type , ref damage , ref knockback );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ItemID.IronBow , 1 ).
            AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
            AddTile( TileID.WorkBenches ).
            Register( );
            CreateRecipe( ).
            AddIngredient( ItemID.LeadBow , 1 ).
            AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 1 ).
            AddTile( TileID.WorkBenches ).
            Register( );
        }
    }
}
