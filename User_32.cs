using System;
using System.Runtime.InteropServices;

namespace GMAO
{
	// Token: 0x0200006E RID: 110
	internal class User_32
	{
		// Token: 0x06000536 RID: 1334
		[DllImport("user32.dll")]
		public static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE1 devMode);

		// Token: 0x06000537 RID: 1335
		[DllImport("user32.dll")]
		public static extern int ChangeDisplaySettings(ref DEVMODE1 devMode, int flags);

		// Token: 0x04000707 RID: 1799
		public const int ENUM_CURRENT_SETTINGS = -1;

		// Token: 0x04000708 RID: 1800
		public const int CDS_UPDATEREGISTRY = 1;

		// Token: 0x04000709 RID: 1801
		public const int CDS_TEST = 2;

		// Token: 0x0400070A RID: 1802
		public const int DISP_CHANGE_SUCCESSFUL = 0;

		// Token: 0x0400070B RID: 1803
		public const int DISP_CHANGE_RESTART = 1;

		// Token: 0x0400070C RID: 1804
		public const int DISP_CHANGE_FAILED = -1;
	}
}
