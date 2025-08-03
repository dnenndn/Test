using System;
using System.Collections.Generic;
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
	// Token: 0x02000057 RID: 87
	public partial class creer_da : Form
	{
		// Token: 0x06000418 RID: 1048 RVA: 0x000AFF2C File Offset: 0x000AE12C
		public creer_da()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			creer_da.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			creer_da.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radMenuItem1.Click += this.click_ajouter;
			creer_da.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x06000419 RID: 1049 RVA: 0x000AFFC4 File Offset: 0x000AE1C4
		private void creer_da_Load(object sender, EventArgs e)
		{
			this.pictureBox2.Hide();
			bool flag = page_loginn.stat_user == "Responsable Achat" | page_loginn.stat_user == "Responsable Méthode" | page_loginn.stat_user == "Responsable Magasin";
			if (flag)
			{
				this.radDropDownList6.Items.Clear();
				this.label18.Show();
				this.radDropDownList6.Show();
				bd bd = new bd();
				string cmdText = "select login from utilisateur where deleted  = @d";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
					}
				}
				this.radDropDownList6.Text = page_loginn.esm;
			}
			else
			{
				this.label18.Hide();
				this.radDropDownList6.Hide();
				this.radDropDownList6.Items.Clear();
				this.radDropDownList6.Items.Add(page_loginn.esm);
				this.radDropDownList6.Text = page_loginn.esm;
			}
			this.select_periode();
			this.select_article();
			creer_da.table.Columns.Clear();
			creer_da.table.Columns.Add("column1");
			creer_da.table.Columns.Add("column2");
			creer_da.table.Columns.Add("column3");
		}

		// Token: 0x0600041A RID: 1050 RVA: 0x000B01B8 File Offset: 0x000AE3B8
		private void select_periode()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Jour");
			this.radDropDownList1.Items.Add("Semaine");
			this.radDropDownList1.Items.Add("Mois");
			this.radDropDownList1.Items.Add("Année");
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x000B0230 File Offset: 0x000AE430
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

		// Token: 0x0600041C RID: 1052 RVA: 0x000B0374 File Offset: 0x000AE574
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
				bool flag2 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select id from tableau_article_equipement where id_article = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = selectedNode.Tag;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						creer_da.radGridView1.Rows.Add(new object[]
						{
							Convert.ToString(selectedNode.Tag),
							selectedNode.ToolTipText,
							0,
							""
						});
						creer_da.radGridView1.Rows[creer_da.radGridView1.Rows.Count - 1].Cells[5].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
					}
					else
					{
						creer_da.radGridView1.Rows.Add(new object[]
						{
							Convert.ToString(selectedNode.Tag),
							selectedNode.ToolTipText,
							0,
							"",
							Resources.icons8_structure_en_arbre_80,
							Resources.icons8_supprimer_pour_toujours_100__4_
						});
					}
					creer_da.radGridView1.Templates.Clear();
					creer_da.select_equipement();
				}
				else
				{
					MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x000B0520 File Offset: 0x000AE720
		private int search_tableau(string s)
		{
			int result = 0;
			bool flag = creer_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < creer_da.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(creer_da.radGridView1.Rows[i].Cells[0].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x000B05A4 File Offset: 0x000AE7A4
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = creer_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag3)
					{
						string cmdText = "select id from tableau_article_equipement where id_article = @i";
						bd bd = new bd();
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = creer_da.radGridView1.Rows[e.RowIndex].Cells[0].Value;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count != 0;
						if (flag4)
						{
							creer_da.id_article = creer_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
							creer_da.designation_article = creer_da.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
							da_add_equipement da_add_equipement = new da_add_equipement();
							da_add_equipement.Show();
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 5;
					if (flag5)
					{
						string b = creer_da.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag6 = dialogResult == DialogResult.Yes;
						if (flag6)
						{
							creer_da.radGridView1.Rows.RemoveAt(e.RowIndex);
							bool flag7 = creer_da.table.Rows.Count != 0;
							if (flag7)
							{
								for (int i = 0; i < creer_da.table.Rows.Count; i++)
								{
									bool flag8 = creer_da.table.Rows[i].ItemArray[0].ToString() == b;
									if (flag8)
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

		// Token: 0x0600041F RID: 1055 RVA: 0x000B0810 File Offset: 0x000AEA10
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x000B082C File Offset: 0x000AEA2C
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox5.Text) != "" & fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				bool flag2 = this.test_validation_tableau() == 1;
				if (flag2)
				{
					bool flag3 = this.test_obligatoire_equipement() == 1;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "insert into demande_achat (date_da, heure_da, delai, periode, createur, demandeur, statut, vue) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8)SELECT CAST(scope_identity() AS int)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = DateTime.Today;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = fonction.Mid(DateTime.Now.ToString(), 12, 5);
						sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox5.Text;
						sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
						sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = page_loginn.id_user;
						sqlCommand.Parameters.Add("@i7", SqlDbType.Int).Value = 0;
						sqlCommand.Parameters.Add("@i8", SqlDbType.Int).Value = 0;
						string cmdText2 = "select id from utilisateur where login = @v";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@v", SqlDbType.VarChar).Value = this.radDropDownList6.Text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						sqlCommand.Parameters.Add("@i6", SqlDbType.Int).Value = dataTable.Rows[0].ItemArray[0];
						bd.ouverture_bd(bd.cnn);
						int id = (int)sqlCommand.ExecuteScalar();
						bd.cnn.Close();
						this.save_da_article(id);
						this.save_fichier(id);
						MessageBox.Show("DA est crée avec succés");
						this.TextBox5.Clear();
						this.select_periode();
						this.liste_adresse.Clear();
						this.recherche_fichier();
						creer_da.radGridView1.Rows.Clear();
						creer_da.table.Rows.Clear();
					}
					else
					{
						MessageBox.Show("Erreur : Liaison équipement article ou motif manquants ", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
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

		// Token: 0x06000421 RID: 1057 RVA: 0x000B0B10 File Offset: 0x000AED10
		private int test_validation_tableau()
		{
			int result = 0;
			bool flag = creer_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				result = 1;
				fonction fonction = new fonction();
				for (int i = 0; i < creer_da.radGridView1.Rows.Count; i++)
				{
					bool flag2 = !fonction.is_reel(creer_da.radGridView1.Rows[i].Cells[2].Value.ToString()) | creer_da.radGridView1.Rows[i].Cells[2].Value.ToString() == "0";
					if (flag2)
					{
						result = 0;
					}
				}
			}
			return result;
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x000B0BD8 File Offset: 0x000AEDD8
		private void save_da_article(int id)
		{
			bd bd = new bd();
			for (int i = 0; i < creer_da.radGridView1.Rows.Count; i++)
			{
				string cmdText = "insert into da_article (id_da, id_article, qt, motif, qt_restant) values (@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
				sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = creer_da.radGridView1.Rows[i].Cells[0].Value.ToString();
				sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = creer_da.radGridView1.Rows[i].Cells[2].Value.ToString();
				sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = creer_da.radGridView1.Rows[i].Cells[3].Value.ToString();
				sqlCommand.Parameters.Add("@i5", SqlDbType.Real).Value = creer_da.radGridView1.Rows[i].Cells[2].Value.ToString();
				bd.ouverture_bd(bd.cnn);
				int id_lis = (int)sqlCommand.ExecuteScalar();
				bd.cnn.Close();
				this.save_da_article_equipement(id, id_lis, creer_da.radGridView1.Rows[i].Cells[0].Value.ToString());
			}
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x000B0D8C File Offset: 0x000AEF8C
		private void save_da_article_equipement(int id, int id_lis, string id_art)
		{
			bd bd = new bd();
			bool flag = creer_da.table.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < creer_da.table.Rows.Count; i++)
				{
					bool flag2 = creer_da.table.Rows[i].ItemArray[0].ToString() == id_art;
					if (flag2)
					{
						string cmdText = "insert into da_article_equipement (id_da, id_article, id_equipement, id_lis) values (@i1, @i2, @i3, @i4)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = creer_da.table.Rows[i].ItemArray[0];
						sqlCommand.Parameters.Add("@i3", SqlDbType.Real).Value = creer_da.table.Rows[i].ItemArray[1];
						sqlCommand.Parameters.Add("@i4", SqlDbType.Int).Value = id_lis;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
					}
				}
			}
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x000B0EE0 File Offset: 0x000AF0E0
		public static void select_equipement()
		{
			creer_da.radGridView1.Templates.Clear();
			GridViewTemplate gridViewTemplate = new GridViewTemplate();
			gridViewTemplate.Caption = "Liaison Equipement";
			gridViewTemplate.DataSource = creer_da.table;
			gridViewTemplate.AllowRowResize = false;
			gridViewTemplate.ShowColumnHeaders = true;
			gridViewTemplate.AllowAddNewRow = false;
			gridViewTemplate.Columns["column1"].Width = 200;
			gridViewTemplate.Columns["column2"].Width = 200;
			gridViewTemplate.Columns["column3"].Width = 400;
			gridViewTemplate.Columns[0].IsVisible = false;
			gridViewTemplate.AllowEditRow = false;
			gridViewTemplate.Columns[1].HeaderText = "ID Equipement";
			gridViewTemplate.Columns[2].HeaderText = "Désignation";
			gridViewTemplate.Columns[1].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			gridViewTemplate.Columns[2].HeaderTextAlignment = ContentAlignment.MiddleLeft;
			creer_da.radGridView1.Templates.Insert(0, gridViewTemplate);
			GridViewRelation gridViewRelation = new GridViewRelation(creer_da.radGridView1.MasterTemplate);
			gridViewRelation.ChildTemplate = gridViewTemplate;
			gridViewRelation.ParentColumnNames.Add(creer_da.radGridView1.MasterTemplate.Columns[0].Name);
			gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
			creer_da.radGridView1.Relations.Add(gridViewRelation);
			creer_da.radGridView1.MasterTemplate.CollapseAll();
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x000B1084 File Offset: 0x000AF284
		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = creer_da.table.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < creer_da.table.Rows.Count; i++)
				{
					object obj = creer_da.table.Rows[i].ItemArray[0];
					string str = (obj != null) ? obj.ToString() : null;
					string str2 = "-";
					object obj2 = creer_da.table.Rows[i].ItemArray[1];
					MessageBox.Show(str + str2 + ((obj2 != null) ? obj2.ToString() : null));
				}
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x000B1120 File Offset: 0x000AF320
		private int recherche_data_table(DataTable table, string s)
		{
			int result = 0;
			for (int i = 0; i < table.Rows.Count; i++)
			{
				bool flag = s == table.Rows[i].ItemArray[0].ToString();
				if (flag)
				{
					result = 1;
				}
			}
			return result;
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x000B117C File Offset: 0x000AF37C
		private int test_obligatoire_equipement()
		{
			bd bd = new bd();
			fonction fonction = new fonction();
			int result = 1;
			bool flag = creer_da.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < creer_da.radGridView1.Rows.Count; i++)
				{
					string cmdText = "select id from tableau_article_equipement where id_article = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = creer_da.radGridView1.Rows[i].Cells[0].Value.ToString();
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag2 = dataTable.Rows.Count != 0;
					if (flag2)
					{
						bool flag3 = this.recherche_data_table(creer_da.table, creer_da.radGridView1.Rows[i].Cells[0].Value.ToString()) == 0;
						if (flag3)
						{
							result = 0;
						}
					}
					else
					{
						bool flag4 = fonction.DeleteSpace(Convert.ToString(creer_da.radGridView1.Rows[i].Cells[3].Value)) == "";
						if (flag4)
						{
							result = 0;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06000428 RID: 1064 RVA: 0x000B12F0 File Offset: 0x000AF4F0
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(openFileDialog.FileName) != "";
			if (flag)
			{
				this.liste_adresse.Add(openFileDialog.FileName);
			}
			this.recherche_fichier();
		}

		// Token: 0x06000429 RID: 1065 RVA: 0x000B1354 File Offset: 0x000AF554
		private void recherche_fichier()
		{
			fonction fonction = new fonction();
			this.radPanel1.Controls.Clear();
			bool flag = this.liste_adresse.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.liste_adresse.Count; i++)
				{
					PictureBox pictureBox = new PictureBox();
					pictureBox.Size = new Size(48, 30);
					pictureBox.Cursor = Cursors.Hand;
					pictureBox.Location = new Point(5 + 100 * i, 7);
					pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
					string h = Convert.ToString(this.liste_adresse[i]);
					pictureBox.Click += delegate(object s, EventArgs e)
					{
						fonction.ouvrir_fichier(h);
					};
					bool flag2 = this.n_fichier(h) == "dwg";
					if (flag2)
					{
						pictureBox.Image = this.imageList1.Images[9];
					}
					else
					{
						bool flag3 = this.n_fichier(h) == "png" | this.n_fichier(h) == "jpeg" | this.n_fichier(h) == "jpg";
						if (flag3)
						{
							pictureBox.Image = this.imageList1.Images[7];
						}
						else
						{
							bool flag4 = this.n_fichier(h) == "xlsx" | this.n_fichier(h) == "xls";
							if (flag4)
							{
								pictureBox.Image = this.imageList1.Images[4];
							}
							else
							{
								bool flag5 = this.n_fichier(h) == "pdf";
								if (flag5)
								{
									pictureBox.Image = this.imageList1.Images[5];
								}
								else
								{
									bool flag6 = this.n_fichier(h) == "txt";
									if (flag6)
									{
										pictureBox.Image = this.imageList1.Images[6];
									}
									else
									{
										bool flag7 = this.n_fichier(h) == "docx";
										if (flag7)
										{
											pictureBox.Image = this.imageList1.Images[3];
										}
										else
										{
											bool flag8 = this.n_fichier(h) == "rar" | this.n_fichier(h) == "zip";
											if (flag8)
											{
												pictureBox.Image = this.imageList1.Images[8];
											}
											else
											{
												pictureBox.Image = this.imageList1.Images[9];
											}
										}
									}
								}
							}
						}
					}
					PictureBox pictureBox2 = new PictureBox();
					pictureBox2.Size = new Size(15, 15);
					pictureBox2.Cursor = Cursors.Hand;
					pictureBox2.Location = new Point(56 + 100 * i, 7);
					pictureBox2.Image = this.pictureBox2.Image;
					pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
					pictureBox2.Click += delegate(object s, EventArgs e)
					{
						this.supprimer_file(h);
					};
					this.radPanel1.Controls.Add(pictureBox);
					this.radPanel1.Controls.Add(pictureBox2);
					Label label = new Label();
					label.AutoSize = true;
					label.BackColor = Color.Transparent;
					label.ForeColor = Color.Black;
					label.Location = new Point(5 + 100 * i, 45);
					label.Cursor = Cursors.Default;
					label.Text = this.nom_fichier(h);
					this.radPanel1.Controls.Add(label);
				}
			}
		}

		// Token: 0x0600042A RID: 1066 RVA: 0x000B1748 File Offset: 0x000AF948
		public string n_fichier(string h)
		{
			int num = 0;
			int length = h.Length;
			for (int i = 1; i < length + 1; i++)
			{
				bool flag = fonction.Mid(h, i, 1) == ".";
				if (flag)
				{
					num = i;
				}
			}
			return fonction.Mid(h, num + 1, length - num);
		}

		// Token: 0x0600042B RID: 1067 RVA: 0x000B17A8 File Offset: 0x000AF9A8
		public string nom_fichier(string h)
		{
			int num = 0;
			int length = h.Length;
			for (int i = 1; i < length + 1; i++)
			{
				bool flag = fonction.Mid(h, i, 1) == "\\";
				if (flag)
				{
					num = i;
				}
			}
			return fonction.Mid(h, num + 1, length - num);
		}

		// Token: 0x0600042C RID: 1068 RVA: 0x000B1808 File Offset: 0x000AFA08
		private void supprimer_file(string x)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				this.liste_adresse.Remove(x);
				this.recherche_fichier();
			}
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x000B1848 File Offset: 0x000AFA48
		private void save_fichier(int id)
		{
			bd bd = new bd();
			bool flag = this.liste_adresse.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.liste_adresse.Count; i++)
				{
					string cmdText = "insert into da_fichier (id_da, adresse) values (@i1, @i2)";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id;
					sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.liste_adresse[i];
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x040005A0 RID: 1440
		public static DataTable table = new DataTable();

		// Token: 0x040005A1 RID: 1441
		public static string id_article;

		// Token: 0x040005A2 RID: 1442
		public static string designation_article;

		// Token: 0x040005A3 RID: 1443
		private List<string> liste_adresse = new List<string>();
	}
}
