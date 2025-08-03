using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Guna.UI2.WinForms;

namespace GMAO
{
	// Token: 0x020000ED RID: 237
	public partial class page_codification_equipement : Form
	{
		// Token: 0x06000A4C RID: 2636 RVA: 0x001994CC File Offset: 0x001976CC
		public page_codification_equipement()
		{
			this.InitializeComponent();
			this.ProgressBar1.Hide();
		}

		// Token: 0x06000A4D RID: 2637 RVA: 0x001994F0 File Offset: 0x001976F0
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			fonction fonction = new fonction();
			bool flag = fonction.isnumeric(this.TextBox1.Text);
			if (flag)
			{
				List<int> list = new List<int>();
				int id_prn = Convert.ToInt32(this.TextBox1.Text);
				list.Clear();
				fonction.telecharger_tous_id_enfant(id_prn, list);
				string text = this.TextBox2.Text;
				this.ProgressBar1.Value = 0;
				this.ProgressBar1.MaximumValue = list.Count;
				this.ProgressBar1.Show();
				bd bd = new bd();
				bd.ouverture_bd(bd.cnn);
				for (int i = 0; i < list.Count; i++)
				{
					string cmdText = "update equipement set code = @c where id = @i";
					string value = this.incrementation(i + 1, text);
					SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
					sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = list[i];
					sqlCommand.Parameters.Add("@c", SqlDbType.VarChar).Value = value;
					sqlCommand.ExecuteNonQuery();
					this.ProgressBar1.Value = this.ProgressBar1.Value + 1;
				}
				bd.cnn.Close();
				MessageBox.Show("Succés");
				this.TextBox1.Clear();
				this.TextBox2.Clear();
				this.ProgressBar1.Hide();
			}
			else
			{
				MessageBox.Show("Erreur");
			}
		}

		// Token: 0x06000A4E RID: 2638 RVA: 0x00199688 File Offset: 0x00197888
		private string incrementation(int a, string b)
		{
			string str = "";
			bool flag = a < 10;
			if (flag)
			{
				str = "000" + a.ToString();
			}
			bool flag2 = a < 100 & a >= 10;
			if (flag2)
			{
				str = "00" + a.ToString();
			}
			bool flag3 = a < 1000 & a >= 100;
			if (flag3)
			{
				str = "0" + a.ToString();
			}
			bool flag4 = a >= 1000;
			if (flag4)
			{
				str = (a.ToString() ?? "");
			}
			return b + "-" + str;
		}
	}
}
