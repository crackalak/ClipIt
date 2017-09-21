using System;
using System.ComponentModel;

namespace ClipIt
{
    public class BindingListWithRemoving<T> : BindingList<T>
    {
        protected override void RemoveItem(int index)
        {
            BeforeRemove?.Invoke(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, 0, index));

            base.RemoveItem(index);
        }

        public event EventHandler<ListChangedEventArgs> BeforeRemove;
    }
}
