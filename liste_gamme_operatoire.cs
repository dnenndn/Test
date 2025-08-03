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
using Telerik.WinControls.UI.Localization;

namespace GMAO
{
	// Token: 0x0200008D RID: 141
	public partial class liste_gamme_operatoire : Form
	{
		// Token: 0x06000693 RID: 1683 RVA: 0x0011F120 File Offset: 0x0011D320
		public liste_gamme_operatoire()
		{
			this.InitializeComponent();
			LocalizationProvider<RadGridLocalizationProvider>.CurrentProvider = new test_rad();
			liste_gamme_operatoire.radGridView1.ViewCellFormatting += new CellFormattingEventHandler(liste_gamme_operatoire.select_change);
			liste_gamme_operatoire.radGridView1.ViewRowFormatting += new RowFormattingEventHandler(liste_gamme_operatoire.select_changee);
			liste_gamme_operatoire.radGridView1.CellClick += new GridViewCellEventHandler(this.RadGridView1_CellClick);
			liste_gamme_operatoire.remplissage_tableau(0);
		}

		// Token: 0x06000694 RID: 1684 RVA: 0x0011F19C File Offset: 0x0011D39C
		private void RadGridView1_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1 & e.ColumnIndex == 5;
			if (flag)
			{
				this.panel1.Show();
				liste_gamme_operatoire.radGridView1.Size = new Size(1077, 190);
				liste_gamme_operatoire.row_act = e.RowIndex;
				liste_gamme_operatoire.id_gamme = Convert.ToInt32(liste_gamme_operatoire.radGridView1.Rows[e.RowIndex].Cells[0].Value);
				bool flag2 = this.button1.BackColor == Color.White;
				if (flag2)
				{
					this.button1_Click(sender, e);
				}
				bool flag3 = this.button2.BackColor == Color.White;
				if (flag3)
				{
					this.button2_Click(sender, e);
				}
				bool flag4 = this.button3.BackColor == Color.White;
				if (flag4)
				{
					this.button3_Click(sender, e);
				}
				bool flag5 = this.button4.BackColor == Color.White;
				if (flag5)
				{
					this.button4_Click(sender, e);
				}
			}
			bool flag6 = e.RowIndex > -1 & e.ColumnIndex == 6;
			if (flag6)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag7 = dialogResult == DialogResult.Yes;
				if (flag7)
				{
					bd bd = new bd();
					liste_gamme_operatoire.row_act = e.RowIndex;
					string cmdText = "update gamme_operatoire set deleted = @d where id = @i";
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_gamme_operatoire.radGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
					sqlCommand.Parameters.Add("@d", SqlDbType.Int).Value = 1;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					liste_gamme_operatoire.remplissage_tableau(3);
				}
			}
		}

		// Token: 0x06000695 RID: 1685 RVA: 0x0011F3AE File Offset: 0x0011D5AE
		private void pictureBox3_Click(object sender, EventArgs e)
		{
			this.panel1.Visible = false;
			liste_gamme_operatoire.radGridView1.Size = new Size(1077, 481);
		}

		// Token: 0x06000696 RID: 1686 RVA: 0x0011F3D8 File Offset: 0x0011D5D8
		private void liste_gamme_operatoire_Load(object sender, EventArgs e)
		{
			this.pictureBox3_Click(sender, e);
		}

		// Token: 0x06000697 RID: 1687 RVA: 0x0011F3E4 File Offset: 0x0011D5E4
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

		// Token: 0x06000698 RID: 1688 RVA: 0x0011F468 File Offset: 0x0011D668
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

		// Token: 0x06000699 RID: 1689 RVA: 0x0011F56C File Offset: 0x0011D76C
		public static void remplissage_tableau(int o)
		{
			liste_gamme_operatoire.radGridView1.Rows.Clear();
			liste_gamme_operatoire.radGridView1.AllowDragToGroup = false;
			liste_gamme_operatoire.radGridView1.AllowAddNewRow = false;
			liste_gamme_operatoire.radGridView1.EnablePaging = true;
			liste_gamme_operatoire.radGridView1.PageSize = 14;
			liste_gamme_operatoire.radGridView1.EnableSorting = true;
			liste_gamme_operatoire.radGridView1.MasterView.TableSearchRow.SuspendSearch();
			string cmdText = "select gamme_operatoire.id, plan_maintenance.designation, gamme_operatoire.code, gamme_operatoire.designation, operation from gamme_operatoire inner join plan_maintenance on gamme_operatoire.id_plan = plan_maintenance.id where gamme_operatoire.deleted = @d";
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
					liste_gamme_operatoire.radGridView1.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						dataTable.Rows[i].ItemArray[3].ToString(),
						dataTable.Rows[i].ItemArray[4].ToString(),
						Resources.icons8_approuver_et_mettre_à_jour_96__4_,
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
			bool flag2 = liste_gamme_operatoire.radGridView1.Rows.Count != 0;
			if (flag2)
			{
				bool flag3 = o == 0;
				if (flag3)
				{
					liste_gamme_operatoire.radGridView1.MasterTemplate.MoveToFirstPage();
					liste_gamme_operatoire.radGridView1.Rows[0].IsCurrent = true;
				}
				bool flag4 = o == 1;
				if (flag4)
				{
					liste_gamme_operatoire.radGridView1.MasterTemplate.MoveToLastPage();
				}
				bool flag5 = o == 2;
				if (flag5)
				{
					liste_gamme_operatoire.radGridView1.Rows[liste_gamme_operatoire.row_act].IsCurrent = true;
				}
				bool flag6 = o == 3;
				if (flag6)
				{
					bool flag7 = liste_gamme_operatoire.row_act != 0;
					if (flag7)
					{
						liste_gamme_operatoire.radGridView1.Rows[liste_gamme_operatoire.row_act - 1].IsCurrent = true;
					}
					else
					{
						liste_gamme_operatoire.radGridView1.MasterTemplate.MoveToFirstPage();
						liste_gamme_operatoire.radGridView1.Rows[0].IsCurrent = true;
					}
				}
			}
			liste_gamme_operatoire.radGridView1.MasterView.TableSearchRow.ShowCloseButton = false;
			liste_gamme_operatoire.radGridView1.Templates.Clear();
			liste_gamme_operatoire.radGridView1.MasterView.TableSearchRow.ResumeSearch();
		}

		// Token: 0x0600069A RID: 1690 RVA: 0x0011F858 File Offset: 0x0011DA58
		private void couleur_button(Button b)
		{
			foreach (object obj in this.panel4.Controls)
			{
				Control control = (Control)obj;
				bool flag = control.Name.Contains("button");
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

		// Token: 0x0600069B RID: 1691 RVA: 0x0011F918 File Offset: 0x0011DB18
		private void button1_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button1);
			this.panel2.Controls.Clear();
			gamme_general gamme_general = new gamme_general();
			gamme_general.TopLevel = false;
			this.panel2.Controls.Add(gamme_general);
			gamme_general.Show();
		}

		// Token: 0x0600069C RID: 1692 RVA: 0x0011F96C File Offset: 0x0011DB6C
		private void button2_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button2);
			this.panel2.Controls.Clear();
			gamme_pdr gamme_pdr = new gamme_pdr();
			gamme_pdr.TopLevel = false;
			this.panel2.Controls.Add(gamme_pdr);
			gamme_pdr.Show();
		}

		// Token: 0x0600069D RID: 1693 RVA: 0x0011F9C0 File Offset: 0x0011DBC0
		private void button3_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button3);
			this.panel2.Controls.Clear();
			gamme_outillage gamme_outillage = new gamme_outillage();
			gamme_outillage.TopLevel = false;
			this.panel2.Controls.Add(gamme_outillage);
			gamme_outillage.Show();
		}

		// Token: 0x0600069E RID: 1694 RVA: 0x0011FA14 File Offset: 0x0011DC14
		private void button4_Click(object sender, EventArgs e)
		{
			this.couleur_button(this.button4);
			this.panel2.Controls.Clear();
			gamme_fonction gamme_fonction = new gamme_fonction();
			gamme_fonction.TopLevel = false;
			this.panel2.Controls.Add(gamme_fonction);
			gamme_fonction.Show();
		}

		// Token: 0x040008CA RID: 2250
		private static int row_act;

		// Token: 0x040008CB RID: 2251
		public static int id_gamme;
	}
}
