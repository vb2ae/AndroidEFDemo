using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidEF.Standard;

namespace AndroidEFDemo
{
    public class ToDoAdapter : BaseAdapter<ToDoItem>
    {

        private readonly List<ToDoItem> data;
        private readonly Activity context;


        public ToDoAdapter(Activity activity, IEnumerable<ToDoItem> todoItems)
        {
            data = todoItems.OrderBy(s => s.Id).ToList();
            context = activity;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override ToDoItem this[int position]
        {
            get { return data[position]; }
        }

        public override int Count
        {
            get { return data.Count; }
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;
            if (view == null)
            {
                view = context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItemChecked, null);
            }

            var todoItem = data[position];
            var text = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            text.Text = todoItem.Description;

            return view;
        }
    }
}