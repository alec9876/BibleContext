using BibleContext.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BibleContext.Services
{
    public interface IFirestore
    {
        Task<List<OldTestBooks>> Read();
        Task<OldTestBooks> GetBook(string id);
        Task<List<Section>> GetSections(string id);
        Task<List<Chapters>> GetChapters(string id);
        bool Insert();



    }
    public class Firestore
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();

        public static async Task<List<OldTestBooks>> Read()
        {
            return await firestore.Read();
        }

        public static async Task<OldTestBooks> GetBook(string id)
        {
            return await firestore.GetBook(id);
        }

        public static async Task<List<Section>> GetSections(string id)
        {
            return await firestore.GetSections(id);
        }
        public static async Task<List<Chapters>> GetChapters(string id)
        {
            return await firestore.GetChapters(id);
        }

        public static bool Insert()
        {
            return firestore.Insert();
        }
    }
}
