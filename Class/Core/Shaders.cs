using System;
using OpenTK.Graphics.OpenGL;
using System.IO;

public class Shaders //by making shader class, increasing readability
{

    public int programID;
    public int vertexShaderID;
    public int fragmentShaderID;


    public Shaders()
    {
        programID = GL.CreateProgram();
    }

    public void LoadShadersFromString(string vertexShaderString, string fragmentShaderString)
    {
        int vertexShaderAddress = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderAddress, vertexShaderString);
        GL.CompileShader(vertexShaderAddress);
        GL.AttachShader(programID, vertexShaderAddress);
        Console.WriteLine(GL.GetShaderInfoLog(vertexShaderAddress));
        //Console.WriteLine(vertexShaderString);
        int fragmentShaderAddress = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShaderAddress, fragmentShaderString);
        GL.CompileShader(fragmentShaderAddress);
        GL.AttachShader(programID, fragmentShaderAddress);
        Console.WriteLine(GL.GetShaderInfoLog(fragmentShaderAddress));
        //Console.WriteLine(fragmentShaderString);
        GL.LinkProgram(programID);
        Console.WriteLine(GL.GetProgramInfoLog(programID));

        Print();
    }


    public void LoadShadersFromFiles(string vertexShaderPath, string fragmentShaderPath)
    {

        programID = GL.CreateProgram();
        loadShader(vertexShaderPath, ShaderType.VertexShader, programID, out vertexShaderID);
        loadShader(fragmentShaderPath, ShaderType.FragmentShader, programID, out fragmentShaderID);
        GL.LinkProgram(programID);
        Console.WriteLine(GL.GetProgramInfoLog(programID));

        Print();
    }

    private void loadShader(String filename, ShaderType type, int program, out int address)
    {
        address = GL.CreateShader(type);
        using (StreamReader sr = new StreamReader(filename))
        {
            Console.WriteLine(sr.ReadToEnd());
            GL.ShaderSource(address, sr.ReadToEnd());
            Console.WriteLine(sr.ReadToEnd());
        }
        GL.CompileShader(address);
        GL.AttachShader(program, address);
        Console.WriteLine(GL.GetShaderInfoLog(address));
    }

    public void Print()
    {
        string txt = "Shader Information Program ID:" + programID + " Vertex Shader ID:" + vertexShaderID + " Fragment Shader ID:" + fragmentShaderID;
        Console.WriteLine(txt);
    }

}
