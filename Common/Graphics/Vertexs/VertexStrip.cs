using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;

namespace EternalResolve.Common.Graphics.Vertexs
{
    public class VertexStrip
    {
        public void PrepareStrip( Vector2[ ] positions , float[ ] rotations , VertexStrip.StripColorFunction colorFunction , VertexStrip.StripHalfWidthFunction widthFunction , Vector2 offsetForAllPositions = default( Vector2 ) , int? expectedVertexPairsAmount = null , bool includeBacksides = false )
        {
            int num = positions.Length;
            int num2 = this._vertexAmountCurrentlyMaintained = num * 2;
            if ( this._vertices.Length < num2 )
            {
                Array.Resize<VertexStrip.CustomVertexInfo>( ref this._vertices , num2 );
            }
            int num3 = num;
            if ( expectedVertexPairsAmount != null )
            {
                num3 = expectedVertexPairsAmount.Value;
            }
            for ( int i = 0; i < num; i++ )
            {
                if ( positions[ i ] == Vector2.Zero )
                {
                    num = i - 1;
                    this._vertexAmountCurrentlyMaintained = num * 2;
                    break;
                }
                Vector2 pos = positions[ i ] + offsetForAllPositions;
                float rot = MathHelper.WrapAngle( rotations[ i ] );
                int indexOnVertexArray = i * 2;
                float progressOnStrip = (float) i / (float) ( num3 - 1 );
                this.AddVertex( colorFunction , widthFunction , pos , rot , indexOnVertexArray , progressOnStrip );
            }
            this.PrepareIndices( num , includeBacksides );
        }

        public void PrepareStripWithProceduralPadding( Vector2[ ] positions , float[ ] rotations , VertexStrip.StripColorFunction colorFunction , VertexStrip.StripHalfWidthFunction widthFunction , Vector2 offsetForAllPositions = default( Vector2 ) , bool includeBacksides = false )
        {
            int num = positions.Length;
            this._temporaryPositionsCache.Clear( );
            this._temporaryRotationsCache.Clear( );
            int i = 0;
            while ( i < num && ( positions[ i ] != Vector2.Zero ) )
            {
                Vector2 vector = positions[ i ];
                float num2 = MathHelper.WrapAngle( rotations[ i ] );
                this._temporaryPositionsCache.Add( vector );
                this._temporaryRotationsCache.Add( num2 );
                if ( i + 1 < num && positions[ i + 1 ] != Vector2.Zero )
                {
                    Vector2 vector2 = positions[ i + 1 ];
                    float num3 = MathHelper.WrapAngle( rotations[ i + 1 ] );
                    int num4 = (int) ( Math.Abs( MathHelper.WrapAngle( num3 - num2 ) ) / 0.2617994f );
                    if ( num4 != 0 )
                    {
                        float num5 = vector.DistanceSQ( vector2 );
                        Vector2 value = vector + Utils.ToRotationVector2( num2 ) * num5;
                        Vector2 value2 = vector2 + Utils.ToRotationVector2( num3 ) * ( 100f - num5 );
                        int num6 = num4 + 2;
                        float num7 = 1f / (float) num6;
                        Vector2 target = vector;
                        for ( float num8 = num7; num8 < 1f; num8 += num7 )
                        {
                            Vector2 vector3 = Vector2.CatmullRom( value , vector , vector2 , value2 , num8 );
                            float item = MathHelper.WrapAngle( Utils.ToRotation( vector3.DirectionTo( target ) ) );
                            this._temporaryPositionsCache.Add( vector3 );
                            this._temporaryRotationsCache.Add( item );
                            target = vector3;
                        }
                    }
                }
                i++;
            }
            int count = this._temporaryPositionsCache.Count;
            for ( int j = 0; j < count; j++ )
            {
                Vector2 pos = this._temporaryPositionsCache[ j ] + offsetForAllPositions;
                float rot = this._temporaryRotationsCache[ j ];
                int indexOnVertexArray = j * 2;
                float progressOnStrip = (float) j / (float) ( count - 1 );
                this.AddVertex( colorFunction , widthFunction , pos , rot , indexOnVertexArray , progressOnStrip );
            }
            this._vertexAmountCurrentlyMaintained = count * 2;
            this.PrepareIndices( count , includeBacksides );
        }

