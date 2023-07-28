using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Players
{
    public class Modify_SpawnTimeSetup : ModPlayer
    {
        public override void Kill( double damage , int hitDirection , bool pvp , PlayerDeathReason damageSource )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                Player.respawnTimer = 300;
            }
            base.Kill( damage , hitDirection , pvp , damageSource );
        }
    }
}
