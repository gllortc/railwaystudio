using System;
using Rwm.Otc.Data;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Trains;

namespace Rwm.Otc.Layout
{
   /// <summary>
   /// Implements the relation between element and train.
   /// It is used to know where is a train in the layout.
   /// </summary>
   [ORMTable("ELEMENT_TRAINS")]
   public class ElementTrain : ORMEntity<ElementTrain>
   {

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementTrain"/>.
      /// </summary>
      public ElementTrain() { }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the object unique identifier.
      /// </summary>
      [ORMPrimaryKey()]
      public override long ID { get; set; } = 0;

      /// <summary>
      /// Gets or sets the related accessory module.
      /// </summary>
      [ORMProperty("elementid", "Train")]
      public Element Element { get; set; } = null;

      /// <summary>
      /// Gets or sets the related element.
      /// </summary>
      [ORMProperty("trainid")]
      public Train Train { get; set; } = null;

      #endregion

      #region Methods

      public static System.Data.DataTable ListTrains()
      {
         try
         {
            string sql = @"SELECT 
                             m.id, 
                             em.elementid,  
                             m.IMAGEDATA     As ""Icon"", 
                             m.name          As ""Name"", 
                             m.moddigitaladd As ""Address"",
                             Case 
                                 When (e.Name IS null) Or (e.Name='') Then 'X:' || e.x || ';Y:' || e.y
                                 Else e.Name 
                             End             As ""Block""
                          FROM 
                             " + Train.TableName + @" m 
                             Left Join " + ElementTrain.TableName + @" em On (em.trainid = m.id) 
                             Left Join " + Element.TableName + @"      e  On (e.id = em.elementid)
                          WHERE 
                             m.moddigitaladd > 0 
                          ORDER BY 
                             m.name ASC";

            return Train.ExecuteDataTable(sql);
         }
         catch (Exception ex)
         {
            Logger.LogError(ex);
            throw ex;
         }
      }

      #endregion

   }
}
