using EternalResolve.Common.Contents.Entities.Items.Materials;
using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Items.Materials.Others;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.ArcSwords.BlueDaggers
{
    public class BlueDagger : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "幽蓝匕首" );
            Tooltip.AddTranslation( Chinese , "" +
                "这是我年少时的梦。\n" +
                "我已经做了三年的梦了。\n" +
                "现在它越来越脆弱。\n" +
                "我只希望\n" +
                "最后的那一天可以晚点到来。" );

            DisplayName.AddTranslation( English , "Blue Dagger" );

        }
        public override void SetDefaults( )
        {
            Item.width = 14;
            Item.height = 38;
            Item.useAnimation = 25;
            Item.useTime = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.rare = ItemRarityID.Orange;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.noMelee = true;
            Item.damage = 20;
            Item.knockBack = 2f;
            Item.autoReuse = false;
            Item.noMelee = true;
            Item.DamageType = DamageClass.Magic;
            Item.shoot = ModContent.ProjectileType<BlueDagger_Pro>( );
            Item.shootSpeed = 15f;
            Item.value = 40000;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<SlimeKingEssence>( ) ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 2 ).
                AddIngredient( ModContent.ItemType<RealSilverIngot>( ) ).
                AddTile( TileID.Anvils ).
                Register( );
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<SlimeKingEssence>( ) ).
                AddIngredient( ModContent.ItemType<NoFlawsDream>( ) , 2 ).
                AddIngredient( ModContent.ItemType<RealTungstenIngot>( ) ).
                AddTile( TileID.Anvils );
        }
    }
}
