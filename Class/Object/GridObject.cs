using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace CivilApp
{

    class GridObject
    {
        public VBO gridVBO;
        public Shaders gridShader;
        public int vertexIndex;

        public GridObject()
        {

            gridVBO = new VBO();
            gridShader = new Shaders();
            vertexIndex = 3;

            float[] gridArray = Grid.DrawGrid(11, 10);
            gridVBO.LoadBuffer(vertexIndex, gridArray);
            gridShader.LoadShadersFromString(ShaderFiles.BasicVertexShader(vertexIndex), ShaderFiles.BasicFragmentShader(0.9f, 0.9f, 0.9f, 0.0f));
        }

        public void Draw()
        {
            GL.UseProgram(gridShader.programID);
            GL.EnableVertexAttribArray(gridVBO.vertexIndex);
            for (int i = 0; i < 11 * 6; i++)
            {
                GL.DrawArrays(PrimitiveType.LineStrip, 11 * i, 11);
            }
            GL.DisableVertexAttribArray(gridVBO.vertexIndex);
        }

    }

}