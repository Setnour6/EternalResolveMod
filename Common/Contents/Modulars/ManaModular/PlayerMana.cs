using EternalResolve.Common.Contents.Entities.Buffs.Manas.Damages;
using EternalResolve.Common.Contents.Entities.Buffs.Manas.Debuff;
using EternalResolve.Common.Contents.Entities.Buffs.Manas.Defenses;
using EternalResolve.Common.Contents.Entities.Buffs.Manas.Speeds;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars.ManaModular
{
    public class PlayerMana_Get : GlobalNPC
    {
        public override void OnKill( NPC npc )
        {
            if ( !npc.SpawnedFromStatue )
            {
                int value = 1 + ( npc.defense / 2 + npc.damage / 5 );
                Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue += value;
                if ( Language.ActiveCulture == EternalResolve.Chinese )
                    CombatText.NewText( npc.getRect( ) , Color.MediumPurple , "魔能 +" + value );
                else
                    CombatText.NewText( npc.getRect( ) , Color.MediumPurple , "Mana +" + value );
            }
            base.OnKill( npc );
        }
    }
    public class PlayerMana : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public int ManaValue = 0;

        public int ManaMax = 1000;

        public override void ResetEffects( )
        {
            ManaMax = 1000;
            base.ResetEffects( );
        }

        public override void Kill( double damage , int hitDirection , bool pvp , PlayerDeathReason damageSource )
        {
            if ( Player.GetModPlayer<PlayerMana>( ).ManaValue > 200 )
                Player.GetModPlayer<PlayerMana>( ).ManaValue -= Main.rand.Next( 100 , 200 );
            base.Kill( damage , hitDirection , pvp , damageSource );
        }

        public override void PostUpdate( )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                if ( ManaValue < 0 )
                    ManaValue = 0;
                else if ( ManaValue > ManaMax )
                    ManaValue = ManaMax;
                if ( ( (float) ManaValue / (float) ManaMax ) > 0.8f )
                {
                    Player.AddBuff( ModContent.BuffType<ManaMoveSpeed_12>( ) , 1 );
                    Player.AddBuff( ModContent.BuffType<MeleeDamage_8>( ) , 1 );
                    Player.AddBuff( ModContent.BuffType<ManaDefense_3>( ) , 1 );
                }
                if ( ( (float) ManaValue / (float) ManaMax ) < 0.1f )
                {
                    Player.AddBuff( ModContent.BuffType<DeMoveSpeed_12>( ) , 1 );
                }
            }
            base.PostUpdate( );
        }

        public override void LoadData( TagCompound tag )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                ManaValue = tag.GetInt( "EternalResolve:PlayerMana" );
            }
            base.LoadData( tag );
        }
        public override void SaveData( TagCompound tag )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                tag.Add( "EternalResolve:PlayerMana" , ManaValue );
            }
        }

        public override void ModifyHitNPC( Item item , NPC target , ref int damage , ref float knockback , ref bool crit )
        {
            if ( !target.SpawnedFromStatue && Main.rand.Next( 10 ) == 5 && Main.netMode == NetmodeID.MultiplayerClient )
            {
                int value = 1 + ( target.defense / 4 + target.damage / 10 );
                Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue += value;
                if ( Language.ActiveCulture == EternalResolve.Chinese )
                    CombatText.NewText( target.getRect( ) , Color.MediumPurple , "魔能 +" + value );
                else
                    CombatText.NewText( target.getRect( ) , Color.MediumPurple , "Mana +" + value );
            }
            base.ModifyHitNPC( item , target , ref damage , ref knockback , ref crit );
        }
        public override void ModifyHitNPCWithProj( Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection )
        {
            if ( !target.SpawnedFromStatue && Main.rand.Next( 10 ) == 5 )
            {
                int value = 1 + ( target.defense / 4 + target.damage / 10 );
                Main.LocalPlayer.GetModPlayer<PlayerMana>( ).ManaValue += value;
                if ( Language.ActiveCulture == EternalResolve.Chinese )
                    CombatText.NewText( target.getRect( ) , Color.MediumPurple , "魔能 +" + value );
                else
                    CombatText.NewText( target.getRect( ) , Color.MediumPurple , "Mana +" + value );
            }
            base.ModifyHitNPCWithProj( proj , target , ref damage , ref knockback , ref crit , ref hitDirection );
        }
    }
}
