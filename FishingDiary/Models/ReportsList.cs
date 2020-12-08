//18.09.20
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;

namespace FishingDiary.Models
{
    public static class ReportsList
    {
        // Reports list
        // Список отчётов
        private static List<Report> mListReports = new List<Report>();

        /// <summary>
        /// Add report
        /// Добавить отчёт
        /// </summary>
        /// <param name="report">Reports</param>
        public static void AddReport(Report report)
        {
            mListReports.Add(report);
        }

        /// <summary>
        /// Remove report
        /// Удалить отчёт
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Removal result</returns>
        public static bool DeleteReport(Report report)
        {
            return mListReports.Remove(report);
        }

        /// <summary>
        /// Loading report from file
        /// </summary>
        /// <param name="sNameFile">Name file</param>
        /// <returns></returns>
        public static bool LoadReportList(string sNameMainFile)
        {
            FileStream file = new FileStream(sNameMainFile, FileMode.Open);

            // to do

            file.Close();

            return true;
        }

        /// <summary>
        /// Save the report to a file
        /// </summary>
        /// <param name="sNameFile">Name file</param>
        /// <returns></returns>
        public static bool SaveReportList(string sNameMainFile)
        {
            FileStream file = new FileStream(sNameMainFile, FileMode.Create);

            foreach(Report report in mListReports)
            {
                // to do
            }

            file.Close();

            return true;
        }
    }
}
