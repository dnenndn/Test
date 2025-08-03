using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000D3 RID: 211
	public partial class ot_tabl_bsm : Form
	{
		// Token: 0x06000975 RID: 2421 RVA: 0x00184E68 File Offset: 0x00183068
		public ot_tabl_bsm()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tabl_bsm.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tabl_bsm.select_changee);
		}

		// Token: 0x06000976 RID: 2422 RVA: 0x00184EBB File Offset: 0x001830BB
		private void ot_tabl_bsm_Load(object sender, EventArgs e)
		{
			this.select_bsm();
		}

		// Token: 0x06000977 RID: 2423 RVA: 0x00184EC8 File Offset: 0x001830C8
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

		// Token: 0x06000978 RID: 2424 RVA: 0x00184F4C File Offset: 0x0018314C
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

		// Token: 0x06000979 RID: 2425 RVA: 0x00185050 File Offset: 0x00183250
		private void select_bsm()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct bsm_article.id, id_bsm, bsm.date_bsm, bsm.heure_bsm, article.code_article, article.reference, article.designation, bsm_article.quantite, parametre_unite_article.designation, bsm_article.prix_ht, (bsm_article.quantite * bsm_article.prix_ht), ordre_travail.n_ot from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join article on bsm_article.id_article = article.id inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on  tableau_article_unite.id_unite = parametre_unite_article.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where ordre_travail.id in (" + str + ") and type_stock <> @v and bsm_article.quantite <> @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Réparable";
			sqlCommand.Parameters.Add("@d", SqlDbType.Real).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[11].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[7].ToString(),
						dataTable.Rows[i].ItemArray[8].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[9]).ToString("0.000"),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[10]).ToString("0.000")
					});
				}
			}
		}
	}
}
