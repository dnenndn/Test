using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200011D RID: 285
	public partial class prod_rapport_prep_general : Form
	{
		// Token: 0x06000C90 RID: 3216 RVA: 0x001E80D4 File Offset: 0x001E62D4
		public prod_rapport_prep_general()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000C91 RID: 3217 RVA: 0x001E8127 File Offset: 0x001E6327
		private void prod_rapport_prep_general_Load(object sender, EventArgs e)
		{
			this.select_champs();
		}

		// Token: 0x06000C92 RID: 3218 RVA: 0x001E8134 File Offset: 0x001E6334
		private void select_champs()
		{
			bd bd = new bd();
			this.radGridView1.Rows.Clear();
			string cmdText = "select prod_rapport_prep_general.id, prod_saisie.designation, valeur from prod_rapport_prep_general inner join prod_saisie on prod_rapport_prep_general.id_qualite = prod_saisie.id where id_rapport = @i1";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
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
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
			}
		}

		// Token: 0x06000C93 RID: 3219 RVA: 0x001E8254 File Offset: 0x001E6454
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				int num = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[2].Value));
					if (flag2)
					{
						num = 0;
					}
				}
				bool flag3 = num == 1;
				if (flag3)
				{
					bd bd = new bd();
					for (int j = 0; j < this.radGridView1.Rows.Count; j++)
					{
						string cmdText = "update prod_rapport_prep_general set valeur = @h where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[j].Cells[0].Value.ToString();
						sqlCommand.Parameters.Add("@h", SqlDbType.Real).Value = this.radGridView1.Rows[j].Cells[2].Value.ToString();
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
					}
					MessageBox.Show("Modification avec succés");
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier les champs", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}
	}
}
