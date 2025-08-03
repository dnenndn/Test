using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000003 RID: 3
	public partial class acceuil_stock_liste_article : Form
	{
		// Token: 0x06000021 RID: 33 RVA: 0x000064C8 File Offset: 0x000046C8
		public acceuil_stock_liste_article()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(acceuil_stock_liste_article.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(acceuil_stock_liste_article.select_changee);
		}

		// Token: 0x06000022 RID: 34 RVA: 0x0000651B File Offset: 0x0000471B
		private void acceuil_stock_liste_article_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00006528 File Offset: 0x00004728
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

		// Token: 0x06000024 RID: 36 RVA: 0x000065AC File Offset: 0x000047AC
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

		// Token: 0x06000025 RID: 37 RVA: 0x000066B0 File Offset: 0x000048B0
		private void remplissage_tableau()
		{
			this.radGridView3.Rows.Clear();
            bd bd = new bd();
            string cmdText = "SELECT designation, stock_neuf FROM article WHERE stock_neuf < stock_min";
            System.Data.SqlClient.SqlCommand sqlCommand = new System.Data.SqlClient.SqlCommand(cmdText, bd.cnn);
            System.Data.SqlClient.SqlDataAdapter sqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter(sqlCommand);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            sqlDataAdapter.Fill(dataTable);

            for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				this.radGridView3.Rows.Add(new object[]
				{
					dataTable.Rows[i]["designation"],
					dataTable.Rows[i]["stock_neuf"]
				});
			}
		}
	}
}
