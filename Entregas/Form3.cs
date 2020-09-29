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
    public partial class Form3 : Form
    {
        String ID;
        int identrega;
        public Form3()
        {
            InitializeComponent();
            atualizaGrid();
        }



        private void btnInserir_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-15NES98; Initial Catalog=DBEntregas;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Entrega] ([situacao] ,[data_entrada_pedido] ,[remetente] ,[destinatario] ,[endereco_destinatario] ,[valor_entrega] ,[observacao] ,[entregador]) VALUES (@situa, @data, @remete, @destin, @endere, @valor, @obs, @entregador)", con))
                {

                    cmd.Parameters.AddWithValue("situa", cbxSituacao.Text);
                    cmd.Parameters.AddWithValue("data", this.dtfinal.Text);
                    cmd.Parameters.AddWithValue("remete", txtRemetente.Text);
                    cmd.Parameters.AddWithValue("destin", txtDestinatario.Text);
                    cmd.Parameters.AddWithValue("endere", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("valor", Convert.ToDouble(txtValor.Text));
                    cmd.Parameters.AddWithValue("obs", txtObs.Text);
                    cmd.Parameters.AddWithValue("entregador", txtEntregador.Text);
                    try
                    {

                        con.Open();
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                            MessageBox.Show("Entrega cadastrada com sucesso!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);

                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            atualizaGrid();
            limparCampos();
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

        public void limparCampos()
        {
            txtDestinatario.Text = "";
            txtEndereco.Text = "";
            txtEntregador.Text = "";
            txtObs.Text = "";
            txtRemetente.Text = "";
            txtValor.Text = "";
            this.dtfinal.Value = DateTime.Now.Date;

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-15NES98; Initial Catalog=DBEntregas; Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Entrega SET situacao = @situa, data_entrada_pedido = @data, remetente = @remete, destinatario = @destin, endereco_destinatario = @endere, valor_entrega = @valor, observacao = @obs, entregador = @entregador  WHERE id_entrega = @id", con))
                {

                    cmd.Parameters.AddWithValue("situa", cbxSituacao.Text);
                    cmd.Parameters.AddWithValue("data", this.dtfinal.Text);
                    cmd.Parameters.AddWithValue("remete", txtRemetente.Text);
                    cmd.Parameters.AddWithValue("destin", txtDestinatario.Text);
                    cmd.Parameters.AddWithValue("endere", txtEndereco.Text);
                    cmd.Parameters.AddWithValue("valor", Convert.ToDouble(txtValor.Text));
                    cmd.Parameters.AddWithValue("obs", txtObs.Text);
                    cmd.Parameters.AddWithValue("entregador", txtEntregador.Text);
                    cmd.Parameters.AddWithValue("id", identrega);

                    try
                    {
                        con.Open();
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                            MessageBox.Show("Registro alterado com sucesso!");
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            atualizaGrid();
            limparCampos();
        }

        private void dgEntregas_DoubleClick(object sender, EventArgs e)
        {
            identrega = Convert.ToInt32(dgEntregas.CurrentRow.Cells[0].Value.ToString());
            txtRemetente.Text = dgEntregas.CurrentRow.Cells[1].Value.ToString();
            txtDestinatario.Text = dgEntregas.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = dgEntregas.CurrentRow.Cells[3].Value.ToString();
            //situação 4
            txtEntregador.Text = dgEntregas.CurrentRow.Cells[5].Value.ToString();
            dtfinal.Value = Convert.ToDateTime(dgEntregas.CurrentRow.Cells[6].Value.ToString());
            txtValor.Text = dgEntregas.CurrentRow.Cells[7].Value.ToString();
            txtObs.Text = dgEntregas.CurrentRow.Cells[8].Value.ToString();
        }

        private void dgEntregas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //    identrega = Convert.ToInt32(dgEntregas.CurrentRow.Cells[0].Value.ToString());
            //    txtRemetente.Text = dgEntregas.CurrentRow.Cells[1].Value.ToString();
            //    txtDestinatario.Text = dgEntregas.CurrentRow.Cells[2].Value.ToString();
            //    txtEndereco.Text = dgEntregas.CurrentRow.Cells[3].Value.ToString();
            //    //situação 4
            //    txtEntregador.Text = dgEntregas.CurrentRow.Cells[5].Value.ToString();
            //    dtfinal.Value = Convert.ToDateTime(dgEntregas.CurrentRow.Cells[6].Value.ToString());
            //    txtValor.Text = dgEntregas.CurrentRow.Cells[7].Value.ToString();
            //    txtObs.Text = dgEntregas.CurrentRow.Cells[8].Value.ToString();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-15NES98; Initial Catalog=DBEntregas;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Entrega WHERE id_entrega = @ID", con))
                {
                    cmd.Parameters.AddWithValue("id", identrega);
                    try
                    {
                        con.Open();
                        if (cmd.ExecuteNonQuery() > -1)
                        {
                            MessageBox.Show("Entrega Excluida com sucesso!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro: " + ex);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }
            atualizaGrid();
            limparCampos();
        }

        private void dgEntregas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            identrega = Convert.ToInt32(dgEntregas.CurrentRow.Cells[0].Value.ToString());
            txtRemetente.Text = dgEntregas.CurrentRow.Cells[1].Value.ToString();
            txtDestinatario.Text = dgEntregas.CurrentRow.Cells[2].Value.ToString();
            txtEndereco.Text = dgEntregas.CurrentRow.Cells[3].Value.ToString();
            //situação 4
            txtEntregador.Text = dgEntregas.CurrentRow.Cells[5].Value.ToString();
            dtfinal.Value = Convert.ToDateTime(dgEntregas.CurrentRow.Cells[6].Value.ToString());
            txtValor.Text = dgEntregas.CurrentRow.Cells[7].Value.ToString();
            txtObs.Text = dgEntregas.CurrentRow.Cells[8].Value.ToString();

        }
    }
}
