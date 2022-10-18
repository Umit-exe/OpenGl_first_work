using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.OpenGl;
using Tao.Platform.Windows;

namespace Ornek2020
{
    public partial class Form1 : Form
    {
        float alfa = 0;
        public Form1()
        {
            InitializeComponent();
            OpenGlControl.InitializeContexts();
            // OpenGL ilk işlemler
            Gl.glClearColor(0.1f, 0.1f, 0.1f, 0.0f);
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glOrtho(0.0, 1.0, 0.0, 1.0, -1.0, 1.0);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void MyPaint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
            Gl.glColor3f(0.2f, 0.5f, 0.0f);
            //Gl.glTranslatef(x, y, z);
            
            Gl.glPushMatrix();
            Gl.glTranslatef(0.5f, 0.5f, 0);
            Gl.glRotatef(alfa, 0, 0, 1);
            Gl.glTranslatef(-0.5f, -0.5f, 0);
            Gl.glBegin(Gl.GL_TRIANGLES);
                    Gl.glVertex3f(0.0f, 0.0f, 0.0f);
                    Gl.glVertex3f(0.5f, 0.5f, 0.0f);
                    Gl.glVertex3f(1.0f, 0.0f, 0.0f);
                    Gl.glVertex3f(0.0f, 1.0f, 0.0f);
                    Gl.glVertex3f(0.5f, 0.5f, 0.0f);
                    Gl.glVertex3f(1.0f, 1.0f, 0.0f);
            Gl.glEnd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            alfa = (alfa + 5) % 360;
            OpenGlControl.Refresh();
        }

        private void MyKeys(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
                alfa = (alfa + 5) % 360;
            if (e.KeyCode == Keys.D)
                alfa = (alfa - 5) % 360;
            OpenGlControl.Refresh();
        }
    }
}
