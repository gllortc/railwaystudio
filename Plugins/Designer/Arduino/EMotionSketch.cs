using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Rwm.Otc.Diagnostics;
using Rwm.Otc.Layout.EasyConnect;
using Rwm.Otc.Utils;

namespace Rwm.Studio.Plugins.Designer.Arduino
{
   internal class EMotionSketch
   {

      #region Constants

      private const string PATH_PROJECT_FOLDER = "tmp_sketch";
      private const string PATH_SKETCH_FILENAME = EMotionSketch.PATH_PROJECT_FOLDER + ".ino";
      private const string PATH_SKETCH_BUILD = "build.bat";
      private const string PATH_BUILD = "ino_build";
      private const string PATH_CACHE = "ino_cache";

      private const string LIBRARY_DCC_DECODER = "ArduinoDCCDecoder";

      #endregion

      #region Constructors

      /// <summary>
      /// Returns a new instance of <see cref="EMotionSketch"/>.
      /// </summary>
      /// <param name="module">The module for which the sketch is generated.</param>
      public EMotionSketch(EmotionModule module)
      {
         this.Module = module;
      }

      #endregion

      #region Properties

      /// <summary>
      /// Gets the accessory decoder for which the sketch is generated.
      /// </summary>
      public EmotionModule Module { get; private set; }

      /// <summary>
      /// Gets the sketch project root path.
      /// </summary>
      private string ProjectPath
      {
         get { return Path.Combine(PluginData.PluginPath, EMotionSketch.PATH_PROJECT_FOLDER); }
      }

      /// <summary>
      /// Gets the sketch filename (including the full path).
      /// </summary>
      private string SketchFilename
      {
         get { return Path.Combine(PluginData.PluginPath, EMotionSketch.PATH_PROJECT_FOLDER, EMotionSketch.PATH_SKETCH_FILENAME); }
      }

      /// <summary>
      /// Gets the build filename (including the full path).
      /// </summary>
      private string BuildFilename
      {
         get { return Path.Combine(PluginData.PluginPath, EMotionSketch.PATH_PROJECT_FOLDER, EMotionSketch.PATH_SKETCH_BUILD); }
      }

