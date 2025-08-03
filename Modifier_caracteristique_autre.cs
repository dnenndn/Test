using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200009A RID: 154
	public partial class Modifier_caracteristique_autre : Form
	{
		// Token: 0x06000700 RID: 1792 RVA: 0x00132E96 File Offset: 0x00131096
		public Modifier_caracteristique_autre()
		{
			this.InitializeComponent();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000701 RID: 1793 RVA: 0x00132EC8 File Offset: 0x001310C8
		private void Modifier_caracteristique_autre_Load(object sender, EventArgs e)
		{
			this.label6.Text = Sous_Famille.id_cr;
			this.select_type();
			string cmdText = "select nom, champ_obligatoire, type from caracteristique where id = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Sous_Famille.id_cr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				bool flag2 = dataTable.Rows[0].ItemArray[1].ToString() == "0";
				if (flag2)
				{
					this.radCheckBox1.Checked = false;
				}
				else
				{
					this.radCheckBox1.Checked = true;
				}
				this.ComboBox1.Text = dataTable.Rows[0].ItemArray[2].ToString();
				string cmdText2 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Sous_Famille.id_cr;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag3 = dataTable2.Rows.Count != 0;
				if (flag3)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable2.Rows[i].ItemArray[0].ToString()
						});
						bool flag4 = dataTable2.Rows[i].ItemArray[1].ToString() == "1";
						if (flag4)
						{
							this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[1].Value = "True";
						}
						this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[2].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
					}
				}
			}
		}

		// Token: 0x06000702 RID: 1794 RVA: 0x00133148 File Offset: 0x00131348
		private void select_type()
		{
			this.ComboBox1.Items.Clear();
			this.ComboBox1.Items.Add("Select Unique");
			this.ComboBox1.Items.Add("Select Multiple");
			this.ComboBox1.Items.Add("CheckBox");
			this.ComboBox1.Items.Add("Radio Button");
		}

		// Token: 0x06000703 RID: 1795 RVA: 0x001331C0 File Offset: 0x001313C0
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 2;
					if (flag3)
					{
						this.radGridView1.Rows.RemoveAt(e.RowIndex);
					}
				}
			}
		}

		// Token: 0x06000704 RID: 1796 RVA: 0x0013322C File Offset: 0x0013142C
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.guna2TextBox1.Text) != "";
			if (flag)
			{
				this.radGridView1.Rows.Add(new object[]
				{
					this.guna2TextBox1.Text
				});
				this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[2].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
				this.guna2TextBox1.Clear();
			}
		}

		// Token: 0x06000705 RID: 1797 RVA: 0x001332CC File Offset: 0x001314CC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & this.ComboBox1.Text != "";
			if (flag)
			{
				int num = 0;
				bool @checked = this.radCheckBox1.Checked;
				if (@checked)
				{
					num = 1;
				}
				string cmdText = "update caracteristique set nom = @i2, type = @i3, champ_obligatoire = @i4 where id = @i1";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
				sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.ComboBox1.Text;
				sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = num;
				string cmdText2 = "delete caracteristique_option where id_caracteristique = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				bool flag2 = this.radGridView1.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < this.radGridView1.Rows.Count; i++)
					{
						bool flag3 = fonction.DeleteSpace(Convert.ToString(this.radGridView1.Rows[i].Cells[0].Value)) != "";
						if (flag3)
						{
							int num2 = 0;
							bool flag4 = Convert.ToString(this.radGridView1.Rows[i].Cells[1].Value) == "True";
							if (flag4)
							{
								num2 = 1;
							}
							string cmdText3 = "insert into caracteristique_option (id_caracteristique, valeur_option, defaut) values (@i1, @i2, @i3)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = this.label6.Text;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = Convert.ToString(this.radGridView1.Rows[i].Cells[0].Value);
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = num2;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
				MessageBox.Show("Succés");
				Sous_Famille.select_caracteristique(Sous_Famille.id_sous_famille);
				base.Close();
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
