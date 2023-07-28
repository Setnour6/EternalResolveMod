using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class CelestialHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "天星徽章" );
            Tooltip.AddTranslation( Chinese , "" +
                "减少10%魔力消耗\n" +
                "增加50点魔力上限\n" +
                "增加12%的魔法伤害和暴击率" );

            DisplayName.AddTranslation( English , "Celestial Heraldry" );
            Tooltip.AddTranslation( English , "" +
            "Reduces mana cost by 10% \n" +
            "Increases the magic limit by 50 points \n" +
            "Increases magic damage and critical hit rate by 12%" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 12 , 5 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 5 );
            Item.value = Item.sellPrice( 0 , 5 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.statManaMax2 += 60;
            player.manaCost *= 0.8f;
            player.GetDamage( DamageClass.Magic ) += 0.15f;
            player.GetCritChance( DamageClass.Magic ) += 15;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<StarHeraldry>( ) , 1 ).
                AddIngredient( ModContent.ItemType<StarShineHeraldry>( ) , 1 ).
                AddIngredient( ItemID.SorcererEmblem , 1 ).
                AddTile( TileID.MythrilAnvil ).
                Register( );
        }
    }
}
