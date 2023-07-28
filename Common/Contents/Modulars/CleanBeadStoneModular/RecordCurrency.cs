using EternalResolve.Common.CodeStage.AntiCheat.ObscuredTypes;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace EternalResolve.Common.Contents.Modulars.CleanBeadStoneModular
{
    public class RecordCurrency : ModPlayer
    {
        public override bool CloneNewInstances => true;

        public ObscuredInt CleanBeadStone = 0;

        public ObscuredInt MinimumGuarantee = 0;

        int _cacheCleanBeadStone = 0;

        int _cacheMinimumGuarantee = 0;

        public override void SaveData( TagCompound tag )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                _cacheCleanBeadStone = CleanBeadStone;
                _cacheMinimumGuarantee = MinimumGuarantee;
                tag.Add( "RecordCurrency:CleanBeadStone" , _cacheCleanBeadStone );
                tag.Add( "RecordCurrency:MinimumGuarantee" , _cacheMinimumGuarantee );
            }
        }
        public override void LoadData( TagCompound tag )
        {
            if ( Terraria.Main.netMode != Terraria.ID.NetmodeID.Server )
            {
                _cacheCleanBeadStone = tag.GetInt( "RecordCurrency:CleanBeadStone" );
                _cacheMinimumGuarantee = tag.GetInt( "RecordCurrency:MinimumGuarantee" );
                CleanBeadStone = _cacheCleanBeadStone;
                MinimumGuarantee = _cacheMinimumGuarantee;
            }
            base.LoadData( tag );
        }
    }
}