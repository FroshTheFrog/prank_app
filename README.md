# About
**Disclaimer:** This program was by no means written to be malicious; nor was it written with the capabilities to sneak onto someone's computer. Instead, it was made to mess with one's friends. For this reason, it must be manually installed.

This is a "virus" that was written as a means for one to prank one's friends. It was written using the .net framework in C#. The "virus" lies dormant on one's computer upon its startup. During the virus's specified activation time, if the user presses the space bar or enter, the virus will hijack one's computer. It will turn the user's volume permanently up, and it will cover the screen with a looping playlist of videos. The videos cannot be force-quit, minimized or covered up. Rather, if the user tries to close out of the virus, the user will be prompted to answer trivia questions that appear on the screen. If the user gets three right in a row, they get their computer back... until next time.

# Setup
Any settings that the user wishes to change can be found in: <br />
***/Intel Thermal Management/Intel Thermal Management/My_code/Constants.cs***

You can add and remove videos in the videos folder located in the the program directory where you are bulding to. Alternatively, you can specify to include them during your build.<br />

The user can add and remove questions in the constructor for: <br />
***/Intel Thermal Management/Intel Thermal Management/My_code/Test.cs***

Once you have setup the program how you want. You can easily build an installer using: <br />
https://www.advancedinstaller.com/ <br />
Once it is intalled, it must be run once for it to be setup. <br />

**NOTE:** When setting up the installer, you should choose to launch from the release configuration. When doing this, make sure that you build the latest version of your project from this configuration, not the debug.

**Sounds used:** <br />
http://www.orangefreesounds.com/wrong-answer-sound-effect/ <br />
http://www.orangefreesounds.com/bing-sound/ <br />
