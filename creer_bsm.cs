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
	// Token: 0x02000053 RID: 83
	public partial class creer_bsm : Form
	{
		// Token: 0x060003B8 RID: 952 RVA: 0x0009D660 File Offset: 0x0009B860
		public creer_bsm()
		{
			this.InitializeComponent();
			this.radRadioButton1.CheckStateChanged += delegate(object s, EventArgs f)
			{
				this.radb1_change();
			};
			this.radRadioButton2.CheckStateChanged += delegate(object s, EventArgs f)
			{
				this.radb2_change();
			};
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			creer_bsm.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			creer_bsm.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radMenuItem1.Click += this.click_ajouter;
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x0009D74C File Offset: 0x0009B94C
		private void radb1_change()
		{
			bool isChecked = this.radRadioButton1.IsChecked;
			if (isChecked)
			{
				this.label10.Show();
				this.label14.Show();
				this.TextBox1.Show();
			}
			else
			{
				this.label10.Hide();
				this.label14.Hide();
				this.TextBox1.Hide();
			}
		}

		// Token: 0x060003BA RID: 954 RVA: 0x0009D7B8 File Offset: 0x0009B9B8
		private void radb2_change()
		{
			bool flag = !this.radRadioButton2.IsChecked;
			if (flag)
			{
				this.label10.Show();
				this.label14.Show();
				this.TextBox1.Show();
			}
			else
			{
				this.label10.Hide();
				this.label14.Hide();
				this.TextBox1.Hide();
			}
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0009D826 File Offset: 0x0009BA26
		private void creer_bsm_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radTimePicker1.Value = new DateTime?(DateTime.Now);
			this.select_intervenant();
			this.select_article();
		}

		// Token: 0x060003BC RID: 956 RVA: 0x0009D860 File Offset: 0x0009BA60
		private void select_article()
		{
			this.radTreeView1.Nodes.Clear();
			this.radGridView1.Columns[2].IsVisible = true;
			this.radGridView1.Columns[3].IsVisible = true;
			this.radGridView1.Columns[4].IsVisible = false;
			bd bd = new bd();
			string cmdText = "select id, designation ,stock_neuf from article where deleted =@d and stock_neuf <> @d order by designation";
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

		// Token: 0x060003BD RID: 957 RVA: 0x0009D9FC File Offset: 0x0009BBFC
		private void select_article_repare()
		{
			this.radTreeView1.Nodes.Clear();
			this.radGridView1.Columns[2].IsVisible = false;
			this.radGridView1.Columns[3].IsVisible = false;
			this.radGridView1.Columns[4].IsVisible = true;
			bd bd = new bd();
			string cmdText = "select magasin_sous_traitance.id, article.designation ,ref_interne from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id where article.deleted =@d and emplacement_actuel = @m  order by article.designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@m", SqlDbType.VarChar).Value = "Magasin";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					RadTreeNode radTreeNode = new RadTreeNode();
					radTreeNode.Text = dataTable.Rows[i].ItemArray[1].ToString() + " - " + dataTable.Rows[i].ItemArray[2].ToString();
					radTreeNode.Tag = dataTable.Rows[i].ItemArray[0].ToString();
					radTreeNode.ToolTipText = dataTable.Rows[i].ItemArray[1].ToString();
					this.radTreeView1.Nodes.Add(radTreeNode);
				}
			}
		}

		// Token: 0x060003BE RID: 958 RVA: 0x0009DBB4 File Offset: 0x0009BDB4
		private void select_article_usee()
		{
			this.radGridView1.Columns[2].IsVisible = true;
			this.radGridView1.Columns[3].IsVisible = true;
			this.radGridView1.Columns[4].IsVisible = false;
			this.radTreeView1.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation ,stock_use from article where deleted =@d and stock_use <> @d order by designation";
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

		// Token: 0x060003BF RID: 959 RVA: 0x0009DD50 File Offset: 0x0009BF50
		private void select_article_rebute()
		{
			this.radGridView1.Columns[2].IsVisible = true;
			this.radGridView1.Columns[3].IsVisible = true;
			this.radGridView1.Columns[4].IsVisible = false;
			this.radTreeView1.Nodes.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation ,stock_rebute from article where deleted =@d and stock_rebute <> @d order by designation";
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

		// Token: 0x060003C0 RID: 960 RVA: 0x0009DEEC File Offset: 0x0009C0EC
		private void click_ajouter(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				bool flag2 = !this.radRadioButton6.IsChecked;
				if (flag2)
				{
					RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
					bool flag3 = this.search_tableau(Convert.ToString(selectedNode.Tag)) == 0;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "select parametre_unite_article.designation from tableau_article_unite inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where id_article = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = selectedNode.Tag;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						string cmdText2 = "";
						bool isChecked = this.radRadioButton4.IsChecked;
						if (isChecked)
						{
							cmdText2 = "select stock_neuf from article where id = @i1";
						}
						bool isChecked2 = this.radRadioButton3.IsChecked;
						if (isChecked2)
						{
							cmdText2 = "select stock_use from article where id = @i1";
						}
						bool isChecked3 = this.radRadioButton5.IsChecked;
						if (isChecked3)
						{
							cmdText2 = "select stock_rebute from article where id = @i1";
						}
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = selectedNode.Tag;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						this.radGridView1.Rows.Add(new object[]
						{
							Convert.ToString(selectedNode.Tag),
							selectedNode.ToolTipText,
							0,
							Convert.ToString(dataTable2.Rows[0].ItemArray[0]),
							"-",
							Convert.ToString(dataTable.Rows[0].ItemArray[0])
						});
						this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[6].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
						this.radGridView1.Templates.Clear();
					}
					else
					{
						MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					this.click_ajouter_repare(sender, e);
				}
			}
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x0009E130 File Offset: 0x0009C330
		private void click_ajouter_repare(object sender, EventArgs e)
		{
			bool flag = this.radTreeView1.SelectedNode != null;
			if (flag)
			{
				bool isChecked = this.radRadioButton6.IsChecked;
				if (isChecked)
				{
					RadTreeNode selectedNode = this.radTreeView1.SelectedNode;
					bool flag2 = this.search_tableau_repare(Convert.ToString(selectedNode.Tag)) == 0;
					if (flag2)
					{
						bd bd = new bd();
						string cmdText = "select magasin_sous_traitance.id, article.designation ,ref_interne, article.id from magasin_sous_traitance inner join article on magasin_sous_traitance.id_article = article.id where magasin_sous_traitance.id = @i1";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = selectedNode.Tag;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						string cmdText2 = "select parametre_unite_article.designation from tableau_article_unite inner join parametre_unite_article on tableau_article_unite.id_unite = parametre_unite_article.id where id_article = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = Convert.ToInt32(dataTable.Rows[0].ItemArray[3]);
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						this.radGridView1.Rows.Add(new object[]
						{
							dataTable.Rows[0].ItemArray[3],
							selectedNode.ToolTipText,
							0,
							0,
							dataTable.Rows[0].ItemArray[2],
							Convert.ToString(dataTable2.Rows[0].ItemArray[0])
						});
						this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[6].Value = Resources.icons8_supprimer_pour_toujours_100__4_;
						this.radGridView1.Rows[this.radGridView1.Rows.Count - 1].Cells[7].Value = Convert.ToString(selectedNode.Tag);
						this.radGridView1.Templates.Clear();
					}
					else
					{
						MessageBox.Show("Erreur : L'article est déja ajouté", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x0009E36C File Offset: 0x0009C56C
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

		// Token: 0x060003C3 RID: 963 RVA: 0x0009E3F4 File Offset: 0x0009C5F4
		private int search_tableau_repare(string s)
		{
			int result = 0;
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < this.radGridView1.Rows.Count; i++)
				{
					bool flag2 = Convert.ToString(this.radGridView1.Rows[i].Cells[7].Value) == s;
					if (flag2)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x0009E47C File Offset: 0x0009C67C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 6;
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

		// Token: 0x060003C5 RID: 965 RVA: 0x0009E53C File Offset: 0x0009C73C
		private void select_intervenant()
		{
			this.radDropDownList6.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, nom from intervenant where deleted = @i order by nom";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList6.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x0009E644 File Offset: 0x0009C844
		private void radRadioButton4_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton4.IsChecked;
			if (isChecked)
			{
				this.radGridView1.Rows.Clear();
				this.select_article();
			}
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x0009E67C File Offset: 0x0009C87C
		private void radRadioButton3_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton3.IsChecked;
			if (isChecked)
			{
				this.radGridView1.Rows.Clear();
				this.select_article_usee();
			}
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x0009E6B4 File Offset: 0x0009C8B4
		private void radRadioButton5_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton5.IsChecked;
			if (isChecked)
			{
				this.radGridView1.Rows.Clear();
				this.select_article_rebute();
			}
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x0009E6EC File Offset: 0x0009C8EC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = creer_bsm.radGridView2.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = !this.radRadioButton6.IsChecked;
				if (flag2)
				{
					int num = 1;
					fonction fonction = new fonction();
					bool isChecked = this.radRadioButton1.IsChecked;
					if (isChecked)
					{
					}
					bool flag3 = num == 1;
					if (flag3)
					{
						bool flag4 = this.radDropDownList6.Text != "";
						if (flag4)
						{
							bool flag5 = this.radGridView1.Rows.Count != 0;
							if (flag5)
							{
								int num2 = 1;
								for (int i = 0; i < this.radGridView1.Rows.Count; i++)
								{
									bool flag6 = fonction.is_reel(this.radGridView1.Rows[i].Cells[2].Value.ToString());
									if (flag6)
									{
										bool flag7 = Convert.ToDouble(this.radGridView1.Rows[i].Cells[2].Value.ToString()) <= 0.0;
										if (flag7)
										{
											num2 = 0;
										}
									}
									else
									{
										num2 = 0;
									}
								}
								bool flag8 = num2 == 1;
								if (flag8)
								{
									int num3 = 1;
									for (int j = 0; j < this.radGridView1.Rows.Count; j++)
									{
										bool flag9 = Convert.ToDouble(this.radGridView1.Rows[j].Cells[2].Value.ToString()) > Convert.ToDouble(this.radGridView1.Rows[j].Cells[3].Value.ToString());
										if (flag9)
										{
											num3 = 0;
										}
									}
									bool flag10 = num3 == 1;
									if (flag10)
									{
										bd bd = new bd();
										string value = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 8);
										string text = "Non";
										bool isChecked2 = this.radRadioButton1.IsChecked;
										if (isChecked2)
										{
											text = "Oui";
										}
										string text2 = "";
										bool isChecked3 = this.radRadioButton4.IsChecked;
										if (isChecked3)
										{
											text2 = "Neuf";
										}
										bool isChecked4 = this.radRadioButton3.IsChecked;
										if (isChecked4)
										{
											text2 = "Usé";
										}
										bool isChecked5 = this.radRadioButton5.IsChecked;
										if (isChecked5)
										{
											text2 = "Rebuté";
										}
										bool flag11 = text == "Oui";
										string cmdText;
										if (flag11)
										{
											cmdText = "insert into bsm (type_stock, bsm_maintenance, id_receptionniste, n_ot, createur, date_bsm, heure_bsm, validation) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8)SELECT CAST(scope_identity() AS int)";
										}
										else
										{
											cmdText = "insert into bsm (type_stock, bsm_maintenance, id_receptionniste, createur, date_bsm, heure_bsm, validation) values (@i1, @i2, @i3, @i5, @i6, @i7, @i8)SELECT CAST(scope_identity() AS int)";
										}
										SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
										bool flag12 = text == "Oui";
										if (flag12)
										{
											sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.TextBox1.Text;
										}
										sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = text2;
										sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = text;
										sqlCommand.Parameters.Add("@i3", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
										sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = page_loginn.id_user;
										sqlCommand.Parameters.Add("@i6", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
										sqlCommand.Parameters.Add("@i7", SqlDbType.VarChar).Value = value;
										sqlCommand.Parameters.Add("@i8", SqlDbType.VarChar).Value = "Non";
										bd.ouverture_bd(bd.cnn);
										int num4 = (int)sqlCommand.ExecuteScalar();
										bd.cnn.Close();
										string cmdText2 = "insert into bsm_equipement (id_bsm, id_equipement) values (@i1, @i2)";
										SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
										sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = num4;
										sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = creer_bsm.radGridView2.Rows[0].Cells[0].Value.ToString();
										bd.ouverture_bd(bd.cnn);
										sqlCommand2.ExecuteNonQuery();
										bd.cnn.Close();
										for (int k = 0; k < this.radGridView1.Rows.Count; k++)
										{
											string cmdText3 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
											SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
											sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[k].Cells[0].Value.ToString();
											SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand3);
											DataTable dataTable = new DataTable();
											sqlDataAdapter.Fill(dataTable);
											string cmdText4 = "insert into bsm_article (id_bsm, id_article, quantite, prix_ht) values (@i1, @i2, @i3, @i4)";
											SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
											sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = num4;
											sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[k].Cells[0].Value.ToString();
											sqlCommand4.Parameters.Add("@i3", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[2].Value.ToString();
											sqlCommand4.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
											string cmdText5 = "";
											bool flag13 = text2 == "Neuf";
											if (flag13)
											{
												cmdText5 = "update article set stock_neuf = stock_neuf - @v where id = @i";
											}
											bool flag14 = text2 == "Usé";
											if (flag14)
											{
												cmdText5 = "update article set stock_use = stock_use - @v where id = @i";
											}
											bool flag15 = text2 == "Rebuté";
											if (flag15)
											{
												cmdText5 = "update article set stock_rebute = stock_rebute - @v where id = @i";
											}
											SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
											sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[k].Cells[0].Value.ToString();
											sqlCommand5.Parameters.Add("@v", SqlDbType.Real).Value = this.radGridView1.Rows[k].Cells[2].Value.ToString();
											bd.ouverture_bd(bd.cnn);
											sqlCommand4.ExecuteNonQuery();
											sqlCommand5.ExecuteNonQuery();
											bd.cnn.Close();
											string cmdText6 = "insert into modification_article (id_article, tva, prix_ht, stock_neuf, stock_use, stock_rebute, date_modification) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7)";
											SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
											sqlCommand6.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView1.Rows[k].Cells[0].Value.ToString();
											sqlCommand6.Parameters.Add("@i2", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[0]);
											sqlCommand6.Parameters.Add("@i3", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
											sqlCommand6.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
											sqlCommand6.Parameters.Add("@i5", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
											sqlCommand6.Parameters.Add("@i6", SqlDbType.Real).Value = Convert.ToString(dataTable.Rows[0].ItemArray[4]);
											sqlCommand6.Parameters.Add("@i7", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
											bd.ouverture_bd(bd.cnn);
											sqlCommand6.ExecuteNonQuery();
											bd.cnn.Close();
										}
										this.TextBox1.Clear();
										this.radRadioButton4.IsChecked = true;
										this.select_article();
										this.radGridView1.Rows.Clear();
										creer_bsm.radGridView2.Rows.Clear();
										this.select_intervenant();
										MessageBox.Show("Création d'un BSM avec succés");
									}
									else
									{
										MessageBox.Show("Erreur : La quantité choisit doit être inférieure ou égale à la quantité en stock", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
									}
								}
								else
								{
									MessageBox.Show("Erreur : La quantité doit être un réel strictement positive", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
								}
							}
							else
							{
								MessageBox.Show("Erreur : Il faut choisir au moin un article dans le BSM", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : Il faut choisir un réceptionniste", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Format de l'OT est incorrecte, le format est de la forme N-N", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					bool flag16 = this.radGridView1.Rows.Count != 0;
					if (flag16)
					{
						bool flag17 = this.radDropDownList6.Text != "";
						if (flag17)
						{
							int num5 = 1;
							fonction fonction2 = new fonction();
							bool isChecked6 = this.radRadioButton1.IsChecked;
							if (isChecked6)
							{
							}
							bool flag18 = num5 == 1;
							if (flag18)
							{
								bd bd2 = new bd();
								string value2 = fonction.Mid(this.radTimePicker1.Value.ToString(), 12, 8);
								string text3 = "Non";
								bool isChecked7 = this.radRadioButton1.IsChecked;
								if (isChecked7)
								{
									text3 = "Oui";
								}
								string value3 = "Réparable";
								bool flag19 = text3 == "Oui";
								string cmdText7;
								if (flag19)
								{
									cmdText7 = "insert into bsm (type_stock, bsm_maintenance, id_receptionniste, n_ot, createur, date_bsm, heure_bsm, validation) values (@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i8)SELECT CAST(scope_identity() AS int)";
								}
								else
								{
									cmdText7 = "insert into bsm (type_stock, bsm_maintenance, id_receptionniste, createur, date_bsm, heure_bsm, validation) values (@i1, @i2, @i3, @i5, @i6, @i7, @i8)SELECT CAST(scope_identity() AS int)";
								}
								SqlCommand sqlCommand7 = new SqlCommand(cmdText7, bd2.cnn);
								bool flag20 = text3 == "Oui";
								if (flag20)
								{
									sqlCommand7.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.TextBox1.Text;
								}
								sqlCommand7.Parameters.Add("@i1", SqlDbType.VarChar).Value = value3;
								sqlCommand7.Parameters.Add("@i2", SqlDbType.VarChar).Value = text3;
								sqlCommand7.Parameters.Add("@i3", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag;
								sqlCommand7.Parameters.Add("@i5", SqlDbType.Int).Value = page_loginn.id_user;
								sqlCommand7.Parameters.Add("@i6", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
								sqlCommand7.Parameters.Add("@i7", SqlDbType.VarChar).Value = value2;
								sqlCommand7.Parameters.Add("@i8", SqlDbType.VarChar).Value = "Non";
								bd2.ouverture_bd(bd2.cnn);
								int num6 = (int)sqlCommand7.ExecuteScalar();
								bd2.cnn.Close();
								string cmdText8 = "insert into bsm_equipement (id_bsm, id_equipement) values (@i1, @i2)";
								SqlCommand sqlCommand8 = new SqlCommand(cmdText8, bd2.cnn);
								sqlCommand8.Parameters.Add("@i1", SqlDbType.Int).Value = num6;
								sqlCommand8.Parameters.Add("@i2", SqlDbType.Int).Value = creer_bsm.radGridView2.Rows[0].Cells[0].Value.ToString();
								bd2.ouverture_bd(bd2.cnn);
								sqlCommand8.ExecuteNonQuery();
								bd2.cnn.Close();
								for (int l = 0; l < this.radGridView1.Rows.Count; l++)
								{
									string cmdText9 = "select tva, prix_ht, stock_neuf, stock_use, stock_rebute from article where id = @i";
									SqlCommand sqlCommand9 = new SqlCommand(cmdText9, bd2.cnn);
									sqlCommand9.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[l].Cells[0].Value.ToString();
									SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand9);
									DataTable dataTable2 = new DataTable();
									sqlDataAdapter2.Fill(dataTable2);
									string cmdText10 = "insert into bsm_article (id_bsm, id_article, quantite, prix_ht) values (@i1, @i2, @i3, @i4)";
									SqlCommand sqlCommand10 = new SqlCommand(cmdText10, bd2.cnn);
									sqlCommand10.Parameters.Add("@i1", SqlDbType.Int).Value = num6;
									sqlCommand10.Parameters.Add("@i2", SqlDbType.Int).Value = this.radGridView1.Rows[l].Cells[0].Value.ToString();
									sqlCommand10.Parameters.Add("@i3", SqlDbType.Real).Value = "1";
									sqlCommand10.Parameters.Add("@i4", SqlDbType.Real).Value = Convert.ToString(dataTable2.Rows[0].ItemArray[1]);
									string cmdText11 = "insert into ds_historique_mvt (id_t, id_mvt, date_mvt, heure_mvt, mvt) values (@i1, @i2, @i3, @i4, @i5)";
									SqlCommand sqlCommand11 = new SqlCommand(cmdText11, bd2.cnn);
									sqlCommand11.Parameters.Add("@i1", SqlDbType.Int).Value = this.radGridView1.Rows[l].Cells[7].Value.ToString();
									sqlCommand11.Parameters.Add("@i2", SqlDbType.Int).Value = num6;
									sqlCommand11.Parameters.Add("@i3", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
									sqlCommand11.Parameters.Add("@i4", SqlDbType.VarChar).Value = value2;
									sqlCommand11.Parameters.Add("@i5", SqlDbType.VarChar).Value = "BSM";
									string cmdText12 = "update magasin_sous_traitance set emplacement_actuel = @u, equipement_actuel = @e where id = @i";
									SqlCommand sqlCommand12 = new SqlCommand(cmdText12, bd2.cnn);
									sqlCommand12.Parameters.Add("@u", SqlDbType.VarChar).Value = "Usine";
									sqlCommand12.Parameters.Add("@e", SqlDbType.Int).Value = creer_bsm.radGridView2.Rows[0].Cells[0].Value.ToString();
									sqlCommand12.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView1.Rows[l].Cells[7].Value.ToString();
									bd2.ouverture_bd(bd2.cnn);
									sqlCommand9.ExecuteNonQuery();
									sqlCommand10.ExecuteNonQuery();
									sqlCommand11.ExecuteNonQuery();
									sqlCommand12.ExecuteNonQuery();
									bd2.cnn.Close();
								}
								this.TextBox1.Clear();
								this.radRadioButton4.IsChecked = true;
								this.select_article();
								this.radGridView1.Rows.Clear();
								creer_bsm.radGridView2.Rows.Clear();
								this.select_intervenant();
								MessageBox.Show("Création d'un BSM avec succés");
							}
							else
							{
								MessageBox.Show("Erreur : Format de l'OT est incorrecte, le format est de la forme N-N", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur : Il faut choisir un réceptionniste", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Il faut choisir au moin un article dans le BSM", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				MessageBox.Show("Erreur : Il faut choisir l'emplacement : Arbre Equipement", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x060003CA RID: 970 RVA: 0x0009F764 File Offset: 0x0009D964
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			equipement_bsm equipement_bsm = new equipement_bsm();
			equipement_bsm.Show();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0009F77F File Offset: 0x0009D97F
		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox1.Text;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0009F79C File Offset: 0x0009D99C
		private int test_format_ot()
		{
			int result = 0;
			bool flag = this.TextBox1.Text.Contains("-");
			if (flag)
			{
				int num = this.TextBox1.Text.IndexOf("-");
				num++;
				fonction fonction = new fonction();
				bool flag2 = num != 0 & this.TextBox1.Text.Length > num;
				if (flag2)
				{
					string nombre = fonction.Mid(this.TextBox1.Text, 1, num - 1);
					string nombre2 = fonction.Mid(this.TextBox1.Text, num + 1, this.TextBox1.Text.Length - num);
					bool flag3 = fonction.isnumeric(nombre) & fonction.isnumeric(nombre2);
					if (flag3)
					{
						result = 1;
					}
				}
			}
			return result;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x0009F86C File Offset: 0x0009DA6C
		private void radRadioButton6_ToggleStateChanged(object sender, StateChangedEventArgs args)
		{
			bool isChecked = this.radRadioButton6.IsChecked;
			if (isChecked)
			{
				this.radGridView1.Rows.Clear();
				this.select_article_repare();
			}
		}
	}
}
