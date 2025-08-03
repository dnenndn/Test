using System;
using System.Runtime.InteropServices;

namespace GMAO
{
	// Token: 0x0200006D RID: 109
	public struct DEVMODE1
	{
		// Token: 0x040006E5 RID: 1765
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmDeviceName;

		// Token: 0x040006E6 RID: 1766
		public short dmSpecVersion;

		// Token: 0x040006E7 RID: 1767
		public short dmDriverVersion;

		// Token: 0x040006E8 RID: 1768
		public short dmSize;

		// Token: 0x040006E9 RID: 1769
		public short dmDriverExtra;

		// Token: 0x040006EA RID: 1770
		public int dmFields;

		// Token: 0x040006EB RID: 1771
		public short dmOrientation;

		// Token: 0x040006EC RID: 1772
		public short dmPaperSize;

		// Token: 0x040006ED RID: 1773
		public short dmPaperLength;

		// Token: 0x040006EE RID: 1774
		public short dmPaperWidth;

		// Token: 0x040006EF RID: 1775
		public short dmScale;

		// Token: 0x040006F0 RID: 1776
		public short dmCopies;

		// Token: 0x040006F1 RID: 1777
		public short dmDefaultSource;

		// Token: 0x040006F2 RID: 1778
		public short dmPrintQuality;

		// Token: 0x040006F3 RID: 1779
		public short dmColor;

		// Token: 0x040006F4 RID: 1780
		public short dmDuplex;

		// Token: 0x040006F5 RID: 1781
		public short dmYResolution;

		// Token: 0x040006F6 RID: 1782
		public short dmTTOption;

		// Token: 0x040006F7 RID: 1783
		public short dmCollate;

		// Token: 0x040006F8 RID: 1784
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
		public string dmFormName;

		// Token: 0x040006F9 RID: 1785
		public short dmLogPixels;

		// Token: 0x040006FA RID: 1786
		public short dmBitsPerPel;

		// Token: 0x040006FB RID: 1787
		public int dmPelsWidth;

		// Token: 0x040006FC RID: 1788
		public int dmPelsHeight;

		// Token: 0x040006FD RID: 1789
		public int dmDisplayFlags;

		// Token: 0x040006FE RID: 1790
		public int dmDisplayFrequency;

		// Token: 0x040006FF RID: 1791
		public int dmICMMethod;

		// Token: 0x04000700 RID: 1792
		public int dmICMIntent;

		// Token: 0x04000701 RID: 1793
		public int dmMediaType;

		// Token: 0x04000702 RID: 1794
		public int dmDitherType;

		// Token: 0x04000703 RID: 1795
		public int dmReserved1;

		// Token: 0x04000704 RID: 1796
		public int dmReserved2;

		// Token: 0x04000705 RID: 1797
		public int dmPanningWidth;

		// Token: 0x04000706 RID: 1798
		public int dmPanningHeight;
	}
}
