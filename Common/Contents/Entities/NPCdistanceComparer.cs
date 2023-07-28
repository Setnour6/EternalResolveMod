using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;

namespace EternalResolve.Common.Contents.Entities
{
    public class NPCdistanceComparer : IComparer<NPC>
    {
		public NPCdistanceComparer( Entity entity )
		{
			this.e = entity;
		}
		public int Compare( NPC x , NPC y )
		{
			int result;
			try
			{
				if ( Vector2.Distance( x.Center , this.e.Center ) > Vector2.Distance( y.Center , this.e.Center ) )
				{
					result = -1;
				}
				else if ( Vector2.Distance( x.Center , this.e.Center ) < Vector2.Distance( y.Center , this.e.Center ) )
				{
					result = 1;
				}
				else
				{
					result = 0;
				}
			}
			catch
			{
				result = 0;
			}
			return result;
		}
		private Entity e;
	}
}
