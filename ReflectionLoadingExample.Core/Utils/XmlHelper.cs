using System.Xml.Linq;

namespace ReflectionLoadingExample.Core.Utils;

public class XmlHelper
{
    public static List<MoudleEntity> MoudleList;

    public static void LoadMoudleList()
    {
        MoudleList = new List<MoudleEntity>();
        var doc = XDocument.Load("MoudlesConfig.xml");
        foreach (var element in doc.Descendants("Module"))
        {
            try
            {
                var isShow = bool.Parse(element.Attribute("IsShow").Value);
                var moduleName =element.Attribute("ModuleName").Value;
                var viewModelType = ModuleHelper.GetModuleType(moduleName);
                if (isShow && viewModelType != null)
                {
                    var model = new MoudleEntity();
                    model.ModuleName = moduleName;
                    model.type = viewModelType;
                    model.BusinessName = element.Attribute("BusinessName").Value;
                    MoudleList.Add(model);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    public static void LoadConfig()
    {
        var doc = XDocument.Load("MoudlesConfig.xml");
        foreach (var element in doc.Descendants("Config"))
        {
            try
            {
                Config.ShowScreen = bool.Parse(element.Attribute("ShowScreen").Value);
                Config.DefaultName =element.Attribute("DefaultName").Value;
                Config.DefaultSex =element.Attribute("DefaultSex").Value;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}