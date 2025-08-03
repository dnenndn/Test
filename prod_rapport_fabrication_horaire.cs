using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000116 RID: 278
	public partial class prod_rapport_fabrication_horaire : Form
	{
		// Token: 0x06000C51 RID: 3153 RVA: 0x001E09EC File Offset: 0x001DEBEC
		public prod_rapport_fabrication_horaire()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000C52 RID: 3154 RVA: 0x001E0A3F File Offset: 0x001DEC3F
		private void prod_rapport_fabrication_horaire_Load(object sender, EventArgs e)
		{
			this.select_horaire();
		}

		// Token: 0x06000C53 RID: 3155 RVA: 0x001E0A4C File Offset: 0x001DEC4C
		private void select_horaire()
		{
			bd bd = new bd();
			this.radGridView1.Rows.Clear();
			string cmdText = "select prod_rapport_horaire_fabrication.id, prod_saisie.designation, h1, h2, h3, h4, h5, h6, h7, h8 from prod_rapport_horaire_fabrication inner join prod_saisie on prod_rapport_horaire_fabrication.id_qualite = prod_saisie.id where id_rapport = @i1 and id_unite = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[7].ToString(),
						dataTable.Rows[i].ItemArray[8].ToString(),
						dataTable.Rows[i].ItemArray[9].ToString()
					});
				}
			}
		}

		// Token: 0x06000C54 RID: 3156 RVA: 0x001E0C5C File Offset: 0x001DEE5C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				int num = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					for (int j = 2; j <= 9; j++)
					{
						bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[j].Value));
						if (flag2)
						{
							num = 0;
						}
					}
				}
				bool flag3 = num == 1;
				if (flag3)
				{
					bd bd = new bd();
					for (int k = 0; k < this.radGridView1.Rows.Count; k++)
					{
						string cmdText = "update prod_rapport_horaire_fabrication set h1 = @h1, h2 =@h2, h3 =@h3, h4 = @h4, h5=@h5, h6 =@h6, h7=@h7, h8=@h8 where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[k].Cells[0].Value.ToString();
						sqlCommand.Parameters.Add("@h1", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[2].Value.ToString();
						sqlCommand.Parameters.Add("@h2", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[3].Value.ToString();
						sqlCommand.Parameters.Add("@h3", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[4].Value.ToString();
						sqlCommand.Parameters.Add("@h4", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[5].Value.ToString();
						sqlCommand.Parameters.Add("@h5", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[6].Value.ToString();
						sqlCommand.Parameters.Add("@h6", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[7].Value.ToString();
						sqlCommand.Parameters.Add("@h7", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[8].Value.ToString();
						sqlCommand.Parameters.Add("@h8", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[9].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText2 = "select id_mesure from prod_mesure where id_unite = @i1 and id_saisie in(select id_qualite from prod_rapport_horaire_fabrication where id = @i2)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[k].Cells[0].Value.ToString();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count != 0;
						if (flag4)
						{
							for (int l = 0; l < dataTable.Rows.Count; l++)
							{
								int id_mesure = Convert.ToInt32(dataTable.Rows[l].ItemArray[0]);
								for (int m = 2; m <= 9; m++)
								{
									double valeur = Convert.ToDouble(this.radGridView1.Rows[k].Cells[m].Value);
									lancement_ot_preventive.creation_ot_mesure(id_mesure, valeur);
								}
							}
						}
					}
					MessageBox.Show("Modification avec succés");
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}
	}
}
