using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace CivilApp
{
    class AreaObject
    {
        VBO areaVBO;
        Shaders areaShader;
        public int vertexIndex;

        public AreaObject()
        {
            int vertexIndex = 9;
            areaVBO = new VBO();
            PortalFrame portalFrame = new PortalFrame(8, 5, 20, 5, 4);
            areaVBO.LoadBuffer(vertexIndex, portalFrame.CreateAreaFloatArray());

            areaShader = new Shaders();
            //areaShader.LoadShadersFromString(LineShader.LoadAreaVertexShader(), LineShader.LoadAreaFragmentShader());
            areaShader.LoadShadersFromString(ShaderFiles.BasicVertexShader(vertexIndex), ShaderFiles.BasicFragmentShader(1.0f, 0.0f, 0.0f, 0.5f));

        }

        public void Draw(Matrix4 bufferMVP)
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            GL.UseProgram(areaShader.programID);

            int locationMVP = GL.GetUniformLocation(areaShader.programID, "MVP");
            GL.UniformMatrix4(locationMVP, false, ref bufferMVP);

            GL.EnableVertexAttribArray(areaVBO.vertexIndex);
            GL.DrawArrays(PrimitiveType.Polygon, 0, 100);
            GL.DisableVertexAttribArray(areaVBO.vertexIndex);


            GL.Disable(EnableCap.Blend);
            //How to use alpha https://stackoverflow.com/questions/28079159/opengl-glsl-texture-transparency
        }
    }
}
