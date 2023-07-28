using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class WarHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "战争徽章" );
            Tooltip.AddTranslation( Chinese , "" +
                "增加15%近战暴击率\n" +
                "增加12%近战速度\n" +
                "增加15%近战伤害" );

            DisplayName.AddTranslation( English , "War Heraldry" );
            Tooltip.AddTranslation( English , "" +
            "Increases melee critical hit rate by 15%\n" +
            "Increases melee speed by 12%\n" +
            "Increase melee damage by 15%" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 12 , 6 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 5 );
            Item.value = Item.sellPrice( 0 , 5 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.meleeSpeed += 0.12f;
            player.GetDamage( DamageClass.Melee ) += 0.15f;
            player.GetCritChance( DamageClass.Melee ) += 15;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
            AddIngredient( ModContent.ItemType<SwordHeraldry>( ) , 1 ).
            AddIngredient( ModContent.ItemType<ArcHeraldry>( ) , 1 ).
            AddIngredient( ItemID.WarriorEmblem , 1 ).
            AddTile( TileID.MythrilAnvil ).
            Register( );
        }
    }
}
