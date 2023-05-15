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
    internal class CCliente
    {
        public void mostrarCliente(DataGridView tablaCliente)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "Select * from Cliente";
                tablaCliente.DataSource = null;
                MySqlDataAdapter adapter = new MySqlDataAdapter(query, objetoConexion.establecerConexion());
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                tablaCliente.DataSource = dt;
                objetoConexion.cerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se mostraron los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void guardarCliente(TextBox nombres, TextBox apellidos, TextBox Dni , TextBox telefono)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "insert into Cliente (Nombre,Apellidos,Dni,Telefono)" + "values ('" + nombres.Text + "','" + apellidos.Text + "','" + Dni.Text + "','" + telefono.Text +  "');";
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
        public void SelecionCliente(DataGridView tablaCliente, TextBox id, TextBox nombres, TextBox apellidos, TextBox Dni,TextBox telefono)
        {
            try
            {
                id.Text = tablaCliente.CurrentRow.Cells[0].Value.ToString();
                nombres.Text = tablaCliente.CurrentRow.Cells[1].Value.ToString();
                apellidos.Text = tablaCliente.CurrentRow.Cells[2].Value.ToString();
                Dni.Text = tablaCliente.CurrentRow.Cells[3].Value.ToString();
                telefono.Text = tablaCliente.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Noo se seleciona los datos de la base de datos, error " + ex.ToString());
            }
        }
        public void modificarCliente(TextBox Id, TextBox nombres, TextBox apellidos, TextBox Dni, TextBox telefono)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "update cliente set Nombre='" + nombres.Text + "', Apellidos ='" + apellidos.Text + "', DNI ='" + Dni.Text + "', Telefono ='" + telefono.Text +  "' where ID_Cliente = '" + Id.Text + "';";
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
        public void DeleteCliente(TextBox Id)
        {
            try
            {
                CConexion objetoConexion = new CConexion();

                String query = "delete from Cliente where ID_cliente = '" + Id.Text + "';";
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
