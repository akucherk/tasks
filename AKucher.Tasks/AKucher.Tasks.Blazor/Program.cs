using DevExpress.Xpo.DB;
using DevExpress.Xpo;

namespace AKucher.Tasks.Blazor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            // Initialize default dataLayer
            var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);
            //CreateTestData();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();
        }

        //private static void CreateTestData()
        //{
        //    const string defaultTaskObjectName = "Test-123";
        //    using (var uow = new UnitOfWork())
        //    {
        //        var task = uow.Query<TaskObject>().FirstOrDefault(x => x.Index == defaultTaskObjectName);
        //        if (task == null)
        //        {
        //            task = new TaskObject(uow);
        //            task.Index = defaultTaskObjectName;
        //            task.Items.Add(new TaskItem(uow) { Description = "Test item" });
        //            task.Items.Add(new TaskItem(uow) { Description = "Test item 2" });
        //            task.Items.Add(new TaskItem(uow) { Description = "Test item 3" });
        //            uow.CommitChanges();
        //        }
        //    }
        //}
    }
}