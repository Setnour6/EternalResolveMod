using EternalResolve.Assets.Textures.StarTeleportPlatforms;
using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Entities.Items.Slashs.RedRiots;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Players
{
    public class DrawSwordFunction : ModPlayer
    {
        public static float Rotation;
        public static Vector2 Position;
        public static Texture2D Texture;
        public static SpriteEffects Direction;

        public static void DrawSword( )
        {
            Player Player = Main.LocalPlayer;
            Item Item = Player.HeldItem;
            Rectangle ItemFrame =
                ( Main.itemAnimations[ Item.type ] != null )
                ? Main.itemAnimations[ Item.type ].GetFrame( TextureAssets.Item[ Item.type ].Value ) :
                Utils.Frame( TextureAssets.Item[ Item.type ].Value , 1 , 1 , 0 , 0 );
            Vector2 ItemFrameSize = Utils.Size( ItemFrame );
            if ( Player.active &&
                Item.type != ItemID.None &&
                ( Item.useStyle == ItemUseStyleID.Swing || Item.useStyle == 13 ) &&
                Item.IsWeapon( ) &&
                Player.itemAnimation == 0 )
            {
                int theRad = 65 - Player.velocity.Y.ToInt( ) * 4;
                if ( theRad > 155 )
                    theRad = 155;
                if ( theRad < -35 )
                    theRad = -35;
                Rotation = Player.direction == 1 ? -theRad.ToRad( ) : theRad.ToRad( );
                IndividualWeapons( Player , Item );//个别武器需要单独计算旋转角度.
                Texture = TextureAssets.Item[ Player.HeldItem.type ].Value;
                Position = Player.position + Player.Size / 2 + Vector2.UnitY * 10 - Main.screenPosition;
                Direction = Player.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
                Main.spriteBatch.Draw( Texture , Position , new Rectangle?( ItemFrame ) , Lighting.GetColor( Player.position.X.ToInt( ) / 16 , Player.position.Y.ToInt( ) / 16 ) , Rotation , ItemFrameSize / 2 , 1f , Direction , 1f );
            }
        }

        public static void DrawBow( )
        {
            Player Player = Main.LocalPlayer;
            Item Item = Player.HeldItem;
            Rectangle ItemFrame =
                ( Main.itemAnimations[ Item.type ] != null )
                ? Main.itemAnimations[ Item.type ].GetFrame( TextureAssets.Item[ Item.type ].Value ) :
                Utils.Frame( TextureAssets.Item[ Item.type ].Value , 1 , 1 , 0 , 0 );
            Vector2 ItemFrameSize = Utils.Size( ItemFrame );
            if ( Player.active &&
                Item.type != ItemID.None &&
                ( Item.useStyle == ItemUseStyleID.Shoot ) &&
                Item.IsWeapon( ) &&
                Item.DamageType == DamageClass.Ranged &&
                !Item.staff[ Item.type ] &&
                Player.itemAnimation == 0 )
            {
                int theRad = 35;
                if ( theRad > 125 )
                    theRad = 125;
                if ( theRad < -5 )
                    theRad = -5;
                Rotation = Player.direction == 1 ? -theRad.ToRad( ) : theRad.ToRad( );
                Texture = TextureAssets.Item[ Player.HeldItem.type ].Value;
                Position = Player.position + Player.Size / 2 - Main.screenPosition;
                Direction = Player.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                Main.spriteBatch.Draw( Texture , Position , new Rectangle?( ItemFrame ) , Lighting.GetColor( Player.position.X.ToInt( ) / 16 , Player.position.Y.ToInt( ) / 16 ) , Rotation , ItemFrameSize / 2 , 1f , Direction , 1f );
            }
        }

        public static void DrawMagicStaff( )
        {
            Player Player = Main.LocalPlayer;
            Item Item = Player.HeldItem;
            Rectangle ItemFrame =
                ( Main.itemAnimations[ Item.type ] != null )
                ? Main.itemAnimations[ Item.type ].GetFrame( TextureAssets.Item[ Item.type ].Value ) :
                Utils.Frame( TextureAssets.Item[ Item.type ].Value , 1 , 1 , 0 , 0 );
            Vector2 ItemFrameSize = Utils.Size( ItemFrame );
            if ( Player.active &&
                Item.type != ItemID.None &&
                ( Item.useStyle == ItemUseStyleID.Shoot ) &&
                Item.IsWeapon( ) &&
                Item.staff[ Item.type ] &&
                Player.itemAnimation == 0 )
            {
                int theRad = 180;
                if ( theRad > 270 )
                    theRad = 270;
                if ( theRad < -150 )
                    theRad = -150;
                Rotation = Player.direction == 1 ? -theRad.ToRad( ) : theRad.ToRad( );
                Texture = TextureAssets.Item[ Player.HeldItem.type ].Value;
                Position = Player.position + Player.Size / 2 - Main.screenPosition;
                Direction = Player.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
                Main.spriteBatch.Draw( Texture , Position , new Rectangle?( ItemFrame ) , Lighting.GetColor( Player.position.X.ToInt( ) / 16 , Player.position.Y.ToInt( ) / 16 ) , Rotation , ItemFrameSize / 2 , 1f , Direction , 1f );
            }
        }

        public override void DrawEffects( PlayerDrawSet drawInfo , ref float r , ref float g , ref float b , ref float a , ref bool fullBright )
        {
            drawInfo.backHairDraw = true;
            DrawSword( );
            DrawBow( );
            DrawMagicStaff( );
            base.DrawEffects( drawInfo , ref r , ref g , ref b , ref a , ref fullBright );
        }

        public static void IndividualWeapons( Player Player , Item Item )
        {
            if ( Item.type == ModContent.ItemType<RedRiot>( ) )
                Rotation -= Player.direction == 1 ? (float) Math.PI / 180 * -15 : (float) Math.PI / 180 * 15;
        }
    }
}