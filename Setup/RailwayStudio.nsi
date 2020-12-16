;INITIALIZATION
;-------------------------

;modern GUI
!include "MUI.nsh"

;use lzma as compression algorithm
SetCompressor lzma

;ask for confirmation to abort the installation
!define MUI_ABORTWARNING

;use logo in the left side of welcome and finish screens,in the installer and in the uninstaller
!define MUI_WELCOMEFINISHPAGE_BITMAP "auxiliarFiles\Images\rwm_studio_logo_wizard.bmp"
!define MUI_UNWELCOMEFINISHPAGE_BITMAP "auxiliarFiles\Images\rwm_studio_logo_wizard.bmp"

;use logo in the header of the screens
!define MUI_HEADERIMAGE
!define MUI_HEADERIMAGE_BITMAP "auxiliarFiles\Images\rwm_studio_logo_header.bmp"

;VARIABLES
;----------------

;version of the installer
!define VERSION "1.0.0"

;the name of the software
!define NAME "RailwayStudio"

!define EXE_NAME "RailwayStudio.exe"
!define EXE_NAME_UNINSTALLER "Uninstall.RailwayStudio.exe"

;SCREENS
;------------------------------

;screen for welcome
!insertmacro MUI_PAGE_WELCOME

;screen to visualize the license
!insertmacro MUI_PAGE_LICENSE "$(MUILicense)"

;screen to choose the installation folder
!insertmacro MUI_PAGE_DIRECTORY

;screen to copy the files
!insertmacro MUI_PAGE_INSTFILES

;screen when finished
!insertmacro MUI_PAGE_FINISH

;available languages
!insertmacro MUI_LANGUAGE "English"
!insertmacro MUI_LANGUAGE "Spanish"

LicenseLangString MUILicense ${LANG_ENGLISH} "auxiliarFiles\Licenses\license_en.txt"
LicenseLangString MUILicense ${LANG_SPANISH} "auxiliarFiles\Licenses\license_es.txt"

;GENERAL CONFIGURATION
;---------------------------------------

;generated setup file
OutFile "RWM.RailwayStudio.Setup.${VERSION}.exe"

;name of the application
Name "${NAME}"
Caption "${NAME} ${VERSION}"

;Integrity check enabled
CRCCheck on

;graphical styles of XP enabled
XPStyle on

;Default folder for installation
InstallDir "C:\Railwaymania\Studio"

;Close the wizard when installation is finished"
AutoCloseWindow true

;Show installation details
ShowInstDetails hide

;overwriting of the existing files
SetOverwrite on

;optimization of the data to copy
SetDatablockOptimize on

;only compress when compressed size is smaller than original
SetCompress auto

;to personalize the uninstaller message
UninstallText "This is the uninstaller for ${NAME} v${VERSION}"

; VisionAuditor icon
Icon "AuxiliarFiles\Images\railwaymania.ico"
WindowIcon on

;SECTIONS OR COMPONENTS
;------------------------------------------

Section "The installer"

SetOutPath $INSTDIR

SetOverwrite on
File /nonfatal /a /r "files_overwrite\"

SetOverwrite off
File /nonfatal /a /r "files_question\"

WriteUninstaller "${EXE_NAME_UNINSTALLER}"

;all users can access to program
SetShellVarContext all

;to create the program group
CreateDirectory "$SMPROGRAMS\Railwaymania"

;to create the shortcut to the application
CreateShortCut "$SMPROGRAMS\Railwaymania\RailwayStudio.lnk" "$INSTDIR\${EXE_NAME}"

;to create the program group
CreateDirectory "$SMPROGRAMS\Railwaymania\Utilities"

;to create the shortcut to the uninstaller
CreateShortCut "$SMPROGRAMS\Railwaymania\Utilities\Uninstall RailwayStudio.lnk" "$INSTDIR\${EXE_NAME_UNINSTALLER}"

SetDetailsView hide

;enter refistry keys to add application in the list of Windows installed software
WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayName" "${NAME}"
WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "UninstallString" "$INSTDIR\${EXE_NAME_UNINSTALLER}"
WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "Publisher" "Railwaymania"
WriteRegStr HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}" "DisplayVersion" "${VERSION}"

WriteRegStr HKLM "SOFTWARE\EMDEP\${NAME}" "InstallDir" $INSTDIR
WriteRegStr HKLM "SOFTWARE\EMDEP\${NAME}" "Version" "${VERSION}"

