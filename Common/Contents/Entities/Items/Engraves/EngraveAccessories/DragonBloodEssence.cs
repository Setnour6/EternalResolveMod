using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Engraves.EngraveAccessories
{
    public class DragonBloodEssence_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            if ( npc.type == NPCID.CultistDragonHead || npc.type == NPCID.CultistDragonBody1
                || npc.type == NPCID.CultistDragonBody2 || npc.type == NPCID.CultistDragonBody3 ||
                npc.type == NPCID.CultistDragonBody4 || npc.type == NPCID.CultistDragonTail )
            {
                npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<DragonBloodEssence>( ) , 1 , 1 , 10 ) );
            }
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class DragonBloodEssence_Power : ModPlayer
    {
        public bool Enable = false;

        protected override bool CloneNewInstances => true;

        public override void ResetEffects( )
        {
            Enable = false;
            base.ResetEffects( );
        }

        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( Enable && ( target.type == NPCID.CultistDragonHead || target.type == NPCID.CultistDragonBody1
                || target.type == NPCID.CultistDragonBody2 || target.type == NPCID.CultistDragonBody3 ||
                target.type == NPCID.CultistDragonBody4 || target.type == NPCID.CultistDragonTail ) )
            {
                damage = 666666;
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( Enable && ( target.type == NPCID.CultistDragonHead || target.type == NPCID.CultistDragonBody1
                || target.type == NPCID.CultistDragonBody2 || target.type == NPCID.CultistDragonBody3 ||
                target.type == NPCID.CultistDragonBody4 || target.type == NPCID.CultistDragonTail ) )
            {
                damage = 666666;
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
    public class DragonBloodEssence : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "龙之精血" );
            DisplayName.AddTranslation( English , "Dragon's blood essence" );
            Tooltip.AddTranslation( Chinese , "你的攻击将处决小白龙" );
            Tooltip.AddTranslation( English , "Your attack will execute the little white dragon" );
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
            player.GetModPlayer<DragonBloodEssence_Power>( ).Enable = true;
            base.UpdateAccessory( player , hideVisual );
        }
    }
}