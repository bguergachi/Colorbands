//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Drawing.Drawing2D;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Game
//{
//    public class ColorBandTheme
//    {
//        //Max sky color constants
//        private static readonly int[] MAX_RGB_SKY_COLOR_CONST = { 255, 229, 91 };
//        //Min sky color constants
//        private static readonly int[] MIN_RGB_SKY_COLOR_CONST = { 221, 71, 71 };
//        //Max ground color constants
//        private static readonly int[] MAX_RGB_GROUND_COLOR_CONST = { 197, 245, 194 };
//        //Min ground color constants
//        private static readonly int[] MIN_RGB_GROUND_COLOR_CONST = { 59, 95, 65 };
//        //Increment used to find colors
//        private double increment = 0;
//        //X value used to return color value
//        private static double xValue = 0;

       

//        /// <summary>
//        /// The following functions are used to return a value to create a specific gradient
//        /// based on designated functions for each RGB value
//        /// </summary>
//        /// <param name="index">The value of gradient index</param>
//        /// <param name="chose">Chose if ground color,'g', or sky color,'s'</param>
//        /// <returns>The R value</returns>
//        public static double RedFunction(int RValue, char chose)
//        {


//            if (chose == 's')
//            {
                

//                return
//            }
//            else if (chose == 'g')
//            {
//                returnValue = ((43.4 + 21.5) - 1);
//                if (returnValue < TOP_GROUND_COLOR_CONST[0])
//                {
//                    returnValue /= TOP_GROUND_COLOR_CONST[0];
//                }
//                else
//                {
//                    returnValue = 1;
//                }
//            }
//            return returnValue;
//        }

//        public static double findXValueForR()
//        {

//        }
//        /// <summary>
//        /// The following functions to return a value to create a specific gradient
//        /// based on designated functions for each RGB value
//        /// </summary>
//        /// <param name="index">The value of gradient index</param>
//        /// <param name="chose">Chose if ground color,'g', or sky color,'s',</param>
//        /// <returns>The R value</returns>
//        public static double GreenFunction(int GValue, char chose)
//        {
//            double returnValue = 0;

//            if (chose == 's')
//            {
//                returnValue = ((1.414 * Math.Pow(-0.01118 - 3.548, 6) - 2809) - 1);
//                if (returnValue < TOP_SKY_COLOR_CONST[1])
//                {
//                    returnValue /= TOP_SKY_COLOR_CONST[1];
//                }
//                else
//                {
//                    returnValue = 1;
//                }
//            }
//            else if (chose == 'g')
//            {
//                returnValue = ((-1.023 * Math.Pow(-0.5101 + 4.109, 4) + 265.7) - 1);
//                if (returnValue < TOP_GROUND_COLOR_CONST[1])
//                {
//                    returnValue /= TOP_GROUND_COLOR_CONST[1];
//                }
//                else
//                {
//                    returnValue = 1;
//                }
//            }
//            return returnValue;
//        }
//        public static double findXValueForR()
//        {

//        }

//        /// <summary>
//        /// The following functions to return a value to create a specific gradient
//        /// based on designated functions for each RGB value
//        /// </summary>
//        /// <param name="index">The value of gradient index</param>
//        /// <param name="chose">Chose if ground color,'g', or sky color,'s',</param>
//        /// <returns>The R value</returns>
//        public static double BlueFunction(int BValue, char chose)
//        {
//            double returnValue = 0;

//            if (chose == 's')
//            {

//            }
//            else if (chose == 'g')
//            {
//                returnValue = ((46.4 * (index) + 11.5) - 1);
//                if (returnValue > TOP_GROUND_COLOR_CONST[2])
//                {
//                    returnValue /= TOP_GROUND_COLOR_CONST[2];
//                }
//                else
//                {
//                    returnValue = 1;
//                }
//            }
//            return returnValue;
//        }

//        public static double findXValueForR()
//        {

//        }
//    }
//}
