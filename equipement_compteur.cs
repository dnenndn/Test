using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200012C RID: 300
	public partial class equipement_compteur : Form
	{
		// Token: 0x06000D3C RID: 3388 RVA: 0x00200848 File Offset: 0x001FEA48
		public equipement_compteur()
		{
			this.InitializeComponent();
			this.panel1.Visible = false;
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView2.CellClick += new GridViewCellEventHandler(this.RadGridView2_CellClick);
		}

		// Token: 0x06000D3D RID: 3389 RVA: 0x00200914 File Offset: 0x001FEB14
		private void RadGridView2_CellClick(object sender, GridViewCellEventArgs e)
		{
			string value = this.radGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 4;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					string cmdText = "delete equipement_compteur_historique where id = @a";
					bd bd = new bd();
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_historique_compteur(equipement_compteur.id_compteur);
				}
			}
		}

		// Token: 0x06000D3E RID: 3390 RVA: 0x002009F0 File Offset: 0x001FEBF0
		private void equipement_compteur_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000D3F RID: 3391 RVA: 0x002009FC File Offset: 0x001FEBFC
		private void select_change(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement is GridTableHeaderCellElement;
			if (flag)
			{
				e.CellElement.BackColor = Color.Firebrick;
			}
		}

		// Token: 0x06000D40 RID: 3392 RVA: 0x00200A30 File Offset: 0x001FEC30
		private void select_changee(object sender, RowFormattingEventArgs e)
		{
			bool flag = e.RowElement is GridTableHeaderRowElement;
			if (flag)
			{
				e.RowElement.ForeColor = Color.Firebrick;
			}
		}

		// Token: 0x06000D41 RID: 3393 RVA: 0x00200A64 File Offset: 0x001FEC64
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 5;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select id,designation, valeur, unite from equipement_compteur where id_equipement = @i and deleted  = @d";
			bd bd = new bd();
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
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
						Resources.icons8_visible_96,
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
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

		// Token: 0x06000D42 RID: 3394 RVA: 0x00200C94 File Offset: 0x001FEE94
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.TextBox2.Text);
				if (flag2)
				{
					bd bd = new bd();
					bool flag3 = this.guna2Button1.Text == "Ajouter";
					if (flag3)
					{
						string cmdText = "select id from equipement_compteur where id_equipement = @i1 and designation = @i2";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
						sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag4 = dataTable.Rows.Count == 0;
						if (flag4)
						{
							string cmdText2 = "insert into equipement_compteur (id_equipement, designation, valeur, unite, deleted) values(@i1, @i2, @i3, @i4, @i5)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
							sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox2.Text;
							sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
							sqlCommand2.Parameters.Add("@i5", SqlDbType.Int).Value = 0;
							bd.ouverture_bd(bd.cnn);
							int num = (int)sqlCommand2.ExecuteScalar();
							string cmdText3 = "insert into equipement_compteur_nv (id_compteur, valeur, date_nv) values (@d1, @d2, @d3)";
							SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
							sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = num;
							sqlCommand3.Parameters.Add("@d2", SqlDbType.Real).Value = this.TextBox2.Text;
							sqlCommand3.Parameters.Add("@d3", SqlDbType.Date).Value = DateTime.Today;
							sqlCommand3.ExecuteNonQuery();
							bd.cnn.Close();
							MessageBox.Show("Succés");
							this.TextBox1.Clear();
							this.TextBox2.Clear();
							this.guna2TextBox1.Clear();
							this.remplissage_tableau();
						}
						else
						{
							MessageBox.Show("Erreur : Compteur déja existe");
						}
					}
					bool flag5 = this.guna2Button1.Text == "Modifier";
					if (flag5)
					{
						string cmdText4 = "select id from equipement_compteur where id_equipement = @i1 and designation = @i2 and id <> @i3";
						SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
						sqlCommand4.Parameters.Add("@i1", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
						sqlCommand4.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand4.Parameters.Add("@i3", SqlDbType.Int).Value = equipement_compteur.id_modifier;
						SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand4);
						DataTable dataTable2 = new DataTable();
						sqlDataAdapter2.Fill(dataTable2);
						bool flag6 = dataTable2.Rows.Count == 0;
						if (flag6)
						{
							string cmdText5 = "update equipement_compteur set designation = @i2, valeur = @i3, unite = @i4 where id = @i1";
							string cmdText6 = "insert into equipement_compteur_nv (id_compteur, valeur, date_nv) values (@d1, @d2, @d3)";
							SqlCommand sqlCommand5 = new SqlCommand(cmdText5, bd.cnn);
							SqlCommand sqlCommand6 = new SqlCommand(cmdText6, bd.cnn);
							sqlCommand5.Parameters.Add("@i1", SqlDbType.Int).Value = equipement_compteur.id_modifier;
							sqlCommand5.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand5.Parameters.Add("@i3", SqlDbType.Real).Value = this.TextBox2.Text;
							sqlCommand5.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
							sqlCommand6.Parameters.Add("@d1", SqlDbType.Int).Value = equipement_compteur.id_modifier;
							sqlCommand6.Parameters.Add("@d2", SqlDbType.Real).Value = this.TextBox2.Text;
							sqlCommand6.Parameters.Add("@d3", SqlDbType.Date).Value = DateTime.Today;
							bd.ouverture_bd(bd.cnn);
							sqlCommand5.ExecuteNonQuery();
							sqlCommand6.ExecuteNonQuery();
							bd.cnn.Close();
							lancement_ot_preventive.creation_ot_compteur(Convert.ToInt32(equipement_compteur.id_modifier));
							MessageBox.Show("Succés");
							this.TextBox1.Clear();
							this.TextBox2.Clear();
							this.guna2TextBox1.Clear();
							this.label1.Text = "Ajouter un compteur";
							this.guna2Button1.Text = "Ajouter";
							this.remplissage_tableau();
						}
						else
						{
							MessageBox.Show("Erreur : Compteur déja existe");
						}
					}
				}
				else
				{
					MessageBox.Show("Erreur : Le champs valeur doit être un réel");
				}
			}
			else
			{
				MessageBox.Show("Erreur :Un champs obligatoire est vide");
			}
		}

		// Token: 0x06000D43 RID: 3395 RVA: 0x00201210 File Offset: 0x001FF410
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string value = this.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 6;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							this.panel1.Visible = false;
							string cmdText = "update equipement_compteur set deleted = @d where id = @a";
							bd bd = new bd();
							SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
							sqlCommand.Parameters.Add("@a", SqlDbType.Int).Value = value;
							sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
							bd.ouverture_bd(bd.cnn);
							sqlCommand.ExecuteNonQuery();
							bd.cnn.Close();
							this.remplissage_tableau();
						}
					}
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 5;
					if (flag5)
					{
						equipement_compteur.id_modifier = value;
						this.guna2Button1.Text = "Modifier";
						this.panel1.Visible = false;
						this.label1.Text = "Modifier un compteur";
						this.TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.TextBox2.Text = this.radGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
						this.guna2TextBox1.Text = this.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
					}
					bool flag6 = e.RowIndex >= 0 && e.ColumnIndex == 4;
					if (flag6)
					{
						equipement_compteur.id_compteur = value;
						this.label12.Text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
						this.panel1.Show();
						DateTime now = DateTime.Now;
						DateTime value2 = new DateTime(now.Year, now.Month, 1);
						this.radDateTimePicker1.Value = value2;
						this.radDateTimePicker3.Value = value2.AddMonths(1).AddDays(-1.0);
						this.radDateTimePicker2.Value = DateTime.Today;
						this.select_historique_compteur(equipement_compteur.id_compteur);
					}
				}
			}
		}

		// Token: 0x06000D44 RID: 3396 RVA: 0x0020151B File Offset: 0x001FF71B
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
		}

		// Token: 0x06000D45 RID: 3397 RVA: 0x0020152C File Offset: 0x001FF72C
		private void select_historique_compteur(string id)
		{
			this.radGridView2.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select equipement_compteur_nv.id, date_nv, equipement_compteur_nv.valeur, equipement_compteur.unite from equipement_compteur_nv inner join equipement_compteur on equipement_compteur_nv.id_compteur = equipement_compteur.id where id_compteur = @i and date_nv between @d1 and @d2 order by date_nv desc";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = id;
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
					this.radGridView2.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[1].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x06000D46 RID: 3398 RVA: 0x002016C1 File Offset: 0x001FF8C1
		private void radDateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.select_historique_compteur(equipement_compteur.id_compteur);
		}

		// Token: 0x06000D47 RID: 3399 RVA: 0x002016D0 File Offset: 0x001FF8D0
		private void radDateTimePicker3_ValueChanged(object sender, EventArgs e)
		{
			this.select_historique_compteur(equipement_compteur.id_compteur);
		}

		// Token: 0x06000D48 RID: 3400 RVA: 0x002016E0 File Offset: 0x001FF8E0
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			double num = 0.0;
			bd bd = new bd();
			string cmdText = "select valeur from equipement_compteur where id = @v";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@v", SqlDbType.Int).Value = equipement_compteur.id_compteur;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				num = Convert.ToDouble(dataTable.Rows[0].ItemArray[0]);
			}
			fonction fonction = new fonction();
			bool flag2 = fonction.is_reel(this.guna2TextBox2.Text);
			if (flag2)
			{
				string cmdText2 = "insert into equipement_compteur_historique (id_compteur, valeur, date_mesure) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
				sqlCommand2.Parameters.Add("@v1", SqlDbType.Int).Value = equipement_compteur.id_compteur;
				sqlCommand2.Parameters.Add("@v2", SqlDbType.Real).Value = Convert.ToDouble(this.guna2TextBox2.Text) - num;
				sqlCommand2.Parameters.Add("@v3", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				string cmdText3 = "insert into equipement_compteur_nv (id_compteur, valeur, date_nv) values (@d1, @d2, @d3)";
				SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
				sqlCommand3.Parameters.Add("@d1", SqlDbType.Int).Value = equipement_compteur.id_compteur;
				sqlCommand3.Parameters.Add("@d2", SqlDbType.Real).Value = this.guna2TextBox2.Text;
				sqlCommand3.Parameters.Add("@d3", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
				string cmdText4 = "update equipement_compteur set valeur = @v where id = @i";
				SqlCommand sqlCommand4 = new SqlCommand(cmdText4, bd.cnn);
				sqlCommand4.Parameters.Add("@v", SqlDbType.Real).Value = this.guna2TextBox2.Text;
				sqlCommand4.Parameters.Add("@i", SqlDbType.Real).Value = equipement_compteur.id_compteur;
				bd.ouverture_bd(bd.cnn);
				sqlCommand2.ExecuteNonQuery();
				sqlCommand4.ExecuteNonQuery();
				sqlCommand3.ExecuteNonQuery();
				bd.cnn.Close();
				lancement_ot_preventive.creation_ot_compteur(Convert.ToInt32(equipement_compteur.id_compteur));
				MessageBox.Show("Ajout avec succés");
				this.remplissage_tableau();
				this.select_historique_compteur(equipement_compteur.id_compteur);
			}
			else
			{
				MessageBox.Show("Erreur : Le champs valeur doit être un réel");
			}
		}

		// Token: 0x040010C5 RID: 4293
		private static string id_modifier;

		// Token: 0x040010C6 RID: 4294
		private static string id_compteur;
	}
}
