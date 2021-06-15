using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Grid
{
    public static float[] DrawGrid(int lineNumber, float scale)
    {
        float[] bottom = GridBottom(lineNumber, scale);
        float[] behind = GridBehind(lineNumber, scale);
        float[] bottomBehind = AddFloatArrays(bottom, behind);
        float[] side = GridSide(lineNumber, scale);
        float[] bottomBehindSide = AddFloatArrays(bottomBehind, side);
        return bottomBehindSide;
    }

    public static float[] AddFloatArrays(float[] firstArray, float[] secondArray)
    {
        float[] floatArrayBuffer = new float[firstArray.Length + secondArray.Length];
        for (int i = 0; i < firstArray.Length; i++)
        {
            floatArrayBuffer[i] = firstArray[i];
        }
        for (int i = 0; i < secondArray.Length; i++)
        {
            floatArrayBuffer[firstArray.Length + i] = secondArray[i];
        }
        return floatArrayBuffer;
    }

    public static float[] GridBottom(int lineNumber, float scale)
    {
        float[] floatArray = new float[lineNumber * lineNumber * 3 * 2];
        int counterX = 0;
        int counterY = 0;
        for (int i = 0; i < lineNumber * lineNumber * 3; i += 3)
        {
            floatArray[i] = counterX * scale;
            floatArray[i + 1] = 0;
            floatArray[i + 2] = counterY * scale;

            if (counterX < lineNumber - 1)
            {
                counterX++;
            }
            else
            {
                counterX = 0;
                counterY++;
            }
        }
        counterX = 0;
        counterY = 0;
        for (int i = lineNumber * lineNumber * 3; i < lineNumber * lineNumber * 3 * 2; i += 3)
        {
            floatArray[i] = counterX * scale;
            floatArray[i + 1] = 0;
            floatArray[i + 2] = counterY * scale;
            if (counterY < lineNumber - 1)
            {
                counterY++;
            }
            else
            {
                counterY = 0;
                counterX++;
            }
        }
        return floatArray;
    }

    public static float[] GridBehind(int lineNumber, float scale)
    {
        float[] floatArray = new float[lineNumber * lineNumber * 3 * 2];
        float offset =0;
        int counterX = 0;
        int counterY = 0;
        for (int i = 0; i < lineNumber * lineNumber * 3; i += 3)
        {
            floatArray[i] = counterX * scale;
            floatArray[i + 1] = counterY * scale;
            floatArray[i + 2] = offset;

            if (counterX < lineNumber - 1)
            {
                counterX++;
            }
            else
            {
                counterX = 0;
                counterY++;
            }
        }
        counterX = 0;
        counterY = 0;
        for (int i = lineNumber * lineNumber * 3; i < lineNumber * lineNumber * 3 * 2; i += 3)
        {
            floatArray[i] = counterX * scale;
            floatArray[i + 1] = counterY * scale;
            floatArray[i + 2] = offset;
            if (counterY < lineNumber - 1)
            {
                counterY++;
            }
            else
            {
                counterY = 0;
                counterX++;
            }
        }
        return floatArray;
    }

    public static float[] GridSide(int lineNumber, float scale)
    {
        float[] floatArray = new float[lineNumber * lineNumber * 3 * 2];
        float offset = 0;
        int counterX = 0;
        int counterY = 0;
        for (int i = 0; i < lineNumber * lineNumber * 3; i += 3)
        {
            floatArray[i] = offset;
            floatArray[i + 1] = counterY * scale;
            floatArray[i + 2] = counterX * scale;

            if (counterX < lineNumber - 1)
            {
                counterX++;
            }
            else
            {
                counterX = 0;
                counterY++;
            }
        }
        counterX = 0;
        counterY = 0;
        for (int i = lineNumber * lineNumber * 3; i < lineNumber * lineNumber * 3 * 2; i += 3)
        {
            floatArray[i] = offset;
            floatArray[i + 1] = counterY * scale;
            floatArray[i + 2] = counterX * scale;
            if (counterY < lineNumber - 1)
            {
                counterY++;
            }
            else
            {
                counterY = 0;
                counterX++;
            }
        }
        return floatArray;
    }
}
