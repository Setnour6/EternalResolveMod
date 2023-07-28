using EternalResolve.Common.Contents.Entities.Items.Magics.Wands.Ebony;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.Wands.BloodWooden
{
    public class BloodWoodenWand : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "血木法杖" );
            Tooltip.AddTranslation( Chinese ,
                "在命中敌人时\n" +
                "你获得 2点 生命回复加成\n" +
                "持续 2 秒" );

            DisplayName.AddTranslation( English , "Blood Wooden Wand" );
            Tooltip.AddTranslation( English ,
                "When hitting the enemy\n" +
                "give you 2 lifeRegen\n" +
                "keep 2s" );
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
            Item.shoot = ModContent.ProjectileType<BloodWoodenWand_Pro>( );
            Item.shootSpeed = 7f;
            Item.value = Item.sellPrice( 0 , 1 );
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<EbonyWand>( ) , 1 ).
            AddIngredient( ItemID.Vertebrae , 4 ).
            AddTile( TileID.DemonAltar ).
            Register( );
            base.AddRecipes( );
        }
    }
}