using EternalResolve.Common.Contents.Entities.Items.Materials.Ingots;
using EternalResolve.Common.Contents.Entities.Items.Tools.Axes;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular.UI.Quests
{
    public class TheWanderingEarthI : Quest
    {
        public override void Init( )
        {
            QuestName = ( Language.ActiveCulture == EternalResolve.Chinese ?
                "流浪地球 - I" : "TheWanderingEarth - I" );
            QuestText = ( Language.ActiveCulture == EternalResolve.Chinese ?
                "成功开启星门来到这里。" :
                "Successfully opened the Stargate and came here." );

            base.Init( );
        }
        public override bool UpdateCheckEvent( )
        {
            return SubWorld_Ekanda.InEkandaWorld;
        }

        public override List<Item> QuestLoot( )
        {
            List<Item> items = new List<Item>( );
            items.Add( new Item( ModContent.ItemType<ElectricHeatingPlate>( ) ) );
            Item guding = new Item( ModContent.ItemType<Guding>( ) );
            guding.stack = 16;
            items.Add( guding );

            return items;
        }
    }
}
