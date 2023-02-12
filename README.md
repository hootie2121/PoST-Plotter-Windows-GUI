# PoST Plotter Windows GUI

## Purpose
PoSTPWG is a simple graphical user interface for Windows to be used with madMAx43v3r's Chia Gigahorse CPU and GPU plotters that may be obtained from [HERE](https://github.com/madMAx43v3r/chia-gigahorse). PoSTPWG has no affiliation with madMAx or his software. PoSTPWG was composed entirely by OpenAI's ChatGPT and compiled by someone with no programming skills whatsoever. Please keep that in mind as this program is an experiment to push the limits of the AI revolution while trying to fill a small, niche usecase.

## Installation
1. Download the latest release from the GitHub repository [HERE](https://github.com/hootie2121/PoST-Plotter-Windows-GUI/releases). Note: This is currently the only trusted location to download this software. Caution should be taken if obtaining PoSTPWG from any other source.
2. Unzip the dowloaded file and place in a file/directory of your choice. Tip: Placing PoSTPWG in the same folder with the plotting software will improve the ease of use however, this is not necessary.
3. Run the .exe. If PoSTPWG is not in the same directory as the plotters, you will receive a file dialog box asking you to navigate to the various plotters (eg. chia_plot.exe, chia_plot_k34.exe, cuda_plot_k26.exe, etc.). Once all plotters have been selected, a config file will be generated with their paths. If the .exe is in the same location as the plotters, the config will automatically generate and add the paths.

## Running
Enter the preferred variables into the given options. When ready, hit "Read. Set. Plot!" which will send the command to the appropriate plotting software. The typical CLI window should pop-up where you can follow the plots progress.

## Advanced Options
### Debugging
Either if you are running into errors, if the program will not start the plot or, you are just curious which arguments are being passed along to the plotting program; you may utilze the debug setting located in the "Options" menu. When active, dialog boxes should be visible near each setting with the software argument (eg. -k, -C, -N, etc.) and the value associated with it. All values should match those entered by the user. If they do not, that is likely due to a bug and should be reported as such on GitHub.
### Config
Several options associated with the config file may also be found in the "Options" menu. 
1. You may directly open the config file to see and or edit it's contents. 
2. You may open the location the config file.
3. You may clear the config file. This will result in PoSTPWG restarting and prompting the rentry of the plotting paths.

## Bugs
Curently, there are many known and unknown bugs due to the alpha nature of this project.
### Known
1. Most current Menu options have no function associated with them
2. There is no current hard stops inplace preventing the start of plotting if necessary arguments are omitted or invalid
### Unknown
For any bugs not mentioned above, please check for the issue [HERE](https://github.com/hootie2121/PoST-Plotter-Windows-GUI/issues) in the GitHub repo. If you find the bug or a similar bug mentioned, please add a comment further explaing your situation to help identify the problem. If you do not find the bug or a similar bug, please enter a new issue. Along with provding a detailed description of the bug, please also tag the bug appropriately (Severe Bug, Moderate Bug, Minor Bug) so that addressing of bugs happen in a relevant order.

## Planned Improvements
In no particular order:
- Add advanced option to allow the manual entry of additional arguments that are not currently supported in the UI
- Allow for the saving of all entries as a profile for quick resuming of plotting
- Allow for just the saving of Account Keys for quick switching of plotting accounts
- Add additional plotting arguments as options in the UI
- Move the outside CLI screen into a print screen within the UI to monitor plotting process
- Implement a status bar for individual plots
- Implement a status bar for n plots to be created
- Implement automatic plot checking of completed plots
- Integrate plot sink into PoSTPWG
- Add program update functionality from application