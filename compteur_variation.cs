using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200004E RID: 78
	public partial class compteur_variation : Form
	{
		// Token: 0x0600036A RID: 874 RVA: 0x0009108C File Offset: 0x0008F28C
		public compteur_variation()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(compteur_variation.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(compteur_variation.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau();
		}

		// Token: 0x0600036B RID: 875 RVA: 0x00091134 File Offset: 0x0008F334
		private void compteur_variation_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600036C RID: 876 RVA: 0x00091138 File Offset: 0x0008F338
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

		// Token: 0x0600036D RID: 877 RVA: 0x000911BC File Offset: 0x0008F3BC
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

		// Token: 0x0600036E RID: 878 RVA: 0x000912C0 File Offset: 0x0008F4C0
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select date_mesure, equipement.designation, equipement_compteur.designation, equipement_compteur_historique.valeur, equipement_compteur.unite from equipement_compteur_historique inner join equipement_compteur on equipement_compteur_historique.id_compteur = equipement_compteur.id inner join equipement on equipement_compteur.id_equipement = equipement.id where equipement.deleted = @d and equipement_compteur.deleted = @d and date_mesure between @d1 and @d2 order by date_mesure desc";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
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
						dataTable.Rows[i].ItemArray[0].ToString().Substring(0, 10),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[4])
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x0600036F RID: 879 RVA: 0x000914EA File Offset: 0x0008F6EA
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000914F4 File Offset: 0x0008F6F4
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}
	}
}
