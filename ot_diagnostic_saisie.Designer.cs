namespace GMAO
{
	// Token: 0x020000B7 RID: 183
	public partial class ot_diagnostic_saisie : global::System.Windows.Forms.Form
	{
		// Token: 0x0600084C RID: 2124 RVA: 0x001656D4 File Offset: 0x001638D4
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600084D RID: 2125 RVA: 0x0016570C File Offset: 0x0016390C
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::GMAO.ot_diagnostic_saisie));
			this.radDiagram1 = new global::Telerik.WinControls.UI.RadDiagram();
			this.crystalTheme1 = new global::Telerik.WinControls.Themes.CrystalTheme();
			this.fluentTheme1 = new global::Telerik.WinControls.Themes.FluentTheme();
			this.radContextMenu1 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem1 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.breezeTheme1 = new global::Telerik.WinControls.Themes.BreezeTheme();
			this.arbre = new global::Telerik.WinControls.UI.RadTreeView();
			this.radTreeView1 = new global::Telerik.WinControls.UI.RadTreeView();
			this.label30 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.radContextMenu2 = new global::Telerik.WinControls.UI.RadContextMenu(this.components);
			this.radMenuItem2 = new global::Telerik.WinControls.UI.RadMenuItem();
			this.radDiagram1.BeginInit();
			this.arbre.BeginInit();
			this.radTreeView1.BeginInit();
			base.SuspendLayout();
			this.radDiagram1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radDiagram1.IsBackgroundSurfaceVisible = false;
			this.radDiagram1.IsDraggingEnabled = false;
			this.radDiagram1.IsEditable = false;
			this.radDiagram1.Location = new global::System.Drawing.Point(12, 8);
			this.radDiagram1.Name = "radDiagram1";
			this.radDiagram1.SelectionMode = 3;
			this.radDiagram1.SerializedXml = componentResourceManager.GetString("radDiagram1.SerializedXml");
			this.radDiagram1.Size = new global::System.Drawing.Size(551, 227);
			this.radDiagram1.TabIndex = 167;
			this.radDiagram1.Text = "radDiagram1";
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).Zoom = 1.0;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsBackgroundSurfaceVisible = false;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsEditable = false;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsDraggingEnabled = false;
			((global::Telerik.WinControls.UI.RadDiagramElement)this.radDiagram1.GetChildAt(0)).IsManipulationAdornerVisible = true;
			this.radContextMenu1.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem1
			});
			this.radMenuItem1.Name = "radMenuItem1";
			this.radMenuItem1.Text = "Choisir";
			this.radMenuItem1.UseCompatibleTextRendering = false;
			this.arbre.BackColor = global::System.Drawing.Color.White;
			this.arbre.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.arbre.EnableKineticScrolling = true;
			this.arbre.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.arbre.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.arbre.ItemHeight = 36;
			this.arbre.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.arbre.LineStyle = 0;
			this.arbre.Location = new global::System.Drawing.Point(590, 33);
			this.arbre.Name = "arbre";
			this.arbre.RadContextMenu = this.radContextMenu1;
			this.arbre.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.arbre.Size = new global::System.Drawing.Size(225, 202);
			this.arbre.SpacingBetweenNodes = -1;
			this.arbre.TabIndex = 175;
			this.arbre.ThemeName = "Breeze";
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.arbre.GetChildAt(0)).NodeSpacing = -1;
			this.radTreeView1.BackColor = global::System.Drawing.Color.White;
			this.radTreeView1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.radTreeView1.EnableKineticScrolling = true;
			this.radTreeView1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10.5f);
			this.radTreeView1.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.radTreeView1.ItemHeight = 36;
			this.radTreeView1.LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			this.radTreeView1.LineStyle = 0;
			this.radTreeView1.Location = new global::System.Drawing.Point(837, 33);
			this.radTreeView1.Name = "radTreeView1";
			this.radTreeView1.RadContextMenu = this.radContextMenu2;
			this.radTreeView1.RightToLeft = global::System.Windows.Forms.RightToLeft.No;
			this.radTreeView1.Size = new global::System.Drawing.Size(225, 202);
			this.radTreeView1.SpacingBetweenNodes = -1;
			this.radTreeView1.TabIndex = 176;
			this.radTreeView1.ThemeName = "Breeze";
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).ShowExpandCollapse = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).ItemHeight = 36;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).ShowLines = false;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).ShowRootLines = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).LineColor = global::System.Drawing.Color.FromArgb(209, 209, 209);
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).LineStyle = 0;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).TreeIndent = 20;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).FullRowSelect = true;
			((global::Telerik.WinControls.UI.RadTreeViewElement)this.radTreeView1.GetChildAt(0)).NodeSpacing = -1;
			this.label30.AutoSize = true;
			this.label30.BackColor = global::System.Drawing.Color.Transparent;
			this.label30.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label30.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label30.ForeColor = global::System.Drawing.Color.DimGray;
			this.label30.Location = new global::System.Drawing.Point(588, 18);
			this.label30.Name = "label30";
			this.label30.Size = new global::System.Drawing.Size(126, 12);
			this.label30.TabIndex = 251;
			this.label30.Text = "Liste des défaillances";
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.label1.Font = new global::System.Drawing.Font("Arial Rounded MT Bold", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.DimGray;
			this.label1.Location = new global::System.Drawing.Point(835, 18);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(90, 12);
			this.label1.TabIndex = 252;
			this.label1.Text = "Causes Choisie";
			this.radContextMenu2.Items.AddRange(new global::Telerik.WinControls.RadItem[]
			{
				this.radMenuItem2
			});
			this.radContextMenu2.ThemeName = "Breeze";
			this.radMenuItem2.Name = "radMenuItem2";
			this.radMenuItem2.Text = "Supprimer";
			this.radMenuItem2.UseCompatibleTextRendering = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.White;
			base.ClientSize = new global::System.Drawing.Size(1074, 243);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.label30);
			base.Controls.Add(this.radTreeView1);
			base.Controls.Add(this.arbre);
			base.Controls.Add(this.radDiagram1);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ot_diagnostic_saisie";
			base.ShowIcon = false;
			base.Load += new global::System.EventHandler(this.ot_diagnostic_saisie_Load);
			this.radDiagram1.EndInit();
			this.arbre.EndInit();
			this.radTreeView1.EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000B5B RID: 2907
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000B5C RID: 2908
		private global::Telerik.WinControls.UI.RadDiagram radDiagram1;

		// Token: 0x04000B5D RID: 2909
		private global::Telerik.WinControls.Themes.CrystalTheme crystalTheme1;

		// Token: 0x04000B5E RID: 2910
		private global::Telerik.WinControls.Themes.FluentTheme fluentTheme1;

		// Token: 0x04000B5F RID: 2911
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu1;

		// Token: 0x04000B60 RID: 2912
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem1;

		// Token: 0x04000B61 RID: 2913
		private global::Telerik.WinControls.Themes.BreezeTheme breezeTheme1;

		// Token: 0x04000B62 RID: 2914
		private global::Telerik.WinControls.UI.RadTreeView arbre;

		// Token: 0x04000B63 RID: 2915
		private global::Telerik.WinControls.UI.RadTreeView radTreeView1;

		// Token: 0x04000B64 RID: 2916
		internal global::System.Windows.Forms.Label label30;

		// Token: 0x04000B65 RID: 2917
		internal global::System.Windows.Forms.Label label1;

		// Token: 0x04000B66 RID: 2918
		private global::Telerik.WinControls.UI.RadContextMenu radContextMenu2;

		// Token: 0x04000B67 RID: 2919
		private global::Telerik.WinControls.UI.RadMenuItem radMenuItem2;
	}
}
