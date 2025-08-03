using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Telerik.WinControls.Primitives;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x020000E5 RID: 229
	public partial class outillage_date_heure_fin : Form
	{
		// Token: 0x06000A00 RID: 2560 RVA: 0x001916CE File Offset: 0x0018F8CE
		public outillage_date_heure_fin()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x001916F1 File Offset: 0x0018F8F1
		private void outillage_date_heure_fin_Load(object sender, EventArgs e)
		{
			this.fin_radDateTimePicker2.Value = DateTime.Today;
			this.fin_radTimePicker1.Value = new DateTime?(DateTime.Now);
		}

		// Token: 0x06000A02 RID: 2562 RVA: 0x0019171B File Offset: 0x0018F91B
		private void radButton1_Click(object sender, EventArgs e)
		{
			this.cloturer_outil();
			this.modifier_statut_0();
			base.Hide();
		}

		// Token: 0x06000A03 RID: 2563 RVA: 0x00191734 File Offset: 0x0018F934
		private void cloturer_outil()
		{
			string cmdText = "UPDATE tab_lancement_affectation SET encours=0 ,date_fin=@i1,heure_fin=@i2   where id=@i20 ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				sqlCommand.Parameters.Add("@i20", SqlDbType.VarChar).Value = Outillage_utilisation_lancement.val;
				sqlCommand.Parameters.Add("@i1", SqlDbType.Date).Value = this.fin_radDateTimePicker2.Value.Date;
				sqlCommand.Parameters.Add("@i2", SqlDbType.VarChar).Value = this.fin_radTimePicker1.Value.ToString().Substring(11, 5);
				sqlCommand.Connection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlCommand.Connection.Close();
			}
		}

		// Token: 0x06000A04 RID: 2564 RVA: 0x00191820 File Offset: 0x0018FA20
		private void modifier_statut_0()
		{
			string cmdText = "UPDATE outils SET statut=0   where id=@i20 ";
			using (SqlCommand sqlCommand = new SqlCommand(cmdText, this.b.cnn))
			{
				sqlCommand.Parameters.Add("@i20", SqlDbType.VarChar).Value = Outillage_utilisation_lancement.val2;
				sqlCommand.Connection.Open();
				sqlCommand.ExecuteNonQuery();
				sqlCommand.Connection.Close();
			}
			Outillage_utilisation_lancement.remplissage_rad_outil();
			Outillage_utilisation_lancement.remplissage_tableau();
		}

		// Token: 0x04000CF9 RID: 3321
		private bd b = new bd();
	}
}
