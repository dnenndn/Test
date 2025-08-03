using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x02000090 RID: 144
	public partial class liste_outillage : Form
	{
		// Token: 0x060006B0 RID: 1712 RVA: 0x001239B0 File Offset: 0x00121BB0
		public liste_outillage()
		{
			this.InitializeComponent();
			this.radCheckedDropDownList1.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(liste_outillage.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(liste_outillage.select_changee);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x060006B1 RID: 1713 RVA: 0x00123A6C File Offset: 0x00121C6C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 16;
			if (flag)
			{
				this.button1.Text = "Modifier";
				this.button2.Visible = true;
				this.codeoutil_radTextBox1.Text = (string)this.radGridView1.CurrentRow.Cells[2].Value;
				this.codeoutil_radTextBox1.Enabled = false;
				this.design_radTextBox1.Text = (string)this.radGridView1.CurrentRow.Cells[3].Value;
				this.sec_radDropDownList1.Text = (string)this.radGridView1.CurrentRow.Cells[4].Value;
				this.nserie_radTextBox2.Text = (string)this.radGridView1.CurrentRow.Cells[5].Value;
				this.nmodel_radTextBox3.Text = (string)this.radGridView1.CurrentRow.Cells[6].Value;
				this.fab_radTextBox1.Text = (string)this.radGridView1.CurrentRow.Cells[7].Value;
				this.achat_radDateTimePicker1.Value = Convert.ToDateTime(this.radGridView1.CurrentRow.Cells[8].Value);
				this.fingarantie_radDateTimePicker2.Value = Convert.ToDateTime(this.radGridView1.CurrentRow.Cells[9].Value);
				this.miservice_radDateTimePicker3.Value = Convert.ToDateTime(this.radGridView1.CurrentRow.Cells[10].Value);
				this.prix_radTextBox5.Text = (string)this.radGridView1.CurrentRow.Cells[11].Value;
				this.remarque_radTextBox1.Text = (string)this.radGridView1.CurrentRow.Cells[12].Value;
				this.type_radDropDownList1.Text = (string)this.radGridView1.CurrentRow.Cells[13].Value;
				this.etat_radDropDownList1.Text = (string)this.radGridView1.CurrentRow.Cells[14].Value;
				this.pictureBox1.Image = (Image)this.radGridView1.CurrentRow.Cells[1].Value;
				this.insertion_automatique_utilisation();
			}
			bool flag2 = e.RowIndex >= 0 & e.ColumnIndex == 17;
			if (flag2)
			{
				this.supprimer_outil();
			}
		}

		// Token: 0x060006B2 RID: 1714 RVA: 0x00123D60 File Offset: 0x00121F60
		private void liste_outillage_Load(object sender, EventArgs e)
		{
			this.achat_radDateTimePicker1.Value = DateTime.Today;
			this.fingarantie_radDateTimePicker2.Value = DateTime.Today;
			this.miservice_radDateTimePicker3.Value = DateTime.Today;
			this.button2.Visible = false;
			this.remplissage_etat_outil();
			this.remplissage_rad_secteur();
			this.remplissage_rad_utilisation();
			this.remplissage_rad_tpe();
			this.remplissage_tableau();
		}

		// Token: 0x060006B3 RID: 1715 RVA: 0x00123DD4 File Offset: 0x00121FD4
		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = this.button1.Text == "Ajouter";
			if (flag)
			{
				this.codeoutil_radTextBox1.Enabled = true;
				this.inserer_nouveau_outil();
			}
			else
			{
				this.modifier_outil();
			}
		}

		// Token: 0x060006B4 RID: 1716 RVA: 0x00123E1C File Offset: 0x0012201C
		private void remplissage_rad_secteur()
		{
			string cmdText = "select * from secteur ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(this.dt_sec);
				for (int i = 0; i < this.dt_sec.Rows.Count; i++)
				{
					this.sec_radDropDownList1.Items.Add(this.dt_sec.Rows[i].ItemArray[2].ToString());
				}
			}
		}

		// Token: 0x060006B5 RID: 1717 RVA: 0x00123ED4 File Offset: 0x001220D4
		private void remplissage_rad_utilisation()
		{
			string cmdText = "select * from utilisation ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(this.dt_uti);
				for (int i = 0; i < this.dt_uti.Rows.Count; i++)
				{
					this.radCheckedDropDownList1.Items.Add(this.dt_uti.Rows[i].ItemArray[2].ToString());
				}
			}
		}

		// Token: 0x060006B6 RID: 1718 RVA: 0x00123F8C File Offset: 0x0012218C
		private void remplissage_rad_tpe()
		{
			string cmdText = "select * from tab_type ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(this.dt_type);
				for (int i = 0; i < this.dt_type.Rows.Count; i++)
				{
					this.type_radDropDownList1.Items.Add(this.dt_type.Rows[i].ItemArray[2].ToString());
				}
			}
		}

		// Token: 0x060006B7 RID: 1719 RVA: 0x00124044 File Offset: 0x00122244
		private void remplissage_etat_outil()
		{
			this.etat_radDropDownList1.Items.Clear();
			this.etat_radDropDownList1.Items.Add("Mauvaise");
			this.etat_radDropDownList1.Items.Add("Assez Bien");
			this.etat_radDropDownList1.Items.Add("Bien");
		}

		// Token: 0x060006B8 RID: 1720 RVA: 0x001240A8 File Offset: 0x001222A8
		private void remplissage_tableau()
		{
			this.radGridView1.Rows.Clear();
			this.radGridView1.PageSize = 8;
			this.radGridView1.EnableSorting = false;
			this.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			DataTable dataTable = new DataTable();
			string cmdText = "SELECT outils.id,outils.photo, outils.code_outils, outils.designation, secteur.designation ,outils.num_serie,outils.num_modele,outils.fabriquant,outils.date_achat,outils.Fin_garantie,outils.mise_service,outils.Prix_achat,outils.Remarque,tab_type.designation,outils.Etat_outil FROM outils left JOIN secteur ON outils.fk_secteur_id = secteur.id  left join tab_type on outils.FK_type_id = tab_type.id ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					byte[] buffer = (byte[])dataTable.Rows[i].ItemArray[1];
					MemoryStream stream = new MemoryStream(buffer);
					string text = this.afficher_utilisation(dataTable.Rows[i].ItemArray[0].ToString());
					this.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						Image.FromStream(stream),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[7].ToString(),
						dataTable.Rows[i].ItemArray[8].ToString().Substring(0, 9),
						dataTable.Rows[i].ItemArray[9].ToString().Substring(0, 9),
						dataTable.Rows[i].ItemArray[10].ToString().Substring(0, 9),
						dataTable.Rows[i].ItemArray[11].ToString(),
						dataTable.Rows[i].ItemArray[12].ToString(),
						dataTable.Rows[i].ItemArray[13].ToString(),
						dataTable.Rows[i].ItemArray[14].ToString(),
						text,
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
					this.radGridView1.Rows[i].Height = 40;
				}
				this.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
				this.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			}
		}

		// Token: 0x060006B9 RID: 1721 RVA: 0x001243EC File Offset: 0x001225EC
		private void inserer_nouveau_outil()
		{
			bool flag = this.codeoutil_radTextBox1.Text == "";
			if (flag)
			{
				MessageBox.Show("vou devez remplir les champs obligatoires", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag2 = this.verification_num(this.nserie_radTextBox2.Text, this.nmodel_radTextBox3.Text, this.prix_radTextBox5.Text);
				flag2 = true;
				bool flag3 = !flag2;
				if (flag3)
				{
					MessageBox.Show("vouz devez inserer des numero seulement", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				else
				{
					bool flag4 = this.sec_radDropDownList1.Text != "";
					if (flag4)
					{
						bool flag5 = this.type_radDropDownList1.Text != "";
						if (flag5)
						{
							MemoryStream memoryStream = new MemoryStream();
							this.pictureBox1.Image.Save(memoryStream, this.pictureBox1.Image.RawFormat);
							byte[] value = new byte[0];
							value = memoryStream.ToArray();
							string cmdText = "insert into dbo.outils(code_outils,num_serie,num_modele ,fabriquant,date_achat,Fin_garantie,mise_service,fk_secteur_id,FK_type_id,prix_achat,Etat_outil,designation,Remarque, photo, statut) values(@i1,@i2,@i3,@i4,@i5,@i6,@i7,@i8,@i9,@i11,@i12,@i13,@i14, @i15, @i16) SELECT CAST(SCOPE_IDENTITY() AS INT)";
							using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
							{
								try
								{
									string s = this.dt_sec.Rows[this.sec_radDropDownList1.SelectedItem.Index].ItemArray[0].ToString();
									string s2 = this.dt_type.Rows[this.type_radDropDownList1.SelectedItem.Index].ItemArray[0].ToString();
									sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = this.codeoutil_radTextBox1.Text;
									sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.nserie_radTextBox2.Text;
									sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.nmodel_radTextBox3.Text;
									sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.fab_radTextBox1.Text;
									sqlCommand.Parameters.Add("@i5", SqlDbType.Date).Value = this.achat_radDateTimePicker1.Value.Date;
									sqlCommand.Parameters.Add("@i6", SqlDbType.Date).Value = this.fingarantie_radDateTimePicker2.Value.Date;
									sqlCommand.Parameters.Add("@i7", SqlDbType.Date).Value = this.miservice_radDateTimePicker3.Value.Date;
									sqlCommand.Parameters.Add("@i8", SqlDbType.Int).Value = int.Parse(s);
									sqlCommand.Parameters.Add("@i9", SqlDbType.Int).Value = int.Parse(s2);
									sqlCommand.Parameters.Add("@i11", SqlDbType.VarChar).Value = this.prix_radTextBox5.Text;
									sqlCommand.Parameters.Add("@i12", SqlDbType.VarChar).Value = this.etat_radDropDownList1.SelectedItem.Text;
									sqlCommand.Parameters.Add("@i13", SqlDbType.VarChar).Value = this.design_radTextBox1.Text;
									sqlCommand.Parameters.Add("@i14", SqlDbType.VarChar).Value = this.remarque_radTextBox1.Text;
									sqlCommand.Parameters.Add("@i15", SqlDbType.Image).Value = value;
									sqlCommand.Parameters.Add("@i16", SqlDbType.Int).Value = 0;
									sqlCommand.Connection.Open();
									int id_outil = (int)sqlCommand.ExecuteScalar();
									sqlCommand.Connection.Close();
									this.insert_utilisation(id_outil);
								}
								catch (Exception ex)
								{
									bool flag6 = ex is SqlException;
									if (flag6)
									{
										MessageBox.Show("code  existe deja", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
										sqlCommand.Connection.Close();
									}
								}
								sqlCommand.Connection.Close();
							}
							this.remplissage_tableau();
							this.clear_all();
						}
						else
						{
							MessageBox.Show("Erreur : Il faut choisir le type", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Il faut choisir le secteur", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
			}
		}

		// Token: 0x060006BA RID: 1722 RVA: 0x001248A4 File Offset: 0x00122AA4
		private void modifier_outil()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			bool flag = this.verification_num(this.nserie_radTextBox2.Text, this.nmodel_radTextBox3.Text, this.prix_radTextBox5.Text);
			flag = true;
			bool flag2 = !flag;
			if (flag2)
			{
				MessageBox.Show("vouz devez inserer des numero seulement", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			else
			{
				bool flag3 = this.sec_radDropDownList1.Text != "";
				if (flag3)
				{
					bool flag4 = this.type_radDropDownList1.Text != "";
					if (flag4)
					{
						MemoryStream memoryStream = new MemoryStream();
						this.pictureBox1.Image.Save(memoryStream, this.pictureBox1.Image.RawFormat);
						byte[] value2 = new byte[0];
						value2 = memoryStream.ToArray();
						string cmdText = "UPDATE outils SET num_serie=@i2,num_modele=@i3 ,fabriquant=@i4,fk_secteur_id=@i5,FK_type_id=@i6,prix_achat=@i8,Etat_outil=@i9,designation=@i10,Remarque=@i11,date_achat=@i12,Fin_garantie=@i13,mise_service=@i14, photo = @i15     where id=@i20 ";
						using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
						{
							try
							{
								string value3 = this.dt_sec.Rows[this.sec_radDropDownList1.FindString(this.sec_radDropDownList1.Text)].ItemArray[0].ToString();
								string value4 = this.dt_type.Rows[this.type_radDropDownList1.FindString(this.type_radDropDownList1.Text)].ItemArray[0].ToString();
								sqlCommand.Parameters.Add("@i20", SqlDbType.VarChar).Value = value;
								sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.nserie_radTextBox2.Text;
								sqlCommand.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.nmodel_radTextBox3.Text;
								sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.fab_radTextBox1.Text;
								sqlCommand.Parameters.Add("@i5", SqlDbType.Int).Value = value3;
								sqlCommand.Parameters.Add("@i6", SqlDbType.Int).Value = value4;
								sqlCommand.Parameters.Add("@i8", SqlDbType.VarChar).Value = this.prix_radTextBox5.Text;
								sqlCommand.Parameters.Add("@i9", SqlDbType.VarChar).Value = this.etat_radDropDownList1.Text;
								sqlCommand.Parameters.Add("@i10", SqlDbType.VarChar).Value = this.design_radTextBox1.Text;
								sqlCommand.Parameters.Add("@i11", SqlDbType.VarChar).Value = this.remarque_radTextBox1.Text;
								sqlCommand.Parameters.Add("@i12", SqlDbType.Date).Value = this.achat_radDateTimePicker1.Value.Date;
								sqlCommand.Parameters.Add("@i13", SqlDbType.Date).Value = this.fingarantie_radDateTimePicker2.Value.Date;
								sqlCommand.Parameters.Add("@i14", SqlDbType.Date).Value = this.miservice_radDateTimePicker3.Value.Date;
								sqlCommand.Parameters.Add("@i15", SqlDbType.Image).Value = value2;
								sqlCommand.Connection.Open();
								sqlCommand.ExecuteNonQuery();
								sqlCommand.Connection.Close();
								this.button2.Visible = false;
							}
							catch (Exception ex)
							{
								string message = ex.Message;
								MessageBox.Show(message);
							}
							sqlCommand.Connection.Close();
						}
						this.modifier_utilisation();
						this.button1.Text = "Ajouter";
						this.codeoutil_radTextBox1.Enabled = true;
						this.clear_all();
						this.remplissage_tableau();
					}
					else
					{
						MessageBox.Show("Erreur : Il faut choisir le type", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Il faut choisir le secteur", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		// Token: 0x060006BB RID: 1723 RVA: 0x00124D14 File Offset: 0x00122F14
		private void supprimer_outil()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			DialogResult dialogResult = MessageBox.Show("voulez vous supprimer cette ligne", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
			bool flag = dialogResult == DialogResult.OK;
			if (flag)
			{
				string cmdText = "delete from outils where id= @i1;";
				using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
				{
					sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = value;
					sqlCommand.Connection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlCommand.Connection.Close();
				}
			}
			this.remplissage_tableau();
		}

		// Token: 0x060006BC RID: 1724 RVA: 0x00124DE0 File Offset: 0x00122FE0
		private bool verification_num(string s1, string s2, string s3)
		{
			int num = 0;
			float num2 = 0f;
			int num3;
			bool flag = int.TryParse(s1, out num3);
			bool flag2 = int.TryParse(s2, out num);
			bool flag3 = float.TryParse(s3, out num2);
			bool flag4 = flag && flag2 && flag3;
			bool result;
			if (flag4)
			{
				bool flag5 = true;
				result = flag5;
			}
			else
			{
				bool flag5 = false;
				result = flag5;
			}
			return result;
		}

		// Token: 0x060006BD RID: 1725 RVA: 0x00124E38 File Offset: 0x00123038
		private void pictureBox2_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.FileName = "";
			openFileDialog.ShowDialog();
			bool flag = openFileDialog.FileName != "";
			if (flag)
			{
				this.pictureBox1.Image = new Bitmap(openFileDialog.FileName);
			}
		}

		// Token: 0x060006BE RID: 1726 RVA: 0x00124E8C File Offset: 0x0012308C
		private void insertion_automatique_utilisation()
		{
			for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
			{
				this.radCheckedDropDownList1.Items[i].Checked = false;
			}
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			string cmdText = "select outils.code_outils,outils.id ,utilisation.designation from outil_utilisation inner join outils on outil_utilisation.id_outil = outils.id inner join utilisation  on outil_utilisation.id_utilisation = utilisation.id where outils.id=@i1 ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = value;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				for (int j = 0; j < dataTable.Rows.Count; j++)
				{
					for (int k = 0; k < this.radCheckedDropDownList1.Items.Count; k++)
					{
						bool flag = this.radCheckedDropDownList1.Items[k].Text.ToString() == dataTable.Rows[j].ItemArray[2].ToString();
						if (flag)
						{
							this.radCheckedDropDownList1.Items[k].Checked = true;
						}
					}
				}
			}
		}

		// Token: 0x060006BF RID: 1727 RVA: 0x00125010 File Offset: 0x00123210
		private void insert_utilisation(int id_outil)
		{
			for (int i = 0; i < this.radCheckedDropDownList1.Items.Count; i++)
			{
				bool @checked = this.radCheckedDropDownList1.Items[i].Checked;
				if (@checked)
				{
					string cmdText = "insert into outil_utilisation (id_outil,id_utilisation) values (@i1,@i2)";
					using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
					{
						sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = id_outil;
						sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = this.dt_uti.Rows[this.radCheckedDropDownList1.Items[i].Index].ItemArray[0].ToString();
						sqlCommand.Connection.Open();
						sqlCommand.ExecuteNonQuery();
						sqlCommand.Connection.Close();
					}
				}
			}
		}

		// Token: 0x060006C0 RID: 1728 RVA: 0x00125124 File Offset: 0x00123324
		private string afficher_utilisation(string id_outil)
		{
			string text = "";
			string cmdText = "select outils.code_outils,outils.id ,utilisation.designation from outil_utilisation inner join outils on outil_utilisation.id_outil = outils.id inner join utilisation  on outil_utilisation.id_utilisation = utilisation.id where outils.id=@i1 ";
			string result;
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = id_outil;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string str = dataTable.Rows[i].ItemArray[2].ToString() + "\n";
					text += str;
				}
				result = text;
			}
			return result;
		}

		// Token: 0x060006C1 RID: 1729 RVA: 0x001251FC File Offset: 0x001233FC
		private void modifier_utilisation()
		{
			string value = (string)this.radGridView1.CurrentRow.Cells[0].Value;
			string cmdText = "delete from outil_utilisation where id_outil= @i1;";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				sqlCommand.Parameters.Add("@i1", SqlDbType.VarChar).Value = value;
				sqlCommand.Connection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlCommand.Connection.Close();
			}
			this.insert_utilisation(Convert.ToInt32(value));
			this.remplissage_tableau();
		}

		// Token: 0x060006C2 RID: 1730 RVA: 0x001252B0 File Offset: 0x001234B0
		private void clear_all()
		{
			this.codeoutil_radTextBox1.Enabled = true;
			foreach (object obj in base.Controls)
			{
				Control control = (Control)obj;
				bool flag = control is RadTextBox;
				if (flag)
				{
					((RadTextBox)control).Clear();
				}
			}
			this.sec_radDropDownList1.Items.Clear();
			this.dt_sec.Clear();
			this.type_radDropDownList1.Items.Clear();
			this.dt_type.Clear();
			this.etat_radDropDownList1.Items.Clear();
			this.radCheckedDropDownList1.Items.Clear();
			this.dt_uti.Clear();
			this.remplissage_etat_outil();
			this.remplissage_rad_secteur();
			this.remplissage_rad_utilisation();
			this.remplissage_rad_tpe();
			this.button1.Text = "Ajouter";
			this.button2.Visible = false;
		}

		// Token: 0x060006C3 RID: 1731 RVA: 0x001253D4 File Offset: 0x001235D4
		private void button2_Click(object sender, EventArgs e)
		{
		}

		// Token: 0x060006C4 RID: 1732 RVA: 0x001253D7 File Offset: 0x001235D7
		private void button2_Click_1(object sender, EventArgs e)
		{
			this.clear_all();
		}

		// Token: 0x060006C5 RID: 1733 RVA: 0x001253E4 File Offset: 0x001235E4
		private void button1_Click_1(object sender, EventArgs e)
		{
			bool flag = this.button1.Text == "Ajouter";
			if (flag)
			{
				this.codeoutil_radTextBox1.Enabled = true;
				this.inserer_nouveau_outil();
			}
			else
			{
				this.modifier_outil();
			}
		}

		// Token: 0x060006C6 RID: 1734 RVA: 0x0012542C File Offset: 0x0012362C
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

		// Token: 0x060006C7 RID: 1735 RVA: 0x001254B0 File Offset: 0x001236B0
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

		// Token: 0x040008FD RID: 2301
		private bd b = new bd();

		// Token: 0x040008FE RID: 2302
		private DataTable dt_sec = new DataTable();

		// Token: 0x040008FF RID: 2303
		private DataTable dt_type = new DataTable();

		// Token: 0x04000900 RID: 2304
		private DataTable dt_uti = new DataTable();
	}
}
