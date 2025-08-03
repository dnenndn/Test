using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x020000EB RID: 235
	public partial class outillage_utilisation_historique : Form
	{
		// Token: 0x06000A37 RID: 2615 RVA: 0x00195E28 File Offset: 0x00194028
		public outillage_utilisation_historique()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(outillage_utilisation_historique.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(outillage_utilisation_historique.select_changee);
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00195E88 File Offset: 0x00194088
		private void outillage_utilisation_historique_Load(object sender, EventArgs e)
		{
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.remplissage_tableau();
		}

		// Token: 0x06000A39 RID: 2617 RVA: 0x00195EEC File Offset: 0x001940EC
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

		// Token: 0x06000A3A RID: 2618 RVA: 0x00195F70 File Offset: 0x00194170
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

		// Token: 0x06000A3B RID: 2619 RVA: 0x00196074 File Offset: 0x00194274
		public void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.PageSize = 15;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			DataTable dataTable = new DataTable();
			dataTable.Clear();
			string cmdText = "select  tab_lancement_affectation.id,outils.designation,intervenant.nom, date_debut,heure_debut,date_fin,heure_fin,commentaire, outils.id from tab_lancement_affectation inner join outils on tab_lancement_affectation.outil = outils.id inner join intervenant on tab_lancement_affectation.id_intervenant = intervenant.id where encours=0 and date_debut between @d1 and @d2 order by date_debut";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				sqlDataAdapter.Fill(dataTable);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString().Substring(0, 9),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString().Substring(0, 9),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[7].ToString(),
						dataTable.Rows[i].ItemArray[8].ToString()
					});
				}
				this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
				this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			}
		}
	}
}
