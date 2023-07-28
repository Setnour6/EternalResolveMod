using EternalResolve.Common.Contents.Entities.Items;
using EternalResolve.Common.Contents.Entities.Items.Currencies;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Npcs
{
    public class Modify_Strengthen : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        protected override bool CloneNewInstances => true;
		public override GlobalNPC Clone( NPC from, NPC to )
		{
			return base.Clone( from, to );
		}

		public bool Strengthened = false;

        bool _starengthened = false;

        public override void SetDefaults( NPC npc )
        {
            if ( npc.TypeName.Contains( "slime" ) || npc.TypeName.Contains( "Slime" ) || npc.TypeName.Contains( "史莱姆" ) )
            {
                npc.knockBackResist = -1;
            }
            base.SetDefaults( npc );
        }

        public override void AI( NPC npc )
        {
            if ( !DebugMode.Debug && !npc.TypeName.Contains( "傀儡" ) )
                npc.active = false;

            if ( npc.life > 12 && !npc.friendly && npc.active && !_starengthened && Main.rand.Next( 100 ) == 50 )
            {
                npc.life *= 2;
                npc.defense *= 2;
                npc.damage *= 2;
                npc.knockBackResist = -1;
                npc.GetGlobalNPC<Modify_Strengthen>( ).Strengthened = true;
                Main.NewTextMultiline( npc.TypeName + " 已经醒来" , false , Color.Purple );
            }
            _starengthened = true;

            if ( Main.time % 60 == 0 && Main.dayTime )
            {
                if ( npc.TypeName.Contains( "僵尸" ) || npc.TypeName.Contains( "zombie" ) || npc.type == NPCID.Zombie ||
                    npc.type == NPCID.ZombieDoctor || npc.type == NPCID.ZombieElf || npc.type == NPCID.ZombieElfBeard || npc.type == NPCID.ZombieElfGirl
                    || npc.type == NPCID.ZombieEskimo || npc.type == NPCID.ZombieMerman || npc.type == NPCID.ZombieMushroom || npc.type == NPCID.ZombieMushroomHat
                    || npc.type == NPCID.ZombiePixie || npc.type == NPCID.ZombieRaincoat || npc.type == NPCID.ZombieSuperman ||
                    npc.type == NPCID.ZombieSweater || npc.type == NPCID.ZombieXmas || npc.type == NPCID.ArmedTorchZombie || npc.type == NPCID.ArmedZombie ||
                    npc.type == NPCID.ArmedZombieCenx || npc.type == NPCID.ArmedZombieEskimo || npc.type == NPCID.ArmedZombiePincussion ||
                    npc.type == NPCID.ArmedZombieSlimed || npc.type == NPCID.ArmedZombieSwamp || npc.type == NPCID.ArmedZombieTwiggy )
                {
                    npc.StrikeNPC( 66 , 0 , 0 , false );
                    npc.AddBuff( BuffID.OnFire , 120 );
                }
            }
            base.AI( npc );
        }
        public override void OnKill( NPC npc )
        {
            if ( npc.GetGlobalNPC<Modify_Strengthen>( ).Strengthened )
            {
                ERItemManager.CreateItem( npc.Center , ModContent.ItemType<CleanStone>( ) , Main.rand.Next( 2 , 4 ) );
            }
            base.OnKill( npc );
        }
    }
}