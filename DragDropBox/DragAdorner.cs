namespace DragDropBox
{
    using System.Windows;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;

    public class DragAdorner : Adorner
    {
        private TranslateTransform mouseOffset;

        public DragAdorner(UIElement adornedElement)
            : base(adornedElement)
        {
            this.IsHitTestVisible = false;
            var position = Mouse.GetPosition(adornedElement);
            this.mouseOffset = new TranslateTransform(position.X, position.Y);
        }

        protected override int VisualChildrenCount => 1;

        public override GeneralTransform GetDesiredTransform(GeneralTransform transform)
        {
            return this.mouseOffset;
        }

        protected override Visual GetVisualChild(int index)
        {
            return this.AdornedElement;
        }
    }
}