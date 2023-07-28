using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Electrics
{
    public class ItemElectric : GlobalItem
    {
        public override bool InstancePerEntity => true;
        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

        /// <summary>
        /// 是否可充电.
        /// </summary>
        public bool CanCharge = false;

        /// <summary>
        /// 是否为供电物品.
        /// </summary>
        public bool IsBattery = false;

        /// <summary>
        /// 当前电量.
        /// </summary>
        public int ElectricValue = 0;

        /// <summary>
        /// 电量上限.
        /// </summary>
        public int ElectricValueMax = 0;

    }
}
