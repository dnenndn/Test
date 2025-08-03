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
	// Token: 0x020000D6 RID: 214
	public partial class ot_tabl_outillage : Form
	{
		// Token: 0x0600098E RID: 2446 RVA: 0x001876A4 File Offset: 0x001858A4
		public ot_tabl_outillage()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_tabl_outillage.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_tabl_outillage.select_changee);
		}

		// Token: 0x0600098F RID: 2447 RVA: 0x001876F7 File Offset: 0x001858F7
		private void ot_tabl_outillage_Load(object sender, EventArgs e)
		{
			this.select_outil();
		}

		// Token: 0x06000990 RID: 2448 RVA: 0x00187704 File Offset: 0x00185904
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

		// Token: 0x06000991 RID: 2449 RVA: 0x00187788 File Offset: 0x00185988
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

		// Token: 0x06000992 RID: 2450 RVA: 0x0018788C File Offset: 0x00185A8C
		private void select_outil()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string str = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			string cmdText = "select distinct tab_lancement_affectation.id,  code_outils, outils.designation, tab_lancement_affectation.date_debut, tab_lancement_affectation.heure_debut, tab_lancement_affectation.date_fin, tab_lancement_affectation.heure_fin, intervenant.nom, ordre_travail.n_ot from tab_lancement_affectation inner join intervenant on tab_lancement_affectation.id_intervenant = intervenant.id inner join outils on tab_lancement_affectation.outil = outils.id inner join ordre_travail on tab_lancement_affectation.n_ot = ordre_travail.n_ot where ordre_travail.id in (" + str + ") ";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					bool flag2 = Convert.ToString(dataTable.Rows[i].ItemArray[5]) != "";
					if (flag2)
					{
						text = fonction.Mid(dataTable.Rows[i].ItemArray[5].ToString(), 1, 10);
					}
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[8].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[3].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[4].ToString(),
						text,
						Convert.ToString(dataTable.Rows[i].ItemArray[6]),
						dataTable.Rows[i].ItemArray[7].ToString()
					});
				}
			}
		}
	}
}
