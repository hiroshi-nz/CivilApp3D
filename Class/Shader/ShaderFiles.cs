using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CivilApp
{
    class ShaderFiles
    {
        public static string LoadTriangleStripVertexShader()
        {
            string shader = @"#version 410 compatibility
layout(location = 10) in vec3 vertexPosition;

void main(){
    gl_Position =  gl_ModelViewProjectionMatrix * vec4(vertexPosition, 1);

}";

            return shader;
        }



        public static string LoadTriangleStripFragmentShader()
        {
            string shader = @"#version 410 compatibility
out vec4 color;
void main()
{
    color = vec4(0, 100, 0, 0.1);
}";

            return shader;
        }


        public static string GridVertexShader()
        {
            string shader = @"#version 410 compatibility
layout(location = 3) in vec3 vertexPosition;

uniform float graphRotation;
uniform mat4 MVP;

vec3 rotationZ(float angle, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = cos(angle) * oldXYZ.x - sin(angle) * oldXYZ.y;
newXYZ.y = sin(angle) * oldXYZ.x + cos(angle) * oldXYZ.y;
newXYZ.z = oldXYZ.z;

return newXYZ;
}

vec3 rotationY(float angle, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = cos(angle) * oldXYZ.x + sin(angle) * oldXYZ.z;
newXYZ.y = oldXYZ.y;
newXYZ.z = -sin(angle) * oldXYZ.x + cos(angle) * oldXYZ.z;

return newXYZ;
}

vec3 translation(vec3 offset, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = oldXYZ.x + offset.x;
newXYZ.y = oldXYZ.y + offset.y;
newXYZ.z = oldXYZ.z + offset.z;

return newXYZ;
}

vec3 translationBack(vec3 offset, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = oldXYZ.x - offset.x;
newXYZ.y = oldXYZ.y - offset.y;
newXYZ.z = oldXYZ.z - offset.z;

return newXYZ;
}

void main(){

//vec3 translationOffset = vec3(-50f, -50f, -50f);
//vec3 locationBuffer = translation(translationOffset, vertexPosition);
locationBuffer = rotationY(graphRotation, locationBuffer);
locationBuffer = translationBack(translationOffset, locationBuffer);

gl_Position = MVP * vec4(locationBuffer, 1);

}";

            return shader;
        }

        public static string BasicVertexShader(int location)
        {
            string shader = @"#version 410 compatibility
layout(location = " + location + @") in vec3 vertexPosition;

uniform float graphRotation;
uniform mat4 MVP;

vec3 rotationZ(float angle, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = cos(angle) * oldXYZ.x - sin(angle) * oldXYZ.y;
newXYZ.y = sin(angle) * oldXYZ.x + cos(angle) * oldXYZ.y;
newXYZ.z = oldXYZ.z;

return newXYZ;
}

vec3 rotationY(float angle, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = cos(angle) * oldXYZ.x + sin(angle) * oldXYZ.z;
newXYZ.y = oldXYZ.y;
newXYZ.z = -sin(angle) * oldXYZ.x + cos(angle) * oldXYZ.z;

return newXYZ;
}

vec3 translation(vec3 offset, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = oldXYZ.x + offset.x;
newXYZ.y = oldXYZ.y + offset.y;
newXYZ.z = oldXYZ.z + offset.z;

return newXYZ;
}

vec3 translationBack(vec3 offset, vec3 oldXYZ){
vec3 newXYZ;
newXYZ.x = oldXYZ.x - offset.x;
newXYZ.y = oldXYZ.y - offset.y;
newXYZ.z = oldXYZ.z - offset.z;

return newXYZ;
}

void main(){

vec3 translationOffset = vec3(-50f, -50f, -50f);
vec3 locationBuffer = translation(translationOffset, vertexPosition);
locationBuffer = rotationY(graphRotation, locationBuffer);
locationBuffer = translationBack(translationOffset, locationBuffer);

gl_Position = MVP * vec4(locationBuffer, 1);

}";

            return shader;
        }



        public static string BasicFragmentShader(float R, float G, float B, float A)
        {
            string shader = @"#version 410 compatibility
out vec4 color;

void main()
{
	//color = vec4(1, 1, 1, 0);
	gl_FragColor = vec4(" + R + ", " + G + ", " + B + ", " + A + @");

}";

            return shader;
        }

    }
}
