using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000B0 RID: 176
	public partial class ot_bt_projet : Form
	{
		// Token: 0x060007F2 RID: 2034 RVA: 0x00159B64 File Offset: 0x00157D64
		public ot_bt_projet()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_bt_projet.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_bt_projet.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.action_tableau);
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00159BCF File Offset: 0x00157DCF
		private void ot_bt_projet_Load(object sender, EventArgs e)
		{
			this.radDateTimePicker1.Value = DateTime.Today;
			this.radDateTimePicker2.Value = DateTime.Today;
			this.select_tableau();
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00159BFC File Offset: 0x00157DFC
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

		// Token: 0x060007F5 RID: 2037 RVA: 0x00159C80 File Offset: 0x00157E80
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

		// Token: 0x060007F6 RID: 2038 RVA: 0x00159D84 File Offset: 0x00157F84
		private void action_tableau(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex >= 0 && e.ColumnIndex == 6;
			if (flag)
			{
				DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "ALERTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				bool flag2 = dialogResult == DialogResult.Yes;
				if (flag2)
				{
					bd bd = new bd();
					string cmdText = "delete ot_projet where id = @i";
					int num = Convert.ToInt32(this.radGridView3.Rows[e.RowIndex].Cells[0].Value);
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = num;
					bd.ouverture_bd(bd.cnn);
					sqlCommand.ExecuteNonQuery();
					bd.cnn.Close();
					this.select_tableau();
				}
			}
		}

		// Token: 0x060007F7 RID: 2039 RVA: 0x00159E60 File Offset: 0x00158060
		private void select_tableau()
		{
			this.radGridView3.Rows.Clear();
			bd bd = new bd();
			string cmdText = "select id, description, sous_traitant, debut, fin, cout from ot_projet where id_ot = @i";
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
					this.radGridView3.Rows.Add(new object[]
					{
						dataTable.Rows[i].ItemArray[1].ToString(),
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[2].ToString(),
						fonction.Mid(dataTable.Rows[i].ItemArray[3].ToString(), 1, 10),
						fonction.Mid(dataTable.Rows[i].ItemArray[4].ToString(), 1, 10),
						Convert.ToDouble(dataTable.Rows[i].ItemArray[5]).ToString("0.000"),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x060007F8 RID: 2040 RVA: 0x0015A000 File Offset: 0x00158200
		private void radButton1_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.DeleteSpace(this.TextBox1.Text) != "";
			if (flag)
			{
				bool flag2 = fonction.is_reel(this.guna2TextBox2.Text);
				if (flag2)
				{
					bool flag3 = Convert.ToDouble(this.guna2TextBox2.Text) > 0.0;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "insert into ot_projet (id_ot, description, sous_traitant, debut, fin, cout) values (@v1, @v2, @v3, @v4, @v5, @v6)";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@v1", SqlDbType.Int).Value = ot_liste.id_ot_tr;
						sqlCommand.Parameters.Add("@v2", SqlDbType.VarChar).Value = this.TextBox1.Text;
						sqlCommand.Parameters.Add("@v3", SqlDbType.VarChar).Value = this.guna2TextBox1.Text;
						sqlCommand.Parameters.Add("@v4", SqlDbType.Date).Value = this.radDateTimePicker1.Value;
						sqlCommand.Parameters.Add("@v5", SqlDbType.Date).Value = this.radDateTimePicker2.Value;
						sqlCommand.Parameters.Add("@v6", SqlDbType.Real).Value = this.guna2TextBox2.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Enregistrement avec succés");
						this.TextBox1.Clear();
						this.guna2TextBox1.Clear();
						this.guna2TextBox2.Clear();
						this.select_tableau();
					}
					else
					{
						MessageBox.Show("Erreur :Coût doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :Coût doit être un réel strictement positif", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Choisir la description du projet", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
