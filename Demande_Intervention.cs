using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Gauges;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000064 RID: 100
	public partial class Demande_Intervention : Form
	{
		// Token: 0x060004A7 RID: 1191 RVA: 0x000C568C File Offset: 0x000C388C
		public Demande_Intervention()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			Demande_Intervention.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(Demande_Intervention.select_change);
			Demande_Intervention.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(Demande_Intervention.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(Demande_Intervention.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(Demande_Intervention.select_changee);
			Demande_Intervention.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(Demande_Intervention.select_change);
			Demande_Intervention.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(Demande_Intervention.select_changee);
			Demande_Intervention.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
			Demande_Intervention.radGridView2.CellClick += new GridViewCellEventHandler(this.action_tableau_2);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau_3);
			this.label26.Text = "";
			this.pictureBox3.Hide();
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker4.Value = value;
			this.radDateTimePicker3.Value = value.AddMonths(1).AddDays(-1.0);
			Demande_Intervention.id_eq_filtre.Clear();
			Demande_Intervention.id_eq_filtre.Add(-1);
			this.select_demandeur_filtre();
			this.select_urgence_filtre();
			this.select_createur_filtre();
			this.select_defaillance_filtre();
			this.remplissage_tableau(0);
		}

		// Token: 0x060004A8 RID: 1192 RVA: 0x000C5854 File Offset: 0x000C3A54
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x060004A9 RID: 1193 RVA: 0x000C58D8 File Offset: 0x000C3AD8
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = Color.Firebrick;
				}
				else
				{
					e.RowElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.RowElement.ResetValue(VisualElement.BackColorProperty);
					e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty);
					e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x060004AA RID: 1194 RVA: 0x000C59DC File Offset: 0x000C3BDC
		private void panel8_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 900, 1);
		}

		// Token: 0x060004AB RID: 1195 RVA: 0x000C5A18 File Offset: 0x000C3C18
		private void Demande_Intervention_Load(object sender, EventArgs e)
		{
			this.panel4.Visible = false;
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radDateTimePicker2.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			this.radTimePicker2.Value = new DateTime?(DateTime.Now);
			this.radGridView1.Columns[8].IsVisible = false;
			this.radGridView1.Columns[9].IsVisible = false;
			this.radGridView1.Columns[10].IsVisible = false;
			this.radGridView1.Columns[11].IsVisible = false;
			this.radGridView1.Columns[13].IsVisible = false;
			this.radGridView1.Columns[14].IsVisible = false;
			this.radGridView1.Columns[15].IsVisible = false;
			this.radGridView1.Columns[16].IsVisible = false;
			this.radGridView1.Columns[17].IsVisible = false;
			this.radGridView1.Columns[18].IsVisible = false;
			this.radGridView1.Columns[19].IsVisible = false;
			this.remplissage_grid_equipement();
			this.select_demandeur_ajout();
			this.select_urgence_ajout();
			this.select_defaillance_ajout();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.statut_formatting);
		}

		// Token: 0x060004AC RID: 1196 RVA: 0x000C5BC8 File Offset: 0x000C3DC8
		private void remplissage_grid_equipement()
		{
			Demande_Intervention.radGridView3.Rows.Clear();
			Demande_Intervention.radGridView3.Rows.Add(new object[]
			{
				"Atelier"
			});
			Demande_Intervention.radGridView3.Rows.Add(new object[]
			{
				"Equipement *"
			});
			Demande_Intervention.radGridView3.Rows.Add(new object[]
			{
				"Sous Equipement"
			});
			Demande_Intervention.radGridView3.Rows.Add(new object[]
			{
				"Organe"
			});
			for (int i = 0; i < 4; i++)
			{
				Demande_Intervention.radGridView3.Rows[i].Cells[4].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
			}
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x000C5C98 File Offset: 0x000C3E98
		private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.panel4.Visible = false;
			}
			else
			{
				this.panel4.Visible = true;
			}
		}

		// Token: 0x060004AE RID: 1198 RVA: 0x000C5CD8 File Offset: 0x000C3ED8
		private void label4_Click(object sender, EventArgs e)
		{
			bool visible = this.panel2.Visible;
			if (visible)
			{
				this.panel2.Visible = false;
			}
			else
			{
				this.panel2.Visible = true;
			}
		}

		// Token: 0x060004AF RID: 1199 RVA: 0x000C5D18 File Offset: 0x000C3F18
		private void panel6_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 972, 1);
		}

		// Token: 0x060004B0 RID: 1200 RVA: 0x000C5D54 File Offset: 0x000C3F54
		private void label11_Click(object sender, EventArgs e)
		{
			bool visible = this.panel7.Visible;
			if (visible)
			{
				this.panel7.Visible = false;
			}
			else
			{
				this.panel7.Visible = true;
			}
		}

		// Token: 0x060004B1 RID: 1201 RVA: 0x000C5D94 File Offset: 0x000C3F94
		private void select_demandeur_ajout()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select id, nom from intervenant where deleted = @d order by nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x060004B2 RID: 1202 RVA: 0x000C5E9C File Offset: 0x000C409C
		private void select_demandeur_filtre()
		{
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
			this.radDropDownList6.Items.Add("");
			this.radDropDownList6.Items[0].Tag = 0;
			string cmdText = "select id, nom from intervenant where deleted = @d order by nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
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

		// Token: 0x060004B3 RID: 1203 RVA: 0x000C5FF0 File Offset: 0x000C41F0
		private void select_urgence_ajout()
		{
			this.radDropDownList2.Items.Clear();
			this.radDropDownList2.Items.Add("Elevée");
			this.radDropDownList2.Items.Add("Moyenne");
			this.radDropDownList2.Items.Add("Faible");
		}

		// Token: 0x060004B4 RID: 1204 RVA: 0x000C6054 File Offset: 0x000C4254
		private void select_urgence_filtre()
		{
			this.radDropDownList5.Items.Clear();
			this.radDropDownList5.Items.Add("");
			this.radDropDownList5.Items.Add("Elevée");
			this.radDropDownList5.Items.Add("Moyenne");
			this.radDropDownList5.Items.Add("Faible");
		}

		// Token: 0x060004B5 RID: 1205 RVA: 0x000C60CC File Offset: 0x000C42CC
		private void select_createur_filtre()
		{
			bd bd = new bd();
			this.radDropDownList7.Items.Clear();
			this.radDropDownList7.Items.Add("");
			this.radDropDownList7.Items[0].Tag = 0;
			string cmdText = "select id, login from utilisateur where deleted = @d order by login";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList7.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList7.Items[i + 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radDropDownList7.Items[0].Selected = true;
		}

		// Token: 0x060004B6 RID: 1206 RVA: 0x000C6220 File Offset: 0x000C4420
		private void select_defaillance_ajout()
		{
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.DropDownHeight = 200;
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.DropDownWidth = 600;
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows.Clear();
			string cmdText = "select code, anomalie, id from parametre_anomalie where deleted = @d order by code";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
			}
			this.radMultiColumnComboBox1.SelectedItem = null;
		}

		// Token: 0x060004B7 RID: 1207 RVA: 0x000C6380 File Offset: 0x000C4580
		private void select_defaillance_filtre()
		{
			this.radCheckedDropDownList1.Items.Clear();
			string cmdText = "select code, id from parametre_anomalie where deleted = @d order by code";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radCheckedDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					this.radCheckedDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[1].ToString();
				}
			}
		}

		// Token: 0x060004B8 RID: 1208 RVA: 0x000C6488 File Offset: 0x000C4688
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			Demande_Intervention.insr_or_filtre = "insr";
			Equipement_di equipement_di = new Equipement_di();
			equipement_di.Show();
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x000C64B0 File Offset: 0x000C46B0
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 4;
			if (flag)
			{
				Demande_Intervention.radGridView3.Rows[e.RowIndex].Cells[1].Value = "";
				Demande_Intervention.radGridView3.Rows[e.RowIndex].Cells[2].Value = "";
				Demande_Intervention.radGridView3.Rows[e.RowIndex].Cells[3].Value = "";
			}
		}

		// Token: 0x060004BA RID: 1210 RVA: 0x000C6560 File Offset: 0x000C4760
		private void action_tableau_2(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 3;
			if (flag)
			{
				int index = e.RowIndex + 1;
				Demande_Intervention.id_eq_filtre.RemoveAt(index);
				Demande_Intervention.radGridView2.Rows.RemoveAt(e.RowIndex);
			}
		}

		// Token: 0x060004BB RID: 1211 RVA: 0x000C65B4 File Offset: 0x000C47B4
		private void action_tableau_3(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 18;
			if (flag)
			{
				string a = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
				string value = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
				bool flag2 = a == "En Attente" | a == "Annulée";
				if (flag2)
				{
					Demande_Intervention.row_act = e.RowIndex;
					this.panel2.Visible = true;
					this.panel2.Focus();
					this.id_modifier = Convert.ToInt32(value);
					this.guna2Button1.Text = "Modifier";
					this.label4.Text = "Modifier Demande Intervention";
					int num = this.search_tag_raddropdown(this.radGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), this.radDropDownList1);
					this.radDropDownList1.Items[num].Selected = true;
					this.radDateTimePicker1.Value = Convert.ToDateTime(this.radGridView1.Rows[e.RowIndex].Cells[5].Value);
					this.radTimePicker1.Value = new DateTime?(Convert.ToDateTime(this.radGridView1.Rows[e.RowIndex].Cells[6].Value.ToString()));
					bd bd = new bd();
					string cmdText = "select urgence, parametre_anomalie.code, description_defaillance, atelier, equipement, sous_equipement, organe, date_arret, heure_arret, arret_machine from demande_intervention inner join parametre_anomalie on demande_intervention.id_defaillance = parametre_anomalie.id where demande_intervention.id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					this.pictureBox3.Show();
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
						int num2 = this.search_tag_raddropdown(dataTable.Rows[0].ItemArray[0].ToString(), this.radDropDownList2);
						this.radDropDownList2.Items[num2].Selected = true;
						int selectedIndex = this.search_tag_combogrid(dataTable.Rows[0].ItemArray[1].ToString(), this.radMultiColumnComboBox1);
						this.radMultiColumnComboBox1.SelectedIndex = selectedIndex;
						this.guna2TextBox1.Text = dataTable.Rows[0].ItemArray[2].ToString();
						this.radDateTimePicker2.Value = Convert.ToDateTime(dataTable.Rows[0].ItemArray[7].ToString());
						this.radTimePicker2.Value = new DateTime?(Convert.ToDateTime(dataTable.Rows[0].ItemArray[8].ToString()));
						bool flag4 = dataTable.Rows[0].ItemArray[9].ToString() == "Oui";
						if (flag4)
						{
							this.radRadioButton2.IsChecked = true;
						}
						else
						{
							this.radRadioButton1.IsChecked = true;
						}
						this.remplissage_grid_equipement();
						bool flag5 = dataTable.Rows[0].ItemArray[3].ToString() != "0";
						if (flag5)
						{
							string cmdText2 = "select id, code, designation from equipement where id = @i";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[3].ToString();
							SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
							DataTable dataTable2 = new DataTable();
							sqlDataAdapter2.Fill(dataTable2);
							bool flag6 = dataTable2.Rows.Count != 0;
							if (flag6)
							{
								Demande_Intervention.radGridView3.Rows[0].Cells[1].Value = dataTable2.Rows[0].ItemArray[0].ToString();
								Demande_Intervention.radGridView3.Rows[0].Cells[2].Value = dataTable2.Rows[0].ItemArray[1].ToString();
								Demande_Intervention.radGridView3.Rows[0].Cells[3].Value = dataTable2.Rows[0].ItemArray[2].ToString();
							}
						}
						bool flag7 = dataTable.Rows[0].ItemArray[4].ToString() != "0";
						if (flag7)
						{
							string cmdText3 = "select id, code, designation from equipement where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[4].ToString();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter3.Fill(dataTable3);
							bool flag8 = dataTable3.Rows.Count != 0;
							if (flag8)
							{
								Demande_Intervention.radGridView3.Rows[1].Cells[1].Value = dataTable3.Rows[0].ItemArray[0].ToString();
								Demande_Intervention.radGridView3.Rows[1].Cells[2].Value = dataTable3.Rows[0].ItemArray[1].ToString();
								Demande_Intervention.radGridView3.Rows[1].Cells[3].Value = dataTable3.Rows[0].ItemArray[2].ToString();
							}
						}
						bool flag9 = dataTable.Rows[0].ItemArray[5].ToString() != "0";
						if (flag9)
						{
							string cmdText4 = "select id, code, designation from equipement where id = @i";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[5].ToString();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							bool flag10 = dataTable4.Rows.Count != 0;
							if (flag10)
							{
								Demande_Intervention.radGridView3.Rows[2].Cells[1].Value = dataTable4.Rows[0].ItemArray[0].ToString();
								Demande_Intervention.radGridView3.Rows[2].Cells[2].Value = dataTable4.Rows[0].ItemArray[1].ToString();
								Demande_Intervention.radGridView3.Rows[2].Cells[3].Value = dataTable4.Rows[0].ItemArray[2].ToString();
							}
						}
						bool flag11 = dataTable.Rows[0].ItemArray[6].ToString() != "0";
						if (flag11)
						{
							string cmdText5 = "select id, code, designation from equipement where id = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[6].ToString();
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter5.Fill(dataTable5);
							bool flag12 = dataTable5.Rows.Count != 0;
							if (flag12)
							{
								Demande_Intervention.radGridView3.Rows[3].Cells[1].Value = dataTable5.Rows[0].ItemArray[0].ToString();
								Demande_Intervention.radGridView3.Rows[3].Cells[2].Value = dataTable5.Rows[0].ItemArray[1].ToString();
								Demande_Intervention.radGridView3.Rows[3].Cells[3].Value = dataTable5.Rows[0].ItemArray[2].ToString();
							}
						}
					}
				}
				bool flag13 = a == "Clôturée";
				if (flag13)
				{
					MessageBox.Show("Erreur : Impossible de modifier une demande d'intervention clôturée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				bool flag14 = a == "Validée";
				if (flag14)
				{
					MessageBox.Show("Erreur : Impossible de modifier une demande d'intervention validée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool flag15 = e.RowIndex >= 0 && e.ColumnIndex == 19;
			if (flag15)
			{
				string a2 = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
				string value2 = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
				bool flag16 = a2 == "En Attente" | a2 == "Annulée";
				if (flag16)
				{
					Demande_Intervention.row_act = e.RowIndex;
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag17 = dialogResult == DialogResult.Yes;
					if (flag17)
					{
						bd bd2 = new bd();
						string cmdText6 = "update demande_intervention set deleted = @d where id = @i";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
						sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 1;
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = value2;
						bd2.ouverture_bd(bd2.cnn);
						sqlCommand6.ExecuteNonQuery();
						bd2.cnn.Close();
						this.remplissage_tableau(3);
					}
				}
				bool flag18 = a2 == "Clôturée";
				if (flag18)
				{
					MessageBox.Show("Erreur : Impossible de supprimer une demande d'intervention clôturée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				bool flag19 = a2 == "Validée";
				if (flag19)
				{
					MessageBox.Show("Erreur : Impossible de supprimer une demande d'intervention validée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			bool flag20 = e.RowIndex >= 0 && e.ColumnIndex == 17;
			if (flag20)
			{
				string a3 = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
				string value3 = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
				bool flag21 = a3 == "En Attente";
				if (flag21)
				{
					DialogResult dialogResult2 = MessageBox.Show("Vous voulez annuler ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag22 = dialogResult2 == DialogResult.Yes;
					if (flag22)
					{
						bd bd3 = new bd();
						string cmdText7 = "update demande_intervention set statut = @d where id = @i";
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd3.cnn);
						sqlCommand7.Parameters.Add("@d", SqlDbType.Int).Value = 5;
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = value3;
						bd3.ouverture_bd(bd3.cnn);
						sqlCommand7.ExecuteNonQuery();
						bd3.cnn.Close();
						this.remplissage_tableau(2);
					}
				}
				else
				{
					bool flag23 = a3 == "Annulée";
					if (flag23)
					{
						DialogResult dialogResult3 = MessageBox.Show("Vous voulez retourner en attente ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag24 = dialogResult3 == DialogResult.Yes;
						if (flag24)
						{
							bd bd4 = new bd();
							string cmdText8 = "update demande_intervention set statut = @d where id = @i";
							SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd4.cnn);
							sqlCommand8.Parameters.Add("@d", SqlDbType.Int).Value = 0;
							sqlCommand8.Parameters.Add("@i", SqlDbType.Int).Value = value3;
							bd4.ouverture_bd(bd4.cnn);
							sqlCommand8.ExecuteNonQuery();
							bd4.cnn.Close();
							this.remplissage_tableau(2);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Impossible", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x060004BC RID: 1212 RVA: 0x000C728C File Offset: 0x000C548C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.guna2Button1.Text == "Enregistrer";
			if (flag)
			{
				bd bd = new bd();
				bool flag2 = this.radDropDownList1.Text != "" & this.radDropDownList2.Text != "" & this.radMultiColumnComboBox1.Text != "";
				if (flag2)
				{
					fonction fonction = new fonction();
					bool flag3 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[1].Cells[1].Value));
					if (flag3)
					{
						int num = 0;
						int num2 = 0;
						int num3 = 0;
						bool flag4 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[0].Cells[1].Value));
						if (flag4)
						{
							num = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[0].Cells[1].Value);
						}
						int num4 = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[1].Cells[1].Value);
						bool flag5 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[2].Cells[1].Value));
						if (flag5)
						{
							num2 = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[2].Cells[1].Value);
						}
						bool flag6 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[3].Cells[1].Value));
						if (flag6)
						{
							num3 = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[3].Cells[1].Value);
						}
						string value = "Non";
						bool isChecked = this.radRadioButton2.IsChecked;
						if (isChecked)
						{
							value = "Oui";
						}
						string cmdText = "select id from parametre_anomalie where code = @v";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radMultiColumnComboBox1.Text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						int num5 = Convert.ToInt32(this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows[this.radMultiColumnComboBox1.SelectedIndex].Cells[2].Value);
						string cmdText2 = "select id from demande_intervention where year(date_emission) = @y and month(date_emission) = @m";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@y", SqlDbType.Int).Value = this.radDateTimePicker1.Value.Year;
						sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = this.radDateTimePicker1.Value.Month;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						int num6 = dataTable2.Rows.Count + 1;
						string value2 = string.Concat(new string[]
						{
							this.radDateTimePicker1.Value.Year.ToString(),
							"-",
							this.radDateTimePicker1.Value.Month.ToString(),
							"-",
							num6.ToString()
						});
						string cmdText3 = "insert into demande_intervention (id_demandeur, date_emission, heure_emission, urgence, id_defaillance, description_defaillance, createur, atelier, equipement, sous_equipement, organe, arret_machine, date_arret, heure_arret, statut, n_di, deleted) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11, @i12, @i13, @i14, @i15, @i16, @i17)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
						sqlCommand3.Parameters.Add("@i2", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
						sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
						sqlCommand3.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.radDropDownList2.Text;
						sqlCommand3.Parameters.Add("@i5", SqlDbType.Int).Value = num5;
						sqlCommand3.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand3.Parameters.Add("@i7", SqlDbType.Int).Value = page_loginn.id_user;
						sqlCommand3.Parameters.Add("@i8", SqlDbType.Int).Value = num;
						sqlCommand3.Parameters.Add("@i9", SqlDbType.Int).Value = num4;
						sqlCommand3.Parameters.Add("@i10", SqlDbType.Int).Value = num2;
						sqlCommand3.Parameters.Add("@i11", SqlDbType.Int).Value = num3;
						sqlCommand3.Parameters.Add("@i12", SqlDbType.VarChar).Value = value;
						sqlCommand3.Parameters.Add("@i13", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
						sqlCommand3.Parameters.Add("@i14", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker2.Value.ToString(), 12, 5);
						sqlCommand3.Parameters.Add("@i15", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@i16", SqlDbType.VarChar).Value = value2;
						sqlCommand3.Parameters.Add("@i17", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_grid_equipement();
						this.select_demandeur_ajout();
						this.select_urgence_ajout();
						MessageBox.Show("Enregistrement d'une demande d'intervention avec succés");
						this.guna2TextBox1.Clear();
						this.remplissage_tableau(0);
					}
					else
					{
						MessageBox.Show("Erreur : Il faut choisir l'équipement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				this.update_di(sender, e);
			}
		}

		// Token: 0x060004BD RID: 1213 RVA: 0x000C7948 File Offset: 0x000C5B48
		private void remplissage_tableau(int o)
		{
			this.panel15.Visible = false;
			this.radRadialGauge1.Visible = false;
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 10;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<int> list3 = new List<int>();
			list.Add("0");
			list2.Add("8");
			string text = "(@un = @deux)";
			string text2 = "(@un = @deux)";
			string text3 = "(@un = @deux)";
			string text4 = "(@un = @deux)";
			bool isChecked = this.radRadioButton3.IsChecked;
			if (isChecked)
			{
				for (int i = 0; i < Demande_Intervention.id_eq_filtre.Count; i++)
				{
					this.telecharger_tous_id_enfant(Demande_Intervention.id_eq_filtre[i], list3);
				}
			}
			string text5 = string.Join<int>(",", Demande_Intervention.id_eq_filtre.ToArray());
			bool isChecked2 = this.radRadioButton3.IsChecked;
			if (isChecked2)
			{
				text5 = string.Join<int>(",", list3.ToArray());
			}
			int num = 0;
			bool @checked = this.radCheckBox11.Checked;
			if (@checked)
			{
				text = "(equipement in (" + text5 + ") or @tag_equip = @dvarc1)";
				num++;
			}
			bool checked2 = this.radCheckBox12.Checked;
			if (checked2)
			{
				text2 = "(atelier in (" + text5 + ") or @tag_equip = @dvarc1)";
				num++;
			}
			bool checked3 = this.radCheckBox10.Checked;
			if (checked3)
			{
				text3 = "(sous_equipement in (" + text5 + ") or @tag_equip = @dvarc1)";
				num++;
			}
			bool checked4 = this.radCheckBox9.Checked;
			if (checked4)
			{
				text4 = "(organe in (" + text5 + ") or @tag_equip = @dvarc1)";
				num++;
			}
			string text6 = "";
			bool flag = num != 0;
			if (flag)
			{
				text6 = string.Concat(new string[]
				{
					"and ( ",
					text,
					" or ",
					text2,
					" or ",
					text3,
					" or ",
					text4,
					" )"
				});
			}
			for (int j = 0; j < this.radCheckedDropDownList1.Items.Count; j++)
			{
				bool checked5 = this.radCheckedDropDownList1.Items[j].Checked;
				if (checked5)
				{
					list.Add(this.radCheckedDropDownList1.Items[j].Tag.ToString());
				}
			}
			bool checked6 = this.radCheckBox5.Checked;
			if (checked6)
			{
				list2.Add("0");
			}
			bool checked7 = this.radCheckBox6.Checked;
			if (checked7)
			{
				list2.Add("1");
			}
			bool checked8 = this.radCheckBox7.Checked;
			if (checked8)
			{
				list2.Add("10");
			}
			bool checked9 = this.radCheckBox8.Checked;
			if (checked9)
			{
				list2.Add("5");
			}
			string text7 = string.Join(",", list.ToArray());
			string text8 = string.Join(",", list2.ToArray());
			string value = " ";
			string value2 = " ";
			bool checked10 = this.radCheckBox1.Checked;
			if (checked10)
			{
				value = "Oui";
			}
			bool checked11 = this.radCheckBox2.Checked;
			if (checked11)
			{
				value2 = "Non";
			}
			bd bd = new bd();
			string cmdText = string.Concat(new string[]
			{
				" select urgence,statut,demande_intervention.id, intervenant.nom, date_emission, heure_emission, equipement.designation, atelier, sous_equipement, organe, utilisateur.login, parametre_anomalie.anomalie, description_defaillance, arret_machine, date_arret, heure_arret, n_di from demande_intervention inner join intervenant on demande_intervention.id_demandeur = intervenant.id left join utilisateur on demande_intervention.createur = utilisateur.id inner join parametre_anomalie on demande_intervention.id_defaillance = parametre_anomalie.id inner join equipement on demande_intervention.equipement = equipement.id where demande_intervention.deleted = @d and (id_demandeur = @i1 or @v1 = @vide) and (createur = @i2 or @v2 = @vide) and (urgence = @v or @v = @vide) and (date_emission between @d1 and @d2) and (id_defaillance in (",
				text7,
				") or @tag = @dvarc) and (statut in (",
				text8,
				") or @tag_s = @dvarc) and (arret_machine = @ar1 or arret_machine = @ar2) ",
				text6,
				" order by date_emission desc, heure_emission desc"
			});
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
			sqlCommand.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
			sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.radDropDownList6.Text;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList7.SelectedItem.Tag;
			sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.radDropDownList7.Text;
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList5.Text;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker4.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker3.Value;
			sqlCommand.Parameters.Add("@tag", SqlDbType.VarChar).Value = text7;
			sqlCommand.Parameters.Add("@tag_s", SqlDbType.VarChar).Value = text8;
			sqlCommand.Parameters.Add("@tag_equip", SqlDbType.VarChar).Value = text5;
			sqlCommand.Parameters.Add("@dvarc", SqlDbType.VarChar).Value = "0";
			sqlCommand.Parameters.Add("@dvarc1", SqlDbType.VarChar).Value = "-1";
			sqlCommand.Parameters.Add("@ar1", SqlDbType.VarChar).Value = value;
			sqlCommand.Parameters.Add("@ar2", SqlDbType.VarChar).Value = value2;
			sqlCommand.Parameters.Add("@un", SqlDbType.VarChar).Value = 1;
			sqlCommand.Parameters.Add("@deux", SqlDbType.VarChar).Value = 2;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				for (int k = 0; k < dataTable.Rows.Count; k++)
				{
					string text9 = "";
					string text10 = "";
					string text11 = "";
					bool flag3 = dataTable.Rows[k].ItemArray[7].ToString() != "0";
					if (flag3)
					{
						string cmdText2 = "select designation from equipement where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[k].ItemArray[7].ToString();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						text9 = dataTable2.Rows[0].ItemArray[0].ToString();
					}
					bool flag4 = dataTable.Rows[k].ItemArray[8].ToString() != "0";
					if (flag4)
					{
						string cmdText3 = "select designation from equipement where id = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[k].ItemArray[8].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						text10 = dataTable3.Rows[0].ItemArray[0].ToString();
					}
					bool flag5 = dataTable.Rows[k].ItemArray[9].ToString() != "0";
					if (flag5)
					{
						string cmdText4 = "select designation from equipement where id = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[k].ItemArray[9].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						text11 = dataTable4.Rows[0].ItemArray[0].ToString();
					}
					string text12 = "Red";
					bool flag6 = dataTable.Rows[k].ItemArray[0].ToString() == "Moyenne";
					if (flag6)
					{
						text12 = "Yellow";
					}
					bool flag7 = dataTable.Rows[k].ItemArray[0].ToString() == "Faible";
					if (flag7)
					{
						text12 = "Green";
					}
					string text13 = "";
					string text14 = "";
					bool flag8 = dataTable.Rows[k].ItemArray[13].ToString() == "Oui";
					if (flag8)
					{
						text13 = fonction.Mid(dataTable.Rows[k].ItemArray[14].ToString(), 1, 10);
						text14 = dataTable.Rows[k].ItemArray[15].ToString();
					}
					string text15 = "";
					bool flag9 = dataTable.Rows[k].ItemArray[1].ToString() == "0";
					if (flag9)
					{
						text15 = "En Attente";
					}
					bool flag10 = dataTable.Rows[k].ItemArray[1].ToString() == "1";
					if (flag10)
					{
						text15 = "Validée";
					}
					bool flag11 = dataTable.Rows[k].ItemArray[1].ToString() == "5";
					if (flag11)
					{
						text15 = "Annulée";
					}
					bool flag12 = dataTable.Rows[k].ItemArray[1].ToString() == "10";
					if (flag12)
					{
						text15 = "Clôturée";
					}
					this.radGridView1.Rows.Add(new object[]
					{
						text12,
						text15,
						dataTable.Rows[k].ItemArray[2].ToString(),
						dataTable.Rows[k].ItemArray[16].ToString(),
						dataTable.Rows[k].ItemArray[3].ToString(),
						fonction.Mid(dataTable.Rows[k].ItemArray[4].ToString(), 1, 10),
						dataTable.Rows[k].ItemArray[5].ToString(),
						dataTable.Rows[k].ItemArray[6].ToString(),
						text9,
						text10,
						text11,
						dataTable.Rows[k].ItemArray[10].ToString(),
						dataTable.Rows[k].ItemArray[11].ToString(),
						dataTable.Rows[k].ItemArray[12].ToString(),
						dataTable.Rows[k].ItemArray[13].ToString(),
						text13,
						text14,
						"",
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.label26.Text = this.radGridView1.Rows.Count.ToString() + " DI";
			bool flag13 = this.radGridView1.Rows.Count != 0;
			if (flag13)
			{
				double num2 = 0.0;
				for (int l = 0; l < this.radGridView1.Rows.Count; l++)
				{
					bool flag14 = this.radGridView1.Rows[l].Cells[14].Value.ToString() == "Oui";
					if (flag14)
					{
						num2 += 1.0;
					}
				}
				bool flag15 = num2 != 0.0;
				if (flag15)
				{
					this.panel15.Show();
					this.radRadialGauge1.Show();
					double value3 = num2 / (double)this.radGridView1.Rows.Count * 100.0;
					this.radRadialGauge1.Value = (float)Math.Round(value3, 2);
				}
			}
			bool flag16 = this.radGridView1.Rows.Count != 0;
			if (flag16)
			{
				bool flag17 = o == 0;
				if (flag17)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag18 = o == 1;
				if (flag18)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag19 = o == 2;
				if (flag19)
				{
					this.radGridView1.Rows[Demande_Intervention.row_act].IsCurrent = true;
				}
				bool flag20 = o == 3;
				if (flag20)
				{
					bool flag21 = Demande_Intervention.row_act != 0;
					if (flag21)
					{
						this.radGridView1.Rows[Demande_Intervention.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x000C87BA File Offset: 0x000C69BA
		private void radButton3_Click(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x000C87C8 File Offset: 0x000C69C8
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Demande_Intervention.insr_or_filtre = "filtre";
			Equipement_di equipement_di = new Equipement_di();
			equipement_di.Show();
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x000C87F0 File Offset: 0x000C69F0
		private void telecharger_tous_id_enfant(int id_prn, List<int> l)
		{
			bd bd = new bd();
			l.Add(id_prn);
			string cmdText = "select id from equipement where deleted = @d and id_parent = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_prn;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.telecharger_tous_id_enfant(Convert.ToInt32(dataTable.Rows[i].ItemArray[0]), l);
				}
			}
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x000C88CC File Offset: 0x000C6ACC
		private void radCheckBox3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox3.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[4].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[4].IsVisible = false;
			}
		}

		// Token: 0x060004C2 RID: 1218 RVA: 0x000C8920 File Offset: 0x000C6B20
		private void radCheckBox4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox4.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[5].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[5].IsVisible = false;
			}
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x000C8974 File Offset: 0x000C6B74
		private void radCheckBox13_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox13.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[6].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[6].IsVisible = false;
			}
		}

		// Token: 0x060004C4 RID: 1220 RVA: 0x000C89C8 File Offset: 0x000C6BC8
		private void radCheckBox14_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox14.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[11].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[11].IsVisible = false;
			}
		}

		// Token: 0x060004C5 RID: 1221 RVA: 0x000C8A20 File Offset: 0x000C6C20
		private void radCheckBox15_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox15.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[7].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[7].IsVisible = false;
			}
		}

		// Token: 0x060004C6 RID: 1222 RVA: 0x000C8A74 File Offset: 0x000C6C74
		private void radCheckBox16_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox16.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[8].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[8].IsVisible = false;
			}
		}

		// Token: 0x060004C7 RID: 1223 RVA: 0x000C8AC8 File Offset: 0x000C6CC8
		private void radCheckBox17_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox17.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[9].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[9].IsVisible = false;
			}
		}

		// Token: 0x060004C8 RID: 1224 RVA: 0x000C8B20 File Offset: 0x000C6D20
		private void radCheckBox18_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox18.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[10].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[10].IsVisible = false;
			}
		}

		// Token: 0x060004C9 RID: 1225 RVA: 0x000C8B78 File Offset: 0x000C6D78
		private void radCheckBox19_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox19.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[12].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[12].IsVisible = false;
			}
		}

		// Token: 0x060004CA RID: 1226 RVA: 0x000C8BD0 File Offset: 0x000C6DD0
		private void radCheckBox20_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox20.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[13].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[13].IsVisible = false;
			}
		}

		// Token: 0x060004CB RID: 1227 RVA: 0x000C8C28 File Offset: 0x000C6E28
		private void radCheckBox21_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox21.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[17].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[17].IsVisible = false;
			}
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000C8C80 File Offset: 0x000C6E80
		private void radCheckBox22_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox22.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[18].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[18].IsVisible = false;
			}
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x000C8CD8 File Offset: 0x000C6ED8
		private void radCheckBox23_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox23.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[19].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[19].IsVisible = false;
			}
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x000C8D30 File Offset: 0x000C6F30
		private void radCheckBox24_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox24.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[14].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[14].IsVisible = false;
			}
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x000C8D88 File Offset: 0x000C6F88
		private void radCheckBox25_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox25.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[15].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[15].IsVisible = false;
			}
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x000C8DE0 File Offset: 0x000C6FE0
		private void radCheckBox26_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool @checked = this.radCheckBox26.Checked;
			if (@checked)
			{
				this.radGridView1.Columns[16].IsVisible = true;
			}
			else
			{
				this.radGridView1.Columns[16].IsVisible = false;
			}
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000C8E38 File Offset: 0x000C7038
		private void statut_formatting(object sender, CellFormattingEventArgs e)
		{
			string a = Convert.ToString(e.CellElement.RowInfo.Cells[1].Value);
			bool flag = a == "En Attente";
			if (flag)
			{
				bool flag2 = e.CellElement.ColumnInfo.HeaderText == "Statut";
				if (flag2)
				{
					e.CellElement.DrawFill = true;
					e.CellElement.GradientStyle = 0;
					e.CellElement.BackColor = Color.Goldenrod;
				}
				else
				{
					bool isCurrent = e.CellElement.IsCurrent;
					if (isCurrent)
					{
						e.CellElement.DrawFill = true;
						e.CellElement.GradientStyle = 0;
						e.CellElement.BackColor = Color.Firebrick;
					}
					else
					{
						e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
						e.CellElement.ResetValue(VisualElement.BackColorProperty);
						e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
					}
				}
			}
			else
			{
				bool flag3 = a == "Annulée";
				if (flag3)
				{
					bool flag4 = e.CellElement.ColumnInfo.HeaderText == "Statut";
					if (flag4)
					{
						e.CellElement.DrawFill = true;
						e.CellElement.GradientStyle = 0;
						e.CellElement.BackColor = Color.Red;
					}
					else
					{
						bool isCurrent2 = e.CellElement.IsCurrent;
						if (isCurrent2)
						{
							e.CellElement.DrawFill = true;
							e.CellElement.GradientStyle = 0;
							e.CellElement.BackColor = Color.Firebrick;
						}
						else
						{
							e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
							e.CellElement.ResetValue(VisualElement.BackColorProperty);
							e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
						}
					}
				}
				else
				{
					bool flag5 = a == "Clôturée";
					if (flag5)
					{
						bool flag6 = e.CellElement.ColumnInfo.HeaderText == "Statut";
						if (flag6)
						{
							e.CellElement.DrawFill = true;
							e.CellElement.GradientStyle = 0;
							e.CellElement.BackColor = Color.Green;
						}
						else
						{
							bool isCurrent3 = e.CellElement.IsCurrent;
							if (isCurrent3)
							{
								e.CellElement.DrawFill = true;
								e.CellElement.GradientStyle = 0;
								e.CellElement.BackColor = Color.Firebrick;
							}
							else
							{
								e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
								e.CellElement.ResetValue(VisualElement.BackColorProperty);
								e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
							}
						}
					}
					else
					{
						bool flag7 = a == "Validée";
						if (flag7)
						{
							bool flag8 = e.CellElement.ColumnInfo.HeaderText == "Statut";
							if (flag8)
							{
								e.CellElement.DrawFill = true;
								e.CellElement.GradientStyle = 0;
								e.CellElement.BackColor = Color.DodgerBlue;
							}
							else
							{
								bool isCurrent4 = e.CellElement.IsCurrent;
								if (isCurrent4)
								{
									e.CellElement.DrawFill = true;
									e.CellElement.GradientStyle = 0;
									e.CellElement.BackColor = Color.Firebrick;
								}
								else
								{
									e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
									e.CellElement.ResetValue(VisualElement.BackColorProperty);
									e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
								}
							}
						}
						else
						{
							bool isCurrent5 = e.CellElement.IsCurrent;
							if (isCurrent5)
							{
								e.CellElement.DrawFill = true;
								e.CellElement.GradientStyle = 0;
								e.CellElement.BackColor = Color.Firebrick;
							}
							else
							{
								e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
								e.CellElement.ResetValue(VisualElement.BackColorProperty);
								e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
							}
						}
					}
				}
			}
			bool flag9 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 17;
			if (flag9)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				bool flag10 = e.CellElement.RowInfo.Cells[1].Value.ToString() == "En Attente";
				if (flag10)
				{
					radButtonElement.Text = "Annuler";
					radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				}
				else
				{
					bool flag11 = e.CellElement.RowInfo.Cells[1].Value.ToString() == "Annulée";
					if (flag11)
					{
						radButtonElement.Text = "Retourner En attente";
						radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Green, "", typeof(FillPrimitive));
					}
					else
					{
						radButtonElement.Text = "";
						radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.DimGray, "", typeof(FillPrimitive));
					}
				}
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000C93E8 File Offset: 0x000C75E8
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.guna2Button1.Text = "Enregistrer";
			this.label4.Text = "Ajouter Demande Intervention";
			this.pictureBox3.Hide();
			this.remplissage_grid_equipement();
			this.select_demandeur_ajout();
			this.select_urgence_ajout();
			this.guna2TextBox1.Clear();
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000C9448 File Offset: 0x000C7648
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

		// Token: 0x060004D4 RID: 1236 RVA: 0x000C94B8 File Offset: 0x000C76B8
		private int search_tag_combogrid(string s, RadMultiColumnComboBox r)
		{
			int result = -1;
			bool flag = r.MultiColumnComboBoxElement.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < r.MultiColumnComboBoxElement.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows[this.radMultiColumnComboBox1.SelectedIndex].Cells[0].Value) == s;
					if (flag2)
					{
						result = i;
					}
				}
			}
			return result;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x000C9550 File Offset: 0x000C7750
		private void update_di(object sender, EventArgs e)
		{
			bd bd = new bd();
			bool flag = this.radDropDownList1.Text != "" & this.radDropDownList2.Text != "" & this.radMultiColumnComboBox1.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[1].Cells[1].Value));
				if (flag2)
				{
					int num = 0;
					int num2 = 0;
					int num3 = 0;
					bool flag3 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[0].Cells[1].Value));
					if (flag3)
					{
						num = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[0].Cells[1].Value);
					}
					int num4 = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[1].Cells[1].Value);
					bool flag4 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[2].Cells[1].Value));
					if (flag4)
					{
						num2 = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[2].Cells[1].Value);
					}
					bool flag5 = fonction.isnumeric(Convert.ToString(Demande_Intervention.radGridView3.Rows[3].Cells[1].Value));
					if (flag5)
					{
						num3 = Convert.ToInt32(Demande_Intervention.radGridView3.Rows[3].Cells[1].Value);
					}
					string value = "Non";
					bool isChecked = this.radRadioButton2.IsChecked;
					if (isChecked)
					{
						value = "Oui";
					}
					string cmdText = "select id from parametre_anomalie where code = @v";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radMultiColumnComboBox1.Text;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					int num5 = Convert.ToInt32(this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows[this.radMultiColumnComboBox1.SelectedIndex].Cells[2].Value);
					string cmdText2 = "update demande_intervention set id_demandeur = @i1, date_emission = @i2, heure_emission = @i3, urgence = @i4, id_defaillance = @i5, description_defaillance = @i6, atelier = @i8, equipement = @i9, sous_equipement = @i10, organe = @i11, arret_machine = @i12, date_arret = @i13, heure_arret = @i14 where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.id_modifier;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
					sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.radDropDownList2.Text;
					sqlCommand2.Parameters.Add("@i5", SqlDbType.Int).Value = num5;
					sqlCommand2.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
					sqlCommand2.Parameters.Add("@i8", SqlDbType.Int).Value = num;
					sqlCommand2.Parameters.Add("@i9", SqlDbType.Int).Value = num4;
					sqlCommand2.Parameters.Add("@i10", SqlDbType.Int).Value = num2;
					sqlCommand2.Parameters.Add("@i11", SqlDbType.Int).Value = num3;
					sqlCommand2.Parameters.Add("@i12", SqlDbType.VarChar).Value = value;
					sqlCommand2.Parameters.Add("@i13", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
					sqlCommand2.Parameters.Add("@i14", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker2.Value.ToString(), 12, 5);
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					this.pictureBox3_Click(sender, e);
					MessageBox.Show("Modification d'une demande d'intervention avec succés");
					this.remplissage_tableau(2);
					this.radGridView1.Focus();
				}
				else
				{
					MessageBox.Show("Erreur : Il faut choisir l'équipement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x000C9A74 File Offset: 0x000C7C74
		private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.radMultiColumnComboBox1.Text != "";
			if (flag)
			{
				this.TextBox2.Text = this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows[this.radMultiColumnComboBox1.SelectedIndex].Cells[1].Value.ToString();
			}
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x000C9AE0 File Offset: 0x000C7CE0
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "";
			saveFileDialog.ShowDialog();
			bool flag = false;
			bool flag2 = saveFileDialog.FileName != "";
			if (flag2)
			{
				this.RunExportToexcel(saveFileDialog.FileName, ref flag);
			}
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x000C9B30 File Offset: 0x000C7D30
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(this.radGridView1)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 1,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x04000615 RID: 1557
		public static string insr_or_filtre;

		// Token: 0x04000616 RID: 1558
		public static List<int> id_eq_filtre = new List<int>();

		// Token: 0x04000617 RID: 1559
		private static int row_act;

		// Token: 0x04000618 RID: 1560
		private int id_modifier = 0;
	}
}
