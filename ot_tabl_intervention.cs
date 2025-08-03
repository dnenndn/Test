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
	// Token: 0x020000D5 RID: 213
	public partial class ot_tabl_intervention : Form
	{
		// Token: 0x06000983 RID: 2435 RVA: 0x00186394 File Offset: 0x00184594
		public ot_tabl_intervention()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tabl_intervention.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tabl_intervention.select_changee);
		}

		// Token: 0x06000984 RID: 2436 RVA: 0x001863F6 File Offset: 0x001845F6
		private void ot_tabl_intervention_Load(object sender, EventArgs e)
		{
			this.select_corrective();
			this.select_preventive();
			this.label5.Text = this.calcul_duree_3(this.tot);
		}

		// Token: 0x06000985 RID: 2437 RVA: 0x00186420 File Offset: 0x00184620
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

		// Token: 0x06000986 RID: 2438 RVA: 0x001864A4 File Offset: 0x001846A4
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

		// Token: 0x06000987 RID: 2439 RVA: 0x001865A8 File Offset: 0x001847A8
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

		// Token: 0x06000988 RID: 2440 RVA: 0x00186620 File Offset: 0x00184820
		private void select_corrective()
		{
			bd bd = new bd();
			this.tot = 0.0;
			this.radGridView3.Rows.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct ot_ordo_intervenant.id, intervenant.nom, fonction_intervenant.designation, debut, fin, id_ressource_fonction, ordre_travail.n_ot, ordre_travail.id  from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ot_ressources_fonction.id_ot in (" + str + ") and ordre_travail.type not like '%' + @p + '%'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string value = dataTable.Rows[i].ItemArray[5].ToString();
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
						sqlCommand7.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[7].ToString();
						SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
						DataTable dataTable7 = new DataTable();
						sqlDataAdapter7.Fill(dataTable7);
						text = dataTable7.Rows[0].ItemArray[0].ToString();
						text2 = "Réparation";
					}
					this.tot = this.calcul_duree_2(dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString()) + this.tot;
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						text,
						text2,
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						this.calcul_duree(dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString())
					});
				}
			}
		}

		// Token: 0x06000989 RID: 2441 RVA: 0x00186C14 File Offset: 0x00184E14
		private void select_preventive()
		{
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			bd bd = new bd();
			string cmdText = "select distinct ot_ordo_intervenant.id, intervenant.nom, fonction_intervenant.designation, debut, fin, id_ressource_fonction, ordre_travail.n_ot, ordre_travail.id from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join fonction_intervenant on ot_ressources_fonction.id_fonction = fonction_intervenant.id inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ot_ressources_fonction.id_ot in (" + str + ") and ordre_travail.type like '%' + @p + '%'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
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
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[7].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					string text = dataTable2.Rows[0].ItemArray[0].ToString();
					string text2 = "Préventive";
					this.tot = this.calcul_duree_2(dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString()) + this.tot;
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						text,
						text2,
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						this.calcul_duree(dataTable.Rows[i].ItemArray[3].ToString(), dataTable.Rows[i].ItemArray[4].ToString())
					});
				}
			}
		}

		// Token: 0x0600098A RID: 2442 RVA: 0x00186E90 File Offset: 0x00185090
		private double calcul_duree_2(string debut, string fin)
		{
			DateTime d = Convert.ToDateTime(debut);
			DateTime d2 = Convert.ToDateTime(fin);
			TimeSpan timeSpan = default(TimeSpan);
			timeSpan = d2 - d;
			double num = Math.Truncate(timeSpan.TotalHours);
			double num2 = timeSpan.TotalMinutes % 60.0;
			return num * 60.0 + num2;
		}

		// Token: 0x0600098B RID: 2443 RVA: 0x00186F00 File Offset: 0x00185100
		private string calcul_duree_3(double s)
		{
			double num = Math.Truncate(s / 60.0);
			double num2 = s % 60.0;
			return num.ToString() + " Heures " + num2.ToString() + " Min";
		}

		// Token: 0x04000C92 RID: 3218
		private double tot = 0.0;
	}
}
