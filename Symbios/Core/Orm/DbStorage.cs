using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using Symbios.Core.Models;

namespace Symbios.Core.Orm {

    public class DbStorage : IDataStorage {
        private readonly TextWriter logWriter;

        public DbStorage(TextWriter logWriter) {
            CheckForNull(logWriter, "logWriter");
            this.logWriter = logWriter;
        }

        public IList<Category> FetchAllCategories() {
            return CreateContext().Categories.ToList();
        }

        public void SaveAppWithItems(App app) {
            CheckForNull(app, "app");
            var context = CreateContext();
            context.Apps.InsertOnSubmit(app);
            context.SubmitChanges();
        }

        public IList<App> FetchAppsByCategoryTag(string tag) {
            CheckForNull(tag, "tag");
            var context = CreateContext();
            return (from app in context.Apps
                    where app.CategoryTag == tag
                    orderby app.Title
                    select app).ToList();
        }

        public IList<App> FetchRecentApps(int maxCount) {
            var context = CreateContext();
            return (from app in context.Apps
                    orderby app.Created descending
                    select app).Take(maxCount).ToList();
        }

        public Screenshot FetchScreenshotById(int id) {
            var context = CreateContext();
            return (from screenshot in context.Screenshots
                    where screenshot.Id == id
                    select screenshot).SingleOrDefault();
        }

        public AppFile FetchAppFileById(int id) {
            var context = CreateContext();
            return (from file in context.AppFiles
                    where file.Id == id
                    select file).SingleOrDefault();
        }

        public Category FetchCategoryByTag(string tag) {
            CheckForNull(tag, "tag");
            var context = CreateContext();
            return context.Categories.Where(cat => cat.Tag == tag)
                .SingleOrDefault();
        }

        public IList<App> FetchAppsBySearchPattern(string pattern) {
            CheckForNull(pattern, "pattern");
            var context = CreateContext();
            return (from app in context.Apps
                    where (app.Title.Contains(pattern) ||
                           app.Description.Contains(pattern))
                    orderby app.Title
                    select app).ToList();
        }

        public IList<Planet> FetchAllPlanets() {
            return CreateContext().Planets
                .OrderBy(planet => planet.Name).ToList();
        }

        public void UpdatePlanets(IList<Planet> planets) {
            CheckForNull(planets, "planets");
            var context = CreateContext();
            context.Planets.AttachAll(planets);
            context.Refresh(RefreshMode.KeepCurrentValues, planets);
            context.SubmitChanges();
        }

        public bool UserExists(string name, string password) {
            CheckForNull(name, "name");
            CheckForNull(password, "password");
            int count = CreateContext().Users
                .Where(x => x.Name == name && x.Password == password)
                .Count();
            return count > 0;
        }

        private SymbiosDataContext CreateContext() {
            return new SymbiosDataContext {
                Log = logWriter
            };
        }

        private static void CheckForNull(object var, string varName) {
            if (var == null) {
                throw new ArgumentNullException(varName);
            }
        }

    }
}