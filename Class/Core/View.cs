using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

class View
{
    // angle of rotation for the camera direction
    float horizontalAngle;
    float verticalAngle;
    float angleX;
    float angleY;
    float angleZ;

    float targetX;
    float targetY;
    float targetZ;

    // XYZ position of the camera
    float cameraPositionX;
    float cameraPositionY;
    float cameraPositionZ;
    float zoom = 91;
    
    float xOffset = 15;
    float yOffset = 25;
    float zOffset = 0;

    float speedOfMovement = 10;
    float increment = 5;

    Point mouseStartingLocation;
    Point mouseNewLocation;
    int mouseSensitivity = 2;

    public View()
    {
        // angle of rotation for the camera direction
        horizontalAngle = 0.0f;
        verticalAngle = 0.0f;
        angleX = 0.0f;
        angleY = 5.0f;
        angleZ = 0.0f;
        // XZ position of the camera
        cameraPositionX = 0;
        cameraPositionY = 0.2f;
        cameraPositionZ = 100;

        speedOfMovement = 1;

        mouseStartingLocation = new Point(0, 0);
        mouseNewLocation = new Point(0, 0);

        
        

        Console.WriteLine(angleX);
        Console.WriteLine(angleY);
        Console.WriteLine(angleZ);
    }


    public void Print()
    {
        string positionTxt = "cameraPosition x:" + cameraPositionX + " y:" + cameraPositionY + " z:" + cameraPositionZ;
        string targetTxt = " target x:" + targetX + " target y:" + targetY + " target Z:" + targetZ;
        string angleTxt = " angle x:" + angleX + " angle y:" + angleY + " angle Z:" + angleZ;

        Console.WriteLine(positionTxt);
        Console.WriteLine(targetTxt);
        Console.WriteLine(angleTxt);
    }

    public void PrintOrtho()
    {
        string positionTxt = "offset x:" + xOffset + " offset y:" + yOffset + " offset z:" + zOffset;
        string zoomTxt = "zoom:" + zoom;
        //string targetTxt = " target x:" + targetX + " target y:" + targetY + " target Z:" + targetZ;
        //string angleTxt = " angle x:" + angleX + " angle y:" + angleY + " angle Z:" + angleZ;

        Console.WriteLine(positionTxt);
        Console.WriteLine(zoomTxt);
        //Console.WriteLine(angleTxt);
    }

    public void LookLeft()
    {
        horizontalAngle -= increment;

        angleX = MathHelper.sinAngle(horizontalAngle);
        angleY = -MathHelper.cosAngle(horizontalAngle);
        Print();
    }

    public void LookRight()
    {
        horizontalAngle += increment;
        angleX = MathHelper.sinAngle(horizontalAngle);
        angleY = -MathHelper.cosAngle(horizontalAngle);
        Print();
    }

    public void MoveForward()
    {
        //cameraPositionX += 10;
        //cameraPositionY += targetY * speedOfMovement;
        cameraPositionZ -= speedOfMovement;

        //cameraPositionX += targetX * speedOfMovement;
        //cameraPositionY += targetY * speedOfMovement;
        //cameraPositionZ += targetZ * speedOfMovement;
    }

    public void MoveBackward()
    {
        cameraPositionZ += speedOfMovement;
    }

    public void MoveUp()
    {
        cameraPositionY += speedOfMovement;
    }

    public void MoveDown()
    {
        cameraPositionY -= speedOfMovement;
    }

    public void MoveRight()
    {
        cameraPositionX += 1;
        angleX += 1;
        angleX = MathHelper.sinAngle(horizontalAngle);
        angleY = -MathHelper.cosAngle(horizontalAngle);
    }

    public void MoveLeft()
    {
        cameraPositionX -= 1;
        angleX -= 1;
        angleX = MathHelper.sinAngle(horizontalAngle);
        angleY = -MathHelper.cosAngle(horizontalAngle);

    }

    public void LookUp()
    {
        verticalAngle--;
        angleZ = -MathHelper.sinAngle(verticalAngle);
    }

    public void LookDown()
    {
        verticalAngle++;
        angleZ = -MathHelper.sinAngle(verticalAngle);
    }

    public void ZoomIn()
    {
        zoom -= 10;
        Console.WriteLine(zoom);

    }

    public void ZoomOut()
    {
        zoom += 10;
        Console.WriteLine(zoom);

    }

    public void ChangeOffsetX(float number)
    {
        xOffset += number;
    }

