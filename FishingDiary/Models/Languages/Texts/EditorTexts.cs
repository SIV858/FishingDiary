//31.01.24
using System;
using System.Collections.Generic;
using System.Text;

namespace FishingDiary.Models
{
    public class CEditorTexts
    {
        public string sHead { get; set; } = "Editor";
        public Dictionary<string, string> EditParamDict { get; set; } = new Dictionary<string, string>();

        //Returns the local name of the parameter.
        //If no such parameter is found, returns the current name
        public string GetLocaleParam(string sCommonParam)
        {
            foreach(var param in EditParamDict)
            {
                if (param.Key == sCommonParam)
                {
                    return param.Value;
                }
            }

            return sCommonParam;
        }
    }
}
