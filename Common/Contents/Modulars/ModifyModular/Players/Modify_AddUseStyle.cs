using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Players
{
    public class Modify_AddUseStyle : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public override void PostUpdate( )
        {
            if ( Player.inventory[ Player.selectedItem ].useStyle == 714 )
            {
                Vector2 vector = Player.RotatedRelativePoint( Player.MountedCenter , true , true );
                float num7 = Main.mouseX + Main.screenPosition.X - vector.X;
                float num8 = Main.mouseY + Main.screenPosition.Y - vector.Y;
                Player.itemRotation = (float) Math.Atan2( (double) ( num8 * (float) Player.direction ) , (double) ( num7 * (float) Player.direction ) ) - Player.fullRotation;
                NetMessage.SendData( MessageID.PlayerControls , -1 , -1 , null , Player.whoAmI , 0f , 0f , 0f , 0 , 0 , 0 );
                NetMessage.SendData( MessageID.ItemAnimation , -1 , -1 , null , Player.whoAmI , 0f , 0f , 0f , 0 , 0 , 0 );
                if ( Player.itemAnimation < Player.itemAnimationMax * 0.333 )
                {
                    Player.bodyFrame.Y = Player.bodyFrame.Height * 3;
                }
                else if ( Player.itemAnimation < Player.itemAnimationMax * 0.666 )
                {
                    Player.bodyFrame.Y = Player.bodyFrame.Height * 2;
                }
                else
                {
                    Player.bodyFrame.Y = 0;
                }
            }
            base.PostUpdate( );
        }
        public override void PostItemCheck( )
        {
            if ( Player.channel && Player.inventory[ Player.selectedItem ].useStyle == 714 )
            {
                int useAnimation = Player.itemAnimationMax;
                bool flag82 = Player.itemTimeMax != 0;
                if ( flag82 )
                {
                    useAnimation = Player.itemTimeMax;
                }
                bool flag83 = useAnimation == 0;
                if ( flag83 )
                {
                    useAnimation = Player.inventory[ Player.selectedItem ].useAnimation;
                }
                float num26 = 1f - (float) ( Player.itemAnimation % useAnimation ) / (float) useAnimation;
                Player.CompositeArmStretchAmount stretch3 = Player.CompositeArmStretchAmount.Quarter;
                bool flag84 = num26 > 0.33f && num26 <= 0.66f;
                if ( flag84 )
                {
                    stretch3 = Player.CompositeArmStretchAmount.ThreeQuarters;
                }
                bool flag85 = num26 > 0.66f && num26 <= 1f;
                if ( flag85 )
                {
                    stretch3 = Player.CompositeArmStretchAmount.Full;
                }
                float rotation = Player.itemRotation - 1.5707964f * (float) Player.direction;
                Player.SetCompositeArmFront( true , stretch3 , rotation );
            }
            base.PostItemCheck( );
        }
    }
}