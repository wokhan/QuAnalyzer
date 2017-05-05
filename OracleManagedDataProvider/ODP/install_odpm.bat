@echo off
REM ===========================================================
REM ODP.NET, Managed Driver 12c Release 3 Beta 2 INSTALL SCRIPT
REM ===========================================================
REM 
REM  This batch file installs ODP.NET, Managed Driver

goto :ParseArgs



REM ************
REM INSTALL ODPM
REM ************

:odpm

echo ********************************** >> %1\install.log
echo Installing ODP.NET, Managed Driver >> %1\install.log
echo ********************************** >> %1\install.log

REM copy the files
xcopy odp.net %1\odp.net\ /E /F /R /Y >> %1\install.log

echo.>> %1\install.log

REM not calling configure.bat as follows since on Win2k when dir names contain 
REM a space it has issues when retreiving CURRENT DIR in configure.bat
REM call %1\configure.bat odp.net4 %3

if /i {%2} == {x86} (
  pushd %1\odp.net\managed\x86
  call configure.bat %MACHINE_WIDE_CONFIG_ODPM%
)
if /i {%2} == {x64} (
  pushd %1\odp.net\managed\x64
  call configure.bat %MACHINE_WIDE_CONFIG_ODPM%
)
if /i {%2} == {both} (
  pushd %1\odp.net\managed\x86
  call configure.bat %MACHINE_WIDE_CONFIG_ODPM%
  popd
  pushd %1\odp.net\managed\x64
  call configure.bat %MACHINE_WIDE_CONFIG_ODPM%
)
popd

echo.>> %1\install.log
echo ********************************* >> %1\install.log
echo ODP.NET, Managed Driver installed >> %1\install.log
echo ********************************* >> %1\install.log
echo.>> %1\install.log

goto :EOF



REM =======================
REM Parse Script Arguments
REM =======================
:ParseArgs
if /i {%1} == {} goto :Usage
if /i {%2} == {} goto :Usage
if /i {%1} == {-h} goto :Usage
if /i {%1} == {-help} goto :Usage

REM configure machine wide or not - default is true
set MACHINE_WIDE_CONFIG_ODPM=true
if /i {%3} == {false} set MACHINE_WIDE_CONFIG_ODPM=false

if NOT EXIST %1\*.* (
  mkdir %1 > NUL 2>&1
)

echo ****************** >> %1\install.log
echo ODPM install files >> %1\install.log
echo ****************** >> %1\install.log
REM /R to overwrite readonly files at destination
REM /Y to overwrite an existing file without prompting
xcopy uninstall_odpm.bat %1 /R /Y /F >> %1\install.log
xcopy network\admin\sample\tnsnames.ora %1\network\admin\sample\ /R /Y /F >> %1\install.log
xcopy network\admin\sample\sqlnet.ora %1\network\admin\sample\ /R /Y /F >> %1\install.log


echo.>> %1\install.log

if /i {%2} == {x64}  goto :odpm
if /i {%2} == {x86}  goto :odpm
if /i {%2} == {both} goto :odpm
goto :Usage


:Usage
echo.
echo Usage:
echo   install_odpm.bat oracle_home_path platform [machine_wide_configuration]
echo.
echo   Required platform argument can be set to : x86, x64, or both
echo   Optional machine_wide_configuration argument can be set to : true or false
echo   By default, machine_wide_configuration is true.
echo.
echo Example:
echo   install_odpm.bat c:\oracle x64        (install and configure ODP.NET, Managed Driver at the machine wide level for x64 applications)
echo   install_odpm.bat c:\oracle x86  false (install but do not configure ODP.NET, Managed Driver at the machine wide level for x86 applications)
echo   install_odpm.bat c:\oracle both true  (install and configure ODP.NET, Managed Driver at the machine wide level for both x86 and x64 applications)
echo.
goto :EOF
