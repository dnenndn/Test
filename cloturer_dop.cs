using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200003D RID: 61
	public partial class cloturer_dop : Form
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x00070DBC File Offset: 0x0006EFBC
		public cloturer_dop()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change1);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee1);
			this.radMenuItem1.Click += this.click_ajouter;
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060002AA RID: 682 RVA: 0x00070E58 File Offset: 0x0006F058
		private void cloturer_dop_Load(object sender, EventArgs e)
		{
			this.label5.Text = "";
			this.label6.Text = "";
			this.label8.Text = "";
			this.select_article();
			this.label8.Text = tableau_comparatif.id_dop;
			this.get_article();
		}

		// Token: 0x060002AB RID: 683 RVA: 0x00070EB8 File Offset: 0x0006F0B8
		private void select_article()
		{
			bd bd = new bd();
			string cmdText = "select article.id, article.designation from dop_article inner join article on dop_article.id_article = article.id where id_dop = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = tableau_comparatif.id_dop;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x060002AC RID: 684 RVA: 0x00070FD8 File Offset: 0x0006F1D8
		private void click_ajouter(object sender, EventArgs e)
		{
			this.label5.Text = "";
			this.label6.Text = "";
			this.radDropDownList6.Items.Clear();
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					this.label5.Text = selectedNode.Tag.ToString();
					this.label6.Text = selectedNode.Text;
					string cmdText = "select fournisseur.nom, fournisseur.id from devis_fournisseur inner join fournisseur on devis_fournisseur.id_fournisseur = fournisseur.id inner join devis on devis_fournisseur.id_devis = devis.id inner join devis_article on devis.id = devis_article.id_devis where devis_article.id_article = @i1 and devis.id_dop = @i2";
					bd bd = new bd();
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = selectedNode.Tag.ToString();
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.label8.Text;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
						for (int i = 0; i < dataTable.Rows.Count; i++)
						{
							this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
							this.radDropDownList6.Items[this.radDropDownList6.Items.Count - 1].Tag = dataTable.Rows[i].ItemArray[1].ToString();
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060002AD RID: 685 RVA: 0x000711C4 File Offset: 0x0006F3C4
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060002AE RID: 686 RVA: 0x0007124C File Offset: 0x0006F44C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				bool flag2 = this.search_tableau(Convert.ToString(this.label5.Text)) == 0;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select code_article from article where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label5.Text;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					string cmdText2 = "select devis_article.prix_ht, devis_article.remise, devis_article.qt_disponible from devis_article inner join article on devis_article.id_article = article.id inner join devis on devis_article.id_devis = devis.id inner join devis_fournisseur on devis.id = devis_fournisseur.id_devis where devis_article.id_article = @i1 and devis_fournisseur.id_fournisseur = @i2 and devis.id_dop = @i3";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.label5.Text;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.label8.Text;
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable.Rows.Count != 0;
					if (flag3)
					{
						this.radGridView1.Rows.Add(new object[]
						{
							this.label5.Text,
							this.radDropDownList6.SelectedItem.Tag,
							this.radDropDownList6.Text,
							dataTable.Rows[0].ItemArray[0].ToString(),
							this.label6.Text,
							Convert.ToDouble(dataTable2.Rows[0].ItemArray[0]).ToString("0.000"),
							dataTable2.Rows[0].ItemArray[1],
							Resources.icons8_supprimer_pour_toujours_100__4_,
							dataTable2.Rows[0].ItemArray[2]
						});
					}
				}
				else
				{
					MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060002AF RID: 687 RVA: 0x00071494 File Offset: 0x0006F694
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag3)
					{
						string b = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.radGridView1.Rows.RemoveAt(e.RowIndex);
							bool flag5 = creer_da.table.Rows.Count != 0;
							if (flag5)
							{
								for (int i = 0; i < creer_da.table.Rows.Count; i++)
								{
									bool flag6 = creer_da.table.Rows[i].ItemArray[0].ToString() == b;
									if (flag6)
									{
										creer_da.table.Rows.Remove(creer_da.table.Rows[i]);
										i--;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060002B0 RID: 688 RVA: 0x000715EC File Offset: 0x0006F7EC
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "delete dop_fini where id_dop = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label8.Text;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					string cmdText2 = "insert into dop_fini (id_dop, id_article, id_fournisseur, prix_ht, remise, qt_disponible, fini) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.label8.Text;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[1].Value.ToString();
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToDouble(this.radGridView1.Rows[i].Cells[5].Value.ToString());
					sqlCommand2.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToDouble(this.radGridView1.Rows[i].Cells[6].Value.ToString());
					sqlCommand2.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToDouble(this.radGridView1.Rows[i].Cells[8].Value.ToString());
					sqlCommand2.Parameters.Add("@i7", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
				MessageBox.Show("Enregistrement avec succés");
			}
		}

		// Token: 0x060002B1 RID: 689 RVA: 0x00071880 File Offset: 0x0006FA80
		private void get_article()
		{
			string cmdText = "select id_article, id_fournisseur,fournisseur.nom, article.code_article, article.designation, dop_fini.prix_ht, dop_fini.remise from dop_fini inner join article on dop_fini.id_article = article.id inner join fournisseur on dop_fini.id_fournisseur = fournisseur.id where id_dop = @i";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = tableau_comparatif.id_dop;
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
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[5]).ToString("0.000"),
						dataTable.Rows[i].ItemArray[6].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x0400038F RID: 911
		private string id_art = "";
	}
}
