using EternalResolve.Common.Codes.Utils;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve
{
    /// <summary>
    /// 代表从设备获取信息的信息类.
    /// </summary>
    public class FrontDevice : ModSystem
    {
        /// <summary>
        /// 用户输入.
        /// </summary>
        public static InputInformation Input = new InputInformation( );

        /// <summary>
        /// 窗体信息.
        /// </summary>
        public static FormInformation Form = new FormInformation( );

        /// <summary>
        /// 游戏信息.
        /// </summary>
        public static GameInformation Game = new GameInformation( );

        /// <summary>
        /// 空物品.
        /// </summary>
        public static Item EmptyItem;

        public override void Load( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                EmptyItem = new Item( ItemID.None );
                EmptyItem.SetDefaults( 0 );
            }
            base.Load( );
        }

        public override void PreUpdatePlayers( )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                Form.GetInformationFromDevice( );
                Input.GetInformationFromDevice( );
            }
            base.PreUpdatePlayers( );
        }
    }
}
