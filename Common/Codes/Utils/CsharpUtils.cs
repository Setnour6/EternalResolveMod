using Microsoft.Xna.Framework;
using System;

namespace EternalResolve.Common.Codes.Utils
{
    public static class CsharpUtils
    {
        public static string[ ] CharacterTable = new string[ ]
        {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "N",
            "M",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            };

        /// <summary>
        /// 将单精度浮点数强制转换为整数.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt( this float value )
        {
            return (int) value;
        }

        public static float ToRad( this int value )
        {
            return (float) Math.PI / 180 * value;
        }


        /// <summary>
        /// 将整数强制转换为单精度浮点数.
        /// </summary>
        /// <param name="value">值.</param>
        /// <returns></returns>
        public static float ToFloat( this int value )
        {
            return (float) value;
        }


        /// <summary>
        /// 将双精度浮点数强制转换为单精度浮点数.
        /// </summary>
        /// <param name="value">值.</param>
        /// <returns></returns>
        public static float ToFloat( this double value )
        {
            return (float) value;
        }

        /// <summary>
        /// 将弧度转化为向量.
        /// </summary>
        /// <param name="rad"></param>
        /// <returns></returns>
        public static Vector2 ToVector( this float rad )
        {
            return new Vector2( Math.Cos( rad ).ToFloat( ) , Math.Sin( rad ).ToFloat( ) );
        }
    }
}
