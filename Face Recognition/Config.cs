using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Face_Recognition
{
    class Config
    {
        //Cofigurate the PhotoSavePath and LogSavePath 
        public string PhotoSavepPath = @"C:\Users\YUNUS EMRE\source\repos\Face Recognition\Face Recognition\Images";
        public string LogSavePath = @"C:\Users\YUNUS EMRE\source\repos\Face Recognition\Face Recognition\bin\Debug";
        public string HaarCascadePath = "haarcascade_frontalface_alt.xml";
        public string RtspUrl = "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov";
        public string MailAddressTo = "ynsemrektk@gmail.com";
    }
}
