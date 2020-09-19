//18.09.20
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class ReportsList
    {
        // Reports list
        // Список отчётов
        private List<Report> mListReports = new List<Report>();

        /// <summary>
        /// Add report
        /// Добавить отчёт
        /// </summary>
        /// <param name="report">Reports</param>
        public void AddReport(Report report)
        {
            mListReports.Add(report);
        }

        /// <summary>
        /// Remove report
        /// Удалить отчёт
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Removal result</returns>
        public bool DeleteReport(Report report)
        {
            return mListReports.Remove(report);
        }

    }
}
