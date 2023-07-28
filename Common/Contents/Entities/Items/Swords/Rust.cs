using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalResolve.Common.Contents.Entities.Items.Swords
{
    public class Rust : ERItem
    {
        public override void SetStaticDefaults( )
        {
            DisplayName.AddTranslation( Chinese , "生锈的大刀片" );
            DisplayName.AddTranslation( English , "Rust Knife" );
            base.SetStaticDefaults( );
        }
        public override void SetDefaults( )
        {
            ToSword( 1 );
            Item.damage = 2;
            Item.knockBack = 2f;
            base.SetDefaults( );
        }
    }
}
