using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200001A RID: 26
	public partial class app_recompletement : Form
	{
		// Token: 0x06000156 RID: 342 RVA: 0x00040DD8 File Offset: 0x0003EFD8
		public app_recompletement()
		{
			this.InitializeComponent();
			LocalizationProvider<RadSchedulerLocalizationProvider>.CurrentProvider = new abc1();
			LocalizationProvider<SchedulerNavigatorLocalizationProvider>.CurrentProvider = new abc2();
			this.radSchedulerNavigator1.AgendaViewClick += this.RadSchedulerNavigator1_AgendaViewClick;
			this.radSchedulerNavigator1.SearchCompleted += this.RadSchedulerNavigator1_SearchCompleted;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.TimeZonesDropDown.Visibility = 2;
		}

		// Token: 0x06000157 RID: 343 RVA: 0x00040E58 File Offset: 0x0003F058
		private void radButton3_Click(object sender, EventArgs e)
		{
			app_planifier_da_recomp app_planifier_da_recomp = new app_planifier_da_recomp();
			app_planifier_da_recomp.Show();
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00040E74 File Offset: 0x0003F074
		private void RadSchedulerNavigator1_SearchCompleted(object sender, EventArgs e)
		{
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Hide();
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.AllowSearchRow = true;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.AllowDragToGroup = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.EnableGrouping = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.AllowEditRow = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[3].HeaderText = "Date";
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[0].HeaderText = "Article";
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[3].IsVisible = true;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[4].IsVisible = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[6].IsVisible = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[7].IsVisible = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[8].IsVisible = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[2].IsVisible = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[5].IsVisible = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[1].IsVisible = false;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[3].Width = 150;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Columns[3].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.Show();
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radSchedulerNavigator1.SchedulerNavigatorElement.SearchGrid.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00041118 File Offset: 0x0003F318
		private void select_recomp()
		{
			this.radScheduler1.Appointments.Clear();
			bd bd = new bd();
			string cmdText = "select id_rep, date_ech, heure_ech, article.designation from ac_recompletement_ech inner join ac_recompletement on ac_recompletement_ech.id_rep = ac_recompletement.id inner join article on ac_recompletement.id_article = article.id where ac_recompletement_ech.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
				int num2 = num % 11;
				num2++;
				int num3 = Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[2]), 1, 2));
				num3 *= 60;
				num3 += Convert.ToInt32(fonction.Mid(Convert.ToString(dataTable.Rows[i].ItemArray[2]), 4, 2));
				DateTime dateTime = Convert.ToDateTime(dataTable.Rows[i].ItemArray[1]).AddMinutes((double)num3);
				string text = Convert.ToString(dataTable.Rows[i].ItemArray[3]) ?? "";
				Appointment appointment = new Appointment(dateTime, TimeSpan.FromMinutes(60.0), text, "");
				appointment.StatusId = 2;
				appointment.BackgroundId = num2;
				this.radScheduler1.Appointments.Add(appointment);
			}
		}

		// Token: 0x0600015A RID: 346 RVA: 0x000412C1 File Offset: 0x0003F4C1
		private void app_recompletement_Load(object sender, EventArgs e)
		{
			this.select_recomp();
		}

		// Token: 0x0600015B RID: 347 RVA: 0x000412CC File Offset: 0x0003F4CC
		private void RadSchedulerNavigator1_AgendaViewClick(object sender, EventArgs e)
		{
			SchedulerAgendaViewElement schedulerAgendaViewElement = this.radScheduler1.SchedulerElement.ViewElement as SchedulerAgendaViewElement;
			RadGridView grid = schedulerAgendaViewElement.Grid;
			schedulerAgendaViewElement.AllowDrag = false;
			schedulerAgendaViewElement.AllowDrop = false;
			schedulerAgendaViewElement.DoubleClickEnabled = false;
			grid.AllowSearchRow = true;
			grid.AllowDragToGroup = false;
			grid.EnableGrouping = false;
			grid.AllowEditRow = false;
			grid.Columns[5].HeaderText = "Heure";
			grid.Columns[2].HeaderText = "Article";
			grid.Columns[3].IsVisible = false;
			grid.Columns[4].IsVisible = false;
			grid.Columns[6].IsVisible = false;
			grid.Columns[7].IsVisible = false;
			grid.Columns[8].IsVisible = false;
			grid.Columns[9].IsVisible = false;
			grid.Columns[5].IsVisible = true;
			grid.Columns[1].IsVisible = false;
			grid.Columns[5].Width = 150;
			grid.Columns[0].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			grid.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			grid.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			grid.Columns[5].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			grid.Columns.Move(5, 1);
		}

		// Token: 0x0600015C RID: 348 RVA: 0x0004146B File Offset: 0x0003F66B
		private void radButton1_Click(object sender, EventArgs e)
		{
			this.select_recomp();
		}
	}
}
