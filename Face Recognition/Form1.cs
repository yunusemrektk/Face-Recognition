using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Net.Mail;
using System.Threading;
using AForge.Video;
using OpenTK.Graphics.ES11;
using Newtonsoft.Json;
using AForge.Video.DirectShow;

namespace Face_Recognition
{
    public partial class Form1 : Form
    {
        #region Variables
        private Capture videoCapture = null;
        private Image<Bgr, Byte> currentFrame = null;
        private bool isOnce = false;
        private bool faceDetectionEnabled = false;
        Mat frame = new Mat();
        CascadeClassifier faceCascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
        Image<Bgr, Byte> resultImage = null;
        private bool captureOn;
        int Count = 0;
        string path = @"C:\Users\YUNUS EMRE\source\repos\Face Recognition\Face Recognition\Images";
        string logpath = @"C:\Users\YUNUS EMRE\source\repos\Face Recognition\Face Recognition\bin\Debug";
        string Image_Name = null;
        int IDCount = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            isOnce = true;

        }


        private void ProcessFrame(object sender, EventArgs e)
        {
            if (videoCapture != null)
            {


                //Video Capture

                videoCapture.Retrieve(frame, 0);

                currentFrame = frame.ToImage<Bgr, byte>().Resize(pictureCapture.Width, pictureCapture.Height, Inter.Cubic);

                if (faceDetectionEnabled)
                {


                    Mat grayImage = new Mat();

                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image 
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = faceCascadeClassifier.DetectMultiScale(grayImage, 1.1, 6, Size.Empty, Size.Empty);



                    if (faces.Length > 0)
                    {
                        foreach (var face in faces)
                        {
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            resultImage = currentFrame.Convert<Bgr, Byte>();
                            //resultImage.ROI = face;
                        }


                        if (faces.Length > 2)
                        {
                            //Check if 3 person stable in the frame

                            Count++;
                            if (Count == 5)
                            {
                                if (isOnce == true)
                                {

                                    Image_Name = path + @"\" + "Person" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg";
                                    resultImage.Save(Image_Name);
                                    // Non-Stop Mailing.
                                    Thread th = new Thread(Send_Email);
                                    th.Start();
                                    isOnce = false;





                                }
                            }
                        }

                    }
                }

                pictureCapture.Image = currentFrame.Bitmap;
            }

            GC.RemoveMemoryPressure(1028);
            GC.Collect();


        }

        private void Send_Email()
        {
            //Json Logger
            Logs log = new Logs()
            {
                Date = DateTime.Now.ToString(),
                Id = IDCount
            };
            string strResultJson = JsonConvert.SerializeObject(log);
            File.AppendAllText(@"log.json", strResultJson + Environment.NewLine);


            MailMessage message = new MailMessage();
            message.To.Add("ynsemrektk@gmail.com");
            message.From = new MailAddress("ynsemrektk@hotmail.com");
            message.Subject = "Test";
            message.Body = "Deneme";
            System.Net.Mail.Attachment att;
            System.Net.Mail.Attachment att2;
            att2 = new Attachment(logpath + @"\log.json");
            att = new Attachment(Image_Name);
            message.Attachments.Add(att);
            message.Attachments.Add(att2);

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("ynsemrektk@hotmail.com", "Cimbom1905.");
            client.Port = 587;
            client.Host = "smtp.live.com";
            client.EnableSsl = true;
            client.Send(message);
        }

        private void CapturePlay()
        {
            if (!String.IsNullOrEmpty(textBox1.Text))
            {

                videoCapture = new Capture(textBox1.Text);
                videoCapture.QueryFrame();

                videoCapture.ImageGrabbed += ProcessFrameRTSP;
                videoCapture.Start();
            }
        }

        private void ProcessFrameRTSP(object sender, EventArgs e)
        {
            if (videoCapture != null)
            {
                //Video Capture
                videoCapture.Retrieve(frame, 0);

                currentFrame = frame.ToImage<Bgr, byte>();

                if (faceDetectionEnabled)
                {
                    Mat grayImage = new Mat();

                    CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                    //Enhance the image 
                    CvInvoke.EqualizeHist(grayImage, grayImage);

                    Rectangle[] faces = faceCascadeClassifier.DetectMultiScale(grayImage, 1.1, 1, Size.Empty, Size.Empty);

                   if (faces.Length > 0)
                    {
                        foreach (var face in faces)
                        {
                            CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);

                            resultImage = currentFrame.Convert<Bgr, Byte>();
                            //resultImage.ROI = face;
                        }

                        if (faces.Length > 2)
                        {
                            //Check if 3 person stable in the frame

                            Count++;
                            if (Count == 5)
                            {
                                if (isOnce == true)
                                {

                                    Image_Name = path + @"\" + "Person" + DateTime.Now.ToString("dd-mm-yyyy-hh-mm-ss") + ".jpg";
                                    resultImage.Save(Image_Name);
                                    // Non-Stop Mailing.
                                    Thread th = new Thread(Send_Email);
                                    th.Start();
                                    isOnce = false;

                                }
                            }
                        }

                    }
                }
                double framerate = videoCapture.GetCaptureProperty(CapProp.Fps);
                Thread.Sleep((int)(1000.0 / framerate));
                pictureCapture.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureCapture.Image = currentFrame.Bitmap;
            }

        }
 
        private void DetectionEnable()
        {

            faceDetectionEnabled = true;
        }
 
        void WebcamBaslat()
        {
            if (videoCapture != null) videoCapture.Dispose();
            videoCapture = new Capture();
            Application.Idle += ProcessFrame;

        }
        
        void Stop()
        {
            videoCapture.Stop();
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            CapturePlay();
        }

        private void buttonDetect_Click_1(object sender, EventArgs e)
        {
            DetectionEnable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WebcamBaslat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Stop(); 
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text= "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mov";
        }
    }
}
