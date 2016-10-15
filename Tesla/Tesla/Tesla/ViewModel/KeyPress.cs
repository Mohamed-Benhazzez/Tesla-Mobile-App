namespace Tesla.ViewModelOperation
{
    using Definition.ViewLocator;
    using Exrin.Abstraction;
    using Exrin.Framework;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TeslaDefinition;
    using TeslaDefinition.Interfaces.Model;

    public class PinLoginOperation : IOperation
    {
        IAuthModel _model = null;
        string _backCharacter = "";

        public PinLoginOperation(IAuthModel model, string backCharacter)
        {
            _model = model;
            _backCharacter = backCharacter;
        }

        public Func<IList<IResult>, object, CancellationToken, Task> Function
        {
            get
            {
                return async (results, parameter, token) =>
                {
                    var result = new Result();
                    var character = Convert.ToString(parameter);
                    var pin = _model.AuthModelState.Pin;

                    if (pin == null) pin = string.Empty;

                    if (character != null)
                        if (character == _backCharacter)
                        {
                            if (!String.IsNullOrEmpty(pin) && pin.Length > 0)
                                _model.AuthModelState.Pin = pin.Substring(0, pin.Length - 1);
                        }
                        else
                        {
                            _model.AuthModelState.Pin = pin += character;
                        }


                    if (!await _model.IsPinComplete())
                    {
                        result.ResultAction = ResultType.None;
                    }
                    else if (await _model.IsAuthenticated())
                    {
                        result.ResultAction = ResultType.Navigation;
                        result.Arguments = new NavigationArgs() { Key = Control.Main, StackType = Stacks.Control };
                    }                   
                    else
                    {
                        result.ResultAction = ResultType.Display;
                        result.Arguments = new DisplayArgs() { Message = "Invalid Pin Entered. Please try again." };
                    }

                    results.Add(result);
                };
            }
        }
        
        public bool ChainedRollback { get; private set; } = false;

        public Func<Task> Rollback { get { return null; } }
    }
}
