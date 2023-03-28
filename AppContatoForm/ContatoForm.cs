using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AppContatoForm
{
    public partial class ContatoForm : Form
    {
        private MySqlConnection _conexao;

        public ContatoForm()
        {
            InitializeComponent();

            Conexao();
        }

        private void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd;" +
                "user=root;password=root;port=3360";

            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var nome = txtNome.Text;
            var email = txtEmail.Text;

            var sql = "INSERT INTO contato (data_nasc_con, nome_con, email_con) " +
                "VALUES ('1986-11-13', @_nome, @_email)";
            var comando = new MySqlCommand(sql, _conexao);

            comando.Parameters.AddWithValue("@_nome", nome);
            comando.Parameters.AddWithValue("@_email", email);
            comando.ExecuteNonQuery();

            _conexao.Close();

        }
    }
}
