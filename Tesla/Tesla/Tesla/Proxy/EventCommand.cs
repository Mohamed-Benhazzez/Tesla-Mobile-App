using Exrin.Abstraction;
using Exrin.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using System.Reflection;

namespace Tesla.Proxy
{
    // DO NOT USE: COMPLETELY UNTESTED
    public class EventCommand<T> : Behavior<T> where T : BindableObject
    {

        public static readonly BindableProperty EventNameProperty = BindableProperty.Create("EventName", typeof(string), typeof(EventCommand<T>), null);
        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(EventCommand<T>), null);

        private Delegate _delegate = null;
        private EventInfo _eventInfo = null;

        public string EventName
        {
            get { return (string)GetValue(EventNameProperty); }
            set { SetValue(EventNameProperty, value); }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(T bindable)
        {
            base.OnAttachedTo(bindable);

            var events = bindable.GetType().GetRuntimeEvents().ToList();
            _eventInfo = events.FirstOrDefault(e => e.Name == EventName);
            if (_eventInfo == null)
                throw new ArgumentException($"No event of name {EventName} in EventCommand");

            SetEventHandler(_eventInfo, bindable, EventRaised);
        }

        protected override void OnDetachingFrom(T bindable)
        {
            if (_delegate != null)
                _eventInfo.RemoveEventHandler(bindable, _delegate);

            base.OnDetachingFrom(bindable);
        }

        private void SetEventHandler(EventInfo eventInfo, object target, Action<object, EventArgs> action)
        {   
            var actionInvoke = action.GetType()
                .GetRuntimeMethods().First(m => m.Name == "Invoke");

            Action raise = () => EventRaised(target, null);
            _delegate = raise;
            eventInfo.AddEventHandler(target, _delegate);
        }

        private void EventRaised(object sender, EventArgs eventArgs)
        {
            if (Command == null)
                return;

            Command.Execute(null);

        }

    }
}
