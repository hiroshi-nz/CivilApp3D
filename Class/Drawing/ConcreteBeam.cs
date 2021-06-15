using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace CivilDrawing.Class
{
    class ConcreteBeam
    {
        public List<List<XY>> drawingList;

        private List<XY> beam;
        private List<XY> stirrupInside;
        private List<XY> stirrupOutside;
        private List<List<XY>> rebarList;

        public double height;
        public double width;
        public double cover;
        double stirrupDiameter = 10;
        double rebarDiameter = 25;
        double bendDiameter = 30;

        public int elementID = 10000;

        public XY location;
        // public int groupID;

        public List<Item> viewList1;


        public ConcreteBeam(double height, double width, double cover, XY location)
        {
            this.height = height;
            this.width = width;
            this.cover = cover;

            Stirrup stirrup = new Stirrup(height - cover * 2, width - cover * 2, bendDiameter, 24);
            stirrupOutside = DrawingHelper.Move(stirrup.xyList, cover, cover);
            stirrup = new Stirrup(height - (cover + stirrupDiameter) * 2, width - (cover + stirrupDiameter) * 2, bendDiameter - stirrupDiameter * 2, 24);
            stirrupInside = DrawingHelper.Move(stirrup.xyList, cover + stirrupDiameter, cover + stirrupDiameter);

            Beam();
            Rebar();

            SetLocation(location);
            CreateList();

        }

        public void SetLocation(XY location)
        {
            this.location = location;

            beam = DrawingHelper.Move(beam, location);
            stirrupInside = DrawingHelper.Move(stirrupInside, location);
            stirrupOutside = DrawingHelper.Move(stirrupOutside, location);

            List<List<XY>> newRebarList = new List<List<XY>>();

            foreach (List<XY> xyList in rebarList)
            {
                newRebarList.Add(DrawingHelper.Move(xyList, location));
            }

            rebarList = newRebarList;
        }

        private void Rebar()
        {
            rebarList = new List<List<XY>>();

            double rebarOffset = cover + stirrupDiameter + rebarDiameter / 2;
            Circle rebar = new Circle(rebarDiameter, 24);
            rebarList.Add(DrawingHelper.Move(rebar.xyList, rebarOffset, rebarOffset));
            rebarList.Add(DrawingHelper.Move(rebar.xyList, width - rebarOffset, rebarOffset));
            rebarList.Add(DrawingHelper.Move(rebar.xyList, width - rebarOffset, height - rebarOffset));
            rebarList.Add(DrawingHelper.Move(rebar.xyList, rebarOffset, height - rebarOffset));
        }

        private void Beam()
        {
            beam = new List<XY>();

            XY xy = new XY(0, 0);
            beam.Add(xy);

            xy = new XY(width, 0);
            beam.Add(xy);

            xy = new XY(width, height);
            beam.Add(xy);

            xy = new XY(0, height);
            beam.Add(xy);

            xy = new XY(0, 0);
            beam.Add(xy);
        }

        private void CreateDrawingList()
        {
            drawingList = new List<List<XY>>();

            drawingList.Add(beam);
            drawingList.Add(stirrupInside);
            drawingList.Add(stirrupOutside);

            foreach (List<XY> xyList in rebarList)
            {
                drawingList.Add(xyList);
            }
        }

        public float[] CreateFloatArray()
        {
            //At first, counting the number of float required.
            int totalCount = 0;
            int rebarCount = 0;

            totalCount = beam.Count + stirrupInside.Count + stirrupOutside.Count;

            foreach (List<XY> xyList in rebarList)
            {
                rebarCount += xyList.Count;
            }

            totalCount += rebarCount;
            int floatCount = totalCount * 3;

            Console.WriteLine("Total Count:" + totalCount + " Float Count:" + floatCount);

            //Now actually start to create floatArray
            float[] floatArray = new float[floatCount];

            int offsetCount = 0;
            floatArray = CombineXYListToArray(floatArray, offsetCount, beam);
            offsetCount += beam.Count * 3;

            Console.WriteLine("Offset Count:" + offsetCount);

            floatArray = CombineXYListToArray(floatArray, offsetCount, stirrupInside);
            offsetCount += stirrupInside.Count * 3;
            Console.WriteLine("Offset Count:" + offsetCount);

            floatArray = CombineXYListToArray(floatArray, offsetCount, stirrupOutside);
            offsetCount += stirrupOutside.Count * 3;
            Console.WriteLine("Offset Count:" + offsetCount);


            foreach (List<XY> xyList in rebarList)
            {
                floatArray = CombineXYListToArray(floatArray, offsetCount, xyList);
                offsetCount += xyList.Count * 3;
                Console.WriteLine("Offset Count:" + offsetCount);
            }

            Console.WriteLine("Offset Count:" + offsetCount + " Float Count:" + floatCount);

            floatArray = ScaleFloatArray(floatArray, 0.1f);

            return floatArray;
        }

        private float[] CombineXYListToArray(float[] floatArray, int offset, List<XY> xyList)
        {
            float z = 0.0f;

            for (int i = 0; i < xyList.Count; i++)
            {
                floatArray[offset + i * 3] = Convert.ToSingle(xyList[i].x);
                floatArray[offset + i * 3 + 1] = Convert.ToSingle(xyList[i].y);
                floatArray[offset + i * 3 + 2] = z;
            }

            return floatArray;
        }

        private float[] ScaleFloatArray(float[] floatArray, float scale)
        {
            for(int i = 0; i < floatArray.Length; i++)
            {
                floatArray[i] = floatArray[i] * scale;
            }

            return floatArray;
        }



        public void AddDrawings(Drawings drawings, Color color)
        {
            drawings.Add(elementID, beam, color);
            drawings.Add(elementID, stirrupOutside, color);
            drawings.Add(elementID, stirrupInside, color);

            foreach (List<XY> xyList in rebarList)
            {
                drawings.Add(elementID, xyList, color);
            }

        }

        public void CreateList()
        {
            viewList1 = new List<Item>();
            Item title1 = new Item("Concrete Beam", 0, "", "TITLE");

            viewList1.Add(title1);
            viewList1.Add(new Item("Element ID", elementID, "", ""));
            viewList1.Add(new Item("Height", height, "mm", ""));
            viewList1.Add(new Item("Width", width, "mm", ""));
            viewList1.Add(new Item("Cover", cover, "mm", ""));
        }
    }
}
