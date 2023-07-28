using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Summons.Impacts
{
    public class Impact_Power : ModPlayer
    {
        protected override bool CloneNewInstances => true;

        public bool ImpactPower = false;

        /// <summary>
        /// 0: 跟随
        /// 1: 攻击
        /// </summary>
        public int PowerType = 0;

        public int Timer = 0;

        public Vector2 TargetPoint = Vector2.Zero;

        public override void ResetEffects( )
        {
            if ( Player.HeldItem.type != ModContent.ItemType<Impact>( ) &&
                Player.HasItem( ModContent.ItemType<Impact>( ) ) )
                ImpactPower = true;
            else
                ImpactPower = false;
            base.ResetEffects( );
        }

        public override void UpdateEquips( )
        {
            Timer++;
            TargetPoint = Player.position + ( Timer * 3.1415926f / 180 ).ToRotationVector2( ) * 50;
            base.UpdateEquips( );
        }
    }
}