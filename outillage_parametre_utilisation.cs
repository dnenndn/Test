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
	// Token: 0x020000E9 RID: 233
	public partial class outillage_parametre_utilisation : Form
	{
		// Token: 0x06000A25 RID: 2597 RVA: 0x00194994 File Offset: 0x00192B94
		public outillage_parametre_utilisation()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x00194A18 File Offset: 0x00192C18
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 3;
			if (flag)
			{
				this.radTextBox1.Text = (string)this.radGridView1.CurrentRow.Cells[1].Value;
				this.radTextBox2.Text = (string)this.radGridView1.CurrentRow.Cells[2].Value;
				this.radButton1.Text = "Modifier";
				this.radButton2.Visible = true;
			}
			bool flag2 = e.RowIndex >= 0 & e.ColumnIndex == 4;
			if (flag2)
			{
				this.supprimer_utilisation();
			}
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00194ADC File Offset: 0x00192CDC
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
					this.insertion_nouveau_utilisation();
					this.radTextBox1.Clear();
					this.radTextBox2.Clear();
				}
			}
			else
			{
				this.modifier_utilisation();
				this.radButton1.Text = "Ajouter";
				this.radTextBox1.Clear();
				this.radTextBox2.Clear();
				this.radButton2.Visible = false;
			}
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00194BA8 File Offset: 0x00192DA8
		private void insertion_nouveau_utilisation()
		{
			string cmdText = "insert into utilisation (code,designation) values(@i1,@i2)";
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

		// Token: 0x06000A29 RID: 2601 RVA: 0x00194CA0 File Offset: 0x00192EA0
		private void modifier_utilisation()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			string cmdText = "UPDATE utilisation SET code = @i2,designation =@i3 WHERE id = @i1;  ";
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

		// Token: 0x06000A2A RID: 2602 RVA: 0x00194DD4 File Offset: 0x00192FD4
		private void supprimer_utilisation()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			DialogResult dialogResult = MessageBox.Show("voulez vous supprimer cette ligne", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
			bool flag = dialogResult == DialogResult.OK;
			if (flag)
			{
				string cmdText = "delete from utilisation where id like @i1;";
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

		// Token: 0x06000A2B RID: 2603 RVA: 0x00194EA0 File Offset: 0x001930A0
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.PageSize = 9;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select * from utilisation ";
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

		// Token: 0x06000A2C RID: 2604 RVA: 0x00194FF0 File Offset: 0x001931F0
		private void radButton2_Click(object sender, EventArgs e)
		{
			this.radTextBox1.Clear();
			this.radTextBox2.Clear();
			this.radButton1.Text = "Ajouter";
			this.radButton2.Visible = false;
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00195029 File Offset: 0x00193229
		private void outillage_parametre_utilisation_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x04000D21 RID: 3361
		private bd b = new bd();
	}
}
