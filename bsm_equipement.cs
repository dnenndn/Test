using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000032 RID: 50
	public partial class bsm_equipement : Form
	{
		// Token: 0x0600025D RID: 605 RVA: 0x000668B8 File Offset: 0x00064AB8
		public bsm_equipement()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			bsm_equipement.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			bsm_equipement.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x00066914 File Offset: 0x00064B14
		private void bsm_equipement_Load(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement, equipement.designation from bsm_equipement inner join equipement on bsm_equipement.id_equipement = equipement.id where id_bsm = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = historique_bsm.id_bsm;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				bsm_equipement.radGridView2.Rows.Add(new object[]
				{
					dataTable.Rows[0].ItemArray[0].ToString(),
					dataTable.Rows[0].ItemArray[1].ToString()
				});
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000669D4 File Offset: 0x00064BD4
		private void label5_Click(object sender, EventArgs e)
		{
			equipement_bsm_modifier equipement_bsm_modifier = new equipement_bsm_modifier();
			equipement_bsm_modifier.Show();
		}

		// Token: 0x06000260 RID: 608 RVA: 0x000669F0 File Offset: 0x00064BF0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bd bd = new bd();
			string cmdText = "update bsm_equipement set id_equipement = @v where id_bsm = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = bsm_equipement.radGridView2.Rows[0].Cells[0].Value;
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = historique_bsm.id_bsm;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			historique_bsm.remplissage_tableau(2);
			MessageBox.Show("Modification avec succés");
		}
	}
}
