using System.Linq;
using System.Web.Mvc;

namespace DryRun.Infrastructure.Engine
{
    public class OnlyCSharpRazor : RazorViewEngine
    {
        #region Private Fields

        private readonly string _extension;

        #endregion Private Fields

        #region Public Constructors

        public OnlyCSharpRazor()
        {
            _extension = "cshtml";

            ConfigureFormats();
        }

        public OnlyCSharpRazor(string viewTypeExtension)
        : base()
        {
            _extension = viewTypeExtension;

            ConfigureFormats();
        }

        #endregion Public Constructors

        #region Private Methods

        private void ConfigureFormats()
        {
            AreaMasterLocationFormats = Filter(base.AreaMasterLocationFormats);
            AreaPartialViewLocationFormats = Filter(base.AreaPartialViewLocationFormats);
            AreaViewLocationFormats = Filter(base.AreaViewLocationFormats);
            FileExtensions = Filter(base.FileExtensions);
            MasterLocationFormats = Filter(base.MasterLocationFormats);
            PartialViewLocationFormats = Filter(base.PartialViewLocationFormats);
            ViewLocationFormats = Filter(base.ViewLocationFormats);
        }

        #endregion Private Methods

        #region Private Methods

        private string[] Filter(string[] source)
        {
            return source.Where(
                s =>
                    s.Contains(_extension)).ToArray();
        }

        #endregion Private Methods
    }
}