    public void ChangeOffsetY(float number)
    {
        yOffset += number;
    }

    public void ChangeOffsetZ(float number)
    {
        zOffset += number;
    }


    public void MouseDown(Point mouseLocation)
    {
        this.mouseStartingLocation.X = mouseLocation.X;
        this.mouseStartingLocation.Y = mouseLocation.Y;
    }


    public void MouseMove(Point mouseLocation)
    {
        mouseNewLocation.X = mouseLocation.X;
        mouseNewLocation.Y = mouseLocation.Y;

        horizontalAngle += (mouseNewLocation.X - mouseStartingLocation.X) * 1 / mouseSensitivity;
        verticalAngle += (mouseNewLocation.Y - mouseStartingLocation.Y) * 1 / mouseSensitivity;

        angleX = MathHelper.sinAngle(horizontalAngle);
        angleY = -MathHelper.cosAngle(horizontalAngle);
        angleZ = -MathHelper.sinAngle(verticalAngle);

        mouseStartingLocation.X = mouseNewLocation.X;
        mouseStartingLocation.Y = mouseNewLocation.Y;
    }





    public Matrix4 CreateP(int width, int height)
    {
        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.angleToRadian(45), width / height, 0.1f, 1000.0f);
        return projection;
    }

    public Matrix4 CreateMV()
    {
        Matrix4 view = Matrix4.LookAt(new Vector3(cameraPositionX, cameraPositionY, cameraPositionZ),
                                new Vector3(cameraPositionX + angleX, cameraPositionY + angleY , cameraPositionZ + angleZ),
                                new Vector3(0, 1, 0));

        return view;
    }
   

    public Matrix4 CreateMVP(int width, int height)
    {

        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.angleToRadian(45), width / height, 0.1f, 1000.0f);

        targetX = cameraPositionX + angleX;
        //targetY = (cameraPositionX + angleZ) - 0.1f + lookdown * 0.1f + angleZ;
        targetY = cameraPositionX + angleZ;
        targetZ = cameraPositionZ + angleY;

        Matrix4 lookat = Matrix4.LookAt(new Vector3(cameraPositionX, cameraPositionY, cameraPositionZ),
                                new Vector3(targetX, targetY, targetZ),
                                new Vector3(0, 1, 0));



        Matrix4 MVP = Matrix4.Mult(lookat, projection);
        return MVP;
    }


    public Matrix4 CreateOrthoMVP(int width, int height, float zoom)
    {

        float ratio = Convert.ToSingle(height) / Convert.ToSingle(width);

        Console.WriteLine(ratio);

        Matrix4 projection = Matrix4.CreateOrthographic(100.0f, ratio * 100.0f, 0.1f, 10000.0f);    

        Matrix4 view = Matrix4.LookAt(new Vector3(cameraPositionX, cameraPositionY, cameraPositionZ),
                        new Vector3(cameraPositionX + angleX, cameraPositionY + angleY, cameraPositionZ + angleZ),
                        new Vector3(0, 1, 0));

        Matrix4 lookat = Matrix4.LookAt(new Vector3(cameraPositionX, cameraPositionY, cameraPositionZ),
                        new Vector3(targetX, targetY, targetZ),
                        new Vector3(0, 1, 0));

        Matrix4 MVP = Matrix4.Mult(lookat, projection);
        return MVP;
    }


    public Matrix4 OrthoXYPlane(int width, int height)
    {
        float ratio = Convert.ToSingle(height) / Convert.ToSingle(width);

        Matrix4 projection = Matrix4.CreateOrthographic(zoom, ratio * zoom, 0.1f, 10000.0f);


        Matrix4 view = Matrix4.LookAt(new Vector3(xOffset, yOffset, 1),
                        new Vector3(xOffset, yOffset, - 1),
                        new Vector3(0, 1, 0));

        Matrix4 MVP = Matrix4.Mult(view, projection);
        return MVP;
    }


    public Matrix4 OrthoXZPlane(int width, int height)
    {
        float ratio = Convert.ToSingle(height) / Convert.ToSingle(width);

        Matrix4 projection = Matrix4.CreateOrthographic(zoom, ratio * zoom, 0.1f, 10000.0f);

        Matrix4 view = Matrix4.LookAt(new Vector3(xOffset, 1, zOffset),
                        new Vector3(xOffset, -1, zOffset),
                        new Vector3(0, 0, 1));

        Matrix4 MVP = Matrix4.Mult(view, projection);
        return MVP;
    }
}

