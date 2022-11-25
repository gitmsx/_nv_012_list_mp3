@echo off

if not exist ".git" goto :already
echo.
echo    GIT already found !!!!!
echo.
echo    Exiting...
goto :finished


:already

if not exist ".gitignore" goto :fail_message
echo.
echo    GIT ignore GOOD 
echo.
echo    Exiting...

rem *************************
rem *************************
rem *************************


echo "# _nv_012_list_mp3" >> README.md
git init
git add README.md
git commit -m "first commit"
git branch -M main
git remote add origin https://github.com/gitmsx/_nv_012_list_mp3.git
git push -u origin main
rem *************************
rem *************************


goto finished
:fail_message
echo.
echo    Unfortunately GIT ignore not found
echo.
echo    Exiting...
timeout 1 >nul
goto finished        

rem    ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
:finished
exit