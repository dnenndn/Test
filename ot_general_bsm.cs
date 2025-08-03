using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using GMAO.Properties;
using Guna.UI2.WinForms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000B9 RID: 185
	public partial class ot_general_bsm : Form
	{
		// Token: 0x0600085D RID: 2141 RVA: 0x00166FB0 File Offset: 0x001651B0
		public ot_general_bsm()
		{
			this.InitializeComponent();
			this.radGridView3.ViewCellFormatting += new CellFormattingEventHandler(ot_general_bsm.select_change);
			this.radGridView3.ViewRowFormatting += new RowFormattingEventHandler(ot_general_bsm.select_changee);
			this.radGridView3.CellClick += new GridViewCellEventHandler(this.RadGridView3_CellClick);
		}

		// Token: 0x0600085E RID: 2142 RVA: 0x0016701C File Offset: 0x0016521C
		private void RadGridView3_CellClick(object sender, GridViewCellEventArgs e)
		{
			bool flag = e.RowIndex > -1;
			if (flag)
			{
				bool flag2 = e.ColumnIndex == 2;
				if (flag2)
				{
					DialogResult dialogResult = MessageBox.Show("Vous voulez supprimer ?", "VALIDATION", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					bool flag3 = dialogResult == DialogResult.Yes;
					if (flag3)
					{
						bd bd = new bd();
						string cmdText = "update bsm set li_ot = @vide where id = @i";
						SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
						sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = this.radGridView3.Rows[e.RowIndex].Cells[0].Value;
						sqlCommand.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
						bd.ouverture_bd(bd.cnn);
						sqlCommand.ExecuteNonQuery();
						bd.cnn.Close();
						this.remplissage_tableau();
					}
				}
			}
		}

		// Token: 0x0600085F RID: 2143 RVA: 0x00167114 File Offset: 0x00165314
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

		// Token: 0x06000860 RID: 2144 RVA: 0x00167198 File Offset: 0x00165398
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

		// Token: 0x06000861 RID: 2145 RVA: 0x0016729B File Offset: 0x0016549B
		private void ot_general_bsm_Load(object sender, EventArgs e)
		{
			this.remplissage_tableau();
		}

		// Token: 0x06000862 RID: 2146 RVA: 0x001672A8 File Offset: 0x001654A8
		private void remplissage_tableau()
		{
			bd bd = new bd();
			this.radGridView3.Rows.Clear();
			string cmdText = "select id, n_ot from bsm where li_ot = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = ot_liste.id_ot_tr;
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
						dataTable.Rows[i].ItemArray[0].ToString(),
						dataTable.Rows[i].ItemArray[1].ToString(),
						Resources.icons8_supprimer_pour_toujours_100__4_
					});
				}
			}
		}

		// Token: 0x06000863 RID: 2147 RVA: 0x001673AC File Offset: 0x001655AC
		private void radButton1_Click(object sender, EventArgs e)
		{
			bool flag = this.TextBox1.Text != "";
			if (flag)
			{
				bd bd = new bd();
				string cmdText = "select id from bsm where n_ot = @i";
				SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
				sqlCommand.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
				SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
				DataTable dataTable = new DataTable();
				sqlDataAdapter.Fill(dataTable);
				bool flag2 = dataTable.Rows.Count != 0;
				if (flag2)
				{
					string cmdText2 = "select ordre_travail.n_ot from bsm inner join ordre_travail on bsm.li_ot = ordre_travail.id where bsm.n_ot = @i and li_ot <> @vide";
					SqlCommand sqlCommand2 = new SqlCommand(cmdText2, bd.cnn);
					sqlCommand2.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
					sqlCommand2.Parameters.Add("@vide", SqlDbType.VarChar).Value = "";
					SqlDataAdapter sqlDataAdapter2 = new SqlDataAdapter(sqlCommand2);
					DataTable dataTable2 = new DataTable();
					sqlDataAdapter2.Fill(dataTable2);
					bool flag3 = dataTable2.Rows.Count == 0;
					if (flag3)
					{
						string cmdText3 = "update bsm set li_ot = @h where n_ot = @i";
						SqlCommand sqlCommand3 = new SqlCommand(cmdText3, bd.cnn);
						sqlCommand3.Parameters.Add("@h", SqlDbType.VarChar).Value = ot_liste.id_ot_tr;
						sqlCommand3.Parameters.Add("@i", SqlDbType.VarChar).Value = this.TextBox1.Text;
						bd.ouverture_bd(bd.cnn);
						sqlCommand3.ExecuteNonQuery();
						bd.cnn.Close();
						MessageBox.Show("Ajout avec succés");
						this.remplissage_tableau();
					}
					else
					{
						MessageBox.Show("Erreur :  BSM déja ajouté dans l'OT n° " + dataTable2.Rows[0].ItemArray[0].ToString(), "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
				}
				else
				{
					MessageBox.Show("Erreur :BSM Introuvable", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
			else
			{
				MessageBox.Show("Erreur :Champs obligatoire est vide", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}
	}
}
