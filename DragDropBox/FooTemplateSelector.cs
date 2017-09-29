namespace DragDropBox
{
    using System.Windows;
    using System.Windows.Controls;

    public class FooTemplateSelector : DataTemplateSelector
    {
        public DataTemplate FooTemplate { get; set; }

        public DataTemplate EmptyTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Foo)
            {
                return this.FooTemplate;
            }

            return this.EmptyTemplate;
        }
    }
}
