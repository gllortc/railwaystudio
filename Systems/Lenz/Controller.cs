using com.rwm.otc.systems.commands;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace com.rwm.otc.systems.lenz
{
   public class Controller : OTCSystemInterface
   {
      private Exception _lasterror = null;
      private LenzComm _controller = null;
      private OTCSystem _system = null;

      /// <summary>
      /// Devuelve una instáncia de <see cref="Controller"/>.
      /// </summary>
      /// <param name="system">Una instancia de <see cref="OTCSystem"/> que representa el sistema digital implementado por el controlador.</param>
      public Controller(OTCSystem system)
      {
         _system = system;

         // Genera una instancia del controlador
         _controller = new LenzComm();
      }

      #region Properties

      /// <summary>
      /// Devuelve el nombre del producto.
      /// </summary>
      public string Name
      {
         get
         {
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            AssemblyTitleAttribute attr = (AssemblyTitleAttribute)AssemblyTitleAttribute.GetCustomAttribute(assembly, typeof(AssemblyTitleAttribute));

            return attr.Title;
         }
      }

      /// <summary>
      /// Devuelve la descripción del producto.
      /// </summary>
      public string Description
      {
         get
         {
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            AssemblyDescriptionAttribute attr = (AssemblyDescriptionAttribute)AssemblyDescriptionAttribute.GetCustomAttribute(assembly, typeof(AssemblyDescriptionAttribute));

            return attr.Description;
         }
      }

      /// <summary>
      /// Devuelve la información de licencia del producto.
      /// </summary>
      public string Licence
      {
         get
         {
            Assembly assembly = Assembly.GetAssembly(this.GetType());
            AssemblyCopyrightAttribute attr = (AssemblyCopyrightAttribute)AssemblyCopyrightAttribute.GetCustomAttribute(assembly, typeof(AssemblyCopyrightAttribute));

            return attr.Copyright;
         }
      }

      /// <summary>
      /// Devuelve el icono descriptivo del controlador.
      /// </summary>
      public System.Drawing.Image Icon
      {
         get { return (System.Drawing.Image)global::otc.rwm.pcontrol.systems.lenz.Properties.Resources.ICO_LOGO_LENZ; }
      }

      /// <summary>
      /// Devuelve la versión de la librería.
      /// </summary>
      public string Version
      {
         get
         {
            Version v = Assembly.GetAssembly(this.GetType()).GetName().Version;
            return v.Major + "." + v.Minor + "." + v.Build + "." + v.Revision;
         }
      }

      /// <summary>
      /// Contiene la última excepción capturada
      /// </summary>
      /// <remarks>
      /// Permite mostrar errores detallados en el programa que usa el controlador, que de otra forma,
      /// muestra un mensaje que indica que la clase no responde.
      /// </remarks>
      public Exception LastError
      {
         get { return _lasterror; }
      }

      /// <summary>
      /// Indica si la conexión al sistema digital está abierta.
      /// </summary>
      public bool IsConnected
      {
         get { return _controller.Connected; }
      }

      #endregion

      #region Methods

      /// <summary>
      /// Conecta con el sistema digital.
      /// </summary>
      public void Connect()
      {
         // Obtiene las propiedades de configuración
         _controller.PortName = _system.GetParameterString(LenzSettings.SETTING_PORT_NAME, "");
         _controller.PortSpeed = _system.GetParameterInteger(LenzSettings.SETTING_PORT_SPEED, 9600);
         _controller.RequestTimeout = _system.GetParameterInteger(LenzSettings.SETTING_REQUEST_TIMEOUT, 90);

         try
         {
            _controller.Open();

            // Lanza evento informativo
            if (OnInformation != null)
            {
               ShowMessage("System connected", MessageTypes.Information);
               ShowMessage("Connected to: " + _controller.Description, MessageTypes.Information);
            }
         }
         catch (Exception ex)
         {
            // Memoriza el error
            _lasterror = ex;

            // Lanza evento informativo
            ShowMessage("Connection error: " + ex.Message, MessageTypes.Error, ex);

            // Lanza el error
            throw ex;
         }
      }

      /// <summary>
      /// Cierra la conexión con el sistema digital.
      /// </summary>
      public void Disconnect()
      {
         _controller.Close();
      }

      /// <summary>
      /// Ejecuta un comando (petición) al sistema digital
      /// </summary>
      /// <param name="otcCommand">Un comando OTC.</param>
      public void ExecuteCommand(object otcCommand)
      {
         // Comprueba que el objeto cumpla con el interface IOTCSystemCommand
         if (otcCommand.GetType().GetInterface("otc.systems.commands.IOTCSystemCommand", true) == null)
            ShowMessage("Unexpected command received: " + otcCommand.GetType().ToString() + " isn't OTC command.", MessageTypes.Error);

         try
         {
            if (typeof(OTCSysCmdResumeOperations) == otcCommand.GetType())
            {
               _controller.ResumeOperations();
            }
            else if (typeof(OTCSysCmdPowerOff) == otcCommand.GetType())
            {
               _controller.TrackPowerOff();
            }
            else if (typeof(OTCSysCmdStopAllLocomotives) == otcCommand.GetType())
            {
               _controller.StopAllLocomotives();
            }
            else if (typeof(OTCSysCmdStopLocomotive) == otcCommand.GetType())
            {
               _controller.StopLocomotive(((OTCSysCmdStopLocomotive)otcCommand).Address);
            }
         }
         catch (Exception ex)
         {
            // Memoriza el error
            _lasterror = ex;

            // Lanza evento informativo
            ShowMessage("Request error: " + ex.Message, MessageTypes.Error, ex);

            // Lanza el error
            throw ex;
         }
      }

      /// <summary>
      /// Abre el formulario (modal) que permite configurar el controlador.
      /// </summary>
      /// <remarks>
      /// La nueva configuración tendrá efecto a la siguiente llamada al método Connect().
      /// </remarks>
      public void Setup()
      {
         frmSetup setup = new frmSetup();
         
         if (setup.ShowDialog() == DialogResult.OK)
         {
            // Recarga la configuración
            _controller.PortName = _system.GetParameterString(LenzSettings.SETTING_PORT_NAME, "");
            _controller.PortSpeed = _system.GetParameterInteger(LenzSettings.SETTING_PORT_SPEED, 9600);
            _controller.RequestTimeout = _system.GetParameterInteger(LenzSettings.SETTING_REQUEST_TIMEOUT, 90);

            // Avisa al usuario que reinicie la conexión si se encuentra el sistema conectado
            if (_controller.Connected)
               MessageBox.Show("La nueva configuración surgirá efecto cuando se abra una nueva conexión al sistema digital.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
         }
      }

      #endregion

      #region Messaging Functions

      private enum MessageTypes
      {
         Information,
         Error
      }

      private void ShowMessage(string message, MessageTypes type, Exception exception)
      {
         switch (type)
         {
            case MessageTypes.Information:
               if (OnInformation != null)
                  OnInformation(new OTCInformationEventArgs(message));
               break;

            case MessageTypes.Error:
               if (OnError != null)
                  OnError(new OTCInformationEventArgs(message), exception);
               break;
         }
      }

      private void ShowMessage(string message, MessageTypes type)
      {
         ShowMessage(message, type, null);
      }

      #endregion

      #region Class Events

      // public delegate void ResponseEventHandler(OTCSystemResponseEventArgs e);
      // public event ResponseEventHandler OnResponse;

      public delegate void InfoEventHandler(OTCInformationEventArgs e);
      public event InfoEventHandler OnInformation;

      public delegate void ErrorEventHandler(OTCInformationEventArgs e, Exception error);
      public event ErrorEventHandler OnError;

      /// <summary>
      /// Método interno para lanzar el evento OnError.
      /// </summary>
      private void Object_OnError(OTCInformationEventArgs e, Exception error)
      {
         if (OnError != null) OnError(e, error);
      }

      /// <summary>
      /// Método interno para lanzar el evento OnInformation.
      /// </summary>
      private void Object_OnInformation(OTCInformationEventArgs e)
      {
         if (OnInformation != null) OnInformation(e);
      }

      #endregion

   }
}
