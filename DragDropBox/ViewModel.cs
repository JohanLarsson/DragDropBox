﻿namespace DragDropBox
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public class ViewModel : INotifyPropertyChanged
    {
        private Foo foo1 = new Foo("Johan");
        private Foo foo2;
        private Foo foo3 = new Foo("Erik");
        private Foo foo4;

        public event PropertyChangedEventHandler PropertyChanged;

        public Foo Foo1
        {
            get => this.foo1;

            set
            {
                if (ReferenceEquals(value, this.foo1))
                {
                    return;
                }

                this.foo1 = value;
                this.OnPropertyChanged();
            }
        }

        public Foo Foo2
        {
            get => this.foo2;

            set
            {
                if (ReferenceEquals(value, this.foo2))
                {
                    return;
                }

                this.foo2 = value;
                this.OnPropertyChanged();
            }
        }

        public Foo Foo3
        {
            get => this.foo3;

            set
            {
                if (ReferenceEquals(value, this.foo3))
                {
                    return;
                }

                this.foo3 = value;
                this.OnPropertyChanged();
            }
        }

        public Foo Foo4
        {
            get => this.foo4;

            set
            {
                if (ReferenceEquals(value, this.foo4))
                {
                    return;
                }

                this.foo4 = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}