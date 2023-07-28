using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Materials
{
    public class CreaterSoul : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "造物神的余光" );
            DisplayName.AddTranslation( English , "Creater Soul" );
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 5 , 60 ) );
            ItemID.Sets.ItemIconPulse[ Item.type ] = true;
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
        }

        public override void SetDefaults( )
        {
            Item.width = 88;
            Item.height = 86;
            Item.rare = ItemRarityID.Red;
            Item.maxStack = 1;
        }
    }
}
