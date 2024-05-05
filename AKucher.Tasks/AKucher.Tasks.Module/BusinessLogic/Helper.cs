using AKucher.Tasks.Module.BusinessObjects;

using DevExpress.Xpo;

using System.Drawing.Text;
using System.Runtime.CompilerServices;

namespace AKucher.Tasks.Module.BusinessLogic
{
    public static class Helper
    {
        public static void CreateTestData()
        {
            using (var uow = new UnitOfWork())
            {
                for (uint i = 1; i <= 5; i++)
                {
                    GetOrCreateTask(uow, i);
                }
            }
        }

        private static void GetOrCreateTask(UnitOfWork uow, uint taskNumber)
        {
            var taskIndex = "WMG-" + taskNumber;
            var task = uow.Query<TaskObject>().FirstOrDefault(x => x.Index == taskIndex);
            if (task == null)
            {
                task = new TaskObject(uow)
                {
                    Index = taskIndex,
                    Order = taskNumber
                };
                for (uint i = 1; i <= 3; i++)
                {
                    task.Items.Add(new TaskItem(uow)
                    {
                        Order = i,
                        Description = $"Test item {taskNumber}-{i}"
                    });
                }
                uow.CommitChanges();
            }
        }
    }
}
