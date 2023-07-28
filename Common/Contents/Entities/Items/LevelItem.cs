using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using EternalResolve.Common.Contents.Modulars.RefineSystemModular;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;

namespace EternalResolve.Common.Contents.Entities.Items
{
    public abstract class LevelItem : ERItem
    {
        public virtual string[ ] ChineseText { get; } = new string[ ]
        {


        };

        public virtual string[ ] EnglishText { get; } = new string[ ]
        {

        };

        public override void UpdateInventory( Player player )
        {
            string text = "";
            if ( Language.ActiveCulture == EternalResolve.Chinese )
            {
                for ( int count = 0; count < Item.GetGlobalItem<WeaponRefine>( ).Level; count++ )
                {
                    if ( count < Item.GetGlobalItem<WeaponRefine>( ).Level - 1 )
                        text += ChineseText[ count ] + "\n";
                    else
                        text += ChineseText[ count ];
                }
            }
            else
            {
                for ( int count = 0; count < Item.GetGlobalItem<WeaponRefine>( ).Level; count++ )
                {
                    if ( count < Item.GetGlobalItem<WeaponRefine>( ).Level - 1 )
                        text += EnglishText[ count ] + "\n";
                    else
                        text += EnglishText[ count ];
                }
            }
            Item.GetGlobalItem<WeaponRefine>( ).LevelText = new TextLine( text , Color.White );
            base.UpdateInventory( player );
        }

    }
}
