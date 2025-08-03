using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200010C RID: 268
	public partial class prod_param_saisie : Form
	{
		// Token: 0x06000BF6 RID: 3062 RVA: 0x001D5D38 File Offset: 0x001D3F38
		public prod_param_saisie()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000BF7 RID: 3063 RVA: 0x001D5DB0 File Offset: 0x001D3FB0
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 4;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez Supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "update prod_saisie set deleted = @d where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau(0);
					}
				}
			}
		}

		// Token: 0x06000BF8 RID: 3064 RVA: 0x001D5EB0 File Offset: 0x001D40B0
		private void panel3_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.Gray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000BF9 RID: 3065 RVA: 0x001D5EEA File Offset: 0x001D40EA
		private void button2_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button2);
		}

		// Token: 0x06000BFA RID: 3066 RVA: 0x001D5EFA File Offset: 0x001D40FA
		private void prod_param_saisie_Load(object sender, EventArgs e)
		{
			this.button2_Click(sender, e);
		}

		// Token: 0x06000BFB RID: 3067 RVA: 0x001D5F08 File Offset: 0x001D4108
		private void couleur_button(Button b)
		{
			this.TextBox1.Clear();
			this.guna2TextBox1.Clear();
			foreach (object obj in this.panel4.Controls)
			{
				Button button = (Button)obj;
				bool flag = button == b;
				if (flag)
				{
					button.ForeColor = Color.DimGray;
					button.BackColor = Color.White;
				}
				else
				{
					button.ForeColor = Color.White;
					button.BackColor = Color.DimGray;
				}
			}
			bool flag2 = b == this.button5;
			if (flag2)
			{
				this.panel2.Show();
				this.radGridView1.Columns[3].IsVisible = true;
			}
			else
			{
				this.panel2.Hide();
				this.radGridView1.Columns[3].IsVisible = false;
			}
			this.remplissage_tableau(0);
		}

		// Token: 0x06000BFC RID: 3068 RVA: 0x001D6020 File Offset: 0x001D4220
		private void button1_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button1);
		}

		// Token: 0x06000BFD RID: 3069 RVA: 0x001D6030 File Offset: 0x001D4230
		private void button3_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button3);
		}

		// Token: 0x06000BFE RID: 3070 RVA: 0x001D6040 File Offset: 0x001D4240
		private void button4_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button4);
		}

		// Token: 0x06000BFF RID: 3071 RVA: 0x001D6050 File Offset: 0x001D4250
		private void button5_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button5);
		}

		// Token: 0x06000C00 RID: 3072 RVA: 0x001D6060 File Offset: 0x001D4260
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			int num = 1;
			bool flag = this.button1.BackColor == Color.White;
			if (flag)
			{
				num = 2;
			}
			bool flag2 = this.button3.BackColor == Color.White;
			if (flag2)
			{
				num = 3;
			}
			bool flag3 = this.button4.BackColor == Color.White;
			if (flag3)
			{
				num = 4;
			}
			bool flag4 = this.button5.BackColor == Color.White;
			if (flag4)
			{
				num = 5;
			}
			fonction fonction = new fonction();
			bool flag5 = fonction.DeleteSpace(this.TextBox1.Text) != "";
			if (flag5)
			{
				bd bd = new bd();
				string cmdText = "select id from prod_saisie where designation = @t and deleted = @d and cible = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag6 = dataTable.Rows.Count == 0;
				if (flag6)
				{
					bool flag7 = num != 5;
					if (flag7)
					{
						string cmdText2 = "insert into prod_saisie (designation, unite, preparation_produit, cible, deleted, poid_sec_fab) values (@v1, @v2, @v3, @v4, @v5, @v6)";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand2.Parameters.Add("@v3", SqlDbType.VarChar).Value = "";
						sqlCommand2.Parameters.Add("@v4", SqlDbType.Int).Value = num;
						sqlCommand2.Parameters.Add("@v5", SqlDbType.Int).Value = 0;
						sqlCommand2.Parameters.Add("@v6", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Ajout avec succés");
						this.TextBox1.Clear();
						this.guna2TextBox1.Clear();
						this.remplissage_tableau(0);
					}
					else
					{
						int num2 = 0;
						bool flag8 = this.radCheckBox1.Checked & !this.radCheckBox2.Checked;
						if (flag8)
						{
							num2 = 1;
						}
						bool flag9 = !this.radCheckBox1.Checked & this.radCheckBox2.Checked;
						if (flag9)
						{
							num2 = 2;
						}
						bool flag10 = this.radCheckBox1.Checked & this.radCheckBox2.Checked;
						if (flag10)
						{
							num2 = 3;
						}
						string cmdText3 = "insert into prod_saisie (designation, unite, preparation_produit, cible, deleted, poid_sec_fab) values (@v1, @v2, @v3, @v4, @v5, @v6)";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand3.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand3.Parameters.Add("@v3", SqlDbType.VarChar).Value = num2;
						sqlCommand3.Parameters.Add("@v4", SqlDbType.Int).Value = num;
						sqlCommand3.Parameters.Add("@v5", SqlDbType.Int).Value = 0;
						sqlCommand3.Parameters.Add("@v6", SqlDbType.Int).Value = 0;
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Ajout avec succés");
						this.TextBox1.Clear();
						this.guna2TextBox1.Clear();
						this.remplissage_tableau(0);
					}
				}
				else
				{
					MessageBox.Show("Erreur : le champs de saisie déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Veuillez Choisir le champs de saisie", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000C01 RID: 3073 RVA: 0x001D64CC File Offset: 0x001D46CC
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			int num = 1;
			bool flag = this.button1.BackColor == Color.White;
			if (flag)
			{
				num = 2;
			}
			bool flag2 = this.button3.BackColor == Color.White;
			if (flag2)
			{
				num = 3;
			}
			bool flag3 = this.button4.BackColor == Color.White;
			if (flag3)
			{
				num = 4;
			}
			bool flag4 = this.button5.BackColor == Color.White;
			if (flag4)
			{
				num = 5;
			}
			bd bd = new bd();
			string cmdText = "select id, designation, unite, preparation_produit from prod_saisie where cible = @c and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@c", SqlDbType.Int).Value = num;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag5 = dataTable.Rows.Count != 0;
			if (flag5)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = "";
					bool flag6 = num == 5;
					if (flag6)
					{
						int num2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[3]);
						bool flag7 = num2 == 0;
						if (flag7)
						{
							text = "Ni Argile -  Ni Sable";
						}
						bool flag8 = num2 == 1;
						if (flag8)
						{
							text = "Argile";
						}
						bool flag9 = num2 == 2;
						if (flag9)
						{
							text = "Sable";
						}
						bool flag10 = num2 == 3;
						if (flag10)
						{
							text = "Argile + Sable";
						}
					}
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[2]),
						text,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}
	}
}
