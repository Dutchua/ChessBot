using System;
using System.Runtime.InteropServices;
using OpenCvSharp;
using BoardStateLogic;
using System.Data;

class Startup {

    public OSType OS;
    public enum OSType{
        Windows,
        Linux
    }

    static void Main(){
        Startup startup = new Startup();
        startup.Start();
        BoardState boardState = new BoardState();
        boardState.FENtoBoardState();
    }

    public void Start(){
        OS = DetectOS();
        // Camera();
    }

    private OSType DetectOS(){
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
            return OSType.Linux;
        }else {
            return OSType.Windows;
        }
    }
}