# Idle Cats

 Idle Cats is an idle game where you can collect cats and build rooms to get closer to word domination

## Installation Instructions for Editing and Testing Code

1. Install Unity 2021.3.7f1 (note while this may work on other versions of Unity this is untested so we recommend this version)
2. Install any IDE that can edit C# scripts
3. Clone the release branch from GitHub
4. Unzip the folder called Firebase.zip and move it into the assets folder
5. Launch the project in Unity Hub

## Warnings that appear when you open in Unity
The following are warnings that are normal and have no effect on the game.
If you get any warnings other than the ones listed below please let us know.

1. 86 node options failed to load and were skipped.
2. 164 node options failed to load and were skipped.
3. 242 node options failed to load and were skipped.
4. Assets\Scripts\PartyCat.cs(16,19): warning CS0108: 'PartyCat.camera' hides inherited member 'Component.camera'. Use the new keyword if hiding was intended.
5. Assets\Scripts\ResourceRoomHelper.cs(12,23): warning CS0109: The member 'ResourceRoomHelper.name' does not hide an accessible member. The new keyword is not required.
6. Assets\Scripts\TimerRoom.cs(9,18): warning CS0414: The field 'TimerRoom.researching' is assigned but its value is never used
7. Assets\Scripts\StealingRoom.cs(16,20): warning CS0414: The field 'StealingRoom.roomTitle' is assigned but its value is never used
8. Assets\Scripts\Rooms\Artifact Rooms\ArtifactRoom.cs(22,20): warning CS0414: The field 'ArtifactRoom.roomTitle' is assigned but its value is never used
9. Assets\Scripts\Game Control\Ads\TestAdButton.cs(13,29): warning CS0414: The field 'TestAdButton._iOSAdUnitId' is assigned but its value is never used
10. 320 node options failed to load and were skipped.

You may also on occasion get a memory leak error when running the code. This is not a memory leak and is caused by the playfab package.
There is no current way to fix this error

## Installation Instructions for The APK Release (installing the app itself)
1. Download apk file from the latest release on an android phone or a device with an android emulator installed
2. Open the apk file and install the app
3. Open the app when you have an internet connection, it may take some time to load on the first load.

## Contributing
Pull requests and constructive criticism are welcomed. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.