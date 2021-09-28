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
        Task<List<OldTestBooks>> ReadOT();
        Task<List<NewTestBooks>> ReadNT();
        Task<OldTestBooks> GetBook(string id);
        Task<List<Section>> GetSectionsOT(string id);
        Task<List<Section>> GetSectionsNT(string id);
        Task<List<SubSection>> GetSubSectionsNT(string bookId, string sectionId);
        Task<List<Chapters>> GetChapters(string id);
        bool Insert();



    }
    public class Firestore
    {
        private static IFirestore firestore = DependencyService.Get<IFirestore>();

        public static async Task<List<OldTestBooks>> ReadOT()
        {
            return await firestore.ReadOT();
        }

        public static async Task<List<NewTestBooks>> ReadNT()
        {
            return await firestore.ReadNT();
        }

        public static async Task<List<Section>> GetSectionsOT(string id)
        {
            return await firestore.GetSectionsOT(id);
        }

        public static async Task<List<Section>> GetSectionsNT(string id)
        {
            return await firestore.GetSectionsNT(id);
        }
        public static async Task<List<Chapters>> GetChapters(string id)
        {
            return await firestore.GetChapters(id);
        }

        public static async Task<List<SubSection>> GetSubSectionsNT(string bookId, string sectionId)
        {
            return await firestore.GetSubSectionsNT(bookId, sectionId);
        }

        public static bool Insert()
        {
            return firestore.Insert();
        }
    }
}