        private void PrepareIndices( int vertexPaidsAdded , bool includeBacksides )
        {
            int num = vertexPaidsAdded - 1;
            int num2 = 6 + includeBacksides.ToInt( ) * 6;
            int num3 = this._indicesAmountCurrentlyMaintained = num * num2;
            if ( this._indices.Length < num3 )
            {
                Array.Resize<short>( ref this._indices , num3 );
            }
            short num4 = 0;
            while ( (int) num4 < num )
            {
                short num5 = (short) ( (int) num4 * num2 );
                int num6 = (int) ( num4 * 2 );
                this._indices[ (int) num5 ] = (short) num6;
                this._indices[ (int) ( num5 + 1 ) ] = (short) ( num6 + 1 );
                this._indices[ (int) ( num5 + 2 ) ] = (short) ( num6 + 2 );
                this._indices[ (int) ( num5 + 3 ) ] = (short) ( num6 + 2 );
                this._indices[ (int) ( num5 + 4 ) ] = (short) ( num6 + 1 );
                this._indices[ (int) ( num5 + 5 ) ] = (short) ( num6 + 3 );
                if ( includeBacksides )
                {
                    this._indices[ (int) ( num5 + 6 ) ] = (short) ( num6 + 2 );
                    this._indices[ (int) ( num5 + 7 ) ] = (short) ( num6 + 1 );
                    this._indices[ (int) ( num5 + 8 ) ] = (short) num6;
                    this._indices[ (int) ( num5 + 9 ) ] = (short) ( num6 + 2 );
                    this._indices[ (int) ( num5 + 10 ) ] = (short) ( num6 + 3 );
                    this._indices[ (int) ( num5 + 11 ) ] = (short) ( num6 + 1 );
                }
                num4 += 1;
            }
        }

        private void AddVertex( VertexStrip.StripColorFunction colorFunction , VertexStrip.StripHalfWidthFunction widthFunction , Vector2 pos , float rot , int indexOnVertexArray , float progressOnStrip )
        {
            while ( indexOnVertexArray + 1 >= this._vertices.Length )
            {
                Array.Resize( ref this._vertices , this._vertices.Length * 2 );
            }
            Color color = colorFunction( progressOnStrip );
            float num = widthFunction( progressOnStrip );
            Vector2 value = Utils.ToRotationVector2( MathHelper.WrapAngle( rot - 1.5f ) ) * num;
            this._vertices[ indexOnVertexArray ].Position = pos + value;
            this._vertices[ indexOnVertexArray + 1 ].Position = pos - value;
            this._vertices[ indexOnVertexArray ].TexCoord = new Vector3( progressOnStrip , num , num );
            this._vertices[ indexOnVertexArray + 1 ].TexCoord = new Vector3( progressOnStrip , 0f , num );
            this._vertices[ indexOnVertexArray ].Color = color;
            this._vertices[ indexOnVertexArray + 1 ].Color = color;
        }

        public void DrawTrail( )
        {
            if ( this._vertexAmountCurrentlyMaintained >= 3 )
            {
                Main.instance.GraphicsDevice.DrawUserIndexedPrimitives<VertexStrip.CustomVertexInfo>( PrimitiveType.TriangleList , this._vertices , 0 , this._vertexAmountCurrentlyMaintained , this._indices , 0 , this._indicesAmountCurrentlyMaintained / 3 );
            }
        }
        private VertexStrip.CustomVertexInfo[ ] _vertices = new VertexStrip.CustomVertexInfo[ 1 ];

        // Token: 0x0400013D RID: 317
        private int _vertexAmountCurrentlyMaintained;

        // Token: 0x0400013E RID: 318
        private short[ ] _indices = new short[ 1 ];

        // Token: 0x0400013F RID: 319
        private int _indicesAmountCurrentlyMaintained;

        // Token: 0x04000140 RID: 320
        private List<Vector2> _temporaryPositionsCache = new List<Vector2>( );

        // Token: 0x04000141 RID: 321
        private List<float> _temporaryRotationsCache = new List<float>( );

        // Token: 0x02000153 RID: 339
        // (Invoke) Token: 0x06000736 RID: 1846
        public delegate Color StripColorFunction( float progressOnStrip );

        // Token: 0x02000154 RID: 340
        // (Invoke) Token: 0x0600073A RID: 1850
        public delegate float StripHalfWidthFunction( float progressOnStrip );

        // Token: 0x02000155 RID: 341
        private struct CustomVertexInfo : IVertexType
        {
            // Token: 0x17000087 RID: 135
            // (get) Token: 0x0600073D RID: 1853 RVA: 0x00023D1C File Offset: 0x00021F1C
            public VertexDeclaration VertexDeclaration
            {
                get
                {
                    return VertexStrip.CustomVertexInfo._vertexDeclaration;
                }
            }

            // Token: 0x0600073E RID: 1854 RVA: 0x00023D23 File Offset: 0x00021F23
            public CustomVertexInfo( Vector2 position , Color color , Vector3 texCoord )
            {
                this.Position = position;
                this.Color = color;
                this.TexCoord = texCoord;
            }

            // Token: 0x04000142 RID: 322
            public Vector2 Position;

            // Token: 0x04000143 RID: 323
            public Color Color;

            // Token: 0x04000144 RID: 324
            public Vector3 TexCoord;

            // Token: 0x04000145 RID: 325
            private static VertexDeclaration _vertexDeclaration = new VertexDeclaration( new VertexElement[ ]
            {
                new VertexElement(0, VertexElementFormat.Vector2, VertexElementUsage.Position, 0),
                new VertexElement(8, VertexElementFormat.Color, VertexElementUsage.Color, 0),
                new VertexElement(12, VertexElementFormat.Vector3, VertexElementUsage.TextureCoordinate, 0)
            } );
        }
    }
}
