using Terraria;
using Terraria.ID;

namespace EternalResolve.Common.Codes.Utils
{
    public class GameInformation
    {
        public bool Sever
        {
            get
            {
                return Main.netMode == NetmodeID.Server;
            }
        }
    }
}
