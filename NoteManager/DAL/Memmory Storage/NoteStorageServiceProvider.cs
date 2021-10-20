using Microsoft.Extensions.DependencyInjection;

namespace NoteManager.DAL.Memmory_Storage
{
    public static class NoteStorageServiceProvider
    {
        public static void AddNoteStorageService(this IServiceCollection services)
        {
            services.AddSingleton<INoteStorage, NoteMemmoryStorage>();
        }
    }
}

