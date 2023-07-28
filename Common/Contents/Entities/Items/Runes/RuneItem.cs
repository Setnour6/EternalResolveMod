using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Runes
{
    public enum RuneType : int
    {
        /// <summary>
        /// 粗糙
        /// </summary>
        Rough,
        /// <summary>
        /// 普通
        /// </summary>
        Ordinary,
        /// <summary>
        /// 精良
        /// </summary>
        Excellent,
        /// <summary>
        /// 卓越
        /// </summary>
        Preeminent,
        /// <summary>
        /// 传奇
        /// </summary>
        Legend
    }

    public class RuneItem : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

        public CompleteSet CompleteSet;

        public bool IsRune = false;

        public RuneType RuneType;

        static List<string> _runetypeText = new List<string>( )
        {
            "粗糙",
            "普通",
            "精良",
            "卓越",
            "传奇",
            "限定"
        };

        static List<string> _runetypeEnglishTranslateText = new List<string>( )
        {
            "Rough",
            "Ordinary",
            "Excellent",
            "Preeminent",
            "Legend",
        };

        static List<Color> _runtTypeLevelColor = new List<Color>( )
        {
            Color.Gray,
            Color.White,
            Color.LightBlue,
            Color.BlueViolet,
            Color.OrangeRed,
        };

        public TextLine TextLine;

        public override void SetDefaults( Item item )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                if( CompleteSet == null )
                    CompleteSet = new CompleteSet( );
                item.GetGlobalItem<RuneItem>( ).RuneType = RuneType.Rough;
                base.SetDefaults( item );
                if ( item.GetGlobalItem<RuneItem>( ).IsRune )
                    item.GetGlobalItem<RuneItem>( ).TextLine = new TextLine( "" , Color.LightBlue );
            }
        }

        public override void UpdateInventory( Item item , Player player )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                base.UpdateInventory( item , player );
                if ( item.GetGlobalItem<RuneItem>( ).IsRune )
                {
                    if ( Language.ActiveCulture == EternalResolve.Chinese )
                        item.GetGlobalItem<RuneItem>( ).TextLine.Text = "◆ 符印级别: " + _runetypeText[ (int) item.GetGlobalItem<RuneItem>( ).RuneType ];
                    else
                        item.GetGlobalItem<RuneItem>( ).TextLine.Text = "◆ Rune Level: " + _runetypeEnglishTranslateText[ (int) item.GetGlobalItem<RuneItem>( ).RuneType ];

                    item.GetGlobalItem<RuneItem>( ).TextLine.Color = _runtTypeLevelColor[ (int) item.GetGlobalItem<RuneItem>( ).RuneType ];
                }
            }
        }
    }
}