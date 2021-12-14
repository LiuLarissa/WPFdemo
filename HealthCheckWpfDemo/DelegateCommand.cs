using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthCheckWpfDemo
{
    public class DelegateCommand : ICommand
    {
        public delegate void SimpleEventHandler(object sender, DelegateCommandEventArgs e);
        private SimpleEventHandler handler;
        private bool isEnabled = true;

        public DelegateCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        public void Execute(object parameter)
        {
            this.handler(this, new DelegateCommandEventArgs(parameter));
        }

        public bool CanExecute(object parameter)
        {
            return this.isEnabled;
        }

        public event EventHandler CanExecuteChanged;
        private void OnCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, EventArgs.Empty);
        }
        public bool IsEnable
        {
            get { return this.isEnabled; }
            set
            {
                this.isEnabled = value;
                this.OnCanExecuteChanged();
            }
        }
    }
}
