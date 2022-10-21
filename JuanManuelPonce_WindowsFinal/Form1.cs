using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.VisualBasic;

namespace JuanManuelPonce_WindowsFinal
{
    public partial class Form1 : Form
    {
        string nombre;
        string apellido;
        string puesto;
        int sueldo;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;   
            puesto = txtPuesto.Text;
            sueldo = Convert.ToInt32(txtSueldo.Text);

            bool sueldoValido = ValidarSueldo(sueldo);
            bool puestoValido = ValidarPuesto(puesto);
            bool nombreValido = ValidarCadena(nombre); ValidarCadena(apellido);

            if (!puestoValido || !sueldoValido || !nombreValido)
            {
                MessageBox.Show("Campos invalidos");
            }
            else
            {
                MessageBox.Show("Campos validos");
            }
            


        }
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            puesto = txtPuesto.Text;

            string mensaje = Concatenar(nombre, apellido, puesto);

            MessageBox.Show(mensaje);

        }
        private void btnHoras_Click(object sender, EventArgs e)
        {
            int[] horas = IngresarHoras();
            int totalHoras = CalcularHorasSemanales(horas);
            int promedioHoras = CalcularPromedio(totalHoras, horas.Length);
            string dias = DiasConMenosDe4hs(horas);
            MessageBox.Show("El total de horas fue de: " + totalHoras +"\nEl promedio de horas fue de: " + promedioHoras + "\n" + dias);

        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtSueldo.Clear();
            txtPuesto.Clear();
        }

        #region METODOS

        public bool ValidarSueldo(int salario)
        {
            bool valido = true;
            if(salario <= 0)
            {
                valido = false;
            }
            return valido;
        }

        public bool ValidarPuesto(string posicion)
        {
            bool valido = false;
            if (posicion == "Soporte Técnico")
            {
                valido = true;
            }
            else if (posicion == "DBA")
            {
                valido = true;
            }
            else if (posicion == "Desarrollador")
            {
                valido = true;
            }
            return valido;
        }

        public bool ValidarCadena(string cadena)
        {
            bool valido = false;

            if (cadena.Length > 2 && cadena.Length < 50)
            {
                valido = true;
            }

            return valido;
        }

        public string Concatenar(string cadena1, string cadena2, string cadena3)
        {
            string cadenaFinal = cadena1.ToUpper() + " " + cadena2.ToUpper() + " " + cadena3.ToUpper();
            return cadenaFinal;
        }

        public int[] IngresarHoras()
        {
            int[] horas = new int[5];
            for (int i = 0; i < horas.Length; i++)
            {
                int dia = i + 1;
                horas[i] = Convert.ToInt32(Interaction.InputBox("Ingrese horas del dia " + dia.ToString()));
            }
            return horas;
        }
        public int CalcularHorasSemanales(int[] horas)
        {
            int sumaHoras = 0;
            for (int i = 0; i < horas.Length; i++)
            {
                sumaHoras += horas[i];
            }
            return sumaHoras;
        }

        public int CalcularPromedio(int horasTotales, int dias)
        {
            int promedio = horasTotales/dias;
            return promedio;
        }

        public string DiasConMenosDe4hs(int[] horas)
        {
            string[] diasConMenosHoras = new string[5];

            for (int i = 0; i < horas.Length; i++)
            {
                int dia = i + 1;
                if (horas[i] > 4)
                {
                    diasConMenosHoras[i] = "El dia " + dia + " trabajo menos de 4hs";
                }
            }
            string cadenaFinal = string.Join("\n", diasConMenosHoras);
            return cadenaFinal;
        }


        #endregion

    }
}
