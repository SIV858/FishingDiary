//30.04.24
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData.Binding;

namespace FishingDiary.Models
{
    public static class ShortReportsList
    {
        // Reports list
        private static ObservableCollection<ShortReport> mListReports = new ObservableCollection<ShortReport>();

        public static ObservableCollection<ShortReport> AllListReports => mListReports;
        // Reports list on current page
        public static ObservableCollection<ShortReport> ListReports
        {
            get
            {
                if (_PageCounter.PerPageElements != Helpers.ConvertViewReportModeToUint(Properties.GetInstance().ViewReportMode))
                {
                    _PageCounter = new PageCounter((uint)mListReports.Count,
                        Helpers.ConvertViewReportModeToUint(Properties.GetInstance().ViewReportMode));
                }

                ObservableCollection<ShortReport> CurrentListReports = new ObservableCollection<ShortReport> ();
                foreach (var report in mListReports.Skip((int)_PageCounter.StartElement - 1).Take((int)_PageCounter.CurrentElements))
                {
                    CurrentListReports.Add(report);
                }
                return CurrentListReports;
            }
        }

        // Page counter to display information about the current page
        private static PageCounter _PageCounter = null;

        private static ObservableCollection<ShortReport> mListReports2;


        public static bool FirstPage => _PageCounter.FirstPage;
        public static bool EndPage => _PageCounter.EndPage;
        public static uint StartElement => _PageCounter.StartElement;
        public static uint EndElement => _PageCounter.EndElement;
        public static uint CurrentPage => _PageCounter.CurrentPage;

        public static int Count => mListReports.Count;


        /// <summary>
        /// Add report
        /// </summary>
        /// <param name="report">Reports</param>
        public static void AddReport(ShortReport report)
        {
            mListReports.Add(report);

            if (_PageCounter == null)
            {
                _PageCounter = new PageCounter((uint)mListReports.Count, 
                    Helpers.ConvertViewReportModeToUint(Properties.GetInstance().ViewReportMode));
            }
            else
            {
                _PageCounter.AddElement();
            }
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
            try
            {
                Directory.Delete(Path.GetDirectoryName(report.ReportPath), true);
            }
            catch(DirectoryNotFoundException)
            {

            }

            // delete the full report from the list
            ReportsList.DeleteReport(report.ReportId);

            if (!mListReports.Remove(report))
            {
                return false;
            }

            if (_PageCounter != null)
            {
                _PageCounter.DeleteElement();
            }

            return SaveReportsList(PathsAndConstants.SHORT_REPORT_PATH);
        
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

                foreach (var report in mListReports)
                {
                    report.PhotoMini = Helpers.LoadFromFile(report.PhotoPath);
                    if (report.PhotoMini == null) 
                    {
                        report.PhotoMini = Helpers.LoadFromFile(PathsAndConstants.NO_PHOTO_PATH_MINI);
                        report.PhotoPath = PathsAndConstants.NO_PHOTO_PATH_MINI;
                    }
                }
            }

            _PageCounter = new PageCounter((uint)mListReports.Count,
                Helpers.ConvertViewReportModeToUint(Properties.GetInstance().ViewReportMode));

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

        public static void IncrementPage()
        {
            _PageCounter.IncrementPage();
        }

        public static void DecrementPage()
        {
            _PageCounter.DecrementPage();
        }

        public static void SetPage(uint NumberPage) 
        { 
            _PageCounter.SetPage(NumberPage);
        }

    }
}
