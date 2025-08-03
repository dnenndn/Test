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
	// Token: 0x0200004B RID: 75
	public partial class compteur_actuel : Form
	{
		// Token: 0x06000351 RID: 849 RVA: 0x0008E264 File Offset: 0x0008C464
		public compteur_actuel()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(compteur_actuel.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(compteur_actuel.select_changee);
			this.remplissage_tableau();
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0008E2C0 File Offset: 0x0008C4C0
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

		// Token: 0x06000353 RID: 851 RVA: 0x0008E344 File Offset: 0x0008C544
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

		// Token: 0x06000354 RID: 852 RVA: 0x0008E447 File Offset: 0x0008C647
		private void compteur_actuel_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000355 RID: 853 RVA: 0x0008E44C File Offset: 0x0008C64C
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select equipement.code, equipement.designation, equipement_compteur.designation, valeur, unite from equipement_compteur inner join equipement on equipement_compteur.id_equipement = equipement.id where equipement.deleted = @d and equipement_compteur.deleted = @d";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[4])
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}
	}
}
