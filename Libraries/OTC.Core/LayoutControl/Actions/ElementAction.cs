﻿using Rwm.Otc.LayoutControl.Elements;
using System;
using System.Drawing;
using System.Reflection;

namespace Rwm.Otc.LayoutControl.Actions
{
   /// <summary>
   /// Action base classs.
   /// </summary>
   public abstract class ElementAction
   {

      #region Constants

      /// <summary>Status condition disabled.</summary>
      public static int CONDITION_DISABLED = -1;

      #endregion

      #region Enumerations

      public enum ExecutionEventType : int
      {
         Undefined = 0,
         OnAccessoryStatusChange = 1,
         OnSensorStatusChange = 2
      }

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="ElementAction"/>.
      /// </summary>
      public ElementAction()
      {
         Initialize();
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets or sets the action unique identifier (DB).
      /// </summary>
      public int ID { get; set; }

      /// <summary>
      /// Gets or sets the owner element unique identifier (DB).
      /// </summary>
      public int OwnerElementID { get; set; }

      /// <summary>
      /// Gets or sets the action type name.
      /// </summary>
      public string ActionType { get; set; }

      /// <summary>
      /// Gets or sets the event type name.
      /// </summary>
      public ExecutionEventType EventType { get; set; }

      /// <summary>
      /// Gets or sets the status that should be get the owner element to activate the action.
      /// </summary>
      /// <remarks>
      /// 
      /// </remarks>
      public int ConditionParentStatus { get; set; }

      /// <summary>
      /// Gets or sets the action description.
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Gets the icon assigned to the action.
      /// </summary>
      public virtual Image Icon
      {
         get { return Otc.Properties.Resources.ICO_ACTION_16; }
      }

      internal int IntegerParameter1 { get; set; }

      internal int IntegerParameter2 { get; set; }

      

      #endregion

      #region Methods

      /// <summary>
      /// Execute the action.
      /// </summary>
      /// <param name="element">Parameter to remove!</param>
      /// <param name="project">Project where the action must be executed.</param>
      /// <param name="system">System used to execute the digital commands.</param>
      public virtual void Execute(ElementBase element, Project project, Rwm.Otc.Systems.IDigitalSystem system)
      {
         // Nothing to do here
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Read a category from the current reader record.
      /// </summary>
      public static ElementAction CreateActionInstance(string actionTypeName)
      {
         foreach (Type type in Assembly.GetAssembly(typeof(ElementAction)).GetTypes())
         {
            if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(typeof(ElementAction)) && type.Name.Equals(actionTypeName))
            {
               return (ElementAction)Activator.CreateInstance(type);
            }
         }

         return null;
      }

      #endregion

      #region Private Members

      /// <summary>
      /// Initialize the instance data.
      /// </summary>
      private void Initialize()
      {
         this.ID = 0;
         this.OwnerElementID = 0;
         this.ActionType = string.Empty;
         this.EventType = ExecutionEventType.Undefined;
         this.IntegerParameter1 = 0;
         this.IntegerParameter2 = 0;
         this.ConditionParentStatus = ElementAction.CONDITION_DISABLED;
         this.Description = string.Empty;
      }

      #endregion

   }
}
