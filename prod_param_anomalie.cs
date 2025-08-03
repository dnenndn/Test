using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000106 RID: 262
	public partial class prod_param_anomalie : Form
	{
		// Token: 0x06000BC0 RID: 3008 RVA: 0x001CE9D4 File Offset: 0x001CCBD4
		public prod_param_anomalie()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000BC1 RID: 3009 RVA: 0x001CEA4C File Offset: 0x001CCC4C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 3;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "delete prod_anomalie where id = @i";
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

		// Token: 0x06000BC2 RID: 3010 RVA: 0x001CEB2B File Offset: 0x001CCD2B
		private void prod_param_anomalie_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
			this.select_unite_production();
		}

		// Token: 0x06000BC3 RID: 3011 RVA: 0x001CEB40 File Offset: 0x001CCD40
		private void select_unite_production()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Préparation");
			this.radDropDownList1.Items.Add("Fabrication");
			this.radDropDownList1.Items.Add("Four");
			this.radDropDownList1.Items.Add("Emballage");
		}

		// Token: 0x06000BC4 RID: 3012 RVA: 0x001CEBB8 File Offset: 0x001CCDB8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bd bd = new bd();
			bool flag = fonction.DeleteSpace(this.radTextBox1.Text) != "" & this.radDropDownList1.Text != "";
			if (flag)
			{
				string cmdText = "insert into prod_anomalie (anomalie, unite_production) values (@v1, @v2)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.radTextBox1.Text;
				sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				this.radTextBox1.Clear();
				MessageBox.Show("Enregistrement avec succés");
				this.remplissage_tableau(0);
			}
			else
			{
				MessageBox.Show("Erreur : Un champs Obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000BC5 RID: 3013 RVA: 0x001CECC0 File Offset: 0x001CCEC0
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select * from prod_anomalie order by unite_production";
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
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}
	}
}
