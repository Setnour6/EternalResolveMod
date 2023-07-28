using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular.UI.Quests
{
    public class NoneQuest : Quest
    {
        public override void Init( )
        {
            QuestName = ( Language.ActiveCulture == EternalResolve.Chinese ? "暂无任务" : "None quest" );
            QuestText = ( Language.ActiveCulture == EternalResolve.Chinese ?
                "你目前难得清闲。" :
                "Rare leisure." );
            base.Init( );
        }
        public override bool UpdateCheckEvent( )
        {
            return false;
        }
        public override List<Item> QuestLoot( )
        {
            List<Item> items = new List<Item>( );
            items.Add( new Item( ItemID.None ) );
            return items;
        }
    }
}
