using System;
using System.Collections.Generic;
using EternalResolve.Common.Codes.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace EternalResolve.Common.Contents.Entities.Items.Stabbings.Contents.TheDestructionOfMeteoriteThunder
{
	public class TDMT_Pro_TH : ERPowerProjectile
	{
		public override void SetStaticDefaults( )
		{
			DisplayName.SetDefault( "电流" );
		}
		public override void SetDefaults( )
		{
			Projectile.width = 40;
			Projectile.height = 40;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.friendly = true;
			Projectile.timeLeft = 16;
			Projectile.tileCollide = false;
			Projectile.alpha = 255;
			Projectile.ignoreWater = true;
			Projectile.aiStyle = -1;
			Projectile.scale = 1f;
			Projectile.penetrate = 2000;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
		}

		public override bool ShouldUpdatePosition( )
		{
			return false;
		}

		public override void AI( )
		{
			this.PositionSave[ 0 ] = new Vector2( Projectile.ai[ 0 ] , Projectile.ai[ 1 ] );
			foreach ( NPC target in Main.npc )
			{
				if ( !target.dontTakeDamage && ( !target.friendly || target.type == 488 ) && Projectile.timeLeft == 16 && target.active && Vector2.Distance( target.position , Projectile.position ) < this.distance && !this.hitednpc.Contains( target ) && this.counter < 9 && ( Main.rand.Next( 1 , 3 ) == 1 || this.counter == 0 ) )
				{
					this.hitednpc.Add( target );
					this.PositionSave[ this.counter ] = target.Center;
					this.counter++;
					this.distance = 400f;
				}
			}
			if ( Projectile.timeLeft == 16 )
			{
				NPCdistanceComparer com = new NPCdistanceComparer( Projectile );
				this.hitednpc.Sort( com );
				for ( int i = 0; i < 100; i++ )
				{
					this.Pool[ i ] = Main.rand.Next( -101 , 101 );
				}
			}
			if ( this.PositionSave[ this.status + 1 ] != Vector2.Zero )
			{
				Projectile.Center = XnaUtils.GetCloser( this.PositionSave[ this.status ] , this.PositionSave[ this.status + 1 ] , (float) this.fix , 4f );
				this.status++;
				this.fix++;
				if ( this.fix == 5 )
				{
					this.fix = 0;
				}
			}
			else
			{
				this.status = 0;
			}
			if ( this.status == this.counter )
			{
				this.status = 0;
			}
		}

		public override bool PreDraw( ref Color lightColor )
		{
			Vector2 drawOrigin = Vector2.One;
			Vector2 ts = this.PositionSave[ 0 ];
			for ( int z = 0; z < 8; z++ )
			{
				Vector2 current = this.PositionSave[ z ];
				if ( current != Vector2.Zero && !( this.PositionSave[ z + 1 ] == Vector2.Zero ) )
				{
					Vector2 target = this.PositionSave[ z + 1 ];
					Color color = Color.White;
					int i = 0;
					while ( (float) i < Vector2.Distance( current , target ) / 40f )
					{
						Vector2 targetPos = XnaUtils.GetCloser( current , target , (float) i , Vector2.Distance( current , target ) / 40f );
						targetPos.X += (float) ( this.Pool[ i + 1 ] / 3 );
						targetPos.Y += (float) ( this.Pool[ i + 21 ] / 8 );
						Vector2 currentPos = XnaUtils.GetCloser( current , target , (float) ( i - 1 ) , Vector2.Distance( current , target ) / 40f );
						currentPos.X += (float) ( this.Pool[ i ] / 3 );
						currentPos.Y += (float) ( this.Pool[ i + 20 ] / 8 );
						if ( i == 0 )
						{
							currentPos = ts;
						}
						for ( int j = 0; j < 30; j++ )
						{
							float x = Projectile.velocity.X;
							if ( !0.01f.Equals( x ) )
							{
								if ( !0.02f.Equals( x ) )
								{
									if ( !0.03f.Equals( x ) )
									{
										if ( !0.04f.Equals( x ) )
										{
											if ( !0.05f.Equals( x ) )
											{
												if ( 0.06f.Equals( x ) )
												{
													color = new Color( 255 , 255 , 150 );
												}
											}
											else
											{
												color = new Color( 217 , 217 , 217 );
											}
										}
										else
										{
											color = new Color( 255 , 150 , 150 );
										}
									}
									else
									{
										color = new Color( 255 , 150 , 255 );
									}
								}
								else
								{
									color = new Color( 150 , 255 , 150 );
								}
							}
							else
							{
								color = new Color( 150 , 255 , 255 );
							}
							color *= (float) Projectile.timeLeft / 16f;
							Main.spriteBatch.Draw( TextureAssets.Projectile[ Type ].Value , XnaUtils.GetCloser( currentPos , targetPos , (float) j , 30f ) - Main.screenPosition , default( Rectangle? ) , Color.Multiply( color , 1f ) , Projectile.rotation , drawOrigin , 0.08f , 0 , 0f );
							Lighting.AddLight( XnaUtils.GetCloser( current , target , (float) j , 20f ) , (float) ( color.R / 245 ) , (float) ( color.G / 245 ) , (float) ( color.B / 245 ) );
							Lighting.AddLight( XnaUtils.GetCloser( current , target , (float) j , 20f ) , 0.55f , 0.55f , 0.55f );
							ts = targetPos;
						}
						i++;
					}
				}
			}
			return true;
		}

		private int fix;

		private List<NPC> hitednpc = new List<NPC>( );

		private NPC npc;

		private int counter = 1;

		private int status;

		private float distance = 800f;

		private int[ ] Pool = new int[ 100 ];
	}
}