using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using System.Drawing;


namespace CivilApp
{
    class Graphics3D
    {
        GLControl glControl;

        FrameObject frameObject;
        AreaObject areaObject;
        GridObject gridObject;

        ConcreteObject concreteObject;


        public View view;

        float graphRotation = 0f;
        //Vector3 offsetValues = new Vector3(0, 0, 0);

        public Graphics3D(GLControl glControl)
        {
            this.glControl = glControl;

            InitializeObjects();

            view = new View();

            GL.ClearColor(Color.White);

        }

        private void InitializeObjects()
        {
            frameObject = new FrameObject();
            areaObject = new AreaObject();
            gridObject = new GridObject();
            concreteObject = new ConcreteObject();


        }

        public void Render(int view)
        {
            switch(view)
            {
                case 1:
                    OrthXY();
                    break;

                case 2:
                    View3D1();
                    break;

                case 3:
                    View3D2();
                    break;

                case 4:
                    View3D3();
                    break;

            }



        }
        public void OrthXY()
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.DepthFunc(DepthFunction.Less);


            //Matrix4 bufferMVP = view.CreateMVP(glControl.Width, glControl.Height);
            //Matrix4 bufferMVP = view.CreateOrthoMVP(glControl.Width, glControl.Height, 100);
            Matrix4 bufferMVP = view.OrthoXYPlane(glControl.Width, glControl.Height);
            GL.UseProgram(gridObject.gridShader.programID);

            int locationMVP = GL.GetUniformLocation(gridObject.gridShader.programID, "MVP");
            GL.UniformMatrix4(locationMVP, false, ref bufferMVP);

            concreteObject.Draw(bufferMVP);
            gridObject.Draw();
            


            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.Flush();
            glControl.SwapBuffers();
        }

        public void View3D1()
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.DepthFunc(DepthFunction.Less);


            Matrix4 bufferMVP = view.CreateMVP(glControl.Width, glControl.Height);
            GL.UseProgram(gridObject.gridShader.programID);

            int locationMVP = GL.GetUniformLocation(gridObject.gridShader.programID, "MVP");
            GL.UniformMatrix4(locationMVP, false, ref bufferMVP);

            int rotationLocation = GL.GetUniformLocation(gridObject.gridShader.programID, "graphRotation");
            GL.Uniform1(rotationLocation, Convert.ToSingle(MathHelper.angleToRadian(graphRotation)));
            
            gridObject.Draw();
            frameObject.Draw(bufferMVP);
            areaObject.Draw(bufferMVP);


            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.Flush();
            glControl.SwapBuffers();


        }


        public void View3D2()
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.DepthFunc(DepthFunction.Less);


            Matrix4 bufferMVP = view.CreateMVP(glControl.Width, glControl.Height);
            GL.UseProgram(gridObject.gridShader.programID);

            int locationMVP = GL.GetUniformLocation(gridObject.gridShader.programID, "MVP");
            GL.UniformMatrix4(locationMVP, false, ref bufferMVP);

            int rotationLocation = GL.GetUniformLocation(gridObject.gridShader.programID, "graphRotation");
            GL.Uniform1(rotationLocation, Convert.ToSingle(MathHelper.angleToRadian(graphRotation)));

            gridObject.Draw();
            frameObject.Draw(bufferMVP);
            areaObject.Draw(bufferMVP);


            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.Flush();
            glControl.SwapBuffers();
        }


        public void View3D3()
        {

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthMask(true);
            GL.DepthFunc(DepthFunction.Less);


            Matrix4 bufferMVP = view.CreateMVP(glControl.Width, glControl.Height);
            GL.UseProgram(gridObject.gridShader.programID);

            int locationMVP = GL.GetUniformLocation(gridObject.gridShader.programID, "MVP");
            GL.UniformMatrix4(locationMVP, false, ref bufferMVP);

            int rotationLocation = GL.GetUniformLocation(gridObject.gridShader.programID, "graphRotation");
            GL.Uniform1(rotationLocation, Convert.ToSingle(MathHelper.angleToRadian(graphRotation)));

            gridObject.Draw();
            frameObject.Draw(bufferMVP);
            areaObject.Draw(bufferMVP);


            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            //GL.Flush();
            glControl.SwapBuffers();
        }

    }
}

