using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalResolve.Common.Contents.Entities.Items.Tools.Picks
{
    public class BrokenPick : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "破损不堪的镐子" );
            DisplayName.AddTranslation( English , "Broken Pick" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToPick( 1 );
            Item.rare = -1;
            base.SetDefaults( );
        }
    }
}