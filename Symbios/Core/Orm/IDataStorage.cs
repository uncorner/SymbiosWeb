using System.Collections.Generic;
using Symbios.Core.Models;

namespace Symbios.Core.Orm {

    public interface IDataStorage {

        IList<Category> FetchAllCategories();

        void SaveAppWithItems(App app);

        IList<App> FetchAppsByCategoryTag(string tag);

        IList<App> FetchRecentApps(int maxCount);

        Screenshot FetchScreenshotById(int id);

        AppFile FetchAppFileById(int id);

        Category FetchCategoryByTag(string tag);

        IList<App> FetchAppsBySearchPattern(string pattern);

        IList<Planet> FetchAllPlanets();

        void UpdatePlanets(IList<Planet> planets);

        bool UserExists(string name, string password);

    }
}
