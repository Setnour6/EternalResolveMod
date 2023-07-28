using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class SnipingHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "狙击徽章" );
            Tooltip.AddTranslation( Chinese , "" +
                "增加15%的远程暴击率\n" +
                "增加你15%的远程伤害" );

            DisplayName.AddTranslation( English , "Sniping Heraldry" );
            Tooltip.AddTranslation( English , "" +
            "Increases ranged critical hit rate by 15% \n" +
            "Increases your ranged damage by 15%" );

            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 12 , 4 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 5 );
            Item.value = Item.sellPrice( 0 , 5 );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetCritChance( DamageClass.Ranged ) += 15;
            player.GetDamage( DamageClass.Ranged ) += 0.15f;
        }
        public override void AddRecipes( )
        {

            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<BowHeraldry>( ) , 1 ).
                AddIngredient( ModContent.ItemType<AmmoHeraldry>( ) , 1 ).
                AddIngredient( ItemID.RangerEmblem , 1 ).
                AddTile( TileID.MythrilAnvil ).
                Register( );
        }
    }
}
