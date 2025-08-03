using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;

namespace GMAO
{
	// Token: 0x02000165 RID: 357
	public partial class tb_flux_achat : Form
	{
		// Token: 0x06000FA0 RID: 4000 RVA: 0x0025C148 File Offset: 0x0025A348
		public tb_flux_achat()
		{
			this.InitializeComponent();
			this.radCheckedListBox1.ItemCheckedChanged += new ListViewItemEventHandler(this.RadCheckedListBox1_ItemCheckedChanged);
			this.radCheckedListBox1.VisualItemFormatting += new ListViewVisualItemEventHandler(this.RadCheckedListBox1_VisualItemFormatting);
			this.radCheckedListBox2.VisualItemFormatting += new ListViewVisualItemEventHandler(this.RadCheckedListBox1_VisualItemFormatting);
			this.radCheckedListBox3.VisualItemFormatting += new ListViewVisualItemEventHandler(this.RadCheckedListBox1_VisualItemFormatting);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(tb_flux_achat.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(tb_flux_achat.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(tb_flux_achat.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(tb_flux_achat.select_changee);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(tb_flux_achat.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(tb_flux_achat.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
			this.get_famille();
			this.get_activite();
		}

		// Token: 0x06000FA1 RID: 4001 RVA: 0x0025C2C0 File Offset: 0x0025A4C0
		private void RadCheckedListBox1_VisualItemFormatting(object sender, ListViewVisualItemEventArgs e)
		{
			e.VisualItem.BorderBoxStyle = 1;
			e.VisualItem.BorderBottomColor = Color.Firebrick;
			bool flag = e.VisualItem.Selected | e.VisualItem.ContainsMouse;
			if (flag)
			{
				e.VisualItem.BackColor = Color.White;
				e.VisualItem.ForeColor = Color.Firebrick;
			}
		}

		// Token: 0x06000FA2 RID: 4002 RVA: 0x0025C32C File Offset: 0x0025A52C
		private void RadCheckedListBox1_ItemCheckedChanged(object sender, ListViewItemEventArgs e)
		{
			bool flag = e.Item.CheckState == 1;
			if (flag)
			{
				string id_f = Convert.ToString(e.Item.Tag);
				this.get_sous_famille(id_f);
			}
			else
			{
				this.delete_get_sous_famille(e.Item.Tag.ToString());
			}
		}

		// Token: 0x06000FA3 RID: 4003 RVA: 0x0025C384 File Offset: 0x0025A584
		private void tb_flux_achat_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau_1();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
			}
			bool flag2 = this.radGridView2.Rows.Count != 0;
			if (flag2)
			{
				this.radGridView2.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x06000FA4 RID: 4004 RVA: 0x0025C3FC File Offset: 0x0025A5FC
		private void get_famille()
		{
			bd bd = new bd();
			this.radCheckedListBox1.Items.Clear();
			string cmdText = "select id, designation from famille where deleted = @d order by designation";
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
					this.radCheckedListBox1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedListBox1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					this.radCheckedListBox1.Items[i].CheckState = 1;
				}
			}
		}

		// Token: 0x06000FA5 RID: 4005 RVA: 0x0025C520 File Offset: 0x0025A720
		private void get_activite()
		{
			bd bd = new bd();
			this.radCheckedListBox3.Items.Clear();
			string cmdText = "select id, designation from activite where deleted = @d order by designation";
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
					this.radCheckedListBox3.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedListBox3.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					this.radCheckedListBox3.Items[i].CheckState = 1;
				}
			}
		}

		// Token: 0x06000FA6 RID: 4006 RVA: 0x0025C644 File Offset: 0x0025A844
		private void get_sous_famille(string id_f)
		{
			bd bd = new bd();
			string cmdText = "select id, designation from sous_famille where deleted = @d and id_famille = @f order by designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = id_f;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int count = this.radCheckedListBox2.Items.Count;
					this.radCheckedListBox2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedListBox2.Items[count].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					this.radCheckedListBox2.Items[count].Key = id_f;
					this.radCheckedListBox2.Items[count].CheckState = 1;
				}
			}
		}

