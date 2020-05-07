using System.Collections.Generic;
using Rwm.Otc.Systems.Protocol;

namespace Rwm.Otc.Systems.XpressNet.Protocol
{
   /// <summary>
   /// Lenz XpressNet protocol command: 
   /// Feedback signal received.
   /// </summary>
   /// <remarks>
   /// The current version of this driver only supports feedback from the feedback encoders.
   /// Feedback from the turnouts will be discarded.
   /// </remarks>
   public class LenzFeedbackStatusChanged : IFeedbackStatusChanged, IResponse
   {

      #region Enumerations

      /// <summary>
      /// Types of devices that generate feedback signal.
      /// </summary>
      public enum FeedbackAddressType : byte
      {
         TurnoutWithoutFeedback = 0b00,
         TurnoutWithFeedback = 0b01,
         FeedbackEncoder = 0b10,
         Unknown = 0b11
      }

      #endregion

      #region Constructors

      /// <summary>
      /// returns a new instance of <see cref="LenzFeedbackStatusChanged"/>.
      /// </summary>
      /// <param name="receivedData">Data received from the command station.</param>
      public LenzFeedbackStatusChanged(byte[] receivedData)
      {
         this.SetResponseData(receivedData);
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the address of the changed feedback sensor.
      /// </summary>
      public int Address { get; private set; } = 0;

      /// <summary>
      /// Gets the list of reported statuses from the feedback sensors.
      /// </summary>
      public List<FeedbackPointAddressStatus> ReportedStatuses { get; private set; } = new List<FeedbackPointAddressStatus>();

      /// <summary>
      /// Gets a value indicating if received command is valid.
      /// </summary>
      public bool IsValidResponse { get; private set; } = false;

      /// <summary>
      /// Gets the received bytes from the command station.
      /// </summary>
      public byte[] ResponseBytes { get; private set; }

      private bool IsFeedback { get; set; } = false;

      private int InputGroup { get; set; } = 0;

      /// <summary>
      /// Gets the type of device that generate the feedback signal.
      /// </summary>
      private FeedbackAddressType AddressType { get; set; } = FeedbackAddressType.Unknown;

      #endregion

      #region Methods

      /// <summary>
      /// Extract the data from the received command.
      /// </summary>
      /// <param name="receivedData">Received bytes.</param>
      /// <returns>Return a value indicating if the data is valid or not.</returns>
      private bool SetResponseData(byte[] receivedData)
      {
         this.ResponseBytes = receivedData;

         if (receivedData == null || receivedData.Length != 4)
         {
            this.IsValidResponse = false;
            return false;
         }

         this.Address = receivedData[1] + 1;
         this.IsFeedback = ((receivedData[2] & 0b10000000) == 0b0); // Should be always 0 for feedback modules
         this.AddressType = (FeedbackAddressType)((receivedData[2] & 0b01100000) >> 5); 
         this.InputGroup = (receivedData[2] & 0b00010000);
         this.IsValidResponse = (this.IsFeedback && (this.AddressType == FeedbackAddressType.FeedbackEncoder));

         if (this.IsValidResponse)
         {
            this.ReportedStatuses.Add(new FeedbackPointAddressStatus(this.Address, 1 + (this.InputGroup * 4), ((receivedData[2] & 0b00000001) == 1)));
            this.ReportedStatuses.Add(new FeedbackPointAddressStatus(this.Address, 2 + (this.InputGroup * 4), ((receivedData[2] & 0b00000010) == 1)));
            this.ReportedStatuses.Add(new FeedbackPointAddressStatus(this.Address, 3 + (this.InputGroup * 4), ((receivedData[2] & 0b00000100) == 1)));
            this.ReportedStatuses.Add(new FeedbackPointAddressStatus(this.Address, 4 + (this.InputGroup * 4), ((receivedData[2] & 0b00001000) == 1)));
         }

         return this.IsValidResponse;
      }

      #endregion

      #region Static Members

      /// <summary>
      /// Check if teh received data corresponds to a feedback status changed command.
      /// </summary>
      /// <param name="commandBytes">Received bytes (with header and xor bytes).</param>
      /// <returns>A value indicating if the received bytes corresponds to a feedback status changed command.</returns>
      public static bool IsTypeOf(List<byte> commandBytes)
      {
         if (commandBytes[0] == 0x42)
         {
            int data = commandBytes[2] & 0b0110_0000;
            return (data == 0x40);
         }
         return false;
      }

      #endregion

   }
}
