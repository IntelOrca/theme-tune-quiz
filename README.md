Theme Tune Quiz (TTQ)
=====================
An application which creates "name the theme tune" quizzes from a directory of mp3 tracks.

Populating the database
-----------------------
Place mp3 files in a folder called 'music' inside the application directory. When you
load TTQ, goto 'Edit theme tunes'. It will confirm whether you want to include the new
mp3 files into the ttq database. Click yes and then set the correct information for each
track which should be at the bottom of the list. You can specify the start and playing
time for each track, and record a genre for the track (e.g. "TV" or "Film"). This allows
you to select the memorable part of the track and may allow you to avoid a section of
tracks that might give the answer away.

Creating a quiz
---------------
You can create a quiz using the menus provided. You can select which genres you want to
include in each round, how many tunes to include, and an option for restricting the length
of the track for expert modes (2 second, 5 second). The quiz can then be saved as a .ttq
file which is later loaded when you want to play through the quiz or view the answers.

Fast play
---------
A single player game or multiplayer cooperative game where random tracks will be played
and the player must type what they think the answer is as soon as they recognise it.

Compiling
---------
The application can be compiled with .NET Framework 3.5 or later. The music player currently
uses the MCI api (which is only available for Windows) to play the tracks.