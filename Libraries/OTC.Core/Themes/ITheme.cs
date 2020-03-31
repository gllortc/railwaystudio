using Rwm.Otc.Layout;
using System.Drawing;

namespace Rwm.Otc.Themes
{

   /// <summary>
   /// Interface implemented by all OTC themes.
   /// </summary>
   public interface ITheme
   {

      #region Properties

      /// <summary>
      /// Gets the theme unique identifier (GUID).
      /// </summary>
      string ID { get; }

      /// <summary>
      /// Gets the name of the theme.
      /// </summary>
      string Name { get; }

      /// <summary>
      /// Gets a brief description of the theme.
      /// </summary>
      string Description { get; }

      /// <summary>
      /// Gets the assembly version.
      /// </summary>
      string Version { get; }

      /// <summary>
      /// Gets the element size in pixels.
      /// </summary>
      Size ElementSize { get; }

      #endregion

      #region Methods

      /// <summary>
      /// Gets the element image in function of his status.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <returns>An image representing the element and all his properties.</returns>
      Image GetElementImage(Element element);

      /// <summary>
      /// Gets the element image in function of his status.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <param name="designImage">A value indicating if the image must be represented in design mode or working mode.</param>
      /// <returns>An image representing the element and all his properties.</returns>
      Image GetElementImage(Element element, bool designImage);

      /// <summary>
      /// Gets the element image in function of his status.
      /// </summary>
      /// <param name="element">Element.</param>
      /// <param name="status">The status to be represented.</param>
      /// <returns>An image representing the element and all his properties.</returns>
      Image GetElementImage(Element element, int status);

      #endregion

   }
}
