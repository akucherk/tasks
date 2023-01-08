using DevExpress.Xpo;

namespace AKucher.Tasks.Module.BusinessObjects
{
	public class TaskObject : BaseObject
	{
		public TaskObject(Session session) : base(session)
		{
		}

		private string index;

		public string Index
		{
			get => index;
			set => SetPropertyValue(nameof(Index), ref index, value);
		}

		private string name;

		public string Name
		{
			get => name;
			set => SetPropertyValue(nameof(Name), ref name, value);
		}

		private uint order;

		public uint Order
		{
			get => order;
			set => SetPropertyValue(nameof(Order), ref order, value);
		}

		private Container container;

		[Association(Container.ContainerTasksAssociationName)]
		public Container Container
		{
			get => container;
			set => SetPropertyValue(nameof(Container), ref container, value);
		}
		public const string TaskObjectItemsAssociationName = "TaskObjectItemsAssociationName";

		[Aggregated]
		[Association(TaskObjectItemsAssociationName)]
		public XPCollection<TaskItem> Items => GetCollection<TaskItem>(nameof(Items));
	}
}
