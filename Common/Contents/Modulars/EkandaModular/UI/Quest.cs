using EternalResolve.Common.Contents.Modulars.EkandaModular.UI.Quests;
using System.Collections.Generic;
using Terraria;

namespace EternalResolve.Common.Contents.Modulars.EkandaModular.UI
{
    public class Quest
    {
        public string QuestName = "";

        public string QuestText = "";

        public virtual void Init( )
        {

        }
        public virtual List<Item> QuestLoot( )
        {
            return null;
        }
        public virtual bool UpdateCheckEvent( )
        {
            return false;
        }

        public static List<Quest> Quests = new List<Quest>( )
        {
            new TheWanderingEarthI(),

            new NoneQuest()
        };
    }
}