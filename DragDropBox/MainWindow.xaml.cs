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
            if (e.Source is ContentPresenter contentPresenter)
            {
                DragDrop.DoDragDrop(contentPresenter, new DataObject("foo",  contentPresenter.Content), DragDropEffects.Move);
            }
        }

        private void OnDragEnter(object sender, DragEventArgs e)
        {
        }

        private void OnDrop(object sender, DragEventArgs e)
        {
            if (e.Source is ContentPresenter contentPresenter)
            {
                contentPresenter.SetCurrentValue(ContentPresenter.ContentProperty, e.Data.GetData("foo"));
            }
        }
    }
}
