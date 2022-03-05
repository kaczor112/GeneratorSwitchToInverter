using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorSwitchToInverter
{
    class CalculationProportions
    {
        public static SwitchModel RunCalculation(SwitchModel _inSwitchModel)
        {
            try
            {
                // Zakładam że case rośnie a return maleje
                if (_inSwitchModel == null) return null;
                if (_inSwitchModel.MySwitch == null) return null;
                if (_inSwitchModel.MySwitch.Count <= 1) return null;

                List<SingleCaseModel> requestSwitch = new();

                for(int i = 0; i < _inSwitchModel.MySwitch.Count - 1; i++)
                {
                    int tempStep = _inSwitchModel.MySwitch[i + 1].Ocase - _inSwitchModel.MySwitch[i].Ocase;

                    requestSwitch.Add(_inSwitchModel.MySwitch[i]);

                    if (tempStep <= 1)
                    {
                        continue;
                    }

                    int tempValue = (_inSwitchModel.MySwitch[i].Oreturn - _inSwitchModel.MySwitch[i + 1].Oreturn) / tempStep;

                    for (int j = 1; j < tempStep; j++)
                    {
                        SingleCaseModel _SingleCase = new();
                        _SingleCase.Ocase = _inSwitchModel.MySwitch[i].Ocase + j;
                        _SingleCase.Oreturn = _inSwitchModel.MySwitch[i].Oreturn - (tempValue * j);

                        requestSwitch.Add(_SingleCase);
                    }
                }

                requestSwitch.Add(_inSwitchModel.MySwitch[_inSwitchModel.MySwitch.Count - 1]);

                SwitchModel requestSwitchModel = new();
                requestSwitchModel.SetMySwitch(requestSwitch);
                return requestSwitchModel;
            }
            catch (Exception ex)
            {
                ExceptionManager.GoException(ex);
            }

            return null;
        }
    }
}
