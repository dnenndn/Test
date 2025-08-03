using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000113 RID: 275
	public partial class prod_rapport_fabrication_cf : Form
	{
		// Token: 0x06000C3F RID: 3135 RVA: 0x001DEB04 File Offset: 0x001DCD04
		public prod_rapport_fabrication_cf()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000C40 RID: 3136 RVA: 0x001DEB1C File Offset: 0x001DCD1C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bool flag2 = prod_rapport_fabrication.id_unite != 0;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete prod_rapport_cf_fabrication where id_rapport = @i1 and id_unite = @i2";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
					string cmdText2 = "insert into prod_rapport_cf_fabrication (id_rapport, id_unite, id_cf) values (@i1, @i2, @i3)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					MessageBox.Show("Modification avec succés");
				}
			}
		}

		// Token: 0x06000C41 RID: 3137 RVA: 0x001DEC70 File Offset: 0x001DCE70
		private void select_cf()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select id, nom from intervenant where chef_equipe = @t and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 1;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			string cmdText2 = "select id_cf from prod_rapport_cf_fabrication where id_rapport = @i1 and id_unite = @i2";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			int num = 0;
			sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_fabrication.id_unite;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag = dataTable2.Rows.Count != 0;
			if (flag)
			{
				num = Convert.ToInt32(dataTable2.Rows[0].ItemArray[0]);
			}
			bool flag2 = dataTable.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
					bool flag3 = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]) == num;
					if (flag3)
					{
						this.radDropDownList1.Items[i].Selected = true;
					}
				}
			}
		}

		// Token: 0x06000C42 RID: 3138 RVA: 0x001DEE84 File Offset: 0x001DD084
		private void prod_rapport_fabrication_cf_Load(object sender, EventArgs e)
		{
			bool flag = prod_rapport_fabrication.id_unite != 0;
			if (flag)
			{
				this.select_cf();
			}
		}
	}
}
