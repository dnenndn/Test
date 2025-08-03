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
	// Token: 0x020000D8 RID: 216
	public partial class ot_tabl_reservation : Form
	{
		// Token: 0x0600099C RID: 2460 RVA: 0x001888C8 File Offset: 0x00186AC8
		public ot_tabl_reservation()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tabl_reservation.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tabl_reservation.select_changee);
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0018891B File Offset: 0x00186B1B
		private void ot_tabl_reservation_Load(object sender, EventArgs e)
		{
			this.select_pdr();
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x00188928 File Offset: 0x00186B28
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

		// Token: 0x0600099F RID: 2463 RVA: 0x001889AC File Offset: 0x00186BAC
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

		// Token: 0x060009A0 RID: 2464 RVA: 0x00188AB0 File Offset: 0x00186CB0
		public void select_pdr()
		{
			bd bd = new bd();
			this.radGridView3.Rows.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct ot_ressources_pdr.id, code_article, reference, article.designation, quantite, parametre_unite_article.designation, date_sh, ordre_travail.n_ot from ot_ressources_pdr inner join article on ot_ressources_pdr.id_article = article.id inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id inner join ordre_travail on ot_ressources_pdr.id_ot = ordre_travail.id where id_ot in (" + str + ") ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
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
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}
	}
}
