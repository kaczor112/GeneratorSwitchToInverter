using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorSwitchToInverter
{
    public class SwitchModel
    {
        public List<SingleCaseModel> MySwitch { get; private set; }

        public void SetModelFromString(string _inString)
        {
            try
            {
                if (_inString == null) return;
                if (_inString == "") return;

                List<SingleCaseModel> tempMySwitch = new();

                string[] tempSwitch = _inString.Split("\n");

                if (tempSwitch.Length == 0) return;

                foreach (string OneTempSwitch in tempSwitch)
                {
                    if (OneTempSwitch.Contains("case"))
                    {
                        SingleCaseModel tempSingleCase = new();
                        string[] tempCase = OneTempSwitch.Split(":");

                        tempSingleCase.Ocase = int.Parse(tempCase[0].Replace("case ", ""));
                        tempSingleCase.Oreturn = int.Parse(tempCase[1].Replace("return ", "").Replace(";", ""));

                        tempMySwitch.Add(tempSingleCase);
                    }
                }

                MySwitch = tempMySwitch;
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }
        }

        public string MakeString()
        {
            try
            {
                string tempRequest = "";

                tempRequest += "switch(_speed)\n";
                tempRequest += "{\n";

                foreach (SingleCaseModel OneTempSwitch in MySwitch)
                {
                    tempRequest += "\tcase " + OneTempSwitch.Ocase + ": return " + OneTempSwitch.Oreturn + ";\n";
                }

                tempRequest += "}";

                return tempRequest;
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }

            return null;
        }

        public void SetMySwitch(List<SingleCaseModel> newMySwitch)
        {
            try
            {
                if (newMySwitch == null) return;
                if (newMySwitch.Count == 0) return;

                MySwitch = newMySwitch;
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }
        }
    }

    public class SingleCaseModel
    {
        public int Ocase { get; set; }
        public int Oreturn { get; set; }
    }
}
