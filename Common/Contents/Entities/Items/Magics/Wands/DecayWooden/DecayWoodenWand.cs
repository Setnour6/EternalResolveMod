using EternalResolve.Common.Contents.Entities.Items.Magics.Wands.Ebony;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.Wands.DecayWooden
{
    public class DecayWoodenWand : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "腐木法杖" );
            Tooltip.AddTranslation( Chinese ,
                "在命中敌人时\n" +
                "你获得 40 点魔力上限加成\n" +
                "持续 4 秒" );

            DisplayName.AddTranslation( English , "Decay Wooden Wand" );
            Tooltip.AddTranslation( English ,
                "When hitting the enemy\n" +
                "give you 40 manaMax\n" +
                "keep 4s" );
            Item.staff[ Item.type ] = true;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToRod( 2 );
            Item.damage += 3;
            Item.crit = 12;
            Item.useAnimation = 24;
            Item.useTime = 24;
            Item.knockBack = 4f;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item118;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<DecayWoodenWand_Pro>( );
            Item.shootSpeed = 7f;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<EbonyWand>( ) , 1 ).
            AddIngredient( ItemID.RottenChunk , 4 ).
            AddTile( TileID.DemonAltar ).
            Register( );
            base.AddRecipes( );
        }
    }
}
