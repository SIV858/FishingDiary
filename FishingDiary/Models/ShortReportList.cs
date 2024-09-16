//30.04.24
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.Json;
using System.Collections.ObjectModel;

namespace FishingDiary.Models
{
    public static class ShortReportsList
    {
        // Reports list
        private static ObservableCollection<ShortReport> mListReports = new ObservableCollection<ShortReport>();

        // Public reports list
        public static ObservableCollection<ShortReport> ListReports => mListReports;


        /// <summary>
        /// Add report
        /// </summary>
        /// <param name="report">Reports</param>
        public static void AddReport(ShortReport report)
        {
            mListReports.Add(report);
        }

        /// <summary>
        /// Find report by ID
        /// </summary>
        /// <param name="Id">ID</param>
        /// <returns>Report</returns>
        public static ShortReport FindReport(uint Id)
        {
            foreach (var report in mListReports)
            {
                if (report.ReportId == Id) 
                    return report;
            }
            return null;
        }

        /// <summary>
        /// Remove report
        /// </summary>
        /// <param name="report">Report</param>
        /// <returns>Removal result</returns>
        public static bool DeleteReport(ShortReport report)
        {
            // delete mini photo
            if (Path.GetFileName(report.PhotoPath) != PathsAndConstants.NO_PHOTO_FILE_NAME_MINI)
                File.Delete(report.PhotoPath);
            // delete report directory photo
            Directory.Delete(Path.GetDirectoryName(report.ReportPath), true);

            // delete the full report from the list
            ReportsList.DeleteReport(report.ReportId);


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
                    mListReports = JsonSerializer.Deserialize <ObservableCollection<ShortReport>> (readOnlySpan);
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
                    string json = JsonSerializer.Serialize<ObservableCollection<ShortReport>>(mListReports);
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
