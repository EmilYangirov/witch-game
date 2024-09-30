using System;
using MVVM;
using R3;
using TMPro;

namespace SharedKernel.Binder
{
    public class TextBinder : Observer<string>, IBinder
    {
        private TMP_Text _view;
        private ReadOnlyReactiveProperty<string> _property;
        private IDisposable _handle;

        public TextBinder(TMP_Text view, ReadOnlyReactiveProperty<string> property)
        {
            _view = view;
            _property = property;
        }

        public void Bind()
        {
            OnNext(_property.CurrentValue);
            _handle = _property.Subscribe(this);
        }

        public void Unbind()
        {
            _handle?.Dispose();
            _handle = null;
        }

        protected override void OnNextCore(string value)
        {
            _view.text = value;
        }

        protected override void OnErrorResumeCore(Exception error)
        {
            throw new NotImplementedException();
        }

        protected override void OnCompletedCore(Result result)
        {
            throw new NotImplementedException();
        }
    }
}