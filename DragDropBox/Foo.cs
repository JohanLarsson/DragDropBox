namespace DragDropBox
{
    using System;

    [Serializable]
    public class Foo
    {
        public Foo(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}