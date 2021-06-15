using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp
{
    class Arrays
    {
        public static float[] GetLocationArray()
        {
            float[] locationArray = {
            10,0,0,
            0,10,0,
            0,0,10,

            50,0,0,
            0,50,0,
            0,0,50,

            100,0,0,
            0,100,0,
            0,0,100

            };

            return locationArray;
        }


        public static float[] GetLineArray()
        {
            float[] lineArray = {
            0,0,0,
            100,0,0,

            0,0,0,
            0,100,0,

            0,0,0,
            0,0,100,

            0,0,0,
            0,0,0
            };

            return lineArray;
        }

        public static float[] GetPortalFrameArray()
        {
            float apexHeight = 8;
            float eavesHeight = 3;
            float width = 8;
            

            float[] lineArray = {
            0, 0, 0,
            0, eavesHeight, 0,

            0, eavesHeight, 0,
            width / 2, apexHeight, 0,

            width / 2, apexHeight, 0,
            width, eavesHeight, 0,

            width, 0, 0,
            width, eavesHeight, 0
            };

            return lineArray;
        }


        public static float[] GetColorArray()
        {
            float[] colorArray = {
            50,0,0,
            0,50,0,
            0,0,50,

            100,0,0,
            0,100,0,
            0,0,100,

            150,0,0,
            0,150,0,
            0,0,150,
            };

            return colorArray;
        }


    }
}
