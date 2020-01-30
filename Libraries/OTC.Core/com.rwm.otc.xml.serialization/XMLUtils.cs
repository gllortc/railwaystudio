﻿using System;
using System.Xml.Linq;

namespace Rwm.Otc.xml.serialization
{

   /// <summary>
   /// Provides utility methods for manipulating XML.
   /// There are four methods for each unit. UnitExists, FindUnit, CanCreateUnit, CreateUnit
   /// Units are: Location, Element, and Attribute
   /// </summary>
   internal class XMLUtils
   {
      /// <summary>
      /// Determines whether the location specified exists in the given XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <returns>a value indicating whether the location specified exists in the given XML element</returns>
      public static bool LocationExists(XElement baseElement, string location)
      {
         XElement newLoc = FindLocation(baseElement, location);
         return newLoc != null;
      }

      /// <summary>
      /// Finds the location specified in the given XML element specified.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <returns>the XML element corresponding to the specified location, or <c>null</c> if it is not found</returns>
      public static XElement FindLocation(XElement baseElement, string location)
      {
         if (baseElement == null || location == null)
            throw new ArgumentNullException();

         string[] locSteps = location.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

         XElement currentLocation = baseElement;
         foreach (string loc in locSteps)
         {
            if (loc == ".")
            {
               continue;
            }
            else if (loc == "..")
            {
               currentLocation = currentLocation.Parent;
               if (currentLocation == null)
                  break;
            }
            else
            {
               currentLocation = currentLocation.Element(loc);
               if (currentLocation == null)
                  break;
            }
         }

         return currentLocation;
      }

      /// <summary>
      /// Determines whether the specified location can be created in the specified XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <returns>
      /// <c>true</c> if the specified location can be created in the specified XML element; otherwise, <c>false</c>.
      /// </returns>
      public static bool CanCreateLocation(XElement baseElement, string location)
      {
         string[] locSteps = location.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

         XElement currentLocation = baseElement;
         foreach (string loc in locSteps)
         {
            if (loc == ".")
            {
               continue;
            }
            else if (loc == "..")
            {
               currentLocation = currentLocation.Parent;
               if (currentLocation == null)
                  return false;
            }
            else
            {
               currentLocation = currentLocation.Element(loc);
               if (currentLocation == null)
                  return true;
            }
         }

         return true;
      }

      /// <summary>
      /// Creates and returns XML element corresponding to the sepcified location in the given XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <returns>XML element corresponding to the sepcified location created in the given XML element</returns>
      public static XElement CreateLocation(XElement baseElement, string location)
      {
         string[] locSteps = location.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

         XElement currentLocation = baseElement;
         foreach (string loc in locSteps)
         {
            if (loc == ".")
            {
               continue;
            }
            else if (loc == "..")
            {
               currentLocation = currentLocation.Parent;
               if (currentLocation == null)
                  break;
            }
            else
            {
               XElement newLoc = currentLocation.Element(loc);
               if (newLoc == null)
               {
                  newLoc = new XElement(loc);
                  currentLocation.Add(newLoc);
                  currentLocation = newLoc;
               }
            }
         }

         return currentLocation;
      }

      /// <summary>
      /// Determines whether the attribute with the given name located in the given location string exists in the given XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="attrName">Name of the attribute.</param>
      /// <returns>
      /// a value indicating whether the attribute with the given name located in the given location string exists in the given XML element.
      /// </returns>
      public static bool AttributeExists(XElement baseElement, string location, string attrName)
      {
         return FindAttribute(baseElement, location, attrName) != null;
      }

      /// <summary>
      /// Finds the attribute with the given name located in the given location string in the given XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="attrName">Name of the attribute.</param>
      /// <returns>a value indicating whether the attribute with the given name located in 
      /// the given location string in the given XML element has been found.</returns>
      public static XAttribute FindAttribute(XElement baseElement, string location, string attrName)
      {
         XElement newLoc = FindLocation(baseElement, location);
         if (newLoc == null)
            return null;

         return newLoc.Attribute(attrName);
      }

      /// <summary>
      /// Determines whether the attribute with the given name can be created in the location 
      /// specified by the given location string in the given XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="attrName">Name of the attribute.</param>
      /// <returns>
      /// <c>true</c> if the attribute with the given name can be created in the location 
      /// specified by the given location string in the given XML element; otherwise, <c>false</c>.
      /// </returns>
      public static bool CanCreateAttribute(XElement baseElement, string location, string attrName)
      {
         XElement newLoc = FindLocation(baseElement, location);
         if (newLoc == null) //if the location does not exist
         {
            if (CanCreateLocation(baseElement, location)) // see if you can create the location
            {
               // if you can create the location you can create the attribute too
               return true;
            }
            else
            {
               // if you can't create the location you can't create the attribute either
               return false;
            }
         }

         return newLoc.Attribute(attrName) == null; // i.e., check if the attribute does not exist
      }

