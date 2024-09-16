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
        /// Add report
        /// </summary>
        /// <param name="report">Reports</param>
        public static void AddReport(Report report)
        {
            mListReports.Add(report);
        }

        /// <summary>
        /// Load report from file
        /// </summary>
        /// <param name="ReportPath">Path to report</param>
        public static Report LoadReport(string ReportPath)
        {
            try
            {
                using (StreamReader reader = new StreamReader(ReportPath))
                {
                    string json = reader.ReadToEnd();

                    var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                    Report report = JsonSerializer.Deserialize<Report>(readOnlySpan);
                    mListReports.Add(report);
                    return report;
                }
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

            foreach (Report report in mListReports)
            {
                // to do
            }

            file.Close();

            return true;
        }
    }
}
