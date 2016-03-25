using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tesla.Base
{
    public class BaseModel: INotifyPropertyChanged, IModel
    {

        public BaseModel()
        {
            Execution = new ModelExecution();
        }

        protected IModelExecution Execution { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        // TODO: Look at putting this in Exrin but might lock VM and Models rather than leave it open
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }


    }
}
