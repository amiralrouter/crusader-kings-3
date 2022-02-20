using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crusader_Kings_3 {
    public static class Language {

        //public class Locale{
        //    public string Name;
        //    public string Code;
        //    public Dictionary<string,string> Translates ;
        //}
        //public static Dictionary<string, string> GetParsedTranslates(string data){
        //    Dictionary<string, string> translates = new Dictionary<string, string>();
        //    var xml = System.Xml.Linq.XDocument.Load(data);
        //    foreach (var item in xml.Root.Elements()) {
        //        translates.Add(item.Attribute("key").Value, item.Attribute("value").Value);
        //    }
        //    return translates;
        //}

        //public static List<Locale> _Locales = new List<Locale>();
        //public static List<Locale> Locales{ 
        //    get{
        //        if(_Locales.Count > 0)
        //            return _Locales;
 
        //        _Locales.Add(new Locale() { 
        //            Name = "English", 
        //            Code = "en", 
        //            Translates = GetParsedTranslates(Properties.Resources.Translates_en) 
        //        });
        //        _Locales.Add(new Locale() { 
        //            Name = "Türkçe", 
        //            Code = "tr", 
        //            Translates = GetParsedTranslates(Properties.Resources.Translates_tr) 
        //        }); 

        //        return _Locales;
        //    }
        //}
        //public static string CurrentLocaleCode = "en";
        //public static Locale CurrentLocale {
        //    get {
        //        return Locales.FirstOrDefault(l => l.Code == CurrentLocaleCode);
        //    }
        //}


        //public static string Get(string key) { 
        //    if (CurrentLocale.Translates.ContainsKey(key))
        //        return CurrentLocale.Translates[key]; 
        //    return key;
        //}


    }
}
