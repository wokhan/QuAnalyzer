@echo off
REM =============================================================
REM ODP.NET, Managed Driver 12c Release 3 Beta 2 UNINSTALL SCRIPT
REM =============================================================
REM 
REM  This batch file uninstalls ODP.NET, Managed Driver
 
 
goto :ParseArgs 
 
 
REM ********************************* 
REM UNINSTALL ODP.NET, Managed Driver
REM *********************************

 
:odpm
 
REM proceed only if component is installed 
if EXIST %1\odp.net\managed\common\Oracle.ManagedDataAccess.dll ( 
 
echo ************************************ >> uninstall.log 
echo Uninstalling ODP.NET, Managed Driver >> uninstall.log 
echo ************************************ >> uninstall.log 
 
if /i {%2} == {x86} (
  pushd %1\odp.net\managed\x86
  call unconfigure.bat %MACHINE_WIDE_UNCONFIG_ODPM%
)
if /i {%2} == {x64} (
  pushd %1\odp.net\managed\x64
  call unconfigure.bat %MACHINE_WIDE_UNCONFIG_ODPM%
)
if /i {%2} == {both} (
  pushd %1\odp.net\managed\x86
  call unconfigure.bat %MACHINE_WIDE_UNCONFIG_ODPM%
  popd
  pushd %1\odp.net\managed\x64
  call unconfigure.bat %MACHINE_WIDE_UNCONFIG_ODPM%
)

popd
pushd %1

del /f odp.net\managed\x64\configure.bat  2>nul
del /f odp.net\managed\x64\OraProvCfg.exe  2>nul
del /f odp.net\managed\x64\Oracle.ManagedDataAccessDTC.dll  2>nul
del /f odp.net\managed\x64\Oracle.ManagedDataAccessIOP.dll  2>nul
del /f odp.net\managed\x64\unconfigure.bat  2>nul
del /f odp.net\managed\x86\configure.bat  2>nul
del /f odp.net\managed\x86\OraProvCfg.exe  2>nul
del /f odp.net\managed\x86\Oracle.ManagedDataAccessDTC.dll  2>nul
del /f odp.net\managed\x86\Oracle.ManagedDataAccessIOP.dll  2>nul
del /f odp.net\managed\x86\unconfigure.bat  2>nul
del /f odp.net\managed\common\EF6\Oracle.ManagedDataAccess.EntityFramework.dll  2>nul
del /f odp.net\managed\common\Oracle.ManagedDataAccess.dll  2>nul
del /f odp.net\managed\PublisherPolicy\4\Policy.4.121.Oracle.ManagedDataAccess.config  2>nul
del /f odp.net\managed\PublisherPolicy\4\Policy.4.121.Oracle.ManagedDataAccess.dll  2>nul

rmdir odp.net\managed\x64 2>nul
rmdir odp.net\managed\x86 2>nul
rmdir odp.net\managed\common\EF6 2>nul
rmdir odp.net\managed\common 2>nul
rmdir odp.net\managed\PublisherPolicy\4 2>nul
rmdir odp.net\managed\PublisherPolicy 2>nul
rmdir odp.net\managed 2>nul

popd
 
echo.>> uninstall.log 
echo *********************************** >> uninstall.log 
echo ODP.NET, Managed Driver uninstalled >> uninstall.log 
echo *********************************** >> uninstall.log 
echo.>> uninstall.log 
) 

 
goto :EOF 
 

 
 
REM ======================= 
REM Parse Script Arguments 
REM ======================= 
:ParseArgs 
if /i {%1} == {} goto :Usage 
if /i {%2} == {} goto :Usage 
if /i {%1} == {-h} goto :Usage 
if /i {%1} == {-help} goto :Usage 

REM unconfigure machine wide or not - default is true
set MACHINE_WIDE_UNCONFIG_ODPM=true
if /i {%3} == {false} set MACHINE_WIDE_UNCONFIG_ODPM=false
 
if /i {%2} == {x64}  goto :odpm
if /i {%2} == {x86}  goto :odpm
if /i {%2} == {both} goto :odpm
  
goto :Usage  
 
 
:Usage 
echo. 
echo Usage: 
echo   uninstall_odpm.bat oracle_home_path platform [machine_wide_unconfiguration]
echo. 
echo   Required platform argument can be set to : x86, x64, or both
echo   Optional machine_wide_unconfiguration argument can be set to : true or false
echo   By default, machine_wide_unconfiguration is true.
echo.
echo Example: 
echo   uninstall_odpm.bat c:\oracle x64       (uninstall and unconfigure ODP.NET, Managed Driver which was configured at a machine wide level) 
echo   uninstall_odpm.bat c:\oracle x86 false (uninstall and unconfigure ODP.NET, Managed Driver which was configured at a machine wide level) 
echo   uninstall_odpm.bat c:\oracle x64 true  (uninstall and unconfigure ODP.NET, Managed Driver which was not configured at a machine wide level)  
goto :EOF
 
