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
	// Token: 0x020000EC RID: 236
	public partial class Outillage_utilisation_lancement : Form
	{
		// Token: 0x06000A3E RID: 2622 RVA: 0x00196EDC File Offset: 0x001950DC
		public Outillage_utilisation_lancement()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			Outillage_utilisation_lancement.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(Outillage_utilisation_lancement.select_change);
			Outillage_utilisation_lancement.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(Outillage_utilisation_lancement.select_changee);
			Outillage_utilisation_lancement.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
		}

		// Token: 0x06000A3F RID: 2623 RVA: 0x00196F5A File Offset: 0x0019515A
		private void Outillage_utilisation_lancement_Load(object sender, EventArgs e)
		{
			this.date_debut_radDateTimePicker2.Value = DateTime.Today;
			this.heure_debut_radTimePicker1.Value = new DateTime?(DateTime.Now);
			Outillage_utilisation_lancement.remplissage_rad_outil();
			this.remplissage_rad_intervenant();
			Outillage_utilisation_lancement.remplissage_tableau();
		}

		// Token: 0x06000A40 RID: 2624 RVA: 0x00196F98 File Offset: 0x00195198
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 & e.ColumnIndex == 9;
			if (flag)
			{
				Outillage_utilisation_lancement.val = (string)Outillage_utilisation_lancement.radGridView1.CurrentRow.Cells[0].Value;
				Outillage_utilisation_lancement.val2 = (string)Outillage_utilisation_lancement.radGridView1.CurrentRow.Cells[10].Value;
				outillage_date_heure_fin outillage_date_heure_fin = new outillage_date_heure_fin();
				outillage_date_heure_fin.Show();
			}
		}

		// Token: 0x06000A41 RID: 2625 RVA: 0x0019701C File Offset: 0x0019521C
		private void remplissage_rad_intervenant()
		{
			this.intervenant_radDropDownList1.Items.Clear();
			string cmdText = "select id,nom from intervenant ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					string text = dataTable.Rows[i].ItemArray[1].ToString();
					this.intervenant_radDropDownList1.Items.Add(text);
					this.intervenant_radDropDownList1.Items[i].Tag = dataTable.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000A42 RID: 2626 RVA: 0x00197108 File Offset: 0x00195308
		public static void remplissage_rad_outil()
		{
			Outillage_utilisation_lancement.dt_outil.Clear();
			Outillage_utilisation_lancement.outil_radDropDownList2.Text = "";
			Outillage_utilisation_lancement.outil_radDropDownList2.Items.Clear();
			string cmdText = "select id,code_outils ,designation from outils where statut=0 ";
			bd bd = new bd();
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(Outillage_utilisation_lancement.dt_outil);
				for (int i = 0; i < Outillage_utilisation_lancement.dt_outil.Rows.Count; i++)
				{
					string text = Outillage_utilisation_lancement.dt_outil.Rows[i].ItemArray[1].ToString() + " - " + Outillage_utilisation_lancement.dt_outil.Rows[i].ItemArray[2].ToString();
					Outillage_utilisation_lancement.outil_radDropDownList2.Items.Add(text);
					Outillage_utilisation_lancement.outil_radDropDownList2.Items[i].Tag = Outillage_utilisation_lancement.dt_outil.Rows[i].ItemArray[0].ToString();
				}
			}
		}

		// Token: 0x06000A43 RID: 2627 RVA: 0x00197244 File Offset: 0x00195444
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

		// Token: 0x06000A44 RID: 2628 RVA: 0x001972C8 File Offset: 0x001954C8
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

		// Token: 0x06000A45 RID: 2629 RVA: 0x001973CB File Offset: 0x001955CB
		private void radButton1_Click(object sender, EventArgs e)
		{
			this.affecter_outil();
		}

		// Token: 0x06000A46 RID: 2630 RVA: 0x001973D8 File Offset: 0x001955D8
		private void affecter_outil()
		{
			bool flag = this.intervenant_radDropDownList1.Text == "" | Outillage_utilisation_lancement.outil_radDropDownList2.Text == "" | this.date_debut_radDateTimePicker2.Text == "" | this.heure_debut_radTimePicker1.Value == null;
			if (flag)
			{
				MessageBox.Show("vous devez remplir tous le champs");
			}
			else
			{
				string cmdText = "insert into tab_lancement_affectation (id_intervenant,outil,date_debut,heure_debut,commentaire,encours, n_ot) values(@i1,@i2,@i3,@i4,@i7,@i8, @i9) ";
				using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
				{
					sqlCommand.Parameters.Add("@i1", SqlDbType.Int).Value = this.intervenant_radDropDownList1.SelectedItem.Tag;
					sqlCommand.Parameters.Add("@i2", SqlDbType.Int).Value = Outillage_utilisation_lancement.outil_radDropDownList2.SelectedItem.Tag;
					sqlCommand.Parameters.Add("@i3", SqlDbType.Date).Value = this.date_debut_radDateTimePicker2.Value.Date;
					sqlCommand.Parameters.Add("@i4", SqlDbType.VarChar).Value = this.heure_debut_radTimePicker1.Value.ToString().Substring(11, 5);
					sqlCommand.Parameters.Add("@i7", SqlDbType.VarChar).Value = this.commentaire_radTextBoxControl1.Text;
					sqlCommand.Parameters.Add("@i8", SqlDbType.Int).Value = 1;
					sqlCommand.Parameters.Add("@i9", SqlDbType.VarChar).Value = this.TextBox2.Text;
					sqlCommand.Connection.Open();
					sqlCommand.ExecuteNonQuery();
					sqlCommand.Connection.Close();
				}
				this.modifier_statut_1();
				this.remplissage_rad_intervenant();
				Outillage_utilisation_lancement.remplissage_tableau();
				Outillage_utilisation_lancement.remplissage_rad_outil();
				this.commentaire_radTextBoxControl1.Clear();
			}
		}

		// Token: 0x06000A47 RID: 2631 RVA: 0x001975F8 File Offset: 0x001957F8
		private void modifier_statut_1()
		{
			string value = Outillage_utilisation_lancement.outil_radDropDownList2.SelectedItem.Tag.ToString();
			string cmdText = "UPDATE outils SET statut=1    where id=@i20 ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				sqlCommand.Parameters.Add("@i20", SqlDbType.VarChar).Value = value;
				sqlCommand.Connection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlCommand.Connection.Close();
			}
		}

		// Token: 0x06000A48 RID: 2632 RVA: 0x0019768C File Offset: 0x0019588C
		public static void remplissage_tableau()
		{
			Outillage_utilisation_lancement.radGridView1.Rows.Clear();
			Outillage_utilisation_lancement.radGridView1.PageSize = 9;
			Outillage_utilisation_lancement.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			bd bd = new bd();
			DataTable dataTable = new DataTable();
			dataTable.Clear();
			string cmdText = "select  tab_lancement_affectation.id,outils.designation,intervenant.nom, date_debut,heure_debut,date_fin,heure_fin,commentaire, outils.id, n_ot from tab_lancement_affectation inner join outils on tab_lancement_affectation.outil = outils.id inner join intervenant on tab_lancement_affectation.id_intervenant = intervenant.id where encours=1;  ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn))
			{
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				sqlDataAdapter.Fill(dataTable);
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					Outillage_utilisation_lancement.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString().Substring(0, 10),
						dataTable.Rows[i].ItemArray[4].ToString(),
						dataTable.Rows[i].ItemArray[5].ToString(),
						dataTable.Rows[i].ItemArray[6].ToString(),
						dataTable.Rows[i].ItemArray[7].ToString(),
						Convert.ToString(dataTable.Rows[i].ItemArray[9]),
						Resources.icons8_check_64,
						dataTable.Rows[i].ItemArray[8].ToString()
					});
				}
				Outillage_utilisation_lancement.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
				Outillage_utilisation_lancement.radGridView1.MasterView.TableSearchRow.ResumeSearch();
			}
		}

		// Token: 0x04000D3B RID: 3387
		private bd b = new bd();

		// Token: 0x04000D3C RID: 3388
		private static DataTable dt_outil = new DataTable();

		// Token: 0x04000D3D RID: 3389
		public static string val = "";

		// Token: 0x04000D3E RID: 3390
		public static string val2 = "";
	}
}
