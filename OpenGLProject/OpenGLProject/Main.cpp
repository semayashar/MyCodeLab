#include <GLFW/glfw3.h>
#include <cmath>

#ifndef M_PI
#define M_PI (3.141592653589793238462643383279502884L)
#endif

int main(void)
{
    GLFWwindow* window;

    /* Initialize the library */
    if (!glfwInit())
        return -1;

    /* Create a windowed mode window and its OpenGL context */
    window = glfwCreateWindow(640, 480, "Hello World", NULL, NULL);
    if (!window)
    {
        glfwTerminate();
        return -1;
    }

    /* Make the window's context current */
    glfwMakeContextCurrent(window);

    /* Enable smooth shading */
    glShadeModel(GL_SMOOTH);

    /* Set the background color to black */
    glClearColor(0.0f, 0.0f, 0.0f, 0.0f);

    /* Set the viewport */
    glViewport(0, 0, 640, 480);

    /* Set the projection matrix */
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    glOrtho(0, 640, 0, 480, -1, 1);

    /* Switch back to the modelview matrix */
    glMatrixMode(GL_MODELVIEW);
    glLoadIdentity();

    /* Loop until the user closes the window */
    while (!glfwWindowShouldClose(window))
    {
        /* Render here */
        glClear(GL_COLOR_BUFFER_BIT);

        /* Begin drawing */
        glBegin(GL_LINE_LOOP);

        /* Set the color to red */
        glColor3f(1.0f, 0.0f, 0.0f);

        /* Define the circle */
        float radius = 20.0f;
        for (int i = 0; i < 360; i++)
        {
            float angle = i * (M_PI / 180.0f);
            float x = 30 + radius * std::cos(angle);
            float y = 50 + radius * std::sin(angle);
            glVertex2f(x, y);
        }

        /* End drawing */
        glEnd();

        /* Swap front and back buffers */
        glfwSwapBuffers(window);

        /* Poll for and process events */
        glfwPollEvents();
    }

    glfwTerminate();
    return 0;
}
