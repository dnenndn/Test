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
	// Token: 0x02000018 RID: 24
	public partial class app_point_commande : Form
	{
		// Token: 0x06000147 RID: 327 RVA: 0x0003F714 File Offset: 0x0003D914
		public app_point_commande()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.remplissage_tableau();
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0003F794 File Offset: 0x0003D994
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string cmdText = "select article.id, code_article, article.designation, point_commande, parametre_unite_article.designation from article inner join tableau_article_unite on article.id = tableau_article_unite.id_article inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where article.deleted = @d and methode_gestion = @m";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@m", SqlDbType.VarChar).Value = "Gestion à point commande";
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
						dataTable.Rows[i].ItemArray[0],
						dataTable.Rows[i].ItemArray[1],
						dataTable.Rows[i].ItemArray[2],
						dataTable.Rows[i].ItemArray[3],
						dataTable.Rows[i].ItemArray[4],
						Resources.icons8_approuver_et_mettre_à_jour_96__4_
					});
				}
			}
			bool flag2 = this.radGridView1.Rows.Count != 0;
			if (flag2)
			{
				this.radGridView1.MasterTemplate.MoveToFirstPage();
				this.radGridView1.Rows[0].IsCurrent = true;
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000149 RID: 329 RVA: 0x0003F998 File Offset: 0x0003DB98
		private int test_format()
		{
			int result = 1;
			fonction fonction = new fonction();
			for (int i = 0; i < this.radGridView1.Rows.Count; i++)
			{
				bool flag = !fonction.is_reel(Convert.ToString(this.radGridView1.Rows[i].Cells[3].Value));
				if (flag)
				{
					result = 0;
				}
			}
			return result;
		}

		// Token: 0x0600014A RID: 330 RVA: 0x0003FA10 File Offset: 0x0003DC10
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 5;
					if (flag3)
					{
						string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						fonction fonction = new fonction();
						bool flag4 = fonction.is_reel(Convert.ToString(this.radGridView1.Rows[e.RowIndex].Cells[3].Value));
						if (flag4)
						{
							bd bd = new bd();
							string cmdText = "update article set point_commande = @q where id = @i";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@q", SqlDbType.Real).Value = Convert.ToDouble(this.radGridView1.Rows[e.RowIndex].Cells[3].Value);
							sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = value;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Modification avec succés");
						}
						else
						{
							MessageBox.Show("Erreur : La quantité doit être un réel supérieure ou égale à zéro", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
				}
			}
		}
	}
}
