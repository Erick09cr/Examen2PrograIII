using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen
{
    public partial class IngresarCandidatos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            string cedula = txtCedula.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            string partidoPolitico = txtPartidoPolitico.Text.Trim();

            // Validación asegurarse de que los campos no estén vacíos
            if (string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(partidoPolitico))
            {
                return;
            }

            InsertarCandidato(cedula, nombre, partidoPolitico);

            // Redirigir a una página de confirmación 
            Response.Redirect("CandidatoGuardado.aspx");
        }

        private void InsertarCandidato(string cedula, string nombre, string partidoPolitico)
        {
            string connectionString = "Data Source=DESKTOP-1SU8927\\SQLEXPRESS;Initial Catalog=votaciones;Integrated Security=True;";
            string query = "INSERT INTO Candidatos (Cedula, Nombre, PartidoPolitico) VALUES (@Cedula, @Nombre, @PartidoPolitico)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cedula", cedula);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@PartidoPolitico", partidoPolitico);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}