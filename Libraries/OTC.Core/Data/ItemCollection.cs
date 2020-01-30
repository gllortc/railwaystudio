using System.Collections;
using System.Collections.Generic;
using Rwm.Otc.Data.ORM;

namespace Rwm.Otc.Data
{
   /// <summary>
   /// Implements an useful collection for identifieable database items.
   /// </summary>
   /// <typeparam name="T">Type of items in collection.</typeparam>
   public class ItemCollection<T> : IEnumerable<T>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <c>ItemCollection</c>.
      /// </summary>
      public ItemCollection()
      {
         this.Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the owner project.
      /// </summary>
      public Project Project { get; private set; }

      /// <summary>
      /// Gets the number of items contained in the current collection.
      /// </summary>
      public int Count
      {
         get { return this.Items.Count; }
      }

      /// <summary>
      /// Internal list.
      /// </summary>
      private Dictionary<long, T> Items { get; set; }

      #endregion

      #region Methods

      /// <summary>
      /// Gets a collection element by its ID.
      /// </summary>
      /// <param name="id">Element unique ID.</param>
      /// <returns>The requested collection element or <c>null</c> if the ID doesn't exists.</returns>
      public T Get(long id)
      {
         if (this.Items.ContainsKey(id)) return this.Items[id];
         return default(T);
      }

      /// <summary>
      /// Adds a new item in the collection.
      /// </summary>
      /// <param name="t">Element to add.</param>
      internal void Add(T t)
      {
         // Add new switchboard into collection
         if (this.Items.ContainsKey(((ORMIdentifiableEntity)t).ID)) this.Items[((ORMIdentifiableEntity)t).ID] = t;
         else this.Items.Add(((ORMIdentifiableEntity)t).ID, t);
      }

      /// <summary>
      /// Adds a list of items.
      /// </summary>
      /// <param name="list">List of items to be added to the collection.</param>
      internal void Add(IEnumerable<T> list)
      {
         foreach (T t in list) this.Add(t);
      }

      /// <summary>
      /// Remove an element from the collection.
      /// </summary>
      /// <param name="t">Element to remove.</param>
      internal void Remove(T t)
      {
         this.Remove(((ORMIdentifiableEntity)t).ID);
      }

      /// <summary>
      /// Remove an element from the collection.
      /// </summary>
      /// <param name="id">Unique identifier of the element to remove.</param>
      internal void Remove(long id)
      {
         // Remove switchboard from collection
         if (this.Items.ContainsKey(id)) this.Items.Remove(id);
      }

      /// <summary>
      /// Returns an enumerator for the current collection.
      /// </summary>
      /// <returns>The requested enumerator.</returns>
      public IEnumerator<T> GetEnumerator()
      {
         return this.Items.Values.GetEnumerator();
      }

      /// <summary>
      /// Returns an enumerator for the current collection.
      /// </summary>
      /// <returns>The requested enumerator.</returns>
      IEnumerator IEnumerable.GetEnumerator()
      {
         return this.Items.GetEnumerator();
      }

      /// <summary>
      /// Convert the collection into an array.
      /// </summary>
      /// <returns>An array containing all elements in collection.</returns>
      public T[] ToArray()
      {
         List<T> items = new List<T>();
         items.AddRange(this.Items.Values);
         return items.ToArray();
      }

      #endregion

      #region Private Members

      private void Initialize()
      {
         this.Items = new Dictionary<long, T>();
      }

      #endregion

   }
}
