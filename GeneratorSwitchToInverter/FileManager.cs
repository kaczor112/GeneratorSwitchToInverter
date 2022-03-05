using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorSwitchToInverter
{
    class FileManager
    {
        public static SwitchModel GetSwitchFromFile(string _fileName)
        {
            try
            {
                if(!File.Exists(_fileName)) return null;

                string readText = File.ReadAllText(_fileName);

                SwitchModel _SwitchModel = new();

                _SwitchModel.SetModelFromString(readText);

                return _SwitchModel;
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }

            return null;
        }
        
        public static void SetFileFromSwitch(SwitchModel _inputSwitch)
        {
            try
            {
                string FinalFileName = "FinalSwitch";
                SaveFile(FinalFileName, _inputSwitch.MakeString());
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }
        }
        
        public static void SetFileDefault()
        {
            try
            {
                string DefaultFileName = "DefaultSwitch";
                SaveFile(DefaultFileName, MakeDefaultString());
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }
        }

        protected static void SaveFile(string nameFile, string bodyFile, bool createNewFile = true, string extension = "txt")
        {
            try
            {
                if (createNewFile)
                {
                    if (File.Exists(nameFile + "." + extension))
                    {
                        int index = 1;

                        while (File.Exists(bodyFile + "(" + index + ")." + extension)) index++;

                        nameFile = bodyFile + "(" + index + ")";
                    }

                    File.WriteAllText(nameFile + "." + extension, bodyFile, Encoding.UTF8);
                }
                else
                {
                    using StreamWriter file = new(nameFile + "." + extension, append: true);
                    file.WriteLine(bodyFile);
                }
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }
        }

        private static string MakeDefaultString()
        {
            string PrimaryString = "";

            PrimaryString += "switch(_speed)\n";
            PrimaryString += "{\n";
            PrimaryString += "\tcase 0: return 300000;\n";
            PrimaryString += "\tcase 45: return 170000;\n";
            PrimaryString += "\tcase 90: return 92000;\n";
            PrimaryString += "\tcase 135: return 70000;\n";
            PrimaryString += "\tcase 180: return 48000;\n";
            PrimaryString += "\tcase 225: return 38200;\n";
            PrimaryString += "\tcase 270: return 31000;\n";
            PrimaryString += "\tcase 315: return 26000;\n";
            PrimaryString += "\tcase 360: return 23000;\n";
            PrimaryString += "\tcase 405: return 20000;\n";
            PrimaryString += "\tcase 450: return 18400;\n";
            PrimaryString += "\tcase 495: return 17000;\n";
            PrimaryString += "\tcase 540: return 15300;\n";
            PrimaryString += "\tcase 585: return 14200;\n";
            PrimaryString += "\tcase 630: return 13200;\n";
            PrimaryString += "\tcase 675: return 12500;\n";
            PrimaryString += "}";

            return PrimaryString;
        }
    }
}
