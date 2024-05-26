using DevExpress.Xpo;

namespace AKucher.Tasks.Module.BusinessObjects
{
    public class TaskItem : BaseObject
    {
        public TaskItem(Session session) : base(session)
        {
        }

        private uint order;

        public uint Order
        {
            get => order;
            set => SetPropertyValue(nameof(Order), ref order, value);
        }

        private string description;

        public string Description
        {
            get => description;
            set => SetPropertyValue(nameof(Description), ref description, value);
        }

        private bool completed;

        public bool Completed
        {
            get => completed;
            set => SetPropertyValue(nameof(Completed), ref completed, value);
        }

        private TaskObject task;

        [Association(TaskObject.TaskObjectItemsAssociationName)]
        public TaskObject Task
        {
            get => task;
            set => SetPropertyValue(nameof(Task), ref task, value);
        }

        protected override void OnChanged(string propertyName, object oldValue, object newValue)
        {
            base.OnChanged(propertyName, oldValue, newValue);

            if (IsLoading || IsSaving)
            {
                return;
            }

            ((UnitOfWork)Session).CommitChanges();
        }
    }
}
