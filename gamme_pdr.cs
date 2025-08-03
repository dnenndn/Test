using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200007B RID: 123
	public partial class gamme_pdr : Form
	{
		// Token: 0x060005AA RID: 1450 RVA: 0x000ED2F0 File Offset: 0x000EB4F0
		public gamme_pdr()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(gamme_pdr.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(gamme_pdr.select_changee);
			this.radMenuItem1.Click += this.click_ajouter;
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.RadGridView3_CellClick);
		}

		// Token: 0x060005AB RID: 1451 RVA: 0x000ED373 File Offset: 0x000EB573
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox2.Text;
		}

		// Token: 0x060005AC RID: 1452 RVA: 0x000ED390 File Offset: 0x000EB590
		public static void select_change(object sender, CellFormattingEventArgs e)
		{
			bool isCurrent = e.CellElement.IsCurrent;
			if (isCurrent)
			{
				e.CellElement.DrawFill = true;
				e.CellElement.GradientStyle = 0;
				e.CellElement.BackColor = Color.Firebrick;
			}
			else
			{
				e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
				e.CellElement.ResetValue(VisualElement.BackColorProperty);
				e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
			}
		}

		// Token: 0x060005AD RID: 1453 RVA: 0x000ED414 File Offset: 0x000EB614
		public static void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.DrawFill = true;
				e.RowElement.GradientStyle = 0;
				e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Bold, GraphicsUnit.Point, 0);
				e.RowElement.BackColor = Color.LightYellow;
			}
			else
			{
				bool isSelected = e.RowElement.IsSelected;
				if (isSelected)
				{
					e.RowElement.DrawFill = true;
					e.RowElement.GradientStyle = 0;
					e.RowElement.BackColor = Color.Firebrick;
				}
				else
				{
					e.RowElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.RowElement.ResetValue(VisualElement.BackColorProperty);
					e.RowElement.ResetValue(LightVisualElement.GradientStyleProperty);
					e.RowElement.Font = new Font("Calibri", 8f, FontStyle.Regular, GraphicsUnit.Point, 0);
				}
			}
		}

		// Token: 0x060005AE RID: 1454 RVA: 0x000ED518 File Offset: 0x000EB718
		private void RadGridView3_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 5;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete gamme_ressources_pdr where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_tableau();
				}
			}
		}

		// Token: 0x060005AF RID: 1455 RVA: 0x000ED5EC File Offset: 0x000EB7EC
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select gamme_ressources_pdr.id, id_article, article.code_article, article.designation, quantite from gamme_ressources_pdr inner join article on gamme_ressources_pdr.id_article = article.id where id_gamme = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x060005B0 RID: 1456 RVA: 0x000ED74F File Offset: 0x000EB94F
		private void gamme_pdr_Load(object sender, EventArgs e)
		{
			this.select_tableau();
			this.select_article();
		}

		// Token: 0x060005B1 RID: 1457 RVA: 0x000ED760 File Offset: 0x000EB960
		private void select_article()
		{
			this.radTreeView1.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation, code_article  from article where deleted =@d order by designation";
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
					radTreeNode.Text = (dataTable.Rows[i].ItemArray[1].ToString() ?? "");
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[2].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x060005B2 RID: 1458 RVA: 0x000ED898 File Offset: 0x000EBA98
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(this.guna2TextBox3.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToDouble(this.guna2TextBox3.Text) > 0.0;
					if (flag3)
					{
						int num = Convert.ToInt32(selectedNode.Tag.ToString());
						int num2 = 0;
						for (int i = 0; i < this.radGridView3.Rows.Count; i++)
						{
							bool flag4 = Convert.ToInt32(this.radGridView3.Rows[i].Cells[1].Value) == num;
							if (flag4)
							{
								num2 = 1;
							}
						}
						bool flag5 = num2 == 0;
						if (flag5)
						{
							bd bd = new bd();
							string cmdText = "insert into gamme_ressources_pdr (id_article, id_gamme, quantite) values (@i1, @i2, @i3)";
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = selectedNode.Tag.ToString();
							sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = liste_gamme_operatoire.id_gamme;
							sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.guna2TextBox3.Text;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.select_tableau();
						}
						else
						{
							MessageBox.Show("Erreur :Article déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur :La quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :La quantité doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}
	}
}
