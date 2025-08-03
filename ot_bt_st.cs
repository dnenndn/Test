using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000B1 RID: 177
	public partial class ot_bt_st : Form
	{
		// Token: 0x060007FB RID: 2043 RVA: 0x0015B588 File Offset: 0x00159788
		public ot_bt_st()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_bt_st.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_bt_st.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.RadGridView3_CellClick);
		}

		// Token: 0x060007FC RID: 2044 RVA: 0x0015B5F4 File Offset: 0x001597F4
		private void RadGridView3_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 8;
			if (flag)
			{
				ot_bt_st.id_t = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
				bd bd = new bd();
				string cmdText = "select distinct ds_livraison_article.id, id_livraison from ds_livraison_article inner join ds_commande_article on ds_livraison_article.id_ds_commande_article = ds_commande_article.id where id_t = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_bt_st.id_t;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				this.radDropDownList1.Items.Clear();
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
						this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					}
				}
				this.radGridView3.Size = new Size(1050, 144);
				this.panel1.Show();
			}
		}

		// Token: 0x060007FD RID: 2045 RVA: 0x0015B773 File Offset: 0x00159973
		private void ot_bt_st_Load(object sender, EventArgs e)
		{
			this.pictureBox3_Click(sender, e);
			this.select_st();
		}

		// Token: 0x060007FE RID: 2046 RVA: 0x0015B788 File Offset: 0x00159988
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

		// Token: 0x060007FF RID: 2047 RVA: 0x0015B80C File Offset: 0x00159A0C
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

		// Token: 0x06000800 RID: 2048 RVA: 0x0015B910 File Offset: 0x00159B10
		private void select_st()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select ds_historique_mvt.id_t, article.code_article,magasin_sous_traitance.ref_interne, article.designation from ds_historique_mvt inner join bsm on ds_historique_mvt.id_mvt = bsm.id inner join ordre_travail on bsm.n_ot = ordre_travail.n_ot inner join magasin_sous_traitance on ds_historique_mvt.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id where mvt = @b and ordre_travail.id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			sqlCommand.Parameters.Add("@b", SqlDbType.VarChar).Value = "BSM";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string cmdText2 = "select ds_bon_livraison.id, fournisseur.nom, ds_bon_livraison.date_reel,ds_livraison_article.prix_ht from ds_livraison_article inner join ds_bon_livraison on ds_livraison_article.id_livraison = ds_bon_livraison.id inner join fournisseur on ds_bon_livraison.id_fournisseur = fournisseur.id  where ds_livraison_article.id in (select id_liv_article from ot_bl where id_ot = @i1 and id_t = @i2)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag2 = dataTable2.Rows.Count != 0;
					if (flag2)
					{
						text = dataTable2.Rows[0].ItemArray[0].ToString();
						text2 = dataTable2.Rows[0].ItemArray[1].ToString();
						text3 = fonction.Mid(dataTable2.Rows[0].ItemArray[2].ToString(), 1, 10);
						text4 = Convert.ToDouble(dataTable2.Rows[0].ItemArray[3]).ToString("0.000");
					}
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						text,
						text2,
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						text3,
						text4,
						Resources.icons8_approuver_et_mettre_à_jour_96__4_
					});
				}
			}
		}

		// Token: 0x06000801 RID: 2049 RVA: 0x0015BBC4 File Offset: 0x00159DC4
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radGridView3.Size = new Size(1050, 219);
		}

		// Token: 0x06000802 RID: 2050 RVA: 0x0015BBF0 File Offset: 0x00159DF0
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "delete ot_bl where id_t = @i1 and id_ot = @i2";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = ot_bt_st.id_t;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				string cmdText2 = "insert into ot_bl (id_liv_article, id_ot, id_t) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag.ToString();
				sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = ot_liste.id_ot_tr;
				sqlCommand2.Parameters.Add("@v3", SqlDbType.Int).Value = ot_bt_st.id_t;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
				MessageBox.Show("Enregistrement avec succés");
				this.pictureBox3_Click(sender, e);
				this.select_st();
			}
			else
			{
				MessageBox.Show("Erreur :Choisir un BL", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04000AF7 RID: 2807
		private static int id_t;
	}
}
