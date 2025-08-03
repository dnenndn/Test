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
	// Token: 0x02000039 RID: 57
	public partial class choisir_fournisseur : Form
	{
		// Token: 0x06000292 RID: 658 RVA: 0x0006E1C7 File Offset: 0x0006C3C7
		public choisir_fournisseur()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000293 RID: 659 RVA: 0x0006E1E0 File Offset: 0x0006C3E0
		private void choisir_fournisseur_Load(object sender, EventArgs e)
		{
			choisir_fournisseur.id_dop = liste_dop.id_dop;
			bd bd = new bd();
			this.radDropDownList6.Items.Clear();
			string cmdText = "select fournisseur.nom from dop_fournisseur inner join fournisseur on dop_fournisseur.id_fournisseur = fournisseur.id where id_dop = @i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = liste_dop.id_dop;
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

		// Token: 0x06000294 RID: 660 RVA: 0x0006E2BC File Offset: 0x0006C4BC
		private void radDropDownList6_SelectedIndexChanged(object sender, PositionChangedEventArgs e)
		{
			bool flag = this.radDropDownList6.Text != "";
			if (flag)
			{
				choisir_fournisseur.nom_fournisseur = this.radDropDownList6.Text;
				bon_dop bon_dop = new bon_dop();
				bon_dop.Show();
			}
		}

		// Token: 0x04000375 RID: 885
		public static string id_dop;

		// Token: 0x04000376 RID: 886
		public static string nom_fournisseur;
	}
}
