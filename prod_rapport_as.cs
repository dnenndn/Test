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
	// Token: 0x02000110 RID: 272
	public partial class prod_rapport_as : Form
	{
		// Token: 0x06000C25 RID: 3109 RVA: 0x001DC66C File Offset: 0x001DA86C
		public prod_rapport_as()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000C26 RID: 3110 RVA: 0x001DC6BF File Offset: 0x001DA8BF
		private void prod_rapport_as_Load(object sender, EventArgs e)
		{
			this.select_champs();
		}

		// Token: 0x06000C27 RID: 3111 RVA: 0x001DC6CC File Offset: 0x001DA8CC
		private void select_champs()
		{
			bd bd = new bd();
			this.radGridView1.Rows.Clear();
			string cmdText = "select prod_rapport_prep_as.id, prod_saisie.designation, valeur_a, valeur_s from prod_rapport_prep_as inner join prod_saisie on prod_rapport_prep_as.id_qualite = prod_saisie.id where id_rapport = @i1 and id_unite = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_preparation.id_unite;
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
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString()
					});
				}
			}
		}

		// Token: 0x06000C28 RID: 3112 RVA: 0x001DC82C File Offset: 0x001DAA2C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				int num = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[2].Value)) | !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[3].Value));
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
						string cmdText = "update prod_rapport_prep_as set valeur_a = @a, valeur_s = @s where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[j].Cells[0].Value.ToString();
						sqlCommand.Parameters.Add("@a", SqlDbType.Real).Value = this.radGridView1.Rows[j].Cells[2].Value.ToString();
						sqlCommand.Parameters.Add("@s", SqlDbType.Real).Value = this.radGridView1.Rows[j].Cells[3].Value.ToString();
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
