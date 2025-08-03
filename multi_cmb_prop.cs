using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x0200014B RID: 331
	[ToolboxItem(false)]
	internal class multi_cmb_prop : Component
	{
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000ED3 RID: 3795 RVA: 0x0023F5DC File Offset: 0x0023D7DC
		public RadAutoCompleteBoxElement AutoCompleteBoxElement
		{
			get
			{
				return this.autoCompleteBoxElement;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0023F5F4 File Offset: 0x0023D7F4
		public RadTokenizedTextItemCollection Items
		{
			get
			{
				return this.autoCompleteBoxElement.Items;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x06000ED5 RID: 3797 RVA: 0x0023F614 File Offset: 0x0023D814
		// (set) Token: 0x06000ED6 RID: 3798 RVA: 0x0023F62C File Offset: 0x0023D82C
		public RadMultiColumnComboBox AssociatedRadMultiColumnComboBox
		{
			get
			{
				return this.associatedRadMultiColumnComboBox;
			}
			set
			{
				this.SetAssociatedRadMultiColumnComboBox(value);
			}
		}

		// Token: 0x06000ED7 RID: 3799 RVA: 0x0023F638 File Offset: 0x0023D838
		private void SetAssociatedRadMultiColumnComboBox(RadMultiColumnComboBox radMultiColumnComboBox)
		{
			bool flag = radMultiColumnComboBox == null && this.associatedRadMultiColumnComboBox != null;
			if (flag)
			{
				this.SetAssociatedRadMultiColumnComboBoxCoreToNull();
			}
			this.SetAssociatedRadMultiColumnComboBoxCore(radMultiColumnComboBox);
		}

		// Token: 0x06000ED8 RID: 3800 RVA: 0x0023F66C File Offset: 0x0023D86C
		private void SetAssociatedRadMultiColumnComboBoxCoreToNull()
		{
			this.associatedRadMultiColumnComboBox.HandleCreated -= this.associatedRadMultiColumnComboBox_HandleCreated;
			this.associatedRadMultiColumnComboBox.DataBindingComplete -= new GridViewBindingCompleteEventHandler(this.associatedRadMultiColumnComboBox_DataBindingComplete);
			this.associatedRadMultiColumnComboBox.EditorControl.ViewCellFormatting -= new CellFormattingEventHandler(this.EditorControl_ViewCellFormatting);
			this.associatedRadMultiColumnComboBox.DropDownClosing -= new RadPopupClosingEventHandler(this.radMultiColumnCombobox1_DropDownClosing);
			this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.TextBoxElement.Visibility = 0;
			this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.Children[2].Children.Remove(this.autoCompleteBoxElement);
			this.autoCompleteBoxElement.MaxSize = new Size(0, 0);
			this.autoCompleteBoxElement.AutoCompleteDataSource = null;
			this.associatedRadMultiColumnComboBox.Size = this.originalSize;
			foreach (GridViewRowInfo gridViewRowInfo in this.associatedRadMultiColumnComboBox.EditorControl.Rows)
			{
				gridViewRowInfo.Tag = null;
			}
			this.autoCompleteBoxElement.CreateTextBlock -= new CreateTextBlockEventHandler(this.autoCompleteBoxElement_CreateTextBlock);
			this.autoCompleteBoxElement.TokenValidating -= new TokenValidatingEventHandler(this.autoCompleteBoxElement_TokenValidating);
			this.autoCompleteBoxElement.Text = this.associatedRadMultiColumnComboBox.Text;
			this.autoCompleteBoxElement.KeyDown -= this.autoCompleteBoxElement_KeyDown;
			this.associatedRadMultiColumnComboBox = null;
			this.rows.Clear();
		}

		// Token: 0x06000ED9 RID: 3801 RVA: 0x0023F810 File Offset: 0x0023DA10
		private void SetAssociatedRadMultiColumnComboBoxCore(RadMultiColumnComboBox radMultiColumnComboBox)
		{
			bool flag = radMultiColumnComboBox == null;
			if (!flag)
			{
				this.originalSize = radMultiColumnComboBox.Size;
				this.associatedRadMultiColumnComboBox = radMultiColumnComboBox;
				this.associatedRadMultiColumnComboBox.HandleCreated += this.associatedRadMultiColumnComboBox_HandleCreated;
				this.associatedRadMultiColumnComboBox.DataBindingComplete += new GridViewBindingCompleteEventHandler(this.associatedRadMultiColumnComboBox_DataBindingComplete);
				this.associatedRadMultiColumnComboBox.EditorControl.ViewCellFormatting += new CellFormattingEventHandler(this.EditorControl_ViewCellFormatting);
				this.associatedRadMultiColumnComboBox.DropDownClosing += new RadPopupClosingEventHandler(this.radMultiColumnCombobox1_DropDownClosing);
				this.autoCompleteBoxElement = new RadAutoCompleteBoxElement();
				this.autoCompleteBoxElement.MaxSize = new Size(256, 0);
				this.autoCompleteBoxElement.DrawBorder = false;
				this.autoCompleteBoxElement.KeyDown += this.autoCompleteBoxElement_KeyDown;
				this.autoCompleteBoxElement.NullText = this.associatedRadMultiColumnComboBox.NullText;
				this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.ArrowButton.ZIndex = 1;
				this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.TextBoxElement.Visibility = 2;
				this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.ComboboxLayoutPanel.Content = this.autoCompleteBoxElement;
				this.autoCompleteBoxElement.AutoCompleteDataSource = new List<string>(this.GetAutoCompleteItems());
				this.autoCompleteBoxElement.Margin = new Padding(0);
				this.autoCompleteBoxElement.NullTextViewElement.Padding = new Padding(2, 6, 2, 6);
				this.autoCompleteBoxElement.CreateTextBlock += new CreateTextBlockEventHandler(this.autoCompleteBoxElement_CreateTextBlock);
				this.autoCompleteBoxElement.TokenValidating += new TokenValidatingEventHandler(this.autoCompleteBoxElement_TokenValidating);
				this.PopulateItems();
			}
		}

		// Token: 0x06000EDA RID: 3802 RVA: 0x0023F9C8 File Offset: 0x0023DBC8
		private void autoCompleteBoxElement_KeyDown(object sender, KeyEventArgs e)
		{
			bool flag = e.KeyCode == Keys.F4;
			if (flag)
			{
				this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.ShowPopup();
			}
			bool flag2 = e.KeyCode == Keys.Escape;
			if (flag2)
			{
				this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.ClosePopup(4);
			}
		}

		// Token: 0x06000EDB RID: 3803 RVA: 0x0023FA19 File Offset: 0x0023DC19
		private void associatedRadMultiColumnComboBox_DataBindingComplete(object sender, GridViewBindingCompleteEventArgs e)
		{
			this.autoCompleteBoxElement.AutoCompleteDataSource = new List<string>(this.GetAutoCompleteItems());
		}

		// Token: 0x06000EDC RID: 3804 RVA: 0x0023FA33 File Offset: 0x0023DC33
		private void associatedRadMultiColumnComboBox_HandleCreated(object sender, EventArgs e)
		{
			this.autoCompleteBoxElement.AutoCompleteDataSource = new List<string>(this.GetAutoCompleteItems());
		}

		// Token: 0x06000EDD RID: 3805 RVA: 0x0023FA50 File Offset: 0x0023DC50
		private void PopulateItems()
		{
			foreach (GridViewRowInfo gridViewRowInfo in this.associatedRadMultiColumnComboBox.EditorControl.Rows)
			{
				string key = gridViewRowInfo.Cells[this.associatedRadMultiColumnComboBox.DisplayMember].Value.ToString().Trim();
				bool flag = !this.rows.ContainsKey(key);
				if (flag)
				{
					this.rows.Add(key, gridViewRowInfo);
				}
			}
		}

		// Token: 0x06000EDE RID: 3806 RVA: 0x0023FAF0 File Offset: 0x0023DCF0
		private IEnumerable<string> GetAutoCompleteItems()
		{
			foreach (GridViewRowInfo row in this.associatedRadMultiColumnComboBox.EditorControl.Rows)
			{
				string value = row.Cells[this.associatedRadMultiColumnComboBox.DisplayMember].Value.ToString().Trim();
				bool flag = !this.rows.ContainsKey(value);
				if (flag)
				{
					this.rows.Add(value, row);
				}
				yield return value;
				value = null;
				row = null;
			}
			IEnumerator<GridViewRowInfo> enumerator = null;
			yield break;
			yield break;
		}

		// Token: 0x06000EDF RID: 3807 RVA: 0x0023FB00 File Offset: 0x0023DD00
		private void radMultiColumnCombobox1_DropDownClosing(object sender, RadPopupClosingEventArgs args)
		{
			args.Cancel = (args.CloseReason == 1 && this.associatedRadMultiColumnComboBox.EditorControl.ElementTree.GetElementAtPoint(this.associatedRadMultiColumnComboBox.EditorControl.PointToClient(Cursor.Position)) != null);
			this.SyncCollection();
		}

		// Token: 0x06000EE0 RID: 3808 RVA: 0x0023FB58 File Offset: 0x0023DD58
		private void EditorControl_ViewCellFormatting(object sender, CellFormattingEventArgs e)
		{
			bool flag = e.ColumnIndex != -1 || e.CellElement.RowIndex == -1;
			if (!flag)
			{
				bool flag2 = e.CellElement.Children.Count == 1;
				if (flag2)
				{
					RadCheckBoxElement radCheckBoxElement = new RadCheckBoxElement();
					radCheckBoxElement.Padding = new Padding(0, 3, 1, 0);
					radCheckBoxElement.Alignment = ContentAlignment.MiddleCenter;
					radCheckBoxElement.NotifyParentOnMouseInput = false;
					e.CellElement.Children.Add(radCheckBoxElement);
				}
				RadCheckBoxElement radCheckBoxElement2 = e.CellElement.FindDescendant<RadCheckBoxElement>();
				radCheckBoxElement2.CheckStateChanged -= this.checkBox_CheckStateChanged;
				radCheckBoxElement2.IsChecked = (e.Row.Tag != null && e.Row.Tag.ToString() == bool.TrueString);
				radCheckBoxElement2.CheckStateChanged += this.checkBox_CheckStateChanged;
			}
		}

		// Token: 0x06000EE1 RID: 3809 RVA: 0x0023FC40 File Offset: 0x0023DE40
		private void SyncCollection()
		{
			this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.TextBoxElement.SuspendPropertyNotifications();
			this.associatedRadMultiColumnComboBox.Text = string.Empty;
			foreach (GridViewRowInfo gridViewRowInfo in this.associatedRadMultiColumnComboBox.EditorControl.Rows)
			{
				bool flag = gridViewRowInfo.Tag != null && gridViewRowInfo.Tag.ToString() == bool.TrueString;
				if (flag)
				{
					RadMultiColumnComboBox radMultiColumnComboBox = this.associatedRadMultiColumnComboBox;
					string text = radMultiColumnComboBox.Text;
					object value = gridViewRowInfo.Cells[this.associatedRadMultiColumnComboBox.DisplayMember].Value;
					radMultiColumnComboBox.Text = text + ((value != null) ? value.ToString() : null) + "; ";
				}
			}
			this.associatedRadMultiColumnComboBox.MultiColumnComboBoxElement.TextBoxElement.ResumePropertyNotifications();
			this.autoCompleteBoxElement.CreateTextBlock -= new CreateTextBlockEventHandler(this.autoCompleteBoxElement_CreateTextBlock);
			this.autoCompleteBoxElement.TokenValidating -= new TokenValidatingEventHandler(this.autoCompleteBoxElement_TokenValidating);
			this.autoCompleteBoxElement.Text = this.associatedRadMultiColumnComboBox.Text;
			this.autoCompleteBoxElement.TokenValidating += new TokenValidatingEventHandler(this.autoCompleteBoxElement_TokenValidating);
			this.autoCompleteBoxElement.CreateTextBlock += new CreateTextBlockEventHandler(this.autoCompleteBoxElement_CreateTextBlock);
		}

		// Token: 0x06000EE2 RID: 3810 RVA: 0x0023FDB4 File Offset: 0x0023DFB4
		private void autoCompleteBoxElement_TokenValidating(object sender, TokenValidatingEventArgs e)
		{
			bool flag = this.rows.ContainsKey(e.Text);
			if (flag)
			{
				object tag = this.rows[e.Text].Tag;
				bool flag2 = (((tag != null) ? tag.ToString() : null) ?? "") == bool.TrueString;
				if (flag2)
				{
					e.IsValidToken = false;
				}
			}
			else
			{
				e.IsValidToken = false;
			}
		}

		// Token: 0x06000EE3 RID: 3811 RVA: 0x0023FE28 File Offset: 0x0023E028
		private void autoCompleteBoxElement_CreateTextBlock(object sender, CreateTextBlockEventArgs e)
		{
			bool flag = this.rows.ContainsKey(e.Text) && e.TextBlock is TokenizedTextBlockElement;
			if (flag)
			{
				this.rows[e.Text].Tag = bool.TrueString;
				this.rows[e.Text].InvalidateRow();
			}
		}

		// Token: 0x06000EE4 RID: 3812 RVA: 0x0023FE94 File Offset: 0x0023E094
		public void UpdateItems(object sender, NotifyCollectionChangedEventArgs e)
		{
			bool flag = e.Action == 1;
			if (flag)
			{
				this.PopulateItems();
				foreach (object obj in e.NewItems)
				{
					RadTokenizedTextItem radTokenizedTextItem = (RadTokenizedTextItem)obj;
					bool flag2 = this.rows.ContainsKey(radTokenizedTextItem.Text.Trim());
					if (flag2)
					{
						string key = radTokenizedTextItem.Text.Trim();
						this.rows[key].Tag = bool.FalseString;
						this.rows[key].InvalidateRow();
					}
				}
			}
		}

		// Token: 0x06000EE5 RID: 3813 RVA: 0x0023FF5C File Offset: 0x0023E15C
		private void checkBox_CheckStateChanged(object sender, EventArgs e)
		{
			RadCheckBoxElement radCheckBoxElement = sender as RadCheckBoxElement;
			GridRowElement gridRowElement = radCheckBoxElement.FindAncestor<GridRowElement>();
			gridRowElement.RowInfo.Tag = radCheckBoxElement.IsChecked.ToString();
		}

		// Token: 0x040012A5 RID: 4773
		private RadAutoCompleteBoxElement autoCompleteBoxElement;

		// Token: 0x040012A6 RID: 4774
		private Dictionary<string, GridViewRowInfo> rows = new Dictionary<string, GridViewRowInfo>();

		// Token: 0x040012A7 RID: 4775
		private RadMultiColumnComboBox associatedRadMultiColumnComboBox;

		// Token: 0x040012A8 RID: 4776
		private Size originalSize = Size.Empty;
	}
}
