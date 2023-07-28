using Microsoft.Xna.Framework;

using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Slashs
{
    public class SlashSoul_Loot : GlobalNPC
    {
        public override void ModifyNPCLoot( NPC npc , NPCLoot npcLoot )
        {
            npcLoot.Add( ItemDropRule.Common( ModContent.ItemType<SlashSoul>( ) , 100 , 2 , 5 ) );
            base.ModifyNPCLoot( npc , npcLoot );
        }
    }
    public class SlashSoul : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "破碎刀魂" );
            DisplayName.AddTranslation( English , "Shattered Soul of the Blade" );
            Main.RegisterItemAnimation( Item.type , new DrawAnimationVertical( 4 , 6 ) );
            ItemID.Sets.AnimatesAsSoul[ Item.type ] = true;
            ItemID.Sets.ItemIconPulse[ Item.type ] = true;
            ItemID.Sets.ItemNoGravity[ Item.type ] = true;
        }
        public override void SetDefaults( )
        {
            ToItem( 3 );
            Item.maxStack = 999;
        }
        public override void GrabRange( Player player , ref int grabRange )
        {
            grabRange *= 3;
        }
        public override void PostUpdate( )
        {
            Lighting.AddLight( Item.Center , Color.WhiteSmoke.ToVector3( ) * 0.55f * Main.essScale );
        }
    }
}