		// Token: 0x06000FA7 RID: 4007 RVA: 0x0025C79C File Offset: 0x0025A99C
		private void radButton1_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
			{
				this.radCheckedListBox1.Items[i].CheckState = 1;
			}
		}

		// Token: 0x06000FA8 RID: 4008 RVA: 0x0025C7E4 File Offset: 0x0025A9E4
		private void delete_get_sous_famille(string id_f)
		{
			for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
			{
				bool flag = this.radCheckedListBox2.Items[i].Key.ToString() == id_f;
				if (flag)
				{
					this.radCheckedListBox2.Items.RemoveAt(i);
					i--;
				}
			}
		}

		// Token: 0x06000FA9 RID: 4009 RVA: 0x0025C850 File Offset: 0x0025AA50
		private void radButton2_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
			{
				this.radCheckedListBox2.Items[i].CheckState = 1;
			}
		}

		// Token: 0x06000FAA RID: 4010 RVA: 0x0025C898 File Offset: 0x0025AA98
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

		// Token: 0x06000FAB RID: 4011 RVA: 0x0025C91C File Offset: 0x0025AB1C
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

		// Token: 0x06000FAC RID: 4012 RVA: 0x0025CA20 File Offset: 0x0025AC20
		private void remplissage_tableau_1()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			this.radGridView1.Rows.Clear();
			this.radGridView2.Rows.Clear();
			this.radGridView3.Rows.Clear();
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			this.radGridView2.MasterView.TableSearchRow.SuspendSearch();
			this.nbr_tot_commande = 0;
			this.nbr_tot_commande_st = 0;
			this.montant_tot_commande = 0.0;
			this.montant_tot_commande_st = 0.0;
			this.nbr_tot_reception = 0;
			this.nbr_tot_reception_st = 0;
			this.montant_tot_bl_non_facture = 0.0;
			this.montant_tot_bl_non_facture_st = 0.0;
			this.montant_tot_bl_facture = 0.0;
			this.montant_tot_bl_facture_st = 0.0;
			this.cmp = 0;
			for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
			{
				bool flag = this.radCheckedListBox2.Items[i].CheckState == 1;
				if (flag)
				{
					list.Add(this.radCheckedListBox2.Items[i].Tag.ToString());
				}
			}
			for (int j = 0; j < this.radCheckedListBox1.Items.Count; j++)
			{
				bool flag2 = this.radCheckedListBox1.Items[j].CheckState == 1;
				if (flag2)
				{
					list2.Add(this.radCheckedListBox1.Items[j].Tag.ToString());
				}
			}
			for (int k = 0; k < this.radCheckedListBox3.Items.Count; k++)
			{
				bool flag3 = this.radCheckedListBox3.Items[k].CheckState == 1;
				if (flag3)
				{
					list3.Add(this.radCheckedListBox3.Items[k].Tag.ToString());
				}
			}
			bool flag4 = list.Count != 0 | list3.Count != 0;
			if (flag4)
			{
				this.ProgressBar1.Value = 0;
				this.ProgressBar1.MaximumValue = list.Count + list3.Count;
				this.ProgressBar1.Show();
				this.cmp = list.Count;
			}
			bool flag5 = list.Count != 0;
			if (flag5)
			{
				string text = string.Join(",", list.ToArray());
				this.get_commande_tot_attente(text);
				this.get_commande_tot(text);
				this.get_reception_tot(text);
				this.get_BL_tot_f(text);
				this.get_BL_tot_nf(text);
				double num = this.montant_tot_bl_non_facture + this.montant_tot_bl_facture;
				this.radGridView1.Rows.Add(new object[]
				{
					"Total",
					this.montant_cmnd_attente.ToString("0.000"),
					this.nbr_tot_commande,
					this.montant_tot_commande.ToString("0.000"),
					this.nbr_tot_reception,
					this.montant_tot_bl_non_facture.ToString("0.000"),
					this.montant_tot_bl_facture.ToString("0.000"),
					num.ToString("0.000")
				});
				bool isChecked = this.radRadioButton1.IsChecked;
				if (isChecked)
				{
					this.get_detail_famille(list2, text);
				}
				else
				{
					this.get_detail(list);
				}
				ListSortDirection listSortDirection = ListSortDirection.Descending;
				this.radGridView1.EnableSorting = true;
				this.radGridView1.MasterTemplate.SortDescriptors.Add("column5", listSortDirection);
			}
			bool flag6 = list3.Count != 0;
			if (flag6)
			{
				string liste_id = string.Join(",", list3.ToArray());
				this.get_commande_tot_st_attente(liste_id);
				this.get_commande_tot_st(liste_id);
				this.get_reception_tot_st(liste_id);
				this.get_BL_tot_f_st(liste_id);
				this.get_BL_tot_nf_st(liste_id);
				double num2 = this.montant_tot_bl_non_facture_st + this.montant_tot_bl_facture_st;
				this.radGridView2.Rows.Add(new object[]
				{
					"Total",
					this.montant_cmnd_attente_st.ToString("0.000"),
					this.nbr_tot_commande_st,
					this.montant_tot_commande_st.ToString("0.000"),
					this.nbr_tot_reception_st,
					this.montant_tot_bl_non_facture_st.ToString("0.000"),
					this.montant_tot_bl_facture_st.ToString("0.000"),
					num2.ToString("0.000")
				});
				this.get_detail_activite(list3);
				ListSortDirection listSortDirection2 = ListSortDirection.Descending;
				this.radGridView2.EnableSorting = true;
				this.radGridView2.MasterTemplate.SortDescriptors.Add("column5", listSortDirection2);
			}
			this.ProgressBar1.Hide();
			int num3 = this.nbr_tot_commande + this.nbr_tot_commande_st;
			double num4 = this.montant_cmnd_attente_st + this.montant_cmnd_attente;
			double num5 = this.montant_tot_commande + this.montant_tot_commande_st;
			int num6 = this.nbr_tot_reception + this.nbr_tot_reception_st;
			double num7 = this.montant_tot_bl_non_facture + this.montant_tot_bl_non_facture_st;
			double num8 = this.montant_tot_bl_facture + this.montant_tot_bl_facture_st;
			double num9 = num7 + num8;
			this.radGridView3.Rows.Add(new object[]
			{
				num3,
				num4.ToString("0.000"),
				num5.ToString("0.000"),
				num6,
				num7.ToString("0.000"),
				num8.ToString("0.000"),
				num9.ToString("0.000")
			});
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			this.radGridView2.MasterView.TableSearchRow.ResumeSearch();
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView2.MasterView.TableSearchRow.ShowCloseButton = false;
		}

		// Token: 0x06000FAD RID: 4013 RVA: 0x0025D070 File Offset: 0x0025B270
		private void radButton3_Click(object sender, EventArgs e)
		{
			this.remplissage_tableau_1();
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
			}
			bool flag2 = this.radGridView2.Rows.Count != 0;
			if (flag2)
			{
				this.radGridView2.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x06000FAE RID: 4014 RVA: 0x0025D0E8 File Offset: 0x0025B2E8
		private void get_reception_tot(string liste_id)
		{
			this.nbr_tot_reception = 0;
			bd bd = new bd();
			string cmdText = "select reception.id  from reception inner join reception_article on reception.id = reception_article.id_reception  where reception_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and date_reel between @d1 and @d2 group by reception.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				int count = dataTable.Rows.Count;
				this.nbr_tot_reception = count;
			}
		}

		// Token: 0x06000FAF RID: 4015 RVA: 0x0025D1B8 File Offset: 0x0025B3B8
		private void get_reception_tot_st(string liste_id)
		{
			this.nbr_tot_reception_st = 0;
			bd bd = new bd();
			string cmdText = "select ds_bon_livraison.id from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where ds_commande_article.id_activite in (" + liste_id + ") and date_reel between @d1 and @d2 group by ds_bon_livraison.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				int count = dataTable.Rows.Count;
				this.nbr_tot_reception_st = count;
			}
		}

		// Token: 0x06000FB0 RID: 4016 RVA: 0x0025D288 File Offset: 0x0025B488
		private void get_commande_tot(string liste_id)
		{
			this.montant_tot_commande = 0.0;
			this.nbr_tot_commande = 0;
			bd bd = new bd();
			string cmdText = "select commande.id, sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut <> @d and statut <> @f and date_commande between @d1 and @d2 group by commande.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 5;
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				int count = dataTable.Rows.Count;
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.nbr_tot_commande = count;
				this.montant_tot_commande = num;
			}
		}

		// Token: 0x06000FB1 RID: 4017 RVA: 0x0025D3FC File Offset: 0x0025B5FC
		private void get_commande_tot_st(string liste_id)
		{
			this.montant_tot_commande_st = 0.0;
			this.nbr_tot_commande_st = 0;
			bd bd = new bd();
			string cmdText = "select ds_commande.id, sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande  where ds_commande_article.id_activite in (" + liste_id + ") and statut <> @d and statut <> @f and date_commande between @d1 and @d2 group by ds_commande.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 5;
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				int count = dataTable.Rows.Count;
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.nbr_tot_commande_st = count;
				this.montant_tot_commande_st = num;
			}
		}

		// Token: 0x06000FB2 RID: 4018 RVA: 0x0025D570 File Offset: 0x0025B770
		private void get_BL_tot_nf(string liste_id)
		{
			this.montant_tot_bl_non_facture = 0.0;
			bd bd = new bd();
			string cmdText = "select bon_livraison.id, sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where date_reel between @d1 and @d2 and statut = @f and livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   group by bon_livraison.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.montant_tot_bl_non_facture = num;
			}
		}

		// Token: 0x06000FB3 RID: 4019 RVA: 0x0025D6A8 File Offset: 0x0025B8A8
		private void get_BL_tot_nf_st(string liste_id)
		{
			this.montant_tot_bl_non_facture_st = 0.0;
			bd bd = new bd();
			string cmdText = "select ds_bon_livraison.id, sum(ds_livraison_article.qt * ds_livraison_article.prix_ht - (ds_livraison_article.remise/100)*(ds_livraison_article.qt * ds_livraison_article.prix_ht)) from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where date_reel between @d1 and @d2 and statut = @f and ds_commande_article.id_activite in (" + liste_id + ")  group by ds_bon_livraison.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.montant_tot_bl_non_facture_st = num;
			}
		}

		// Token: 0x06000FB4 RID: 4020 RVA: 0x0025D7E0 File Offset: 0x0025B9E0
		private void get_BL_tot_f(string liste_id)
		{
			this.montant_tot_bl_facture = 0.0;
			bd bd = new bd();
			string cmdText = "select bon_livraison.id, sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where date_reel between @d1 and @d2 and statut = @f and livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + "))   group by bon_livraison.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.montant_tot_bl_facture = num;
			}
		}

		// Token: 0x06000FB5 RID: 4021 RVA: 0x0025D918 File Offset: 0x0025BB18
		private void get_BL_tot_f_st(string liste_id)
		{
			this.montant_tot_bl_facture_st = 0.0;
			bd bd = new bd();
			string cmdText = "select ds_bon_livraison.id, sum(ds_livraison_article.qt * ds_livraison_article.prix_ht - (ds_livraison_article.remise/100)*(ds_livraison_article.qt * ds_livraison_article.prix_ht)) from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where date_reel between @d1 and @d2 and statut = @f and ds_commande_article.id_activite in (" + liste_id + ")  group by ds_bon_livraison.id";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.Int).Value = 1;
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.montant_tot_bl_facture_st = num;
			}
		}

		// Token: 0x06000FB6 RID: 4022 RVA: 0x0025DA50 File Offset: 0x0025BC50
		private void get_detail_activite(List<string> id_act)
		{
			for (int i = 0; i < id_act.Count; i++)
			{
				bd bd = new bd();
				string cmdText = "select designation from activite where id = @m";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = id_act[i];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string text = dataTable.Rows[0].ItemArray[0].ToString();
				int num = 0;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = 0;
				double num5 = 0.0;
				double num6 = 0.0;
				string cmdText2 = "select ds_commande.id, sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande  where ds_commande_article.id_activite = @m and statut <> @d and statut <> @f and date_commande between @d1 and @d2 group by ds_commande.id";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 5;
				sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = id_act[i];
				sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag = dataTable2.Rows.Count != 0;
				if (flag)
				{
					num = dataTable2.Rows.Count;
					double num7 = 0.0;
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						num7 += Math.Round(Convert.ToDouble(dataTable2.Rows[j].ItemArray[1]), 3);
					}
					num2 = num7;
				}
				string cmdText3 = "select ds_bon_livraison.id from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where ds_commande_article.id_activite  = @m and date_reel between @d1 and @d2 group by ds_bon_livraison.id";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = id_act[i];
				sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				bool flag2 = dataTable3.Rows.Count != 0;
				if (flag2)
				{
					num4 = dataTable3.Rows.Count;
				}
				string cmdText4 = "select ds_bon_livraison.id, sum(ds_livraison_article.qt * ds_livraison_article.prix_ht - (ds_livraison_article.remise/100)*(ds_livraison_article.qt * ds_livraison_article.prix_ht)) from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where date_reel between @d1 and @d2 and statut = @f and ds_commande_article.id_activite = @m  group by ds_bon_livraison.id";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 0;
				sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = id_act[i];
				sqlCommand4.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand4.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag3 = dataTable4.Rows.Count != 0;
				if (flag3)
				{
					double num8 = 0.0;
					for (int k = 0; k < dataTable4.Rows.Count; k++)
					{
						num8 += Math.Round(Convert.ToDouble(dataTable4.Rows[k].ItemArray[1]), 3);
					}
					num5 = num8;
				}
				string cmdText5 = "select ds_bon_livraison.id, sum(ds_livraison_article.qt * ds_livraison_article.prix_ht - (ds_livraison_article.remise/100)*(ds_livraison_article.qt * ds_livraison_article.prix_ht)) from ds_bon_livraison inner join ds_livraison_article on ds_bon_livraison.id = ds_livraison_article.id_livraison inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where date_reel between @d1 and @d2 and statut = @f and ds_commande_article.id_activite = @m  group by ds_bon_livraison.id";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
				sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 1;
				sqlCommand5.Parameters.Add("@m", SqlDbType.Int).Value = id_act[i];
				sqlCommand5.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand5.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
				DataTable dataTable5 = new DataTable();
				sqlDataAdapter5.Fill(dataTable5);
				bool flag4 = dataTable5.Rows.Count != 0;
				if (flag4)
				{
					double num9 = 0.0;
					for (int l = 0; l < dataTable5.Rows.Count; l++)
					{
						num9 += Math.Round(Convert.ToDouble(dataTable5.Rows[l].ItemArray[1]), 3);
					}
					num6 = num9;
				}
				double num10 = num5 + num6;
				string cmdText6 = "select ds_commande.id, sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande  where ds_commande_article.id_activite = @m and statut = @d  and date_commande between @d1 and @d2 group by ds_commande.id";
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
				sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = id_act[i];
				sqlCommand6.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand6.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
				DataTable dataTable6 = new DataTable();
				sqlDataAdapter6.Fill(dataTable6);
				bool flag5 = dataTable6.Rows.Count != 0;
				if (flag5)
				{
					double num11 = 0.0;
					for (int m = 0; m < dataTable6.Rows.Count; m++)
					{
						num11 += Math.Round(Convert.ToDouble(dataTable6.Rows[m].ItemArray[1]), 3);
					}
					num3 = num11;
				}
				bool flag6 = num10 != 0.0 | num != 0 | num4 != 0 | num2 != 0.0;
				if (flag6)
				{
					this.radGridView2.Rows.Add(new object[]
					{
						text,
						num3.ToString("0.000"),
						num,
						num2.ToString("0.000"),
						num4,
						num5.ToString("0.000"),
						num6.ToString("0.000"),
						num10.ToString("0.000")
					});
				}
				this.ProgressBar1.Value = this.cmp + i + 1;
			}
		}

		// Token: 0x06000FB7 RID: 4023 RVA: 0x0025E198 File Offset: 0x0025C398
		private void get_detail(List<string> id_sf)
		{
			for (int i = 0; i < id_sf.Count; i++)
			{
				bd bd = new bd();
				string cmdText = "select designation from sous_famille where id = @m";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = id_sf[i];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string text = dataTable.Rows[0].ItemArray[0].ToString();
				int num = 0;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = 0;
				double num5 = 0.0;
				double num6 = 0.0;
				string cmdText2 = "select commande.id, sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut <> @d and statut <> @f and date_commande between @d1 and @d2 group by commande.id";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 5;
				sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = id_sf[i];
				sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag = dataTable2.Rows.Count != 0;
				if (flag)
				{
					num = dataTable2.Rows.Count;
					double num7 = 0.0;
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						num7 += Math.Round(Convert.ToDouble(dataTable2.Rows[j].ItemArray[1]), 3);
					}
					num2 = num7;
				}
				string cmdText3 = "select reception.id  from reception inner join reception_article on reception.id = reception_article.id_reception  where reception_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and date_reel between @d1 and @d2 group by reception.id";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = id_sf[i];
				sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				bool flag2 = dataTable3.Rows.Count != 0;
				if (flag2)
				{
					num4 = dataTable3.Rows.Count;
				}
				string cmdText4 = "select bon_livraison.id, sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where date_reel between @d1 and @d2 and statut = @f and livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   group by bon_livraison.id";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 0;
				sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = id_sf[i];
				sqlCommand4.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand4.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag3 = dataTable4.Rows.Count != 0;
				if (flag3)
				{
					double num8 = 0.0;
					for (int k = 0; k < dataTable4.Rows.Count; k++)
					{
						num8 += Math.Round(Convert.ToDouble(dataTable4.Rows[k].ItemArray[1]), 3);
					}
					num5 = num8;
				}
				string cmdText5 = "select bon_livraison.id, sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where date_reel between @d1 and @d2 and statut = @f and livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m)   group by bon_livraison.id";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
				sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 1;
				sqlCommand5.Parameters.Add("@m", SqlDbType.Int).Value = id_sf[i];
				sqlCommand5.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand5.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
				DataTable dataTable5 = new DataTable();
				sqlDataAdapter5.Fill(dataTable5);
				bool flag4 = dataTable5.Rows.Count != 0;
				if (flag4)
				{
					double num9 = 0.0;
					for (int l = 0; l < dataTable5.Rows.Count; l++)
					{
						num9 += Math.Round(Convert.ToDouble(dataTable5.Rows[l].ItemArray[1]), 3);
					}
					num6 = num9;
				}
				double num10 = num5 + num6;
				string cmdText6 = "select commande.id, sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille = @m) and statut = @d  and date_commande between @d1 and @d2 group by commande.id";
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
				sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = id_sf[i];
				sqlCommand6.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand6.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
				DataTable dataTable6 = new DataTable();
				sqlDataAdapter6.Fill(dataTable6);
				bool flag5 = dataTable6.Rows.Count != 0;
				if (flag5)
				{
					double num11 = 0.0;
					for (int m = 0; m < dataTable2.Rows.Count; m++)
					{
						num11 += Math.Round(Convert.ToDouble(dataTable6.Rows[m].ItemArray[1]), 3);
					}
					num3 = num11;
				}
				bool flag6 = num10 != 0.0 | num != 0 | num4 != 0 | num2 != 0.0;
				if (flag6)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						text,
						num3.ToString("0.000"),
						num,
						num2.ToString("0.000"),
						num4,
						num5.ToString("0.000"),
						num6.ToString("0.000"),
						num10.ToString("0.000")
					});
				}
				this.ProgressBar1.Value = i + 1;
			}
		}

		// Token: 0x06000FB8 RID: 4024 RVA: 0x0025E8DC File Offset: 0x0025CADC
		private void get_detail_famille(List<string> id_f, string abb)
		{
			for (int i = 0; i < id_f.Count; i++)
			{
				bd bd = new bd();
				string cmdText = "select designation from famille where id = @m";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@m", SqlDbType.Int).Value = id_f[i];
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				string text = dataTable.Rows[0].ItemArray[0].ToString();
				int num = 0;
				double num2 = 0.0;
				double num3 = 0.0;
				int num4 = 0;
				double num5 = 0.0;
				double num6 = 0.0;
				string cmdText2 = "select commande.id, sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille = @m and id in (" + abb + "))) and statut <> @d and statut <> @f and date_commande between @d1 and @d2 group by commande.id";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 5;
				sqlCommand2.Parameters.Add("@f", SqlDbType.Int).Value = 0;
				sqlCommand2.Parameters.Add("@m", SqlDbType.Int).Value = id_f[i];
				sqlCommand2.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand2.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag = dataTable2.Rows.Count != 0;
				if (flag)
				{
					num = dataTable2.Rows.Count;
					double num7 = 0.0;
					for (int j = 0; j < dataTable2.Rows.Count; j++)
					{
						num7 += Math.Round(Convert.ToDouble(dataTable2.Rows[j].ItemArray[1]), 3);
					}
					num2 = num7;
				}
				string cmdText3 = "select reception.id  from reception inner join reception_article on reception.id = reception_article.id_reception  where reception_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille = @m and id in (" + abb + "))) and date_reel between @d1 and @d2 group by reception.id";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@m", SqlDbType.Int).Value = id_f[i];
				sqlCommand3.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand3.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
				DataTable dataTable3 = new DataTable();
				sqlDataAdapter3.Fill(dataTable3);
				bool flag2 = dataTable3.Rows.Count != 0;
				if (flag2)
				{
					num4 = dataTable3.Rows.Count;
				}
				string cmdText4 = "select bon_livraison.id, sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where date_reel between @d1 and @d2 and statut = @f and livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille = @m and id in (" + abb + ")))    group by bon_livraison.id";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@f", SqlDbType.Int).Value = 0;
				sqlCommand4.Parameters.Add("@m", SqlDbType.Int).Value = id_f[i];
				sqlCommand4.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand4.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
				DataTable dataTable4 = new DataTable();
				sqlDataAdapter4.Fill(dataTable4);
				bool flag3 = dataTable4.Rows.Count != 0;
				if (flag3)
				{
					double num8 = 0.0;
					for (int k = 0; k < dataTable4.Rows.Count; k++)
					{
						num8 += Math.Round(Convert.ToDouble(dataTable4.Rows[k].ItemArray[1]), 3);
					}
					num5 = num8;
				}
				string cmdText5 = "select bon_livraison.id, sum(livraison_article.qt * livraison_article.prix_ht - (livraison_article.remise/100)*(livraison_article.qt * livraison_article.prix_ht)) from bon_livraison inner join livraison_article on bon_livraison.id = livraison_article.id_livraison where date_reel between @d1 and @d2 and statut = @f and livraison_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille = @m and id in (" + abb + ")))    group by bon_livraison.id";
				SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
				sqlCommand5.Parameters.Add("@f", SqlDbType.Int).Value = 1;
				sqlCommand5.Parameters.Add("@m", SqlDbType.Int).Value = id_f[i];
				sqlCommand5.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand5.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
				DataTable dataTable5 = new DataTable();
				sqlDataAdapter5.Fill(dataTable5);
				bool flag4 = dataTable5.Rows.Count != 0;
				if (flag4)
				{
					double num9 = 0.0;
					for (int l = 0; l < dataTable5.Rows.Count; l++)
					{
						num9 += Math.Round(Convert.ToDouble(dataTable5.Rows[l].ItemArray[1]), 3);
					}
					num6 = num9;
				}
				double num10 = num5 + num6;
				string cmdText6 = "select commande.id, sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (select id from sous_famille where id_famille = @m and id in (" + abb + "))) and statut = @d  and date_commande between @d1 and @d2 group by commande.id";
				SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
				sqlCommand6.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand6.Parameters.Add("@m", SqlDbType.Int).Value = id_f[i];
				sqlCommand6.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
				sqlCommand6.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
				DataTable dataTable6 = new DataTable();
				sqlDataAdapter6.Fill(dataTable6);
				bool flag5 = dataTable6.Rows.Count != 0;
				if (flag5)
				{
					double num11 = 0.0;
					for (int m = 0; m < dataTable6.Rows.Count; m++)
					{
						num11 += Math.Round(Convert.ToDouble(dataTable6.Rows[m].ItemArray[1]), 3);
					}
					num3 = num11;
				}
				bool flag6 = num10 != 0.0 | num != 0 | num4 != 0 | num2 != 0.0;
				if (flag6)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						text,
						num3.ToString("0.000"),
						num,
						num2.ToString("0.000"),
						num4,
						num5.ToString("0.000"),
						num6.ToString("0.000"),
						num10.ToString("0.000")
					});
				}
				this.ProgressBar1.Value = i + 1;
			}
		}

		// Token: 0x06000FB9 RID: 4025 RVA: 0x0025F054 File Offset: 0x0025D254
		private void radButton4_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox1.Items.Count; i++)
			{
				this.radCheckedListBox1.Items[i].CheckState = 0;
			}
		}

		// Token: 0x06000FBA RID: 4026 RVA: 0x0025F09C File Offset: 0x0025D29C
		private void radButton5_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox2.Items.Count; i++)
			{
				this.radCheckedListBox2.Items[i].CheckState = 0;
			}
		}

		// Token: 0x06000FBB RID: 4027 RVA: 0x0025F0E4 File Offset: 0x0025D2E4
		private void radButton7_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox3.Items.Count; i++)
			{
				this.radCheckedListBox3.Items[i].CheckState = 1;
			}
		}

		// Token: 0x06000FBC RID: 4028 RVA: 0x0025F12C File Offset: 0x0025D32C
		private void radButton6_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < this.radCheckedListBox3.Items.Count; i++)
			{
				this.radCheckedListBox3.Items[i].CheckState = 0;
			}
		}

		// Token: 0x06000FBD RID: 4029 RVA: 0x0025F174 File Offset: 0x0025D374
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(this.radGridView1)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(this.radGridView1.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x06000FBE RID: 4030 RVA: 0x0025F1E4 File Offset: 0x0025D3E4
		private void RunExportToexcel_2(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(this.radGridView2)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x06000FBF RID: 4031 RVA: 0x0025F244 File Offset: 0x0025D444
		private void radButton8_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "";
			saveFileDialog.ShowDialog();
			bool flag = false;
			bool flag2 = saveFileDialog.FileName != "";
			if (flag2)
			{
				this.RunExportToexcel(saveFileDialog.FileName, ref flag);
			}
		}

		// Token: 0x06000FC0 RID: 4032 RVA: 0x0025F294 File Offset: 0x0025D494
		private void radButton9_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "";
			saveFileDialog.ShowDialog();
			bool flag = false;
			bool flag2 = saveFileDialog.FileName != "";
			if (flag2)
			{
				this.RunExportToexcel_2(saveFileDialog.FileName, ref flag);
			}
		}

		// Token: 0x06000FC1 RID: 4033 RVA: 0x0025F2E4 File Offset: 0x0025D4E4
		private void get_commande_tot_attente(string liste_id)
		{
			this.montant_cmnd_attente = 0.0;
			bd bd = new bd();
			string cmdText = "select commande.id, sum(commande_article.qt_commande * commande_article.prix_ht - (commande_article.remise/100)*(commande_article.qt_commande * commande_article.prix_ht)) from commande inner join commande_article on commande.id = commande_article.id_commande inner join da_article on commande_article.id_da_article = da_article.id  where da_article.id_article in (select id_article from tableau_article_sous_famille where id_sous_famille in (" + liste_id + ")) and statut = @d and  date_commande between @d1 and @d2 group by commande.id";
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
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.montant_cmnd_attente = num;
			}
		}

		// Token: 0x06000FC2 RID: 4034 RVA: 0x0025F41C File Offset: 0x0025D61C
		private void get_commande_tot_st_attente(string liste_id)
		{
			this.montant_cmnd_attente_st = 0.0;
			bd bd = new bd();
			string cmdText = "select ds_commande.id, sum(ds_commande_article.qt * ds_commande_article.prix_ht - (ds_commande_article.remise/100)*(ds_commande_article.qt * ds_commande_article.prix_ht)) from ds_commande inner join ds_commande_article on ds_commande.id = ds_commande_article.id_commande  where ds_commande_article.id_activite in (" + liste_id + ") and statut = @d  and date_commande between @d1 and @d2 group by ds_commande.id";
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
				double num = 0.0;
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					num += Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[1]), 3);
				}
				this.montant_cmnd_attente_st = num;
			}
		}

		// Token: 0x040013BF RID: 5055
		private int nbr_tot_commande;

		// Token: 0x040013C0 RID: 5056
		private double montant_tot_commande;

		// Token: 0x040013C1 RID: 5057
		private double montant_cmnd_attente;

		// Token: 0x040013C2 RID: 5058
		private double montant_cmnd_attente_st;

		// Token: 0x040013C3 RID: 5059
		private int nbr_tot_reception;

		// Token: 0x040013C4 RID: 5060
		private double montant_tot_bl_non_facture;

		// Token: 0x040013C5 RID: 5061
		private double montant_tot_bl_facture;

		// Token: 0x040013C6 RID: 5062
		private int nbr_tot_commande_st;

		// Token: 0x040013C7 RID: 5063
		private double montant_tot_commande_st;

		// Token: 0x040013C8 RID: 5064
		private int nbr_tot_reception_st;

		// Token: 0x040013C9 RID: 5065
		private double montant_tot_bl_non_facture_st;

		// Token: 0x040013CA RID: 5066
		private double montant_tot_bl_facture_st;

		// Token: 0x040013CB RID: 5067
		private int cmp = 0;
	}
}
