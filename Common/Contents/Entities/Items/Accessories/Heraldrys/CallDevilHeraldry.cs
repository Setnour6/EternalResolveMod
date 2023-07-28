using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class CallDevilHeraldry : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "唤魔徽章" );
            Tooltip.AddTranslation( Chinese , "" +
                "增加 1 个仆从位和 1 个哨兵位\n" +
                "增加 18% 的召唤伤害" );

            DisplayName.AddTranslation( English , "Call Devil Heraldry" );
            Tooltip.AddTranslation( English , "" +
                "Add 1 servant position and 1 sentry position\n" +
                "Increases summon damage by 18%" );

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
            player.maxMinions++;
            player.maxTurrets++;
            player.GetKnockback(DamageClass.Summon).Base += 0.5f;
            player.GetDamage( DamageClass.Melee ) += 0.18f;
        }
        public override void AddRecipes( )
        {
            CreateRecipe( ).
                AddIngredient( ModContent.ItemType<InsectHeraldry>( ) , 1 ).
                AddIngredient( ModContent.ItemType<SpriteHeraldry>( ) , 1 ).
                AddIngredient( ItemID.SummonerEmblem , 1 ).
                AddTile( TileID.MythrilAnvil ).
                Register( );
        }
    }
}