using System;
using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;

namespace Tesla.ViewModel
{
    public class ControlViewModel : BaseViewModel
    {

        public ControlViewModel(IControlModel model, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner) :
            base(displayService, navigationService, errorHandlingService, stackRunner)
        { }
       
        // Model
        public IControlModel Model { get; set; }

        // View Status
        public string ProximityLocationStatus { get { return Get<string>(); } private set { Set(value); } }
        public string SummonStatus { get { return Get<string>(); } private set { Set(value); } }

        public override IVisualState VisualState
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        // View Commands      
        //public IRelayCommand HonkCommand
        //{
        //    get
        //    {
        //        return GetCommand(() =>
        //        {
        //            return Execution.ViewModelExecute();
        //        });
        //    }
        //}

        //public IRelayCommand LockCommand
        //{
        //    get
        //    {
        //        return GetCommand(() =>
        //        {
        //            return Execution.ViewModelExecute();
        //        });
        //    }
        //}

        //public IRelayCommand FlashCommand
        //{
        //    get
        //    {
        //        return GetCommand(() =>
        //        {
        //            return Execution.ViewModelExecute();
        //        });
        //    }
        //}

        //public IRelayCommand SummonCommand
        //{
        //    get
        //    {
        //        return GetCommand(() =>
        //        {
        //            return Execution.ViewModelExecute();
        //        });
        //    }
        //}

    }
}
