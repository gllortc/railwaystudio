using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout;
using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Designer.Arduino
{
   internal class DecoderSketch
   {

      #region Constants

      private const string PATH_PROJECT_FOLDER = "tmp_sketch";
      private const string PATH_SKETCH_FILENAME = DecoderSketch.PATH_PROJECT_FOLDER + ".ino";
      private const string PATH_SKETCH_BUILD = "build.bat";
      private const string PATH_BUILD = "ino_build";
      private const string PATH_CACHE = "ino_cache";

      private const string LIBRARY_DCC_DECODER = "ArduinoDCCDecoder";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="DecoderSketch"/>.
      /// </summary>
      /// <param name="accessoryDecoder">The decoder of accessories for which the sketch is generated.</param>
      public DecoderSketch(AccessoryDecoder accessoryDecoder)
      {
         this.AccessoryDecoder = accessoryDecoder;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the accessory decoder for which the sketch is generated.
      /// </summary>
      public AccessoryDecoder AccessoryDecoder { get; private set; }

      /// <summary>
      /// Gets the sketch project root path.
      /// </summary>
      private string ProjectPath
      {
         get { return Path.Combine(PluginData.PluginPath, DecoderSketch.PATH_PROJECT_FOLDER); }
      }

      /// <summary>
      /// Gets the sketch filename (including the full path).
      /// </summary>
      private string SketchFilename
      {
         get { return Path.Combine(PluginData.PluginPath, DecoderSketch.PATH_PROJECT_FOLDER, DecoderSketch.PATH_SKETCH_FILENAME); }
      }

      /// <summary>
      /// Gets the build filename (including the full path).
      /// </summary>
      private string BuildFilename
      {
         get { return Path.Combine(PluginData.PluginPath, DecoderSketch.PATH_PROJECT_FOLDER, DecoderSketch.PATH_SKETCH_BUILD); }
      }

      /// <summary>
      /// Gets the sketch library path.
      /// </summary>
      private string LibraryPath
      {
         get
         {
            string libPath = Path.Combine(this.ProjectPath, "src", DecoderSketch.LIBRARY_DCC_DECODER);
            if (!Directory.Exists(libPath)) Directory.CreateDirectory(libPath);
            return libPath;
         }
      }

      /// <summary>
      /// Gets the sketch library path.
      /// </summary>
      private string BuildPath
      {
         get
         {
            string libPath = Path.Combine(PluginData.PluginPath, DecoderSketch.PATH_BUILD);
            if (!Directory.Exists(libPath)) Directory.CreateDirectory(libPath);
            return libPath;
         }
      }

      /// <summary>
      /// Gets the sketch library path.
      /// </summary>
      private string CachePath
      {
         get
         {
            string libPath = Path.Combine(PluginData.PluginPath, DecoderSketch.PATH_CACHE);
            if (!Directory.Exists(libPath)) Directory.CreateDirectory(libPath);
            return libPath;
         }
      }

      #endregion

      #region Methods

      public void Create(bool upload)
      {
         Logger.LogDebug(this, "Create({0})", upload);

         try
         {
            this.AddSketchLibraries();
            this.GenerateSketchSource();
            this.GenerateBuildScript(upload);
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      /// <summary>
      /// Invoke the Arduino compiler to build and upload the sketch.
      /// </summary>
      /// <param name="outputControl">Control where the standard output will be redirected..</param>
      public void Build(System.Windows.Forms.Control outputControl)
      {
         Logger.LogDebug(this, "Build([{0}])", outputControl);

         try
         {
            // Execute the BATCH file
            using (Process process = new Process())
            {
               process.StartInfo.FileName = this.BuildFilename;
               process.StartInfo.UseShellExecute = false;
               process.StartInfo.RedirectStandardOutput = true;
               process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
               process.Start();

               // Synchronously read the standard output of the spawned process. 
               StreamReader reader = process.StandardOutput;
               outputControl.Text = reader.ReadToEnd();

               process.WaitForExit();
            }
         }
         catch (Exception ex)
         {
            Logger.LogError(this, ex);
            throw ex;
         }
      }

      #endregion

      #region Private Members

      private void GenerateSketchSource()
      {
         StringBuilder sketch = new StringBuilder();

         sketch.AppendLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
         sketch.AppendLine("// Arduino DCC Solenoid Switch Decoder.");
         sketch.AppendLine("// Author: Ruud Boer - January 2015");
         sketch.AppendLine("// This sketch turns an Arduino into a DCC decoder to drive max 8 dual coil solenoid switches.");
         sketch.AppendLine("// The DCC signal is optically separated and fed to pin 2 (=Interrupt 0). Schematics: www.mynabay.com");
         sketch.AppendLine("// Many thanks to www.mynabay.com for publishing their DCC monitor and -decoder code.");
         sketch.AppendLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("#include \"src/" + DecoderSketch.LIBRARY_DCC_DECODER + "/" + DecoderSketch.LIBRARY_DCC_DECODER + ".h\"");
         sketch.AppendLine("#define kDCC_INTERRUPT 0");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
         sketch.AppendLine("const byte maxaccessories = 2; //The number of switches you want to control with this Arduino");
         sketch.AppendLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("const byte MODE_SELENOID = 1;");
         sketch.AppendLine("const byte MODE_SIGNAL = 2;");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("typedef struct");
         sketch.AppendLine("{");
         sketch.AppendLine("   byte mode;");
         sketch.AppendLine("   int address;            // Address to respond to");
         sketch.AppendLine("   byte output;            // State of accessory: 1=on, 0=off (for internal use only)");
         sketch.AppendLine("   int outputPin;          // Arduino output pin");
         sketch.AppendLine("   int outputPin2;         // Arduino output pin2, used for solenoid junctions");
         sketch.AppendLine("   byte highlow;           // State of outputpin: 1=HIGH, 0=LOW");
         sketch.AppendLine("   byte highlow2;          // State of outputpin2: 1=HIGH, 0=LOW");
         sketch.AppendLine("   boolean finished;       // Memory location that says the oneshot is finished");
         sketch.AppendLine("   boolean finished2;      // Memory location that says the second oneshot (for solenoid) is finished");
         sketch.AppendLine("   int durationMilli;      // ms flash time");
         sketch.AppendLine("   unsigned long onMilli;  // for internal use");
         sketch.AppendLine("   unsigned long offMilli; // for internal use");
         sketch.AppendLine("}");
         sketch.AppendLine("DCCAccessoryAddress;");
         sketch.AppendLine("DCCAccessoryAddress accessory[maxaccessories];");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("// Initialization");
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("void ConfigureDecoderFunctions()");
         sketch.AppendLine("{");
         sketch.AppendLine("   accessory[0].mode = MODE_SELENOID;");
         sketch.AppendLine("   accessory[0].address = 1;");
         sketch.AppendLine("   accessory[0].durationMilli = 1000;");
         sketch.AppendLine("   accessory[0].outputPin = 5;");
         sketch.AppendLine("   accessory[0].outputPin2 = 6;");
         sketch.AppendLine("   accessory[0].highlow = 0;      // Do not change this value");
         sketch.AppendLine("   accessory[0].highlow2 = 0;     // Do not change this value");
         sketch.AppendLine("   accessory[0].finished = false; // Do not change this value");
         sketch.AppendLine("   accessory[0].finished2 = true; // Do not change this value");
         sketch.AppendLine("   accessory[0].output = 0;       // Do not change this value");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   accessory[1].mode = MODE_SIGNAL;");
         sketch.AppendLine("   accessory[1].address = 2;");
         sketch.AppendLine("   accessory[1].outputPin = 7;");
         sketch.AppendLine("   accessory[1].outputPin2 = 8;");
         sketch.AppendLine("   accessory[1].highlow = 1; // Do not change this value");
         sketch.AppendLine("   accessory[1].highlow2 = 0; // Do not change this value");
         sketch.AppendLine("   accessory[1].finished = false; // Do not change this value");
         sketch.AppendLine("   accessory[1].finished2 = true; // Do not change this value");
         sketch.AppendLine("   accessory[1].output = 0; // Do not change this value");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   // Setup output pins");
         sketch.AppendLine("   for (int i = 0; i < maxaccessories; i++)");
         sketch.AppendLine("   {");
         sketch.AppendLine("      if (accessory[i].outputPin)");
         sketch.AppendLine("      {");
         sketch.AppendLine("         pinMode(accessory[i].outputPin, OUTPUT);");
         sketch.AppendLine("         digitalWrite(accessory[i].outputPin, LOW);");
         sketch.AppendLine("      }");
         sketch.AppendLine("      if (accessory[i].outputPin2)");
         sketch.AppendLine("      {");
         sketch.AppendLine("         pinMode(accessory[i].outputPin2, OUTPUT);");
         sketch.AppendLine("         digitalWrite(accessory[i].outputPin2, LOW);");
         sketch.AppendLine("      }");
         sketch.AppendLine("   }");
         sketch.AppendLine("}");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("// DCC packet handler");
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("void BasicAccDecoderPacket_Handler(int address, boolean activate, byte data)");
         sketch.AppendLine("{");
         sketch.AppendLine("   // Convert NMRA packet address format to human address");
         sketch.AppendLine("   address -= 1;");
         sketch.AppendLine("   address *= 4;");
         sketch.AppendLine("   address += 1;");
         sketch.AppendLine("   address += (data & 0x06) >> 1;");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   boolean enable = (data & 0x01) ? 1 : 0;");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   for (int i = 0; i < maxaccessories; i++)");
         sketch.AppendLine("   {");
         sketch.AppendLine("      if (address == accessory[i].address)");
         sketch.AppendLine("      {");
         sketch.AppendLine("         if (enable) accessory[i].output = 1;");
         sketch.AppendLine("         else accessory[i].output = 0;");
         sketch.AppendLine("      }");
         sketch.AppendLine("   }");
         sketch.AppendLine("}");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("// Process selenoid output");
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("void setSelenoid(int addr)");
         sketch.AppendLine("{");
         sketch.AppendLine("   if (accessory[addr].output == 1)");
         sketch.AppendLine("   {");
         sketch.AppendLine("      if (!accessory[addr].highlow && !accessory[addr].finished)");
         sketch.AppendLine("      {");
         sketch.AppendLine("         accessory[addr].highlow = 1;");
         sketch.AppendLine("         accessory[addr].offMilli = millis() + accessory[addr].durationMilli;");
         sketch.AppendLine("      }");
         sketch.AppendLine("      if (accessory[addr].highlow && millis() > accessory[addr].offMilli)");
         sketch.AppendLine("      {");
         sketch.AppendLine("         accessory[addr].highlow = 0;");
         sketch.AppendLine("         accessory[addr].finished = true;");
         sketch.AppendLine("      }");
         sketch.AppendLine("      accessory[addr].finished2 = false;");
         sketch.AppendLine("   }");
         sketch.AppendLine("   else // output==0");
         sketch.AppendLine("   {");
         sketch.AppendLine("      accessory[addr].highlow = 0;");
         sketch.AppendLine("      accessory[addr].finished = false;");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("      if (!accessory[addr].highlow2 && !accessory[addr].finished2)");
         sketch.AppendLine("      {");
         sketch.AppendLine("         accessory[addr].highlow2 = 1;");
         sketch.AppendLine("         accessory[addr].offMilli = millis() + accessory[addr].durationMilli;");
         sketch.AppendLine("      }");
         sketch.AppendLine("      if (accessory[addr].highlow2 && millis() > accessory[addr].offMilli)");
         sketch.AppendLine("      {");
         sketch.AppendLine("         accessory[addr].highlow2 = 0;");
         sketch.AppendLine("         accessory[addr].finished2 = true;");
         sketch.AppendLine("      }");
         sketch.AppendLine("   }");
         sketch.AppendLine("}");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("// Process signal output");
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("void setSignal(int addr)");
         sketch.AppendLine("{");
         sketch.AppendLine("   if (accessory[addr].output == 1)");
         sketch.AppendLine("   {");
         sketch.AppendLine("      accessory[addr].highlow = 1;");
         sketch.AppendLine("      accessory[addr].highlow2 = 0;");
         sketch.AppendLine("   }");
         sketch.AppendLine("   else // output==0");
         sketch.AppendLine("   {");
         sketch.AppendLine("      accessory[addr].highlow = 0;");
         sketch.AppendLine("      accessory[addr].highlow2 = 1;");
         sketch.AppendLine("   }");
         sketch.AppendLine("}");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("// Setup (run once)");
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("void setup()");
         sketch.AppendLine("{");
         sketch.AppendLine("   DCC.SetBasicAccessoryDecoderPacketHandler(BasicAccDecoderPacket_Handler, true);");
         sketch.AppendLine("   ConfigureDecoderFunctions();");
         sketch.AppendLine("   DCC.SetupDecoder(0x00, 0x00, kDCC_INTERRUPT);");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   pinMode(2, INPUT_PULLUP); //Interrupt 0 with internal pull up resistor (can get rid of external 10k)");
         sketch.AppendLine("   pinMode(13, OUTPUT);");
         sketch.AppendLine("   digitalWrite(13, LOW); //turn off Arduino led at startup");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   for (int n = 0; n < maxaccessories; n++) accessory[n].output = 0; //all servo's to min angle and functions to 0");
         sketch.AppendLine("}");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("// Main loop (run continuous)");
         sketch.AppendLine("//---------------------------------------------------------------");
         sketch.AppendLine("void loop()");
         sketch.AppendLine("{");
         sketch.AppendLine("   // Loop DCC library");
         sketch.AppendLine("   static int addr = 0;");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   DCC.loop();");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   // Bump to next address to test");
         sketch.AppendLine("   if (++addr >= maxaccessories) addr = 0;");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   if (accessory[addr].mode == MODE_SELENOID) setSelenoid(addr);");
         sketch.AppendLine("   if (accessory[addr].mode == MODE_SIGNAL) setSignal(addr);");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   if (accessory[addr].highlow) digitalWrite(accessory[addr].outputPin, HIGH);");
         sketch.AppendLine("   else digitalWrite(accessory[addr].outputPin, LOW);");
         sketch.AppendLine(string.Empty);
         sketch.AppendLine("   if (accessory[addr].highlow2) digitalWrite(accessory[addr].outputPin2, HIGH);");
         sketch.AppendLine("   else digitalWrite(accessory[addr].outputPin2, LOW);");
         sketch.AppendLine("}");
         sketch.AppendLine(string.Empty);

         // Write sketch contents
         File.WriteAllText(Path.Combine(this.ProjectPath, DecoderSketch.PATH_SKETCH_FILENAME), sketch.ToString());
      }

      private void AddSketchLibraries()
      {
         string source;

         source = Properties.Resources.DCC_DECODER_CPP;
         source = source.Replace("#libfilename#", "\"" + DecoderSketch.LIBRARY_DCC_DECODER + ".h\"");
         File.WriteAllText(Path.Combine(this.LibraryPath, DecoderSketch.LIBRARY_DCC_DECODER + ".cpp"), source);

         File.WriteAllText(Path.Combine(this.LibraryPath, DecoderSketch.LIBRARY_DCC_DECODER + ".h"), Properties.Resources.DCC_DECODER_H);
      }

      /// <summary>
      /// Create a batch file to build the project into the project folder.
      /// </summary>
      /// <param name="upload">A value indicating if the build sketch should be uploaded to the device or not (only compile).</param>
      private void GenerateBuildScript(bool upload)
      {
         string cmd;
         string args;
         FileVersionInfo info = ReflectionUtils.GetAssemblyInfo(this.GetType());

         // Generate the BATCH file to build
         cmd = string.Empty;
         cmd += "@ECHO off";
         cmd += Environment.NewLine + Environment.NewLine;
         cmd += "REM -----------------------------------------------------------------";
         cmd += "REM  Build script autogenerated with " + info.ProductName + " v" + info.ProductVersion.ToString();
         cmd += "REM -----------------------------------------------------------------";
         cmd += Environment.NewLine + Environment.NewLine;
         File.WriteAllText(this.BuildFilename, cmd + Environment.NewLine);

         cmd = string.Empty;
         cmd += "ECHO ================================================================================";
         cmd += "ECHO  GENERATING DECODER CONFIGURATION";
         cmd += "ECHO ================================================================================";
         cmd += Environment.NewLine + Environment.NewLine;
         cmd += @"""C:\Program Files (x86)\Arduino\arduino-cli.exe"" ";

         args = string.Empty;
         args += @"compile ";
         args += @"--fqbn arduino:avr:nano:cpu=atmega328old ";
         args += @"--verbose ";
         args += this.ProjectPath;

         File.AppendAllText(this.BuildFilename, cmd + args + Environment.NewLine);

         if (upload)
         {
            cmd = string.Empty;
            cmd += @"""C:\Program Files (x86)\Arduino\arduino-cli.exe"" ";

            args = string.Empty;
            args += @"upload ";
            args += @"--fqbn arduino:avr:nano:cpu=atmega328old ";
            args += @"--port COM3 ";
            args += @"--verify ";
            args += @"--verbose ";
            args += this.ProjectPath;

            File.AppendAllText(this.BuildFilename, cmd + args + Environment.NewLine);
         }
      }

      #endregion

   }
}
