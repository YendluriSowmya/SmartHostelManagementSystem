using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SmartHostelManagementSystem.Data
{
    public static class FileStorage
    {
        public static async Task SaveAsync<T>(string filename, List<T> data)
        {
            var json = JsonSerializer.Serialize(data);
            await File.WriteAllTextAsync(filename, json);
        }

        public static async Task<List<T>> LoadAsync<T>(string filename)
        {
            if (!File.Exists(filename))
                return new List<T>();

            var json = await File.ReadAllTextAsync(filename);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }
    }
}
