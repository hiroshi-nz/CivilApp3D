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
    class FrameObject
    {
        VBO frameVBO;
        Shaders frameShader;
        public int vertexIndex;

        public FrameObject()
        {
            frameVBO = new VBO();
            vertexIndex = 8;

            PortalFrame portalFrame = new PortalFrame(8, 5, 20, 5, 4);
            frameVBO.LoadBuffer(vertexIndex, portalFrame.CreateFloatArray());

            frameShader = new Shaders();
            //frameShader.LoadShadersFromString(LineShader.LoadFrameVertexShader(), LineShader.LoadFrameFragmentShader());
            frameShader.LoadShadersFromString(ShaderFiles.BasicVertexShader(vertexIndex), ShaderFiles.BasicFragmentShader(0.0f, 0.0f, 1.0f, 0.0f));
        }

        public void Draw(Matrix4 bufferMVP)
        {
            GL.UseProgram(frameShader.programID);
            int locationMVP = GL.GetUniformLocation(frameShader.programID, "MVP");
            GL.UniformMatrix4(locationMVP, false, ref bufferMVP);


            GL.EnableVertexAttribArray(frameVBO.vertexIndex);
            GL.DrawArrays(PrimitiveType.Lines, 0, 100);
            GL.DisableVertexAttribArray(frameVBO.vertexIndex);
        }
    }
}
