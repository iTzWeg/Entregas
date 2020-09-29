using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entregas
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            atualizaGrid();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-15NES98; Initial Catalog=DBEntregas;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("select * from Entrega where data_entrada_pedido = @dtentrega", con))
                {
                    cmd.Parameters.AddWithValue("dtentrega", this.dtfinal.Text);
                    
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet dscheque = new DataSet();
                        da.Fill(dscheque, "Entregas");
                        dgEntregas.DataSource = dscheque;
                        dgEntregas.DataMember = dscheque.Tables[0].TableName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }


        public void atualizaGrid()
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-15NES98; Initial Catalog=DBEntregas;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("select id_entrega as Nº, remetente as Remetente, destinatario as Destinatário, endereco_destinatario as Endereço, situacao as Situação, entregador as Entregador, data_entrada_pedido as Data, valor_entrega as Valor, observacao as Obs  from Entrega", con))
                {
                    try
                    {
                        con.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet dscheque = new DataSet();
                        da.Fill(dscheque, "Entregas");
                        dgEntregas.DataSource = dscheque;
                        dgEntregas.DataMember = dscheque.Tables[0].TableName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            atualizaGrid();
            this.dtfinal.Value = DateTime.Now.Date;
        }
    }
}
