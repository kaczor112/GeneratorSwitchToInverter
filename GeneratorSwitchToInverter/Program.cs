using System;

namespace GeneratorSwitchToInverter
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string versionProgram = "ver 0.1 ON 5.03.2022r.";
                string DefaultFileName = "DefaultSwitch.txt";
                string NoticeOfExit = "\nPress any key to exit the program...";

                for (int i = 0; i < args.Length; i++)
                {
                    if((args[i].ToUpper() == "-H") || (args[i].ToUpper() == "--HELP"))
                    {
                        Console.WriteLine("Current version to:" + versionProgram);
                        WriteHelper();
                        Console.WriteLine(NoticeOfExit);
                        Console.ReadKey();
                        return;
                    }

                    if((args[i].ToUpper() == "-V") || (args[i].ToUpper() == "--VERSION"))
                    {
                        Console.WriteLine("Current version to:" + versionProgram + NoticeOfExit);
                        Console.ReadKey();
                        return;
                    }

                    if((args[i].ToUpper() == "-L") || (args[i].ToUpper() == "--LICENSE"))
                    {
                        WriteLicense();
                        Console.WriteLine(NoticeOfExit);
                        Console.ReadKey();
                        return;
                    }

                    if ((args[i].ToUpper() == "-F") || (args[i].ToUpper() == "--FILE"))
                    {
                        if(i <= args.Length - 2)
                            DefaultFileName = args[i];
                        else
                        {
                            WriteHelper();
                            Console.WriteLine(NoticeOfExit);
                            Console.ReadKey();
                        }
                    }
                }

                //if (args.Length == 0) WriteHelper();

                SwitchModel _OldSwitchModel = FileManager.GetSwitchFromFile(DefaultFileName);

                if(_OldSwitchModel == null)
                {
                    FileManager.SetFileDefault();
                    return;
                }

                SwitchModel _NewSwitchModel = CalculationProportions.RunCalculation(_OldSwitchModel);

                if(_NewSwitchModel == null)
                {
                    Console.WriteLine("An error occurred while converting \"FinalSwitch\" please correct the " + DefaultFileName + " file and try again." + NoticeOfExit);
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
            string helperString = "Press:\n" +
                "-h --help\tView helper.\n" +
                "-v --version\tView versions.\n" +
                "-l --license\tView license.\n" +
                "-f --file\tSet input file.";
            Console.WriteLine(helperString);
        }

        private static void WriteLicense()
        {
            string licenseString = "Copyright 2022 Paweł Kaczmarczyk\n\n" +

                "Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files(the \"Software\"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/ or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:\n\n" +

                "The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.\n\n" +

                "THE SOFTWARE IS PROVIDED \"AS IS\", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.";

            Console.WriteLine(licenseString);
        }
    }
}
