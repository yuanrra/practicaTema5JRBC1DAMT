using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp13
{

    public partial class Form1 : Form
    {
        Alumnos misAlumnos = new Alumnos();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Alumno miAlumno = new Alumno();
            String miAlumnoStr, miAlumnoNotaTexto;
            miAlumno.Nombre = aluNombre.Text;
            miAlumno.Nota = Convert.ToInt32(aluNota.Text);
            if (miAlumno.Nota < 5)
            {
                miAlumnoNotaTexto = "Suspenso";
            }
            else if (miAlumno.Nota < 7)
            {
                miAlumnoNotaTexto = "Aprobado";
            }
            else if (miAlumno.Nota < 9)
            {
                miAlumnoNotaTexto = "Notable";
            }
            else
                miAlumnoNotaTexto = "Sobresaliente_v2";
            miAlumnoStr = aluNombre.Text + " " + aluNota.Text + " " +
            miAlumnoNotaTexto + "\n";
            listaAlumnos.AppendText(miAlumnoStr);
            misAlumnos.Agregar(miAlumno);
        }
        //Para añadir un cambio




        class Alumno
        {
            private string nombre;
            private int nota;
            public string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }
            public int Nota
            {
                get { return nota; }
                set
                {
                    if (value >= 0 && value <= 10)
                        nota = value;
                }
            }
            public Boolean Aprobado
            {
                get
                {
                    if (nota >= 5)
                        return true;
                    else
                        return false;
                }
            }
        }

        class Alumnos
        {
            private ArrayList listaAlumnos = new ArrayList();

            // Agrega un nuevo alumno a la lista
            //        
            public void Agregar(Alumno alu)
            {
                listaAlumnos.Add(alu);
            }

            // Devuelve el alumno que está en la posición num
            //
            public Alumno Obtener(int num)
            {
                if (num >= 0 && num <= listaAlumnos.Count)
                {
                    return ((Alumno)listaAlumnos[num]);
                }
                return null;
            }

            // Devuelve la nota media de los alumnos
            //
            public float Media
            {
                get
                {
                    if (listaAlumnos.Count == 0)
                        return 0;
                    else
                    {
                        float media = 0;
                        for (int i = 0; i < listaAlumnos.Count; i++)
                        {
                            media += ((Alumno)listaAlumnos[i]).Nota;
                        }
                        return (media / listaAlumnos.Count);
                    }
                }
            }
        }


    }
}