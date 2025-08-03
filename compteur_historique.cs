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
	// Token: 0x0200004C RID: 76
	public partial class compteur_historique : Form
	{
		// Token: 0x06000358 RID: 856 RVA: 0x0008EAAC File Offset: 0x0008CCAC
		public compteur_historique()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(compteur_historique.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(compteur_historique.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau();
		}

		// Token: 0x06000359 RID: 857 RVA: 0x0008EB54 File Offset: 0x0008CD54
		private void compteur_historique_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x0600035A RID: 858 RVA: 0x0008EB58 File Offset: 0x0008CD58
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

		// Token: 0x0600035B RID: 859 RVA: 0x0008EBDC File Offset: 0x0008CDDC
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

		// Token: 0x0600035C RID: 860 RVA: 0x0008ECE0 File Offset: 0x0008CEE0
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select date_nv, equipement.designation, equipement_compteur.designation, equipement_compteur_nv.valeur, equipement_compteur.unite from equipement_compteur_nv inner join equipement_compteur on equipement_compteur_nv.id_compteur = equipement_compteur.id inner join equipement on equipement_compteur.id_equipement = equipement.id where equipement.deleted = @d and equipement_compteur.deleted = @d and date_nv between @d1 and @d2 order by date_nv desc";
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

		// Token: 0x0600035D RID: 861 RVA: 0x0008EF0A File Offset: 0x0008D10A
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0008EF14 File Offset: 0x0008D114
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}
	}
}
