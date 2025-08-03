using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000146 RID: 326
	public partial class modifier_da_refuser : Form
	{
		// Token: 0x06000E86 RID: 3718 RVA: 0x00232F94 File Offset: 0x00231194
		public modifier_da_refuser()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radMenuItem1.Click += this.click_ajouter;
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000E87 RID: 3719 RVA: 0x00233022 File Offset: 0x00231222
		private void modifier_da_refuser_Load(object sender, EventArgs e)
		{
			this.label6.Text = "";
			this.label6.Text = da_refuser.id_da;
			this.select_periode();
			this.select_da();
			this.select_article();
		}

		// Token: 0x06000E88 RID: 3720 RVA: 0x0023305C File Offset: 0x0023125C
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000E89 RID: 3721 RVA: 0x00233078 File Offset: 0x00231278
		private int test_validation_tableau()
		{
			int result = 0;
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(this.radGridView1.Rows[i].Cells[2].Value.ToString()) | this.radGridView1.Rows[i].Cells[2].Value.ToString() == "0";
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x06000E8A RID: 3722 RVA: 0x00233144 File Offset: 0x00231344
		private void select_periode()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Jour");
			this.radDropDownList1.Items.Add("Semaine");
			this.radDropDownList1.Items.Add("Mois");
			this.radDropDownList1.Items.Add("Année");
		}

		// Token: 0x06000E8B RID: 3723 RVA: 0x002331BC File Offset: 0x002313BC
		private void select_article()
		{
			bd bd = new bd();
			string cmdText = "select id, designation ,stock_neuf from article where deleted =@d order by designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString() + "- qt: " + dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x06000E8C RID: 3724 RVA: 0x00233300 File Offset: 0x00231500
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						Convert.ToString(selectedNode.Tag),
						selectedNode.ToolTipText,
						0,
						"",
						this.imageList1.Images[0]
					});
				}
				else
				{
					MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x06000E8D RID: 3725 RVA: 0x002333B8 File Offset: 0x002315B8
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

		// Token: 0x06000E8E RID: 3726 RVA: 0x00233440 File Offset: 0x00231640
		private void select_da()
		{
			bd bd = new bd();
			this.radGridView1.Rows.Clear();
			string cmdText = "select delai, periode from demande_achat where id = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				this.TextBox5.Text = dataTable.Rows[0].ItemArray[0].ToString();
				this.radDropDownList1.Text = dataTable.Rows[0].ItemArray[1].ToString();
			}
			string cmdText2 = "select id_article, article.designation, qt, motif from da_article inner join article on da_article.id_article = article.id where id_da = @i";
			SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
			sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = this.label6.Text;
			SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
			DataTable dataTable2 = new DataTable();
			sqlDataAdapter2.Fill(dataTable2);
			bool flag2 = dataTable2.Rows.Count != 0;
			if (flag2)
			{
				for (int i = 0; i < dataTable2.Rows.Count; i++)
				{
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable2.Rows[i].ItemArray[0],
						dataTable2.Rows[i].ItemArray[1],
						dataTable2.Rows[i].ItemArray[2],
						dataTable2.Rows[i].ItemArray[3],
						this.imageList1.Images[0]
					});
				}
			}
		}

		// Token: 0x06000E8F RID: 3727 RVA: 0x00233634 File Offset: 0x00231834
		private void save_da_article(int id)
		{
			bd bd = new bd();
			string cmdText = "delete da_article where id_da = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
			for (int i = 0; i < this.radGridView1.Rows.Count; i++)
			{
				string cmdText2 = "insert into da_article (id_da, id_article, qt, motif) values (@i1, @i2, @i3, @i4)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id;
				sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
				sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = this.radGridView1.Rows[i].Cells[2].Value.ToString();
				sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.radGridView1.Rows[i].Cells[3].Value.ToString();
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}

		// Token: 0x06000E90 RID: 3728 RVA: 0x002337D4 File Offset: 0x002319D4
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox5.Text) != "" & fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				bool flag2 = this.test_validation_tableau() == 1;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "update demande_achat set delai = @i1, periode = @i2 where id = @i3";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Real).Value = this.TextBox5.Text;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
					sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = this.label6.Text;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.save_da_article(Convert.ToInt32(this.label6.Text));
					this.modifier_da(Convert.ToInt32(this.label6.Text));
					MessageBox.Show("DA est modifié avec succés");
					base.Close();
				}
				else
				{
					MessageBox.Show("Erreur : Vérifier le tableau des articles ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000E91 RID: 3729 RVA: 0x00233954 File Offset: 0x00231B54
		private void modifier_da(int i)
		{
			bd bd = new bd();
			string cmdText = "insert into da_modifier (id_da, modifier_par, date_modifier, heure_modifier) values (@i1, @i2, @i3, @i4)";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = i;
			sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = page_loginn.id_user;
			sqlCommand.Parameters.Add("@i3", SqlDbType.Date).Value = DateTime.Today;
			sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
			bd.ouverture_bd(bd.cnn);
			sqlCommand.ExecuteNonQuery();
			bd.cnn.Close();
		}

		// Token: 0x06000E92 RID: 3730 RVA: 0x00233A28 File Offset: 0x00231C28
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.radGridView1.Rows.RemoveAt(e.RowIndex);
						}
					}
				}
			}
		}
	}
}