SectionEnd

;UNINSTALLER
;--------------------

Section "Uninstall"

;all users could access to program
SetShellVarContext all

RMDir /r /REBOOTOK $INSTDIR"

Delete "$SMPROGRAMS\Emdep KSK\Studio.lnk"
Delete "$SMPROGRAMS\Emdep KSK\Utilities\Uninstall KSK Studio.lnk"

SetDetailsView hide

DeleteRegKey HKLM "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\${NAME}"

DeleteRegValue HKLM "SOFTWARE\EMDEP\${NAME}" "InstallDir"
DeleteRegValue HKLM "SOFTWARE\EMDEP\${NAME}" "Version"

SectionEnd

Function .onInit
   call IsDotNetInstalledAdv
   !insertMacro MUI_LANGDLL_DISPLAY
FunctionEnd

; Usage
; Define in your script two constants:
;   DOT_MAJOR "(Major framework version)"
;   DOT_MINOR "{Minor framework version)"
;   DOT_MINOR_MINOR "{Minor framework version - last number after the second dot)"
;
; Call IsDotNetInstalledAdv
; This function will abort the installation if the required version
; or higher version of the .NETFramework is not installed.  Place it in
; either your .onInit function or your first install section before
; other code.
Function IsDotNetInstalledAdv
   Push $0
   Push $1
   Push $2
   Push $3
   Push $4
   Push $5

   !define DOT_MAJOR 2
   !define DOT_MINOR 0
   !define DOT_MINOR_MINOR 50727

   StrCpy $0 "0"
   StrCpy $1 "SOFTWARE\Microsoft\.NETFramework" ;registry entry to look in.
   StrCpy $2 0

StartEnum:

   ;Enumerate the versions installed.
   EnumRegKey $3 HKLM "$1\policy" $2

   ;If we don't find any versions installed, it's not here.
   StrCmp $3 "" noDotNet notEmpty

;We found something.
notEmpty:

   ;Find out if the RegKey starts with 'v'.
   ;If it doesn't, goto the next key.
   StrCpy $4 $3 1 0
   StrCmp $4 "v" +1 goNext
   StrCpy $4 $3 1 1

   ;It starts with 'v'.  Now check to see how the installed major version
   ;relates to our required major version.
   ;If it's equal check the minor version, if it's greater,
   ;we found a good RegKey.
   IntCmp $4 ${DOT_MAJOR} +1 goNext yesDotNetReg

   ;Check the minor version.  If it's equal or greater to our requestedversion then we're good.
   StrCpy $4 $3 1 3
   IntCmp $4 ${DOT_MINOR} +1 goNext yesDotNetReg

   ;detect sub-version - e.g. 2.0.50727
   ;takes a value of the registry subkey - it contains the small version number
   EnumRegValue $5 HKLM "$1\policy\$3" 0

   IntCmpU $5 ${DOT_MINOR_MINOR} yesDotNetReg goNext yesDotNetReg

goNext:

   ;Go to the next RegKey.
   IntOp $2 $2 + 1
   goto StartEnum

yesDotNetReg:

    ;Now that we've found a good RegKey, let's make sure it's actually
    ;installed by getting the install path and checking to see if the
    ;mscorlib.dll exists.
    EnumRegValue $2 HKLM "$1\policy\$3" 0
    ;$2 should equal whatever comes after the major and minor versions
    ;(ie, v1.1.4322)
    StrCmp $2 "" noDotNet
    ReadRegStr $4 HKLM $1 "InstallRoot"
    ;Hopefully the install root isn't empty.
    StrCmp $4 "" noDotNet
    ;build the actuall directory path to mscorlib.dll.
    StrCpy $4 "$4$3.$2\mscorlib.dll"
    IfFileExists $4 yesDotNet noDotNet

  noDotNet:
    ;Nope, something went wrong along the way.  Looks like the
    ;proper .NETFramework isn't installed.

    ;Uncomment the following line to make this function throw a message box right away
    MessageBox MB_OK "You must have v${DOT_MAJOR}.${DOT_MINOR}.${DOT_MINOR_MINOR} or greater of the .NETFramework installed.  Aborting!"
    Abort
     StrCpy $0 0
     Goto done

     yesDotNet:
    ;Everything checks out.  Go on with the rest of the installation.
    StrCpy $0 1

   done:
     Pop $4
     Pop $3
     Pop $2
     Pop $1
     Exch $0
 FunctionEnd

