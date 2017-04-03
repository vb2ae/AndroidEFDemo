using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using AndroidEF.Standard;
using System.Linq;

namespace AndroidEFDemo
{
    [Activity(Label = "EF Core Demo", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : ListActivity
    {
        ToDoAdapter adapter;


        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Collections.Generic.List<ToDoItem> lst = null;
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "todo.db");
            using (var db = new AndroidEF.Standard.ToDoContext(path))
            {
                await db.Database.EnsureCreatedAsync();
                lst = db.ToDoItems.ToList();
            }

            adapter = new ToDoAdapter(this, lst);
            ListAdapter = adapter;
            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);
            //btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, System.EventArgs e)
        {
            EditText editDescription = FindViewById<EditText>(Resource.Id.editDescription);
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "todo.db");
            using (var db = new AndroidEF.Standard.ToDoContext(path))
            {
                ToDoItem todo = new ToDoItem() { Completed = false, Description = editDescription.Text };
                db.ToDoItems.Add(todo);
                db.SaveChanges();
            }
        }

    }
}

