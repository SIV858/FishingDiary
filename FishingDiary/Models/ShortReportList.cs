//30.04.24
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.Json;

namespace FishingDiary.Models
{
    public static class ShortReportsList
    {
        // Reports list
        private static List<ShortReport> mListReports = new List<ShortReport>();

        /// <summary>
        /// Add report
        /// Добавить отчёт
        /// </summary>
        /// <param name="report">Reports</param>
        public static void AddReport(ShortReport report)
        {
            mListReports.Add(report);
        }

        /// <summary>
        /// Remove report
        /// Удалить отчёт
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Removal result</returns>
        public static bool DeleteReport(ShortReport report)
        {
            return mListReports.Remove(report);
        }

        /// <summary>
        /// Loading reports from file
        /// </summary>
        /// <param name="sNameFile">Name file</param>
        /// <returns></returns>
        public static bool LoadReporstList(string sNameMainFile)
        {
            // Parse ShortReportList
            // if a file exist then read it
            if (File.Exists(sNameMainFile))
            {
                using (StreamReader reader = new StreamReader(sNameMainFile))
                {
                    string json = reader.ReadToEnd();

                    var readOnlySpan = new ReadOnlySpan<byte>(Encoding.UTF8.GetBytes(json));
                    mListReports = JsonSerializer.Deserialize <List<ShortReport>> (readOnlySpan);
                }
            }

            return true;
        }

        /// <summary>
        /// Save the report to a file
        /// </summary>
        /// <param name="sNameFile">Name file</param>
        /// <returns></returns>
        public static bool SaveReportsList(string sNameMainFile)
        {
            try
            {
                //Write data to file
                using (StreamWriter writer = new StreamWriter(sNameMainFile))
                {
                    string json = JsonSerializer.Serialize<List<ShortReport>>(mListReports);
                    writer.Write(json);
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException(sNameMainFile);
            }
            catch (JsonException)
            {
                throw new JsonException(sNameMainFile);
            }

            return true;
        }
    }
}
