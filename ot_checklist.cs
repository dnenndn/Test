using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x020000B2 RID: 178
	public partial class ot_checklist : Form
	{
		// Token: 0x06000805 RID: 2053 RVA: 0x0015C70C File Offset: 0x0015A90C
		public ot_checklist()
		{
			this.InitializeComponent();
			this.affichage();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_checklist.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_checklist.select_changee);
		}

		// Token: 0x06000806 RID: 2054 RVA: 0x0015C768 File Offset: 0x0015A968
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

		// Token: 0x06000807 RID: 2055 RVA: 0x0015C7EC File Offset: 0x0015A9EC
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

		// Token: 0x06000808 RID: 2056 RVA: 0x0015C8EF File Offset: 0x0015AAEF
		private void ot_checklist_Load(object sender, EventArgs e)
		{
			ot_checklist.id_superviseur = 0;
			ot_checklist.id_plan = 0;
			this.select_plan_maintenance();
		}

		// Token: 0x06000809 RID: 2057 RVA: 0x0015C908 File Offset: 0x0015AB08
		private void affichage()
		{
			bool isChecked = this.radRadioButton7.IsChecked;
			if (isChecked)
			{
				this.panel1.Show();
				this.select_plan_maintenance();
				this.radGridView3.Rows.Clear();
			}
			else
			{
				this.panel1.Hide();
				ot_checklist.id_plan = 0;
				this.radGridView3.Rows.Clear();
				bd bd = new bd();
				string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
				string cmdText = "select ordre_travail.id,gamme_operatoire.id,equipement.code, gamme_operatoire.designation, ordre_travail.statut, intervenant.nom, gamme_operatoire.operation, debut_prevu, fin_prevu from ordre_travail inner join equipement on ordre_travail.equipement = equipement.id left join intervenant on ordre_travail.id_superviseur = intervenant.id inner join gamme_operatoire on ordre_travail.id_intervention = gamme_operatoire.id inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where ordre_travail.id in (" + str + ") and  ordre_travail.type like '%'  + @p + '%' and ordre_travail.statut <> @st1 and ordre_travail.statut <> @st2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@st1", SqlDbType.VarChar).Value = "Annulé";
				sqlCommand.Parameters.Add("@st2", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag = dataTable.Rows.Count != 0;
				if (flag)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radGridView3.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0],
							dataTable.Rows[i].ItemArray[1],
							dataTable.Rows[i].ItemArray[2],
							dataTable.Rows[i].ItemArray[3],
							dataTable.Rows[i].ItemArray[4],
							dataTable.Rows[i].ItemArray[5],
							dataTable.Rows[i].ItemArray[6],
							dataTable.Rows[i].ItemArray[7],
							dataTable.Rows[i].ItemArray[8],
							"True"
						});
					}
				}
			}
		}

		// Token: 0x0600080A RID: 2058 RVA: 0x0015CB5F File Offset: 0x0015AD5F
		private void radRadioButton7_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage();
		}

		// Token: 0x0600080B RID: 2059 RVA: 0x0015CB69 File Offset: 0x0015AD69
		private void radRadioButton8_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			this.affichage();
		}

		// Token: 0x0600080C RID: 2060 RVA: 0x0015CB74 File Offset: 0x0015AD74
		private void select_plan_maintenance()
		{
			bd bd = new bd();
			this.radDropDownList3.Items.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct plan_maintenance.id, plan_maintenance.designation from ordre_travail inner join gamme_operatoire on ordre_travail.id_intervention = gamme_operatoire.id inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where ordre_travail.id in (" + str + ") and ordre_travail.type  like '%'  + @p + '%' and ordre_travail.statut <> @st1 and ordre_travail.statut <> @st2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@st1", SqlDbType.VarChar).Value = "Annulé";
			sqlCommand.Parameters.Add("@st2", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
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

		// Token: 0x0600080D RID: 2061 RVA: 0x0015CCD8 File Offset: 0x0015AED8
		private void radDropDownList3_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList3.Text != "";
			if (flag)
			{
				ot_checklist.id_plan = Convert.ToInt32(this.radDropDownList3.SelectedItem.Tag);
				this.radGridView3.Rows.Clear();
				bd bd = new bd();
				string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
				string cmdText = "select ordre_travail.id,gamme_operatoire.id,equipement.designation, gamme_operatoire.designation, ordre_travail.statut, intervenant.nom, gamme_operatoire.operation, debut_prevu, fin_prevu from ordre_travail inner join equipement on ordre_travail.equipement = equipement.id left join intervenant on ordre_travail.id_superviseur = intervenant.id inner join gamme_operatoire on ordre_travail.id_intervention = gamme_operatoire.id inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where ordre_travail.id in (" + str + ") and  ordre_travail.type like '%'  + @p + '%' and ordre_travail.statut <> @st1 and ordre_travail.statut <> @st2 and plan_maintenance.id = @i ";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@st1", SqlDbType.VarChar).Value = "Annulé";
				sqlCommand.Parameters.Add("@st2", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = ot_checklist.id_plan;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radGridView3.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[0],
							dataTable.Rows[i].ItemArray[1],
							dataTable.Rows[i].ItemArray[2],
							dataTable.Rows[i].ItemArray[3],
							dataTable.Rows[i].ItemArray[4],
							dataTable.Rows[i].ItemArray[5],
							dataTable.Rows[i].ItemArray[6],
							dataTable.Rows[i].ItemArray[7],
							dataTable.Rows[i].ItemArray[8],
							"True"
						});
					}
				}
			}
		}

		// Token: 0x0600080E RID: 2062 RVA: 0x0015CF3C File Offset: 0x0015B13C
		private void radButton1_Click(object sender, EventArgs e)
		{
			ot_checklist.id_ot.Clear();
			ot_checklist.code_equipement.Clear();
			ot_checklist.gamme_operatoire.Clear();
			ot_checklist.superviseur.Clear();
			ot_checklist.operation.Clear();
			ot_checklist.debut_prevu.Clear();
			ot_checklist.fin_prevu.Clear();
			ot_checklist.plan_maintenance = this.radDropDownList3.Text;
			bool flag = this.radGridView3.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView3.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView3.Rows[i].Cells[9].Value) == "True";
					if (flag2)
					{
						ot_checklist.id_ot.Add(Convert.ToInt32(this.radGridView3.Rows[i].Cells[0].Value));
						ot_checklist.code_equipement.Add(Convert.ToString(this.radGridView3.Rows[i].Cells[2].Value));
						ot_checklist.gamme_operatoire.Add(Convert.ToString(this.radGridView3.Rows[i].Cells[3].Value));
						ot_checklist.superviseur.Add(Convert.ToString(this.radGridView3.Rows[i].Cells[5].Value));
						ot_checklist.operation.Add(Convert.ToString(this.radGridView3.Rows[i].Cells[6].Value));
						ot_checklist.debut_prevu.Add(Convert.ToString(this.radGridView3.Rows[i].Cells[7].Value));
						ot_checklist.fin_prevu.Add(Convert.ToString(this.radGridView3.Rows[i].Cells[8].Value));
					}
				}
				bool flag3 = ot_checklist.id_ot.Count != 0;
				if (flag3)
				{
					ot_rapport_checklist ot_rapport_checklist = new ot_rapport_checklist();
					ot_rapport_checklist.Show();
				}
			}
		}

		// Token: 0x0600080F RID: 2063 RVA: 0x0015D1A0 File Offset: 0x0015B3A0
		private void afficher_intervenant()
		{
			this.radGridView3.Templates.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select ordre_travail.id, intervenant.nom from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ordre_travail.id in (" + str + ") ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			dataTable2.Columns.Add("column4");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						"",
						""
					});
				}
			}
			bool flag2 = this.radGridView3.Rows.Count != 0;
			if (flag2)
			{
				for (int j = 0; j < this.radGridView3.Rows.Count; j++)
				{
					string text = this.radGridView3.Rows[j].Cells[0].Value.ToString();
					for (int k = 0; k < 4; k++)
					{
						dataTable2.Rows.Add(new object[]
						{
							text,
							"",
							"",
							""
						});
					}
				}
			}
			GridViewTemplate gridViewTemplate = new GridViewTemplate();
			gridViewTemplate.AllowEditRow = false;
			gridViewTemplate.AllowDeleteRow = false;
			gridViewTemplate.AllowAddNewRow = false;
			gridViewTemplate.Caption = "Intervenant";
			gridViewTemplate.DataSource = dataTable2;
			gridViewTemplate.AllowRowResize = false;
			gridViewTemplate.ShowColumnHeaders = true;
			gridViewTemplate.Columns["column1"].Width = 200;
			gridViewTemplate.Columns["column2"].Width = 350;
			gridViewTemplate.Columns["column3"].Width = 180;
			gridViewTemplate.Columns["column4"].Width = 180;
			gridViewTemplate.Columns[0].IsVisible = false;
			gridViewTemplate.Columns[1].HeaderText = "Intervenant";
			gridViewTemplate.Columns[2].HeaderText = "Date, Heure début";
			gridViewTemplate.Columns[3].HeaderText = "Date, Heure fin";
			gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			gridViewTemplate.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			gridViewTemplate.Columns[1].TextAlignment = ContentAlignment.MiddleLeft;
			gridViewTemplate.Columns[2].TextAlignment = ContentAlignment.MiddleLeft;
			gridViewTemplate.Columns[3].TextAlignment = ContentAlignment.MiddleLeft;
			this.radGridView3.Templates.Insert(0, gridViewTemplate);
			GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView3.MasterTemplate);
			gridViewRelation.ChildTemplate = gridViewTemplate;
			gridViewRelation.ParentColumnNames.Add(this.radGridView3.MasterTemplate.Columns[0].Name);
			gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
			this.radGridView3.Relations.Add(gridViewRelation);
		}

		// Token: 0x04000B01 RID: 2817
		public static int id_superviseur = 0;

		// Token: 0x04000B02 RID: 2818
		public static int id_plan = 0;

		// Token: 0x04000B03 RID: 2819
		public static string plan_maintenance = "";

		// Token: 0x04000B04 RID: 2820
		public static List<int> id_ot = new List<int>();

		// Token: 0x04000B05 RID: 2821
		public static List<string> code_equipement = new List<string>();

		// Token: 0x04000B06 RID: 2822
		public static List<string> gamme_operatoire = new List<string>();

		// Token: 0x04000B07 RID: 2823
		public static List<string> superviseur = new List<string>();

		// Token: 0x04000B08 RID: 2824
		public static List<string> operation = new List<string>();

		// Token: 0x04000B09 RID: 2825
		public static List<string> debut_prevu = new List<string>();

		// Token: 0x04000B0A RID: 2826
		public static List<string> fin_prevu = new List<string>();
	}
}
