using DevExpress.Xpo;

namespace AKucher.Tasks.Module.BusinessObjects
{
	[NonPersistent]
	public abstract class BaseObject : XPBaseObject
    {
        public BaseObject(Session session) : base(session)
        {
        }

        [Key(true)]
        [Persistent("Oid")]
        [MemberDesignTimeVisibility(false)]
        private Guid oid = Guid.Empty;

        [PersistentAlias(nameof(oid))]
        public Guid Oid
        {
            get { return oid; }
        }

        public override void AfterConstruction()
        {
            base.AfterConstruction();
            oid = XpoDefault.NewGuid(); //TODO Is it need?
        }
    }
}