      /// <summary>
      /// Creates and returns the attribute with the given name in the location 
      /// specified by the given location string in the given XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="attrName">Name of the attribute.</param>
      /// <param name="attrValue">The value to be assigned to the attribute.</param>
      /// <returns>returns the attribute with the given name in the location 
      /// specified by the given location string in the given XML element.</returns>
      public static XAttribute CreateAttribute(XElement baseElement, string location, string attrName, object attrValue)
      {
         XElement newLoc = FindLocation(baseElement, location);
         if (newLoc == null)
         {
            if (CanCreateLocation(baseElement, location))
            {
               newLoc = CreateLocation(baseElement, location);
            }
            else
            {
               return null;
            }
         }

         if (newLoc.Attribute(attrName) != null) // i.e., the attribute already exists 
            return null; // we cannot create another one with the same name

         XAttribute newAttr = new XAttribute(attrName, attrValue ?? String.Empty);
         newLoc.Add(newAttr);
         return newAttr;
      }

      /// <summary>
      /// Finds the element with the given name located in the given location string in the given XML element.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="elemName">Name of the element.</param>
      /// <returns>a value indicating whether the element with the given name located in 
      /// the given location string in the given XML element has been found</returns>
      public static XElement FindElement(XElement baseElement, string location, string elemName)
      {
         return FindLocation(baseElement, StringUtils.CombineLocationAndElementName(location, elemName));
      }

      /// <summary>
      /// Determines whether the XML element with the given name located in the 
      /// given location string in the given XML element exists.
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="elemName">Name of the element.</param>
      /// <returns>a value indicating whether the XML element with the given name located in the 
      /// given location string in the given XML element exists</returns>
      public static bool ElementExists(XElement baseElement, string location, string elemName)
      {
         return FindElement(baseElement, location, elemName) != null;
      }

      /// <summary>
      /// Determines whether the XML element with the given name located in the 
      /// given location string in the given XML element can be created
      /// </summary>
      /// <param name="baseElement">The XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="elemName">Name of the element.</param>
      /// <returns>
      /// <c>true</c> if the XML element with the given name located in the given 
      /// location string in the given XML element can be created; otherwise, <c>false</c>.
      /// </returns>
      public static bool CanCreateElement(XElement baseElement, string location, string elemName)
      {
         return CanCreateLocation(baseElement, StringUtils.CombineLocationAndElementName(location, elemName));
      }

      /// <summary>
      /// Creates and returns the XML element with the given name located in the 
      /// given location string in the given XML element.
      /// </summary>
      /// <param name="baseElement">The parent XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="elemName">Name of the element to create.</param>
      /// <returns>returns the XML element with the given name located in the 
      /// given location string in the given XML element</returns>
      public static XElement CreateElement(XElement baseElement, string location, string elemName)
      {
         return CreateLocation(baseElement, StringUtils.CombineLocationAndElementName(location, elemName));
      }

      /// <summary>
      /// Creates and returns the XML element with the given name located in the 
      /// given location string in the given XML element.
      /// </summary>
      /// <param name="baseElement">The parent XML element.</param>
      /// <param name="location">The location string.</param>
      /// <param name="elemName">Name of the element to create.</param>
      /// <param name="elemValue">The element value to be assigned to the created element.</param>
      /// <returns>returns the XML element with the given name located in the 
      /// given location string in the given XML element.</returns>
      public static XElement CreateElement(XElement baseElement, string location, string elemName, object elemValue)
      {
         XElement elem = CreateElement(baseElement, location, elemName);
         if (elem != null)
            elem.SetValue(elemValue);
         return elem;
      }

      /// <summary>
      /// Moves all the children of src (including all its elements and attributes) to the 
      /// destination element, dst.
      /// </summary>
      /// <param name="src">The source element.</param>
      /// <param name="dst">The destination element.</param>
      public static void MoveDescendants(XElement src, XElement dst)
      {
         foreach (XAttribute attr in src.Attributes())
         {
            if (dst.Attribute(attr.Name) != null)
            {
               throw new OTCAttributeAlreadyExistsException(attr.Name.ToString());
            }

            dst.Add(attr);
         }

         foreach (XElement elem in src.Elements())
         {
            dst.Add(elem);
         }
      }

      /// <summary>
      /// Determines whether the specified element has neither any child attributes nor any child elements.
      /// </summary>
      /// <param name="elem">The element.</param>
      /// <returns>
      /// <c>true</c> if the specified element has neither any child attributes nor any child elements; otherwise, <c>false</c>.
      /// </returns>
      public static bool IsElementCompletelyEmpty(XElement elem)
      {
         return !elem.HasAttributes && !elem.HasElements && elem.IsEmpty;
      }
   }

}
