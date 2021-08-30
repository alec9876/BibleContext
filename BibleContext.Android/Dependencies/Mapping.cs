using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BibleContext.Models;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibleContext.Droid.Dependencies
{
    public class Mapping
    {
        public static OldTestBooks OldTestBookMapping(Android.Gms.Tasks.Task task)
        {
            var doc = (DocumentSnapshot)task.Result;
                OldTestBooks newOldTestBook = new OldTestBooks()
                {
                    BookName = doc.Get("BookName").ToString(),
                    Abbreviation = doc.Get("Abbreviation").ToString(),
                    BackgroundColor = doc.Get("BackgroundColor").ToString(),
                    Order = (int)doc.Get("Order"),
                    Id = doc.Id
                };

            return newOldTestBook;
        }
    }
}