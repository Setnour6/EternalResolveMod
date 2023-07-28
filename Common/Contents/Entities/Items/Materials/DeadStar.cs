using Terraria;
using Terraria.DataStructures;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Entities.Items.Materials
{
    public class DeadStar : ERItem
    {
        //暂未编写获取方式。
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "死去的星" );
            DisplayName.AddTranslation( English , "Dead Star" );
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 5 , 5 ) );
            ItemID.Sets.ItemIconPulse[ Item.type ] = true;
            ItemID.Sets.ItemNoGravity[ Item.type ] = true;
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
        }

        public override void SetDefaults( )
        {
            Item.width = 26;
            Item.height = 30;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 1;
        }
    }
}
