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
	// Token: 0x02000161 RID: 353
	public partial class Sous_Famille : Form
	{
		// Token: 0x06000F73 RID: 3955 RVA: 0x00254CD0 File Offset: 0x00252ED0
		public Sous_Famille()
		{
			this.InitializeComponent();
			this.remplissage_tableau(0);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
		}

		// Token: 0x06000F74 RID: 3956 RVA: 0x00254D68 File Offset: 0x00252F68
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.DimGray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x06000F75 RID: 3957 RVA: 0x00254DA8 File Offset: 0x00252FA8
		private void Sous_Famille_Load(object sender, EventArgs e)
		{
			Sous_Famille.guna2Button2.Hide();
			Sous_Famille.radPanel1.Hide();
			this.radGridView1.Size = new Size(1103, 391);
			this.select_famille();
		}

		// Token: 0x06000F76 RID: 3958 RVA: 0x00254DE4 File Offset: 0x00252FE4
		private void select_famille()
		{
			this.ComboBox1.Items.Clear();
			string cmdText = "select designation from famille where deleted = @d";
			bd bd = new bd();
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
					this.ComboBox1.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x06000F77 RID: 3959 RVA: 0x00254EB8 File Offset: 0x002530B8
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & fonction.DeleteSpace(this.ComboBox1.Text) != "";
			if (flag)
			{
				bool flag2 = this.guna2Button1.Text == "Ajouter";
				if (flag2)
				{
					string cmdText = "select id from sous_famille where designation = @v2 and deleted = @d";
					bd bd = new bd();
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						string cmdText2 = "select id from famille where designation = @ds";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@ds", SqlDbType.VarChar).Value = this.ComboBox1.Text;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag4 = dataTable2.Rows.Count != 0;
						if (flag4)
						{
							string cmdText3 = "insert into sous_famille (id_famille,code_sous_famille, designation, deleted) values (@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.VarChar).Value = dataTable2.Rows[0].ItemArray[0];
							sqlCommand3.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand3.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
							sqlCommand3.Parameters.Add("@i4", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("La sous famille est ajouté avec succés");
							this.TextBox1.Clear();
							this.TextBox2.Clear();
							this.remplissage_tableau(1);
						}
						else
						{
							MessageBox.Show("Erreur : La famille déja supprimé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : La sous famille déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				bool flag5 = this.guna2Button1.Text == "Modifier";
				if (flag5)
				{
					string cmdText4 = "select id from sous_famille where (code_sous_famille = @v1 or designation = @v2) and deleted = @d and id <> @o";
					bd bd2 = new bd();
					SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd2.cnn);
					sqlCommand4.Parameters.Add("@v1", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand4.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand4.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand4.Parameters.Add("@o", SqlDbType.Int).Value = Sous_Famille.id_modifier;
					SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand4);
					DataTable dataTable3 = new DataTable();
					sqlDataAdapter3.Fill(dataTable3);
					bool flag6 = dataTable3.Rows.Count == 0;
					if (flag6)
					{
						string cmdText5 = "select id from famille where designation = @ds";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd2.cnn);
						sqlCommand5.Parameters.Add("@ds", SqlDbType.VarChar).Value = this.ComboBox1.Text;
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag7 = dataTable4.Rows.Count != 0;
						if (flag7)
						{
							string cmdText6 = "update sous_famille set id_famille = @i1,code_sous_famille = @i2, designation = @i3 where id = @i4";
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd2.cnn);
							sqlCommand6.Parameters.Add("@i1", SqlDbType.VarChar).Value = dataTable4.Rows[0].ItemArray[0];
							sqlCommand6.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand6.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.TextBox2.Text;
							sqlCommand6.Parameters.Add("@i4", SqlDbType.Int).Value = Sous_Famille.id_modifier;
							bd2.ouverture_bd(bd2.cnn);
							sqlCommand6.ExecuteNonQuery();
							bd2.cnn.Close();
							MessageBox.Show("La sous famille est modifié avec succés");
							this.TextBox1.Clear();
							this.TextBox2.Clear();
							this.guna2Button1.Text = "Ajouter";
							this.label2.Text = "Ajouter Sous Famille";
							this.remplissage_tableau(2);
						}
						else
						{
							MessageBox.Show("Erreur : La famille déja supprimé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : La sous famille déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000F78 RID: 3960 RVA: 0x00255434 File Offset: 0x00253634
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 10;
			this.radGridView1.Columns[0].AllowFiltering = false;
			this.radGridView1.Columns[4].AllowFiltering = false;
			this.radGridView1.Columns[5].AllowFiltering = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select sous_famille.id,famille.designation,code_sous_famille, sous_famille.designation from sous_famille inner join famille on sous_famille.id_famille = famille.id where sous_famille.deleted = @i and famille.deleted = @i order by sous_famille.designation";
			bd bd = new bd();
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
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_,
						"Liste caractéristiques",
						"Ajouter caractéristique"
					});
				}
			}
			bool flag2 = this.radGridView1.Rows.Count != 0;
			if (flag2)
			{
				bool flag3 = o == 0;
				if (flag3)
				{
					this.radGridView1.MasterTemplate.MoveToFirstPage();
					this.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag4 = o == 1;
				if (flag4)
				{
					this.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag5 = o == 2;
				if (flag5)
				{
					this.radGridView1.Rows[Sous_Famille.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = Sous_Famille.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[Sous_Famille.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.Templates.Clear();
			this.afficher_article();
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x06000F79 RID: 3961 RVA: 0x00255768 File Offset: 0x00253968
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string text = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					Sous_Famille.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 5;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update sous_famille set deleted = @d where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = text;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau(3);
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag5)
					{
						Sous_Famille.id_modifier = text;
						this.guna2Button1.Text = "Modifier";
						this.label2.Text = "Modifier Sous Famille";
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
						this.ComboBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					}
					bool flag6 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag6)
					{
						Sous_Famille.id_sous_famille = text;
						Sous_Famille.designation_sous_famille = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
						ajouter_caractéristique ajouter_caractéristique = new ajouter_caractéristique();
						ajouter_caractéristique.Show();
					}
					bool flag7 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag7)
					{
						Sous_Famille.id_sous_famille = text;
						Sous_Famille.select_caracteristique(text);
						Sous_Famille.radPanel1.Show();
						this.radGridView1.Size = new Size(1103, 219);
					}
				}
			}
		}

		// Token: 0x06000F7A RID: 3962 RVA: 0x00255A40 File Offset: 0x00253C40
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Red, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 7;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.FromArgb(244, 161, 0), "", typeof(FillPrimitive));
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
			}
		}

		// Token: 0x06000F7B RID: 3963 RVA: 0x00255B9F File Offset: 0x00253D9F
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			Sous_Famille.radPanel1.Hide();
			Sous_Famille.guna2Button2.Hide();
			this.radGridView1.Size = new Size(1103, 391);
		}

		// Token: 0x06000F7C RID: 3964 RVA: 0x00255BD4 File Offset: 0x00253DD4
		public static void select_caracteristique(string id)
		{
			Sous_Famille.guna2Button2.Show();
			Sous_Famille.radPanel1.Controls.Clear();
			bd bd = new bd();
			string cmdText = "select * from caracteristique where id_sous_famille = @i and deleted =@d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					int id_caract = Convert.ToInt32(dataTable.Rows[i].ItemArray[0]);
					Label label = new Label();
					label.AutoSize = true;
					label.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
					label.ForeColor = Color.Black;
					label.Text = dataTable.Rows[i].ItemArray[2].ToString();
					label.Location = new Point(13, 12 + 62 * i);
					Sous_Famille.radPanel1.Controls.Add(label);
					bool flag2 = Convert.ToInt32(dataTable.Rows[i].ItemArray[4]) == 1;
					if (flag2)
					{
						Label label2 = new Label();
						label2.AutoSize = true;
						label2.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
						label2.ForeColor = Color.Red;
						label2.Text = "*";
						label2.Location = new Point(11 + label.Size.Width, 12 + 62 * i);
						Sous_Famille.radPanel1.Controls.Add(label2);
					}
					bool flag3 = dataTable.Rows[i].ItemArray[3].ToString() == "TextBox";
					if (flag3)
					{
						Guna2TextBox guna2TextBox = new Guna2TextBox();
						guna2TextBox.BorderRadius = 2;
						guna2TextBox.Cursor = Cursors.IBeam;
						guna2TextBox.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
						guna2TextBox.ForeColor = Color.FromArgb(138, 138, 138);
						guna2TextBox.BorderColor = Color.FromArgb(94, 148, 255);
						guna2TextBox.Font = new Font("Calibri", 9f);
						guna2TextBox.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
						guna2TextBox.Location = new Point(17, 34 + 62 * i);
						guna2TextBox.PasswordChar = '\0';
						guna2TextBox.SelectedText = "";
						guna2TextBox.Size = new Size(318, 29);
						guna2TextBox.BackColor = Color.White;
						string cmdText2 = "select valeur_defaut from caracteristique_textbox where id_caracteristique = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag4 = dataTable2.Rows.Count != 0;
						if (flag4)
						{
							guna2TextBox.Text = dataTable2.Rows[0].ItemArray[0].ToString();
						}
						Sous_Famille.radPanel1.Controls.Add(guna2TextBox);
						PictureBox pictureBox = new PictureBox();
						PictureBox pictureBox2 = new PictureBox();
						pictureBox.Cursor = Cursors.Hand;
						pictureBox.Image = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						pictureBox.Location = new Point(341, 34 + 62 * i);
						pictureBox.Size = new Size(35, 30);
						pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
						pictureBox.TabStop = false;
						pictureBox2.Cursor = Cursors.Hand;
						pictureBox2.Image = Resources.icons8_supprimer_pour_toujours_100__4_;
						pictureBox2.Location = new Point(382, 34 + 62 * i);
						pictureBox2.Size = new Size(35, 30);
						pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
						pictureBox2.TabStop = false;
						Sous_Famille.radPanel1.Controls.Add(pictureBox);
						Sous_Famille.radPanel1.Controls.Add(pictureBox2);
						pictureBox2.Click += delegate(object j1, EventArgs j2)
						{
							Sous_Famille.delete_caracteristique(id_caract);
						};
						pictureBox.Click += delegate(object j1, EventArgs j2)
						{
							Sous_Famille.modifier_textbox(id_caract.ToString());
						};
					}
					bool flag5 = dataTable.Rows[i].ItemArray[3].ToString() == "Select Unique";
					if (flag5)
					{
						RadDropDownList radDropDownList = new RadDropDownList();
						radDropDownList.BackColor = Color.Transparent;
						radDropDownList.ThemeName = "Crystal";
						radDropDownList.DropDownStyle = 2;
						((FillPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = Color.Firebrick;
						((FillPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor3 = Color.Firebrick;
						((FillPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor4 = Color.Firebrick;
						((FillPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = Color.Firebrick;
						((BorderPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = Color.Firebrick;
						((BorderPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = Color.Firebrick;
						((BorderPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = Color.Firebrick;
						((BorderPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = Color.Firebrick;
						((BorderPrimitive)radDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = SmoothingMode.HighQuality;
						radDropDownList.Font = new Font("Calibri", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
						radDropDownList.ForeColor = Color.FromArgb(125, 137, 149);
						radDropDownList.Location = new Point(17, 34 + 62 * i);
						radDropDownList.Size = new Size(318, 30);
						Sous_Famille.radPanel1.Controls.Add(radDropDownList);
						PictureBox pictureBox3 = new PictureBox();
						PictureBox pictureBox4 = new PictureBox();
						pictureBox3.Cursor = Cursors.Hand;
						pictureBox3.Image = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						pictureBox3.Location = new Point(341, 34 + 62 * i);
						pictureBox3.Size = new Size(35, 30);
						pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
						pictureBox3.TabStop = false;
						pictureBox4.Cursor = Cursors.Hand;
						pictureBox4.Image = Resources.icons8_supprimer_pour_toujours_100__4_;
						pictureBox4.Location = new Point(382, 34 + 62 * i);
						pictureBox4.Size = new Size(35, 30);
						pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
						pictureBox4.TabStop = false;
						Sous_Famille.radPanel1.Controls.Add(pictureBox3);
						Sous_Famille.radPanel1.Controls.Add(pictureBox4);
						pictureBox4.Click += delegate(object j1, EventArgs j2)
						{
							Sous_Famille.delete_caracteristique(id_caract);
						};
						pictureBox3.Click += delegate(object j1, EventArgs j2)
						{
							Sous_Famille.modifier_autre(id_caract.ToString());
						};
						string cmdText3 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(sqlCommand3);
						DataTable dataTable3 = new DataTable();
						sqlDataAdapter3.Fill(dataTable3);
						bool flag6 = dataTable3.Rows.Count != 0;
						if (flag6)
						{
							radDropDownList.Controls.Clear();
							for (int j = 0; j < dataTable3.Rows.Count; j++)
							{
								radDropDownList.Items.Add(Convert.ToString(dataTable3.Rows[j].ItemArray[0]));
								bool flag7 = Convert.ToInt32(dataTable3.Rows[j].ItemArray[1]) == 1;
								if (flag7)
								{
									radDropDownList.Text = Convert.ToString(dataTable3.Rows[j].ItemArray[0]);
								}
							}
						}
					}
					bool flag8 = dataTable.Rows[i].ItemArray[3].ToString() == "Select Multiple";
					if (flag8)
					{
						RadCheckedDropDownList radCheckedDropDownList = new RadCheckedDropDownList();
						radCheckedDropDownList.Location = new Point(17, 34 + 62 * i);
						radCheckedDropDownList.Size = new Size(318, 30);
						radCheckedDropDownList.ThemeName = "Crystal";
						((RadCheckedDropDownListElement)radCheckedDropDownList.GetChildAt(0)).DropDownStyle = 2;
						((FillPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor2 = Color.Firebrick;
						((FillPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor3 = Color.Firebrick;
						((FillPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor4 = Color.Firebrick;
						((FillPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(0)).BackColor = Color.Firebrick;
						((BorderPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor2 = Color.Firebrick;
						((BorderPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor3 = Color.Firebrick;
						((BorderPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor4 = Color.Firebrick;
						((BorderPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).ForeColor = Color.Firebrick;
						((BorderPrimitive)radCheckedDropDownList.GetChildAt(0).GetChildAt(2).GetChildAt(1).GetChildAt(1)).SmoothingMode = SmoothingMode.HighQuality;
						Sous_Famille.radPanel1.Controls.Add(radCheckedDropDownList);
						PictureBox pictureBox5 = new PictureBox();
						PictureBox pictureBox6 = new PictureBox();
						pictureBox5.Cursor = Cursors.Hand;
						pictureBox5.Image = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
						pictureBox5.Location = new Point(341, 30 + 62 * i);
						pictureBox5.Size = new Size(35, 30);
						pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
						pictureBox5.TabStop = false;
						pictureBox6.Cursor = Cursors.Hand;
						pictureBox6.Image = Resources.icons8_supprimer_pour_toujours_100__4_;
						pictureBox6.Location = new Point(382, 30 + 62 * i);
						pictureBox6.Size = new Size(35, 30);
						pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
						pictureBox6.TabStop = false;
						Sous_Famille.radPanel1.Controls.Add(pictureBox5);
						Sous_Famille.radPanel1.Controls.Add(pictureBox6);
						pictureBox6.Click += delegate(object j1, EventArgs j2)
						{
							Sous_Famille.delete_caracteristique(id_caract);
						};
						pictureBox5.Click += delegate(object j1, EventArgs j2)
						{
							Sous_Famille.modifier_autre(id_caract.ToString());
						};
						string cmdText4 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter4 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable4 = new DataTable();
						sqlDataAdapter4.Fill(dataTable4);
						bool flag9 = dataTable4.Rows.Count != 0;
						if (flag9)
						{
							radCheckedDropDownList.Controls.Clear();
							for (int k = 0; k < dataTable4.Rows.Count; k++)
							{
								radCheckedDropDownList.Items.Add(Convert.ToString(dataTable4.Rows[k].ItemArray[0]));
								bool flag10 = Convert.ToInt32(dataTable4.Rows[k].ItemArray[1]) == 1;
								if (flag10)
								{
									radCheckedDropDownList.Items[k].Checked = true;
								}
								else
								{
									radCheckedDropDownList.Items[k].Checked = false;
								}
							}
						}
					}
					bool flag11 = dataTable.Rows[i].ItemArray[3].ToString() == "CheckBox";
					if (flag11)
					{
						string cmdText5 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
						sqlCommand5.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter5 = new SqlDataAdapter(sqlCommand5);
						DataTable dataTable5 = new DataTable();
						sqlDataAdapter5.Fill(dataTable5);
						bool flag12 = dataTable5.Rows.Count != 0;
						if (flag12)
						{
							int num = 17;
							for (int l = 0; l < dataTable5.Rows.Count; l++)
							{
								RadCheckBox radCheckBox = new RadCheckBox();
								radCheckBox.CheckAlignment = ContentAlignment.MiddleRight;
								radCheckBox.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
								radCheckBox.Location = new Point(num, 34 + 62 * i);
								radCheckBox.Text = Convert.ToString(dataTable5.Rows[l].ItemArray[0]);
								radCheckBox.ThemeName = "Crystal";
								radCheckBox.AutoSize = true;
								int num2 = 0;
								for (int m = 1; m <= radCheckBox.Text.Length; m++)
								{
									bool flag13 = fonction.Mid(radCheckBox.Text, m, 1) == fonction.Mid(radCheckBox.Text, m, 1).ToUpper();
									if (flag13)
									{
										num2++;
									}
								}
								num = num + 42 + radCheckBox.Text.Length * 6 + num2 * 2;
								Sous_Famille.radPanel1.Controls.Add(radCheckBox);
								bool flag14 = Convert.ToInt32(dataTable5.Rows[l].ItemArray[1]) == 1;
								if (flag14)
								{
									radCheckBox.Checked = true;
								}
								else
								{
									radCheckBox.Checked = false;
								}
							}
							PictureBox pictureBox7 = new PictureBox();
							PictureBox pictureBox8 = new PictureBox();
							pictureBox7.Cursor = Cursors.Hand;
							pictureBox7.Image = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
							pictureBox7.Location = new Point(num, 32 + 62 * i);
							pictureBox7.Size = new Size(22, 22);
							pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
							pictureBox7.TabStop = false;
							pictureBox8.Cursor = Cursors.Hand;
							pictureBox8.Image = Resources.icons8_supprimer_pour_toujours_100__4_;
							pictureBox8.Location = new Point(num + 41, 32 + 62 * i);
							pictureBox8.Size = new Size(22, 22);
							pictureBox8.SizeMode = PictureBoxSizeMode.Zoom;
							pictureBox8.TabStop = false;
							Sous_Famille.radPanel1.Controls.Add(pictureBox7);
							Sous_Famille.radPanel1.Controls.Add(pictureBox8);
							pictureBox8.Click += delegate(object j1, EventArgs j2)
							{
								Sous_Famille.delete_caracteristique(id_caract);
							};
							pictureBox7.Click += delegate(object j1, EventArgs j2)
							{
								Sous_Famille.modifier_autre(id_caract.ToString());
							};
						}
					}
					bool flag15 = dataTable.Rows[i].ItemArray[3].ToString() == "Radio Button";
					if (flag15)
					{
						FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
						flowLayoutPanel.AutoScroll = true;
						flowLayoutPanel.Location = new Point(17, 34 + 62 * i);
						flowLayoutPanel.Size = new Size(1086, 40);
						string cmdText6 = "select valeur_option, defaut from caracteristique_option where id_caracteristique = @i";
						SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
						sqlCommand6.Parameters.Add("@i", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
						SqlDataAdapter sqlDataAdapter6 = new SqlDataAdapter(sqlCommand6);
						DataTable dataTable6 = new DataTable();
						sqlDataAdapter6.Fill(dataTable6);
						bool flag16 = dataTable6.Rows.Count != 0;
						if (flag16)
						{
							int num3 = 17;
							for (int n = 0; n < dataTable6.Rows.Count; n++)
							{
								RadRadioButton radRadioButton = new RadRadioButton();
								radRadioButton.Font = new Font("Calibri", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0);
								radRadioButton.Location = new Point(num3, 34 + 62 * i);
								radRadioButton.Text = Convert.ToString(dataTable6.Rows[n].ItemArray[0]);
								radRadioButton.ThemeName = "Crystal";
								radRadioButton.AutoSize = true;
								int num4 = 0;
								for (int num5 = 1; num5 <= radRadioButton.Text.Length; num5++)
								{
									bool flag17 = fonction.Mid(radRadioButton.Text, num5, 1) == fonction.Mid(radRadioButton.Text, num5, 1).ToUpper();
									if (flag17)
									{
										num4++;
									}
								}
								num3 = num3 + 42 + radRadioButton.Text.Length * 6 + num4 * 2;
								flowLayoutPanel.Controls.Add(radRadioButton);
								bool flag18 = Convert.ToInt32(dataTable6.Rows[n].ItemArray[1]) == 1;
								if (flag18)
								{
									radRadioButton.IsChecked = true;
								}
								else
								{
									radRadioButton.IsChecked = false;
								}
							}
							Sous_Famille.radPanel1.Controls.Add(flowLayoutPanel);
							PictureBox pictureBox9 = new PictureBox();
							PictureBox pictureBox10 = new PictureBox();
							pictureBox9.Cursor = Cursors.Hand;
							pictureBox9.Image = Resources.icons8_approuver_et_mettre_à_jour_96__4_;
							pictureBox9.Location = new Point(num3, 0);
							pictureBox9.Size = new Size(22, 22);
							pictureBox9.SizeMode = PictureBoxSizeMode.Zoom;
							pictureBox9.TabStop = false;
							pictureBox10.Cursor = Cursors.Hand;
							pictureBox10.Image = Resources.icons8_supprimer_pour_toujours_100__4_;
							pictureBox10.Location = new Point(num3 + 41, 0);
							pictureBox10.Size = new Size(22, 22);
							pictureBox10.SizeMode = PictureBoxSizeMode.Zoom;
							pictureBox10.TabStop = false;
							flowLayoutPanel.Controls.Add(pictureBox9);
							flowLayoutPanel.Controls.Add(pictureBox10);
							pictureBox10.Click += delegate(object j1, EventArgs j2)
							{
								Sous_Famille.delete_caracteristique(id_caract);
							};
							pictureBox9.Click += delegate(object j1, EventArgs j2)
							{
								Sous_Famille.modifier_autre(id_caract.ToString());
							};
						}
					}
					Label label3 = new Label();
					label3.Text = "";
					label3.Location = new Point(13, 12 + 62 * dataTable.Rows.Count);
					Sous_Famille.radPanel1.Controls.Add(label3);
				}
			}
		}

		// Token: 0x06000F7D RID: 3965 RVA: 0x0025702C File Offset: 0x0025522C
		private void afficher_article()
		{
			this.radGridView1.Templates.Clear();
			bd bd = new bd();
			string cmdText = "select tableau_article_sous_famille.id_sous_famille, article.code_article, article.designation from tableau_article_sous_famille inner join article on tableau_article_sous_famille.id_article = article.id where article.deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			DataTable dataTable2 = new DataTable();
			dataTable2.Columns.Add("column1");
			dataTable2.Columns.Add("column2");
			dataTable2.Columns.Add("column3");
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					dataTable2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString()
					});
				}
				GridViewTemplate gridViewTemplate = new GridViewTemplate();
				gridViewTemplate.Caption = "Article";
				gridViewTemplate.DataSource = dataTable2;
				gridViewTemplate.AllowRowResize = false;
				gridViewTemplate.ShowColumnHeaders = true;
				gridViewTemplate.Columns["column1"].Width = 200;
				gridViewTemplate.Columns["column2"].Width = 250;
				gridViewTemplate.Columns["column3"].Width = 250;
				gridViewTemplate.Columns[0].IsVisible = false;
				gridViewTemplate.Columns[1].HeaderText = "Code Article";
				gridViewTemplate.Columns[2].HeaderText = "Désignation";
				this.radGridView1.Templates.Insert(0, gridViewTemplate);
				GridViewRelation gridViewRelation = new GridViewRelation(this.radGridView1.MasterTemplate);
				gridViewRelation.ChildTemplate = gridViewTemplate;
				gridViewRelation.ParentColumnNames.Add(this.radGridView1.MasterTemplate.Columns[0].Name);
				gridViewRelation.ChildColumnNames.Add(gridViewTemplate.Columns[0].Name);
				this.radGridView1.Relations.Add(gridViewRelation);
			}
		}

		// Token: 0x06000F7E RID: 3966 RVA: 0x002572D4 File Offset: 0x002554D4
		private static void delete_caracteristique(int h)
		{
			DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			bool flag = dialogResult == DialogResult.Yes;
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "delete caracteristique where id=@h";
				string cmdText2 = "delete caracteristique_textbox where id_caracteristique = @h";
				string cmdText3 = "delete caracteristique_option where id_caracteristique = @h";
				string cmdText4 = "delete tableau_article_caracteristique where id_caracteristique = @h";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand.Parameters.Add("@h", SqlDbType.Int).Value = h;
				sqlCommand2.Parameters.Add("@h", SqlDbType.Int).Value = h;
				sqlCommand3.Parameters.Add("@h", SqlDbType.Int).Value = h;
				sqlCommand4.Parameters.Add("@h", SqlDbType.Int).Value = h;
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				sqlCommand2.ExecuteNonQuery();
				sqlCommand3.ExecuteNonQuery();
				sqlCommand4.ExecuteNonQuery();
				Sous_Famille.select_caracteristique(Sous_Famille.id_sous_famille);
			}
		}

		// Token: 0x06000F7F RID: 3967 RVA: 0x00257410 File Offset: 0x00255610
		private static void modifier_textbox(string h)
		{
			Sous_Famille.id_cr = h;
			modifier_caracteristique_textbox modifier_caracteristique_textbox = new modifier_caracteristique_textbox();
			modifier_caracteristique_textbox.Show();
		}

		// Token: 0x06000F80 RID: 3968 RVA: 0x00257434 File Offset: 0x00255634
		private static void modifier_autre(string h)
		{
			Sous_Famille.id_cr = h;
			Modifier_caracteristique_autre modifier_caracteristique_autre = new Modifier_caracteristique_autre();
			modifier_caracteristique_autre.Show();
		}

		// Token: 0x0400138F RID: 5007
		private static string id_modifier;

		// Token: 0x04001390 RID: 5008
		private static int row_act;

		// Token: 0x04001391 RID: 5009
		public static string id_sous_famille;

		// Token: 0x04001392 RID: 5010
		public static string designation_sous_famille;

		// Token: 0x04001393 RID: 5011
		public static string id_cr;
	}
}
