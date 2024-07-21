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
    public partial class Resultados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarResultados();
            }

        }

        private void MostrarResultados()
        {
            string connectionString = "Data Source=DESKTOP-1SU8927\\SQLEXPRESS;Initial Catalog=votaciones;Integrated Security=True;";
            string query = "SELECT Candidatos.Nombre AS Candidato, COUNT(Votos.IdVoto) AS VotosObtenidos, " +
                           "CONVERT(decimal(5,2), (COUNT(Votos.IdVoto) * 100.0 / (SELECT COUNT(*) FROM Votos))) AS PorcentajeVotos " +
                           "FROM Candidatos " +
                           "INNER JOIN Votos ON Candidatos.IdCandidato = Votos.IdCandidato " +
                           "GROUP BY Candidatos.Nombre " +
                           "ORDER BY VotosObtenidos DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(reader);

                GridViewResultados.DataSource = dt;
                GridViewResultados.DataBind();

                MostrarGanador(dt);
            }
        }

        private void MostrarGanador(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                DataRow ganadorRow = dt.Rows[0]; // El primer candidato tiene la mayor cantidad de votos

                string ganador = ganadorRow["Candidato"].ToString();
                lblGanador.Text = $"Ganador: {ganador}";

                // Verificar si hay empate
                bool hayEmpate = VerificarEmpate(dt);

                if (hayEmpate)
                {
                    lblMensaje.Text = "Hay un empate entre varios candidatos.";
                    lblGanador.Text = "No hay ganador, tenemos un empate.";
                }
                else
                {
                    lblMensaje.Text = string.Empty;
                }
            }
            else
            {
                lblGanador.Text = "No hay resultados disponibles.";
                lblMensaje.Text = string.Empty;
            }
        }

        private bool VerificarEmpate(DataTable dt)
        {
            int maxVotos = Convert.ToInt32(dt.Rows[0]["VotosObtenidos"]);
            bool hayEmpate = false;

            for (int i = 1; i < dt.Rows.Count; i++)
            {
                int votos = Convert.ToInt32(dt.Rows[i]["VotosObtenidos"]);

                if (votos == maxVotos)
                {
                    hayEmpate = true;
                }
                else
                {
                    break; // Si encontramos un votos menor al máximo, no hay empate
                }
            }

            return hayEmpate;
        }
    }
}