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
	// Token: 0x020000BA RID: 186
	public partial class ot_general_cause : Form
	{
		// Token: 0x06000866 RID: 2150 RVA: 0x00167DC4 File Offset: 0x00165FC4
		public ot_general_cause()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_general_cause.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_general_cause.select_changee);
		}

		// Token: 0x06000867 RID: 2151 RVA: 0x00167E17 File Offset: 0x00166017
		private void ot_general_cause_Load(object sender, EventArgs e)
		{
			this.radGridView3.Rows.Clear();
			this.select_cause_existe();
			this.select_cause_pas();
		}

		// Token: 0x06000868 RID: 2152 RVA: 0x00167E3C File Offset: 0x0016603C
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

		// Token: 0x06000869 RID: 2153 RVA: 0x00167EC0 File Offset: 0x001660C0
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

		// Token: 0x0600086A RID: 2154 RVA: 0x00167FC4 File Offset: 0x001661C4
		private void select_cause_existe()
		{
			bd bd = new bd();
			string cmdText = "select id, code, designation from parametre_cause_realisation where id in (select id_cause from ot_cause_realisation where id_ot = @i)";
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
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						"True"
					});
				}
			}
		}

		// Token: 0x0600086B RID: 2155 RVA: 0x001680DC File Offset: 0x001662DC
		private void select_cause_pas()
		{
			bd bd = new bd();
			string cmdText = "select id, code, designation from parametre_cause_realisation where id not in (select id_cause from ot_cause_realisation where id_ot = @i)";
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
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						"False"
					});
				}
			}
		}

		// Token: 0x0600086C RID: 2156 RVA: 0x001681F4 File Offset: 0x001663F4
		private void radButton1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "delete ot_cause_realisation where id_ot = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			bool flag = this.radGridView3.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView3.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView3.Rows[i].Cells[3].Value) == "True";
					if (flag2)
					{
						string cmdText2 = "insert into ot_cause_realisation (id_ot, id_cause) values (@v1, @v2)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand2.Parameters.Add("@v2", SqlDbType.Int).Value = this.radGridView3.Rows[i].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
			MessageBox.Show("Enregistrement avec succés");
		}
	}
}
