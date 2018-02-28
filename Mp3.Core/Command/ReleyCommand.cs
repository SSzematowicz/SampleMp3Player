using System;
using System.Windows.Input;

namespace Mp3.Core
{
    class ReleyCommand : ICommand
    {
        private Action m_action;

        public ReleyCommand(Action action)
        {
            m_action = action;
        }
        public bool CanExecute(object parameter) => true;

        public event EventHandler CanExecuteChanged = (s, e) => { };

        public void Execute(object parameter) => m_action();
    }
}
