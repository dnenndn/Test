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
	// Token: 0x020000AA RID: 170
	public partial class ot_bt_bsm : Form
	{
		// Token: 0x060007C4 RID: 1988 RVA: 0x001555E8 File Offset: 0x001537E8
		public ot_bt_bsm()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_bt_bsm.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_bt_bsm.select_changee);
		}

		// Token: 0x060007C5 RID: 1989 RVA: 0x0015563B File Offset: 0x0015383B
		private void ot_bt_bsm_Load(object sender, EventArgs e)
		{
			this.select_bsm();
		}

		// Token: 0x060007C6 RID: 1990 RVA: 0x00155648 File Offset: 0x00153848
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

		// Token: 0x060007C7 RID: 1991 RVA: 0x001556CC File Offset: 0x001538CC
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

		// Token: 0x060007C8 RID: 1992 RVA: 0x001557D0 File Offset: 0x001539D0
		private void select_bsm()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id_bsm, bsm.date_bsm, bsm.heure_bsm, article.code_article, article.reference, article.designation, bsm_article.quantite, parametre_unite_article.designation, bsm_article.prix_ht, (bsm_article.quantite * bsm_article.prix_ht) from bsm_article inner join bsm on bsm_article.id_bsm = bsm.id inner join article on bsm_article.id_article = article.id inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on  tableau_article_unite.id_unite = parametre_unite_article.id inner join ordre_travail on bsm.li_ot = ordre_travail.id where ordre_travail.id = @i and type_stock <> @v and bsm_article.quantite <> @d ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
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
						dataTable.Rows[i].ItemArray[0].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[7].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[8]).ToString("0.000"),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[9]).ToString("0.000")
					});
				}
			}
		}
	}
}
