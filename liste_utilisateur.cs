using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000091 RID: 145
	public partial class liste_utilisateur : Form
	{
		// Token: 0x060006CA RID: 1738 RVA: 0x001281A8 File Offset: 0x001263A8
		public liste_utilisateur()
		{
			this.InitializeComponent();
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(fonction.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(fonction.select_changee);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.remplissage_tableau(0);
		}

		// Token: 0x060006CB RID: 1739 RVA: 0x00128228 File Offset: 0x00126428
		private void panel1_Paint(object sender, PaintEventArgs e)
		{
			Pen pen = new Pen(Color.DimGray);
			pen.Width = 1f;
			e.Graphics.DrawLine(pen, 1, 1, 1148, 1);
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x00128264 File Offset: 0x00126464
		private void liste_utilisateur_Load(object sender, EventArgs e)
		{
			this.label3.Text = "";
			this.panel2.Hide();
			this.radGridView1.Size = new Size(1129, 551);
			this.select_fonction();
		}

		// Token: 0x060006CD RID: 1741 RVA: 0x001282B4 File Offset: 0x001264B4
		private void select_fonction()
		{
			this.radDropDownList1.Items.Clear();
			this.radDropDownList1.Items.Add("Administrateur");
			this.radDropDownList1.Items.Add("Responsable Méthode");
			this.radDropDownList1.Items.Add("Agent de Méthode");
			this.radDropDownList1.Items.Add("Responsable Achat");
			this.radDropDownList1.Items.Add("Responsable Magasin");
			this.radDropDownList1.Items.Add("Magasinier");
			this.radDropDownList1.Items.Add("Responsable Technique");
		}

		// Token: 0x060006CE RID: 1742 RVA: 0x00128370 File Offset: 0x00126570
		private void remplissage_tableau(int o)
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.AllowDragToGroup = false;
			this.radGridView1.AllowAddNewRow = false;
			this.radGridView1.EnablePaging = true;
			this.radGridView1.PageSize = 8;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select photo, id,login, mot_passe, fonction, mail, telephone from utilisateur where deleted = @i order by fonction";
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
					byte[] buffer = (byte[])dataTable.Rows[i].ItemArray[0];
					MemoryStream stream = new MemoryStream(buffer);
					this.radGridView1.Rows.Add(new object[]
					{
						Image.FromStream(stream),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString()
					});
					this.radGridView1.Rows[i].Cells[7].Value = this.imageList1.Images[1];
					this.radGridView1.Rows[i].Cells[8].Value = this.imageList1.Images[0];
					this.radGridView1.Rows[i].Height = 50;
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
					this.radGridView1.Rows[liste_utilisateur.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = liste_utilisateur.row_act != 0;
					if (flag7)
					{
						this.radGridView1.Rows[liste_utilisateur.row_act - 1].IsCurrent = true;
					}
					else
					{
						this.radGridView1.MasterTemplate.MoveToFirstPage();
						this.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060006CF RID: 1743 RVA: 0x0012870C File Offset: 0x0012690C
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = this.radGridView1.Rows.Count != 0;
			if (flag)
			{
				bool flag2 = e.RowIndex != -1;
				if (flag2)
				{
					string text = this.radGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
					liste_utilisateur.row_act = e.RowIndex;
					bool flag3 = e.RowIndex >= 0 && e.ColumnIndex == 8;
					if (flag3)
					{
						DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						bool flag4 = dialogResult == DialogResult.Yes;
						if (flag4)
						{
							string cmdText = "update utilisateur set deleted = @d where id = @a";
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
					bool flag5 = e.RowIndex >= 0 && e.ColumnIndex == 7;
					if (flag5)
					{
						this.label3.Text = text;
						string cmdText2 = "select photo,login, mot_passe, fonction, mail, telephone from utilisateur where id = @i";
						bd bd2 = new bd();
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd2.cnn);
						sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand2);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag6 = dataTable.Rows.Count != 0;
						if (flag6)
						{
							byte[] buffer = (byte[])dataTable.Rows[0].ItemArray[0];
							MemoryStream stream = new MemoryStream(buffer);
							this.pictureBox2.Image = Image.FromStream(stream);
							this.TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[1]);
							this.TextBox2.Text = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
							this.TextBox3.Text = Convert.ToString(dataTable.Rows[0].ItemArray[2]);
							this.radDropDownList1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[3]);
							this.guna2TextBox1.Text = Convert.ToString(dataTable.Rows[0].ItemArray[4]);
							this.guna2TextBox2.Text = Convert.ToString(dataTable.Rows[0].ItemArray[5]);
							this.radGridView1.Size = new Size(1129, 244);
							this.panel2.Show();
							this.remplissage_tableau(2);
						}
					}
				}
			}
		}

		// Token: 0x060006D0 RID: 1744 RVA: 0x00128A21 File Offset: 0x00126C21
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			this.panel2.Hide();
			this.radGridView1.Size = new Size(1129, 551);
		}

		// Token: 0x060006D1 RID: 1745 RVA: 0x00128A4C File Offset: 0x00126C4C
		private void PictureBox6_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.pictureBox2.Image = new Bitmap(openFileDialog.FileName);
			}
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00128AA0 File Offset: 0x00126CA0
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.TextBox2.Text) != "" & fonction.DeleteSpace(this.TextBox3.Text) != "" & fonction.DeleteSpace(this.radDropDownList1.Text) != "";
			if (flag)
			{
				bool flag2 = this.TextBox2.Text.ToLower() == this.TextBox3.Text.ToLower();
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "select id from utilisateur where login = @a and id <> @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.label3.Text;
					SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
					DataTable dataTable = new DataTable();
					sqlDataAdapter.Fill(dataTable);
					bool flag3 = dataTable.Rows.Count == 0;
					if (flag3)
					{
						MemoryStream memoryStream = new MemoryStream();
						this.pictureBox2.Image.Save(memoryStream, this.pictureBox2.Image.RawFormat);
						byte[] value = new byte[0];
						value = memoryStream.ToArray();
						string cmdText2 = "update utilisateur set login = @i1, mot_passe = @i2, fonction = @i3,photo = @i4, mail = @i5, telephone = @i6 where id = @i7";
						SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
						sqlCommand2.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox2.Text;
						sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.radDropDownList1.Text;
						sqlCommand2.Parameters.Add("@i4", SqlDbType.Image).Value = value;
						sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand2.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.guna2TextBox2.Text;
						sqlCommand2.Parameters.Add("@i7", SqlDbType.Int).Value = this.label3.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand2.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Modification avec succés");
						this.TextBox1.Clear();
						this.TextBox2.Clear();
						this.TextBox3.Clear();
						this.select_fonction();
						this.guna2TextBox1.Clear();
						this.guna2TextBox2.Clear();
						this.label3.Text = "";
						this.panel2.Hide();
						this.radGridView1.Size = new Size(1129, 551);
					}
					else
					{
						MessageBox.Show("Erreur : Nom d'utilisateur déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Votre mot de passe n'est pas correctement confirmé", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x04000925 RID: 2341
		private static int row_act;
	}
}
