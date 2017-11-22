namespace DragDropBox
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using Gu.Wpf.Adorners;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private static bool TryGetDropTarget(object sender, out ContentPresenter target)
        {
            target = null;
            if (sender is ContentPresenter cp &&
                cp.Content == null)
            {
                target = cp;
            }

            return target != null;
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.Source is ContentPresenter contentPresenter &&
                contentPresenter.Content != null)
            {
                var data = new DataObject(typeof(Foo), contentPresenter.Content);
                using (var adorner = DragAdorner.Create(contentPresenter))
                {
                    data.SetData(adorner);
                    contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, null);
                    DragDrop.DoDragDrop(contentPresenter, data, DragDropEffects.Move);
                    if (!data.TryGetData<ContentPresenter>(out _) &&
                        data.TryGetData<Foo>(out var foo))
                    {
                        contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, foo);
                    }
                }
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (TryGetDropTarget(e.Source, out var contentPresenter) &&
                e.Data.TryGetData<ContentDragAdorner>(out var adorner))
            {
                adorner.SnapTo(contentPresenter);
                e.Effects = DragDropEffects.Move;
                e.Handled = true;
            }
        }

        private void OnDragLeave(object sender, DragEventArgs e)
        {
            if (TryGetDropTarget(e.Source, out var contentPresenter) &&
                e.Data.TryGetData<ContentDragAdorner>(out var adorner))
            {
                adorner.RemoveSnap(contentPresenter);
                e.Effects = DragDropEffects.None;
                e.Handled = true;
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (TryGetDropTarget(e.Source, out var contentPresenter) &&
                e.Data.TryGetData<Foo>(out var foo))
            {
                contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, foo);
                e.Effects = DragDropEffects.Move;
                e.Data.SetData(contentPresenter);
                e.Handled = true;
            }
        }
    }
}
