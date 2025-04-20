#!/bin/bash
clear

START=$(date +"%s")
#PROJECT_PATH="$(dirname "$(PWD)")"
PROJECT_PATH="$(PWD)"


# PARAMS ----------------------------------------------------

#TEMPLATE_FILE=$(PWD)'/template.html'
#MANIFEST_FILE=$(PWD)'/manifest.plist'
#VERSION_FILE=$(PWD)'/version.txt'

LOGS_PATH=$PROJECT_PATH'/Logs'

VR_BUILD=$PROJECT_PATH'/Builds/VR'
VR_PC_BUILD=$PROJECT_PATH'/Builds/VR_PC'

CONSOLE_ANDROID_BUILD=$PROJECT_PATH'/Builds/ConsoleAndroid'
CONSOLE_PC_BUILD=$PROJECT_PATH'/Builds/ConsolePC'


SERVER_PC_BUILD=$PROJECT_PATH'/Builds/ServerPC'


BUILDS_PATH=$PROJECT_PATH'/Builds'

UNITY='unity'

# -----------------------------------------------------------

[ -d "$LOGS_PATH" ] || mkdir "$LOGS_PATH"

[ -d "$BUILDS_PATH" ] || mkdir "$BUILDS_PATH"

[ -d "$VR_BUILD" ] || mkdir "$VR_BUILD"
[ -d "$VR_PC_BUILD" ] || mkdir "$VR_PC_BUILD"

[ -d "$CONSOLE_ANDROID_BUILD" ] || mkdir "$CONSOLE_ANDROID_BUILD"
[ -d "$CONSOLE_PC_BUILD" ] || mkdir "$CONSOLE_PC_BUILD"

[ -d "$SERVER_PC_BUILD" ] || mkdir "$SERVER_PC_BUILD"


# functions -------------------------------------------------
function UpdateRepo {
  echo 'UpdateRepo not implemented'
}
function Tests {
  echo '' 
  echo '|||||||||||||||||||||||||||||||' 
  echo '|                             |' 
  echo '|        Project test         |' 
  echo '|                             |' 
  echo '|||||||||||||||||||||||||||||||' 
  echo ''
  echo ''
  echo 'test unity...' 
  echo '' 
  $UNITY -runTests -batchmode -projectPath "$PROJECT_PATH" -testResults "$LOGS_PATH/test.xml"
  echo ''
  echo 'tests completed' 
  echo ''
  pause
}
function VRAndroid {
  echo '' 
  echo '|||||||||||||||||||||||||||||||' 
  echo '|                             |' 
  echo '|     VR Android build        |' 
  echo '|                             |' 
  echo '|||||||||||||||||||||||||||||||' 
  echo ''
  echo ''
  echo 'build unity and archive APK...' 
  echo '' 
  $UNITY -batchmode -quit -projectPath "$PROJECT_PATH" -executeMethod Build.BuildActions.VR_Android_Build -buildTarget android -logFile "$LOGS_PATH/VR_Android_build.log"
  if [ $? -ne 0 ]; then
  echo ''
  echo 'Operation failed!'
  echo '' 
  pause
  exit 1
  fi
  echo ''
  echo 'build completed' 
  echo 
  pause
  exit 1
}

function VRPC {
  echo '' 
  echo '|||||||||||||||||||||||||||||||' 
  echo '|                             |' 
  echo '|     VR PC      build        |' 
  echo '|                             |' 
  echo '|||||||||||||||||||||||||||||||' 
  echo ''
  echo ''
  echo 'build unity and archive exe...' 
  echo '' 
  $UNITY -batchmode -quit -projectPath "$PROJECT_PATH" -executeMethod Build.BuildActions.VR_PC_Build -buildTarget win64 -logFile "$LOGS_PATH/VR_PC_build.log"
  if [ $? -ne 0 ]; then
  echo ''
  echo 'Operation failed!'
  echo '' 
  pause
  exit 1
  fi
  echo ''
  echo 'build completed' 
  echo 
  pause
  exit 1
}

function ServerPC {
  echo '' 
  echo '|||||||||||||||||||||||||||||||' 
  echo '|                             |' 
  echo '|         ServerPC            |' 
  echo '|                             |' 
  echo '|||||||||||||||||||||||||||||||' 
  echo ''
  echo ''
  echo 'build unity and archive exe...' 
  echo '' 
  $UNITY -batchmode -quit -projectPath "$PROJECT_PATH" -executeMethod Build.BuildActions.Server_DedicatedWindow_Build -buildTarget win64 -logFile "$LOGS_PATH/Server_PC_build.log"
  if [ $? -ne 0 ]; then
  echo ''
  echo 'Operation failed!'
  echo '' 
  pause
  exit 1
  fi
  echo ''
  echo 'build completed' 
  echo 
  pause
  exit 1
}
# -----------------------------------------------------------


# Entry point -----------------------------------------------

echo '' 
echo '' 
echo '' 
echo '|||||||||||||||||||||||||||||||' 
echo '|                             |' 
echo '|       Build pipeline        |' 
echo '|                             |' 
echo '|||||||||||||||||||||||||||||||' 
echo ''
echo ''
echo ''
echo "0 – Update branch $BRANCH"
echo ''
echo '1 – Run tests'
echo ''
echo '2 – Vr android                | Client'
echo '3 – Vr pc with simulator      | Client'
echo '' 
echo '4 – Android console           | Client'
echo '5 – Windows console           | Client'
echo ''
echo '6 – Dedicated server windows  | Server'
echo '' 
echo '' 
read -n 1 -s -r -p 'Select build type, ESC to cancel...' key
echo ''
if [ "$key" == $'\e' ]; then
  echo '' 
  echo '' 
  echo 'Operation canceled!'
  echo '' 
  echo '' 
  exit 1
fi
  clear
  case $key in 0)
    UpdateRepo
  ;; 
  1)
    Tests
  ;;
  2)
    VRAndroid
  ;;
  3)
    VRPC
  ;;
  6)
    ServerPC
  ;;
  *)
    
  ;;
  esac
    
#@echo off
#set /p a="omn" 
#  
#
##echo %a%
#echo $START
#echo $PROJECT_PATH
#
#read -n 1 -s -r -p 'Select build type, ESC to cancel...' key
pause
# -----------------------------------------------------------