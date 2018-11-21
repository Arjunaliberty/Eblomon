using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eblomon
{
    public class EblResp
    {
        public Previosshift[] PreviosShifts { get; set; }
        public Todayshift TodayShift { get; set; }
        public Currentdebt CurrentDebt { get; set; }
        public int CurrentDebtHours { get; set; }
        public int CurrentDebtMinutes { get; set; }
        public Todayplantime TodayPlanTime { get; set; }
        public Todaydebt TodayDebt { get; set; }
        public int TodayDebtHours { get; set; }
        public int TodayDebtMinutes { get; set; }
        public Todaydebtwitprevperiod TodayDebtWitPrevPeriod { get; set; }
        public bool isActiveWorker { get; set; }
        public string ScheduleName { get; set; }
        public int WorkerId { get; set; }
    }
    public class Todayshift
    {
        public Part[] Parts { get; set; }
        public Sortedpart[] SortedParts { get; set; }
        public int EmployeeId { get; set; }
        public Workingtime WorkingTime { get; set; }
        public DateTime StartDtUtc { get; set; }
        public DateTime EndDtUtc { get; set; }
        public bool IsClosed { get; set; }
    }
    public class Workingtime
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public float TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public float TotalSeconds { get; set; }
    }
    public class Part
    {
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public DateTime StartDtUtc { get; set; }
        public DateTime EndDtUtc { get; set; }
        public object Id { get; set; }
        public Workingtime1 WorkingTime { get; set; }
        public int StartUT { get; set; }
        public int EndUT { get; set; }
        public int SumTime { get; set; }
    }
    public class Workingtime1
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public float TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public float TotalSeconds { get; set; }
    }
    public class Sortedpart
    {
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public DateTime StartDtUtc { get; set; }
        public DateTime EndDtUtc { get; set; }
        public object Id { get; set; }
        public Workingtime2 WorkingTime { get; set; }
        public int StartUT { get; set; }
        public int EndUT { get; set; }
        public int SumTime { get; set; }
    }
    public class Workingtime2
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public float TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public float TotalSeconds { get; set; }
    }
    public class Currentdebt
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public int TotalMilliseconds { get; set; }
        public int TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }
    }
    public class Todayplantime
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public int TotalMilliseconds { get; set; }
        public int TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }
    }
    public class Todaydebt
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public float TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public float TotalSeconds { get; set; }
    }
    public class Todaydebtwitprevperiod
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public float TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public float TotalSeconds { get; set; }
    }
    public class Previosshift
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int IsWorkingDay { get; set; }
        public int PlanAbsence { get; set; }
        public Workingtime3 WorkingTime { get; set; }
        public DateTime Date { get; set; }
        public Divergence Divergence { get; set; }
        public Shiftpart[] ShiftParts { get; set; }
        public int WorkerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Totaltime TotalTime { get; set; }
    }
    public class Workingtime3
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public int TotalMilliseconds { get; set; }
        public int TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }
    }
    public class Divergence
    {
        public int Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public int TotalDays { get; set; }
        public int TotalHours { get; set; }
        public int TotalMilliseconds { get; set; }
        public int TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }
    }
    public class Totaltime
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public int TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }
    }
    public class Shiftpart
    {
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public DateTime StartDtUtc { get; set; }
        public DateTime EndDtUtc { get; set; }
        public int Id { get; set; }
        public Workingtime4 WorkingTime { get; set; }
        public int StartUT { get; set; }
        public int EndUT { get; set; }
        public int SumTime { get; set; }
    }
    public class Workingtime4
    {
        public long Ticks { get; set; }
        public int Days { get; set; }
        public int Hours { get; set; }
        public int Milliseconds { get; set; }
        public int Minutes { get; set; }
        public int Seconds { get; set; }
        public float TotalDays { get; set; }
        public float TotalHours { get; set; }
        public int TotalMilliseconds { get; set; }
        public float TotalMinutes { get; set; }
        public int TotalSeconds { get; set; }
    }
}
