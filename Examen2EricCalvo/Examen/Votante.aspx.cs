using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen
{
    public partial class Votante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            int edad = Convert.ToInt32(txtEdad.Text.Trim());

            // Validar que la edad sea mayor o igual a 18
            if (edad < 18)
            {
                lblMensaje.Text = "Debe ser mayor de 18 años para registrarse como votante.";
                return;
            }

            // Registrar votante en la base de datos
            RegistrarVotante(cedula, nombre, edad);
        }

        private void RegistrarVotante(string cedula, string nombre, int edad)
        {
            string connectionString = "Data Source=DESKTOP-1SU8927\\SQLEXPRESS;Initial Catalog=votaciones;Integrated Security=True;";
            string query = "INSERT INTO Votantes (Cedula, Nombre, Edad) VALUES (@Cedula, @Nombre, @Edad)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cedula", cedula);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Edad", edad);

                connection.Open();
                command.ExecuteNonQuery();
            }

            lblMensaje.Text = "Votante registrado correctamente.";
        }
    }
}
    
