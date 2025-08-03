using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000C3 RID: 195
	public partial class ot_kpi_tous : Form
	{
		// Token: 0x060008B4 RID: 2228 RVA: 0x00171CE4 File Offset: 0x0016FEE4
		public ot_kpi_tous()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_kpi_tous.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_kpi_tous.select_changee);
			this.ProgressBar1.Hide();
		}

		// Token: 0x060008B5 RID: 2229 RVA: 0x00171D43 File Offset: 0x0016FF43
		private void ot_kpi_tous_Load(object sender, EventArgs e)
		{
			this.select_tableau();
		}

		// Token: 0x060008B6 RID: 2230 RVA: 0x00171D50 File Offset: 0x0016FF50
		private void select_tableau()
		{
			bd bd = new bd();
			this.radGridView3.Rows.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.equipement e, equipement.code c, equipement.designation desi from ordre_travail inner join equipement on ordre_travail.equipement = equipement.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot, datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d) tbf,case datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d) when 0 then (datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d))/(count(i)) else   (datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d))/(count(i) - 1) end  mtbf  from temporaire  group by e,c,desi";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.ProgressBar1.Value = 0;
				this.ProgressBar1.MaximumValue = dataTable.Rows.Count;
				this.ProgressBar1.Show();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					double value = Convert.ToDouble(dataTable.Rows[i].ItemArray[3]);
					double num = Convert.ToDouble(dataTable.Rows[i].ItemArray[4]);
					double num2 = Convert.ToDouble(dataTable.Rows[i].ItemArray[6]);
					double num3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[7]);
					string text = "-";
					string text2 = "-";
					string text3 = "-";
					string text4 = "-";
					bool flag2 = num2 != 0.0;
					if (flag2)
					{
						text = Math.Round(num2, 2).ToString();
						text2 = Math.Round(num3, 2).ToString();
						text3 = Math.Round(1.0 / num3, 4).ToString();
						text4 = (Math.Round(num3 / (num + num3), 4) * 100.0).ToString() + " %";
					}
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						Math.Round(value, 2),
						Math.Round(num, 2),
						text,
						text2,
						text4,
						text3,
						Math.Round(1.0 / num, 4)
					});
					this.ProgressBar1.Value = this.ProgressBar1.Value + 1;
				}
			}
			this.ProgressBar1.Hide();
		}

		// Token: 0x060008B7 RID: 2231 RVA: 0x001720A0 File Offset: 0x001702A0
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

		// Token: 0x060008B8 RID: 2232 RVA: 0x00172124 File Offset: 0x00170324
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

		// Token: 0x060008B9 RID: 2233 RVA: 0x00172228 File Offset: 0x00170428
		private List<double> total_debut(DataTable dt, string type_valeur)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			double item = 0.0;
			double item2 = 0.0;
			List<double> list = new List<double>();
			bool flag = dt.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					string text = fonction.Mid(dt.Rows[i].ItemArray[0].ToString(), 1, 10);
					string text2 = fonction.Mid(dt.Rows[i].ItemArray[2].ToString(), 1, 10);
					text = text + " " + dt.Rows[i].ItemArray[1].ToString();
					text2 = text2 + " " + dt.Rows[i].ItemArray[3].ToString();
					DateTime d = Convert.ToDateTime(text);
					DateTime dateTime = Convert.ToDateTime(text2);
					TimeSpan timeSpan = default(TimeSpan);
					timeSpan = dateTime - d;
					bool flag2 = type_valeur == "max";
					if (flag2)
					{
						bool flag3 = timeSpan.TotalHours > num2;
						if (flag3)
						{
							num2 = timeSpan.TotalHours;
						}
					}
					bool flag4 = type_valeur == "min";
					if (flag4)
					{
						bool flag5 = num2 > 0.0;
						if (flag5)
						{
							bool flag6 = timeSpan.TotalHours < num2;
							if (flag6)
							{
								num2 = timeSpan.TotalHours;
							}
						}
						else
						{
							num2 = timeSpan.TotalHours;
						}
					}
					num += timeSpan.TotalHours;
					bool flag7 = dt.Rows.Count > 1;
					if (flag7)
					{
						bool flag8 = i != dt.Rows.Count - 1;
						if (flag8)
						{
							string text3 = fonction.Mid(dt.Rows[i + 1].ItemArray[0].ToString(), 1, 10);
							text3 = text3 + " " + dt.Rows[i + 1].ItemArray[1].ToString();
							DateTime d2 = Convert.ToDateTime(text3);
							TimeSpan timeSpan2 = default(TimeSpan);
							timeSpan2 = d2 - dateTime;
							bool flag9 = type_valeur == "max";
							if (flag9)
							{
								bool flag10 = timeSpan2.TotalHours > num4;
								if (flag10)
								{
									num4 = timeSpan2.TotalHours;
								}
							}
							bool flag11 = type_valeur == "min";
							if (flag11)
							{
								bool flag12 = num4 > 0.0;
								if (flag12)
								{
									bool flag13 = timeSpan2.TotalHours < num4;
									if (flag13)
									{
										num4 = timeSpan2.TotalHours;
									}
								}
								else
								{
									num4 = timeSpan2.TotalHours;
								}
							}
							num3 += timeSpan2.TotalHours;
						}
					}
				}
				bool flag14 = type_valeur == "moy";
				if (flag14)
				{
					num2 = num / (double)dt.Rows.Count;
					num4 = num3 / (double)(dt.Rows.Count - 1);
				}
				item = num / (double)dt.Rows.Count;
				item2 = num3 / (double)(dt.Rows.Count - 1);
			}
			list.Add(num);
			list.Add(num2);
			list.Add(num3);
			list.Add(num4);
			list.Add(item);
			list.Add(item2);
			return list;
		}

		// Token: 0x060008BA RID: 2234 RVA: 0x001725B4 File Offset: 0x001707B4
		private void select_tableau_ot()
		{
			bd bd = new bd();
			this.radGridView3.Rows.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct ordre_travail.equipement, equipement.code, equipement.designation from ordre_travail inner join equipement on ordre_travail.equipement = equipement.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%'";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.ProgressBar1.Value = 0;
				this.ProgressBar1.MaximumValue = dataTable.Rows.Count;
				this.ProgressBar1.Show();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "-";
					string text2 = "-";
					string text3 = "";
					string text4 = "-";
					string cmdText2 = "select  date_debut, heure_debut, date_fin, heure_fin from ordre_travail  where ordre_travail.id in (" + str + ") and ordre_travail.statut =  @a and ordre_travail.type  not like '%'  + @p + '%' and equipement = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
					sqlCommand2.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						int count = dataTable2.Rows.Count;
						List<double> list = new List<double>();
						string type_valeur = "moy";
						list = this.total_debut(dataTable2, type_valeur);
						bool flag3 = list[2] != 0.0;
						if (flag3)
						{
							text = Math.Round(list[2], 2).ToString();
							text2 = Math.Round(list[3], 2).ToString();
							text3 = Math.Round(1.0 / list[5], 4).ToString();
							text4 = (Math.Round(list[5] / (list[4] + list[5]), 4) * 100.0).ToString() + " %";
						}
						this.radGridView3.Rows.Add(new object[]
						{
							dataTable.Rows[i].ItemArray[1].ToString(),
							dataTable.Rows[i].ItemArray[2].ToString(),
							count,
							Math.Round(list[0], 2),
							Math.Round(list[1], 2),
							text,
							text2,
							text4,
							text3,
							Math.Round(1.0 / list[4], 4)
						});
						this.ProgressBar1.Value = this.ProgressBar1.Value + 1;
					}
				}
			}
			this.ProgressBar1.Hide();
		}
	}
}
