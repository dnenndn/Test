using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace GMAO
{
	// Token: 0x0200003C RID: 60
	internal class classe_ot_notif
	{
		// Token: 0x060002A6 RID: 678 RVA: 0x000705F0 File Offset: 0x0006E7F0
		public static void creer_notif_nbre_intervention(int id_equipement, int delai, int nbr_panne, string des_equipement)
		{
			List<int> list = new List<int>();
			fonction.telecharger_tous_id_enfant(id_equipement, list);
			string str = string.Join<int>(",", list.ToArray());
			bd bd = new bd();
			string cmdText = "with temporary as(select  date_debut, lead(date_debut, @nbr_panne) over (order by date_debut) as t from ordre_travail where equipement in (" + str + ")  and type not like '%'  + @p + '%' and statut <> @a) select   date_debut,min(t), datediff(day, date_debut, min(t))  from temporary where datediff(day, date_debut, t) < @delai group by date_debut";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@nbr_panne", SqlDbType.Int).Value = nbr_panne;
			sqlCommand.Parameters.Add("@delai", SqlDbType.Int).Value = delai;
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select id from utilisateur where (fonction = @a1 or fonction = @a2 or fonction = @a3 or fonction = @a4 or fonction = @a5 or fonction = @a6) and deleted = @d";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@a1", SqlDbType.VarChar).Value = "Administrateur";
			sqlCommand2.Parameters.Add("@a2", SqlDbType.VarChar).Value = "Ingénieur Méthode";
			sqlCommand2.Parameters.Add("@a3", SqlDbType.VarChar).Value = "Responsable Technique";
			sqlCommand2.Parameters.Add("@a4", SqlDbType.VarChar).Value = "Responsable Maintenance";
			sqlCommand2.Parameters.Add("@a5", SqlDbType.VarChar).Value = "Responsable Méthode";
			sqlCommand2.Parameters.Add("@a6", SqlDbType.VarChar).Value = "Agent de Méthode";
			sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			List<int> list2 = new List<int>();
			for (int i = 0; i < dataTable2.Rows.Count; i++)
			{
				list2.Add(Convert.ToInt32(dataTable2.Rows[i].ItemArray[0]));
			}
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					string cmdText3 = "select count(id) from ordre_travail where date_debut between @d1 and @d2 and statut <> @a and type not like '%'  + @p + '%'";
					SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
					sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = dataTable.Rows[j].ItemArray[0];
					sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = dataTable.Rows[j].ItemArray[1];
					sqlCommand3.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
					sqlCommand3.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					int num = 0;
					bool flag2 = dataTable3.Rows.Count != 0;
					if (flag2)
					{
						num = Convert.ToInt32(dataTable3.Rows[0].ItemArray[0]);
					}
					string cmdText4 = "select id from notification where id_n = @n and type = @t and date_creation = @d";
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
					sqlCommand4.Parameters.Add("@n", SqlDbType.Int).Value = id_equipement;
					sqlCommand4.Parameters.Add("@t", SqlDbType.VarChar).Value = "OT Nbr Panne";
					sqlCommand4.Parameters.Add("@d", SqlDbType.Date).Value = dataTable.Rows[j].ItemArray[0];
					SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable4 = new DataTable();
					sqlDataAdapter4.Fill(dataTable4);
					bool flag3 = dataTable4.Rows.Count == 0;
					if (flag3)
					{
						for (int k = 0; k < list2.Count; k++)
						{
							string cmdText5 = "insert into notification (id_n, type, id_utilisateur, description, vue, date_creation) values (@v1, @v2, @v3, @v4, @v5, @v6)";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							sqlCommand5.Parameters.Add("@v1", SqlDbType.Int).Value = id_equipement;
							sqlCommand5.Parameters.Add("@v2", SqlDbType.VarChar).Value = "OT Nbr Panne";
							sqlCommand5.Parameters.Add("@v3", SqlDbType.Int).Value = list2[k];
							DbParameter dbParameter = sqlCommand5.Parameters.Add("@v4", SqlDbType.VarChar);
							string[] array = new string[13];
							array[0] = "Nombre des Pannes (";
							array[1] = num.ToString();
							array[2] = ") dépasse le nombre prévu (";
							array[3] = nbr_panne.ToString();
							array[4] = ") dans une période de (";
							array[5] = delai.ToString();
							array[6] = ") Jour pour l'équipement : ";
							array[7] = des_equipement;
							array[8] = " entre la date ";
							int num2 = 9;
							object obj = dataTable.Rows[j].ItemArray[0];
							array[num2] = ((obj != null) ? obj.ToString() : null);
							array[10] = " et ";
							int num3 = 11;
							object obj2 = dataTable.Rows[j].ItemArray[1];
							array[num3] = ((obj2 != null) ? obj2.ToString() : null);
							array[12] = " ";
							dbParameter.Value = string.Concat(array);
							sqlCommand5.Parameters.Add("@v5", SqlDbType.Int).Value = 0;
							sqlCommand5.Parameters.Add("@v6", SqlDbType.Date).Value = dataTable.Rows[j].ItemArray[0];
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x00070BEC File Offset: 0x0006EDEC
		public static void notification()
		{
			bd bd = new bd();
			string cmdText = "select id_equipement, cout_arrêt, nbre_arrêt, periode_nbr, periode, equipement.designation from equipement_prevision inner join equipement on equipement_prevision.id_equipement = equipement.id where equipement.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int id_equipement = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					int num = Convert.ToInt32(dataTable.Rows[i].ItemArray[3]);
					int nbr_panne = Convert.ToInt32(dataTable.Rows[i].ItemArray[2]);
					string des_equipement = Convert.ToString(dataTable.Rows[i].ItemArray[5]);
					bool flag2 = Convert.ToString(dataTable.Rows[i].ItemArray[4]) == "Semaine";
					if (flag2)
					{
						num *= 7;
					}
					bool flag3 = Convert.ToString(dataTable.Rows[i].ItemArray[4]) == "Mois";
					if (flag3)
					{
						num *= 30;
					}
					bool flag4 = Convert.ToString(dataTable.Rows[i].ItemArray[4]) == "Année";
					if (flag4)
					{
						num *= 365;
					}
					bool flag5 = num != 0;
					if (flag5)
					{
						classe_ot_notif.creer_notif_nbre_intervention(id_equipement, num, nbr_panne, des_equipement);
					}
				}
			}
		}
	}
}
