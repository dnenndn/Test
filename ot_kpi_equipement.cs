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
	// Token: 0x020000C1 RID: 193
	public partial class ot_kpi_equipement : Form
	{
		// Token: 0x060008A6 RID: 2214 RVA: 0x001702E4 File Offset: 0x0016E4E4
		public ot_kpi_equipement()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_kpi_equipement.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_kpi_equipement.select_changee);
		}

		// Token: 0x060008A7 RID: 2215 RVA: 0x00170337 File Offset: 0x0016E537
		private void ot_kpi_equipement_Load(object sender, EventArgs e)
		{
			this.select_tableau();
		}

		// Token: 0x060008A8 RID: 2216 RVA: 0x00170344 File Offset: 0x0016E544
		private void select_tableau()
		{
			bd bd = new bd();
			this.radGridView3.Rows.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "with temporaire as(select ordre_travail.id i,concat(date_debut,@espace, heure_debut, @wa) debut , concat(date_fin,@espace, heure_fin, @wa) fin, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa))/60.0 d, ordre_travail.sous_equipement e, equipement.code c, equipement.designation desi from ordre_travail inner join equipement on ordre_travail.sous_equipement = equipement.id where ordre_travail.id in (" + str + ") and ordre_travail.statut = @a and ordre_travail.type not like '%'  + @p + '%') select e, c, desi, sum(d) ttr,avg(d) mttr, count(i) nbre_ot, datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d) tbf,case datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d) when 0 then (datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d))/(count(i)) else   (datediff(MINUTE,MIN(debut),max(fin))/60.0 - sum(d))/(count(i) - 1) end  mtbf  from temporaire  group by e,c,desi";
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
				}
			}
		}

		// Token: 0x060008A9 RID: 2217 RVA: 0x00170640 File Offset: 0x0016E840
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

		// Token: 0x060008AA RID: 2218 RVA: 0x001706C4 File Offset: 0x0016E8C4
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
	}
}
