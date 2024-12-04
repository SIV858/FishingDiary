//18.09.20
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.Json;

namespace FishingDiary.Models
{
    public static class ReportsList
    {
        // Reports list
        private static List<Report> mListReports = new List<Report>();

        /// <summary>
        /// Reports list
        /// </summary>
        public static List<Report> Reports => mListReports;

        /// <summary>
        /// Add report
        /// </summary>
        /// <param name="report">Reports</param>
        public static void AddReport(Report report)
        {
            mListReports.Add(report);
        }

        /// <summary>
        /// Get report returned from a list or loaded from a file
        /// </summary>
        /// <param name="ReportPath">Path to report</param>
        /// <param name="ReportId">Report ID</param>
        /// <returns>Report</returns>
        public static Report GetReport(string ReportPath, uint ReportId)
        {
            try
            {
                Report report = mListReports.Find(x => x.ReportId == ReportId);
                // If you couldn't find it in the list, load it from a file
                if (report == null)
                {
                    using (StreamReader reader = new StreamReader(ReportPath))
                    {
                        string json = reader.ReadToEnd();

                        var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                        report = JsonSerializer.Deserialize<Report>(readOnlySpan);
                        mListReports.Add(report);
                    }
                }
                return report;
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(ReportPath);
            }
            catch (JsonException)
            {
                throw new JsonException(ReportPath);
            }

        }

        /// <summary>
        /// Load all reports
        /// </summary>
        public static void LoadReports()
        {
            foreach(ShortReport shortReport in ShortReportsList.AllListReports)
            {
                GetReport(shortReport.ReportPath, shortReport.ReportId);
            }
        }

        /// <summary>
        /// Delete report
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Removal result</returns>
        public static bool DeleteReport(Report report)
        {
            return mListReports.Remove(report);
        }


        /// <summary>
        /// Delete report by Id. If the report is not in the list, then we do nothing.
        /// </summary>
        /// <param name="report">Report ID</param>
        public static void DeleteReport(uint ID)
        {
            foreach (Report report in mListReports)
            {
                if (report.ReportId == ID)
                {
                    mListReports.Remove(report);
                    break;
                }
            }
        }
    }
}
