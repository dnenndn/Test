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
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200010E RID: 270
	public partial class prod_rapport : Form
	{
		// Token: 0x06000C07 RID: 3079 RVA: 0x001D7D20 File Offset: 0x001D5F20
		public prod_rapport()
		{
			this.InitializeComponent();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(this.radGridView1_CellFormatting);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
			this.radGridView1.Size = new Size(1080, 455);
			this.panel1.Visible = false;
			this.pictureBox1.Visible = false;
		}

		// Token: 0x06000C08 RID: 3080 RVA: 0x001D7DD8 File Offset: 0x001D5FD8
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				this.radGridView1.Size = new Size(1080, 152);
				this.panel1.Visible = true;
				this.pictureBox1.Visible = true;
				bool flag2 = e.ColumnIndex == 3;
				if (flag2)
				{
					prod_rapport.id_rpr = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
					prod_rapport.date_rpr = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					prod_rapport.poste_rpr = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					prod_rapport_fabrication prod_rapport_fabrication = new prod_rapport_fabrication();
					this.panel1.Controls.Clear();
					prod_rapport_fabrication.TopLevel = false;
					this.panel1.Controls.Add(prod_rapport_fabrication);
					prod_rapport_fabrication.Show();
				}
				bool flag3 = e.ColumnIndex == 4;
				if (flag3)
				{
					prod_rapport.id_rpr = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
					prod_rapport.date_rpr = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					prod_rapport.poste_rpr = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					prod_rapport_four prod_rapport_four = new prod_rapport_four();
					this.panel1.Controls.Clear();
					prod_rapport_four.TopLevel = false;
					this.panel1.Controls.Add(prod_rapport_four);
					prod_rapport_four.Show();
				}
				bool flag4 = e.ColumnIndex == 5;
				if (flag4)
				{
					prod_rapport.id_rpr = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
					prod_rapport.date_rpr = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					prod_rapport.poste_rpr = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					prod_rapport_preparation prod_rapport_preparation = new prod_rapport_preparation();
					this.panel1.Controls.Clear();
					prod_rapport_preparation.TopLevel = false;
					this.panel1.Controls.Add(prod_rapport_preparation);
					prod_rapport_preparation.Show();
				}
				bool flag5 = e.ColumnIndex == 6;
				if (flag5)
				{
					prod_rapport.id_rpr = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
					prod_rapport.date_rpr = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					prod_rapport.poste_rpr = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
					prod_rapport_fuel prod_rapport_fuel = new prod_rapport_fuel();
					this.panel1.Controls.Clear();
					prod_rapport_fuel.TopLevel = false;
					this.panel1.Controls.Add(prod_rapport_fuel);
					prod_rapport_fuel.Show();
				}
				bool flag6 = e.ColumnIndex == 7;
				if (flag6)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag7 = dialogResult == DialogResult.Yes;
					if (flag7)
					{
						prod_rapport.id_rpr = Convert.ToInt32(this.radGridView1.Rows[e.RowIndex].Cells[0].Value);
						bd bd = new bd();
						string cmdText = "delete prod_rapport_general where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = prod_rapport.id_rpr;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						string cmdText2 = "select id_unite, valeur from prod_fab_tonnage where id_rapport = @i";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = prod_rapport.id_rpr;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag8 = dataTable.Rows.Count != 0;
						if (flag8)
						{
							for (int i = 0; i < dataTable.Rows.Count; i++)
							{
								string cmdText3 = "update equipement_compteur set valeur = valeur - @v where id in (select id_compteur from prod_fab_compteur where id_unite = @u)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@v", SqlDbType.Real).Value = dataTable.Rows[i].ItemArray[1];
								sqlCommand3.Parameters.Add("@u", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0];
								bd.ouverture_bd(bd.cnn);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C09 RID: 3081 RVA: 0x001D83A0 File Offset: 0x001D65A0
		private void radGridView1_CellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 3;
			if (flag)
			{
				RadButtonElement radButtonElement = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement.SetThemeValueOverride(VisualElement.BackColorProperty, Color.DarkOrchid, "", typeof(FillPrimitive));
				radButtonElement.ForeColor = Color.White;
				radButtonElement.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag2 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 4;
			if (flag2)
			{
				RadButtonElement radButtonElement2 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement2.SetThemeValueOverride(VisualElement.BackColorProperty, Color.Crimson, "", typeof(FillPrimitive));
				radButtonElement2.ForeColor = Color.White;
				radButtonElement2.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag3 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 5;
			if (flag3)
			{
				RadButtonElement radButtonElement3 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement3.SetThemeValueOverride(VisualElement.BackColorProperty, Color.LimeGreen, "", typeof(FillPrimitive));
				radButtonElement3.ForeColor = Color.White;
				radButtonElement3.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
			bool flag4 = e.CellElement.ColumnInfo is GridViewCommandColumn & e.CellElement.RowIndex != -1 & e.CellElement.ColumnIndex == 6;
			if (flag4)
			{
				RadButtonElement radButtonElement4 = (RadButtonElement)e.CellElement.Children[0];
				radButtonElement4.SetThemeValueOverride(VisualElement.BackColorProperty, Color.DodgerBlue, "", typeof(FillPrimitive));
				radButtonElement4.ForeColor = Color.White;
				radButtonElement4.SetThemeValueOverride(FillPrimitive.GradientStyleProperty, BorderStyle.None, "", typeof(FillPrimitive));
			}
		}

		// Token: 0x06000C0A RID: 3082 RVA: 0x001D8648 File Offset: 0x001D6848
		private void prod_rapport_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker2.Value = DateTime.Today;
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radDateTimePicker3.Value = DateTime.Today;
			this.select_poste();
			this.remplissage_tableau(0);
		}

		// Token: 0x06000C0B RID: 3083 RVA: 0x001D8698 File Offset: 0x001D6898
		private void select_poste()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Jour");
			this.radDropDownList1.Items.Add("Soir");
			this.radDropDownList1.Items.Add("Nuit");
		}

		// Token: 0x06000C0C RID: 3084 RVA: 0x001D86FC File Offset: 0x001D68FC
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from prod_rapport_general where date_rapport =@d and poste = @p";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@d", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				sqlCommand.Parameters.Add("@p", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count == 0;
				if (flag2)
				{
					string cmdText2 = "insert into prod_rapport_general (date_rapport, poste) values (@v1, @v2)SELECT CAST(scope_identity() AS int)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@v1", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
					sqlCommand2.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
					bd.ouverture_bd(bd.cnn);
					int id_rapport = (int)sqlCommand2.ExecuteScalar();
					bd.cnn.Close();
					this.insert_produit_fabrication(id_rapport);
					this.insert_produit_four(id_rapport);
					this.insert_qualite_four(id_rapport);
					this.insert_qualite_fabrication(id_rapport);
					this.insert_horaire_fabrication(id_rapport);
					this.insert_tonnage(id_rapport);
					this.insert_qualite_préparation(id_rapport);
					this.insert_qualite_préparation_general(id_rapport);
					MessageBox.Show("Ajout avec succés");
					this.select_poste();
					this.remplissage_tableau(0);
				}
				else
				{
					MessageBox.Show("Erreur : Rapport déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Choisir Poste", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000C0D RID: 3085 RVA: 0x001D88DC File Offset: 0x001D6ADC
		private void insert_produit_fabrication(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Fabrication";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id from prod_type_brique";
				SqlCommand selectCommand = new SqlCommand(cmdText2, bd.cnn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < dataTable2.Rows.Count; j++)
						{
							string cmdText3 = "insert into prod_rapport_fab_produit (id_rapport, id_unite, id_produit, quantite, tonnage) values (@i1, @i2, @i3, @i4, @i5)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
							sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
							sqlCommand2.Parameters.Add("@i5", SqlDbType.Real).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000C0E RID: 3086 RVA: 0x001D8AE4 File Offset: 0x001D6CE4
		private void insert_produit_four(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Four";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id from prod_type_brique";
				SqlCommand selectCommand = new SqlCommand(cmdText2, bd.cnn);
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(selectCommand);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < dataTable2.Rows.Count; j++)
						{
							string cmdText3 = "insert into prod_rapport_four_entre (id_rapport, id_unite, id_produit, quantite, tonnage) values (@i1, @i2, @i3, @i4, @i5)";
							string cmdText4 = "insert into prod_rapport_four_sortie (id_rapport, id_unite, id_produit, quantite, tonnage) values (@i1, @i2, @i3, @i4, @i5)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText3, bd.cnn);
							SqlCommand sqlCommand3 = new SqlCommand(cmdText4, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
							sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
							sqlCommand2.Parameters.Add("@i5", SqlDbType.Real).Value = 0;
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
							sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand2.ExecuteNonQuery();
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000C0F RID: 3087 RVA: 0x001D8DCC File Offset: 0x001D6FCC
		private void insert_qualite_four(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Four";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id from prod_saisie where cible = @t and deleted = @d";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@t", SqlDbType.Int).Value = 3;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < dataTable2.Rows.Count; j++)
						{
							string cmdText3 = "insert into prod_rapport_four_qualite (id_rapport, id_unite, id_qualite, valeur) values (@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000C10 RID: 3088 RVA: 0x001D8FF4 File Offset: 0x001D71F4
		private void insert_qualite_fabrication(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Fabrication";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id from prod_saisie where cible = @t and deleted = @d";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@t", SqlDbType.Int).Value = 2;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < dataTable2.Rows.Count; j++)
						{
							string cmdText3 = "insert into prod_rapport_fabrication_qualite (id_rapport, id_unite, id_qualite, valeur) values (@i1, @i2, @i3, @i4)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000C11 RID: 3089 RVA: 0x001D921C File Offset: 0x001D741C
		private void insert_qualite_préparation(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Préparation";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id, preparation_produit from prod_saisie where cible = @t and deleted = @d";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@t", SqlDbType.Int).Value = 5;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < dataTable2.Rows.Count; j++)
						{
							int num = Convert.ToInt32(dataTable2.Rows[j].ItemArray[1]);
							bool flag3 = num == 3;
							if (flag3)
							{
								string cmdText3 = "insert into prod_rapport_prep_as (id_rapport, id_unite, id_qualite, valeur_a, valeur_s) values (@i1, @i2, @i3, @i4, @i5)";
								SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
								sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
								sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
								sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
								sqlCommand3.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
								sqlCommand3.Parameters.Add("@i5", SqlDbType.Real).Value = 0;
								bd.ouverture_bd(bd.cnn);
								sqlCommand3.ExecuteNonQuery();
								bd.cnn.Close();
							}
							bool flag4 = num == 0;
							if (flag4)
							{
								string cmdText4 = "insert into prod_rapport_prep_qualite (id_rapport, id_unite, id_qualite, valeur) values (@i1, @i2, @i3, @i4)";
								SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
								sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
								sqlCommand4.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
								sqlCommand4.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
								sqlCommand4.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
								bd.ouverture_bd(bd.cnn);
								sqlCommand4.ExecuteNonQuery();
								bd.cnn.Close();
							}
						}
					}
				}
			}
		}

		// Token: 0x06000C12 RID: 3090 RVA: 0x001D9574 File Offset: 0x001D7774
		private void insert_qualite_préparation_general(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id from prod_saisie where cible = @t and deleted = @d";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@t", SqlDbType.Int).Value = 4;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "insert into prod_rapport_prep_general (id_rapport, id_qualite, valeur) values (@i1, @i3, @i4)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@i4", SqlDbType.Real).Value = 0;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000C13 RID: 3091 RVA: 0x001D96D8 File Offset: 0x001D78D8
		private void insert_chefequipe_fabrication(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Fabrication";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "insert into prod_rapport_cf_fabrication (id_rapport, id_unite, id_cf) values (@i1, @i2, @i3)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Int).Value = 0;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000C14 RID: 3092 RVA: 0x001D981C File Offset: 0x001D7A1C
		private void insert_horaire_fabrication(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Fabrication";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				string cmdText2 = "select id from prod_saisie where cible = @t and deleted = @d";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@t", SqlDbType.Int).Value = 1;
				sqlCommand2.Parameters.Add("@d", SqlDbType.Int).Value = 0;
				SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
				DataTable dataTable2 = new DataTable();
				sqlDataAdapter2.Fill(dataTable2);
				bool flag2 = dataTable2.Rows.Count != 0;
				if (flag2)
				{
					for (int i = 0; i < dataTable.Rows.Count; i++)
					{
						for (int j = 0; j < dataTable2.Rows.Count; j++)
						{
							string cmdText3 = "insert into prod_rapport_horaire_fabrication (id_rapport, id_unite, id_qualite , h1, h2, h3, h4, h5, h6, h7, h8) values (@i1, @i2, @i3, @h1, @h2, @h3, @h4, @h5, @h6, @h7, @h7)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
							sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@i3", SqlDbType.Int).Value = dataTable2.Rows[j].ItemArray[0].ToString();
							sqlCommand3.Parameters.Add("@h1", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@h2", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@h3", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@h4", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@h5", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@h6", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@h7", SqlDbType.Int).Value = 0;
							sqlCommand3.Parameters.Add("@h8", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
						}
					}
				}
			}
		}

		// Token: 0x06000C15 RID: 3093 RVA: 0x001D9B14 File Offset: 0x001D7D14
		private void insert_tonnage(int id_rapport)
		{
			bd bd = new bd();
			string cmdText = "select id_equipement from prod_equipement where unite_production = @f";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@f", SqlDbType.VarChar).Value = "Fabrication";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string cmdText2 = "insert into prod_fab_tonnage (id_rapport, id_unite, valeur) values (@i1, @i2, @i3)";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = id_rapport;
					sqlCommand2.Parameters.Add("@i2", SqlDbType.Int).Value = dataTable.Rows[i].ItemArray[0].ToString();
					sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = 0;
					bd.ouverture_bd(bd.cnn);
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
				}
			}
		}

		// Token: 0x06000C16 RID: 3094 RVA: 0x001D9C58 File Offset: 0x001D7E58
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnableSorting = true;
			bd bd = new bd();
			string cmdText = "select * from prod_rapport_general where date_rapport between @d1 and @d2  order by date_rapport";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d1", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
			sqlCommand.Parameters.Add("@d2", SqlDbType.Date).Value = this.radDateTimePicker3.Value;
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
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						Convert.ToString(dataTable.Rows[i].ItemArray[2]),
						"Fabrication",
						"Four",
						"Préparation",
						"Fuel",
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			this.radGridView1.Templates.Clear();
		}

		// Token: 0x06000C17 RID: 3095 RVA: 0x001D9E10 File Offset: 0x001D8010
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000C18 RID: 3096 RVA: 0x001D9E1B File Offset: 0x001D801B
		private void radDateTimePicker3_ValueChanged(object sender, EventArgs e)
		{
			this.remplissage_tableau(0);
		}

		// Token: 0x06000C19 RID: 3097 RVA: 0x001D9E26 File Offset: 0x001D8026
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			this.radGridView1.Size = new Size(1080, 455);
			this.pictureBox1.Visible = false;
		}

		// Token: 0x04000FAD RID: 4013
		public static int id_rpr = 0;

		// Token: 0x04000FAE RID: 4014
		public static string date_rpr = "";

		// Token: 0x04000FAF RID: 4015
		public static string poste_rpr = "";
	}
}
