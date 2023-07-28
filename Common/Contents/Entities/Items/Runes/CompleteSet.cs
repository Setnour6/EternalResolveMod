using Terraria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EternalResolve.Common.Contents.Entities.Items.Runes
{
    public class CompleteSet
    {
        public virtual bool Check( )
        {
            return false;
        }
        public virtual string Text()
        {
            return "";
        }
        public virtual void UpdateInventory( Player player )
        {

        }
    }
}
