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

		private TaskObject task;

		[Association(TaskObject.TaskObjectItemsAssociationName)]
		public TaskObject Task
		{
			get => task;
			set => SetPropertyValue(nameof(Task), ref task, value);
		}
	}
}
