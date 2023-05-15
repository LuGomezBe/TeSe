using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoSen.Clases
{
    internal class CEquipo
    {
        public void mostrarEquipo(DataGridView tablaEquipo)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "Select * from equipo";
                tablaEquipo.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaEquipo.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void guardarEquipo(ComboBox equipo, TextBox marca, TextBox descripcion)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into Equipo (Tipo_d_Equipo,Marca,Descripcion_Falla)" + "values ('" + equipo.Text + "','" + marca.Text + "','" + descripcion.Text + "');";
                MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se guardo los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void SelecionEquipo(DataGridView tablaEquipo, TextBox Id, ComboBox equipo, TextBox marca, TextBox descripcion)
        {
            try
            {
                Id.Text = tablaEquipo.CurrentRow.Cells[0].Value.ToString();
                equipo.Text = tablaEquipo.CurrentRow.Cells[1].Value.ToString();
                marca.Text = tablaEquipo.CurrentRow.Cells[2].Value.ToString();
                descripcion.Text = tablaEquipo.CurrentRow.Cells[3].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se seleciona los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void modificarEquipo(TextBox Id, ComboBox equipo, TextBox marca, TextBox descripcion)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "update equipo set Tipo_d_Equipo='" + equipo.Text + "', Marca='" + marca.Text + "', Descripcion_Falla ='" + descripcion.Text + "' where Num_Registro= '" + Id.Text + "';";
                MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se modifico los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void DeleteEquipo(TextBox Id)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "delete from equipo where Num_Registro = '" + Id.Text + "';";
                MySqlCommand mySqlCommand = new MySqlCommand(query, objetoConexion.establecerConexion());
                MySqlDataReader reader = mySqlCommand.ExecuteReader();

                while (reader.Read()) { }
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se elimino los datos de la base de datos, error " + ex.ToString());
            }
        }
    }
}
