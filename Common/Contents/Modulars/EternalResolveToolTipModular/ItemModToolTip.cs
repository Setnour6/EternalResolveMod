using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items.Currencies;
using EternalResolve.Common.Contents.Entities.Items.Runes;
using EternalResolve.Common.Contents.Modulars.ModifyModular.Items;
using EternalResolve.Common.Contents.Modulars.RefineSystemModular;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular
{
    public class ItemModToolTip
    {
        public Item Item { get; private set; }

        public Texture2D BackGround { get; private set; }

        public int Border { get; private set; } = 14;

        public static int SpacingNum { get; private set; } = 6;

        public List<Line> Lines = new List<Line>( );

        int Width = 0;

        int Height = 0;

        SpacingLine Spacing = new SpacingLine( );

        public void Draw( Item item , int x , int y )
        {
            Item = item;
            BackGround = Item.GetGlobalItem<ItemToolTipHack>( ).BackGround;
            Lines.Clear( );
            if ( Language.ActiveCulture == EternalResolve.Chinese )
                SetLineChinese( );
            else
                SetLineEnglish( );
            for ( int count = 0; count < Lines.Count; count++ )
                Lines[ count ].CheckSize( );
            List<int> widthsdata = new List<int>( );
            int heightAll = 0;
            for ( int count = 0; count < Lines.Count; count++ )
            {
                heightAll = 0;
                for ( int count2 = 0; count2 < count; count2++ )
                    heightAll += Lines[ count2 ].Height + SpacingNum;
                if ( Lines[ count ].DrawType == 1 )
                {
                    Lines[ count ].SetPosition( Border + x + Width / 2 - Lines[ count ].Width / 2 , 6 + Border + heightAll + y );
                }
                else
                    Lines[ count ].SetPosition( Border + x , 6 + Border + heightAll + y );
                widthsdata.Add( Lines[ count ].Width );
            }
            Width = widthsdata.Max( );
            Spacing.Height = 0;
            Spacing.Width = Width;
            Height = heightAll;
            if ( x + Width > Main.screenWidth )
            {
                x = Main.screenWidth - Width - 2 * Border;
                for ( int count = 0; count < Lines.Count; count++ )
                {
                    heightAll = 0;
                    for ( int count2 = 0; count2 < count; count2++ )
                        heightAll += Lines[ count2 ].Height + SpacingNum;
                    if ( Lines[ count ].DrawType == 1 )
                    {
                        Lines[ count ].SetPosition( Border + x + Width / 2 - Lines[ count ].Width / 2 , 6 + Border + heightAll + y );
                    }
                    else
                        Lines[ count ].SetPosition( Border + x , 6 + Border + heightAll + y );
                }
            }
            if ( y + heightAll + Border > Main.screenHeight )
            {
                y = Main.screenHeight - Height - Border;
                for ( int count = 0; count < Lines.Count; count++ )
                {
                    heightAll = 0;
                    for ( int count2 = 0; count2 < count; count2++ )
                        heightAll += Lines[ count2 ].Height + SpacingNum;
                    if ( Lines[ count ].DrawType == 1 )
                    {
                        Lines[ count ].SetPosition( Border + x + Width / 2 - Lines[ count ].Width / 2 , 6 + Border + heightAll + y );
                    }
                    else
                        Lines[ count ].SetPosition( Border + x , 6 + Border + heightAll + y );
                }
            }
            if ( ModContent.GetInstance<ClientSideConfig>( ).mouseDrawItemTooltip )
                Main.spriteBatch.DrawNinePieces( BackGround , x , y , Width + 2 * Border , 6 + Height + Border , Border );
            for ( int count = 0; count < Lines.Count; count++ )
                Lines[ count ].Draw( );
        }

        public void SetLineChinese( )
        {
            Lines.Add( Spacing.Clone( ) );
            Lines.Add( new ItemImageLine( Item ) );
            Lines.Add( Spacing.Clone( ) );
            if ( Item.GetGlobalItem<WeaponRefine>( ).Level > 1 )
                Lines.Add( new TextLine( "◆ " + Item.HoverName + " +" + Item.GetGlobalItem<WeaponRefine>( ).Level , ItemRarity.GetColor( Item.rare ) ) );
            else
                Lines.Add( new TextLine( "◆ " + Item.HoverName , ItemRarity.GetColor( Item.rare ) ) );

            if ( Item.GetGlobalItem<RuneItem>( ).TextLine != null && Item.GetGlobalItem<RuneItem>( ).TextLine.Text != string.Empty )
            {
                Lines.Add( Item.GetGlobalItem<RuneItem>( ).TextLine );
            }
            Lines.Add( Spacing.Clone( ) );
            {
                if ( Item.damage > 0 )
                    Lines.Add( new TextLine( "◆ " + (int) ( Item.damage * Main.LocalPlayer.GetDamage( DamageClass.Generic ).Additive * Main.LocalPlayer.GetDamage( Item.DamageType ).Additive ) + "点 " + Item.DamageType.DisplayName , Color.White ) );
                if ( ( Item.damage > 0 || Main.LocalPlayer.GetCritChance( Item.DamageType ) > 0 ) && Item.IsWeapon( ) )
                    Lines.Add( new TextLine( "◆ " + ( Main.LocalPlayer.GetCritChance( Item.DamageType ) + Item.crit + 4 ) + "% 暴击概率" , Color.White ) );
                if ( Item.knockBack > 0 )
                    Lines.Add( new TextLine( "◆ " + Item.knockBack + "点 击退能力" , Color.White ) );
                if ( Item.useTime > 0 && Item.damage > 0 )
                    Lines.Add( new TextLine( "◆ " + ( 60 / (float) Item.useTime ).ToString( "F1" ) + "次/秒 施法时间" , Color.White ) );
                if ( Item.useAnimation > 0 && Item.damage > 0 )
                    Lines.Add( new TextLine( "◆ " + ( 60 / (float) Item.useAnimation ).ToString( "F1" ) + "次/秒 挥舞时间" , Color.White ) );
                if ( Item.mana > 0 )
                    Lines.Add( new TextLine( "◆ " + Item.mana + "点 魔力消耗" , Color.White ) );
                if ( Item.defense > 0 )
                    Lines.Add( new TextLine( "◆ " + Item.defense + "点 防御加成" , Color.White ) );
                if ( Item.useAmmo > 0 )
                {
                    Item ammo = new Item( );
                    ammo.SetDefaults( Item.useAmmo , false );
                    Lines.Add( new TextLine( "◆ 使用 " + ammo.Name + " 作为弹药" , Color.White ) );
                }
                if ( Item.prefix > 0 )
                {
                    Item Item2 = Main.tooltipPrefixComparisonItem;
                    if ( Item2 == null || Item2.netID != Item.netID )
                    {
                        Item2 = new Item( );
                        Item2.netDefaults( Item.netID );
                    }
                    if ( Item2.damage != Item.damage )
                    {
                        double num = Item.damage - Item2.damage;
                        num = num / Item2.damage * 100.0;
                        num = Math.Round( num );
                        if ( num > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ 攻击力增加 " + num + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ 攻击力减少 " + num + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.useAnimation != Item.useAnimation )
                    {
                        double num2 = (float) Item.useAnimation - (float) Item2.useAnimation;
                        num2 = num2 / (double) Item2.useAnimation * 100.0;
                        num2 = Math.Round( num2 );
                        num2 *= -1.0;
                        if ( num2 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ 挥舞速度增加 " + num2 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ 挥舞速度减少 " + num2 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.crit != Item.crit )
                    {
                        double num3 = Item.crit - Item2.crit;
                        if ( num3 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ 暴击概率增加 " + num3 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ 暴击概率减少 " + num3 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.mana != Item.mana )
                    {
                        double num4 = (float) Item.mana - (float) Item2.mana;
                        num4 = num4 / (double) Item2.mana * 100.0;
                        num4 = Math.Round( num4 );
                        if ( num4 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ 魔力消耗增加 " + num4 + "%" , Color.Red ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ 魔力消耗减少 " + num4 + "%" , Color.Green ) );
                        }
                    }
                    if ( Item2.scale != Item.scale )
                    {
                        double num5 = Item.scale - Item2.scale;
                        num5 = num5 / (double) Item2.scale * 100.0;
                        num5 = Math.Round( num5 );
                        if ( num5 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ 大小增加 " + num5 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ 大小减少 " + num5 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.shootSpeed != Item.shootSpeed )
                    {
                        double num6 = Item.shootSpeed - Item2.shootSpeed;
                        num6 = num6 / (double) Item2.shootSpeed * 100.0;
                        num6 = Math.Round( num6 );
                        if ( num6 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ 使用速度增加 " + num6 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ 使用速度减少 " + num6 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.knockBack != Main.HoverItem.knockBack )
                    {
                        double num7 = Main.HoverItem.knockBack - Item2.knockBack;
                        num7 = num7 / (double) Item2.knockBack * 100.0;
                        num7 = Math.Round( num7 );
                        if ( num7 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ 击退能力增加 " + num7 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ 击退能力减少 " + num7 + "%" , Color.Red ) );
                        }
                    }
                    switch ( Item.prefix )
                    {
                        case 62:
                            Lines.Add( new TextLine( "◆ 防御增加 1" , Color.Green ) );
                            break;
                        case 63:
                            Lines.Add( new TextLine( "◆ 防御增加 2" , Color.Green ) );
                            break;
                        case 64:
                            Lines.Add( new TextLine( "◆ 防御增加 3" , Color.Green ) );
                            break;
                        case 65:
                            Lines.Add( new TextLine( "◆ 防御增加 4" , Color.Green ) );
                            break;
                        case 66:
                            Lines.Add( new TextLine( "◆ 魔力上限增加 20" , Color.Green ) );
                            break;
                        case 67:
                            Lines.Add( new TextLine( "◆ 暴击概率增加 2%" , Color.Green ) );
                            break;
                        case 68:
                            Lines.Add( new TextLine( "◆ 暴击概率增加 4%" , Color.Green ) );
                            break;
                        case 69:
                            Lines.Add( new TextLine( "◆ 伤害增加 1%" , Color.Green ) );
                            break;
                        case 70:
                            Lines.Add( new TextLine( "◆ 伤害增加 2%" , Color.Green ) );
                            break;
                        case 71:
                            Lines.Add( new TextLine( "◆ 伤害增加 3%" , Color.Green ) );
                            break;
                        case 72:
                            Lines.Add( new TextLine( "◆ 伤害增加 4%" , Color.Green ) );
                            break;
                        case 73:
                            Lines.Add( new TextLine( "◆ 移动速度增加 1%" , Color.Green ) );
                            break;
                        case 74:
                            Lines.Add( new TextLine( "◆ 移动速度增加 2%" , Color.Green ) );
                            break;
                        case 75:
                            Lines.Add( new TextLine( "◆ 移动速度增加 3%" , Color.Green ) );
                            break;
                        case 76:
                            Lines.Add( new TextLine( "◆ 移动速度增加 4%" , Color.Green ) );
                            break;
                        case 77:
                            Lines.Add( new TextLine( "◆ 近战速度增加 1%" , Color.Green ) );
                            break;
                        case 78:
                            Lines.Add( new TextLine( "◆ 近战速度增加 2%" , Color.Green ) );
                            break;
                        case 79:
                            Lines.Add( new TextLine( "◆ 近战速度增加 3%" , Color.Green ) );
                            break;
                        case 80:
                            Lines.Add( new TextLine( "◆ 近战速度增加 4%" , Color.Green ) );
                            break;
                    }
                }
                if ( Item.GetGlobalItem<WeaponRefine>( ).CanLevelUp )
                {
                    if ( Item.GetGlobalItem<WeaponRefine>( ).Level > 1 )
                    {
                        if ( Item.IsWeapon( ) )
                        {
                            Lines.Add( new TextLine( "◆ 造成 " + ( Item.GetGlobalItem<WeaponRefine>( ).Level * Item.GetGlobalItem<WeaponRefine>( ).Level ) / 2 + "% 额外伤害" , Color.LightBlue ) );
                        }
                        else if ( !Item.accessory && Item.defense > 0 )
                        {
                            Lines.Add( new TextLine( "◆ 提供 " + Item.GetGlobalItem<WeaponRefine>( ).Level * 2 + " 额外防御" , Color.LightBlue ) );
                        }
                    }
                    if ( Item.GetGlobalItem<WeaponRefine>( ).LevelText.Text != string.Empty )
                    {
                        Lines.Add( Item.GetGlobalItem<WeaponRefine>( ).LevelText );
                    }
                }
                if ( Item.damage > 0 || ( Item.GetGlobalItem<WeaponRefine>( ).Level > 1 ) || ( Item.GetGlobalItem<WeaponRefine>( ).LevelText.Text != string.Empty || ( Modular.RefineSystemInteracting && Item.GetGlobalItem<WeaponRefine>( ).MatExp > 0 ) ) ||
                    ( Item.damage > 0 && ( Main.LocalPlayer.GetCritChance( DamageClass.Generic ) > 0 || Main.LocalPlayer.GetCritChance( Item.DamageType ) > 0 ) )
                    || Item.knockBack > 0 || ( Item.useTime > 0 && Item.damage > 0 ) ||
                    ( Item.useAnimation > 0 && Item.damage > 0 ) || Item.mana > 0 || Item.defense > 0 || Item.useAmmo > 0 )
                    Lines.Add( Spacing.Clone( ) );
            }
            {
                if ( Modular.RefineSystemInteracting && Item.GetGlobalItem<WeaponRefine>( ).MatExp > 0 )
                {
                    Lines.Add( new TextLine( "◆ 可提供 " + Item.GetGlobalItem<WeaponRefine>( ).MatExp * Item.stack + " 精炼经验" , Color.White ) );
                }
            }
            {
                if ( Item.pick > 0 )
                    Lines.Add( new TextLine( "◆ 镐 " + Item.pick + "%" , Color.White ) );
                if ( Item.axe > 0 )
                    Lines.Add( new TextLine( "◆ 斧 " + Item.axe * 5 + "%" , Color.White ) );
                if ( Item.hammer > 0 )
                    Lines.Add( new TextLine( "◆ 锤 " + Item.hammer + "%" , Color.White ) );
                if ( Item.fishingPole > 0 )
                    Lines.Add( new TextLine( "◆ 渔 " + Item.fishingPole + "%" , Color.White ) );
                if ( Item.wornArmor && Main.LocalPlayer.setBonus != string.Empty )
                    Lines.Add( new TextLine( "◆ 当前套装属性: \n" +
                        "  " +
                        Main.LocalPlayer.setBonus , Color.White ) );
                if ( ( Item.wornArmor && Main.LocalPlayer.setBonus != string.Empty ) || Item.pick > 0 || Item.axe > 0 || Item.hammer > 0 || Item.fishingPole > 0 )
                    Lines.Add( Spacing.Clone( ) );
            }
            {
                if ( Item.material )
                    Lines.Add( new TextLine( "◆ 属于材料" , Color.White ) );
                if ( Item.accessory )
                    Lines.Add( new TextLine( "◆ 属于饰品" , Color.White ) );
                if ( Item.createTile > -1 )
                    Lines.Add( new TextLine( "◆ 属于物块" , Color.White ) );
                if ( Item.consumable )
                    Lines.Add( new TextLine( "◆ 属于消耗品" , Color.White ) );
                if ( Item.ModItem != null && Item.ModItem.CanRightClick( ) )
                    Lines.Add( new TextLine( "◆ 允许物品栏内对其右键" , Color.White ) );
                if ( Item.expert )
                    Lines.Add( new TextLine( "◆ 属于专家模式物品" , Color.Orange ) );
                if ( Item.master )
                    Lines.Add( new TextLine( "◆ 属于大师模式物品" , Color.Red ) );
                if ( Item.material || Item.accessory || Item.createTile > -1 || Item.consumable || Item.consumable || Item.ModItem != null && Item.ModItem.CanRightClick( ) ||
                  Item.expert || Item.master )
                    Lines.Add( Spacing.Clone( ) );
            }
            {
                if ( Item.GetGlobalItem<Modify_Authentication>( ).Authentication )
                    Lines.Add( new TextLine( "◆ 特标认证" , Color.Gold ) );
                if ( Item.ToolTip.Lines > 0 && Item.ToolTip.GetLine( 0 ) != "" )
                {
                    if ( Item.type == ModContent.ItemType<CleanStone>( ) )
                    {
                        Lines.Add( new TextLine( "◆ 货币介绍:" , Color.White ) );
                        for ( int count = 0; count < Item.ToolTip.Lines; count++ )
                            Lines.Add( new TextLine( "  " + Item.ToolTip.GetLine( count ) , Color.White ) );
                    }
                    else if ( !Item.GetGlobalItem<RuneItem>( ).IsRune )
                    {
                        Lines.Add( new TextLine( "◆ 物品介绍:" , Color.White ) );
                        for ( int count = 0; count < Item.ToolTip.Lines; count++ )
                            Lines.Add( new TextLine( "  " + Item.ToolTip.GetLine( count ) , Color.White ) );
                    }
                    else if ( Item.GetGlobalItem<RuneItem>( ).IsRune )
                    {
                        Lines.Add( new TextLine( "◆ 符印介绍: " , Color.White ) );
                        for ( int count = 0; count < Item.ToolTip.Lines; count++ )
                            Lines.Add( new TextLine( Item.ToolTip.GetLine( count ) , Color.White ) );
                    }
                }
                if ( Item.GetGlobalItem<ItemToolTipHack>( ).TextLine.Text != string.Empty )
                {
                    Lines.Add( Item.GetGlobalItem<ItemToolTipHack>( ).TextLine );
                }
                if ( ( Item.ToolTip.Lines > 0 && Item.ToolTip.GetLine( 0 ) != "" ) || ( Item.GetGlobalItem<ItemToolTipHack>( ).TextLine.Text != string.Empty ) )
                    Lines.Add( Spacing.Clone( ) );
                if ( Item.GetGlobalItem<Modify_RecordMaker>( ).RecordName != string.Empty )
                    Lines.Add( new TextLine( "◆ 制造者: " + Item.GetGlobalItem<Modify_RecordMaker>( ).RecordName , Color.Green ) );
                if ( Item.type == ItemID.PaintRoller )
                {
                    Lines.Add( new TextLine( "" +
                        "◆ 漆刷，认准生隆装饰材料店，" +
                        "品质优良，易用耐用！" , Color.BlueViolet ) );
                }
                if ( Item.ModItem != null )
                    Lines.Add( new TextLine( "◆ 该物品属于 " + Item.ModItem.Mod.Name , Color.BlueViolet ) );
                else
                    Lines.Add( new TextLine( "◆ 该物品属于原版" , Color.BlueViolet ) );
                if ( Main.npcShop == 0 )
                    Lines.Add( new TextLine( "" , Color.BlueViolet ) );
            }
            {
                Color valueColor = Color.Gray;
                if ( Main.npcShop > 0 && Item.value > 0 )
                {
                    int buyValue;//买价
                    int sellValue;//卖价
                    int resultValue;//结果
                    int finalValue;//最终计算得到价
                    Main.LocalPlayer.GetItemExpectedPrice( Item , out buyValue , out sellValue );
                    if ( !Item.isAShopItem && !Item.buyOnce )
                        resultValue = buyValue;
                    else
                        resultValue = sellValue;
                    if ( resultValue > 0 )
                    {
                        string text = "";
                        int[ ] Company = new int[ 4 ];
                        finalValue = resultValue * Item.stack;
                        if ( !Item.buy )
                        {
                            finalValue = resultValue / 5;
                            if ( finalValue < 1 )
                                finalValue = 1;
                            int finalValue2 = finalValue;
                            finalValue *= Item.stack;
                            int amount = Main.shopSellbackHelper.GetAmount( Item );
                            if ( amount > 0 )
                                finalValue += ( -finalValue2 + sellValue ) * Math.Min( amount , Item.stack );
                        }
                        if ( finalValue < 1 )
                            finalValue = 1;
                        if ( finalValue >= 1000000 )
                        {
                            Company[ 0 ] = finalValue / 1000000;
                            finalValue -= Company[ 0 ] * 1000000;
                        }
                        if ( finalValue >= 10000 )
                        {
                            Company[ 1 ] = finalValue / 10000;
                            finalValue -= Company[ 1 ] * 10000;
                        }
                        if ( finalValue >= 100 )
                        {
                            Company[ 2 ] = finalValue / 100;
                            finalValue -= Company[ 2 ] * 100;
                        }
                        if ( finalValue >= 1 )
                            Company[ 3 ] = finalValue;
                        if ( Company[ 3 ] > 0 )
                        {
                            text = Company[ 3 ] + "铜" + text;
                            valueColor = Color.DarkOrange;
                        }
                        if ( Company[ 2 ] > 0 )
                        {
                            text = Company[ 2 ] + "银 " + text;
                            valueColor = Color.Silver;
                        }
                        if ( Company[ 1 ] > 0 )
                        {
                            text = Company[ 1 ] + "金 " + text;
                            valueColor = Color.Gold;
                        }
                        if ( Company[ 0 ] > 0 )
                        {
                            text = Company[ 0 ] + "铂金 " + text;
                            valueColor = Color.Plum;
                        }
                        Lines.Add( Spacing.Clone( ) );
                        if ( !Item.buy )
                            Lines.Add( new TextLine( "◆ 卖出价: " + text , valueColor ) );
                        else
                            Lines.Add( new TextLine( "◆ 买入价: " + text , valueColor ) );
                        Lines.Add( new TextLine( "" , Color.BlueViolet ) );
                    }
                }
                else if ( Main.npcShop > 0 && Item.value == 0 )
                {
                    Lines.Add( new TextLine( "◆ 没有价值" , Color.Gray ) );
                    Lines.Add( new TextLine( "" , Color.BlueViolet ) );
                }
            }
        }

        public void SetLineEnglish( )
        {
            Lines.Add( Spacing.Clone( ) );
            Lines.Add( new ItemImageLine( Item ) );
            Lines.Add( Spacing.Clone( ) );
            if ( Item.GetGlobalItem<WeaponRefine>( ).Level > 1 )
                Lines.Add( new TextLine( "◆ " + Item.HoverName + " +" + Item.GetGlobalItem<WeaponRefine>( ).Level , ItemRarity.GetColor( Item.rare ) ) );
            else
                Lines.Add( new TextLine( "◆ " + Item.HoverName , ItemRarity.GetColor( Item.rare ) ) );

            if ( Item.GetGlobalItem<RuneItem>( ).TextLine != null && Item.GetGlobalItem<RuneItem>( ).TextLine.Text != string.Empty )
            {
                Lines.Add( Item.GetGlobalItem<RuneItem>( ).TextLine );
            }
            Lines.Add( Spacing.Clone( ) );
            {
                if ( Item.damage > 0 )
                    Lines.Add( new TextLine( "◆ " + (int) ( Item.damage * Main.LocalPlayer.GetDamage( DamageClass.Generic ).Additive * Main.LocalPlayer.GetDamage( Item.DamageType ).Additive ) + " " + Item.DamageType.DisplayName , Color.White ) );
                if ( Item.damage > 0 && ( Main.LocalPlayer.GetCritChance( DamageClass.Generic ) > 0 || Main.LocalPlayer.GetCritChance( Item.DamageType ) > 0 ) )
                    Lines.Add( new TextLine( "◆ " + ( Main.LocalPlayer.GetCritChance( DamageClass.Generic ) + Main.LocalPlayer.GetCritChance( Item.DamageType ) ) + "% Crit" , Color.White ) );
                if ( Item.knockBack > 0 )
                    Lines.Add( new TextLine( "◆ " + Item.knockBack + " KnockBack" , Color.White ) );
                if ( Item.useTime > 0 && Item.damage > 0 )
                    Lines.Add( new TextLine( "◆ " + ( 60 / (float) Item.useTime ).ToString( "F1" ) + "Times / Second Casting time" , Color.White ) );
                if ( Item.useAnimation > 0 && Item.damage > 0 )
                    Lines.Add( new TextLine( "◆ " + ( 60 / (float) Item.useAnimation ).ToString( "F1" ) + "Times / Second Waving time" , Color.White ) );
                if ( Item.mana > 0 )
                    Lines.Add( new TextLine( "◆ " + Item.mana + " Mana" , Color.White ) );
                if ( Item.defense > 0 )
                    Lines.Add( new TextLine( "◆ " + Item.defense + " Defense" , Color.White ) );
                if ( Item.useAmmo > 0 )
                {
                    Item ammo = new Item( );
                    ammo.SetDefaults( Item.useAmmo , false );
                    Lines.Add( new TextLine( "◆ Use " + ammo.Name + " as ammunition" , Color.White ) );
                }
                if ( Item.prefix > 0 )
                {
                    Item Item2 = Main.tooltipPrefixComparisonItem;
                    if ( Item2 == null || Item2.netID != Item.netID )
                    {
                        Item2 = new Item( );
                        Item2.netDefaults( Item.netID );
                    }
                    if ( Item2.damage != Item.damage )
                    {
                        double num = Item.damage - Item2.damage;
                        num = num / Item2.damage * 100.0;
                        num = Math.Round( num );
                        if ( num > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ Damage add " + num + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ Damage reduce " + num + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.useAnimation != Item.useAnimation )
                    {
                        double num2 = (float) Item.useAnimation - (float) Item2.useAnimation;
                        num2 = num2 / (double) Item2.useAnimation * 100.0;
                        num2 = Math.Round( num2 );
                        num2 *= -1.0;
                        if ( num2 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ Use animation speed add " + num2 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆  Use animation speed reduce" + num2 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.crit != Item.crit )
                    {
                        double num3 = (float) Item.crit - (float) Item2.crit;
                        if ( num3 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ Crit add " + num3 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ Crit reduce " + num3 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.mana != Item.mana )
                    {
                        double num4 = (float) Item.mana - (float) Item2.mana;
                        num4 = num4 / (double) Item2.mana * 100.0;
                        num4 = Math.Round( num4 );
                        if ( num4 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ Mana use add " + num4 + "%" , Color.Red ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ Mana use reduce " + num4 + "%" , Color.Green ) );
                        }
                    }
                    if ( Item2.scale != Item.scale )
                    {
                        double num5 = Item.scale - Item2.scale;
                        num5 = num5 / (double) Item2.scale * 100.0;
                        num5 = Math.Round( num5 );
                        if ( num5 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ Size add " + num5 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ Size reduce " + num5 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.shootSpeed != Item.shootSpeed )
                    {
                        double num6 = Item.shootSpeed - Item2.shootSpeed;
                        num6 = num6 / (double) Item2.shootSpeed * 100.0;
                        num6 = Math.Round( num6 );
                        if ( num6 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ Use speed add " + num6 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ Use speed reduce " + num6 + "%" , Color.Red ) );
                        }
                    }
                    if ( Item2.knockBack != Main.HoverItem.knockBack )
                    {
                        double num7 = Main.HoverItem.knockBack - Item2.knockBack;
                        num7 = num7 / (double) Item2.knockBack * 100.0;
                        num7 = Math.Round( num7 );
                        if ( num7 > 0.0 )
                        {
                            Lines.Add( new TextLine( "◆ KnockBack add " + num7 + "%" , Color.Green ) );
                        }
                        else
                        {
                            Lines.Add( new TextLine( "◆ KnockBack reduce" + num7 + "%" , Color.Red ) );
                        }
                    }
                    switch ( Item.prefix )
                    {
                        case 62:
                            Lines.Add( new TextLine( "◆ Defense add 1" , Color.Green ) );
                            break;
                        case 63:
                            Lines.Add( new TextLine( "◆ Defense add 2" , Color.Green ) );
                            break;
                        case 64:
                            Lines.Add( new TextLine( "◆ Defense add 3" , Color.Green ) );
                            break;
                        case 65:
                            Lines.Add( new TextLine( "◆ Defense add 4" , Color.Green ) );
                            break;
                        case 66:
                            Lines.Add( new TextLine( "◆ Mana max value add 20" , Color.Green ) );
                            break;
                        case 67:
                            Lines.Add( new TextLine( "◆ Crit add 2%" , Color.Green ) );
                            break;
                        case 68:
                            Lines.Add( new TextLine( "◆ Crit add 4%" , Color.Green ) );
                            break;
                        case 69:
                            Lines.Add( new TextLine( "◆ Damage add 1%" , Color.Green ) );
                            break;
                        case 70:
                            Lines.Add( new TextLine( "◆ Damage add 2%" , Color.Green ) );
                            break;
                        case 71:
                            Lines.Add( new TextLine( "◆ Damage add 3%" , Color.Green ) );
                            break;
                        case 72:
                            Lines.Add( new TextLine( "◆ Damage add 4%" , Color.Green ) );
                            break;
                        case 73:
                            Lines.Add( new TextLine( "◆ MoveSpeed add 1%" , Color.Green ) );
                            break;
                        case 74:
                            Lines.Add( new TextLine( "◆ MoveSpeed add 2%" , Color.Green ) );
                            break;
                        case 75:
                            Lines.Add( new TextLine( "◆ MoveSpeed add 3%" , Color.Green ) );
                            break;
                        case 76:
                            Lines.Add( new TextLine( "◆ MoveSpeed add 4%" , Color.Green ) );
                            break;
                        case 77:
                            Lines.Add( new TextLine( "◆ MeleeSpeed add 1%" , Color.Green ) );
                            break;
                        case 78:
                            Lines.Add( new TextLine( "◆ MeleeSpeed add 2%" , Color.Green ) );
                            break;
                        case 79:
                            Lines.Add( new TextLine( "◆ MeleeSpeed add 3%" , Color.Green ) );
                            break;
                        case 80:
                            Lines.Add( new TextLine( "◆ MeleeSpeed add 4%" , Color.Green ) );
                            break;
                    }
                }
                if ( Item.GetGlobalItem<WeaponRefine>( ).Level > 1 )
                {
                    Lines.Add( new TextLine( "◆ Cause " + ( Item.GetGlobalItem<WeaponRefine>( ).Level * Item.GetGlobalItem<WeaponRefine>( ).Level ) / 2 + "% Additional damage" , Color.LightBlue ) );
                }
                if ( Item.GetGlobalItem<WeaponRefine>( ).CanLevelUp )
                {
                    if ( Item.GetGlobalItem<WeaponRefine>( ).LevelText.Text != string.Empty )
                    {
                        Lines.Add( Item.GetGlobalItem<WeaponRefine>( ).LevelText );
                    }
                }
                if ( Item.damage > 0 || ( Item.GetGlobalItem<WeaponRefine>( ).Level > 1 ) || ( Item.GetGlobalItem<WeaponRefine>( ).CanLevelUp ) ||
                    ( Item.damage > 0 && ( Main.LocalPlayer.GetCritChance( DamageClass.Generic ) > 0 || Main.LocalPlayer.GetCritChance( Item.DamageType ) > 0 ) )
                    || Item.knockBack > 0 || ( Item.useTime > 0 && Item.damage > 0 ) ||
                    ( Item.useAnimation > 0 && Item.damage > 0 ) || Item.mana > 0 || Item.defense > 0 || Item.useAmmo > 0 )
                    Lines.Add( Spacing.Clone( ) );
            }
            if ( Modular.RefineSystemInteracting && Item.GetGlobalItem<WeaponRefine>( ).MatExp > 0 )
            {
                Lines.Add( new TextLine( "◆ Available " + Item.GetGlobalItem<WeaponRefine>( ).MatExp * Item.stack + " exp" , Color.White ) );
            }
            {
                if ( Item.pick > 0 )
                    Lines.Add( new TextLine( "◆ Pick " + Item.pick + " %" , Color.White ) );
                if ( Item.axe > 0 )
                    Lines.Add( new TextLine( "◆ Axe " + Item.axe * 5 + " %" , Color.White ) );
                if ( Item.hammer > 0 )
                    Lines.Add( new TextLine( "◆ Hammer " + Item.hammer + " %" , Color.White ) );
                if ( Item.fishingPole > 0 )
                    Lines.Add( new TextLine( "◆ Fish " + Item.fishingPole + " %" , Color.White ) );
                if ( Main.LocalPlayer.setBonus != string.Empty )
                    Lines.Add( new TextLine( "◆ Current suite properties: \n" +
                        "  " +
                        Main.LocalPlayer.setBonus , Color.White ) );
                if ( Main.LocalPlayer.setBonus != string.Empty || Item.pick > 0 || Item.axe > 0 || Item.hammer > 0 || Item.fishingPole > 0 )
                    Lines.Add( Spacing.Clone( ) );
            }
            {
                if ( Item.material )
                    Lines.Add( new TextLine( "◆ Belongs to material" , Color.White ) );
                if ( Item.accessory )
                    Lines.Add( new TextLine( "◆ Belonging to accessory" , Color.White ) );
                if ( Item.createTile > -1 )
                    Lines.Add( new TextLine( "◆ Belonging to block" , Color.White ) );
                if ( Item.consumable )
                    Lines.Add( new TextLine( "◆ Belonging to consumables" , Color.White ) );
                if ( Item.ModItem != null && Item.ModItem.CanRightClick( ) )
                    Lines.Add( new TextLine( "◆ Allow right clicking in the inventory" , Color.White ) );
                if ( Item.expert )
                    Lines.Add( new TextLine( "◆ Items in expert mode" , Color.Orange ) );
                if ( Item.master )
                    Lines.Add( new TextLine( "◆ Items in master mode" , Color.Red ) );
                if ( Item.material || Item.accessory || Item.createTile > -1 || Item.consumable || ( Item.ModItem != null && Item.ModItem.CanRightClick( ) ) || Item.expert || Item.master )
                    Lines.Add( Spacing.Clone( ) );
            }
            {
                if ( Item.GetGlobalItem<Modify_Authentication>( ).Authentication )
                    Lines.Add( new TextLine( "◆ Special standard certification" , Color.Gold ) );
                if ( Item.ToolTip.Lines > 0 && Item.ToolTip.GetLine( 0 ) != "" )
                {
                    if ( Item.type == ModContent.ItemType<CleanStone>( ) )
                    {
                        Lines.Add( new TextLine( "◆ Currency introduction:" , Color.White ) );
                        for ( int count = 0; count < Item.ToolTip.Lines; count++ )
                            Lines.Add( new TextLine( "  " + Item.ToolTip.GetLine( count ) , Color.White ) );
                    }
                    else if ( !Item.GetGlobalItem<RuneItem>( ).IsRune )
                    {
                        Lines.Add( new TextLine( "◆ Item introduction:" , Color.White ) );
                        for ( int count = 0; count < Item.ToolTip.Lines; count++ )
                            Lines.Add( new TextLine( "  " + Item.ToolTip.GetLine( count ) , Color.White ) );
                    }
                    else if ( Item.GetGlobalItem<RuneItem>( ).IsRune )
                    {
                        Lines.Add( new TextLine( "◆ Rune introduction:" , Color.White ) );
                        for ( int count = 0; count < Item.ToolTip.Lines; count++ )
                            Lines.Add( new TextLine( "  " + Item.ToolTip.GetLine( count ) , Color.White ) );
                    }
                }
                if ( Item.GetGlobalItem<ItemToolTipHack>( ).TextLine.Text != string.Empty )
                {
                    Lines.Add( Item.GetGlobalItem<ItemToolTipHack>( ).TextLine );
                }
                if ( ( Item.ToolTip.Lines > 0 && Item.ToolTip.GetLine( 0 ) != "" ) || ( Item.GetGlobalItem<ItemToolTipHack>( ).TextLine.Text != string.Empty ) )
                    Lines.Add( Spacing.Clone( ) );
                if ( Item.GetGlobalItem<Modify_RecordMaker>( ).RecordName != string.Empty )
                    Lines.Add( new TextLine( "◆ Maker: " + Item.GetGlobalItem<Modify_RecordMaker>( ).RecordName , Color.Green ) );
                if ( Item.ModItem != null )
                    Lines.Add( new TextLine( "◆ This Item belongs to " + Item.ModItem.Mod.Name , Color.BlueViolet ) );
                else
                    Lines.Add( new TextLine( "◆ This Item belongs to the original" , Color.BlueViolet ) );
                if ( Main.npcShop == 0 )
                    Lines.Add( new TextLine( "" , Color.BlueViolet ) );
            }
            {
                Color valueColor = Color.Gray;
                if ( Main.npcShop > 0 && Item.value > 0 )
                {
                    int buyValue;//买价
                    int sellValue;//卖价
                    int resultValue;//结果
                    int finalValue;//最终计算得到价
                    Main.LocalPlayer.GetItemExpectedPrice( Item , out buyValue , out sellValue );
                    if ( !Item.isAShopItem && !Item.buyOnce )
                        resultValue = buyValue;
                    else
                        resultValue = sellValue;
                    if ( resultValue > 0 )
                    {
                        string text = "";
                        int[ ] Company = new int[ 4 ];
                        finalValue = resultValue * Item.stack;
                        if ( !Item.buy )
                        {
                            finalValue = resultValue / 5;
                            if ( finalValue < 1 )
                                finalValue = 1;
                            int finalValue2 = finalValue;
                            finalValue *= Item.stack;
                            int amount = Main.shopSellbackHelper.GetAmount( Item );
                            if ( amount > 0 )
                                finalValue += ( -finalValue2 + sellValue ) * Math.Min( amount , Item.stack );
                        }
                        if ( finalValue < 1 )
                            finalValue = 1;
                        if ( finalValue >= 1000000 )
                        {
                            Company[ 0 ] = finalValue / 1000000;
                            finalValue -= Company[ 0 ] * 1000000;
                        }
                        if ( finalValue >= 10000 )
                        {
                            Company[ 1 ] = finalValue / 10000;
                            finalValue -= Company[ 1 ] * 10000;
                        }
                        if ( finalValue >= 100 )
                        {
                            Company[ 2 ] = finalValue / 100;
                            finalValue -= Company[ 2 ] * 100;
                        }
                        if ( finalValue >= 1 )
                            Company[ 3 ] = finalValue;
                        if ( Company[ 3 ] > 0 )
                        {
                            text = Company[ 3 ] + "Copper" + text;
                            valueColor = Color.DarkOrange;
                        }
                        if ( Company[ 2 ] > 0 )
                        {
                            text = Company[ 2 ] + "Silver " + text;
                            valueColor = Color.Silver;
                        }
                        if ( Company[ 1 ] > 0 )
                        {
                            text = Company[ 1 ] + "Gold " + text;
                            valueColor = Color.Gold;
                        }
                        if ( Company[ 0 ] > 0 )
                        {
                            text = Company[ 0 ] + "Platinum " + text;
                            valueColor = Color.Plum;
                        }
                        Lines.Add( Spacing.Clone( ) );
                        if ( !Item.buy )
                            Lines.Add( new TextLine( "◆ SELL: " + text , valueColor ) );
                        else
                            Lines.Add( new TextLine( "◆ BUY: " + text , valueColor ) );
                        Lines.Add( new TextLine( "" , Color.BlueViolet ) );
                    }
                }
                else if ( Main.npcShop > 0 && Item.value == 0 )
                {
                    Lines.Add( new TextLine( "◆ No value" , Color.Gray ) );
                    Lines.Add( new TextLine( "" , Color.BlueViolet ) );
                }
            }
        }

    }
}