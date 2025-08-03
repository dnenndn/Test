using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000BD RID: 189
	public partial class ot_general_detail : Form
	{
		// Token: 0x0600087C RID: 2172 RVA: 0x00169AAC File Offset: 0x00167CAC
		public ot_general_detail()
		{
			this.InitializeComponent();
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radCheckedDropDownList1.DropDownListElement.Popup.ToolTipTextNeeded += new ToolTipTextNeededEventHandler(this.Popup_ToolTipTextNeeded);
		}

		// Token: 0x0600087D RID: 2173 RVA: 0x00169B10 File Offset: 0x00167D10
		private void Popup_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
		{
			RadListVisualItem radListVisualItem = sender as RadListVisualItem;
			bool flag = radListVisualItem != null;
			if (flag)
			{
				e.ToolTipText = radListVisualItem.Text;
			}
		}

		// Token: 0x0600087E RID: 2174 RVA: 0x00169B3C File Offset: 0x00167D3C
		private void ot_general_detail_Load(object sender, EventArgs e)
		{
			this.select_priorite_ajout();
			this.select_etat_ajout();
			this.select_type_intervention_ajout();
			this.select_classe_intervention_ajout();
			this.select_centre_charge_ajout();
			this.select_superviseur_ajout();
			this.select_information1();
		}

		// Token: 0x0600087F RID: 2175 RVA: 0x00169B70 File Offset: 0x00167D70
		private void select_information1()
		{
			bd bd = new bd();
			string cmdText = "select n_ot, urgence, statut, type, parametre_classe_intervention.designation, intervenant.nom, intervenant.nom, date_debut, heure_debut, date_fin, heure_fin, debut_prevu, fin_prevu from ordre_travail left join parametre_classe_intervention on ordre_travail.id_classe = parametre_classe_intervention.id  left join intervenant on ordre_travail.id_superviseur = intervenant.id where ordre_travail.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.radDropDownList4.Text = dataTable.Rows[0].ItemArray[1].ToString();
				this.radDropDownList1.Text = dataTable.Rows[0].ItemArray[2].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[3].ToString();
				bool flag2 = Convert.ToString(dataTable.Rows[0].ItemArray[4].ToString()) != "";
				if (flag2)
				{
					int num = this.search_tag_raddropdown(dataTable.Rows[0].ItemArray[4].ToString(), this.radDropDownList3);
					this.radDropDownList3.Items[num].Selected = true;
				}
				bool flag3 = Convert.ToString(dataTable.Rows[0].ItemArray[6].ToString()) != "";
				if (flag3)
				{
					int num2 = this.search_tag_raddropdown(dataTable.Rows[0].ItemArray[6].ToString(), this.radDropDownList6);
					this.radDropDownList6.Items[num2].Selected = true;
				}
				this.radDateTimePicker1.Value = Convert.ToDateTime(dataTable.Rows[0].ItemArray[7]);
				this.radTimePicker1.Value = new DateTime?(Convert.ToDateTime(dataTable.Rows[0].ItemArray[8]));
				this.radDateTimePicker2.Value = Convert.ToDateTime(dataTable.Rows[0].ItemArray[9]);
				this.radTimePicker2.Value = new DateTime?(Convert.ToDateTime(dataTable.Rows[0].ItemArray[10]));
				this.radDateTimePicker4.Value = Convert.ToDateTime(fonction.Mid(dataTable.Rows[0].ItemArray[11].ToString(), 1, 10));
				this.radDateTimePicker3.Value = Convert.ToDateTime(fonction.Mid(dataTable.Rows[0].ItemArray[12].ToString(), 1, 10));
				this.radTimePicker4.Value = new DateTime?(Convert.ToDateTime(fonction.Mid(dataTable.Rows[0].ItemArray[11].ToString(), 12, 5)));
				this.radTimePicker3.Value = new DateTime?(Convert.ToDateTime(fonction.Mid(dataTable.Rows[0].ItemArray[12].ToString(), 12, 5)));
				string cmdText2 = "select id_centre_charge from ot_centre_charge where id_ot = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag4 = dataTable2.Rows.Count != 0;
				if (flag4)
				{
					for (int i = 0; i < dataTable2.Rows.Count; i++)
					{
						for (int j = 0; j < this.radCheckedDropDownList1.Items.Count; j++)
						{
							bool flag5 = dataTable2.Rows[i].ItemArray[0].ToString() == this.radCheckedDropDownList1.Items[j].Tag.ToString();
							if (flag5)
							{
								this.radCheckedDropDownList1.Items[j].Checked = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000880 RID: 2176 RVA: 0x00169FEC File Offset: 0x001681EC
		private void select_priorite_ajout()
		{
			this.radDropDownList4.Items.Clear();
			this.radDropDownList4.Items.Add("Elevée");
			this.radDropDownList4.Items.Add("Moyenne");
			this.radDropDownList4.Items.Add("Faible");
		}

		// Token: 0x06000881 RID: 2177 RVA: 0x0016A050 File Offset: 0x00168250
		private void select_etat_ajout()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("En Cours");
			this.radDropDownList1.Items.Add("En Préparation");
			this.radDropDownList1.Items.Add("Planifié");
			this.radDropDownList1.Items.Add("En Attente Arrêt Machine");
			this.radDropDownList1.Items.Add("Sous-Traitant à contacter");
			this.radDropDownList1.Items.Add("Clôturé");
			this.radDropDownList1.Items.Add("Annulé");
		}

		// Token: 0x06000882 RID: 2178 RVA: 0x0016A10C File Offset: 0x0016830C
		private void select_type_intervention_ajout()
		{
			this.radDropDownList5.Items.Clear();
			bd bd = new bd();
			string cmdText = "select type, id_di from ordre_travail where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.radDropDownList5.Items.Add("");
			this.radDropDownList5.Items[0].Tag = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string a = dataTable.Rows[0].ItemArray[0].ToString();
				bool flag2 = a == "Corrective Curative" | a == "Corrective Palliative" | a == "Travaux Neufs";
				if (flag2)
				{
					int num = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]);
					this.an_di = num;
					bool flag3 = num != 0;
					if (flag3)
					{
						string cmdText2 = "select n_di from demande_intervention where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = num;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						this.radDropDownList5.Items.Add(dataTable2.Rows[0].ItemArray[0].ToString());
						this.radDropDownList5.Items[1].Tag = num;
						this.select_di_ajout(num, 2);
						this.radDropDownList5.Items[1].Selected = true;
					}
					else
					{
						this.select_di_ajout(num, 1);
						this.radDropDownList5.Items[0].Selected = true;
					}
				}
				else
				{
					this.label5.Visible = false;
					this.radDropDownList5.Visible = false;
					this.radDropDownList5.Items[0].Selected = true;
				}
			}
		}

		// Token: 0x06000883 RID: 2179 RVA: 0x0016A360 File Offset: 0x00168560
		private void select_classe_intervention_ajout()
		{
			bd bd = new bd();
			this.radDropDownList3.Items.Clear();
			string cmdText = "select id, designation from parametre_classe_intervention";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList3.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList3.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000884 RID: 2180 RVA: 0x0016A44C File Offset: 0x0016864C
		private void select_centre_charge_ajout()
		{
			bd bd = new bd();
			this.radCheckedDropDownList1.Items.Clear();
			string cmdText = "select id, designation from parametre_centre_charge";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radCheckedDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000885 RID: 2181 RVA: 0x0016A538 File Offset: 0x00168738
		private void select_superviseur_ajout()
		{
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
			string cmdText = "select id, nom from intervenant where deleted = @d order by nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.radDropDownList6.Items.Add("");
			this.radDropDownList6.Items[0].Tag = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i + 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radDropDownList6.Items[0].Selected = true;
		}

		// Token: 0x06000886 RID: 2182 RVA: 0x0016A68C File Offset: 0x0016888C
		private int search_tag_raddropdown(string s, RadDropDownList r)
		{
			int result = -1;
			bool flag = r.Items.Count != 0;
			if (flag)
			{
				for (int i = 0; i < r.Items.Count; i++)
				{
					bool flag2 = r.Items[i].Text.ToString() == s;
					if (flag2)
					{
						result = i;
					}
				}
			}
			return result;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0016A6FC File Offset: 0x001688FC
		private void select_di_ajout(int id, int rg)
		{
			bd bd = new bd();
			string cmdText = "select id, n_di from demande_intervention where deleted = @d and (statut = @d or statut = @h) and id <> @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@h", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList5.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList5.Items[i + rg].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x0016A830 File Offset: 0x00168A30
		private void radButton1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			int hour = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker2.Value), 12, 2));
			int minute = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker2.Value), 15, 2));
			int hour2 = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker1.Value), 12, 2));
			int minute2 = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker1.Value), 15, 2));
			DateTime d = new DateTime(this.radDateTimePicker2.Value.Year, this.radDateTimePicker2.Value.Month, this.radDateTimePicker2.Value.Day, hour, minute, 0);
			DateTime d2 = new DateTime(this.radDateTimePicker1.Value.Year, this.radDateTimePicker1.Value.Month, this.radDateTimePicker1.Value.Day, hour2, minute2, 0);
			double totalMinutes = (d - d2).TotalMinutes;
			bool flag = totalMinutes > 0.0;
			if (flag)
			{
				this.reinitialiser_compteur();
				bd bd = new bd();
				string cmdText = "update ordre_travail set statut = @v1, id_classe = @v3, urgence = @v5, id_superviseur = @v6, id_di = @v7, date_debut = @d1, heure_debut = @h1, date_fin = @d2, heure_fin = @h2, debut_prevu = @p1, fin_prevu = @p2 where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				sqlCommand.Parameters.Add("@v3", SqlDbType.Int).Value = this.radDropDownList3.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@v5", SqlDbType.VarChar).Value = this.radDropDownList4.Text;
				sqlCommand.Parameters.Add("@v6", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@v7", SqlDbType.Int).Value = this.radDropDownList5.SelectedItem.Tag;
				sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				sqlCommand.Parameters.Add("@h1", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
				sqlCommand.Parameters.Add("@h2", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker2.Value.ToString(), 12, 5);
				sqlCommand.Parameters.Add("@p1", SqlDbType.DateTime).Value = fonction.Mid(this.radDateTimePicker4.Value.ToString(), 1, 10) + " " + fonction.Mid(this.radTimePicker4.Value.ToString(), 12, 5) + ":00";
				sqlCommand.Parameters.Add("@p2", SqlDbType.DateTime).Value = fonction.Mid(this.radDateTimePicker3.Value.ToString(), 1, 10) + " " + fonction.Mid(this.radTimePicker3.Value.ToString(), 12, 5) + ":00";
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = ot_liste.id_ot_tr;
				string cmdText2 = "update demande_intervention set statut = @d where id = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(this.radDropDownList5.SelectedItem.Tag);
				string cmdText3 = "delete ot_centre_charge where id_ot = @i";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				sqlCommand3.ExecuteNonQuery();
				bd.cnn.Close();
				List<string> list = new List<string>();
				list.Clear();
				for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
				{
					bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
					if (@checked)
					{
						list.Add(this.radCheckedDropDownList1.Items[i].Tag.ToString());
					}
				}
				bool flag2 = list.Count != 0;
				if (flag2)
				{
					for (int j = 0; j < list.Count; j++)
					{
						string cmdText4 = "insert into ot_centre_charge (id_ot, id_centre_charge) values (@i1, @i2)";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = list[j];
						bd.ouverture_bd(bd.cnn);
						sqlCommand4.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
				bool flag3 = ot_liste.type_ot_tr == "Corrective Curative" | ot_liste.type_ot_tr == "Corrective Palliative" | ot_liste.type_ot_tr == "Travaux Neufs";
				if (flag3)
				{
					bool flag4 = this.an_di != 0;
					if (flag4)
					{
						int num = Convert.ToInt32(this.radDropDownList5.SelectedItem.Tag);
						bool flag5 = this.an_di != num;
						if (flag5)
						{
							string cmdText5 = "select id from ordre_travail where id_di = @i and deleted  = @d";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = this.an_di;
							SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand5);
							DataTable dataTable = new DataTable();
							sqlDataAdapter.Fill(dataTable);
							bool flag6 = dataTable.Rows.Count == 0;
							if (flag6)
							{
								string cmdText6 = "update demande_intervention set statut = @d where id = @i";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
								sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
								sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = this.an_di;
								bd.ouverture_bd(bd.cnn);
								sqlCommand6.ExecuteNonQuery();
								bd.cnn.Close();
							}
						}
					}
				}
				MessageBox.Show("Modification avec succés");
				ot_liste.remplissage_tableau(2);
			}
			else
			{
				MessageBox.Show("Erreur :La Date de fin prévue doit être supérieure à la date de début prévue", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x0016AFD4 File Offset: 0x001691D4
		private void reinitialiser_compteur()
		{
			bool flag = this.radDropDownList1.Text == "Clôturé";
			if (flag)
			{
				bd bd = new bd();
				string type_ot_tr = ot_liste.type_ot_tr;
				bool flag2 = !type_ot_tr.Contains("Prév");
				if (flag2)
				{
					string cmdText = "select  organe, id_intervention, statut from ordre_travail where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
						int num = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
						int num2 = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]);
						string a = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
						bool flag4 = a != "Clôturé";
						if (flag4)
						{
							string cmdText2 = "select id_compteur from compteur_liaison where id_organe = @i1 and id_intervention = @i2";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = num2;
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag5 = dataTable2.Rows.Count != 0;
							if (flag5)
							{
								for (int i = 0; i < dataTable2.Rows.Count; i++)
								{
									int num3 = Convert.ToInt32(dataTable2.Rows[i].ItemArray[0]);
									string cmdText3 = "select initial from prev_compteur where id_compteur = @i and reinitialisation = @o and organe = @v";
									SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
									sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = num3;
									sqlCommand3.Parameters.Add("@v", SqlDbType.Int).Value = num;
									sqlCommand3.Parameters.Add("@o", SqlDbType.VarChar).Value = "Oui";
									SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
									DataTable dataTable3 = new DataTable();
									sqlDataAdapter3.Fill(dataTable3);
									bool flag6 = dataTable3.Rows.Count != 0;
									if (flag6)
									{
										double num4 = Convert.ToDouble(dataTable3.Rows[0].ItemArray[0]);
										string cmdText4 = "update equipement_compteur set valeur = @v where id = @i";
										SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
										sqlCommand4.Parameters.Add("@v", SqlDbType.Real).Value = num4;
										sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = num3;
										bd.ouverture_bd(bd.cnn);
										sqlCommand4.ExecuteNonQuery();
										bd.cnn.Close();
									}
								}
							}
						}
					}
				}
				else
				{
					string cmdText5 = "select id_prev_compteur from ot_reinit_compteur where id_ot = @i";
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
					sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand5);
					DataTable dataTable4 = new DataTable();
					sqlDataAdapter4.Fill(dataTable4);
					bool flag7 = dataTable4.Rows.Count != 0;
					if (flag7)
					{
						int num5 = Convert.ToInt32(dataTable4.Rows[0].ItemArray[0]);
						string cmdText6 = "select initial, id_compteur from prev_compteur where id = @i and reinitialisation = @o";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = num5;
						sqlCommand6.Parameters.Add("@o", SqlDbType.VarChar).Value = "Oui";
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand6);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter5.Fill(dataTable5);
						bool flag8 = dataTable5.Rows.Count != 0;
						if (flag8)
						{
							double num6 = Convert.ToDouble(dataTable5.Rows[0].ItemArray[0]);
							int num7 = Convert.ToInt32(dataTable5.Rows[0].ItemArray[1]);
							string cmdText7 = "update equipement_compteur set valeur = @v where id = @i";
							SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
							sqlCommand7.Parameters.Add("@v", SqlDbType.Real).Value = num6;
							sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = num7;
							bd.ouverture_bd(bd.cnn);
							string cmdText8 = "delete ot_reinit_compteur where id_prev_compteur = @i1";
							SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd.cnn);
							sqlCommand8.Parameters.Add("@i1", SqlDbType.Int).Value = num5;
							sqlCommand7.ExecuteNonQuery();
							sqlCommand8.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x04000B8C RID: 2956
		private int an_di = 0;
	}
}
