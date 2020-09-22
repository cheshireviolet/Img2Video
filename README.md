# Img2Video

Convert a batch of images into a video with options to add text, music and more! I made this because my mother needed a tool like this and doing by herself using video/image editors take too long when doing simple things.

## Latest Release

You can find the latest version [here](https://github.com/cheshireviolet/Img2Video/releases).

## Requirements

If you simply wanna use the tool, you'll need these:

* Windows
* [ffmpeg](https://ffmpeg.org/download.html) (lastest build should work)

If you're a developer and want to make your own adjustments, you'll also need:

* Visual Studio 2019
* .NET Framework 4.7.2

## Setup

1. Put ffmpeg.exe, ffplay.exe and ffprobe.exe in the same folder as the program.
2. Create a folder called "img" and put the images you wanna use there. They should be named 001.\*, 002.\*, 003.\*, etc.
3. If you want to add a song, rename it to "song.mp3" in the same folder as Img2Video. It has to be mp3 for now
4. Ready to go! Just open Img2Video and tweak the settings, press "Create" when ready. And alert will pop up when ready.
