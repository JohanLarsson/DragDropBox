namespace DragDropBox
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is ContentPresenter contentPresenter &&
                contentPresenter.Content != null)
            {
                var data = new DataObject(typeof(Foo), contentPresenter.Content);
                DragDrop.DoDragDrop(contentPresenter, data, DragDropEffects.Move);
                var target = data.GetData(typeof(UIElement));
                if (target != null &&
                    !ReferenceEquals(target, contentPresenter))
                {
                    contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, null);
                }
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Source is ContentPresenter contentPresenter &&
                contentPresenter.Content == null)
            {
                contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, e.Data.GetData(typeof(Foo)));
                e.Effects = DragDropEffects.Move;
                e.Data.SetData(typeof(UIElement), contentPresenter);
                e.Handled = true;
            }
        }

        private void OnDragLeave(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;
            e.Handled = true;
        }
    }
}
