using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000AE RID: 174
	public partial class ot_bt_intervention : Form
	{
		// Token: 0x060007E1 RID: 2017 RVA: 0x00157D00 File Offset: 0x00155F00
		public ot_bt_intervention()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_bt_intervention.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_bt_intervention.select_changee);
		}

		// Token: 0x060007E2 RID: 2018 RVA: 0x00157D54 File Offset: 0x00155F54
		private void ot_bt_intervention_Load(object sender, EventArgs e)
		{
			this.select_date();
			bool flag = ot_liste.type_ot_tr.Contains("Préventive");
			if (flag)
			{
				this.select_preventive();
			}
			else
			{
				this.select_corrective();
			}
		}

		// Token: 0x060007E3 RID: 2019 RVA: 0x00157D90 File Offset: 0x00155F90
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

		// Token: 0x060007E4 RID: 2020 RVA: 0x00157E14 File Offset: 0x00156014
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

		// Token: 0x060007E5 RID: 2021 RVA: 0x00157F18 File Offset: 0x00156118
		private void select_date()
		{
			bd bd = new bd();
			string cmdText = "select date_debut, heure_debut, date_fin, heure_fin from ordre_travail where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string text = fonction.Mid(dataTable.Rows[0].ItemArray[0].ToString(), 1, 10);
				string text2 = fonction.Mid(dataTable.Rows[0].ItemArray[2].ToString(), 1, 10);
				text = text + " " + dataTable.Rows[0].ItemArray[1].ToString();
				text2 = text2 + " " + dataTable.Rows[0].ItemArray[3].ToString();
				this.label2.Text = text;
				this.label3.Text = text2;
				this.label5.Text = this.calcul_duree(text, text2);
			}
		}

		// Token: 0x060007E6 RID: 2022 RVA: 0x00158058 File Offset: 0x00156258
		private string calcul_duree(string debut, string fin)
		{
			DateTime d = Convert.ToDateTime(debut);
			DateTime d2 = Convert.ToDateTime(fin);
			TimeSpan timeSpan = default(TimeSpan);
			timeSpan = d2 - d;
			double num = Math.Truncate(timeSpan.TotalHours);
			double num2 = timeSpan.TotalMinutes % 60.0;
			return num.ToString() + " Heures " + num2.ToString() + " Min";
		}

		// Token: 0x060007E7 RID: 2023 RVA: 0x001580D0 File Offset: 0x001562D0
		private void select_corrective()
		{
			bd bd = new bd();
			this.radGridView3.Rows.Clear();
			string cmdText = "select intervenant.nom, fonction_intervenant.designation, debut, fin, id_ressource_fonction from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id where ot_ressources_fonction.id_ot = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string value = dataTable.Rows[i].ItemArray[4].ToString();
					string cmdText2 = "select id_operation, type_operation from ot_ordo_intervention where id_ressource_fonction = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = value;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					string text = "";
					string text2 = "";
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						bool flag3 = dataTable2.Rows[0].ItemArray[1].ToString() == "Réparation";
						if (flag3)
						{
							string cmdText3 = "select designation from operation_maintenance where id = @i";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[0].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
							DataTable dataTable3 = new DataTable();
							sqlDataAdapter3.Fill(dataTable3);
							text = dataTable3.Rows[0].ItemArray[0].ToString();
							text2 = "Réparation";
						}
						bool flag4 = dataTable2.Rows[0].ItemArray[1].ToString() == "Intervention";
						if (flag4)
						{
							string cmdText4 = "select parametre_intervention.intervention from parametre_intervention where id = @i";
							SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[0].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
							DataTable dataTable4 = new DataTable();
							sqlDataAdapter4.Fill(dataTable4);
							text = dataTable4.Rows[0].ItemArray[0].ToString();
							text2 = "Réparation";
						}
						bool flag5 = dataTable2.Rows[0].ItemArray[1].ToString() == "Test";
						if (flag5)
						{
							string cmdText5 = "select designation from operation_maintenance where id = @i";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[0].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
							DataTable dataTable5 = new DataTable();
							sqlDataAdapter5.Fill(dataTable5);
							text = dataTable5.Rows[0].ItemArray[0].ToString();
							text2 = "Test";
						}
						bool flag6 = dataTable2.Rows[0].ItemArray[1].ToString() == "Diagnostic";
						if (flag6)
						{
							string cmdText6 = "select designation from operation_diagnostic where id = @i";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[0].ItemArray[0].ToString();
							SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
							DataTable dataTable6 = new DataTable();
							sqlDataAdapter6.Fill(dataTable6);
							text = dataTable6.Rows[0].ItemArray[0].ToString();
							text2 = "Diagnostic";
						}
					}
					else
					{
						string cmdText7 = "select parametre_intervention.intervention from ordre_travail inner join parametre_intervention on ordre_travail.id_intervention = parametre_intervention.id where ordre_travail.id = @i";
						SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
						DataTable dataTable7 = new DataTable();
						sqlDataAdapter7.Fill(dataTable7);
						text = dataTable7.Rows[0].ItemArray[0].ToString();
						text2 = "Réparation";
					}
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						text,
						text2,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						this.calcul_duree(dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString())
					});
				}
			}
		}

		// Token: 0x060007E8 RID: 2024 RVA: 0x00158620 File Offset: 0x00156820
		private void select_preventive()
		{
			bd bd = new bd();
			this.radGridView3.Rows.Clear();
			string cmdText = "select intervenant.nom, fonction_intervenant.designation, debut, fin, id_ressource_fonction from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id where ot_ressources_fonction.id_ot = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "select gamme_operatoire.designation from ordre_travail inner join gamme_operatoire on ordre_travail.id_intervention = gamme_operatoire.id where ordre_travail.id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					string text = dataTable2.Rows[0].ItemArray[0].ToString();
					string text2 = "Préventive";
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						text,
						text2,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						this.calcul_duree(dataTable.Rows[i].ItemArray[2].ToString(), dataTable.Rows[i].ItemArray[3].ToString())
					});
				}
			}
		}
	}
}
