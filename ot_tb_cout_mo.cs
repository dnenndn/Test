using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000DC RID: 220
	public partial class ot_tb_cout_mo : Form
	{
		// Token: 0x060009B8 RID: 2488 RVA: 0x0018A2D4 File Offset: 0x001884D4
		public ot_tb_cout_mo()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tb_cout_mo.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tb_cout_mo.select_changee);
		}

		// Token: 0x060009B9 RID: 2489 RVA: 0x0018A327 File Offset: 0x00188527
		private void ot_tb_cout_mo_Load(object sender, EventArgs e)
		{
			this.select_tableau();
		}

		// Token: 0x060009BA RID: 2490 RVA: 0x0018A334 File Offset: 0x00188534
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

		// Token: 0x060009BB RID: 2491 RVA: 0x0018A3B8 File Offset: 0x001885B8
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

		// Token: 0x060009BC RID: 2492 RVA: 0x0018A4BC File Offset: 0x001886BC
		private void select_tableau()
		{
			bd bd = new bd();
			this.label1.Text = "";
			this.radGridView3.Rows.Clear();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select intervenant.nom,cout_horaire,(datediff(MINUTE,debut, fin) / 60.0) , cout_horaire * (datediff(MINUTE,debut, fin) / 60.0) from ot_ordo_intervenant inner join intervenant on ot_ordo_intervenant.id_intervenant = intervenant.id where id_ressource_fonction in(select id from ot_ressources_fonction where id_ot  in (" + str + "))";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			double num = 0.0;
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0],
						Convert.ToDouble(dataTable.Rows[i].ItemArray[1]).ToString("0.000"),
						Math.Round(Convert.ToDouble(dataTable.Rows[i].ItemArray[2]), 2),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[3]).ToString("0.000")
					});
					num += Convert.ToDouble(dataTable.Rows[i].ItemArray[3]);
				}
			}
			this.label1.Text = num.ToString("0.000");
		}
	}
}
