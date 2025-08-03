using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x020000E8 RID: 232
	public partial class outillage_parametre_type : Form
	{
		// Token: 0x06000A1A RID: 2586 RVA: 0x00193ABC File Offset: 0x00191CBC
		public outillage_parametre_type()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000A1B RID: 2587 RVA: 0x00193B40 File Offset: 0x00191D40
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 3;
			if (flag)
			{
				string text = (string)this.radGridView1.CurrentRow.Cells[1].Value;
				string text2 = (string)this.radGridView1.CurrentRow.Cells[2].Value;
				this.radTextBox1.Text = text;
				this.radTextBox2.Text = text2;
				this.radButton1.Text = "modifier";
				this.radButton2.Visible = true;
			}
			bool flag2 = e.RowIndex >= 0 & e.ColumnIndex == 4;
			if (flag2)
			{
				this.supprimer_type();
			}
		}

		// Token: 0x06000A1C RID: 2588 RVA: 0x00193C08 File Offset: 0x00191E08
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radButton1.Text == "Ajouter";
			if (flag)
			{
				bool flag2 = this.radTextBox1.Text == "" | this.radTextBox2.Text == "";
				if (flag2)
				{
					MessageBox.Show("vouz devez remplir tous les champs");
				}
				else
				{
					this.insertion_nouveau_type();
					this.radTextBox1.Clear();
					this.radTextBox2.Clear();
				}
			}
			else
			{
				this.modifier_type();
				this.radButton1.Text = "Ajouter";
				this.radTextBox1.Clear();
				this.radTextBox2.Clear();
				this.radButton2.Visible = false;
			}
		}

		// Token: 0x06000A1D RID: 2589 RVA: 0x00193CD4 File Offset: 0x00191ED4
		private void insertion_nouveau_type()
		{
			string cmdText = "insert into dbo.tab_type (code,designation) values(@i1,@i2)";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				try
				{
					sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.radTextBox1.Text;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.radTextBox2.Text;
					sqlCommand.Connection.Open();
					sqlCommand.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					bool flag = ex.Number == 2627;
					if (flag)
					{
						MessageBox.Show("code ou designation existe deja", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						sqlCommand.Connection.Close();
					}
				}
				sqlCommand.Connection.Close();
			}
			this.remplissage_tableau();
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x00193DCC File Offset: 0x00191FCC
		private void modifier_type()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			string cmdText = "UPDATE tab_type SET code = @i2,designation =@i3 WHERE id = @i1;  ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				try
				{
					sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = value;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.radTextBox1.Text;
					sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.radTextBox2.Text;
					sqlCommand.Connection.Open();
					sqlCommand.ExecuteNonQuery();
				}
				catch (SqlException ex)
				{
					bool flag = ex.Number == 2627;
					if (flag)
					{
						MessageBox.Show("code ou designation existe deja", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						sqlCommand.Connection.Close();
					}
				}
				sqlCommand.Connection.Close();
			}
			this.remplissage_tableau();
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00193F00 File Offset: 0x00192100
		private void supprimer_type()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			DialogResult dialogResult = MessageBox.Show("voulez vous supprimer cette ligne", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
			bool flag = dialogResult == DialogResult.OK;
			if (flag)
			{
				string cmdText = "delete from tab_type where id like @i1;";
				using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
				{
					sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = value;
					sqlCommand.Connection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlCommand.Connection.Close();
				}
				this.remplissage_tableau();
			}
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00193FCC File Offset: 0x001921CC
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.PageSize = 9;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select * from tab_type ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0],
						dataTable.Rows[i].ItemArray[1],
						dataTable.Rows[i].ItemArray[2],
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
				this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
				this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			}
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0019411C File Offset: 0x0019231C
		private void radButton2_Click(object sender, EventArgs e)
		{
			this.radTextBox1.Clear();
			this.radTextBox2.Clear();
			this.radButton1.Text = "Ajouter";
			this.radButton2.Visible = false;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00194155 File Offset: 0x00192355
		private void outillage_parametre_type_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x04000D15 RID: 3349
		private bd b = new bd();
	}
}
