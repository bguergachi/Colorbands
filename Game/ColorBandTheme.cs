using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class ColorBandTheme
    {
        //Top sky color constant
        private static readonly int TOP_SKY_COLOR_CONST = 255;
        //Top ground color constant
        private static readonly int TOP_GROUND_COLOR_CONST = 65;


        /// <summary>
        /// The following functions are used to return a value to create a specific gradient
        /// based on designated functions for each RGB value
        /// </summary>
        /// <param name="index">The value of gradient index</param>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s'</param>
        /// <returns>The R value</returns>
        public static double RedValue(int index, char chose)
        {
            if (chose == 's')
            {
                return (62.8 * Math.Pow(index / TOP_SKY_COLOR_CONST, 1 / 3) + 158.9) ;
            }
            else if (chose == 'g')
            {
                return (43.4 * (index / TOP_GROUND_COLOR_CONST) + 21.5);
            }
            return 0;
        }
        /// <summary>
        /// The following functions to return a value to create a specific gradient
        /// based on designated functions for each RGB value
        /// </summary>
        /// <param name="index">The value of gradient index</param>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s',</param>
        /// <returns>The R value</returns>
        public static double GreenValue(int index, char chose)
        {
            if (chose == 's')
            {
                return (1.414 * Math.Pow(-0.01118 * (index / TOP_SKY_COLOR_CONST) - 3.548, 6) - 2809) ;
            }
            else if (chose == 'g')
            {
                return (-1.023 * Math.Pow(-0.5101 * (index / TOP_GROUND_COLOR_CONST) + 4.109, 4) + 265.7) ;
            }
            return 0;
        }
        /// <summary>
        /// The following functions to return a value to create a specific gradient
        /// based on designated functions for each RGB value
        /// </summary>
        /// <param name="index">The value of gradient index</param>
        /// <param name="chose">Chose if ground color,'g', or sky color,'s',</param>
        /// <returns>The R value</returns>
        public static double BlueValue(int index, char chose)
        {
            if (chose == 's')
            {
                return (0.3583 * Math.Pow(1.306 * (index / TOP_SKY_COLOR_CONST) - 5.073, 3) + 90.01) ;
            }
            else if (chose == 'g')
            {
                return (46.4 * (index/ TOP_GROUND_COLOR_CONST) + 11.5) ;
            }
            return 0;
        }
    }
}
