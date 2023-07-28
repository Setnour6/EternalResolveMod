using EternalResolve.Common.Contents.Modulars;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace EternalResolve.Common.Contents.Entities.Tiles.RefiningWorkbenchs
{
    public class RefiningWorkbench_Tile : ModTile
    {
        public override void SetStaticDefaults( )
        {
            DustType = 21;
            MinPick = 45;
            Main.tileSolidTop[ Type ] = true;
            Main.tileFrameImportant[ Type ] = true;
            Main.tileNoAttach[ Type ] = true;
            Main.tileTable[ Type ] = true;
            Main.tileLavaDeath[ Type ] = true;
            TileID.Sets.CanBeSleptIn[ Type ] = true;
            TileID.Sets.HasOutlines[ Type ] = true;
            TileID.Sets.DisableSmartCursor[ Type ] = false;
            TileObjectData.newTile.CopyFrom( TileObjectData.Style3x3 );
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[ ]
            {
                16,
                16,
                18
            };
            TileObjectData.newTile.Origin = new Point16( 2 , 2 );
            Main.tileLighted[ Type ] = true;
            AddToArray( ref TileID.Sets.RoomNeeds.CountsAsTable );
            ModTranslation name = CreateMapEntryName( null );
            name.AddTranslation( EternalResolve.Chinese , "武器精炼工作台" );
            name.AddTranslation( EternalResolve.English , "Weapon Refining Workbench" );
            AddMapEntry( new Color( 200 , 200 , 200 ) , name );
            TileObjectData.addTile( Type );
        }

        public override void NumDust( int i , int j , bool fail , ref int num )
        {
            num = ( fail ? 1 : 3 );
        }

        public override void KillMultiTile( int i , int j , int frameX , int frameY )
        {
            Item.NewItem(null, i * 16 , j * 16 , 32 , 16 , ModContent.ItemType<RefiningWorkbench>( ) , 1 , false , 0 , false , false );
        }

        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings) => true;

        public override bool RightClick( int i , int j )
        {
            Modular.RefineSystemInteracting = !Modular.RefineSystemInteracting;
            return Vector2.Distance( Main.LocalPlayer.Center , new Vector2( i , j ) * 16 ) < 50;
        }

        public override void MouseOver( int i , int j )
        {
            Player player = Main.LocalPlayer;
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<RefiningWorkbench>( );
        }

        public override void MouseOverFar( int i , int j )
        {
            MouseOver( i , j );
        }

        public override void ModifyLight( int i , int j , ref float r , ref float g , ref float b )
        {
            r = 0.75f;
            g = 0.65f;
            b = 0.75f;
        }

    }
}
