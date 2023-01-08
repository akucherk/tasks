using DevExpress.Xpo;

namespace AKucher.Tasks.Module.BusinessObjects
{
	public class Container : BaseObject
	{
		public Container(Session session) : base(session)
		{
		}

		private string name;

		public string Name
		{
			get => name;
			set => SetPropertyValue(nameof(Name), ref name, value);
		}

		private bool isActive;

		public bool IsActive
		{
			get => isActive;
			set => SetPropertyValue(nameof(IsActive), ref isActive, value);
		}

		public const string ContainerTasksAssociationName = "ContainerTasksAssociationName";

		[Aggregated]
		[Association(ContainerTasksAssociationName)]
		public XPCollection<TaskObject> Tasks => GetCollection<TaskObject>(nameof(Tasks));
	}
}
