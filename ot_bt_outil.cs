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
	// Token: 0x020000AF RID: 175
	public partial class ot_bt_outil : Form
	{
		// Token: 0x060007EB RID: 2027 RVA: 0x0015926C File Offset: 0x0015746C
		public ot_bt_outil()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_bt_outil.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_bt_outil.select_changee);
		}

		// Token: 0x060007EC RID: 2028 RVA: 0x001592BF File Offset: 0x001574BF
		private void ot_bt_outil_Load(object sender, EventArgs e)
		{
			this.select_outil();
		}

		// Token: 0x060007ED RID: 2029 RVA: 0x001592CC File Offset: 0x001574CC
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

		// Token: 0x060007EE RID: 2030 RVA: 0x00159350 File Offset: 0x00157550
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

		// Token: 0x060007EF RID: 2031 RVA: 0x00159454 File Offset: 0x00157654
		private void select_outil()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select  code_outils, outils.designation, tab_lancement_affectation.date_debut, tab_lancement_affectation.heure_debut, tab_lancement_affectation.date_fin, tab_lancement_affectation.heure_fin, intervenant.nom from tab_lancement_affectation inner join intervenant on tab_lancement_affectation.id_intervenant = intervenant.id inner join outils on tab_lancement_affectation.outil = outils.id inner join ordre_travail on tab_lancement_affectation.n_ot = ordre_travail.n_ot where ordre_travail.id = @i ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					bool flag2 = Convert.ToString(dataTable.Rows[i].ItemArray[4]) != "";
					if (flag2)
					{
						text = fonction.Mid(dataTable.Rows[i].ItemArray[4].ToString(), 1, 10);
					}
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[2].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[3].ToString(),
						text,
						Convert.ToString(dataTable.Rows[i].ItemArray[5]),
						dataTable.Rows[i].ItemArray[6].ToString()
					});
				}
			}
		}
	}
}
