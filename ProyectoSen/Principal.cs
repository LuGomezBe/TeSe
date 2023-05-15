using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSen
{
    public partial class Principal : Form
    {

        public Principal()
        {
            InitializeComponent();
            
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Clases.CCliente objetoTecnico = new Clases.CCliente();
            objetoTecnico.mostrarCliente(dgvPrincipal);
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            Clases.CEquipo objetoTecnico = new Clases.CEquipo();
            objetoTecnico.mostrarEquipo(dgvPrincipal);
        }

        private void btnTecnico_Click(object sender, EventArgs e)
        {
            Clases.CTecnico objetoTecnico = new Clases.CTecnico();
            objetoTecnico.mostrarTecnico(dgvPrincipal);
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(cmbCrear.SelectedIndex == 0) 
            {
                this.Hide();
                Form1 formulario1 = new Form1();
                formulario1.ShowDialog();
            }
            if (cmbCrear.SelectedIndex == 1)
            {
                this.Hide();
                Cliente formulario1 = new Cliente();
                formulario1.ShowDialog();
            }
            if (cmbCrear.SelectedIndex == 2)
            {
                this.Hide();
                Equipo formulario1 = new Equipo();
                formulario1.ShowDialog();
            }
            else
            {
                lblMessage.Text = "↑ Elija una opcion ↑";
            }
        }
    }
}
