using EternalResolve.Common.Contents.Entities.Items.Tools.Axes;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular.UI.Quests
{
    public class TheWanderingEarthII : Quest
    {
        public override void Init( )
        {
            QuestName = ( Language.ActiveCulture == EternalResolve.Chinese ?
                "流浪地球 II" : "The Wandering Earth II" );
            QuestText = ( Language.ActiveCulture == EternalResolve.Chinese ?
                "拥有 1 个石块。" :
                "Own a stone block." );
            base.Init( );
        }
        public override bool UpdateCheckEvent( )
        {
            return Main.LocalPlayer.HasItem( ItemID.StoneBlock );
        }
        public override List<Item> QuestLoot( )
        {
            List<Item> items = new List<Item>( );
            items.Add( new Item( ModContent.ItemType<ElectricHeatingPlate>( ) ) );
            return items;
        }
    }
}
