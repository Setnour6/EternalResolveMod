using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;

namespace EternalResolve.Common.Contents.Modulars.RuneModular.RuneSlots
{
    public class WeaponRune : Control
    {
        public WeaponRuneSlot[ ] Slot;

        public override void Initialization( )
        {
            SetSize( 308 , 304 );
            Slot = new WeaponRuneSlot[ 7 ];
            for ( int count = 0; count < Slot.Length; count++ )
                Slot[ count ] = new WeaponRuneSlot( );
            Slot[ 0 ].SubPosition = new Vector2( 54 , 0 );
            Slot[ 1 ].SubPosition = new Vector2( 160 , 0 );
            Slot[ 2 ].SubPosition = new Vector2( 0 , 98 );
            Slot[ 3 ].SubPosition = new Vector2( 107 , 98 );
            Slot[ 4 ].SubPosition = new Vector2( 214 , 98 );
            Slot[ 5 ].SubPosition = new Vector2( 53 , 196 );
            Slot[ 6 ].SubPosition = new Vector2( 161 , 196 );
            for ( int count = 0; count < Slot.Length; count++ )
                Register( Slot[ count ] );

            base.Initialization( );
        }
        public override void Update( )
        {
            Slot[ 0 ].SubPosition = new Vector2( 44 , 0 );
            Slot[ 1 ].SubPosition = new Vector2( 170 , 0 );
            Slot[ 2 ].SubPosition = new Vector2( -10 , 98 );
            Slot[ 3 ].SubPosition = new Vector2( 107 , 98 );
            Slot[ 4 ].SubPosition = new Vector2( 224 , 98 );
            Slot[ 5 ].SubPosition = new Vector2( 43 , 196 );
            Slot[ 6 ].SubPosition = new Vector2( 171 , 196 );
            base.Update( );
        }
    }
}
