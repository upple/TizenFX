using System;

namespace ElmSharp
{
    public abstract class GenItem : ItemObject
    {
        internal GenItem(object data, GenItemClass itemClass) : base(IntPtr.Zero)
        {
            Data = data;
            ItemClass = itemClass;
        }

        public GenItemClass ItemClass { get; protected set; }
        public object Data { get; protected set; }
        public abstract bool IsSelected { get; set; }
        public abstract void Update();
        protected override void OnInvalidate()
        {
            ItemClass?.SendItemDeleted(Data);
            Data = null;
            ItemClass = null;
        }
    }
}
