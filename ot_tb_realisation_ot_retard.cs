using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000E2 RID: 226
	public partial class ot_tb_realisation_ot_retard : Form
	{
		// Token: 0x060009E9 RID: 2537 RVA: 0x0018E8FC File Offset: 0x0018CAFC
		public ot_tb_realisation_ot_retard()
		{
			this.InitializeComponent();
			this.radChartView1.ShowTrackBall = true;
		}

		// Token: 0x060009EA RID: 2538 RVA: 0x0018E924 File Offset: 0x0018CB24
		private void ot_tb_realisation_ot_retard_Load(object sender, EventArgs e)
		{
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select count(id) from ordre_travail where id  in (" + str + ") and debut_prevu > convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120) and statut = @a";
			string cmdText2 = "select count(id) from ordre_travail where id  in (" + str + ") and ( datediff(minute,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120))/60.0 <=1) and ( datediff(minute,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120))/60.0 >= 0)  and statut = @a";
			string cmdText3 = "select count(id) from ordre_travail where id  in (" + str + ") and ( datediff(day,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120)) = 0) and ( datediff(minute,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120))/60.0 > 1)  and statut = @a";
			string cmdText4 = "select count(id) from ordre_travail where id  in (" + str + ") and ( datediff(day,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120)) = 1)  and statut = @a";
			string cmdText5 = "select count(id) from ordre_travail where id  in (" + str + ") and ( datediff(day,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120)) > 1) and ( datediff(day,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120)) <= 7)  and statut = @a";
			string cmdText6 = "select count(id) from ordre_travail where id  in (" + str + ") and ( datediff(day,debut_prevu , convert(datetime,concat(date_debut,@espace, heure_debut, @wa),120)) > 7)  and statut = @a";
			string cmdText7 = "select count(id) from ordre_travail where id  in (" + str + ")  and statut = @a";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand2.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand2.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
			sqlCommand3.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand3.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand3.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
			DataTable dataTable3 = new DataTable();
			sqlDataAdapter3.Fill(dataTable3);
			SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
			sqlCommand4.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand4.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand4.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
			DataTable dataTable4 = new DataTable();
			sqlDataAdapter4.Fill(dataTable4);
			SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
			sqlCommand5.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand5.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand5.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
			DataTable dataTable5 = new DataTable();
			sqlDataAdapter5.Fill(dataTable5);
			SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
			sqlCommand6.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand6.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			sqlCommand6.Parameters.Add("@a", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
			DataTable dataTable6 = new DataTable();
			sqlDataAdapter6.Fill(dataTable6);
			SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd.cnn);
			sqlCommand7.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			SqlDataAdapter sqlDataAdapter7 = new SqlDataAdapter(sqlCommand7);
			DataTable dataTable7 = new DataTable();
			sqlDataAdapter7.Fill(dataTable7);
			int item = 0;
			int item2 = 0;
			int item3 = 0;
			int item4 = 0;
			int item5 = 0;
			int item6 = 0;
			int item7 = 0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				item = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
			}
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				item2 = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
			}
			bool flag3 = dataTable3.Rows.Count != 0;
			if (flag3)
			{
				item3 = Convert.ToInt32(dataTable3.Rows[0].ItemArray[0]);
			}
			bool flag4 = dataTable4.Rows.Count != 0;
			if (flag4)
			{
				item4 = Convert.ToInt32(dataTable4.Rows[0].ItemArray[0]);
			}
			bool flag5 = dataTable5.Rows.Count != 0;
			if (flag5)
			{
				item5 = Convert.ToInt32(dataTable5.Rows[0].ItemArray[0]);
			}
			bool flag6 = dataTable6.Rows.Count != 0;
			if (flag6)
			{
				item6 = Convert.ToInt32(dataTable6.Rows[0].ItemArray[0]);
			}
			bool flag7 = dataTable7.Rows.Count != 0;
			if (flag7)
			{
				item7 = Convert.ToInt32(dataTable7.Rows[0].ItemArray[0]);
			}
			FunnelSeries funnelSeries = new FunnelSeries();
			funnelSeries.DynamicHeight = true;
			funnelSeries.SegmentSpacing = 20;
			funnelSeries.NeckRatio = 0.2f;
			funnelSeries.ShowLabels = true;
			List<int> list = new List<int>();
			List<string> list2 = new List<string>();
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
			list.Add(item6);
			list.Add(item7);
			list2.Add("OT Réalisé en avance");
			list2.Add("OT Réalisé dans l'heure");
			list2.Add("OT Réalisé dans la journée");
			list2.Add("OT Réalisé après une journée");
			list2.Add("OT Réalisé avec moin d'une semain");
			list2.Add("OT Réalisé avec plus d'une semaine");
			list2.Add("OT Annulé");
			for (int num = this.test_list(list); num == 0; num = this.test_list(list))
			{
				for (int i = 0; i < 6; i++)
				{
					bool flag8 = list[i] > list[i + 1];
					if (flag8)
					{
						int value = list[i];
						string value2 = list2[i];
						list[i] = list[i + 1];
						list2[i] = list2[i + 1];
						list[i + 1] = value;
						list2[i + 1] = value2;
						list2[i + 1] = value2;
					}
				}
			}
			for (int j = 0; j < 7; j++)
			{
				funnelSeries.DataPoints.Add(new FunnelDataPoint((double)list[j], list2[j]));
			}
			this.radChartView1.Series.Clear();
			this.radChartView1.Series.Add(funnelSeries);
			this.radChartView1.ShowLegend = true;
			this.radChartView1.View.Palette = KnownPalette.Material;
		}

		// Token: 0x060009EB RID: 2539 RVA: 0x0018F0C8 File Offset: 0x0018D2C8
		private int test_list(List<int> l)
		{
			int result = 1;
			for (int i = 0; i < 6; i++)
			{
				bool flag = l[i] > l[i + 1];
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}
	}
}
