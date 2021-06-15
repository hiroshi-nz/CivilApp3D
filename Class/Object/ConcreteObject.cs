using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;
using CivilDrawing.Class;

namespace CivilApp
{
    class ConcreteObject
    {
        VBO VBO;
        Shaders shader;
        public int vertexIndex;
        ConcreteBeam concreteBeam;

        public ConcreteObject()
        {
            VBO = new VBO();

            vertexIndex = 10;

            concreteBeam = new ConcreteBeam(500, 300, 40, new XY(0, 0));

            VBO.LoadBuffer(vertexIndex, concreteBeam.CreateFloatArray());

            shader = new Shaders();
            shader.LoadShadersFromString(ShaderFiles.BasicVertexShader(vertexIndex), ShaderFiles.BasicFragmentShader(0.0f, 0.0f, 0.0f, 0.0f));
        }

        public void Draw(Matrix4 bufferMVP)
        {
            GL.UseProgram(shader.programID);
            int locationMVP = GL.GetUniformLocation(shader.programID, "MVP");
            GL.UniformMatrix4(locationMVP, false, ref bufferMVP);

            GL.EnableVertexAttribArray(VBO.vertexIndex);
            GL.DrawArrays(PrimitiveType.LineLoop, 0, 4);
            GL.DrawArrays(PrimitiveType.LineLoop, 5, 28);
            GL.DrawArrays(PrimitiveType.LineLoop, 34, 28);
            GL.DrawArrays(PrimitiveType.LineLoop, 63, 24);
            GL.DrawArrays(PrimitiveType.LineLoop, 88, 24);
            GL.DrawArrays(PrimitiveType.LineLoop, 113, 24);
            GL.DrawArrays(PrimitiveType.LineLoop, 138, 24);
            GL.DisableVertexAttribArray(VBO.vertexIndex);
        }
    }
}
