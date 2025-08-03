using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000C6 RID: 198
	public partial class ot_liste_article_reservation : Form
	{
		// Token: 0x060008DB RID: 2267 RVA: 0x00176871 File Offset: 0x00174A71
		public ot_liste_article_reservation()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter;
		}

		// Token: 0x060008DC RID: 2268 RVA: 0x001768A4 File Offset: 0x00174AA4
		private void ot_liste_article_reservation_Load(object sender, EventArgs e)
		{
			this.label3.Text = ot_liste.id_ot_tr.ToString();
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			this.select_article();
		}

		// Token: 0x060008DD RID: 2269 RVA: 0x001768F8 File Offset: 0x00174AF8
		private void select_article()
		{
			this.radTreeView1.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation  from article where deleted =@d and id not in (select id_article from ot_ressources_pdr where id_ot = @v) order by designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = this.label3.Text;
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
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x060008DE RID: 2270 RVA: 0x00176A54 File Offset: 0x00174C54
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				fonction fonction = new fonction();
				bool flag2 = fonction.is_reel(this.TextBox1.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToDouble(this.TextBox1.Text) > 0.0;
					if (flag3)
					{
						bd bd = new bd();
						int hour = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 2));
						int minute = Convert.ToInt32(fonction.Mid(this.radTimePicker1.Value.ToString(), 15, 2));
						DateTime dateTime = new DateTime(this.radDateTimePicker1.Value.Year, this.radDateTimePicker1.Value.Month, this.radDateTimePicker1.Value.Day, hour, minute, 0);
						string cmdText = "insert into ot_ressources_pdr (id_article, id_ot, quantite, date_sh) values (@i1, @i2, @i3, @i4)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = selectedNode.Tag;
						sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToDouble(this.TextBox1.Text);
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.label3.Text;
						sqlCommand.Parameters.Add("@i4", SqlDbType.DateTime).Value = dateTime;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Ajout avec succés");
						ot_ressources_pdr.select_pdr();
						this.select_article();
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

		// Token: 0x060008DF RID: 2271 RVA: 0x00176C7B File Offset: 0x00174E7B
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox1.Text;
		}
	}
}
