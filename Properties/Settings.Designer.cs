using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace GMAO.Properties
{
	// Token: 0x0200016E RID: 366
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.8.1.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600108C RID: 4236 RVA: 0x00297300 File Offset: 0x00295500
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600108D RID: 4237 RVA: 0x00297318 File Offset: 0x00295518
		// (set) Token: 0x0600108E RID: 4238 RVA: 0x0029733A File Offset: 0x0029553A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("50, 30")]
		public Size abc
		{
			get
			{
				return (Size)this["abc"];
			}
			set
			{
				this["abc"] = value;
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600108F RID: 4239 RVA: 0x00297350 File Offset: 0x00295550
		// (set) Token: 0x06001090 RID: 4240 RVA: 0x00297372 File Offset: 0x00295572
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("80, 80")]
		public Size add
		{
			get
			{
				return (Size)this["add"];
			}
			set
			{
				this["add"] = value;
			}
		}

		// Token: 0x04001456 RID: 5206
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
