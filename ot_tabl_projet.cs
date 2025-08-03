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
	// Token: 0x020000D7 RID: 215
	public partial class ot_tabl_projet : Form
	{
		// Token: 0x06000995 RID: 2453 RVA: 0x00187FF8 File Offset: 0x001861F8
		public ot_tabl_projet()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tabl_projet.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tabl_projet.select_changee);
		}

		// Token: 0x06000996 RID: 2454 RVA: 0x0018804B File Offset: 0x0018624B
		private void ot_tabl_projet_Load(object sender, EventArgs e)
		{
			this.select_tableau();
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00188058 File Offset: 0x00186258
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

		// Token: 0x06000998 RID: 2456 RVA: 0x001880DC File Offset: 0x001862DC
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

		// Token: 0x06000999 RID: 2457 RVA: 0x001881E0 File Offset: 0x001863E0
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct ot_projet.id, description, sous_traitant, debut, fin, cout, ordre_travail.n_ot from ot_projet inner join ordre_travail on ot_projet.id_ot = ordre_travail.id where id_ot in (" + str + ")";
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
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[3].ToString(), 1, 10),
						fonction.Mid(dataTable.Rows[i].ItemArray[4].ToString(), 1, 10),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[5]).ToString("0.000"),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}
	}
}
