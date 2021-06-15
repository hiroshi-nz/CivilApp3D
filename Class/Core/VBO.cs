using System;
using OpenTK.Graphics.OpenGL;


public class VBO
{
    public int vertexVBO { get; set; }
    public int textureVBO { get; set; }
    public int colorVBO { get; set; }
    public int vertexIndex { get; set; }
    public int textureIndex { get; set; }
    public int colorIndex { get; set; }


    //from float array
    public void LoadBuffer(int vertexIndex, float[] vertexArray)
    {

        int vertexVBO;
        this.vertexIndex = vertexIndex;
        this.colorIndex = vertexIndex;//just in case I used colorIndex instead of vertexIndex by a mistake.

        GL.GenBuffers(1, out vertexVBO);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexVBO);
        GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertexArray.Length * sizeof(float)), vertexArray, BufferUsageHint.StaticDraw);
        GL.VertexAttribPointer(vertexIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

        this.vertexVBO = vertexVBO;
        this.colorVBO = vertexVBO;
    }


    public void LoadBufferColor(int vertexIndex, int colorIndex, float[] vertexArray, float[] colorArray)
    {

        int vertexVBO;
        int colorVBO;
        this.vertexIndex = vertexIndex;
        this.colorIndex = colorIndex;

        GL.GenBuffers(1, out vertexVBO);
        GL.BindBuffer(BufferTarget.ArrayBuffer, vertexVBO);
        GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertexArray.Length * sizeof(float)), vertexArray, BufferUsageHint.StaticDraw);
        GL.VertexAttribPointer(vertexIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

        GL.GenBuffers(1, out colorVBO);
        GL.BindBuffer(BufferTarget.ArrayBuffer, colorVBO);
        GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(colorArray.Length * sizeof(float)), colorArray, BufferUsageHint.StaticDraw);
        GL.VertexAttribPointer(colorIndex, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

        this.vertexVBO = vertexVBO;
        this.colorVBO = colorVBO;
    }

}
