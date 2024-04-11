using System.Globalization;

namespace SpecIFicator.DefaultPlugin.BlazorComponents.Document.Items
{
    internal static class DocumentItemExtensions
    {
        public static string GetPrimaryText(this IDocumentItem documentItem, string key)
        {
            string result = "";

            try
            {
                CultureInfo cultureInfo = new CultureInfo(documentItem.DataContext.PrimaryLanguage);

                result = documentItem.ResourceManager.GetString(key, cultureInfo);
            }
            catch
            {

            }

            return result;
        }

        public static string GetSecondaryText(this IDocumentItem documentItem, string key)
        {
            string result = "";

            try
            {
                CultureInfo cultureInfo = new CultureInfo(documentItem.DataContext.SecondaryLanguage);

                result = documentItem.ResourceManager.GetString(key, cultureInfo);
            }
            catch
            {

            }

            return result;
        }
    }
}
