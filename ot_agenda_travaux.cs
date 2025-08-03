using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x020000A4 RID: 164
	public partial class ot_agenda_travaux : Form
	{
		// Token: 0x06000789 RID: 1929 RVA: 0x0014E878 File Offset: 0x0014CA78
		public ot_agenda_travaux()
		{
			this.InitializeComponent();
			this.radScheduler1.AppointmentFormatting += this.RadScheduler1_AppointmentFormatting;
			this.radGanttView1.GanttViewElement.GraphicalViewElement.TimelineRange = 1;
			this.radGanttView1.TextViewItemFormatting += new GanttViewTextViewItemFormattingEventHandler(this.radGanttView1_TextViewItemFormatting);
			this.radGanttView1.TextViewCellFormatting += new GanttViewTextViewCellFormattingEventHandler(this.radGanttView1_TextViewCellFormatting);
			this.radGanttView1.GraphicalViewItemFormatting += new GanttViewGraphicalViewItemFormattingEventHandler(this.radGanttView1_GraphicalViewItemFormatting);
			this.radGanttView1.ItemChildIdNeeded += new GanttViewItemChildIdNeededEventHandler(this.RadGanttView1_ItemChildIdNeeded);
		}

		// Token: 0x0600078A RID: 1930 RVA: 0x0014E92A File Offset: 0x0014CB2A
		private void RadGanttView1_ItemChildIdNeeded(object sender, GanttViewItemChildIdNeededEventArgs e)
		{
			e.ChildId = new EventId(Guid.NewGuid());
		}

		// Token: 0x0600078B RID: 1931 RVA: 0x0014E944 File Offset: 0x0014CB44
		private void RadScheduler1_AppointmentFormatting(object sender, SchedulerAppointmentEventArgs e)
		{
			Font font = new Font("Verdana", 8f, FontStyle.Regular);
			e.AppointmentElement.Font = font;
			e.AppointmentElement.ForeColor = Color.White;
			e.AppointmentElement.UseDefaultPaint = true;
			e.AppointmentElement.BorderBoxStyle = 0;
			e.AppointmentElement.BorderWidth = 1f;
		}

		// Token: 0x0600078C RID: 1932 RVA: 0x0014E9AC File Offset: 0x0014CBAC
		private void ot_agenda_travaux_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = DateTime.Today;
			this.select_affichage();
			this.select_type_maintenance();
			this.radScheduler1.ActiveViewType = 0;
			this.radScheduler1.ActiveView.StartDate = this.radDateTimePicker1.Value;
			this.remplissage_calendrier();
		}

		// Token: 0x0600078D RID: 1933 RVA: 0x0014EA0C File Offset: 0x0014CC0C
		private void select_affichage()
		{
			this.radDropDownList6.Items.Clear();
			this.radDropDownList6.Items.Add("1 Jour");
			this.radDropDownList6.Items.Add("3 Jours");
			this.radDropDownList6.Items.Add("Une Semaine");
			this.radDropDownList6.Items.Add("Mois");
			this.radDropDownList6.Items.Add("Chronologie");
			this.radDropDownList6.Text = "3 Jours";
		}

		// Token: 0x0600078E RID: 1934 RVA: 0x0014EAAC File Offset: 0x0014CCAC
		private void select_type_maintenance()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Corrective");
			this.radDropDownList1.Items.Add("Préventive");
			this.radDropDownList1.Text = "Corrective";
		}

		// Token: 0x0600078F RID: 1935 RVA: 0x0014EB08 File Offset: 0x0014CD08
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList6.Text == "1 Jour";
			if (flag)
			{
				this.radScheduler1.ActiveViewType = 1;
			}
			bool flag2 = this.radDropDownList6.Text == "3 Jours";
			if (flag2)
			{
				this.radScheduler1.ActiveViewType = 0;
			}
			bool flag3 = this.radDropDownList6.Text == "Une Semaine";
			if (flag3)
			{
				this.radScheduler1.ActiveViewType = 2;
			}
			bool flag4 = this.radDropDownList6.Text == "Mois";
			if (flag4)
			{
				this.radScheduler1.ActiveViewType = 4;
			}
			bool flag5 = this.radDropDownList6.Text == "Chronologie";
			if (flag5)
			{
				this.radScheduler1.ActiveViewType = 5;
			}
			this.radScheduler1.ActiveView.StartDate = this.radDateTimePicker1.Value;
		}

		// Token: 0x06000790 RID: 1936 RVA: 0x0014EBFC File Offset: 0x0014CDFC
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.radScheduler1.ActiveView.StartDate = this.radDateTimePicker1.Value;
		}

		// Token: 0x06000791 RID: 1937 RVA: 0x0014EC1C File Offset: 0x0014CE1C
		private void remplissage_calendrier()
		{
			this.radScheduler1.Appointments.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select date_debut, heure_debut, date_fin, heure_fin, type, id_intervention, equipement, statut, ordre_travail.id from ordre_travail where id in (" + str + ") and type not like '%'+ @k + '%' and statut <> @a";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				AppointmentBackgroundInfo item = new AppointmentBackgroundInfo(100, "c0", Color.FromArgb(102, 102, 255), Color.FromArgb(106, 68, 232));
				this.radScheduler1.Backgrounds.Add(item);
				AppointmentBackgroundInfo item2 = new AppointmentBackgroundInfo(101, "c1", Color.FromArgb(255, 0, 127), Color.FromArgb(255, 0, 127));
				this.radScheduler1.Backgrounds.Add(item2);
				AppointmentBackgroundInfo item3 = new AppointmentBackgroundInfo(102, "c2", Color.PaleGreen, Color.PaleGreen);
				this.radScheduler1.Backgrounds.Add(item3);
				AppointmentBackgroundInfo item4 = new AppointmentBackgroundInfo(103, "c3", Color.Aquamarine, Color.Aquamarine);
				this.radScheduler1.Backgrounds.Add(item4);
				AppointmentBackgroundInfo item5 = new AppointmentBackgroundInfo(104, "c4", Color.FromArgb(192, 192, 0), Color.FromArgb(192, 192, 0));
				this.radScheduler1.Backgrounds.Add(item5);
				AppointmentBackgroundInfo item6 = new AppointmentBackgroundInfo(105, "c5", Color.Silver, Color.Silver);
				this.radScheduler1.Backgrounds.Add(item6);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					string cmdText2 = "select code from equipement where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[6].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					string str2 = "";
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						str2 = dataTable2.Rows[0].ItemArray[0].ToString() + "-";
					}
					string cmdText3 = "select intervention from parametre_intervention where id = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[5].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						text = str2 + dataTable3.Rows[0].ItemArray[0].ToString();
					}
					string value = fonction.Mid(dataTable.Rows[i].ItemArray[0].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[1].ToString() + ":00";
					string value2 = fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[3].ToString() + ":00";
					DateTime dateTime = default(DateTime);
					dateTime = Convert.ToDateTime(value);
					DateTime d = default(DateTime);
					d = Convert.ToDateTime(value2);
					TimeSpan timeSpan = default(TimeSpan);
					Appointment appointment = new Appointment(dateTime, TimeSpan.FromMinutes((d - dateTime).TotalMinutes), text, "");
					appointment.StatusId = 2;
					appointment.UniqueId = new EventId(Convert.ToInt32(dataTable.Rows[i].ItemArray[8]));
					bool flag4 = dataTable.Rows[i].ItemArray[7].ToString() == "En Cours";
					if (flag4)
					{
						appointment.BackgroundId = 100;
					}
					bool flag5 = dataTable.Rows[i].ItemArray[7].ToString() == "Planifié";
					if (flag5)
					{
						appointment.BackgroundId = 101;
					}
					bool flag6 = dataTable.Rows[i].ItemArray[7].ToString() == "Clôturé";
					if (flag6)
					{
						appointment.BackgroundId = 102;
					}
					bool flag7 = dataTable.Rows[i].ItemArray[7].ToString() == "En Préparation";
					if (flag7)
					{
						appointment.BackgroundId = 103;
					}
					bool flag8 = dataTable.Rows[i].ItemArray[7].ToString() == "En Attente Arrêt Machine";
					if (flag8)
					{
						appointment.BackgroundId = 104;
					}
					bool flag9 = dataTable.Rows[i].ItemArray[7].ToString() == "Sous-Traitant à contacter";
					if (flag9)
					{
						appointment.BackgroundId = 105;
					}
					this.radScheduler1.Appointments.Add(appointment);
				}
			}
			this.radGanttView1.DataProvider = null;
			this.radGanttView1.Items.Clear();
			this.radGanttView1.Links.Clear();
			this.radGanttView1.Columns.Clear();
			this.radGanttView1.DataProvider = new GanttViewIntegrationProvider(this.radScheduler1);
			this.InitializeGanttView();
			this.radGanttView1.GanttViewElement.Columns[0].HeaderText = "Désignation";
			this.radGanttView1.GanttViewElement.Columns[1].HeaderText = "Début";
			this.radGanttView1.GanttViewElement.Columns[2].HeaderText = "Fin";
			foreach (GanttViewDataItem ganttViewDataItem in this.radGanttView1.Items)
			{
				Appointment appointment2 = ganttViewDataItem.DataBoundItem as Appointment;
				string value3 = appointment2.UniqueId.ToString();
				string cmdText4 = "select intervenant.nom, debut, fin from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ordo_intervention on ot_ordo_intervenant.id_ressource_fonction = ot_ordo_intervention.id_ressource_fonction where ot_ordo_intervention.id_ressource_fonction in (select id from ot_ressources_fonction where id_ot = @i) ";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value3;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag10 = dataTable4.Rows.Count != 0;
				if (flag10)
				{
					for (int j = 0; j < dataTable4.Rows.Count; j++)
					{
						string title = dataTable4.Rows[j].ItemArray[0].ToString();
						GanttViewDataItem ganttViewDataItem2 = new GanttViewDataItem();
						ganttViewDataItem2.Start = Convert.ToDateTime(dataTable4.Rows[j].ItemArray[1]);
						ganttViewDataItem2.End = Convert.ToDateTime(dataTable4.Rows[j].ItemArray[2]);
						ganttViewDataItem2.Progress = 30m;
						ganttViewDataItem2.Title = title;
						ganttViewDataItem.Items.Add(ganttViewDataItem2);
					}
				}
			}
		}

		// Token: 0x06000792 RID: 1938 RVA: 0x0014F454 File Offset: 0x0014D654
		private void remplissage_calendrier_preventive()
		{
			this.radScheduler1.Appointments.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select date_debut, heure_debut, date_fin, heure_fin, type, id_intervention, equipement, statut, ordre_travail.id from ordre_travail where id in (" + str + ") and type like '%'+ @k + '%' and statut <> @a";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				AppointmentBackgroundInfo item = new AppointmentBackgroundInfo(100, "c0", Color.FromArgb(102, 102, 255), Color.FromArgb(106, 68, 232));
				this.radScheduler1.Backgrounds.Add(item);
				AppointmentBackgroundInfo item2 = new AppointmentBackgroundInfo(101, "c1", Color.FromArgb(255, 0, 127), Color.FromArgb(255, 0, 127));
				this.radScheduler1.Backgrounds.Add(item2);
				AppointmentBackgroundInfo item3 = new AppointmentBackgroundInfo(102, "c2", Color.PaleGreen, Color.PaleGreen);
				this.radScheduler1.Backgrounds.Add(item3);
				AppointmentBackgroundInfo item4 = new AppointmentBackgroundInfo(103, "c3", Color.Aquamarine, Color.Aquamarine);
				this.radScheduler1.Backgrounds.Add(item4);
				AppointmentBackgroundInfo item5 = new AppointmentBackgroundInfo(104, "c4", Color.FromArgb(192, 192, 0), Color.FromArgb(192, 192, 0));
				this.radScheduler1.Backgrounds.Add(item5);
				AppointmentBackgroundInfo item6 = new AppointmentBackgroundInfo(105, "c5", Color.Silver, Color.Silver);
				this.radScheduler1.Backgrounds.Add(item6);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					string cmdText2 = "select code from equipement where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[6].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					string str2 = "";
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						str2 = dataTable2.Rows[0].ItemArray[0].ToString() + "-";
					}
					string cmdText3 = "select designation from gamme_operatoire where id = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[5].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag3 = dataTable3.Rows.Count != 0;
					if (flag3)
					{
						text = str2 + dataTable3.Rows[0].ItemArray[0].ToString();
					}
					string value = fonction.Mid(dataTable.Rows[i].ItemArray[0].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[1].ToString() + ":00";
					string value2 = fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10) + " " + dataTable.Rows[i].ItemArray[3].ToString() + ":00";
					DateTime dateTime = default(DateTime);
					dateTime = Convert.ToDateTime(value);
					DateTime d = default(DateTime);
					d = Convert.ToDateTime(value2);
					TimeSpan timeSpan = default(TimeSpan);
					Appointment appointment = new Appointment(dateTime, TimeSpan.FromMinutes((d - dateTime).TotalMinutes), text, "");
					appointment.StatusId = 2;
					appointment.UniqueId = new EventId(Convert.ToInt32(dataTable.Rows[i].ItemArray[8]));
					bool flag4 = dataTable.Rows[i].ItemArray[7].ToString() == "En Cours";
					if (flag4)
					{
						appointment.BackgroundId = 100;
					}
					bool flag5 = dataTable.Rows[i].ItemArray[7].ToString() == "Planifié";
					if (flag5)
					{
						appointment.BackgroundId = 101;
					}
					bool flag6 = dataTable.Rows[i].ItemArray[7].ToString() == "Clôturé";
					if (flag6)
					{
						appointment.BackgroundId = 102;
					}
					bool flag7 = dataTable.Rows[i].ItemArray[7].ToString() == "En Préparation";
					if (flag7)
					{
						appointment.BackgroundId = 103;
					}
					bool flag8 = dataTable.Rows[i].ItemArray[7].ToString() == "En Attente Arrêt Machine";
					if (flag8)
					{
						appointment.BackgroundId = 104;
					}
					bool flag9 = dataTable.Rows[i].ItemArray[7].ToString() == "Sous-Traitant à contacter";
					if (flag9)
					{
						appointment.BackgroundId = 105;
					}
					this.radScheduler1.Appointments.Add(appointment);
				}
			}
			this.radGanttView1.DataProvider = null;
			this.radGanttView1.Items.Clear();
			this.radGanttView1.Links.Clear();
			this.radGanttView1.Columns.Clear();
			this.radGanttView1.DataProvider = new GanttViewIntegrationProvider(this.radScheduler1);
			this.InitializeGanttView();
			this.radGanttView1.GanttViewElement.Columns[0].HeaderText = "Désignation";
			this.radGanttView1.GanttViewElement.Columns[1].HeaderText = "Début";
			this.radGanttView1.GanttViewElement.Columns[2].HeaderText = "Fin";
			foreach (GanttViewDataItem ganttViewDataItem in this.radGanttView1.Items)
			{
				Appointment appointment2 = ganttViewDataItem.DataBoundItem as Appointment;
				string value3 = appointment2.UniqueId.ToString();
				string cmdText4 = "select intervenant.nom, debut, fin from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id  where ot_ordo_intervenant.id_ressource_fonction in (select id from ot_ressources_fonction where id_ot = @i) ";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = value3;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag10 = dataTable4.Rows.Count != 0;
				if (flag10)
				{
					for (int j = 0; j < dataTable4.Rows.Count; j++)
					{
						string title = dataTable4.Rows[j].ItemArray[0].ToString();
						GanttViewDataItem ganttViewDataItem2 = new GanttViewDataItem();
						ganttViewDataItem2.Start = Convert.ToDateTime(dataTable4.Rows[j].ItemArray[1]);
						ganttViewDataItem2.End = Convert.ToDateTime(dataTable4.Rows[j].ItemArray[2]);
						ganttViewDataItem2.Progress = 30m;
						ganttViewDataItem2.Title = title;
						ganttViewDataItem.Items.Add(ganttViewDataItem2);
					}
				}
			}
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x0014FC8C File Offset: 0x0014DE8C
		private void radDropDownList1_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList1.Text == "Corrective";
			if (flag)
			{
				this.remplissage_calendrier();
			}
			else
			{
				this.remplissage_calendrier_preventive();
			}
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x0014FCC8 File Offset: 0x0014DEC8
		private void InitializeGanttView()
		{
			this.radGanttView1.GanttViewElement.GraphicalViewElement.OnePixelTime = new TimeSpan(0, 3, 0);
			foreach (GanttViewTextViewColumn ganttViewTextViewColumn in this.radGanttView1.Columns)
			{
				ganttViewTextViewColumn.Width = 150;
			}
			this.radGanttView1.Ratio = 0.3102f;
		}

		// Token: 0x06000795 RID: 1941 RVA: 0x0014FD54 File Offset: 0x0014DF54
		private void radGanttView1_TextViewItemFormatting(object sender, GanttViewTextViewItemFormattingEventArgs e)
		{
			bool flag = e.Item.Parent != null;
			if (flag)
			{
				e.ItemElement.BackColor = Color.Beige;
				e.ItemElement.DrawFill = true;
			}
			else
			{
				Appointment appointment = e.Item.DataBoundItem as Appointment;
				IAppointmentBackgroundInfo byId = this.radScheduler1.Backgrounds.GetById(appointment.ResourceId);
				bool flag2 = appointment.BackgroundId == 100;
				if (flag2)
				{
					e.ItemElement.BackColor = Color.FromArgb(102, 102, 255);
				}
				bool flag3 = appointment.BackgroundId == 101;
				if (flag3)
				{
					e.ItemElement.BackColor = Color.FromArgb(255, 0, 127);
				}
				bool flag4 = appointment.BackgroundId == 102;
				if (flag4)
				{
					e.ItemElement.BackColor = Color.PaleGreen;
				}
				bool flag5 = appointment.BackgroundId == 103;
				if (flag5)
				{
					e.ItemElement.BackColor = Color.Aquamarine;
				}
				bool flag6 = appointment.BackgroundId == 104;
				if (flag6)
				{
					e.ItemElement.BackColor = Color.FromArgb(192, 192, 0);
				}
				bool flag7 = appointment.BackgroundId == 105;
				if (flag7)
				{
					e.ItemElement.BackColor = Color.Silver;
				}
				e.ItemElement.DrawFill = true;
			}
		}

		// Token: 0x06000796 RID: 1942 RVA: 0x0014FEBC File Offset: 0x0014E0BC
		private void radGanttView1_GraphicalViewItemFormatting(object sender, GanttViewGraphicalViewItemFormattingEventArgs e)
		{
			Appointment appointment = e.Item.DataBoundItem as Appointment;
			ISchedulerStorage<IAppointmentBackgroundInfo> backgroundStorage = this.radScheduler1.GetBackgroundStorage();
			IAppointmentBackgroundInfo byId = backgroundStorage.GetById(appointment.BackgroundId);
			bool flag = byId != null;
			if (flag)
			{
				e.ItemElement.TaskElement.BackColor = byId.BackColor;
				e.ItemElement.TaskElement.BackColor2 = byId.BackColor2;
				e.ItemElement.TaskElement.BackColor3 = byId.BackColor3;
				e.ItemElement.TaskElement.BackColor4 = byId.BackColor4;
				e.ItemElement.TaskElement.BorderColor = byId.BorderColor;
				e.ItemElement.TaskElement.BorderColor2 = byId.BorderColor2;
				e.ItemElement.TaskElement.BorderColor3 = byId.BorderColor3;
				e.ItemElement.TaskElement.BorderColor4 = byId.BorderColor4;
				e.ItemElement.TaskElement.BorderBoxStyle = byId.BorderBoxStyle;
				e.ItemElement.TaskElement.BorderGradientStyle = byId.BorderGradientStyle;
				e.ItemElement.TaskElement.ForeColor = byId.ForeColor;
				e.ItemElement.TaskElement.GradientAngle = byId.GradientAngle;
				e.ItemElement.TaskElement.GradientStyle = byId.GradientStyle;
				e.ItemElement.TaskElement.GradientPercentage = byId.GradientPercentage;
				e.ItemElement.TaskElement.GradientPercentage2 = byId.GradientPercentage2;
				e.ItemElement.TaskElement.NumberOfColors = byId.NumberOfColors;
				bool flag2 = byId.Font != null;
				if (flag2)
				{
					e.ItemElement.TaskElement.Font = byId.Font;
				}
			}
			IResource byId2 = this.radScheduler1.Resources.GetById(appointment.ResourceId);
			bool flag3 = byId2 != null;
			if (flag3)
			{
				e.ItemElement.BackColor = byId2.Color;
				e.ItemElement.DrawFill = true;
			}
		}

		// Token: 0x06000797 RID: 1943 RVA: 0x001500E4 File Offset: 0x0014E2E4
		private void radGanttView1_TextViewCellFormatting(object sender, GanttViewTextViewCellFormattingEventArgs e)
		{
			bool flag = e.CellElement.Text == "Désignation" | e.CellElement.Text == "Début" | e.CellElement.Text == "Fin";
			if (flag)
			{
				e.CellElement.ForeColor = Color.Firebrick;
			}
			e.CellElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
		}
	}
}
