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
	// Token: 0x020000E7 RID: 231
	public partial class outillage_parametre_secteur : Form
	{
		// Token: 0x06000A0F RID: 2575 RVA: 0x00192BE8 File Offset: 0x00190DE8
		public outillage_parametre_secteur()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000A10 RID: 2576 RVA: 0x00192C6C File Offset: 0x00190E6C
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
				this.supprimer_secteur();
			}
		}

		// Token: 0x06000A11 RID: 2577 RVA: 0x00192D30 File Offset: 0x00190F30
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
					this.insertion_nouveau_secteur();
					this.radTextBox1.Clear();
					this.radTextBox2.Clear();
				}
			}
			else
			{
				this.modifier_secteur();
				this.radButton1.Text = "Ajouter";
				this.radTextBox1.Clear();
				this.radTextBox2.Clear();
				this.radButton2.Visible = false;
			}
		}

		// Token: 0x06000A12 RID: 2578 RVA: 0x00192DFC File Offset: 0x00190FFC
		private void insertion_nouveau_secteur()
		{
			string cmdText = "insert into dbo.secteur(code,designation) values(@i1,@i2)";
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

		// Token: 0x06000A13 RID: 2579 RVA: 0x00192EF4 File Offset: 0x001910F4
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.PageSize = 9;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select * from secteur ";
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

		// Token: 0x06000A14 RID: 2580 RVA: 0x00193044 File Offset: 0x00191244
		private void modifier_secteur()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			string cmdText = "UPDATE secteur SET code = @i2,designation =@i3 WHERE id = @i1;  ";
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

		// Token: 0x06000A15 RID: 2581 RVA: 0x00193178 File Offset: 0x00191378
		private void supprimer_secteur()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			DialogResult dialogResult = MessageBox.Show("voulez vous supprimer cette ligne", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
			bool flag = dialogResult == DialogResult.OK;
			if (flag)
			{
				string cmdText = "delete from secteur where id like @i1;";
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

		// Token: 0x06000A16 RID: 2582 RVA: 0x00193244 File Offset: 0x00191444
		private void radButton2_Click(object sender, EventArgs e)
		{
			this.radTextBox1.Clear();
			this.radTextBox2.Clear();
			this.radButton1.Text = "Ajouter";
			this.radButton2.Visible = false;
		}

		// Token: 0x06000A17 RID: 2583 RVA: 0x0019327D File Offset: 0x0019147D
		private void outillage_parametre_secteur_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x04000D09 RID: 3337
		private bd b = new bd();
	}
}
