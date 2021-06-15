using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class MathHelper
{
    public static double angleToRadian(double angle)
    {
        return (Math.PI / 180) * angle;
    }
    public static double sinAngle(double angle)
    {
        return Math.Sin((Math.PI / 180) * angle);
    }
    public static double cosAngle(double angle)
    {
        return Math.Cos((Math.PI / 180) * angle);
    }

    public static float angleToRadian(float angle)
    {
        return (float)(Math.PI / 180) * angle;
    }
    public static float sinAngle(float angle)
    {
        return (float)Math.Sin((Math.PI / 180) * angle);
    }
    public static float cosAngle(float angle)
    {
        return (float)Math.Cos((Math.PI / 180) * angle);
    }

    public static double Interpolate(double value, double firstInput, double secondInput, double firstOutput, double secondOutput)
    {
        string text = "";
        double percentage = (value - firstInput) / (secondInput - firstInput);
        text += percentage * 100 + "%" + "\r\n";


        //Console.WriteLine(percentage* 100 + "%" );
        double range = secondOutput - firstOutput;
        double difference = range * percentage;
        double result = firstOutput + range * percentage;
        //Console.WriteLine(firstOutput + "+" + difference + "=" + result);
        text += firstOutput + "+" + range + "*" + percentage + "=" + result + "\r\n";
        //Console.Write(text);
        return result;
    }

    public static double Round2dec(double number)
    {
        return Math.Round(number * 100) / 100;
    }

    public static double Round3dec(double number)
    {
        return Math.Round(number * 1000) / 1000;
    }

    public static double RoundDec(double number, int decimalPlace)
    {
        return Math.Round(number * Math.Pow(10, decimalPlace)) / Math.Pow(10, decimalPlace);
    }
}

