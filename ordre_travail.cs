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
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x020000A1 RID: 161
	public partial class ordre_travail : Form
	{
		// Token: 0x0600074E RID: 1870 RVA: 0x00140734 File Offset: 0x0013E934
		public ordre_travail()
		{
			this.InitializeComponent();
			this.label25.Visible = false;
			this.radCheckedDropDownList1.Visible = false;
			ordre_travail.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(ordre_travail.select_change);
			ordre_travail.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(ordre_travail.select_changee);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ordre_travail.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ordre_travail.select_changee);
			this.radMultiColumnComboBox1.EditorControl.ViewCellFormatting += new CellFormattingEventHandler(ordre_travail.select_change);
			this.radMultiColumnComboBox1.EditorControl.ViewRowFormatting += new RowFormattingEventHandler(ordre_travail.select_changee);
			ordre_travail.radGridView2.CellClick += new GridViewCellEventHandler(this.action_tableau_2);
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radCheckedDropDownList2.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radCheckedDropDownList2.DropDownListElement.Popup.ToolTipTextNeeded += new ToolTipTextNeededEventHandler(this.RadCheckedDropDownList2_ToolTipTextNeeded);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.RadGridView3_CellClick);
		}

		// Token: 0x0600074F RID: 1871 RVA: 0x0014088C File Offset: 0x0013EA8C
		private void RadGridView3_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.ColumnIndex == 2;
			if (flag)
			{
				int rowIndex = e.RowIndex;
				this.radGridView3.Rows.RemoveAt(rowIndex);
			}
		}

		// Token: 0x06000750 RID: 1872 RVA: 0x001408C4 File Offset: 0x0013EAC4
		private void RadCheckedDropDownList2_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
		{
			RadListVisualItem radListVisualItem = sender as RadListVisualItem;
			bool flag = radListVisualItem != null;
			if (flag)
			{
				e.ToolTipText = radListVisualItem.Text;
			}
		}

		// Token: 0x06000751 RID: 1873 RVA: 0x001408F0 File Offset: 0x0013EAF0
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

		// Token: 0x06000752 RID: 1874 RVA: 0x00140974 File Offset: 0x0013EB74
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

		// Token: 0x06000753 RID: 1875 RVA: 0x00140A78 File Offset: 0x0013EC78
		private void panel8_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 934, 1);
		}

		// Token: 0x06000754 RID: 1876 RVA: 0x00140AB4 File Offset: 0x0013ECB4
		private void panel6_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Firebrick);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 972, 1);
		}

		// Token: 0x06000755 RID: 1877 RVA: 0x00140AF0 File Offset: 0x0013ECF0
		private void ordre_travail_Load(object sender, EventArgs e)
		{
			ordre_travail.id_atelier = 0;
			ordre_travail.id_eq_filtre.Clear();
			ordre_travail.id_eq_filtre.Add(-1);
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radDateTimePicker2.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			this.radTimePicker2.Value = new DateTime?(DateTime.Now);
			this.select_priorite_ajout();
			this.select_type_intervention_ajout();
			this.select_centre_charge_ajout();
			this.select_classe_intervention_ajout();
			this.select_superviseur_ajout();
			this.select_etat_ajout();
			this.select_centre_charge_filtre();
			this.select_classe_intervention_filtre();
			this.select_createur_filtre();
			this.select_priorite_filtre();
			this.select_superviseur_filtre();
			this.select_filtre_par_defaut();
			this.button1_Click(sender, e);
		}

		// Token: 0x06000756 RID: 1878 RVA: 0x00140BC8 File Offset: 0x0013EDC8
		private void select_di_ajout()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select id, n_di from demande_intervention where deleted = @d and (statut = @d or statut = @h)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@h", SqlDbType.Int).Value = 1;
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

		// Token: 0x06000757 RID: 1879 RVA: 0x00140CEC File Offset: 0x0013EEEC
		private void select_priorite_ajout()
		{
			this.radDropDownList2.Items.Clear();
			this.radDropDownList2.Items.Add("Elevée");
			this.radDropDownList2.Items.Add("Moyenne");
			this.radDropDownList2.Items.Add("Faible");
		}

		// Token: 0x06000758 RID: 1880 RVA: 0x00140D50 File Offset: 0x0013EF50
		private void select_priorite_filtre()
		{
			this.radDropDownList10.Items.Clear();
			this.radDropDownList10.Items.Add("");
			this.radDropDownList10.Items.Add("Elevée");
			this.radDropDownList10.Items.Add("Moyenne");
			this.radDropDownList10.Items.Add("Faible");
		}

		// Token: 0x06000759 RID: 1881 RVA: 0x00140DC8 File Offset: 0x0013EFC8
		private void select_etat_ajout()
		{
			this.radDropDownList4.Items.Clear();
			this.radDropDownList4.Items.Add("En Cours");
			this.radDropDownList4.Items.Add("En Préparation");
			this.radDropDownList4.Items.Add("Planifié");
			this.radDropDownList4.Items.Add("En Attente Arrêt Machine");
			this.radDropDownList4.Items.Add("Sous-Traitant à contacter");
		}

		// Token: 0x0600075A RID: 1882 RVA: 0x00140E58 File Offset: 0x0013F058
		private void select_type_intervention_ajout()
		{
			this.radDropDownList5.Items.Clear();
			this.radDropDownList5.Items.Add("Corrective Curative");
			this.radDropDownList5.Items.Add("Corrective Palliative");
			this.radDropDownList5.Items.Add("Travaux Neufs");
			this.radDropDownList5.Items.Add("Préventive Systématique");
			this.radDropDownList5.Items.Add("Préventive Syst Compteur");
			this.radDropDownList5.Items.Add("Préventive Conditionnelle");
		}

		// Token: 0x0600075B RID: 1883 RVA: 0x00140EFC File Offset: 0x0013F0FC
		private void select_classe_intervention_ajout()
		{
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
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
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x0600075C RID: 1884 RVA: 0x00140FE8 File Offset: 0x0013F1E8
		private void select_classe_intervention_filtre()
		{
			bd bd = new bd();
			this.radDropDownList13.Items.Clear();
			string cmdText = "select id, designation from parametre_classe_intervention";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.radDropDownList13.Items.Add("");
			this.radDropDownList13.Items[0].Tag = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList13.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList13.Items[i + 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radDropDownList13.Items[0].Selected = true;
		}

		// Token: 0x0600075D RID: 1885 RVA: 0x00141120 File Offset: 0x0013F320
		private void select_centre_charge_ajout()
		{
			bd bd = new bd();
			this.radCheckedDropDownList2.Items.Clear();
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
					this.radCheckedDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radCheckedDropDownList2.ShowItemToolTips = true;
		}

		// Token: 0x0600075E RID: 1886 RVA: 0x00141218 File Offset: 0x0013F418
		private void select_centre_charge_filtre()
		{
			bd bd = new bd();
			this.radDropDownList12.Items.Clear();
			string cmdText = "select id, designation from parametre_centre_charge";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.radDropDownList12.Items.Add("");
			this.radDropDownList12.Items[0].Tag = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList12.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList12.Items[i + 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radDropDownList12.Items[0].Selected = true;
		}

		// Token: 0x0600075F RID: 1887 RVA: 0x00141350 File Offset: 0x0013F550
		private void select_superviseur_ajout()
		{
			bd bd = new bd();
			this.radDropDownList8.Items.Clear();
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
					this.radDropDownList8.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList8.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000760 RID: 1888 RVA: 0x00141458 File Offset: 0x0013F658
		private void select_superviseur_filtre()
		{
			bd bd = new bd();
			this.radDropDownList11.Items.Clear();
			string cmdText = "select id, nom from intervenant where deleted = @d order by nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.radDropDownList11.Items.Add("");
			this.radDropDownList11.Items[0].Tag = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList11.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList11.Items[i + 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radDropDownList11.Items[0].Selected = true;
		}

		// Token: 0x06000761 RID: 1889 RVA: 0x001415AC File Offset: 0x0013F7AC
		private void select_createur_filtre()
		{
			bd bd = new bd();
			this.radDropDownList9.Items.Clear();
			string cmdText = "select id, login from utilisateur where deleted = @d order by login";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			this.radDropDownList9.Items.Add("");
			this.radDropDownList9.Items[0].Tag = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList9.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList9.Items[i + 1].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
			this.radDropDownList9.Items[0].Selected = true;
		}

		// Token: 0x06000762 RID: 1890 RVA: 0x00141700 File Offset: 0x0013F900
		private void select_intervention()
		{
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.DropDownHeight = 200;
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.DropDownWidth = 600;
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows.Clear();
			string cmdText = "select  code, intervention, id from parametre_intervention where deleted = @d order by code";
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

		// Token: 0x06000763 RID: 1891 RVA: 0x00141860 File Offset: 0x0013FA60
		private void select_gamme()
		{
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.DropDownHeight = 200;
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.DropDownWidth = 600;
			this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows.Clear();
			string cmdText = "select code, designation ,id from gamme_operatoire where deleted = @d order by code";
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

		// Token: 0x06000764 RID: 1892 RVA: 0x001419C0 File Offset: 0x0013FBC0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radMultiColumnComboBox1.Text != "" & this.radDropDownList4.Text != "" & this.radDropDownList5.Text != "" & this.radDropDownList6.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				int hour = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker2.Value), 12, 2));
				int minute = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker2.Value), 15, 2));
				int hour2 = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker1.Value), 12, 2));
				int minute2 = Convert.ToInt32(fonction.Mid(Convert.ToString(this.radTimePicker1.Value), 15, 2));
				DateTime d = new DateTime(this.radDateTimePicker2.Value.Year, this.radDateTimePicker2.Value.Month, this.radDateTimePicker2.Value.Day, hour, minute, 0);
				DateTime d2 = new DateTime(this.radDateTimePicker1.Value.Year, this.radDateTimePicker1.Value.Month, this.radDateTimePicker1.Value.Day, hour2, minute2, 0);
				double totalMinutes = (d - d2).TotalMinutes;
				bool flag2 = totalMinutes > 0.0;
				if (flag2)
				{
					int num = 0;
					bool flag3 = this.radDropDownList1.Text != "";
					if (flag3)
					{
						num = Convert.ToInt32(this.radDropDownList1.SelectedItem.Tag);
					}
					List<string> list = new List<string>();
					list.Clear();
					for (int i = 0; i < this.radCheckedDropDownList2.Items.Count; i++)
					{
						bool @checked = this.radCheckedDropDownList2.Items[i].Checked;
						if (@checked)
						{
							list.Add(this.radCheckedDropDownList2.Items[i].Tag.ToString());
						}
					}
					int num2 = 0;
					bool flag4 = this.radDropDownList8.Text != "";
					if (flag4)
					{
						num2 = Convert.ToInt32(this.radDropDownList8.SelectedItem.Tag);
					}
					bd bd = new bd();
					int num3 = 0;
					int num4 = 0;
					int num5 = 0;
					int num6 = 0;
					int num7 = 0;
					bool flag5 = num != 0;
					if (flag5)
					{
						string cmdText = "select atelier, equipement, sous_equipement, organe, id_defaillance from demande_intervention where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag6 = dataTable.Rows.Count != 0;
						if (flag6)
						{
							num3 = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
							num4 = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]);
							num5 = Convert.ToInt32(dataTable.Rows[0].ItemArray[2]);
							num6 = Convert.ToInt32(dataTable.Rows[0].ItemArray[3]);
							num7 = Convert.ToInt32(dataTable.Rows[0].ItemArray[4]);
						}
					}
					bool flag7 = this.radDropDownList5.Text == "Corrective Curative" | this.radDropDownList5.Text == "Corrective Palliative" | this.radDropDownList5.Text == "Travaux Neufs";
					string cmdText2;
					if (flag7)
					{
						cmdText2 = "select id from parametre_intervention where code = @v";
					}
					else
					{
						cmdText2 = "select id from gamme_operatoire where code = @v";
					}
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radMultiColumnComboBox1.Text;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					int num8 = Convert.ToInt32(this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows[this.radMultiColumnComboBox1.SelectedIndex].Cells[2].Value);
					string text = "";
					bool flag8 = this.radDropDownList5.Text == "Corrective Curative";
					if (flag8)
					{
						text = "CCR";
					}
					bool flag9 = this.radDropDownList5.Text == "Corrective Palliative";
					if (flag9)
					{
						text = "CPL";
					}
					bool flag10 = this.radDropDownList5.Text == "Travaux Neufs";
					if (flag10)
					{
						text = "TNF";
					}
					bool flag11 = this.radDropDownList5.Text == "Préventive Systématique";
					if (flag11)
					{
						text = "PST";
					}
					bool flag12 = this.radDropDownList5.Text == "Préventive Syst Compteur";
					if (flag12)
					{
						text = "PSC";
					}
					bool flag13 = this.radDropDownList5.Text == "Préventive Conditionnelle";
					if (flag13)
					{
						text = "PCN";
					}
					string cmdText3 = "select id from ordre_travail where year(date_debut) = @y and month(date_debut) = @m and type = @t";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@y", SqlDbType.Int).Value = this.radDateTimePicker1.Value.Year;
					sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = this.radDateTimePicker1.Value.Month;
					sqlCommand3.Parameters.Add("@t", SqlDbType.VarChar).Value = this.radDropDownList5.Text;
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					int num9 = dataTable3.Rows.Count + 1;
					string value = string.Concat(new string[]
					{
						text,
						"-",
						this.radDateTimePicker1.Value.Year.ToString(),
						"-",
						this.radDateTimePicker1.Value.Month.ToString(),
						"-",
						num9.ToString()
					});
					string cmdText4 = "insert into ordre_travail (n_ot, id_di, date_debut, heure_debut, date_fin, heure_fin, urgence, id_intervention, statut, type, id_classe, id_superviseur, commentaire,createur, deleted, atelier, equipement, sous_equipement, organe, id_defaillance, debut_prevu, fin_prevu) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8, @i9, @i10, @i11, @i13, @i14, @i15, @i16, @i17, @i18, @i19, @i20, @i21, @i22, @i23)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
					sqlCommand4.Parameters.Add("@i1", SqlDbType.VarChar).Value = value;
					sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = num;
					sqlCommand4.Parameters.Add("@i3", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
					sqlCommand4.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5);
					sqlCommand4.Parameters.Add("@i5", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
					sqlCommand4.Parameters.Add("@i6", SqlDbType.VarChar).Value = fonction.Mid(this.radTimePicker2.Value.ToString(), 12, 5);
					sqlCommand4.Parameters.Add("@i7", SqlDbType.VarChar).Value = this.radDropDownList2.Text;
					sqlCommand4.Parameters.Add("@i8", SqlDbType.Int).Value = num8;
					sqlCommand4.Parameters.Add("@i9", SqlDbType.VarChar).Value = this.radDropDownList4.Text;
					sqlCommand4.Parameters.Add("@i10", SqlDbType.VarChar).Value = this.radDropDownList5.Text;
					sqlCommand4.Parameters.Add("@i11", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag.ToString();
					sqlCommand4.Parameters.Add("@i13", SqlDbType.Int).Value = num2;
					sqlCommand4.Parameters.Add("@i14", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
					sqlCommand4.Parameters.Add("@i15", SqlDbType.Int).Value = page_loginn.id_user;
					sqlCommand4.Parameters.Add("@i16", SqlDbType.Int).Value = 0;
					sqlCommand4.Parameters.Add("@i17", SqlDbType.Int).Value = num3;
					sqlCommand4.Parameters.Add("@i18", SqlDbType.Int).Value = num4;
					sqlCommand4.Parameters.Add("@i19", SqlDbType.Int).Value = num5;
					sqlCommand4.Parameters.Add("@i20", SqlDbType.Int).Value = num6;
					sqlCommand4.Parameters.Add("@i21", SqlDbType.Int).Value = num7;
					sqlCommand4.Parameters.Add("@i22", SqlDbType.DateTime).Value = fonction.Mid(this.radDateTimePicker1.Value.ToString(), 1, 10) + " " + fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 5) + ":00";
					sqlCommand4.Parameters.Add("@i23", SqlDbType.DateTime).Value = fonction.Mid(this.radDateTimePicker2.Value.ToString(), 1, 10) + " " + fonction.Mid(this.radTimePicker2.Value.ToString(), 12, 5) + ":00";
					string cmdText5 = "update demande_intervention set statut = @d where id = @i";
					SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
					sqlCommand5.Parameters.Add("@d", SqlDbType.Int).Value = 1;
					sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = num;
					bd.ouverture_bd(bd.cnn);
					int num10 = (int)sqlCommand4.ExecuteScalar();
					sqlCommand5.ExecuteNonQuery();
					bd.cnn.Close();
					bool flag14 = list.Count != 0;
					if (flag14)
					{
						for (int j = 0; j < list.Count; j++)
						{
							string cmdText6 = "insert into ot_centre_charge (id_ot, id_centre_charge) values (@i1, @i2)";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							sqlCommand6.Parameters.Add("@i1", SqlDbType.Int).Value = num10;
							sqlCommand6.Parameters.Add("@i2", SqlDbType.Int).Value = list[j];
							bd.ouverture_bd(bd.cnn);
							sqlCommand6.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
					this.save_bsm(num10);
					MessageBox.Show("Enregistrement de l'OT avec succés");
					this.guna2TextBox1.Clear();
					this.select_centre_charge_ajout();
					this.select_classe_intervention_ajout();
					this.select_superviseur_ajout();
					this.select_type_intervention_ajout();
					this.select_priorite_ajout();
					this.select_etat_ajout();
					this.radDropDownList1.Items.Clear();
					this.select_list_ot();
					this.button1_Click(sender, e);
				}
				else
				{
					MessageBox.Show("Erreur :La Date de fin prévue doit être supérieure à la date de début prévue", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000765 RID: 1893 RVA: 0x00142608 File Offset: 0x00140808
		private void radDropDownList5_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList5.Text == "Corrective Curative" | this.radDropDownList5.Text == "Corrective Palliative" | this.radDropDownList5.Text == "Travaux Neufs";
			if (flag)
			{
				this.select_di_ajout();
				this.select_intervention();
				this.TextBox2.Clear();
			}
			else
			{
				this.radDropDownList1.Items.Clear();
				this.select_gamme();
				this.TextBox2.Clear();
			}
		}

		// Token: 0x06000766 RID: 1894 RVA: 0x001426A0 File Offset: 0x001408A0
		private void label4_Click(object sender, EventArgs e)
		{
			bool flag = !this.panel2.Visible;
			if (flag)
			{
				this.panel2.Visible = true;
			}
			else
			{
				this.panel2.Visible = false;
			}
		}

		// Token: 0x06000767 RID: 1895 RVA: 0x001426E0 File Offset: 0x001408E0
		private void label20_Click(object sender, EventArgs e)
		{
			bool flag = !this.panel7.Visible;
			if (flag)
			{
				this.panel7.Visible = true;
			}
			else
			{
				this.panel7.Visible = false;
			}
		}

		// Token: 0x06000768 RID: 1896 RVA: 0x00142720 File Offset: 0x00140920
		private void button1_Click(object sender, EventArgs e)
		{
			this.button1.ForeColor = Color.Firebrick;
			this.button1.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			ot_liste ot_liste = new ot_liste();
			ot_liste.TopLevel = false;
			this.panel3.Controls.Add(ot_liste);
			ot_liste.Show();
		}

		// Token: 0x06000769 RID: 1897 RVA: 0x00142834 File Offset: 0x00140A34
		private void select_filtre_par_defaut()
		{
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker4.Value = value;
			this.radDateTimePicker3.Value = value.AddMonths(1).AddDays(-1.0);
			this.select_list_ot();
		}

		// Token: 0x0600076A RID: 1898 RVA: 0x00142898 File Offset: 0x00140A98
		private void select_list_ot()
		{
			ordre_travail.id_ort.Clear();
			ordre_travail.id_ort.Add(0);
			ordre_travail.id_atelier = 0;
			bd bd = new bd();
			string value = "Clôturé";
			string value2 = "En Cours";
			string value3 = "En Préparation";
			string value4 = "En Attente Arrêt Machine";
			string value5 = "Planifié";
			string value6 = "Annulé";
			string value7 = "Sous-Traitant à contacter";
			bool flag = !this.radCheckBox7.Checked;
			if (flag)
			{
				value = "faux";
			}
			bool flag2 = !this.radCheckBox5.Checked;
			if (flag2)
			{
				value2 = "faux";
			}
			bool flag3 = !this.radCheckBox6.Checked;
			if (flag3)
			{
				value3 = "faux";
			}
			bool flag4 = !this.radCheckBox2.Checked;
			if (flag4)
			{
				value4 = "faux";
			}
			bool flag5 = !this.radCheckBox1.Checked;
			if (flag5)
			{
				value5 = "faux";
			}
			bool flag6 = !this.radCheckBox8.Checked;
			if (flag6)
			{
				value6 = "faux";
			}
			bool flag7 = !this.radCheckBox27.Checked;
			if (flag7)
			{
				value7 = "faux";
			}
			List<int> list = new List<int>();
			string text = "(@un = @deux)";
			string text2 = "(@un = @deux)";
			string text3 = "(@un = @deux)";
			string text4 = "(@un = @deux)";
			bool isChecked = this.radRadioButton3.IsChecked;
			if (isChecked)
			{
				for (int i = 0; i < ordre_travail.id_eq_filtre.Count; i++)
				{
					this.telecharger_tous_id_enfant(ordre_travail.id_eq_filtre[i], list);
				}
			}
			string text5 = string.Join<int>(",", ordre_travail.id_eq_filtre.ToArray());
			bool isChecked2 = this.radRadioButton3.IsChecked;
			if (isChecked2)
			{
				text5 = string.Join<int>(",", list.ToArray());
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
			string str = "";
			bool flag8 = num != 0;
			if (flag8)
			{
				str = string.Concat(new string[]
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
			bool flag9 = ordre_travail.id_eq_filtre.Count > 1;
			if (flag9)
			{
				ordre_travail.id_atelier = ordre_travail.id_eq_filtre[1];
			}
			List<string> list2 = new List<string>();
			list2.Add("0");
			for (int j = 0; j < this.radCheckedDropDownList1.Items.Count; j++)
			{
				bool checked5 = this.radCheckedDropDownList1.Items[j].Checked;
				if (checked5)
				{
					list2.Add(this.radCheckedDropDownList1.Items[j].Tag.ToString());
				}
			}
			string text6 = string.Join(",", list2.ToArray());
			bool isChecked3 = this.radRadioButton2.IsChecked;
			string cmdText;
			if (isChecked3)
			{
				cmdText = "select ordre_travail.id from ordre_travail left join equipement on ordre_travail.equipement = equipement.id left join ot_centre_charge on ordre_travail.id = ot_centre_charge.id_ot where date_debut between @d1 and @d2 and ordre_travail.type not like '%'  + @p + '%' and (ordre_travail.urgence = @u or @u = @vide) and (id_centre_charge = @ic or @ic = @nl) and (id_classe = @il or @il = @nl) and (id_superviseur = @is or @is = @nl) and (ordre_travail.createur = @cr or @cr = @nl) and (ordre_travail.statut = @s1 or ordre_travail.statut = @s2 or ordre_travail.statut = @s3 or ordre_travail.statut = @s4 or ordre_travail.statut = @s5 or ordre_travail.statut = @s6 or ordre_travail.statut = @s7) and n_ot like '%' + @num_ot + '%' and (id_defaillance in (" + text6 + ") or @tag = @dvarc) " + str;
				ordre_travail.type_maintenance = "Corrective";
			}
			else
			{
				bool isChecked4 = this.radRadioButton1.IsChecked;
				if (isChecked4)
				{
					cmdText = "select ordre_travail.id from ordre_travail left join equipement on ordre_travail.equipement = equipement.id left join ot_centre_charge on ordre_travail.id = ot_centre_charge.id_ot where date_debut between @d1 and @d2 and ordre_travail.type  like '%'  + @p + '%' and (ordre_travail.urgence = @u or @u = @vide) and (id_centre_charge = @ic or @ic = @nl) and (id_classe = @il or @il = @nl) and (id_superviseur = @is or @is = @nl) and (ordre_travail.createur = @cr or @cr = @nl) and (ordre_travail.statut = @s1 or ordre_travail.statut = @s2 or ordre_travail.statut = @s3 or ordre_travail.statut = @s4 or ordre_travail.statut = @s5 or ordre_travail.statut = @s6 or ordre_travail.statut = @s7) and n_ot like '%' + @num_ot + '%' and (id_defaillance in (" + text6 + ") or @tag = @dvarc) " + str;
					ordre_travail.type_maintenance = "Préventive";
				}
				else
				{
					cmdText = "select ordre_travail.id from ordre_travail left join equipement on ordre_travail.equipement = equipement.id left join ot_centre_charge on ordre_travail.id = ot_centre_charge.id_ot where date_debut between @d1 and @d2  and (ordre_travail.urgence = @u or @u = @vide) and (id_centre_charge = @ic or @ic = @nl) and (id_classe = @il or @il = @nl) and (id_superviseur = @is or @is = @nl) and (ordre_travail.createur = @cr or @cr = @nl) and (ordre_travail.statut = @s1 or ordre_travail.statut = @s2 or ordre_travail.statut = @s3 or ordre_travail.statut = @s4 or ordre_travail.statut = @s5 or ordre_travail.statut = @s6 or ordre_travail.statut = @s7) and n_ot like '%' + @num_ot + '%' and (id_defaillance in (" + text6 + ") or @tag = @dvarc) " + str;
					ordre_travail.type_maintenance = "Tous";
				}
			}
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker4.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker3.Value;
			sqlCommand.Parameters.Add("@u", SqlDbType.VarChar).Value = this.radDropDownList10.Text;
			sqlCommand.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
			sqlCommand.Parameters.Add("@ic", SqlDbType.Int).Value = this.radDropDownList12.SelectedItem.Tag;
			sqlCommand.Parameters.Add("@is", SqlDbType.Int).Value = this.radDropDownList11.SelectedItem.Tag;
			sqlCommand.Parameters.Add("@il", SqlDbType.Int).Value = this.radDropDownList13.SelectedItem.Tag;
			sqlCommand.Parameters.Add("@cr", SqlDbType.Int).Value = this.radDropDownList9.SelectedItem.Tag;
			sqlCommand.Parameters.Add("@nl", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@s1", SqlDbType.VarChar).Value = value;
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@s2", SqlDbType.VarChar).Value = value2;
			sqlCommand.Parameters.Add("@s3", SqlDbType.VarChar).Value = value3;
			sqlCommand.Parameters.Add("@s4", SqlDbType.VarChar).Value = value4;
			sqlCommand.Parameters.Add("@s5", SqlDbType.VarChar).Value = value5;
			sqlCommand.Parameters.Add("@s6", SqlDbType.VarChar).Value = value6;
			sqlCommand.Parameters.Add("@s7", SqlDbType.VarChar).Value = value7;
			sqlCommand.Parameters.Add("@num_ot", SqlDbType.VarChar).Value = this.radTextBox1.Text;
			sqlCommand.Parameters.Add("@tag", SqlDbType.VarChar).Value = text6;
			sqlCommand.Parameters.Add("@dvarc", SqlDbType.VarChar).Value = "0";
			sqlCommand.Parameters.Add("@dvarc1", SqlDbType.VarChar).Value = "-1";
			sqlCommand.Parameters.Add("@un", SqlDbType.VarChar).Value = 1;
			sqlCommand.Parameters.Add("@deux", SqlDbType.VarChar).Value = 2;
			sqlCommand.Parameters.Add("@tag_equip", SqlDbType.VarChar).Value = text5;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag10 = dataTable.Rows.Count != 0;
			if (flag10)
			{
				for (int k = 0; k < dataTable.Rows.Count; k++)
				{
					ordre_travail.id_ort.Add(Convert.ToInt32(dataTable.Rows[k].ItemArray[0]));
				}
			}
		}

		// Token: 0x0600076B RID: 1899 RVA: 0x00143044 File Offset: 0x00141244
		private void radButton3_Click(object sender, EventArgs e)
		{
			this.select_list_ot();
			bool flag = this.button1.BackColor == Color.White;
			if (flag)
			{
				this.button1_Click(sender, e);
			}
			bool flag2 = this.button2.BackColor == Color.White;
			if (flag2)
			{
				this.button2_Click(sender, e);
			}
			bool flag3 = this.button3.BackColor == Color.White;
			if (flag3)
			{
				this.button3_Click(sender, e);
			}
			bool flag4 = this.button5.BackColor == Color.White;
			if (flag4)
			{
				this.button5_Click(sender, e);
			}
			bool flag5 = this.button4.BackColor == Color.White;
			if (flag5)
			{
				this.button4_Click(sender, e);
			}
		}

		// Token: 0x0600076C RID: 1900 RVA: 0x00143110 File Offset: 0x00141310
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			Demande_Intervention.insr_or_filtre = "filtre_ot";
			Equipement_di equipement_di = new Equipement_di();
			equipement_di.Show();
		}

		// Token: 0x0600076D RID: 1901 RVA: 0x00143138 File Offset: 0x00141338
		private void action_tableau_2(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 3;
			if (flag)
			{
				int index = e.RowIndex + 1;
				ordre_travail.id_eq_filtre.RemoveAt(index);
				ordre_travail.radGridView2.Rows.RemoveAt(e.RowIndex);
			}
		}

		// Token: 0x0600076E RID: 1902 RVA: 0x0014318C File Offset: 0x0014138C
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

		// Token: 0x0600076F RID: 1903 RVA: 0x00143268 File Offset: 0x00141468
		private void button2_Click(object sender, EventArgs e)
		{
			this.button2.ForeColor = Color.Firebrick;
			this.button2.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			ot_agenda ot_agenda = new ot_agenda();
			ot_agenda.TopLevel = false;
			this.panel3.Controls.Add(ot_agenda);
			ot_agenda.Show();
		}

		// Token: 0x06000770 RID: 1904 RVA: 0x0014337C File Offset: 0x0014157C
		private void button3_Click(object sender, EventArgs e)
		{
			this.button3.ForeColor = Color.Firebrick;
			this.button3.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			ot_tableau ot_tableau = new ot_tableau();
			ot_tableau.TopLevel = false;
			this.panel3.Controls.Add(ot_tableau);
			ot_tableau.Show();
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x00143490 File Offset: 0x00141690
		private void button5_Click(object sender, EventArgs e)
		{
			this.button5.ForeColor = Color.Firebrick;
			this.button5.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			ot_tb ot_tb = new ot_tb();
			ot_tb.TopLevel = false;
			this.panel3.Controls.Add(ot_tb);
			ot_tb.Show();
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x001435A4 File Offset: 0x001417A4
		private void button4_Click(object sender, EventArgs e)
		{
			this.button4.ForeColor = Color.Firebrick;
			this.button4.BackColor = Color.White;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button6.ForeColor = Color.White;
			this.button6.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			ot_analyse ot_analyse = new ot_analyse();
			ot_analyse.TopLevel = false;
			this.panel3.Controls.Add(ot_analyse);
			ot_analyse.Show();
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x001436B8 File Offset: 0x001418B8
		private void button6_Click(object sender, EventArgs e)
		{
			this.button6.ForeColor = Color.Firebrick;
			this.button6.BackColor = Color.White;
			this.button2.ForeColor = Color.White;
			this.button2.BackColor = Color.Firebrick;
			this.button3.ForeColor = Color.White;
			this.button3.BackColor = Color.Firebrick;
			this.button4.ForeColor = Color.White;
			this.button4.BackColor = Color.Firebrick;
			this.button5.ForeColor = Color.White;
			this.button5.BackColor = Color.Firebrick;
			this.button1.ForeColor = Color.White;
			this.button1.BackColor = Color.Firebrick;
			this.panel3.Controls.Clear();
			ot_checklist ot_checklist = new ot_checklist();
			ot_checklist.TopLevel = false;
			this.panel3.Controls.Add(ot_checklist);
			ot_checklist.Show();
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x001437CC File Offset: 0x001419CC
		private void radMultiColumnComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			bool flag = this.radMultiColumnComboBox1.Text != "";
			if (flag)
			{
				this.TextBox2.Text = this.radMultiColumnComboBox1.MultiColumnComboBoxElement.Rows[this.radMultiColumnComboBox1.SelectedIndex].Cells[1].Value.ToString();
			}
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x00143838 File Offset: 0x00141A38
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.TextBox1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from bsm where n_ot = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "select ordre_travail.n_ot from bsm inner join ordre_travail on bsm.li_ot = ordre_travail.id where bsm.n_ot = @i and li_ot <> @vide";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count == 0;
					if (flag3)
					{
						string cmdText3 = "select id from bsm where n_ot = @h";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@h", SqlDbType.VarChar).Value = this.TextBox1.Text;
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag4 = dataTable3.Rows.Count != 0;
						if (flag4)
						{
							for (int i = 0; i < dataTable3.Rows.Count; i++)
							{
								string text = Convert.ToString(dataTable3.Rows[i].ItemArray[0]);
								int num = 0;
								for (int j = 0; j < this.radGridView3.Rows.Count; j++)
								{
									bool flag5 = this.radGridView3.Rows[j].Cells[0].Value.ToString() == text;
									if (flag5)
									{
										num = 1;
									}
								}
								bool flag6 = num == 0;
								if (flag6)
								{
									this.radGridView3.Rows.Add(new object[]
									{
										text,
										this.TextBox1.Text,
										Resources.icons8_supprimer_pour_toujours_100__4_
									});
								}
							}
						}
						this.TextBox1.Clear();
					}
					else
					{
						MessageBox.Show("Erreur :  BSM déja ajouté dans l'OT n° " + dataTable2.Rows[0].ItemArray[0].ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :BSM Introuvable", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x00143B24 File Offset: 0x00141D24
		private void save_bsm(int id_ot)
		{
			bd bd = new bd();
			for (int i = 0; i < this.radGridView3.Rows.Count; i++)
			{
				string cmdText = "update bsm set li_ot = @v where id = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = id_ot;
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView3.Rows[i].Cells[0].Value;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
			this.radGridView3.Rows.Clear();
		}

		// Token: 0x040009E7 RID: 2535
		public static List<int> id_ort = new List<int>();

		// Token: 0x040009E8 RID: 2536
		public static List<int> id_eq_filtre = new List<int>();

		// Token: 0x040009E9 RID: 2537
		public static int id_atelier;

		// Token: 0x040009EA RID: 2538
		public static string type_maintenance = " ";
	}
}
