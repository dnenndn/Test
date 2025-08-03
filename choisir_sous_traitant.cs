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
using Telerik.WinControls.UI.Data;

namespace GMAO
{
	// Token: 0x0200003A RID: 58
	public partial class choisir_sous_traitant : Form
	{
		// Token: 0x06000297 RID: 663 RVA: 0x0006E80D File Offset: 0x0006CA0D
		public choisir_sous_traitant()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000298 RID: 664 RVA: 0x0006E828 File Offset: 0x0006CA28
		private void choisir_sous_traitant_Load(object sender, EventArgs e)
		{
			choisir_sous_traitant.id_ds = dist_encours.id_ds;
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
			string cmdText = "select fournisseur.nom from fournisseur where type = @t";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@t", SqlDbType.VarChar).Value = "Sous_Traitant";
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				for (int i = 0; i < dataTable.Rows.Count; i++)
				{
					this.radDropDownList6.Items.Add(dataTable.Rows[i].ItemArray[0].ToString());
				}
			}
		}

		// Token: 0x06000299 RID: 665 RVA: 0x0006E904 File Offset: 0x0006CB04
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			choisir_sous_traitant.nom_fournisseur = this.radDropDownList6.Text;
			bon_dop_st bon_dop_st = new bon_dop_st();
			bon_dop_st.Show();
		}

		// Token: 0x0400037B RID: 891
		public static string id_ds;

		// Token: 0x0400037C RID: 892
		public static string nom_fournisseur;
	}
}
