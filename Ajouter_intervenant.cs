using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200000A RID: 10
	public partial class Ajouter_intervenant : Form
	{
		// Token: 0x06000078 RID: 120 RVA: 0x0001561D File Offset: 0x0001381D
		public Ajouter_intervenant()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00015635 File Offset: 0x00013835
		private void Ajouter_intervenant_Load(object sender, EventArgs e)
		{
			this.select_fonction();
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00015640 File Offset: 0x00013840
		private void select_fonction()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from fonction_intervenant";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x0001572C File Offset: 0x0001392C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.TextBox2.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToDouble(this.TextBox2.Text) > 0.0;
					if (flag3)
					{
						string cmdText = "select id from intervenant where nom = @i1";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count == 0;
						if (flag4)
						{
							string value = "Interne";
							int num = 0;
							bool isChecked = this.radRadioButton2.IsChecked;
							if (isChecked)
							{
								value = "Externe";
							}
							bool isChecked2 = this.radRadioButton3.IsChecked;
							if (isChecked2)
							{
								num = 1;
							}
							bool flag5 = this.radDropDownList6.Text != "";
							if (flag5)
							{
								string cmdText2 = "insert into intervenant (nom, taux_horaire, id_fonction, deleted, type_cout, chef_equipe) values (@i1, @i2, @i3, @i4, @i5, @i6)";
								SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
								sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
								sqlCommand2.Parameters.Add("@i2", SqlDbType.Real).Value = this.TextBox2.Text;
								sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
								sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
								sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = value;
								sqlCommand2.Parameters.Add("@i6", SqlDbType.Int).Value = num;
								bd.ouverture_bd(bd.cnn);
								sqlCommand2.ExecuteNonQuery();
								bd.cnn.Close();
								MessageBox.Show("Enregistrement avec succés");
								this.TextBox1.Clear();
								this.TextBox2.Clear();
								this.select_fonction();
							}
							else
							{
								string cmdText3 = "insert into intervenant (nom, taux_horaire, deleted, type_cout, chef_equipe) values (@i1, @i2, @i4, @i5, @i6)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Real).Value = this.TextBox2.Text;
								sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
								sqlCommand3.Parameters.Add("@i5", SqlDbType.VarChar).Value = value;
								sqlCommand3.Parameters.Add("@i6", SqlDbType.Int).Value = num;
								bd.ouverture_bd(bd.cnn);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
								MessageBox.Show("Enregistrement avec succés");
								this.TextBox1.Clear();
								this.TextBox2.Clear();
								this.select_fonction();
							}
						}
						else
						{
							MessageBox.Show("Erreur : L'intervenant est déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Taux horaire doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Taux horaire doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
