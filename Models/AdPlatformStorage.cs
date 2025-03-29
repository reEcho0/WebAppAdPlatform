namespace WebAppAdPlatforms.Models
{
    public class AdPlatformStorage
    {
        // Словарь: название площадки -> список локаций
        private Dictionary<string, HashSet<string>> _platforms = new();

        // Загрузка данных из текстового файла
        public void LoadFromText(string text)
        {
            var newPlatforms = new Dictionary<string, HashSet<string>>();

            try
            {
                var lines = text.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                foreach (var line in lines)
                {
                    var parts = line.Split(':');
                    if (parts.Length != 2) continue;

                    var platformName = parts[0].Trim();
                    var locations = parts[1].Split(',', StringSplitOptions.RemoveEmptyEntries)
                                           .Select(l => l.Trim())
                                           .Where(l => !string.IsNullOrEmpty(l))
                                           .ToHashSet();

                    if (!string.IsNullOrEmpty(platformName) && locations.Any())
                    {
                        newPlatforms[platformName] = locations;
                    }
                }

                // Атомарная замена данных
                lock (_platforms)
                {
                    _platforms = newPlatforms;
                }
            }
            catch (Exception)
            {
                // При ошибке оставляем старые данные
            }
        }

        // Поиск подходящих площадок для локации
        public List<string> FindPlatforms(string location)
        {
            if (string.IsNullOrEmpty(location))
                return new List<string>();

            lock (_platforms)
            {
                return _platforms
                    .Where(p => p.Value.Any(loc =>
                        location.StartsWith(loc) || loc.StartsWith(location)))
                    .Select(p => p.Key)
                    .OrderBy(p => p)
                    .ToList();
            }
        }
    }
}
