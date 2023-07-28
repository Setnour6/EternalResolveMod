using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items
{
    public abstract class ERPowerProjectile : ERProjectile
	{
		public Vector2[ ] PositionSave = new Vector2[ 21 ];

		public Vector2[ ] HyperOldPositon = new Vector2[ 31 ];

		public int[ ] timer = new int[ 5 ];

		public bool[ ] switches = new bool[ 5 ];
	}
}