using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.Localization;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Export;
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x020000C5 RID: 197
	public partial class ot_liste : Form
	{
		// Token: 0x060008C9 RID: 2249 RVA: 0x001746CC File Offset: 0x001728CC
		public ot_liste()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			ot_liste.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(ot_liste.select_change);
			ot_liste.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(ot_liste.select_changee);
			ot_liste.radGridView1.CellClick += new GridViewCellEventHandler(this.action_tableau);
			ot_liste.remplissage_tableau(0);
		}

		// Token: 0x060008CA RID: 2250 RVA: 0x0017474D File Offset: 0x0017294D
		private void ot_liste_Load(object sender, EventArgs e)
		{
			this.pictureBox3_Click(sender, e);
		}

		// Token: 0x060008CB RID: 2251 RVA: 0x0017475C File Offset: 0x0017295C
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

		// Token: 0x060008CC RID: 2252 RVA: 0x001747E0 File Offset: 0x001729E0
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

		// Token: 0x060008CD RID: 2253 RVA: 0x001748E4 File Offset: 0x00172AE4
		public static void remplissage_tableau(int o)
		{
			ot_liste.radGridView1.Rows.Clear();
			ot_liste.radGridView1.AllowDragToGroup = false;
			ot_liste.radGridView1.AllowAddNewRow = false;
			ot_liste.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			string text = string.Join<int>(",", ordre_travail.id_ort.ToArray());
			bool flag = ordre_travail.type_maintenance == "Corrective";
			string cmdText;
			if (flag)
			{
				cmdText = "select ordre_travail.urgence, ordre_travail.statut, ordre_travail.id, n_ot, demande_intervention.n_di, type, parametre_classe_intervention.designation, date_debut, heure_debut, equipement.designation, utilisateur.login, parametre_intervention.intervention, atelier.designation ,sous_equipe.designation ,organe.designation, commentaire, intervenant.nom, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa)),demande_intervention.arret_machine from ordre_travail left join intervenant on ordre_travail.id_superviseur = intervenant.id left join utilisateur on ordre_travail.createur = utilisateur.id left join equipement on ordre_travail.equipement = equipement.id left join equipement as atelier on ordre_travail.atelier = atelier.id left join equipement as sous_equipe on ordre_travail.sous_equipement = sous_equipe.id left join equipement as organe on ordre_travail.organe = organe.id inner join parametre_intervention on ordre_travail.id_intervention = parametre_intervention.id left join parametre_classe_intervention on ordre_travail.id_classe = parametre_classe_intervention.id left join demande_intervention on ordre_travail.id_di = demande_intervention.id where ordre_travail.id in (" + text + ") and ordre_travail.deleted = @d order by date_debut desc, heure_debut desc ";
			}
			else
			{
				bool flag2 = ordre_travail.type_maintenance == "Préventive";
				if (flag2)
				{
					cmdText = "select ordre_travail.urgence, ordre_travail.statut, ordre_travail.id, n_ot, demande_intervention.n_di, ordre_travail.type, parametre_classe_intervention.designation, date_debut, heure_debut, equipement.designation,utilisateur.login, gamme_operatoire.designation, atelier.designation ,sous_equipe.designation ,organe.designation, commentaire, intervenant.nom,datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa)) ,demande_intervention.arret_machine from ordre_travail left join intervenant on ordre_travail.id_superviseur = intervenant.id left join utilisateur on ordre_travail.createur = utilisateur.id left join equipement on ordre_travail.equipement = equipement.id left join equipement as atelier on ordre_travail.atelier = atelier.id left join equipement as sous_equipe on ordre_travail.sous_equipement = sous_equipe.id left join equipement as organe on ordre_travail.organe = organe.id inner join gamme_operatoire on ordre_travail.id_intervention = gamme_operatoire.id left join parametre_classe_intervention on ordre_travail.id_classe = parametre_classe_intervention.id left join demande_intervention on ordre_travail.id_di = demande_intervention.id where ordre_travail.id in (" + text + ") and ordre_travail.deleted = @d order by date_debut desc, heure_debut desc ";
				}
				else
				{
					cmdText = string.Concat(new string[]
					{
						"select ordre_travail.urgence, ordre_travail.statut, ordre_travail.id, n_ot, demande_intervention.n_di, ordre_travail.type, parametre_classe_intervention.designation, date_debut, heure_debut, equipement.designation, utilisateur.login, gamme_operatoire.designation, atelier.designation ,sous_equipe.designation ,organe.designation, commentaire, intervenant.nom, datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa)) ,demande_intervention.arret_machine from ordre_travail left join intervenant on ordre_travail.id_superviseur = intervenant.id left join utilisateur on ordre_travail.createur = utilisateur.id left join equipement on ordre_travail.equipement = equipement.id left join equipement as atelier on ordre_travail.atelier = atelier.id left join equipement as sous_equipe on ordre_travail.sous_equipement = sous_equipe.id left join equipement as organe on ordre_travail.organe = organe.id inner join gamme_operatoire on ordre_travail.id_intervention = gamme_operatoire.id left join parametre_classe_intervention on ordre_travail.id_classe = parametre_classe_intervention.id left join demande_intervention on ordre_travail.id_di = demande_intervention.id where ordre_travail.id in (",
						text,
						") and ordre_travail.deleted = @d and ordre_travail.type like  '%'  + @p10 + '%' UNION select ordre_travail.urgence, ordre_travail.statut, ordre_travail.id, n_ot, demande_intervention.n_di, type, parametre_classe_intervention.designation, date_debut, heure_debut, equipement.designation, utilisateur.login, parametre_intervention.intervention, atelier.designation ,sous_equipe.designation ,organe.designation, commentaire, intervenant.nom,datediff(MINUTE,concat(date_debut,@espace, heure_debut, @wa),concat(date_fin,@espace, heure_fin, @wa)),demande_intervention.arret_machine from ordre_travail left join intervenant on ordre_travail.id_superviseur = intervenant.id left join utilisateur on ordre_travail.createur = utilisateur.id left join equipement on ordre_travail.equipement = equipement.id left join equipement as atelier on ordre_travail.atelier = atelier.id left join equipement as sous_equipe on ordre_travail.sous_equipement = sous_equipe.id left join equipement as organe on ordre_travail.organe = organe.id inner join parametre_intervention on ordre_travail.id_intervention = parametre_intervention.id left join parametre_classe_intervention on ordre_travail.id_classe = parametre_classe_intervention.id left join demande_intervention on ordre_travail.id_di = demande_intervention.id where ordre_travail.id in (",
						text,
						") and ordre_travail.deleted = @d and ordre_travail.type not like '%'  + @p10 + '%' order by date_debut desc, heure_debut desc "
					});
				}
			}
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
			sqlCommand.Parameters.Add("@p10", SqlDbType.VarChar).Value = "Préventive";
			sqlCommand.Parameters.Add("@espace", SqlDbType.VarChar).Value = " ";
			sqlCommand.Parameters.Add("@wa", SqlDbType.VarChar).Value = ":00";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag3 = dataTable.Rows.Count != 0;
			if (flag3)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text2 = "Red";
					bool flag4 = dataTable.Rows[i].ItemArray[0].ToString() == "Moyenne";
					if (flag4)
					{
						text2 = "Yellow";
					}
					bool flag5 = dataTable.Rows[i].ItemArray[0].ToString() == "Faible";
					if (flag5)
					{
						text2 = "Green";
					}
					string text3 = dataTable.Rows[i].ItemArray[1].ToString();
					ot_liste.radGridView1.Rows.Add(new object[]
					{
						text2,
						Resources.icons8_visible_96,
						text3,
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[4]),
						Convert.ToString(dataTable.Rows[i].ItemArray[5]),
						Convert.ToString(dataTable.Rows[i].ItemArray[6]),
						fonction.Mid(dataTable.Rows[i].ItemArray[7].ToString(), 1, 10),
						dataTable.Rows[i].ItemArray[8].ToString(),
						dataTable.Rows[i].ItemArray[12].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[9]),
						dataTable.Rows[i].ItemArray[13].ToString(),
						dataTable.Rows[i].ItemArray[14].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[10]),
						Convert.ToString(dataTable.Rows[i].ItemArray[11]),
						Convert.ToString(dataTable.Rows[i].ItemArray[15]),
						Convert.ToString(dataTable.Rows[i].ItemArray[16]),
						Convert.ToString(dataTable.Rows[i].ItemArray[17]),
						Convert.ToString(dataTable.Rows[i].ItemArray[18]),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			bool flag6 = ot_liste.radGridView1.Rows.Count != 0;
			if (flag6)
			{
				bool flag7 = o == 0;
				if (flag7)
				{
					ot_liste.radGridView1.MasterTemplate.MoveToFirstPage();
					ot_liste.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag8 = o == 1;
				if (flag8)
				{
					ot_liste.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag9 = o == 2;
				if (flag9)
				{
					ot_liste.radGridView1.Rows[ot_liste.row_act].IsCurrent = true;
				}
				bool flag10 = o == 3;
				if (flag10)
				{
					bool flag11 = ot_liste.row_act != 0;
					if (flag11)
					{
						ot_liste.radGridView1.Rows[ot_liste.row_act - 1].IsCurrent = true;
					}
					else
					{
						ot_liste.radGridView1.MasterTemplate.MoveToFirstPage();
						ot_liste.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			ot_liste.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			ot_liste.radGridView1.Templates.Clear();
			ot_liste.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x060008CE RID: 2254 RVA: 0x00174EA8 File Offset: 0x001730A8
		private void couleur_button(Button b)
		{
			foreach (object obj in this.panel4.Controls)
			{
				Control control = (Control)obj;
				bool flag = control is Button;
				if (flag)
				{
					bool flag2 = control.Name != b.Name;
					if (flag2)
					{
						control.BackColor = Color.WhiteSmoke;
						control.ForeColor = Color.Black;
					}
					else
					{
						control.BackColor = Color.White;
						control.ForeColor = Color.Firebrick;
					}
				}
			}
		}

		// Token: 0x060008CF RID: 2255 RVA: 0x00174F64 File Offset: 0x00173164
		private void button1_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button1);
			this.panel1.Controls.Clear();
			ot_general ot_general = new ot_general();
			ot_general.TopLevel = false;
			this.panel1.Controls.Add(ot_general);
			ot_general.Show();
		}

		// Token: 0x060008D0 RID: 2256 RVA: 0x00174FB8 File Offset: 0x001731B8
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 1;
			if (flag)
			{
				ot_liste.row_act = e.RowIndex;
				this.cc = e.RowIndex;
				ot_liste.id_ot_tr = Convert.ToInt32(ot_liste.radGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
				ot_liste.type_ot_tr = Convert.ToString(ot_liste.radGridView1.Rows[e.RowIndex].Cells[6].Value.ToString());
				this.panel1.Show();
				this.panel4.Show();
				ot_liste.radGridView1.Size = new Size(ot_liste.radGridView1.Size.Width, 192);
				this.label2.Text = ot_liste.radGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
				bool flag2 = this.button1.BackColor == Color.White;
				if (flag2)
				{
					this.button1_Click(sender, e);
				}
				bool flag3 = this.button3.BackColor == Color.White;
				if (flag3)
				{
					this.button3_Click(sender, e);
				}
				bool flag4 = this.button4.BackColor == Color.White;
				if (flag4)
				{
					this.button4_Click(sender, e);
				}
				bool flag5 = this.button2.BackColor == Color.White;
				if (flag5)
				{
					this.button2_Click(sender, e);
				}
				bool flag6 = this.button5.BackColor == Color.White;
				if (flag6)
				{
					this.button5_Click(sender, e);
				}
			}
			bool flag7 = e.RowIndex >= 0 && e.ColumnIndex == 20;
			if (flag7)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag8 = dialogResult == DialogResult.Yes;
				if (flag8)
				{
					bd bd = new bd();
					string cmdText = "update demande_intervention set statut = @d where id = (select id_di from ordre_travail where id = @i) and id not in (select id_di from ordre_travail where id <> @i and statut <> @a)";
					string cmdText2 = "delete ordre_travail where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					int num = Convert.ToInt32(ot_liste.radGridView1.Rows[e.RowIndex].Cells[3].Value);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 0;
					sqlCommand.Parameters.Add("@a", SqlDbType.VarChar).Value = "Annulé";
					sqlCommand2.Parameters.Add("@i", SqlDbType.Int).Value = num;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					sqlCommand2.ExecuteNonQuery();
					bd.cnn.Close();
					this.pictureBox3_Click(sender, e);
				}
			}
		}

		// Token: 0x060008D1 RID: 2257 RVA: 0x001752E8 File Offset: 0x001734E8
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Hide();
			this.panel4.Hide();
			ot_liste.radGridView1.Size = new Size(ot_liste.radGridView1.Size.Width, 494);
			this.cc = -1;
		}

		// Token: 0x060008D2 RID: 2258 RVA: 0x0017533C File Offset: 0x0017353C
		private void ot_formatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.CellElement.RowInfo is GridViewDataRowInfo;
			if (flag)
			{
				bool flag2 = this.cc == e.CellElement.RowIndex;
				if (flag2)
				{
					e.CellElement.DrawFill = true;
					e.CellElement.GradientStyle = 0;
					e.CellElement.BackColor = Color.Blue;
					e.CellElement.Focus();
				}
				else
				{
					e.CellElement.ResetValue(LightVisualElement.DrawFillProperty);
					e.CellElement.ResetValue(VisualElement.BackColorProperty);
					e.CellElement.ResetValue(LightVisualElement.GradientStyleProperty);
				}
			}
		}

		// Token: 0x060008D3 RID: 2259 RVA: 0x001753F0 File Offset: 0x001735F0
		private void button3_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button3);
			this.panel1.Controls.Clear();
			ot_ressources ot_ressources = new ot_ressources();
			ot_ressources.TopLevel = false;
			this.panel1.Controls.Add(ot_ressources);
			ot_ressources.Show();
		}

		// Token: 0x060008D4 RID: 2260 RVA: 0x00175444 File Offset: 0x00173644
		private void button4_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button4);
			this.panel1.Controls.Clear();
			ot_ordonnacement ot_ordonnacement = new ot_ordonnacement();
			ot_ordonnacement.TopLevel = false;
			this.panel1.Controls.Add(ot_ordonnacement);
			ot_ordonnacement.Show();
		}

		// Token: 0x060008D5 RID: 2261 RVA: 0x00175498 File Offset: 0x00173698
		private void button2_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button2);
			this.panel1.Controls.Clear();
			ot_diagnostic ot_diagnostic = new ot_diagnostic();
			ot_diagnostic.TopLevel = false;
			this.panel1.Controls.Add(ot_diagnostic);
			ot_diagnostic.Show();
		}

		// Token: 0x060008D6 RID: 2262 RVA: 0x001754EC File Offset: 0x001736EC
		private void button5_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button5);
			this.panel1.Controls.Clear();
			ot_bt ot_bt = new ot_bt();
			ot_bt.TopLevel = false;
			this.panel1.Controls.Add(ot_bt);
			ot_bt.Show();
		}

		// Token: 0x060008D7 RID: 2263 RVA: 0x00175540 File Offset: 0x00173740
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = "";
			saveFileDialog.ShowDialog();
			bool flag = false;
			bool flag2 = saveFileDialog.FileName != "";
			if (flag2)
			{
				this.RunExportToexcel(saveFileDialog.FileName, ref flag);
			}
		}

		// Token: 0x060008D8 RID: 2264 RVA: 0x00175590 File Offset: 0x00173790
		private void RunExportToexcel(string fileName, ref bool openExportFile)
		{
			new ExportToExcelML(ot_liste.radGridView1)
			{
				SummariesExportOption = 0,
				ChildViewExportMode = 3,
				PagingExportOption = 1,
				HiddenRowOption = 0,
				HiddenColumnOption = 0,
				ExportHierarchy = true
			}.RunExport(fileName);
			RadMessageBox.SetThemeName(ot_liste.radGridView1.ThemeName);
			MessageBox.Show("Enregistrement avec succés");
		}

		// Token: 0x04000BE2 RID: 3042
		private static int row_act;

		// Token: 0x04000BE3 RID: 3043
		public static int id_ot_tr;

		// Token: 0x04000BE4 RID: 3044
		public static string type_ot_tr;

		// Token: 0x04000BE5 RID: 3045
		private int cc = -1;
	}
}
