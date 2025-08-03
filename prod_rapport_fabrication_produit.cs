using System;
using System.Collections.Generic;
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
	// Token: 0x02000117 RID: 279
	public partial class prod_rapport_fabrication_produit : Form
	{
		// Token: 0x06000C57 RID: 3159 RVA: 0x001E17F8 File Offset: 0x001DF9F8
		public prod_rapport_fabrication_produit()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.CellValueChanged += new GridViewCellEventHandler(this.RadGridView2_CellValueChanged);
		}

		// Token: 0x06000C58 RID: 3160 RVA: 0x001E1894 File Offset: 0x001DFA94
		private void RadGridView2_CellValueChanged(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 2;
				if (flag2)
				{
					bd bd = new bd();
					string value = this.radGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
					string cmdText = "select id from prod_type_brique where designation = @d";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@d", SqlDbType.VarChar).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					int num = 0;
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
						num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
					}
					this.radGridView2.Rows[e.RowIndex].Cells[0].Value = num;
				}
			}
		}

		// Token: 0x06000C59 RID: 3161 RVA: 0x001E19A5 File Offset: 0x001DFBA5
		private void prod_rapport_fabrication_produit_Load(object sender, EventArgs e)
		{
			this.ajout_combo();
			this.select_produit();
			this.remplissage_tabl2();
			this.select_heure();
		}

		// Token: 0x06000C5A RID: 3162 RVA: 0x001E19C4 File Offset: 0x001DFBC4
		private void select_produit()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select prod_rapport_fab_produit.id,id_produit, prod_type_brique.designation, quantite from prod_rapport_fab_produit inner join prod_type_brique on prod_rapport_fab_produit.id_produit = prod_type_brique.id where id_rapport = @i1 and id_unite = @i2";
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
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
			}
		}

		// Token: 0x06000C5B RID: 3163 RVA: 0x001E1B24 File Offset: 0x001DFD24
		private double somme_ancien_tonnage()
		{
			double result = 0.0;
			bd bd = new bd();
			string cmdText = "select valeur from prod_fab_tonnage where id_rapport = @i1 and id_unite = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			fonction fonction = new fonction();
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = fonction.is_reel(dataTable.Rows[0].ItemArray[0].ToString());
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000C5C RID: 3164 RVA: 0x001E1C18 File Offset: 0x001DFE18
		private double avg_poid(int id_p)
		{
			int num = 0;
			bd bd = new bd();
			string cmdText = "select id from prod_saisie where poid_sec_fab = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());
			}
			string cmdText2 = "select heure from prod_rapport_heure where id_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
			sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = id_p;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			int num2 = dataTable2.Rows.Count;
			string cmdText3 = "select h1, h2, h3, h4, h5, h6, h7, h8 from prod_rapport_horaire_fabrication where id_rapport = @i1 and id_unite = @i2 and id_qualite = @i3";
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
			sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = num;
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			double num3 = 0.0;
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					int num4 = Convert.ToInt32(dataTable2.Rows[i].ItemArray[0]) - 1;
					num3 += Convert.ToDouble(dataTable3.Rows[0].ItemArray[num4]);
					bool flag3 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[num4]) == 0.0;
					if (flag3)
					{
						num2--;
					}
				}
			}
			bool flag4 = id_p == 1;
			if (flag4)
			{
			}
			bool flag5 = id_p == 2;
			if (flag5)
			{
			}
			bool flag6 = id_p == 3;
			if (flag6)
			{
			}
			bool flag7 = id_p == 4;
			if (flag7)
			{
			}
			bool flag8 = id_p == 5;
			double result;
			if (flag8)
			{
				result = 4200.0;
			}
			else
			{
				result = 7200.0;
			}
			bool flag9 = num2 != 0;
			if (flag9)
			{
				result = num3 / (double)num2;
			}
			return result;
		}

		// Token: 0x06000C5D RID: 3165 RVA: 0x001E1F54 File Offset: 0x001E0154
		private double calcul_nv_tonnage()
		{
			double num = 0.0;
			int num2 = 0;
			bd bd = new bd();
			string cmdText = "select id from prod_saisie where poid_sec_fab = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 1;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				num2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0].ToString());
			}
			for (int i = 0; i < this.radGridView1.Rows.Count; i++)
			{
				int num3 = Convert.ToInt32(this.radGridView1.Rows[i].Cells[1].Value);
				double num4 = Convert.ToDouble(this.radGridView1.Rows[i].Cells[3].Value);
				string cmdText2 = "select heure from prod_rapport_heure where id_rapport = @i1 and id_unite = @i2 and id_produit = @i3";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
				sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
				sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = num3;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				int num5 = dataTable2.Rows.Count;
				string cmdText3 = "select h1, h2, h3, h4, h5, h6, h7, h8 from prod_rapport_horaire_fabrication where id_rapport = @i1 and id_unite = @i2 and id_qualite = @i3";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
				sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
				sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = num2;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				double num6 = 0.0;
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						int num7 = Convert.ToInt32(dataTable2.Rows[j].ItemArray[0]) - 1;
						num6 += Convert.ToDouble(dataTable3.Rows[0].ItemArray[num7]);
						bool flag3 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[num7]) == 0.0;
						if (flag3)
						{
							num5--;
						}
					}
				}
				bool flag4 = num3 == 1;
				if (flag4)
				{
				}
				bool flag5 = num3 == 2;
				if (flag5)
				{
				}
				bool flag6 = num3 == 3;
				if (flag6)
				{
				}
				bool flag7 = num3 == 4;
				if (flag7)
				{
				}
				bool flag8 = num3 == 5;
				double num8;
				if (flag8)
				{
					num8 = 4200.0;
				}
				else
				{
					num8 = 7200.0;
				}
				bool flag9 = num5 != 0;
				if (flag9)
				{
					num8 = num6 / (double)num5;
				}
				string cmdText4 = "select designation from prod_type_brique where id = @i";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = num3;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				string s = " ";
				bool flag10 = dataTable4.Rows.Count != 0;
				if (flag10)
				{
					s = Convert.ToString(dataTable4.Rows[0].ItemArray[0]);
				}
				double num9 = fonction.tonnage_wagon(s);
				num += num4 * num9 * num8;
			}
			return num;
		}

		// Token: 0x06000C5E RID: 3166 RVA: 0x001E23B0 File Offset: 0x001E05B0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				int num = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[3].Value));
					if (flag2)
					{
						num = 0;
					}
					else
					{
						bool flag3 = Convert.ToDouble(this.radGridView1.Rows[i].Cells[3].Value) < 0.0;
						if (flag3)
						{
							num = 0;
						}
					}
				}
				bool flag4 = num == 1;
				if (flag4)
				{
					int num2 = 1;
					for (int j = 0; j < this.radGridView2.Rows.Count; j++)
					{
						int num3 = Convert.ToInt32(this.radGridView2.Rows[j].Cells[0].Value);
						bool flag5 = num3 == 0;
						if (flag5)
						{
							num2 = 0;
						}
					}
					bool flag6 = num2 == 1;
					if (flag6)
					{
						bd bd = new bd();
						string cmdText = "delete prod_rapport_heure where id_rapport = @i1 and id_unite = @i2";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						for (int k = 0; k < this.radGridView2.Rows.Count; k++)
						{
							int num4 = Convert.ToInt32(this.radGridView2.Rows[k].Cells[0].Value);
							string cmdText2 = "insert into prod_rapport_heure (id_rapport, id_unite, heure, id_produit) values(@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = k + 1;
							sqlCommand2.Parameters.Add("@i4", SqlDbType.Int).Value = num4;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
						double num5 = this.calcul_nv_tonnage();
						num5 *= 1.1;
						double num6 = this.somme_ancien_tonnage();
						for (int l = 0; l < this.radGridView1.Rows.Count; l++)
						{
							double num7 = fonction.tonnage_wagon(this.radGridView1.Rows[l].Cells[2].Value.ToString());
							double num8 = num7 * Convert.ToDouble(this.radGridView1.Rows[l].Cells[3].Value) * this.avg_poid(Convert.ToInt32(this.radGridView1.Rows[l].Cells[1].Value));
							string cmdText3 = "update prod_rapport_fab_produit set quantite = @q, tonnage = @t where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[l].Cells[0].Value;
							sqlCommand3.Parameters.Add("@q", SqlDbType.Real).Value = this.radGridView1.Rows[l].Cells[3].Value;
							sqlCommand3.Parameters.Add("@t", SqlDbType.Real).Value = num8 * 1.1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
						string cmdText4 = "update prod_fab_tonnage set valeur = @v where id_rapport = @i1 and id_unite = @i2";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
						sqlCommand4.Parameters.Add("@v", SqlDbType.Real).Value = num5;
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText5 = "select id_compteur from prod_fab_compteur where id_unite = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag7 = dataTable.Rows.Count != 0;
						if (flag7)
						{
							for (int m = 0; m < dataTable.Rows.Count; m++)
							{
								bool flag8 = num5 != num6;
								if (flag8)
								{
									string cmdText6 = "insert into equipement_compteur_historique (id_compteur, valeur, date_mesure) values (@v1, @v2, @v3)";
									SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
									sqlCommand6.Parameters.Add("@v1", SqlDbType.Int).Value = dataTable.Rows[m].ItemArray[0].ToString();
									sqlCommand6.Parameters.Add("@v2", SqlDbType.Real).Value = num5;
									sqlCommand6.Parameters.Add("@v3", SqlDbType.Date).Value = DateTime.Today;
									string cmdText7 = "update equipement_compteur set valeur = valeur + @v where id = @i";
									SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
									sqlCommand7.Parameters.Add("@v", SqlDbType.Real).Value = num5 - num6;
									sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[m].ItemArray[0].ToString();
									bd.ouverture_bd(bd.cnn);
									bd.cnn.Close();
									double num9 = 0.0;
									string cmdText8 = "select valeur from equipement_compteur where id = @v";
									SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
									sqlCommand8.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[m].ItemArray[0].ToString();
									SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand8);
									DataTable dataTable2 = new DataTable();
									sqlDataAdapter2.Fill(dataTable2);
									bool flag9 = dataTable2.Rows.Count != 0;
									if (flag9)
									{
										num9 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]);
									}
									string cmdText9 = "insert into equipement_compteur_nv (id_compteur, valeur, date_nv) values (@v1, @v2, @v3)";
									SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd.cnn);
									sqlCommand9.Parameters.Add("@v1", SqlDbType.Int).Value = dataTable.Rows[m].ItemArray[0].ToString();
									sqlCommand9.Parameters.Add("@v2", SqlDbType.Real).Value = num9 + num5 - num6;
									sqlCommand9.Parameters.Add("@v3", SqlDbType.Date).Value = DateTime.Today;
									bd.ouverture_bd(bd.cnn);
									sqlCommand9.ExecuteNonQuery();
									sqlCommand6.ExecuteNonQuery();
									sqlCommand7.ExecuteNonQuery();
									bd.cnn.Close();
									lancement_ot_preventive.creation_ot_compteur(Convert.ToInt32(dataTable.Rows[m].ItemArray[0].ToString()));
								}
							}
						}
						MessageBox.Show("Modification avec succés");
					}
					else
					{
						MessageBox.Show("Erreur : Associer chaque Heure d'échantillonnage à un produit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier la quantité de chaque produit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Vérifier la quantité de chaque produit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000C5F RID: 3167 RVA: 0x001E2C84 File Offset: 0x001E0E84
		private void remplissage_tabl2()
		{
			this.radGridView2.Rows.Clear();
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H1"
			});
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H2"
			});
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H3"
			});
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H4"
			});
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H5"
			});
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H6"
			});
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H7"
			});
			this.radGridView2.Rows.Add(new object[]
			{
				0,
				"H8"
			});
		}

		// Token: 0x06000C60 RID: 3168 RVA: 0x001E2DE4 File Offset: 0x001E0FE4
		private void ajout_combo()
		{
			List<string> list = new List<string>();
			bd bd = new bd();
			string cmdText = "select designation from prod_type_brique";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					list.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
				foreach (GridViewColumn gridViewColumn in this.radGridView2.Columns)
				{
					bool flag2 = gridViewColumn is GridViewComboBoxColumn;
					if (flag2)
					{
						GridViewComboBoxColumn gridViewComboBoxColumn = new GridViewComboBoxColumn();
						gridViewComboBoxColumn = (GridViewComboBoxColumn)gridViewColumn;
						gridViewComboBoxColumn.DataSource = list;
					}
				}
			}
		}

		// Token: 0x06000C61 RID: 3169 RVA: 0x001E2EFC File Offset: 0x001E10FC
		private void select_heure()
		{
			bd bd = new bd();
			string cmdText = "select heure, id_produit, prod_type_brique.designation from prod_rapport_heure inner join prod_type_brique on id_produit = prod_type_brique.id where id_rapport = @i1 and id_unite = @i2";
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
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					this.radGridView2.Rows[num - 1].Cells[0].Value = dataTable.Rows[i].ItemArray[1].ToString();
					this.radGridView2.Rows[num - 1].Cells[2].Value = dataTable.Rows[i].ItemArray[2].ToString();
				}
			}
		}
	}
}