      /// <summary>
      /// Gets the sketch library path.
      /// </summary>
      private string LibraryPath
      {
         get
         {
            string libPath = Path.Combine(this.ProjectPath, "src", EMotionSketch.LIBRARY_DCC_DECODER);
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
            string libPath = Path.Combine(PluginData.PluginPath, EMotionSketch.PATH_BUILD);
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
            string libPath = Path.Combine(PluginData.PluginPath, EMotionSketch.PATH_CACHE);
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
         int idx;
         StringBuilder sketch = new StringBuilder();

         // Sketch header
         sketch.AppendLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
         sketch.AppendLine("// Railwaymania EasyConnect / eMotion module (based on Arduino)");
         sketch.AppendLine("// Author:  Gerard Llort - February 2021");
         sketch.AppendLine("// Version: " + ReflectionUtils.GetAssemblyVersion(this.GetType()));
         sketch.AppendLine("//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");

         // Sketch used libraries
         sketch.AppendLine("#import <Arduino.h>");
         sketch.AppendLine("#include \"Flasher.cpp\"");
         sketch.AppendLine("#include \"Siren.cpp\"");
         sketch.AppendLine("#include \"FailingLamp.cpp\"");
         sketch.AppendLine("#include \"FireRing.cpp\"");
         sketch.AppendLine("#include \"ServoActuator.cpp\"");
         sketch.AppendLine("#include \"WorkingLights.cpp\"");
         sketch.AppendLine("#include \"SoundPlayer.cpp\"");
         sketch.AppendLine("#include \"TimerButton.cpp\"");

         sketch.AppendLine(string.Empty);

         // Define LED pins
         sketch.AppendLine("// PIN declararations");
         idx = 1;
         foreach (IEMotionAction action in this.Module.Actions)
         {
            if (action is LampFailureAction)
            {
               sketch.AppendLine("#define PIN_FLAMP" + idx + " " + ((LampFailureAction)action).Output);
            }
            else if (action is SirenLightsAction)
            {
               sketch.AppendLine("#define PIN_SIREN" + idx + "_1 " + ((SirenLightsAction)action).Output1);
               sketch.AppendLine("#define PIN_SIREN" + idx + "_2 " + ((SirenLightsAction)action).Output2);
            }
            idx++;
         }

         sketch.AppendLine(string.Empty);

         // Actions declaration
         sketch.AppendLine("// Actions declararation");
         idx = 1;
         foreach (IEMotionAction action in this.Module.Actions)
         {
            if (action is LampFailureAction)
            {
               sketch.AppendLine("FailingLamp flamp" + idx + "(PIN_FLAMP" + idx + ");");
            }
            else if (action is SirenLightsAction)
            {
               sketch.AppendLine("Siren siren" + idx + "(PIN_SIREN" + idx + "_1, PIN_SIREN" + idx + "_2, " + ((SirenLightsAction)action).Interval + ");");
            }
            idx++;
         }

         if (this.Module.Button1Enabled && this.Module.Button1Interval > 0)
            sketch.AppendLine("TimerButton tbutton1(A0, " + this.Module.Button1Interval + ");");
         if (this.Module.Button2Enabled && this.Module.Button2Interval > 0)
            sketch.AppendLine("TimerButton tbutton2(A1, " + this.Module.Button2Interval + ");");

         sketch.AppendLine(string.Empty);

         // Setup
         sketch.AppendLine("void setup()");
         sketch.AppendLine("{");
         if (this.Module.DebugEnabled) sketch.AppendLine("   Serial.begin(9600);");
         sketch.AppendLine(string.Empty);

         idx = 1;
         foreach (IEMotionAction action in this.Module.Actions)
         {
            //if (action is LampFailureAction)
            //{
            //   sketch.AppendLine("FailingLamp flamp" + idx + "(PIN_FLAMP" + idx + ");");
            //}
            //else if (action is SirenLightsAction)
            //{
            //   sketch.AppendLine("Siren siren1(PIN_SIREN" + idx + "_1, PIN_SIREN" + idx + "_2, " + ((SirenLightsAction)action).Interval + ");");
            //}
            idx++;
         }
         sketch.AppendLine("   // servo.Initialize();");
         sketch.AppendLine("   // sound.Initialize();");
         sketch.AppendLine("}");

         sketch.AppendLine(string.Empty);

         // Loop
         sketch.AppendLine("void loop()");
         sketch.AppendLine("{");
         
         if (this.Module.Button1Enabled && this.Module.Button1Interval > 0)
         {
            sketch.AppendLine("   switch (tbutton1.Dispatch())");
            sketch.AppendLine("   {");
            sketch.AppendLine("      case TimerButton::TIMERBUTTON_STATUS_START: siren1.Restart(); break;");
            sketch.AppendLine("      case TimerButton::TIMERBUTTON_STATUS_ENABLED: siren1.Dispatch(); break;");
            sketch.AppendLine("      case TimerButton::TIMERBUTTON_STATUS_END: siren1.Stop(); break;");
            sketch.AppendLine("      default: break;");
            sketch.AppendLine("   }");
            sketch.AppendLine(string.Empty);
         }

         if (this.Module.Button1Enabled && this.Module.Button1Interval > 0)
         {
            sketch.AppendLine("   switch (tbutton2.Dispatch())");
            sketch.AppendLine("   {");
            sketch.AppendLine("      case TimerButton::TIMERBUTTON_STATUS_START: siren1.Restart(); break;");
            sketch.AppendLine("      case TimerButton::TIMERBUTTON_STATUS_ENABLED: siren1.Dispatch(); break;");
            sketch.AppendLine("      case TimerButton::TIMERBUTTON_STATUS_END: siren1.Stop(); break;");
            sketch.AppendLine("      default: break;");
            sketch.AppendLine("   }");
            sketch.AppendLine(string.Empty);
         }

         idx = 1;
         foreach (IEMotionAction action in this.Module.Actions)
         {
            if (action.ActionButtonIndex <= 0)
            {
               if (action is LampFailureAction)
               {
                  sketch.AppendLine("flamp" + idx + ".Dispatch();");
               }
               else if (action is SirenLightsAction)
               {
                  sketch.AppendLine("siren1" + idx + ".Dispatch();");
               }
            }
            idx++;
         }

         sketch.AppendLine("}");
         sketch.AppendLine(string.Empty);

         // Write sketch contents
         File.WriteAllText(Path.Combine(this.ProjectPath, EMotionSketch.PATH_SKETCH_FILENAME), sketch.ToString());
      }

      private void AddSketchLibraries()
      {
         string source;

         source = Properties.Resources.DCC_DECODER_CPP;
         source = source.Replace("#libfilename#", "\"" + EMotionSketch.LIBRARY_DCC_DECODER + ".h\"");
         File.WriteAllText(Path.Combine(this.LibraryPath, EMotionSketch.LIBRARY_DCC_DECODER + ".cpp"), source);

         File.WriteAllText(Path.Combine(this.LibraryPath, EMotionSketch.LIBRARY_DCC_DECODER + ".h"), Properties.Resources.DCC_DECODER_H);
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
