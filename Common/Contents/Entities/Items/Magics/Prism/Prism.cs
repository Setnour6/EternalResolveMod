using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Magics.Prism
{
    public class Prism : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese ,
                "三棱镜" );
            Tooltip.AddTranslation( Chinese ,
                "聚集阳光\n" +
                "在夜晚无法使用" );

            DisplayName.AddTranslation( English ,
                "Prism" );
            Tooltip.AddTranslation( English ,
                "Gather sunshine\n" +
                "This item cannot be used at night" );
        }
        public override void SetDefaults( )
        {
            Item.damage = 4;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 1;
            Item.width = 16;
            Item.height = 16;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.reuseDelay = 5;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item13;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.channel = true;
            Item.knockBack = 0f;
            Item.value = Item.sellPrice( 0 , 0 , 8 , 88 );
            Item.shoot = ModContent.ProjectileType<PrismLightProjectile>( );
            Item.shootSpeed = 30f;
            Item.rare = ItemRarityID.Orange;
        }
        public override bool CanUseItem( Player player )
        {
            return Main.dayTime;
        }

        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ItemID.Glass , 32 ).
                AddTile( TileID.WorkBenches ).
                Register( );
        }
    }
}