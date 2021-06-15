using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp
{
    class PortalFrame
    {
        List<Frame> frameList;

        Frame leftColumn;
        Frame leftRafter;
        Frame rightRafter;
        Frame rightColumn;

        public PortalFrame(double apexHeight, double eavesHeight, double frameSpan, double frameSpacing, int numberOfBays)
        {
            this.leftColumn = new Frame(0, 0, 0, 0, eavesHeight, 0);
            this.leftRafter = new Frame(0, eavesHeight, 0, frameSpan / 2, apexHeight, 0);
            this.rightRafter = new Frame(frameSpan / 2, apexHeight, 0, frameSpan, eavesHeight, 0);
            this.rightColumn = new Frame(frameSpan, eavesHeight, 0, frameSpan, 0, 0);

            frameList = new List<Frame>();

            for (int i = 0; i < numberOfBays; i++)
            {
                double offsetZ = frameSpacing * i;

                Frame leftColumn = new Frame(0, 0, offsetZ, 0, eavesHeight, offsetZ);
                Frame leftRafter = new Frame(0, eavesHeight, offsetZ, frameSpan / 2, apexHeight, offsetZ);
                Frame rightRafter = new Frame(frameSpan / 2, apexHeight, offsetZ, frameSpan, eavesHeight, offsetZ);
                Frame rightColumn = new Frame(frameSpan, eavesHeight, offsetZ, frameSpan, 0, offsetZ);

                frameList.Add(leftColumn);
                frameList.Add(leftRafter);
                frameList.Add(rightRafter);
                frameList.Add(rightColumn); 
            }
       }


        public float[] CreateFloatArray()
        {
            float[] floatArray = new float[frameList.Count * 6];

            for(int i = 0; i < frameList.Count; i++)
            {
                floatArray[i * 6] = Convert.ToSingle(frameList[i].start.x);
                floatArray[i * 6 + 1] = Convert.ToSingle(frameList[i].start.y);
                floatArray[i * 6 + 2] = Convert.ToSingle(frameList[i].start.z);
                floatArray[i * 6 + 3] = Convert.ToSingle(frameList[i].end.x);
                floatArray[i * 6 + 4] = Convert.ToSingle(frameList[i].end.y);
                floatArray[i * 6 + 5] = Convert.ToSingle(frameList[i].end.z);
            }

            return floatArray;
        }

        public float[] CreateAreaFloatArray()
        {
            List<Frame> frameList = new List<Frame>();

            frameList.Add(leftColumn);
            frameList.Add(leftRafter);
            frameList.Add(rightRafter);
            frameList.Add(rightColumn);

            float[] floatArray = new float[frameList.Count * 6];
            for (int i = 0; i < frameList.Count; i++)
            {
                floatArray[i * 6] = Convert.ToSingle(frameList[i].start.x);
                floatArray[i * 6 + 1] = Convert.ToSingle(frameList[i].start.y);
                floatArray[i * 6 + 2] = Convert.ToSingle(frameList[i].start.z);
                floatArray[i * 6 + 3] = Convert.ToSingle(frameList[i].end.x);
                floatArray[i * 6 + 4] = Convert.ToSingle(frameList[i].end.y);
                floatArray[i * 6 + 5] = Convert.ToSingle(frameList[i].end.z);
            }

            return floatArray;
        }


    }
}
