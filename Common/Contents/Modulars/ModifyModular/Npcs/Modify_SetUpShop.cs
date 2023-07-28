using EternalResolve.Common.Contents.Entities.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Modulars.ModifyModular.Npcs
{
    public class Modify_SetUpShop : GlobalNPC
    {
        public override void SetupShop( int type , Chest shop , ref int nextSlot )
        {
            if ( type == NPCID.ArmsDealer )
            {
                shop.item[ nextSlot ].SetDefaults( ModContent.ItemType<LegalFirearmsParts>( ) , false );
                nextSlot++;
            }
            base.SetupShop( type , shop , ref nextSlot );
        }
    }
}