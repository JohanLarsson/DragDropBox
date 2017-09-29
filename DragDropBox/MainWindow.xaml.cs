namespace DragDropBox
{
    using System.Diagnostics;
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
            if (e.Source is ContentPresenter contentPresenter)
            {
                Debug.WriteLine("DoDragDrop");
                if (DragDrop.DoDragDrop(contentPresenter, new DataObject(typeof(Foo), contentPresenter.Content), DragDropEffects.Move) == DragDropEffects.Move)
                {
                    contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, null);
                }
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
            if (e.Source is ContentPresenter contentPresenter &&
                e.Data.GetDataPresent(typeof(Foo)))
            {
                Debug.WriteLine($"DragEnter {contentPresenter.Name}");
                contentPresenter.SetCurrentValue(AllowDropProperty, true);
            }
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Source is ContentPresenter contentPresenter)
            {
                Debug.WriteLine($"Drop: {contentPresenter.Name}");
                contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, e.Data.GetData(typeof(Foo)));
                e.Effects = DragDropEffects.Move;
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
