using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves.EngraveAccessories
{
    public class DragonRelic_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.CultistDragonHead || npc.type == NPCID.CultistDragonBody1
                || npc.type == NPCID.CultistDragonBody2 || npc.type == NPCID.CultistDragonBody3 ||
                npc.type == NPCID.CultistDragonBody4 || npc.type == NPCID.CultistDragonTail )
            {
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<DragonRelic>( ) , 1 , 1 , 10 ) );
            }
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class DragonRelic_Power : ModPlayer
    {
        public bool Enable = false;

        protected override bool CloneNewInstances => true;

        public override void ResetEffects( )
        {
            Enable = false;
            base.ResetEffects( );
        }
    }
    public class DragonRelic_PowerForItem : GlobalItem
    {
        public override void GrabRange( Item item , Player player , ref int grabRange )
        {
            if ( item.type == ItemID.SoulofFlight && player.GetModPlayer<DragonRelic_Power>( ).Enable )
            {
                grabRange *= 10000;
            }
            base.GrabRange( item , player , ref grabRange );
        }
    }
    public class DragonRelic : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "龙之遗物" );
            DisplayName.AddTranslation( English , "Dragon Relic" );
            Tooltip.AddTranslation( Chinese , "允许你更快速地收集飞行之魂" );
            Tooltip.AddTranslation( English , "Allows you to collect soul of flight more quickly" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 4 );
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.GetModPlayer<DragonRelic_Power>( ).Enable = true;
            base.UpdateAccessory( player , hideVisual );
        }
    }
}
