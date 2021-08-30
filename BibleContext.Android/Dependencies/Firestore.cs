using Android.App;
using Android.Content;
using Android.Gms.Tasks;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BibleContext.Models;
using BibleContext.Droid.Dependencies;
using BibleContext.Services;
using Firebase.Firestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(BibleContext.Droid.Dependencies.Firestore))]
namespace BibleContext.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<Section> sections;
        List<Chapters> chapters;
        List<OldTestBooks> oldTestBooks;
        OldTestBooks oldTestBook;
        bool success = false;
        public Firestore()
        {
            oldTestBooks = new List<OldTestBooks>();
            sections = new List<Section>();
            chapters = new List<Chapters>();
            oldTestBook = new OldTestBooks();
        }


        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if(task.IsSuccessful)
            {
                if (task.Result is DocumentSnapshot)
                {
                    var newBook = Mapping.OldTestBookMapping(task);

                    oldTestBook = newBook;
                }
                else
                {
                    var documents = (QuerySnapshot)task.Result;
                    var getDoc = documents.Documents.FirstOrDefault();
                    var checkDoc = getDoc.Reference.Parent.Id;

                    if (checkDoc == "OldTestamentBooks")
                    {
                        oldTestBooks.Clear();
                        foreach (var doc in documents.Documents)
                        {
                            OldTestBooks newOldTestBooks = new OldTestBooks()
                            {
                                BookName = doc.Get("BookName").ToString(),
                                Abbreviation = doc.Get("Abbreviation").ToString(),
                                BackgroundColor = doc.Get("BackgroundColor").ToString(),
                                Order = (int)doc.Get("Order"),
                                Genre = doc.Get("Genre").ToString(),
                                Id = doc.Id
                            };

                            oldTestBooks.Add(newOldTestBooks);
                        }
                    }
                    if (checkDoc == "Sections")
                    {
                        sections.Clear();
                        foreach (var doc in documents.Documents)
                        {
                            Section newSections = new Section()
                            {
                                Title = doc.Get("Title").ToString(),
                                Verses = doc.Get("Verses").ToString(),
                                Order = (int)doc.Get("Order"),
                                BackgroundColor = doc.Get("BackgroundColor").ToString(),
                                Id = doc.Id
                            };

                            sections.Add(newSections);
                        }
                    }
                    if (checkDoc == "Chapters")
                    {
                        chapters.Clear();
                        foreach (var doc in documents.Documents)
                        {
                            Chapters newChapters = new Chapters()
                            {
                                Chapter = doc.Get("Chapter").ToString(),
                                Order = (int)doc.Get("Order"),
                                Id = doc.Id
                            };

                            chapters.Add(newChapters);
                        }
                    }
                }
            }
            else
            {
                oldTestBooks.Clear();
                sections.Clear();
                chapters.Clear();
            }

            success = true;
        }

        public async Task<List<OldTestBooks>> Read()
        {
            try
            {
                success = false;
                var collection = FirebaseFirestore.Instance.Collection("OldTestamentBooks");
                var query = collection.OrderBy("Order", Query.Direction.Ascending);
                query.Get().AddOnCompleteListener(this);

                #region for loop
                for (int i = 0; i < 40; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (success)
                        break;
                }
                #endregion 

                //await System.Threading.Tasks.Task.Delay(1000);

                return oldTestBooks;
            }
            catch (Exception)
            {
                return oldTestBooks;
            }
        }

        public async Task<OldTestBooks> GetBook(string id)
        {
            try
            {
                success = false;
                var collection = FirebaseFirestore.Instance
                    .Collection("Sections").Document(id);
                collection.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 40; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (success)
                        break;
                }

                return oldTestBook;

            }
            catch (Exception)
            {
                return oldTestBook;
            }
        }

        public async Task<List<Section>> GetSections(string id)
        {
            try
            {
                success = false;
                var collection = FirebaseFirestore.Instance
                    .Collection("OldTestamentBooks").Document(id).Collection("Sections");
                var query = collection.OrderBy("Order", Query.Direction.Ascending);
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 40; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (success)
                        break;
                }

                return sections;
            }
            catch (Exception)
            {
                return sections;
            }
        }

        public async Task<List<Chapters>> GetChapters(string id)
        {
            try
            {
                success = false;
                var collection = FirebaseFirestore.Instance
                    .Collection("OldTestamentBooks").Document(id).Collection("Chapters");
                var query = collection.OrderBy("Order", Query.Direction.Ascending);
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 40; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (success)
                        break;
                }

                return chapters;
            }
            catch (Exception)
            {
                return chapters;
            }
        }

        public bool Insert()
        {
            try
            {
                for (int i = 1; i < 4; i++)
                {
                    var postDocument = new Dictionary<string, Java.Lang.Object>
                    {
                        { "Chapter", i.ToString()},
                        { "Order", i }
                    };

                    var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("OldTestamentBooks")
                        .Document("v67oOkEd6J1BI7x4AEEH")
                        .Collection("Chapters");
                    collection.Add(new Java.Util.HashMap(postDocument));

                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}