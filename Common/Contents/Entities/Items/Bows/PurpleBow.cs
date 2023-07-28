using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Modulars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Bows
{
    public class PurpleBow : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "紫弓" );
            Tooltip.AddTranslation( Chinese , "有50%几率造成双倍伤害" );
            DisplayName.AddTranslation( English , "Purple Bow" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToBow( 2 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
        }
        public override void ModifyShootStats( Player player , ref Vector2 position , ref Vector2 velocity , ref int type , ref int damage , ref float knockback )
        {
            if ( Main.rand.Next( 10 ) <= 5 )
            {
                damage *= 2;
            }
        }

        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 6 ).
                AddIngredient( ItemID.PurpleDye , 4 ).
                AddIngredient( ItemID.LifeCrystal ).
                AddTile( TileID.Anvils ).
                Register( );
            base.AddRecipes( );
        }
    }
}