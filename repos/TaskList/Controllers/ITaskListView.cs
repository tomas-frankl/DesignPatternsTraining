using System.Collections.Generic;

namespace TaskList.Presenters
{
    //metadata interface pattern
    public interface ITaskListView { }

    public interface ITaskListView<T>
    {
        void OnListUpdated(IEnumerable<T> list);
        void OnAddAction(T item);
        void OnEditAction(T item);
        void OnDeleteAction(T item);
    }
}
