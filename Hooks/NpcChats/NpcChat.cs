using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace EternalResolve.Hooks.NpcChats
{
    public class NpcChat : ModSystem
    {
        public static bool Enable = false;

        public NpcChatInterface NpcChatInterface;
        public override void Load( )
        {
            //     NpcChatInterface = new NpcChatInterface( );
            //       NpcChatInterface.Initialization( );
            //     On.Terraria.Main.GUIChatDrawInner += Main_GUIChatDrawInner;
            base.Load( );
        }

        public override void UpdateUI( GameTime gameTime )
        {
            if ( Main.LocalPlayer.talkNPC < 0 )
            {
                //        Enable = false;
                return;
            }
            if ( Enable )
            {
                //          NpcChatInterface.Update( gameTime );
            }
            base.UpdateUI( gameTime );
        }

        private void Main_GUIChatDrawInner( On.Terraria.Main.orig_GUIChatDrawInner orig , Terraria.Main self )
        {
            if ( Main.LocalPlayer.talkNPC < 0 )
            {
                orig.Invoke( self );
                return;
            }
            ScreenWidth = Main.screenWidth;
            Main.screenWidth = -800;
            orig.Invoke( self );
            Main.screenWidth = ScreenWidth;
            Enable = true;
            NpcChatInterface.Draw( Main.gameTimeCache );
        }

        public static int ScreenWidth;
    }
}
