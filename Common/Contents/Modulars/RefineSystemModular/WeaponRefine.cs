using EternalResolve.Common.Codes.Utils;
using EternalResolve.Common.Contents.Modulars.EternalResolveToolTipModular;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars.RefineSystemModular
{
    public class WeaponRefine : GlobalItem
    {
        public bool CanLevelUp = false;

        public int Level = 1;

        public int LevelMax = 1;

        public int Exp = 0;

        public int ExpMax = 500;

        public int MatExp = 0;

        public TextLine LevelText;

        public override bool InstancePerEntity => true;

        public override void SetDefaults( Item item )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                item.GetGlobalItem<WeaponRefine>( ).LevelText = new TextLine( "" , Color.White );
                if ( item.IsWeapon( ) )
                {
                    item.GetGlobalItem<WeaponRefine>( ).CanLevelUp = true;
                    item.GetGlobalItem<WeaponRefine>( ).LevelMax = 10;
                    item.GetGlobalItem<WeaponRefine>( ).MatExp = 50 + item.rare * 500;
                }
                if( item.defense > 0 && !item.accessory )
                {
                    item.GetGlobalItem<WeaponRefine>( ).CanLevelUp = true;
                    item.GetGlobalItem<WeaponRefine>( ).LevelMax = 10;
                    item.GetGlobalItem<WeaponRefine>( ).MatExp = 50 + item.rare * 500;
                }
            }
            base.SetDefaults( item );
        }

        public override void ModifyWeaponDamage( Item item , Player player , ref StatModifier damage , ref float flat )
        {
            flat += item.damage * item.GetGlobalItem<WeaponRefine>( ).Level * item.GetGlobalItem<WeaponRefine>( ).Level / 200f;
            base.ModifyWeaponDamage( item , player , ref damage , ref flat );
        }

        public override void UpdateEquip( Item item , Player player )
        {
            player.statDefense += item.GetGlobalItem<WeaponRefine>( ).Level * 2;
            base.UpdateEquip( item , player );
        }

        public override GlobalItem Clone( Item item , Item itemClone )
        {
            return base.Clone( item , itemClone );
        }

        public override void LoadData( Item item , TagCompound tag )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                Level = tag.GetInt( "Level" );
                Exp = tag.GetInt( "Exp" );
                MatExp = tag.GetInt( "MatExp" );
                base.LoadData( item , tag );
            }
        }

        public override void SaveData( Item item , TagCompound tag )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                tag.Add( "Level" , Level );
                tag.Add( "Exp" , Exp );
                tag.Add( "MatExp" , MatExp );
                base.SaveData( item , tag );
            }
        }

        public override void Update( Item item , ref float gravity , ref float maxFallSpeed )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                if ( item.GetGlobalItem<WeaponRefine>( ).Exp > item.GetGlobalItem<WeaponRefine>( ).ExpMax )
                {
                    if ( item.GetGlobalItem<WeaponRefine>( ).Level < item.GetGlobalItem<WeaponRefine>( ).LevelMax )
                    {
                        item.GetGlobalItem<WeaponRefine>( ).Level += 1;
                        item.GetGlobalItem<WeaponRefine>( ).Exp -= item.GetGlobalItem<WeaponRefine>( ).ExpMax;
                    }
                    else if ( item.GetGlobalItem<WeaponRefine>( ).Level == item.GetGlobalItem<WeaponRefine>( ).LevelMax )
                    {
                        item.GetGlobalItem<WeaponRefine>( ).Exp = item.GetGlobalItem<WeaponRefine>( ).ExpMax;
                    }
                }
            }
            base.Update( item , ref gravity , ref maxFallSpeed );
        }

        public override void UpdateInventory( Item item , Player player )
        {
            if ( Main.netMode != NetmodeID.Server )
            {
                item.GetGlobalItem<WeaponRefine>( ).ExpMax = item.GetGlobalItem<WeaponRefine>( ).Level * 500 * item.rare;
                if ( item != null && item.type != ItemID.None )
                {
                    if ( item.GetGlobalItem<WeaponRefine>( ).Exp > item.GetGlobalItem<WeaponRefine>( ).ExpMax )
                    {
                        if ( item.GetGlobalItem<WeaponRefine>( ).Level < item.GetGlobalItem<WeaponRefine>( ).LevelMax )
                        {
                            item.GetGlobalItem<WeaponRefine>( ).Level += 1;
                            item.GetGlobalItem<WeaponRefine>( ).Exp -= item.GetGlobalItem<WeaponRefine>( ).ExpMax;
                        }
                        else if ( item.GetGlobalItem<WeaponRefine>( ).Level == item.GetGlobalItem<WeaponRefine>( ).LevelMax )
                        {
                            item.GetGlobalItem<WeaponRefine>( ).Exp = item.GetGlobalItem<WeaponRefine>( ).ExpMax;
                        }
                    }
                    base.UpdateInventory( item , player );
                }
            }
        }
    }
}