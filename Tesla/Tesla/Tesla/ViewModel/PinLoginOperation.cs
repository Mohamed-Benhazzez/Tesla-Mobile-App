using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesla.Control;
using TeslaDefinition;
using TeslaDefinition.Interfaces.Model;
using TeslaDefinition.Interfaces.Service;

namespace Tesla.ViewModelOperation
{
    public class PinLoginOperation : IOperation
    {
        IPinModel _model = null;
        string _backCharacter = "";

        public PinLoginOperation(IPinModel model, string backCharacter)
        {
            _model = model;
            _backCharacter = backCharacter;
        }

        public bool ChainedRollback { get; private set; } = false;

        public Func<IResult, Task> Function
        {
            get
            {
                return async (result) =>
                {

                    var character = Convert.ToString(result.Parameter);
                    var pin = _model.Pin;

                    if (character != null && pin != null)
                        if (character == _backCharacter)
                        {
                            if (!String.IsNullOrEmpty(pin) && pin.Length > 0)
                                _model.Pin = pin.Substring(0, pin.Length - 1);
                        }
                        else
                        {
                            _model.Pin = pin += character;
                        }

                    
                    if (await _model.IsPinValid())
                    {
                        result.ResultAction = ResultType.Navigation;
                        result.Arguments = new NavigationArgs() { PageIndicator = PageLocator.Main.Main, StackType = Stacks.Main };
                    }
                    else
                    {
                        result.ResultAction = ResultType.Display;
                        result.Arguments = new DisplayArgs() { Message = "Invalid Pin Entered. Please try again." };
                    }
                };
            }
        }

        public Func<IResult, Task> Rollback { get { return null; } }
    }
}
