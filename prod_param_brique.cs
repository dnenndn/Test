using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000107 RID: 263
	public partial class prod_param_brique : Form
	{
		// Token: 0x06000BC8 RID: 3016 RVA: 0x001CFB0C File Offset: 0x001CDD0C
		public prod_param_brique()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellValueChanged += new GridViewCellEventHandler(this.RadGridView1_CellValueChanged);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000BC9 RID: 3017 RVA: 0x001CFB9C File Offset: 0x001CDD9C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 2;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "delete prod_type_brique where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau(0);
					}
				}
			}
		}

		// Token: 0x06000BCA RID: 3018 RVA: 0x001CFC7C File Offset: 0x001CDE7C
		private void RadGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				int num = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
				fonction fonction = new fonction();
				bool flag2 = fonction.DeleteSpace(Convert.ToString(this.radGridView1.Rows[e.RowIndex].Cells[1].Value)) != "";
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select id from prod_type_brique where designation = @t and id <> @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = Convert.ToString(this.radGridView1.Rows[e.RowIndex].Cells[1].Value);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez Modifier ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							int columnIndex = e.ColumnIndex;
							int num2 = columnIndex;
							if (num2 == 1)
							{
								update_tableau.modifier_varchar("prod_type_brique", num, "designation", Convert.ToString(this.radGridView1.Rows[e.RowIndex].Cells[1].Value));
							}
						}
					}
					else
					{
						MessageBox.Show("Erreur : Type de Brique déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x06000BCB RID: 3019 RVA: 0x001CFE4C File Offset: 0x001CE04C
		private void prod_param_brique_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000BCC RID: 3020 RVA: 0x001CFE58 File Offset: 0x001CE058
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select * from prod_type_brique";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
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
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000BCD RID: 3021 RVA: 0x001CFFB8 File Offset: 0x001CE1B8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from prod_type_brique where designation = @t";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into prod_type_brique (designation) values (@t)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@t", SqlDbType.VarChar).Value = this.TextBox1.Text;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Ajout avec succés");
					this.remplissage_tableau(0);
					this.TextBox1.Clear();
				}
				else
				{
					MessageBox.Show("Erreur : Type de Brique déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Veuillez Choisir le type de brique", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
