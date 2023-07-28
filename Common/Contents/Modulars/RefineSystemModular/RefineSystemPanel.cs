using EternalResolve.Assets.Textures.Systems.RefineSystems;
using EternalResolve.Common.Codes.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class RefineSystemPanel : Control
    {
        public RefineSystemSlot WeaponSlot;

        public RefineSystemButton Button;

        public RefineSystemBar Bar;

        public RefineSystemCloseButton Close;

        public RefineSystemItemPool Pool;

        public Vector2 Target;

        public override void Initialization( )
        {
            SetSize( 444 , 564 );

            Button = new RefineSystemButton( );
            Button.SubPosition = new Vector2( 136 , 480 );
            Button.LeftClickEvent += Button_LeftClickEvent;

            void Button_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                if ( WeaponSlot.Item != null && WeaponSlot.Item.type != ItemID.None )
                {
                    for ( int count = 0; count < Pool.Souls.Count; count++ )
                    {
                        Pool.Souls[ count ].Target = WeaponSlot.Center - Pool.Position;
                    }
                }
            }

            Register( Button );

            Bar = new RefineSystemBar( );
            Bar.SubPosition = new Vector2( 150 , 108 );
            Register( Bar );

            WeaponSlot = new RefineSystemSlot( RefineAssets.Slot );
            WeaponSlot.SubPosition = new Vector2( 70 , 92 );
            Register( WeaponSlot );

            Pool = new RefineSystemItemPool( );
            Pool.SubPosition = new Vector2( 76 , 168 );
            Register( Pool );

            Close = new RefineSystemCloseButton( );
            Close.SubPosition = new Vector2( 400 , 20 );
            Close.LeftClickEvent += Close_LeftClickEvent;
            void Close_LeftClickEvent( Codes.UI.Events.UIMouseEvent mouseEvent , Control element )
            {
                Modular.RefineSystemInteracting = false;
            }

            Register( Close );

            base.Initialization( );
        }


        public override void Update( )
        {
            Velocity = ( Target - Position ) * 0.09f;
            Position += Velocity;

            if ( Modular.RefineSystemInterface.Panel.WeaponSlot.Item != null &&
                Modular.RefineSystemInterface.Panel.WeaponSlot.Item.type != ItemID.None &&
                Main.mouseItem != null && Main.mouseItem.type != ItemID.None && Main.mouseItem.GetGlobalItem<WeaponRefine>( ).MatExp > 0 )
            {
                if ( Keyboard.GetState( ).IsKeyDown( Keys.LeftShift ) && Modular.RefineSystemInteracting )
                {
                    Item item = Main.mouseItem.Clone( );
                    item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                    Pool.AddItem( item , Main.rand.NextVector2Unit( 0 , 3.1415f / 2 ) * Main.rand.Next( Pool.Height ) );
                    Main.mouseItem.SetDefaults( 0 );
                    SoundEngine.PlaySound( SoundID.NPCHit11 );
                }
            }

            for ( int count = 0; count < Pool.Souls.Count; count++ )
            {
                if ( Vector2.Distance( Pool.Souls[ count ].Pos , WeaponSlot.Center - Pool.Position ) < 10 && Pool.Souls[ count ].Vel.Length( ) < 1 )
                {
                    for ( int count2 = 0; count2 < 32; count2++ )
                    {
                        RefineDust.NewDust( Pool.Position + Pool.Souls[ count ].Pos , Main.rand.NextVector2Unit( ) * 2 , 1f , Main.rand.Next( 0 , 4 ) * 0.5f ,
                            Color.White );
                    }
                    WeaponSlot.Item.GetGlobalItem<WeaponRefine>( ).Exp +=
                             Pool.Souls[ count ].Item.Clone( ).GetGlobalItem<WeaponRefine>( ).MatExp;
                    WeaponSlot.Item.GetGlobalItem<AntiCheating>( ).FormalChannel = true;
                    SoundEngine.PlaySound( SoundID.NPCHit11 );
                    Pool.Souls.Remove( Pool.Souls[ count ] );
                }
            }
            for ( int count = 0; count < RefineDust.dusts.Count; count++ )
                RefineDust.dusts[ count ].Update( );
            base.Update( );
        }
        public override void Draw( SpriteBatch spriteBatch )
        {
            spriteBatch.Draw( RefineAssets.Panel , Position , Color );
            spriteBatch.Draw( RefineAssets.PanelSlot , Position + new Vector2( 52 , 72 ) , Color );
            if ( ( Modular.RefineSystemInterface.Panel.WeaponSlot.Item != null &&
                Modular.RefineSystemInterface.Panel.WeaponSlot.Item.type != ItemID.None &&
                Main.mouseItem != null && Main.mouseItem.type != ItemID.None && Main.mouseItem.GetGlobalItem<WeaponRefine>( ).MatExp > 0 ) ||
                Keyboard.GetState( ).IsKeyDown( Keys.LeftShift ) )
            {
                spriteBatch.Draw( RefineAssets.CheckMouseItem , Position , Color );
            }
            base.Draw( spriteBatch );

            for ( int count = 0; count < RefineDust.dusts.Count; count++ )
                RefineDust.dusts[ count ].Draw( );
        }
    }
}
