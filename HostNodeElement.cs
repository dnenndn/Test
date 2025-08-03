using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using GMAO.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200001D RID: 29
	public class HostNodeElement : TreeNodeElement
	{
		// Token: 0x060001A8 RID: 424 RVA: 0x00048B18 File Offset: 0x00046D18
		protected override void CreateChildElements()
		{
			base.CreateChildElements();
			this.lve = new LightVisualElement();
			this.lve.StretchHorizontally = false;
			this.lve.StretchVertically = false;
			this.lve.Shape = new RoundRectShape(this.sizeConst / 2);
			this.lve.SmoothingMode = SmoothingMode.AntiAlias;
			this.lve.ImageLayout = ImageLayout.Zoom;
			this.lve.ForeColor = Color.Black;
			this.lve.MinSize = new Size(this.sizeConst, this.sizeConst);
			this.lve.Image = Resources.icons8_fichier_lié_64;
			this.Children.Add(this.lve);
			this.lve.Visibility = 1;
			this.lve.Click += this.<CreateChildElements>g__button_Click|3_0;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00048BFC File Offset: 0x00046DFC
		public override void Synchronize()
		{
			base.Synchronize();
			RadTreeNode data = base.Data;
			bool flag = data.Tag != null;
			if (flag)
			{
				bool flag2 = Arbre_Equipement.list_id.Contains(Convert.ToInt32(data.Tag));
				if (flag2)
				{
					int index = 0;
					for (int i = 0; i < Arbre_Equipement.list_id.Count; i++)
					{
						bool flag3 = Arbre_Equipement.list_id[i] == Convert.ToInt32(data.Tag);
						if (flag3)
						{
							index = i;
						}
					}
					this.lve.Text = Arbre_Equipement.count_id[index].ToString();
					this.lve.Visibility = 0;
				}
				else
				{
					this.lve.Visibility = 1;
				}
			}
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x060001AA RID: 426 RVA: 0x00048CCC File Offset: 0x00046ECC
		protected override Type ThemeEffectiveType
		{
			get
			{
				return typeof(TreeNodeElement);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00048CFC File Offset: 0x00046EFC
		[CompilerGenerated]
		private void <CreateChildElements>g__button_Click|3_0(object sender, EventArgs e)
		{
			Arbre_Equipement.id_eqp = Convert.ToInt32(base.Data.Value.ToString());
			bd bd = new bd();
			string cmdText = "select code, designation from equipement where id=@i";
			SqlCommand sqlCommand = new SqlCommand(cmdText, bd.cnn);
			sqlCommand.Parameters.Add("@i", SqlDbType.Int).Value = Arbre_Equipement.id_eqp;
			SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
			DataTable dataTable = new DataTable();
			sqlDataAdapter.Fill(dataTable);
			bool flag = dataTable.Rows.Count != 0;
			if (flag)
			{
				Arbre_Equipement.label5.Text = Arbre_Equipement.id_eqp.ToString();
				Arbre_Equipement.label6.Text = dataTable.Rows[0].ItemArray[0].ToString();
				Arbre_Equipement.label7.Text = dataTable.Rows[0].ItemArray[1].ToString();
			}
			Arbre_Equipement.Panel10.Show();
			Arbre_Equipement.arbre.Size = new Size(424, Arbre_Equipement.arbre.Size.Height);
			Arbre_Equipement.guna2Button2.Show();
			Arbre_Equipement.button7_Click(sender, e);
		}

		// Token: 0x04000274 RID: 628
		private int result;

		// Token: 0x04000275 RID: 629
		private LightVisualElement lve;

		// Token: 0x04000276 RID: 630
		private int sizeConst = 26;
	}
}
