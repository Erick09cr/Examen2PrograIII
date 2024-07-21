using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Examen
{
    public partial class Votaciones : System.Web.UI.Page


    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCandidatos();
            }
        }
        protected void ButtonVotar_Click(object sender, EventArgs e)
        {
            string cedulaVotante = txtCedulaVotante.Text.Trim();
            int idCandidato = Convert.ToInt32(ddlCandidatos.SelectedValue);

            // Validar que se haya seleccionado un candidato
            if (idCandidato == 0)
            {
                lblMensaje.Text = "Debe seleccionar un candidato.";
                return;
            }

            // Verificar si el votante ya ha votado
            if (VotanteYaVoto(cedulaVotante))
            {
                lblMensaje.Text = "Usted ya ha votado.";
                return;
            }

            if (!CedulaRegistrada(cedulaVotante))
            {
                lblMensaje.Text = "Cédula no registrada. No se puede procesar el voto.";
                return;
            }



            // Registrar el voto en la base de datos
            RegistrarVoto(cedulaVotante, idCandidato);

            // Redireccionar a página de confirmación
            Response.Redirect("VotoRegistrado.aspx");
        }

        private void CargarCandidatos()
        {
            string connectionString = "Data Source=DESKTOP-1SU8927\\SQLEXPRESS;Initial Catalog=votaciones;Integrated Security=True;";
            string query = "SELECT IdCandidato, Nombre FROM Candidatos";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ddlCandidatos.DataSource = reader;
                ddlCandidatos.DataTextField = "Nombre";
                ddlCandidatos.DataValueField = "IdCandidato";
                ddlCandidatos.DataBind();

                ddlCandidatos.Items.Insert(0, new ListItem("-- Seleccione un Candidato --", "0"));

                reader.Close();
            }
        }

        private bool VotanteYaVoto(string cedula)
        {
            string connectionString = "Data Source=DESKTOP-1SU8927\\SQLEXPRESS;Initial Catalog=votaciones;Integrated Security=True;";
            string query = "SELECT COUNT(*) FROM Votos INNER JOIN Votantes ON Votos.IdVotante = Votantes.IdVotante WHERE Votantes.Cedula = @Cedula";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cedula", cedula);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }

        private void RegistrarVoto(string cedula, int idCandidato)
        {
            string connectionString = "Data Source=DESKTOP-1SU8927\\SQLEXPRESS;Initial Catalog=votaciones;Integrated Security=True;";
            string query = "INSERT INTO Votos (IdVotante, IdCandidato, FechaVoto) SELECT IdVotante, @IdCandidato, GETDATE() FROM Votantes WHERE Cedula = @Cedula";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cedula", cedula);
                command.Parameters.AddWithValue("@IdCandidato", idCandidato);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private bool CedulaRegistrada(string cedula)
        {
            string connectionString = "Data Source=DESKTOP-1SU8927\\SQLEXPRESS;Initial Catalog=votaciones;Integrated Security=True;";
            string query = "SELECT COUNT(*) FROM Votantes WHERE Cedula = @Cedula";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Cedula", cedula);

                connection.Open();
                int count = (int)command.ExecuteScalar();

                return count > 0;
            }
        }
    }
}


