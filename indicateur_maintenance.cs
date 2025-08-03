using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GMAO
{
	// Token: 0x0200007F RID: 127
	internal class indicateur_maintenance
	{
		// Token: 0x060005F9 RID: 1529 RVA: 0x000FA138 File Offset: 0x000F8338
		public double select_cout_mo(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select id from ot_ressources_fonction where id_ot in (" + str + "))";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x060005FA RID: 1530 RVA: 0x000FA208 File Offset: 0x000F8408
		public double select_cout_pdr(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x060005FB RID: 1531 RVA: 0x000FA314 File Offset: 0x000F8514
		public double select_cout_reparation_externe(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id  where  ot_bl.id_ot in (" + str + ")";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x060005FC RID: 1532 RVA: 0x000FA3E4 File Offset: 0x000F85E4
		public double select_cout_projet(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout) from ot_projet  where  id_ot in (" + str + ")";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x060005FD RID: 1533 RVA: 0x000FA4B4 File Offset: 0x000F86B4
		public double select_cout_mo_corrective(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id  where id_ot in (" + str + ") and type not like '%'  + @p + '%' and statut = @st)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x060005FE RID: 1534 RVA: 0x000FA5C0 File Offset: 0x000F87C0
		public double select_cout_pdr_corrective(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d and type not like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x060005FF RID: 1535 RVA: 0x000FA708 File Offset: 0x000F8908
		public double select_cout_reparation_externe_corrective(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id  where  ot_bl.id_ot in (" + str + ") and type not like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000600 RID: 1536 RVA: 0x000FA814 File Offset: 0x000F8A14
		public double select_cout_projet_corrective(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout) from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + str + ") and type not like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000601 RID: 1537 RVA: 0x000FA920 File Offset: 0x000F8B20
		public double select_cout_mo_preventive(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)) from ot_ordo_intervenant where id_ressource_fonction in(select ot_ressources_fonction.id from ot_ressources_fonction inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id  where id_ot in (" + str + ") and type  like '%'  + @p + '%' and statut = @st)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000602 RID: 1538 RVA: 0x000FAA2C File Offset: 0x000F8C2C
		public double select_cout_pdr_preventive(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d and type  like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000603 RID: 1539 RVA: 0x000FAB74 File Offset: 0x000F8D74
		public double select_cout_reparation_externe_preventive(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(ds_livraison_article.prix_ht) from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id  where  ot_bl.id_ot in (" + str + ") and type like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000604 RID: 1540 RVA: 0x000FAC80 File Offset: 0x000F8E80
		public double select_cout_projet_preventive(List<int> id_ot)
		{
			double result = 0.0;
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout) from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + str + ") and type  like '%'  + @p + '%' and statut = @st";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[0].ItemArray[0]));
				if (flag2)
				{
					result = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
				}
			}
			return result;
		}

		// Token: 0x06000605 RID: 1541 RVA: 0x000FAD8C File Offset: 0x000F8F8C
		public List<double> select_cout_mo_par_type(List<int> id_ot)
		{
			List<double> list = new List<double>();
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout_horaire * (datediff(MINUTE,debut, fin) / 60.0)), ordre_travail.type from ot_ordo_intervenant inner join ot_ressources_fonction on ot_ordo_intervenant.id_ressource_fonction = ot_ressources_fonction.id   inner join ordre_travail on ot_ressources_fonction.id_ot = ordre_travail.id where id_ressource_fonction in(select id from ot_ressources_fonction where id_ot in (" + str + ")) and ordre_travail.statut = @s group by ordre_travail.type";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@s", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			double item = 0.0;
			double item2 = 0.0;
			double item3 = 0.0;
			double item4 = 0.0;
			double item5 = 0.0;
			double item6 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
					if (flag2)
					{
						bool flag3 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Curative";
						if (flag3)
						{
							item = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag4 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Palliative";
						if (flag4)
						{
							item2 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag5 = dataTable.Rows[i].ItemArray[1].ToString() == "Travaux Neufs";
						if (flag5)
						{
							item3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag6 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Systématique";
						if (flag6)
						{
							item4 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag7 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Syst Compteur";
						if (flag7)
						{
							item5 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag8 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Conditionnelle";
						if (flag8)
						{
							item6 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
					}
				}
			}
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
			list.Add(item6);
			return list;
		}

		// Token: 0x06000606 RID: 1542 RVA: 0x000FB0B4 File Offset: 0x000F92B4
		public List<double> select_cout_pdr_par_type(List<int> id_ot)
		{
			List<double> list = new List<double>();
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(bsm_article.quantite * bsm_article.prix_ht), type from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where  ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d  and statut = @st group by type";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			double item = 0.0;
			double item2 = 0.0;
			double item3 = 0.0;
			double item4 = 0.0;
			double item5 = 0.0;
			double item6 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
					if (flag2)
					{
						bool flag3 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Curative";
						if (flag3)
						{
							item = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag4 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Palliative";
						if (flag4)
						{
							item2 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag5 = dataTable.Rows[i].ItemArray[1].ToString() == "Travaux Neufs";
						if (flag5)
						{
							item3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag6 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Systématique";
						if (flag6)
						{
							item4 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag7 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Syst Compteur";
						if (flag7)
						{
							item5 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag8 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Conditionnelle";
						if (flag8)
						{
							item6 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
					}
				}
			}
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
			list.Add(item6);
			return list;
		}

		// Token: 0x06000607 RID: 1543 RVA: 0x000FB418 File Offset: 0x000F9618
		public List<double> select_cout_reparation_externe_par_type(List<int> id_ot)
		{
			List<double> list = new List<double>();
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(ds_livraison_article.prix_ht), type from ot_bl inner join ds_livraison_article on ot_bl.id_liv_article = ds_livraison_article.id inner join ordre_travail on ot_bl.id_ot = ordre_travail.id  where  ot_bl.id_ot in (" + str + ")   and statut = @st group by type";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			double item = 0.0;
			double item2 = 0.0;
			double item3 = 0.0;
			double item4 = 0.0;
			double item5 = 0.0;
			double item6 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
					if (flag2)
					{
						bool flag3 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Curative";
						if (flag3)
						{
							item = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag4 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Palliative";
						if (flag4)
						{
							item2 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag5 = dataTable.Rows[i].ItemArray[1].ToString() == "Travaux Neufs";
						if (flag5)
						{
							item3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag6 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Systématique";
						if (flag6)
						{
							item4 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag7 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Syst Compteur";
						if (flag7)
						{
							item5 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag8 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Conditionnelle";
						if (flag8)
						{
							item6 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
					}
				}
			}
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
			list.Add(item6);
			return list;
		}

		// Token: 0x06000608 RID: 1544 RVA: 0x000FB740 File Offset: 0x000F9940
		public List<double> select_cout_projet_par_type(List<int> id_ot)
		{
			List<double> list = new List<double>();
			bd bd = new bd();
			string str = string.Join<int>(",", id_ot.ToArray());
			string cmdText = "select sum(cout), type from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id  where  id_ot in (" + str + ")  and statut = @st group by type";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@st", SqlDbType.VarChar).Value = "Clôturé";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			double item = 0.0;
			double item2 = 0.0;
			double item3 = 0.0;
			double item4 = 0.0;
			double item5 = 0.0;
			double item6 = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				fonction fonction = new fonction();
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					bool flag2 = fonction.is_reel(Convert.ToString(dataTable.Rows[i].ItemArray[0]));
					if (flag2)
					{
						bool flag3 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Curative";
						if (flag3)
						{
							item = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag4 = dataTable.Rows[i].ItemArray[1].ToString() == "Corrective Palliative";
						if (flag4)
						{
							item2 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag5 = dataTable.Rows[i].ItemArray[1].ToString() == "Travaux Neufs";
						if (flag5)
						{
							item3 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag6 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Systématique";
						if (flag6)
						{
							item4 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag7 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Syst Compteur";
						if (flag7)
						{
							item5 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
						bool flag8 = dataTable.Rows[i].ItemArray[1].ToString() == "Préventive Conditionnelle";
						if (flag8)
						{
							item6 = Convert.ToDouble(dataTable.Rows[i].ItemArray[0]);
						}
					}
				}
			}
			list.Add(item);
			list.Add(item2);
			list.Add(item3);
			list.Add(item4);
			list.Add(item5);
			list.Add(item6);
			return list;
		}
	}
}
