using System;
using Exrin.Abstraction;
using Exrin.Framework;
using Tesla.Base;
using TeslaDefinition.Interfaces.Model;
using Tesla.ViewModel.MainTabs;

namespace Tesla.ViewModel
{
    public class ControlViewModel : BaseViewModel
    {

        public ControlViewModel(IControlModel model, IDisplayService displayService, INavigationService navigationService, IErrorHandlingService errorHandlingService, IStackRunner stackRunner) :
            base(displayService, navigationService, errorHandlingService, stackRunner, new ControlVisualState(model))
        { }
       
        // Model
        public IControlModel Model { get; set; }

        // View Status
        public string ProximityLocationStatus { get { return Get<string>(); } private set { Set(value); } }
        public string SummonStatus { get { return Get<string>(); } private set { Set(value); } }

      

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
