using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000A3 RID: 163
	public partial class ot_agenda_employe : Form
	{
		// Token: 0x06000781 RID: 1921 RVA: 0x0014D90E File Offset: 0x0014BB0E
		public ot_agenda_employe()
		{
			this.InitializeComponent();
			this.radScheduler1.AppointmentFormatting += this.RadScheduler1_AppointmentFormatting;
		}

		// Token: 0x06000782 RID: 1922 RVA: 0x0014D940 File Offset: 0x0014BB40
		private void ot_agenda_employe_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radScheduler1.ActiveViewType = 0;
			this.radScheduler1.ActiveView.StartDate = this.radDateTimePicker1.Value;
			this.remplissage_calendrier();
		}

		// Token: 0x06000783 RID: 1923 RVA: 0x0014D990 File Offset: 0x0014BB90
		private void RadScheduler1_AppointmentFormatting(object sender, SchedulerAppointmentEventArgs e)
		{
			Font font = new Font("Verdana", 8f, FontStyle.Regular);
			e.AppointmentElement.Font = font;
			e.AppointmentElement.ForeColor = Color.White;
			e.AppointmentElement.UseDefaultPaint = true;
			e.AppointmentElement.BorderBoxStyle = 0;
			e.AppointmentElement.BorderWidth = 1f;
		}

		// Token: 0x06000784 RID: 1924 RVA: 0x0014D9F8 File Offset: 0x0014BBF8
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.radScheduler1.ActiveView.StartDate = this.radDateTimePicker1.Value;
		}

		// Token: 0x06000785 RID: 1925 RVA: 0x0014DA18 File Offset: 0x0014BC18
		private void remplissage_calendrier()
		{
			this.radScheduler1.Appointments.Clear();
			bd bd = new bd();
			string text = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = string.Concat(new string[]
			{
				"select distinct intervenant.id, intervenant.nom from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where (ot_ordo_intervenant.id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ordre_travail.statut = @a and ordre_travail.id in (",
				text,
				") and type not like '%'+ @k + '%') and id_ressource_fonction in (select id_ressource_fonction from ot_ordo_intervention)) or (ot_ordo_intervenant.id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ordre_travail.statut = @a and ordre_travail.id in (",
				text,
				") and type  like '%'+ @k + '%')) "
			});
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				Color[] array = new Color[]
				{
					Color.Beige,
					Color.Khaki,
					Color.LightYellow
				};
				Resource resource = new Resource();
				resource.Id = new EventId(i);
				resource.Name = dataTable.Rows[i].ItemArray[1].ToString();
				resource.Color = array[i % 3];
				this.radScheduler1.Resources.Add(resource);
			}
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.radScheduler1.GetDayView().ResourcesPerView = 3;
				this.radScheduler1.GroupType = 1;
				SchedulerDayViewGroupedByResourceElement schedulerDayViewGroupedByResourceElement = this.radScheduler1.SchedulerElement.ViewElement as SchedulerDayViewGroupedByResourceElement;
				schedulerDayViewGroupedByResourceElement.ResourceHeaderHeight = 135;
			}
			for (int j = 0; j < dataTable.Rows.Count; j++)
			{
				this.remplissage_preventive(j, dataTable.Rows[j].ItemArray[0].ToString(), text);
				string cmdText2 = "select ot_ordo_intervenant.id, intervenant.nom, debut, fin, id_ressource_fonction, intervenant.id from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where ot_ordo_intervenant.id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ordre_travail.statut = @a and ordre_travail.id in (" + text + ") and type not like '%'+ @k + '%') and id_ressource_fonction in (select id_ressource_fonction from ot_ordo_intervention) and intervenant.id = @h";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@k", SqlDbType.VarChar).Value = "Préventive";
				sqlCommand2.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
				sqlCommand2.Parameters.Add("@h", SqlDbType.VarChar).Value = dataTable.Rows[j].ItemArray[0].ToString();
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					AppointmentBackgroundInfo item = new AppointmentBackgroundInfo(100, "c0", Color.Aquamarine, Color.Aquamarine);
					this.radScheduler1.Backgrounds.Add(item);
					AppointmentBackgroundInfo item2 = new AppointmentBackgroundInfo(101, "c1", Color.FromArgb(255, 0, 127), Color.FromArgb(255, 0, 127));
					this.radScheduler1.Backgrounds.Add(item2);
					AppointmentBackgroundInfo item3 = new AppointmentBackgroundInfo(102, "c2", Color.PaleGreen, Color.PaleGreen);
					this.radScheduler1.Backgrounds.Add(item3);
					for (int k = 0; k < dataTable2.Rows.Count; k++)
					{
						string text2 = "";
						string cmdText3 = "select id_operation, type_operation from ot_ordo_intervention where id_ressource_fonction = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable2.Rows[k].ItemArray[4].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						string a = "";
						string text3 = "";
						bool flag3 = dataTable3.Rows.Count != 0;
						if (flag3)
						{
							a = dataTable3.Rows[0].ItemArray[1].ToString();
							bool flag4 = a == "Intervention";
							if (flag4)
							{
								string cmdText4 = "select intervention from parametre_intervention where id = @i";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable3.Rows[0].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
								DataTable dataTable4 = new DataTable();
								sqlDataAdapter4.Fill(dataTable4);
								bool flag5 = dataTable4.Rows.Count != 0;
								if (flag5)
								{
									text3 = dataTable4.Rows[0].ItemArray[0].ToString();
								}
							}
							bool flag6 = a == "Réparation" | a == "Test";
							if (flag6)
							{
								string cmdText5 = "select designation from operation_maintenance where id = @i";
								SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
								sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable3.Rows[0].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
								DataTable dataTable5 = new DataTable();
								sqlDataAdapter5.Fill(dataTable5);
								bool flag7 = dataTable5.Rows.Count != 0;
								if (flag7)
								{
									text3 = dataTable5.Rows[0].ItemArray[0].ToString();
								}
							}
							bool flag8 = a == "Diagnostic";
							if (flag8)
							{
								string cmdText6 = "select designation from operation_diagnostic where id = @i";
								SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
								sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable3.Rows[0].ItemArray[0].ToString();
								SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
								DataTable dataTable6 = new DataTable();
								sqlDataAdapter6.Fill(dataTable6);
								bool flag9 = dataTable6.Rows.Count != 0;
								if (flag9)
								{
									text3 = dataTable6.Rows[0].ItemArray[0].ToString();
								}
							}
							text2 = text3;
						}
						string value = dataTable2.Rows[k].ItemArray[2].ToString();
						string value2 = dataTable2.Rows[k].ItemArray[3].ToString();
						DateTime dateTime = default(DateTime);
						dateTime = Convert.ToDateTime(value);
						DateTime d = default(DateTime);
						d = Convert.ToDateTime(value2);
						TimeSpan timeSpan = default(TimeSpan);
						Appointment appointment = new Appointment(dateTime, TimeSpan.FromMinutes((d - dateTime).TotalMinutes), text2, "");
						appointment.StatusId = 2;
						bool flag10 = a == "Intervention" | a == "Réparation";
						if (flag10)
						{
							appointment.BackgroundId = 100;
						}
						bool flag11 = a == "Test";
						if (flag11)
						{
							appointment.BackgroundId = 102;
						}
						bool flag12 = a == "Diagnostic";
						if (flag12)
						{
							appointment.BackgroundId = 101;
						}
						appointment.ResourceId = this.radScheduler1.Resources[j].Id;
						this.radScheduler1.Appointments.Add(appointment);
					}
				}
			}
		}

		// Token: 0x06000786 RID: 1926 RVA: 0x0014E1A4 File Offset: 0x0014C3A4
		private void remplissage_preventive(int h, string chaine, string liste_id)
		{
			bd bd = new bd();
			string cmdText = "select ot_ordo_intervenant.id, intervenant.nom, debut, fin, id_ressource_fonction, intervenant.id, ordre_travail.id_intervention from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ot_ordo_intervenant.id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where ordre_travail.statut = @a and ordre_travail.id in (" + liste_id + ") and type  like '%'+ @k + '%')  and intervenant.id = @h";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@k", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			sqlCommand.Parameters.Add("@h", SqlDbType.VarChar).Value = chaine;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				AppointmentBackgroundInfo item = new AppointmentBackgroundInfo(104, "c0", Color.DimGray, Color.DimGray);
				this.radScheduler1.Backgrounds.Add(item);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					string cmdText2 = "select designation from gamme_operatoire where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[6].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						text = dataTable2.Rows[0].ItemArray[0].ToString();
					}
					string text2 = text;
					string value = dataTable.Rows[i].ItemArray[2].ToString();
					string value2 = dataTable.Rows[i].ItemArray[3].ToString();
					DateTime dateTime = default(DateTime);
					dateTime = Convert.ToDateTime(value);
					DateTime d = default(DateTime);
					d = Convert.ToDateTime(value2);
					TimeSpan timeSpan = default(TimeSpan);
					Appointment appointment = new Appointment(dateTime, TimeSpan.FromMinutes((d - dateTime).TotalMinutes), text2, "");
					appointment.StatusId = 2;
					appointment.BackgroundId = 104;
					appointment.ResourceId = this.radScheduler1.Resources[h].Id;
					this.radScheduler1.Appointments.Add(appointment);
				}
			}
		}
	}
}
