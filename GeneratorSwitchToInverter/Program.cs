using System;

namespace GeneratorSwitchToInverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string DefaultFileName = "DefaultSwitch.txt";
                string NoticeOfExit = "\nPress any key to exit the program...";

                for (int i = 0; i < args.Length; i++)
                {

                }

                if (args.Length == 0) WriteHelper();

                SwitchModel _OldSwitchModel = FileManager.GetSwitchFromFile(DefaultFileName);

                if(_OldSwitchModel == null)
                {
                    FileManager.SetFileDefault();
                    return;
                }

                SwitchModel _NewSwitchModel = CalculationProportions.RunCalculation(_OldSwitchModel);

                if(_NewSwitchModel == null)
                {
                    Console.WriteLine("An error occurred while converting \"FinalSwitch\" please correct the xxx file and try again." + NoticeOfExit);
                    Console.ReadKey();
                    return;
                }

                FileManager.SetFileFromSwitch(_NewSwitchModel);
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }
        }

        private static void WriteHelper()
        {

        }

        private static void WriteLicense()
        {

        }
    }
}
