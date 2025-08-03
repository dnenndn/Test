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
	// Token: 0x02000078 RID: 120
	public partial class gamme_general : Form
	{
		// Token: 0x06000588 RID: 1416 RVA: 0x000E89A4 File Offset: 0x000E6BA4
		public gamme_general()
		{
			this.InitializeComponent();
			this.radCheckedDropDownList1.DropDownListElement.Popup.ToolTipTextNeeded += new ToolTipTextNeededEventHandler(this.Popup_ToolTipTextNeeded);
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x000E8A04 File Offset: 0x000E6C04
		private void Popup_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
		{
			RadListVisualItem radListVisualItem = sender as RadListVisualItem;
			bool flag = radListVisualItem != null;
			if (flag)
			{
				e.ToolTipText = radListVisualItem.Text;
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x000E8A30 File Offset: 0x000E6C30
		private void gamme_general_Load(object sender, EventArgs e)
		{
			this.select_priorite_ajout();
			this.select_etat_ajout();
			this.select_type_intervention_ajout();
			this.select_classe_intervention_ajout();
			this.select_centre_charge_ajout();
			this.select_superviseur_ajout();
			this.select_information1();
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x000E8A64 File Offset: 0x000E6C64
		private void select_information1()
		{
			bd bd = new bd();
			string cmdText = "select gamme_operatoire.code, urgence, statut, type, parametre_classe_intervention.designation, intervenant.nom, plan_maintenance.designation, gamme_operatoire.designation, duree, var_duree from gamme_operatoire left join parametre_classe_intervention on gamme_operatoire.id_classe = parametre_classe_intervention.id left join intervenant on gamme_operatoire.id_superviseur = intervenant.id inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where gamme_operatoire.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radDropDownList5.Items.Add(dataTable.Rows[0].ItemArray[6].ToString());
				this.radDropDownList5.Text = dataTable.Rows[0].ItemArray[6].ToString();
				this.TextBox1.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.radDropDownList4.Text = dataTable.Rows[0].ItemArray[1].ToString();
				this.radDropDownList1.Text = dataTable.Rows[0].ItemArray[2].ToString();
				this.TextBox2.Text = dataTable.Rows[0].ItemArray[3].ToString();
				this.guna2TextBox1.Text = dataTable.Rows[0].ItemArray[7].ToString();
				this.guna2TextBox7.Text = dataTable.Rows[0].ItemArray[8].ToString();
				string b = dataTable.Rows[0].ItemArray[9].ToString();
				foreach (object obj in this.panel6.Controls)
				{
					RadRadioButton radRadioButton = (RadRadioButton)obj;
					bool flag2 = radRadioButton.Text == b;
					if (flag2)
					{
						radRadioButton.IsChecked = true;
					}
				}
				bool flag3 = Convert.ToString(dataTable.Rows[0].ItemArray[4].ToString()) != "";
				if (flag3)
				{
					int num = this.search_tag_raddropdown(dataTable.Rows[0].ItemArray[4].ToString(), this.radDropDownList3);
					this.radDropDownList3.Items[num].Selected = true;
				}
				string cmdText2 = "select id_centre_charge from gamme_centre_charge where id_gamme = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
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
				bool flag6 = Convert.ToString(dataTable.Rows[0].ItemArray[5].ToString()) != "";
				if (flag6)
				{
					int num2 = this.search_tag_raddropdown(dataTable.Rows[0].ItemArray[5].ToString(), this.radDropDownList6);
					this.radDropDownList6.Items[num2].Selected = true;
				}
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x000E8E94 File Offset: 0x000E7094
		private void select_priorite_ajout()
		{
			this.radDropDownList4.Items.Clear();
			this.radDropDownList4.Items.Add("Elevée");
			this.radDropDownList4.Items.Add("Moyenne");
			this.radDropDownList4.Items.Add("Faible");
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x000E8EF8 File Offset: 0x000E70F8
		private void select_etat_ajout()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("En Cours");
			this.radDropDownList1.Items.Add("En Préparation");
			this.radDropDownList1.Items.Add("Planifié");
			this.radDropDownList1.Items.Add("En Attente Arrêt Machine");
			this.radDropDownList1.Items.Add("Sous-Traitant à contacter");
			this.radDropDownList1.Items.Add("Annulé");
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x000E8F9C File Offset: 0x000E719C
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
						this.radDropDownList5.Items[1].Selected = true;
					}
					else
					{
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

		// Token: 0x0600058F RID: 1423 RVA: 0x000E91D4 File Offset: 0x000E73D4
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

		// Token: 0x06000590 RID: 1424 RVA: 0x000E92C0 File Offset: 0x000E74C0
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

		// Token: 0x06000591 RID: 1425 RVA: 0x000E93AC File Offset: 0x000E75AC
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

		// Token: 0x06000592 RID: 1426 RVA: 0x000E9500 File Offset: 0x000E7700
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

		// Token: 0x06000593 RID: 1427 RVA: 0x000E9570 File Offset: 0x000E7770
		private void radButton1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			string value = "";
			foreach (object obj in this.panel6.Controls)
			{
				RadRadioButton radRadioButton = (RadRadioButton)obj;
				bool isChecked = radRadioButton.IsChecked;
				if (isChecked)
				{
					value = radRadioButton.Text;
				}
			}
			bool flag = fonction.DeleteSpace(this.guna2TextBox1.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.isnumeric(this.guna2TextBox7.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.guna2TextBox7.Text) > 0;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "update gamme_operatoire set statut = @v1, id_classe = @v3, urgence = @v5, id_superviseur = @v6, designation = @v7, duree = @v8, var_duree = @v9, code = @v10 where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
						sqlCommand.Parameters.Add("@v3", SqlDbType.Int).Value = this.radDropDownList3.SelectedItem.Tag;
						sqlCommand.Parameters.Add("@v5", SqlDbType.VarChar).Value = this.radDropDownList4.Text;
						sqlCommand.Parameters.Add("@v6", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
						sqlCommand.Parameters.Add("@v7", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand.Parameters.Add("@v8", SqlDbType.Int).Value = this.guna2TextBox7.Text;
						sqlCommand.Parameters.Add("@v9", SqlDbType.VarChar).Value = value;
						sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = liste_gamme_operatoire.id_gamme;
						sqlCommand.Parameters.Add("@v10", SqlDbType.VarChar).Value = this.TextBox1.Text;
						string cmdText2 = "delete gamme_centre_charge where id_gamme = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						sqlCommand2.ExecuteNonQuery();
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
						bool flag4 = list.Count != 0;
						if (flag4)
						{
							for (int j = 0; j < list.Count; j++)
							{
								string cmdText3 = "insert into gamme_centre_charge (id_gamme, id_centre_charge) values (@i1, @i2)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = list[j];
								bd.ouverture_bd(bd.cnn);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
							}
						}
						MessageBox.Show("Modification avec succés");
						liste_gamme_operatoire.remplissage_tableau(2);
					}
					else
					{
						MessageBox.Show("Erreur :Durée estimée doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :Durée estimée doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Veuillez choisir la description de la gamme opératoire", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
