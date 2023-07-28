using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items;
using EternalResolve.Common.Contents.Entities.Items.Bows.ColdingSuns;
using EternalResolve.Common.Contents.Entities.Items.Currencies;
using EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Commands
{
    public class GiftRecord : ModPlayer
    {
        protected override bool CloneNewInstances => true;

        public bool Code_20210803_N = false;

        public bool Code_20210803_S0 = false;

        public bool Code_20210803_S1 = false;

        public bool Code_20210810_N = false;

        public bool Code_20210810_S0 = false;

        public bool Code_20210826_N = false;

        public bool Code_20210826_S0 = false;

        public bool Code_DreadSoulGift = false;

        public override void LoadData( TagCompound tag )
        {
            Code_20210803_N = tag.GetBool( "Code_20210803_N" );
            Code_20210803_S0 = tag.GetBool( "Code_20210803_S0" );
            Code_20210803_S1 = tag.GetBool( "Code_20210803_S1" );

            Code_20210810_N = tag.GetBool( "Code_20210810_N" );
            Code_20210810_S0 = tag.GetBool( "Code_20210810_S0" );

            Code_20210826_N = tag.GetBool( "Code_20210826_N" );
            Code_20210826_S0 = tag.GetBool( "Code_20210826_S0" );

            Code_DreadSoulGift = tag.GetBool( "Code_DreadSoulGift" );
            base.LoadData( tag );
        }
        public override void SaveData( TagCompound tag )
        {
            tag.Add( "Code_20210803_N" , Code_20210803_N );
            tag.Add( "Code_20210803_S0" , Code_20210803_S0 );
            tag.Add( "Code_20210803_S1" , Code_20210803_S1 );

            tag.Add( "Code_20210810_N" , Code_20210810_N );
            tag.Add( "Code_20210810_S0" , Code_20210810_S0 );

            tag.Add( "Code_20210826_N" , Code_20210826_N );
            tag.Add( "Code_20210826_S0" , Code_20210826_S0 );

            tag.Add( "Code_DreadSoulGift" , Code_DreadSoulGift );
        }
    }

    public class Gift : ModCommand
    {
        public override CommandType Type
            => CommandType.Chat;

        public override string Command
            => "Gift";

        public override string Usage
            => "/Gift <code>";

        public override string Description
            => "礼包码";

        public override void Action( CommandCaller caller , string input , string[ ] args )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                string dt = TimeInformation.GetNetDateTime( );
                DateTime Now = Convert.ToDateTime( dt );
                if ( input.Contains( "Code20210803N" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_20210803_N )
                {
                    if ( Now.Year <= 2021 && Now.Month < 9 )
                    {
                        caller.Player.GetModPlayer<GiftRecord>( ).Code_20210803_N = true;
                        ERItemManager.CreateItem( caller.Player.Center , ModContent.ItemType<CleanStone>( ) , 3600 );
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                    }
                    else
                    {
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "礼包码已过期." );
                    }
                }
                if ( input.Contains( "Code20210803S0" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_20210803_S0 )
                {
                    if ( Now.Year <= 2021 && Now.Month < 9 )
                    {
                        caller.Player.GetModPlayer<GiftRecord>( ).Code_20210803_S0 = true;
                        ERItemManager.CreateItem( caller.Player.Center , ModContent.ItemType<CleanStone>( ) , 7200 );
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                    }
                    else
                    {
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "礼包码已过期." );
                    }
                }
                if ( input.Contains( "Code20210803S1" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_20210803_S1 )
                {
                    if ( Now.Year <= 2021 && Now.Month < 9 )
                    {
                        caller.Player.GetModPlayer<GiftRecord>( ).Code_20210803_S1 = true;
                        ERItemManager.CreateItem( caller.Player.Center , ModContent.ItemType<CleanStone>( ) , 32000 );
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                    }
                    else
                    {
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "礼包码已过期." );
                    }
                }

                if ( input.Contains( "Code20210810N" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_20210810_N )
                {
                    if ( Now.Year <= 2021 && Now.Month < 10 )
                    {
                        caller.Player.GetModPlayer<GiftRecord>( ).Code_20210810_N = true;
                        ERItemManager.CreateItem( caller.Player.Center , ModContent.ItemType<CleanStone>( ) , 3600 );
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                    }
                    else
                    {
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "礼包码已过期." );
                    }
                }
                if ( input.Contains( "Code20210810S0" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_20210810_S0 )
                {
                    if ( Now.Year <= 2021 && Now.Month < 10 )
                    {
                        caller.Player.GetModPlayer<GiftRecord>( ).Code_20210810_S0 = true;
                        ERItemManager.CreateAuthenticationItem( caller.Player.Center , ModContent.ItemType<FiringSun>( ) );
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                    }
                    else
                    {
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "礼包码已过期." );
                    }
                }

                if ( input.Contains( "Code20210826N" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_20210826_N )
                {
                    if ( Now.Year <= 2021 && Now.Month < 10 )
                    {
                        caller.Player.GetModPlayer<GiftRecord>( ).Code_20210826_N = true;
                        ERItemManager.CreateItem( caller.Player.Center , ModContent.ItemType<CleanStone>( ) , 1800 );
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                    }
                    else
                    {
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "礼包码已过期." );
                    }
                }
                if ( input.Contains( "Code20210826S0" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_20210826_S0 )
                {
                    if ( Now.Year <= 2021 && Now.Month < 10 )
                    {
                        caller.Player.GetModPlayer<GiftRecord>( ).Code_20210826_S0 = true;
                        ERItemManager.CreateAuthenticationItem( caller.Player.Center , ModContent.ItemType<DreamStar>( ) );
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                    }
                    else
                    {
                        CombatText.NewText( caller.Player.getRect( ) , Color.Green , "礼包码已过期." );
                    }
                }

                if ( input.Contains( "Code_DreadSoulGift" ) && !caller.Player.GetModPlayer<GiftRecord>( ).Code_DreadSoulGift )
                {
                    caller.Player.GetModPlayer<GiftRecord>( ).Code_DreadSoulGift = true;
                    ERItemManager.CreateItem( caller.Player.Center , ModContent.ItemType<CleanStone>( ) , 180000 );
                    ERItemManager.CreateAuthenticationItem( caller.Player.Center , ModContent.ItemType<FiringSun>( ) );
                    CombatText.NewText( caller.Player.getRect( ) , Color.Green , "生效成功！" );
                }
                else
                {
                    CombatText.NewText( caller.Player.getRect( ) , Color.Green , "您已领取过该礼包." );
                }
            }
        }
    }
}