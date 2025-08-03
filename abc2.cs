using System;
using Telerik.WinControls.UI;

namespace GMAO
{
	// Token: 0x02000094 RID: 148
	public class abc2 : SchedulerNavigatorLocalizationProvider
	{
		// Token: 0x060006DF RID: 1759 RVA: 0x0012DB18 File Offset: 0x0012BD18
		public override string GetLocalizedString(string id)
		{
			uint num = <PrivateImplementationDetails>.ComputeStringHash(id);
			if (num <= 2536801878U)
			{
				if (num <= 1183584910U)
				{
					if (num != 1103215200U)
					{
						if (num == 1183584910U)
						{
							if (id == "MonthViewButtonCaption")
							{
								return "Par Mois";
							}
						}
					}
					else if (id == "TodayButtonCaptionThisWeek")
					{
						return "Cette Semaine";
					}
				}
				else if (num != 1501467062U)
				{
					if (num != 2018430276U)
					{
						if (num == 2536801878U)
						{
							if (id == "WeekViewButtonCaption")
							{
								return "Par Semaine";
							}
						}
					}
					else if (id == "SearchInAppointments")
					{
						return "Recherche";
					}
				}
				else if (id == "DayViewButtonCaption")
				{
					return "Par Jour";
				}
			}
			else if (num <= 3242991498U)
			{
				if (num != 2634022482U)
				{
					if (num == 3242991498U)
					{
						if (id == "ShowWeekendCheckboxCaption")
						{
							return "Afficher Weekend";
						}
					}
				}
				else if (id == "TodayButtonCaptionThisMonth")
				{
					return "Ce Mois";
				}
			}
			else if (num != 3488376327U)
			{
				if (num != 3910179689U)
				{
					if (num == 4105603614U)
					{
						if (id == "AgendaViewButtonCaption")
						{
							return "Détail";
						}
					}
				}
				else if (id == "TodayButtonCaptionToday")
				{
					return "Aujourd'hui";
				}
			}
			else if (id == "TimelineViewButtonCaption")
			{
				return "Chronologie";
			}
			return string.Empty;
		}
	}
}
