using System;
using System.Runtime.InteropServices;
using OpenCvSharp;

class Startup {

    public OSType OS;
    public enum OSType{
        Windows,
        Linux
    }

    static void Main(){
        Startup startup = new Startup();
        startup.Start();
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