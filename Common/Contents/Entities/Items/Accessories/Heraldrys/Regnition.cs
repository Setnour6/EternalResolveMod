using EternalResolve.Common.Contents.Modulars;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Heraldrys
{
    public class Regnition : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "余烬" );
            Tooltip.AddTranslation( Chinese , "纪念品" );
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 12 , 6 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
        }
        public override void SetDefaults( )
        {
            ToAccessory( 9 );
            Item.GetGlobalItem<AntiCheating>( ).FormalChannel = false;
        }
    }
}