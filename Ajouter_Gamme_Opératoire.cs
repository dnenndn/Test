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
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000009 RID: 9
	public partial class Ajouter_Gamme_Opératoire : Form
	{
		// Token: 0x0600005B RID: 91 RVA: 0x0000CDBC File Offset: 0x0000AFBC
		public Ajouter_Gamme_Opératoire()
		{
			this.InitializeComponent();
			this.radMenuItem1.Click += this.click_ajouter;
			this.radDropDownList1.DropDownListElement.Popup.ToolTipTextNeeded += new ToolTipTextNeededEventHandler(this.Popup_ToolTipTextNeeded);
			this.radCheckedDropDownList2.DropDownListElement.Popup.ToolTipTextNeeded += new ToolTipTextNeededEventHandler(this.Popup_ToolTipTextNeeded);
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(Ajouter_Gamme_Opératoire.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(Ajouter_Gamme_Opératoire.select_changee);
			this.radGridView2.ViewCellFormatting += new CellFormattingEventHandler(Ajouter_Gamme_Opératoire.select_change);
			this.radGridView2.ViewRowFormatting += new RowFormattingEventHandler(Ajouter_Gamme_Opératoire.select_changee);
			this.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(Ajouter_Gamme_Opératoire.select_change);
			this.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(Ajouter_Gamme_Opératoire.select_changee);
			this.radCheckedDropDownList2.TextBlockFormatting += new TextBlockFormattingEventHandler(design.radCheckedDropDownList_TextBlockFormatting);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.RadGridView3_CellClick);
			this.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
			this.radGridView2.CellClick += new GridViewCellEventHandler(this.RadGridView2_CellClick);
			this.select_article();
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000CF34 File Offset: 0x0000B134
		private void Popup_ToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e)
		{
			RadListVisualItem radListVisualItem = sender as RadListVisualItem;
			bool flag = radListVisualItem != null;
			if (flag)
			{
				e.ToolTipText = radListVisualItem.Text;
			}
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000CF60 File Offset: 0x0000B160
		private void RadGridView2_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 5;
			if (flag)
			{
				this.radGridView2.Rows.RemoveAt(e.RowIndex);
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000CFA0 File Offset: 0x0000B1A0
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 3;
			if (flag)
			{
				this.radGridView1.Rows.RemoveAt(e.RowIndex);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000CFE0 File Offset: 0x0000B1E0
		private void RadGridView3_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 4;
			if (flag)
			{
				this.radGridView3.Rows.RemoveAt(e.RowIndex);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000D01E File Offset: 0x0000B21E
		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			this.radTreeView1.Filter = this.guna2TextBox2.Text;
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000D038 File Offset: 0x0000B238
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

		// Token: 0x06000062 RID: 98 RVA: 0x0000D0BC File Offset: 0x0000B2BC
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

		// Token: 0x06000063 RID: 99 RVA: 0x0000D1C0 File Offset: 0x0000B3C0
		private void select_priorite_ajout()
		{
			this.radDropDownList2.Items.Clear();
			this.radDropDownList2.Items.Add("Elevée");
			this.radDropDownList2.Items.Add("Moyenne");
			this.radDropDownList2.Items.Add("Faible");
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000D224 File Offset: 0x0000B424
		private void select_etat_ajout()
		{
			this.radDropDownList4.Items.Clear();
			this.radDropDownList4.Items.Add("En Cours");
			this.radDropDownList4.Items.Add("En Préparation");
			this.radDropDownList4.Items.Add("Planifié");
			this.radDropDownList4.Items.Add("En Attente Arrêt Machine");
			this.radDropDownList4.Items.Add("Sous-Traitant à contacter");
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000D2B4 File Offset: 0x0000B4B4
		private void select_type_intervention_ajout()
		{
			this.radDropDownList5.Items.Clear();
			this.radDropDownList5.Items.Add("Préventive Systématique");
			this.radDropDownList5.Items.Add("Préventive Syst Compteur");
			this.radDropDownList5.Items.Add("Préventive Conditionnelle");
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000D318 File Offset: 0x0000B518
		private void select_operation()
		{
			this.radDropDownList10.Items.Clear();
			this.radDropDownList10.Items.Add("Révision");
			this.radDropDownList10.Items.Add("Contrôle");
			this.radDropDownList10.Items.Add("Inspection");
			this.radDropDownList10.Items.Add("Graissage");
			this.radDropDownList10.Items.Add("Lubrification");
			this.radDropDownList10.Items.Add("Nettoyage");
			this.radDropDownList10.Items.Add("Changement");
			this.radDropDownList10.Items.Add("Test");
			this.radDropDownList10.Items.Add("Visite");
			this.radDropDownList10.Items.Add("Autres");
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000D414 File Offset: 0x0000B614
		private void select_classe_intervention_ajout()
		{
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
			string cmdText = "select id, designation from parametre_classe_intervention";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
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

		// Token: 0x06000068 RID: 104 RVA: 0x0000D500 File Offset: 0x0000B700
		private void select_centre_charge_ajout()
		{
			bd bd = new bd();
			this.radCheckedDropDownList2.Items.Clear();
			string cmdText = "select id, designation from parametre_centre_charge";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radCheckedDropDownList2.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radCheckedDropDownList2.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000D5EC File Offset: 0x0000B7EC
		private void select_superviseur_ajout()
		{
			bd bd = new bd();
			this.radDropDownList8.Items.Clear();
			string cmdText = "select id, nom from intervenant where deleted = @d order by nom";
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
					this.radDropDownList8.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList8.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000D6F4 File Offset: 0x0000B8F4
		private void select_plan_maintenance_ajout()
		{
			bd bd = new bd();
			this.radDropDownList1.Items.Clear();
			string cmdText = "select id, designation from plan_maintenance where deleted = @d order by designation";
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
					this.radDropDownList1.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x0000D7FC File Offset: 0x0000B9FC
		private void Ajouter_Gamme_Opératoire_Load(object sender, EventArgs e)
		{
			this.select_priorite_ajout();
			this.select_type_intervention_ajout();
			this.select_centre_charge_ajout();
			this.select_classe_intervention_ajout();
			this.select_superviseur_ajout();
			this.select_etat_ajout();
			this.select_plan_maintenance_ajout();
			this.select_type_outil();
			this.select_fonction();
			this.select_operation();
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000D850 File Offset: 0x0000BA50
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = this.radDropDownList2.Text != "" & this.radDropDownList4.Text != "" & this.radDropDownList5.Text != "" & this.radDropDownList6.Text != "" & this.radDropDownList1.Text != "" & fonction.DeleteSpace(this.TextBox1.Text) != "" & fonction.DeleteSpace(this.guna2TextBox1.Text) != "" & this.radDropDownList10.Text != "";
			if (flag)
			{
				int num = 0;
				bool flag2 = this.radDropDownList8.Text != "";
				if (flag2)
				{
					num = Convert.ToInt32(this.radDropDownList8.SelectedItem.Tag.ToString());
				}
				bool flag3 = fonction.isnumeric(this.guna2TextBox7.Text);
				if (flag3)
				{
					bool flag4 = Convert.ToInt32(this.guna2TextBox7.Text) > 0;
					if (flag4)
					{
						string value = "";
						foreach (object obj in this.panel6.Controls)
						{
							RadRadioButton radRadioButton = (RadRadioButton)obj;
							bool isChecked = radRadioButton.IsChecked;
							if (isChecked)
							{
								value = radRadioButton.Text;
							}
						}
						bd bd = new bd();
						string cmdText = "select id from gamme_operatoire where code = @v";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v", SqlDbType.VarChar).Value = this.TextBox1.Text;
						SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
						DataTable dataTable = new DataTable();
						sqlDataAdapter.Fill(dataTable);
						bool flag5 = dataTable.Rows.Count == 0;
						if (flag5)
						{
							string cmdText2 = "insert into gamme_operatoire (id_plan, code, designation, urgence, statut, type, id_classe, id_superviseur, duree, var_duree, deleted, operation) values(@i1, @i2, @i3, @i4, @i5, @i6, @i7, @i9, @i10, @i11, @i12, @i13)SELECT CAST(scope_identity() AS int)";
							SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
							sqlCommand2.Parameters.Add("@i1", SqlDbType.Int).Value = this.radDropDownList1.SelectedItem.Tag.ToString();
							sqlCommand2.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.TextBox1.Text;
							sqlCommand2.Parameters.Add("@i3", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
							sqlCommand2.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.radDropDownList2.Text;
							sqlCommand2.Parameters.Add("@i5", SqlDbType.VarChar).Value = this.radDropDownList4.Text;
							sqlCommand2.Parameters.Add("@i6", SqlDbType.VarChar).Value = this.radDropDownList5.Text;
							sqlCommand2.Parameters.Add("@i7", SqlDbType.Int).Value = this.radDropDownList6.SelectedItem.Tag.ToString();
							sqlCommand2.Parameters.Add("@i9", SqlDbType.Int).Value = num;
							sqlCommand2.Parameters.Add("@i10", SqlDbType.Int).Value = this.guna2TextBox7.Text;
							sqlCommand2.Parameters.Add("@i11", SqlDbType.VarChar).Value = value;
							sqlCommand2.Parameters.Add("@i12", SqlDbType.Int).Value = 0;
							sqlCommand2.Parameters.Add("@i13", SqlDbType.VarChar).Value = this.radDropDownList10.Text;
							bd.ouverture_bd(bd.cnn);
							int num2 = (int)sqlCommand2.ExecuteScalar();
							bd.cnn.Close();
							List<string> list = new List<string>();
							list.Clear();
							for (int i = 0; i < this.radCheckedDropDownList2.Items.Count; i++)
							{
								bool @checked = this.radCheckedDropDownList2.Items[i].Checked;
								if (@checked)
								{
									list.Add(this.radCheckedDropDownList2.Items[i].Tag.ToString());
								}
							}
							bool flag6 = list.Count != 0;
							if (flag6)
							{
								for (int j = 0; j < list.Count; j++)
								{
									string cmdText3 = "insert into gamme_centre_charge (id_gamme, id_centre_charge) values (@i1, @i2)";
									SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
									sqlCommand3.Parameters.Add("@i1", SqlDbType.Int).Value = num2;
									sqlCommand3.Parameters.Add("@i2", SqlDbType.Int).Value = list[j];
									bd.ouverture_bd(bd.cnn);
									sqlCommand3.ExecuteNonQuery();
									bd.cnn.Close();
								}
							}
							this.save_pdr(num2);
							this.save_outillage(num2);
							this.save_fonction(num2);
							this.TextBox1.Clear();
							this.guna2TextBox1.Clear();
							this.radGridView1.Rows.Clear();
							this.radGridView2.Rows.Clear();
							this.radGridView3.Rows.Clear();
							MessageBox.Show("Enregistrement avec succés");
						}
						else
						{
							MessageBox.Show("Erreur : Code Gamme Opératoire déja existe", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur : Durée estimée doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur : Durée estimée doit être un entier strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur : Un champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x0600006D RID: 109 RVA: 0x0000DE70 File Offset: 0x0000C070
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
							bool flag4 = Convert.ToInt32(this.radGridView3.Rows[i].Cells[0].Value) == num;
							if (flag4)
							{
								num2 = 1;
							}
						}
						bool flag5 = num2 == 0;
						if (flag5)
						{
							this.radGridView3.Rows.Add(new object[]
							{
								selectedNode.Tag.ToString(),
								selectedNode.ToolTipText,
								selectedNode.Text,
								this.guna2TextBox3.Text,
								Resources.icons8_supprimer_pour_toujours_100__4_
							});
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

		// Token: 0x0600006E RID: 110 RVA: 0x0000DFF8 File Offset: 0x0000C1F8
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

		// Token: 0x0600006F RID: 111 RVA: 0x0000E130 File Offset: 0x0000C330
		private void select_type_outil()
		{
			this.radDropDownList3.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from tab_type order by designation";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = ot_liste.id_ot_tr;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList3.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList3.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000070 RID: 112 RVA: 0x0000E23C File Offset: 0x0000C43C
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList3.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(this.guna2TextBox4.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.guna2TextBox4.Text) > 0;
					if (flag3)
					{
						int num = 0;
						for (int i = 0; i < this.radGridView1.Rows.Count; i++)
						{
							bool flag4 = this.radGridView1.Rows[i].Cells[0].Value.ToString() == this.radDropDownList3.SelectedItem.Tag.ToString();
							if (flag4)
							{
								num = 1;
							}
						}
						bool flag5 = num == 0;
						if (flag5)
						{
							this.radGridView1.Rows.Add(new object[]
							{
								this.radDropDownList3.SelectedItem.Tag.ToString(),
								this.radDropDownList3.Text,
								this.guna2TextBox4.Text,
								Resources.icons8_supprimer_pour_toujours_100__4_
							});
						}
						else
						{
							MessageBox.Show("Erreur :La Famille d'outillage est déja ajoutée", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
			else
			{
				MessageBox.Show("Erreur :Il faut choisir la famille d'outillage", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000E3D8 File Offset: 0x0000C5D8
		private void select_fonction()
		{
			this.radDropDownList9.Items.Clear();
			bd bd = new bd();
			string cmdText = "select id, designation from fonction_intervenant";
			SqlCommand selectCommand = new SqlCommand(cmdText, bd.cnn);
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList9.Items.Add(dataTable.Rows[i].ItemArray[1].ToString());
					this.radDropDownList9.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000072 RID: 114 RVA: 0x0000E4C4 File Offset: 0x0000C6C4
		private void radButton2_Click(object sender, EventArgs e)
		{
			bool flag = this.radDropDownList9.Text != "";
			if (flag)
			{
				fonction fonction = new fonction();
				bool flag2 = fonction.isnumeric(this.guna2TextBox5.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToInt32(this.guna2TextBox5.Text) > 0;
					if (flag3)
					{
						bool flag4 = fonction.isnumeric(this.guna2TextBox6.Text);
						if (flag4)
						{
							bool flag5 = Convert.ToInt32(this.guna2TextBox6.Text) > 0;
							if (flag5)
							{
								string text = "Interne";
								bool isChecked = this.radRadioButton2.IsChecked;
								if (isChecked)
								{
									text = "Externe";
								}
								this.radGridView2.Rows.Add(new object[]
								{
									this.radDropDownList9.SelectedItem.Tag.ToString(),
									this.radDropDownList9.Text,
									this.guna2TextBox5.Text,
									this.guna2TextBox6.Text,
									text,
									Resources.icons8_supprimer_pour_toujours_100__4_
								});
							}
							else
							{
								MessageBox.Show("Erreur :Minutes planifiées doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
							}
						}
						else
						{
							MessageBox.Show("Erreur :Minutes planifiées doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						}
					}
					else
					{
						MessageBox.Show("Erreur :Nbre Requis doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :Nbre Requis doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Il faut choisir la fonction", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		// Token: 0x06000073 RID: 115 RVA: 0x0000E660 File Offset: 0x0000C860
		private void save_pdr(int id)
		{
			for (int i = 0; i < this.radGridView3.Rows.Count; i++)
			{
				bd bd = new bd();
				string cmdText = "insert into gamme_ressources_pdr (id_article, id_gamme, quantite) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = this.radGridView3.Rows[i].Cells[0].Value.ToString();
				sqlCommand.Parameters.Add("@v2", SqlDbType.Int).Value = id;
				sqlCommand.Parameters.Add("@v3", SqlDbType.Real).Value = this.radGridView3.Rows[i].Cells[3].Value.ToString();
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}

		// Token: 0x06000074 RID: 116 RVA: 0x0000E768 File Offset: 0x0000C968
		private void save_outillage(int id)
		{
			for (int i = 0; i < this.radGridView1.Rows.Count; i++)
			{
				bd bd = new bd();
				string cmdText = "insert into gamme_ressources_outillage (id_type, id_gamme, quantite) values (@v1, @v2, @v3)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[0].Value.ToString();
				sqlCommand.Parameters.Add("@v2", SqlDbType.Int).Value = id;
				sqlCommand.Parameters.Add("@v3", SqlDbType.Int).Value = this.radGridView1.Rows[i].Cells[2].Value.ToString();
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x0000E870 File Offset: 0x0000CA70
		private void save_fonction(int id)
		{
			for (int i = 0; i < this.radGridView2.Rows.Count; i++)
			{
				bd bd = new bd();
				string cmdText = "insert into gamme_ressources_fonction (id_fonction, id_gamme, nbre_requis, min_planif, type_cout) values (@v1, @v2, @v3, @v4, @v5)";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[0].Value.ToString();
				sqlCommand.Parameters.Add("@v2", SqlDbType.Int).Value = id;
				sqlCommand.Parameters.Add("@v3", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[2].Value.ToString();
				sqlCommand.Parameters.Add("@v4", SqlDbType.Int).Value = this.radGridView2.Rows[i].Cells[3].Value.ToString();
				sqlCommand.Parameters.Add("@v5", SqlDbType.VarChar).Value = this.radGridView2.Rows[i].Cells[4].Value.ToString();
				bd.ouverture_bd(bd.cnn);
				sqlCommand.ExecuteNonQuery();
				bd.cnn.Close();
			}
		}
	}
}
