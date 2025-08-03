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
	// Token: 0x0200011A RID: 282
	public partial class prod_rapport_four_sortie : Form
	{
		// Token: 0x06000C77 RID: 3191 RVA: 0x001E58E8 File Offset: 0x001E3AE8
		public prod_rapport_four_sortie()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000C78 RID: 3192 RVA: 0x001E593B File Offset: 0x001E3B3B
		private void prod_rapport_four_sortie_Load(object sender, EventArgs e)
		{
			this.select_produit();
		}

		// Token: 0x06000C79 RID: 3193 RVA: 0x001E5948 File Offset: 0x001E3B48
		private void select_produit()
		{
			this.radGridView1.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select prod_rapport_four_sortie.id,id_produit, prod_type_brique.designation, quantite from prod_rapport_four_sortie inner join prod_type_brique on prod_rapport_four_sortie.id_produit = prod_type_brique.id where id_rapport = @i1 and id_unite = @i2";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_four.id_unite;
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

		// Token: 0x06000C7A RID: 3194 RVA: 0x001E5AA8 File Offset: 0x001E3CA8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				int num = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[3].Value));
					if (flag2)
					{
						num = 0;
					}
					else
					{
						bool flag3 = Convert.ToDouble(this.radGridView1.Rows[i].Cells[3].Value) < 0.0;
						if (flag3)
						{
							num = 0;
						}
					}
				}
				bool flag4 = num == 1;
				if (flag4)
				{
					bd bd = new bd();
					for (int j = 0; j < this.radGridView1.Rows.Count; j++)
					{
						double num2 = fonction.tonnage_wagon(this.radGridView1.Rows[j].Cells[2].Value.ToString());
						string cmdText = "select valeur from prod_rapport_four_qualite where id_rapport = @i1 and id_unite = @i2 and id_qualite = (select id from prod_saisie where poid_four = @d)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = prod_rapport.id_rpr;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = prod_rapport_four.id_unite;
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						int num3 = Convert.ToInt32(this.radGridView1.Rows[j].Cells[1].Value);
						double num4 = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
						bool flag5 = num3 == 1;
						if (flag5)
						{
						}
						bool flag6 = num3 == 2;
						if (flag6)
						{
						}
						bool flag7 = num3 == 3;
						if (flag7)
						{
						}
						bool flag8 = num3 == 4;
						if (flag8)
						{
						}
						bool flag9 = num3 == 5;
						double num5;
						if (flag9)
						{
							num5 = 4200.0;
						}
						else
						{
							num5 = 7200.0;
						}
						bool flag10 = num4 != 0.0;
						if (flag10)
						{
							num5 = num4;
						}
						double num6 = num5 * num2 * Convert.ToDouble(this.radGridView1.Rows[j].Cells[3].Value);
						string cmdText2 = "update prod_rapport_four_sortie set quantite = @q, tonnage = @t where id = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[j].Cells[0].Value;
						sqlCommand2.Parameters.Add("@q", SqlDbType.Real).Value = this.radGridView1.Rows[j].Cells[3].Value;
						sqlCommand2.Parameters.Add("@t", SqlDbType.Real).Value = num6;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
					}
					MessageBox.Show("Modification avec succés");
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier la quantité de chaque produit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Vérifier la quantité de chaque produit", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
