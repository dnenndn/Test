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
	// Token: 0x020000D4 RID: 212
	public partial class ot_tabl_externe : Form
	{
		// Token: 0x0600097C RID: 2428 RVA: 0x0018590C File Offset: 0x00183B0C
		public ot_tabl_externe()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tabl_externe.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tabl_externe.select_changee);
		}

		// Token: 0x0600097D RID: 2429 RVA: 0x0018595F File Offset: 0x00183B5F
		private void ot_tabl_externe_Load(object sender, EventArgs e)
		{
			this.select_st();
		}

		// Token: 0x0600097E RID: 2430 RVA: 0x0018596C File Offset: 0x00183B6C
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

		// Token: 0x0600097F RID: 2431 RVA: 0x001859F0 File Offset: 0x00183BF0
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

		// Token: 0x06000980 RID: 2432 RVA: 0x00185AF4 File Offset: 0x00183CF4
		private void select_st()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select ds_historique_mvt.id_t, article.code_article,magasin_sous_traitance.ref_interne, article.designation, ordre_travail.n_ot, ordre_travail.id from ds_historique_mvt inner join bsm on ds_historique_mvt.id_mvt = bsm.id inner join ordre_travail on bsm.n_ot = ordre_travail.n_ot inner join magasin_sous_traitance on ds_historique_mvt.id_t = magasin_sous_traitance.id inner join article on magasin_sous_traitance.id_article = article.id where mvt = @b and ordre_travail.id in (" + str + ")";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
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
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[5].ToString();
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
						dataTable.Rows[i].ItemArray[4].ToString(),
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
	}
}
