using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000A0 RID: 160
	public partial class notification : Form
	{
		// Token: 0x06000745 RID: 1861 RVA: 0x0013F40C File Offset: 0x0013D60C
		public notification()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(notification.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(notification.select_changee);
			DateTime now = DateTime.Now;
			DateTime value = new DateTime(now.Year, now.Month, 1);
			this.radDateTimePicker1.Value = value;
			this.radDateTimePicker2.Value = value.AddMonths(1).AddDays(-1.0);
		}

		// Token: 0x06000746 RID: 1862 RVA: 0x0013F4B0 File Offset: 0x0013D6B0
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

		// Token: 0x06000747 RID: 1863 RVA: 0x0013F534 File Offset: 0x0013D734
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 10f, FontStyle.Bold, GraphicsUnit.Point, 0);
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
					e.RowElement.Font = new Font("Calibri", 10f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x06000748 RID: 1864 RVA: 0x0013F637 File Offset: 0x0013D837
		private void notification_Load(object sender, EventArgs e)
		{
			this.select_notification();
		}

		// Token: 0x06000749 RID: 1865 RVA: 0x0013F644 File Offset: 0x0013D844
		private void select_notification()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select * from notification where id_utilisateur = @i and type <> @v and date_creation between @d1 and @d2 order by id desc ";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = page_loginn.id_user;
			sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = "Stock Sécurité";
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			for (int i = 0; i < dataTable.Rows.Count; i++)
			{
				bool flag = dataTable.Rows[i].ItemArray[2].ToString() == "DA Système";
				if (flag)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Resources.icons8_system_64,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				bool flag2 = dataTable.Rows[i].ItemArray[2].ToString() == "Lancement OT Prév";
				if (flag2)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Resources.icons8_entretien_50,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				bool flag3 = dataTable.Rows[i].ItemArray[2].ToString() == "Signature Commande" | dataTable.Rows[i].ItemArray[2].ToString() == "Création Commande";
				if (flag3)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Resources.icons8_signature_96,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				bool flag4 = dataTable.Rows[i].ItemArray[2].ToString() == "Variation Commande";
				if (flag4)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Resources.icons8_prix_50,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				bool flag5 = dataTable.Rows[i].ItemArray[2].ToString() == "Budget";
				if (flag5)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Resources.icons8_budget_64__2_,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				bool flag6 = dataTable.Rows[i].ItemArray[2].ToString() == "Stock Sécurité";
				if (flag6)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Resources.icons8_en_rupture_de_stock_50,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString()
					});
				}
				this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Height = 40;
			}
			bool flag7 = this.radGridView1.Rows.Count != 0;
			if (flag7)
			{
				this.radGridView1.Rows[0].IsCurrent = true;
			}
		}

		// Token: 0x0600074A RID: 1866 RVA: 0x0013FAEA File Offset: 0x0013DCEA
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.select_notification();
		}

		// Token: 0x0600074B RID: 1867 RVA: 0x0013FAF4 File Offset: 0x0013DCF4
		private void radDateTimePicker2_ValueChanged(object sender, EventArgs e)
		{
			this.select_notification();
		}
	}
}
