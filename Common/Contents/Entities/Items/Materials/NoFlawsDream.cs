using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Materials
{
    public class NoFlawsDream_Loot : GlobalNPC
    {
        public override void ModifyGlobalLoot( GlobalLoot globalLoot )
        {
            globalLoot.Add( ItemDropRule.Common( ModContent.ItemType<NoFlawsDream>( ) , 50 , 5 , 10 ) );
            base.ModifyGlobalLoot( globalLoot );
        }
    }
    public class NoFlawsDream : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "无瑕梦境" );

            DisplayName.AddTranslation( English , "Flawless Dream" );

            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 6 , 8 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
            ItemID.Sets.ItemIconPulse[ Item.type ] = true;
            ItemID.Sets.ItemNoGravity[ Item.type ] = true;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToItem( 4 );
            Item.value = Item.sellPrice( 0 , 0 , 15 );
            base.SetDefaults( );
        }
        public override void GrabRange( Player player , ref int grabRange )
        {
            grabRange *= 4;
        }
        public override void Update( ref float gravity , ref float maxFallSpeed )
        {
            Lighting.AddLight( Item.Center , new Vector3( 0.7f , 1.15f , 1.25f ) );
            base.Update( ref gravity , ref maxFallSpeed );
        }
    }
}
