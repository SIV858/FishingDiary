//18.09.20
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class ReportsList
    {

        //Список отчётов
        private List<Report> mListReports = new List<Report>();

        /// <summary>
        /// Добавить отчёт
        /// </summary>
        /// <param name="report">Отчёт</param>
        public void AddReport(Report report)
        {
            mListReports.Add(report);
        }

        /// <summary>
        /// Удалить отчёт
        /// </summary>
        /// <param name="report">Отчёт</param>
        /// <returns>Успешность удаления</returns>
        public bool DeleteReport(Report report)
        {
            return mListReports.Remove(report);
        }

    }
}
