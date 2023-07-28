using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Accessories.Others
{
    public class M_ModPlayer : ModPlayer
    {
        public override bool PreHurt(bool pvp, bool quiet, ref int damage, ref int hitDirection, ref bool crit, ref bool customDamage, ref bool playSound, ref bool genGore, ref PlayerDeathReason damageSource, ref int cooldownCounter)
        {
            if ( NPC.downedBoss2 && Main.rand.Next( 100 ) < 5 )
            {
                //     Main.NewText( "金拱门桶: 精神偏转" );
                return false;
            }
            return true;
        }
    }
    public class M : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "金拱门桶" );
            DisplayName.AddTranslation( English , "M" );
            Tooltip.AddTranslation( Chinese , "" +
                "应征某人愿望诞生之物\n" +
                "具有成长性\n" +
                "它的功能并没有被他的主人公开" );
            Terraria.GameContent.Creative.CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[ Type ] = 1;
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToAccessory( 7 );
            Item.defense = 1;
            base.SetDefaults( );
        }
        public override void UpdateAccessory( Player player , bool hideVisual )
        {
            player.slotsMinions += 2;
            player.GetDamage( DamageClass.Summon ) += 0.05f;
            if ( NPC.downedSlimeKing )
            {
                player.moveSpeed += 0.01f;
                player.statDefense += 1;
                player.slotsMinions += 1;
            }
            if ( NPC.downedBoss3 )
            {
                player.noFallDmg = true;
            }
            if ( Main.hardMode )
            {
                player.statLifeMax2 += 50;
            }
            if ( NPC.downedMoonlord )
            {
                player.statLifeMax2 += 100;
                player.slotsMinions += 1;
            }

            base.UpdateAccessory( player , hideVisual );
        }
    }
}
