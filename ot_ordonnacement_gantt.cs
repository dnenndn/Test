using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000C8 RID: 200
	public partial class ot_ordonnacement_gantt : Form
	{
		// Token: 0x060008EC RID: 2284 RVA: 0x001782AC File Offset: 0x001764AC
		public ot_ordonnacement_gantt()
		{
			this.InitializeComponent();
			this.radGanttView1.GanttViewElement.GraphicalViewElement.TimelineRange = 1;
			this.radGanttView1.TextViewCellFormatting += new GanttViewTextViewCellFormattingEventHandler(this.radGanttView1_TextViewCellFormatting);
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x00178300 File Offset: 0x00176500
		private void radGanttView1_TextViewCellFormatting(object sender, GanttViewTextViewCellFormattingEventArgs e)
		{
			bool flag = e.CellElement.Text == "Désignation" | e.CellElement.Text == "Début" | e.CellElement.Text == "Fin";
			if (flag)
			{
				e.CellElement.ForeColor = Color.Firebrick;
			}
			e.CellElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x00178384 File Offset: 0x00176584
		private void select_gantt()
		{
			this.radGanttView1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select distinct id_intervenant, intervenant.nom from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i order by intervenant.nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select min(debut), max(fin) from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				this.radGanttView1.GanttViewElement.GraphicalViewElement.TimelineStart = Convert.ToDateTime(dataTable2.Rows[0].ItemArray[0]);
				this.radGanttView1.GanttViewElement.GraphicalViewElement.TimelineEnd = Convert.ToDateTime(dataTable2.Rows[0].ItemArray[1]);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText3 = "select debut, fin, ot_ressources_fonction.id from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i and id_intervenant = @v";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					sqlCommand3.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					string cmdText4 = "select min(debut), max(fin) from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i and id_intervenant = @v";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
					sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					sqlCommand4.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable4 = new DataTable();
					sqlDataAdapter4.Fill(dataTable4);
					GanttViewDataItem ganttViewDataItem = new GanttViewDataItem();
					ganttViewDataItem.Start = Convert.ToDateTime(dataTable4.Rows[0].ItemArray[0]);
					ganttViewDataItem.End = Convert.ToDateTime(dataTable4.Rows[0].ItemArray[1]);
					ganttViewDataItem.Progress = 150m;
					ganttViewDataItem.Title = dataTable.Rows[i].ItemArray[1].ToString();
					for (int j = 0; j < dataTable3.Rows.Count; j++)
					{
						GanttViewDataItem ganttViewDataItem2 = new GanttViewDataItem();
						ganttViewDataItem2.Start = Convert.ToDateTime(dataTable3.Rows[j].ItemArray[0]);
						ganttViewDataItem2.End = Convert.ToDateTime(dataTable3.Rows[j].ItemArray[1]);
						ganttViewDataItem2.Progress = 30m;
						int id_or = Convert.ToInt32(dataTable3.Rows[j].ItemArray[2]);
						ganttViewDataItem2.Title = this.afficher_operation(j, id_or);
						ganttViewDataItem.Items.Add(ganttViewDataItem2);
					}
					this.radGanttView1.Items.Add(ganttViewDataItem);
				}
				GanttViewTextViewColumn item = new GanttViewTextViewColumn("Title");
				GanttViewTextViewColumn item2 = new GanttViewTextViewColumn("Start");
				GanttViewTextViewColumn item3 = new GanttViewTextViewColumn("End");
				this.radGanttView1.GanttViewElement.Columns.Add(item);
				this.radGanttView1.GanttViewElement.Columns.Add(item2);
				this.radGanttView1.GanttViewElement.Columns.Add(item3);
				this.radGanttView1.GanttViewElement.Columns[0].Width = 200;
				this.radGanttView1.GanttViewElement.Columns[1].Width = 150;
				this.radGanttView1.GanttViewElement.Columns[2].Width = 150;
				this.radGanttView1.GanttViewElement.Columns[0].HeaderText = "Désignation";
				this.radGanttView1.GanttViewElement.Columns[1].HeaderText = "Début";
				this.radGanttView1.GanttViewElement.Columns[2].HeaderText = "Fin";
			}
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x00178874 File Offset: 0x00176A74
		private void ot_ordonnacement_gantt_Load(object sender, EventArgs e)
		{
			bool flag = ot_liste.type_ot_tr.Contains("Préventive");
			if (flag)
			{
				this.select_gantt_preventive();
			}
			else
			{
				this.select_gantt();
			}
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x001788AC File Offset: 0x00176AAC
		private string afficher_operation(int k, int id_or)
		{
			bd bd = new bd();
			string result = "Tâche " + (k + 1).ToString();
			string cmdText = "select id_operation, type_operation from ot_ordo_intervention where id_ressource_fonction = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id_or;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string a = dataTable.Rows[0].ItemArray[1].ToString();
				bool flag2 = a == "Test" | a == "Réparation";
				if (flag2)
				{
					string cmdText2 = "select designation from operation_maintenance where id = @i";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count != 0;
					if (flag3)
					{
						result = dataTable2.Rows[0].ItemArray[0].ToString();
					}
				}
				bool flag4 = a == "Diagnostic";
				if (flag4)
				{
					string cmdText3 = "select designation from operation_diagnostic where id = @i";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag5 = dataTable3.Rows.Count != 0;
					if (flag5)
					{
						result = dataTable3.Rows[0].ItemArray[0].ToString();
					}
				}
				bool flag6 = a == "Intervention";
				if (flag6)
				{
					string cmdText4 = "select intervention from parametre_intervention where id = @i";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
					sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable4 = new DataTable();
					sqlDataAdapter4.Fill(dataTable4);
					bool flag7 = dataTable4.Rows.Count != 0;
					if (flag7)
					{
						result = dataTable4.Rows[0].ItemArray[0].ToString();
					}
				}
			}
			return result;
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x00178B64 File Offset: 0x00176D64
		private void select_gantt_preventive()
		{
			this.radGanttView1.Items.Clear();
			bd bd = new bd();
			string cmdText = "select distinct id_intervenant, intervenant.nom from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i order by intervenant.nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select min(debut), max(fin) from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				this.radGanttView1.GanttViewElement.GraphicalViewElement.TimelineStart = Convert.ToDateTime(dataTable2.Rows[0].ItemArray[0]);
				this.radGanttView1.GanttViewElement.GraphicalViewElement.TimelineEnd = Convert.ToDateTime(dataTable2.Rows[0].ItemArray[1]);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText3 = "select debut, fin from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i and id_intervenant = @v";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					sqlCommand3.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					string cmdText4 = "select min(debut), max(fin) from ot_ressources_fonction inner join ot_ordo_intervenant on ot_ressources_fonction.id = ot_ordo_intervenant.id_ressource_fonction inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ot = @i and id_intervenant = @v";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
					sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					sqlCommand4.Parameters.Add("@v", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable4 = new DataTable();
					sqlDataAdapter4.Fill(dataTable4);
					GanttViewDataItem ganttViewDataItem = new GanttViewDataItem();
					ganttViewDataItem.Start = Convert.ToDateTime(dataTable4.Rows[0].ItemArray[0]);
					ganttViewDataItem.End = Convert.ToDateTime(dataTable4.Rows[0].ItemArray[1]);
					ganttViewDataItem.Progress = 150m;
					ganttViewDataItem.Title = dataTable.Rows[i].ItemArray[1].ToString();
					for (int j = 0; j < dataTable3.Rows.Count; j++)
					{
						GanttViewDataItem ganttViewDataItem2 = new GanttViewDataItem();
						ganttViewDataItem2.Start = Convert.ToDateTime(dataTable3.Rows[j].ItemArray[0]);
						ganttViewDataItem2.End = Convert.ToDateTime(dataTable3.Rows[j].ItemArray[1]);
						ganttViewDataItem2.Progress = 30m;
						ganttViewDataItem2.Title = "Tâche " + (j + 1).ToString();
						ganttViewDataItem.Items.Add(ganttViewDataItem2);
					}
					this.radGanttView1.Items.Add(ganttViewDataItem);
				}
				GanttViewTextViewColumn item = new GanttViewTextViewColumn("Title");
				GanttViewTextViewColumn item2 = new GanttViewTextViewColumn("Start");
				GanttViewTextViewColumn item3 = new GanttViewTextViewColumn("End");
				this.radGanttView1.GanttViewElement.Columns.Add(item);
				this.radGanttView1.GanttViewElement.Columns.Add(item2);
				this.radGanttView1.GanttViewElement.Columns.Add(item3);
				this.radGanttView1.GanttViewElement.Columns[0].Width = 200;
				this.radGanttView1.GanttViewElement.Columns[1].Width = 150;
				this.radGanttView1.GanttViewElement.Columns[2].Width = 150;
				this.radGanttView1.GanttViewElement.Columns[0].HeaderText = "Désignation";
				this.radGanttView1.GanttViewElement.Columns[1].HeaderText = "Début";
				this.radGanttView1.GanttViewElement.Columns[2].HeaderText = "Fin";
			}
		}
	}
}
