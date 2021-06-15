using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Geometry
{

    public static float[] SquareXY(int scale)
    {
        float[] floatArray = new float[]
        {
                0.5f,0,0.5f,
                0.5f,0,-0.5f,
                -0.5f,0,-0.5f,
                -0.5f,0,0.5f,
        };
        for (int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = floatArray[i] * scale;
        }
        return floatArray;
    }

    public static float[] SquareXZ(int scale)
    {
        float[] floatArray = new float[]
        {
                0.5f,0.5f,0,
                0.5f,-0.5f,0,
                -0.5f,-0.5f,0,
                -0.5f,0.5f,0
        };
        for (int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = floatArray[i] * scale;
        }
        return floatArray;
    }

    public static float[] SquareColor()
    {
        float[] floatArray = new float[]
        {
                1.0f,0.0f,0.0f,
                1.0f,1.0f,0.0f,
                1.0f,0.0f,1.0f,
                0.0f,0.5f,0.5f
        };
        return floatArray;
    }
    public static float[] SquareRandomColor(int numOfSquare)
    {
        float[] floatArray = new float[numOfSquare * 12];
        Random random = new Random();
        for (int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = random.Next(0, 255);
            floatArray[i] = floatArray[i] / 255;
        }
        return floatArray;
    }

    public static float[] SquareIDColor2(int numOfSquare)//for 12 vertices, unnessesary for instancing square.
    {
        float[] floatArray = new float[numOfSquare * 12];
        int counterX = 1;//because 0,0,0 is background color!
        int counterY = 0;
        int counterZ = 255;
        for(int i = 0; i < numOfSquare * 12; i+= 12)
        {
            floatArray[i] = counterX;
            floatArray[i+ 1] = counterY;
            floatArray[i+ 2] = counterZ;

            floatArray[i + 3] = counterX;
            floatArray[i + 4] = counterY;
            floatArray[i + 5] = counterZ;

            floatArray[i + 6] = counterX;
            floatArray[i + 7] = counterY;
            floatArray[i + 8] = counterZ;

            floatArray[i + 9] = counterX;
            floatArray[i + 10] = counterY;
            floatArray[i + 11] = counterZ;

            if (counterX < 255)
            {
                counterX+=3;
            }
            else
            {
                counterX = 0;
                if (counterY < 255)
                {
                    counterY++;
                }
                else
                {
                    counterY = 0;
                    if (counterZ < 255)
                    {
                        counterZ++;
                    }
                    else
                    {
                        Console.WriteLine("error, number of items exceeded the limit");
                    }
                }
            }
        }

        for(int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = floatArray[i] / 255;
        }
        return floatArray;
    }

    public static float[] SquareIDColor(int numOfSquare)
    {
        float[] floatArray = new float[numOfSquare * 3];
        int counterX = 1;//because 0,0,0 is background color!
        int counterY = 0;
        int counterZ = 0;
        int step = 1;
        for (int i = 0; i < numOfSquare * 3; i += 3)
        {
            floatArray[i] = counterX;
            floatArray[i + 1] = counterY;
            floatArray[i + 2] = counterZ;

            if (counterX < 255)
            {
                counterX += step;
            }
            else
            {
                counterX = 0;
                if (counterY < 255)
                {
                    counterY += step;
                }
                else
                {
                    counterY = 0;
                    if (counterZ < 255)
                    {
                        counterZ += step;
                    }
                    else
                    {
                        Console.WriteLine("error, number of items exceeded the limit");
                    }
                }
            }
        }

        for (int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = floatArray[i] / 255;
        }
        return floatArray;
    }



    public static float[] Arrow(int scale)//14 vertices
    {
        float[] floatArray = new float[]
        {

                0.5f,0,0.5f,
                -0.5f,0,-0.5f,
                -0.5f,0,0.5f,

                0.5f,0,0.5f,
                0.5f,0,-0.5f,
                -0.5f,0,-0.5f,

                0f,1,0f,
                -0.5f,0,0.5f,
                0f,1,0f,

                0.5f,0,0.5f,
                0f,1f,0f,
                0.5f,0,-0.5f,

                0f,1,0f,
                -0.5f,0,-0.5f
        };

        for (int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = floatArray[i] * scale;
        }
        return floatArray;
    }

    public static float[] Cube(int scale)//14 vertices
    {
        float[] floatArray = new float[]
        {

                0.5f,0,0.5f,
                -0.5f,0,-0.5f,
                -0.5f,0,0.5f,

                0.5f,0,0.5f,
                0.5f,0,-0.5f,
                -0.5f,0,-0.5f,

                0f,1,0f,
                -0.5f,0,0.5f,
                0f,1,0f,

                0.5f,0,0.5f,
                0f,1f,0f,
                0.5f,0,-0.5f,

                0f,1,0f,
                -0.5f,0,-0.5f
        };

        for (int i = 0; i < floatArray.Length; i++)
        {
            floatArray[i] = floatArray[i] * scale;
        }
        return floatArray;
    }

}

