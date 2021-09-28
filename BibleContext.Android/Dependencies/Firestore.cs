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
        List<SubSection> subSections;
        List<Section> sections;
        List<Chapters> chapters;
        List<OldTestBooks> oldTestBooks;
        List<NewTestBooks> newTestBooks;
        bool success = false;
        public Firestore()
        {
            oldTestBooks = new List<OldTestBooks>();
            newTestBooks = new List<NewTestBooks>();
            sections = new List<Section>();
            subSections = new List<SubSection>();
            chapters = new List<Chapters>();
        }


        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if(task.IsSuccessful)
            {
                var documents = (QuerySnapshot)task.Result;
                var getDoc = documents.Documents.FirstOrDefault();
                if (getDoc == null)
                {
                    success = true;
                    subSections = new List<SubSection>();
                    return;
                }
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
                if(checkDoc == "NewTestamentBooks")
                {
                    newTestBooks.Clear();
                    foreach (var doc in documents.Documents)
                    {
                        NewTestBooks newNewTestBooks = new NewTestBooks()
                        {
                            BookName = doc.Get("BookName").ToString(),
                            Abbreviation = doc.Get("Abbreviation").ToString(),
                            BackgroundColor = doc.Get("BackgroundColor").ToString(),
                            Order = (int)doc.Get("Order"),
                            Genre = doc.Get("Genre").ToString(),
                            Id = doc.Id
                        };

                        newTestBooks.Add(newNewTestBooks);
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
                            Id = doc.Id,
                            HasSubsections = (bool)doc.Get("HasSubsections"),
                            SubSectionCount = (int)doc.Get("SubSectionCount")
                        };

                        sections.Add(newSections);
                    }
                }
                if (checkDoc == "SubSections")
                {
                    subSections.Clear();
                    foreach (var doc in documents.Documents)
                    {
                        SubSection newSubSections = new SubSection()
                        {
                            Title = doc.Get("Title").ToString(),
                            Verses = doc.Get("Verses").ToString(),
                            Order = (int)doc.Get("Order"),
                            BackgroundColor = doc.Get("BackgroundColor").ToString(),
                            Id = doc.Id
                        };

                        subSections.Add(newSubSections);
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
            else
            {
                oldTestBooks.Clear();
                newTestBooks.Clear();
                sections.Clear();
                subSections.Clear();
                chapters.Clear();
            }

            success = true;
        }

        public async Task<List<OldTestBooks>> ReadOT()
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
                    await System.Threading.Tasks.Task.Delay(0);
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

        public async Task<List<NewTestBooks>> ReadNT()
        {
            try
            {
                success = false;
                var collection = FirebaseFirestore.Instance.Collection("NewTestamentBooks");
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

                return newTestBooks;
            }
            catch (Exception)
            {
                return newTestBooks;
            }
        }


        public async Task<List<Section>> GetSectionsOT(string id)
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

        public async Task<List<Section>> GetSectionsNT(string id)
        {
            try
            {
                success = false;
                var collection = FirebaseFirestore.Instance
                    .Collection("NewTestamentBooks").Document(id).Collection("Sections");
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

        public async Task<List<SubSection>> GetSubSectionsNT(string bookId, string sectionId)
        {
            try
            {
                success = false;
                var collection = FirebaseFirestore.Instance
                    .Collection("NewTestamentBooks").Document(bookId).Collection("Sections").Document(sectionId).Collection("SubSections");
                var query = collection.OrderBy("Order", Query.Direction.Ascending);
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 40; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (success)
                        break;
                }

                return subSections;
            }
            catch (Exception)
            {
                return subSections;
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
                for (int i = 1; i < 10; i++)
                {
                    var postDocument = new Dictionary<string, Java.Lang.Object>
                    {
                        { "Chapter", i.ToString()},
                        { "Order", i }
                    };

                    var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("OldTestamentBooks")
                        .Document("4l3tOIrUaakxZZoVjxIA")
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

        public Task<OldTestBooks> GetBook(string id)
        {
            throw new NotImplementedException();
        }
    }
}