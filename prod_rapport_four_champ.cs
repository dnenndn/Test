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
	// Token: 0x02000119 RID: 281
	public partial class prod_rapport_four_champ : Form
	{
		// Token: 0x06000C71 RID: 3185 RVA: 0x001E48F8 File Offset: 0x001E2AF8
		public prod_rapport_four_champ()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000C72 RID: 3186 RVA: 0x001E494B File Offset: 0x001E2B4B
		private void prod_rapport_four_champ_Load(object sender, EventArgs e)
		{
			this.select_champs();
		}

		// Token: 0x06000C73 RID: 3187 RVA: 0x001E4958 File Offset: 0x001E2B58
		private void select_champs()
		{
			bd bd = new bd();
			this.radGridView1.Rows.Clear();
			string cmdText = "select prod_rapport_four_qualite.id, prod_saisie.designation, valeur, prod_saisie.id from prod_rapport_four_qualite inner join prod_saisie on prod_rapport_four_qualite.id_qualite = prod_saisie.id where id_rapport = @i1 and id_unite = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_four.id_unite;
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
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
			}
		}

		// Token: 0x06000C74 RID: 3188 RVA: 0x001E4AB8 File Offset: 0x001E2CB8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				int num = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[2].Value));
					if (flag2)
					{
						num = 0;
					}
				}
				bool flag3 = num == 1;
				if (flag3)
				{
					bd bd = new bd();
					for (int j = 0; j < this.radGridView1.Rows.Count; j++)
					{
						string cmdText = "update prod_rapport_four_qualite set valeur = @h where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[j].Cells[0].Value.ToString();
						sqlCommand.Parameters.Add("@h", SqlDbType.Real).Value = this.radGridView1.Rows[j].Cells[2].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText2 = "select id_mesure from prod_mesure where id_unite = @i1 and id_saisie in(select id_qualite from prod_rapport_four_qualite where id = @i2)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport_four.id_unite;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[j].Cells[0].Value.ToString();
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count != 0;
						if (flag4)
						{
							for (int k = 0; k < dataTable.Rows.Count; k++)
							{
								int id_mesure = Convert.ToInt32(dataTable.Rows[k].ItemArray[0]);
								double valeur = Convert.ToDouble(this.radGridView1.Rows[j].Cells[2].Value);
								lancement_ot_preventive.creation_ot_mesure(id_mesure, valeur);
							}
						}
					}
					string cmdText3 = "select prod_rapport_four_entre.id, id_produit, prod_type_brique.designation from prod_rapport_four_entre inner join prod_type_brique on prod_rapport_four_entre.id_produit = prod_type_brique.id where id_rapport = @i1 and id_unite = @i2";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
					sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_four.id_unite;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag5 = dataTable2.Rows.Count != 0;
					if (flag5)
					{
						for (int l = 0; l < dataTable2.Rows.Count; l++)
						{
							string cmdText4 = "update prod_rapport_four_entre set tonnage = quantite *  @t where id = @i";
							double num2 = fonction.tonnage_wagon(this.radGridView1.Rows[l].Cells[2].Value.ToString());
							string cmdText5 = "select valeur from prod_rapport_four_qualite where id_rapport = @i1 and id_unite = @i2 and id_qualite = (select id from prod_saisie where poid_four = @d)";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
							sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_four.id_unite;
							sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter3.Fill(dataTable3);
							int num3 = Convert.ToInt32(this.radGridView1.Rows[l].Cells[3].Value);
							double num4 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
							bool flag6 = num3 == 1;
							if (flag6)
							{
							}
							bool flag7 = num3 == 2;
							if (flag7)
							{
							}
							bool flag8 = num3 == 3;
							if (flag8)
							{
							}
							bool flag9 = num3 == 4;
							if (flag9)
							{
							}
							bool flag10 = num3 == 5;
							double num5;
							if (flag10)
							{
								num5 = 4200.0;
							}
							else
							{
								num5 = 7200.0;
							}
							bool flag11 = num4 != 0.0;
							if (flag11)
							{
								num5 = num4;
							}
							double num6 = num5 * num2;
							SqlCommand sqlCommand5 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand5.Parameters.Add("@t", SqlDbType.Real).Value = num6;
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[l].ItemArray[0].ToString();
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					string cmdText6 = "select prod_rapport_four_sortie.id, id_produit, prod_type_brique.designation from prod_rapport_four_sortie inner join prod_type_brique on prod_rapport_four_sortie.id_produit = prod_type_brique.id where id_rapport = @i1 and id_unite = @i2";
					SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
					sqlCommand6.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
					sqlCommand6.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_four.id_unite;
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand6);
					DataTable dataTable4 = new DataTable();
					sqlDataAdapter4.Fill(dataTable4);
					bool flag12 = dataTable4.Rows.Count != 0;
					if (flag12)
					{
						for (int m = 0; m < dataTable4.Rows.Count; m++)
						{
							string cmdText7 = "update prod_rapport_four_sortie set tonnage = quantite *  @t where id = @i";
							double num7 = fonction.tonnage_wagon(this.radGridView1.Rows[m].Cells[2].Value.ToString());
							string cmdText8 = "select valeur from prod_rapport_four_qualite where id_rapport = @i1 and id_unite = @i2 and id_qualite = (select id from prod_saisie where poid_four = @d)";
							SqlCommand sqlCommand7 = new SqlCommand(cmdText8, bd.cnn);
							sqlCommand7.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
							sqlCommand7.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_four.id_unite;
							sqlCommand7.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand7);
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter5.Fill(dataTable5);
							int num8 = Convert.ToInt32(this.radGridView1.Rows[m].Cells[3].Value);
							double num9 = Convert.ToDouble(dataTable5.Rows[0].ItemArray[0]);
							bool flag13 = num8 == 1;
							if (flag13)
							{
							}
							bool flag14 = num8 == 2;
							if (flag14)
							{
							}
							bool flag15 = num8 == 3;
							if (flag15)
							{
							}
							bool flag16 = num8 == 4;
							if (flag16)
							{
							}
							bool flag17 = num8 == 5;
							double num10;
							if (flag17)
							{
								num10 = 4200.0;
							}
							else
							{
								num10 = 7200.0;
							}
							bool flag18 = num9 != 0.0;
							if (flag18)
							{
								num10 = num9;
							}
							double num11 = num10 * num7;
							SqlCommand sqlCommand8 = new SqlCommand(cmdText7, bd.cnn);
							sqlCommand8.Parameters.Add("@t", SqlDbType.Real).Value = num11;
							sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = dataTable4.Rows[m].ItemArray[0].ToString();
							bd.ouverture_bd(bd.cnn);
							sqlCommand8.ExecuteNonQuery();
							bd.cnn.Close();
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
