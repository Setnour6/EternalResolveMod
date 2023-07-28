using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Materials.Others
{
    public class SlimeKingEssence_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.KingSlime )
                npcLoot.Add( ItemDropRule.BossBag( ModContent.ItemType<SlimeKingEssence>( ) ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }

    public class SlimeKingEssence : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "史莱姆王之精华" );
            DisplayName.AddTranslation( English , "King Slime‘s Essence" );
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 5 , 5 ) );
            ItemID.Sets.ItemIconPulse[ Item.type ] = true;
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
        }

        public override void SetDefaults( )
        {
            Item.width = 28;
            Item.height = 40;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 1;
        }
    }
}
