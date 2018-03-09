/*1030513312 那婉纯*/

using UnityEngine;
using System.Collections;
using OpenCvSharp;

public class VideoTest : MonoBehaviour
{
    private Camera _camera;
    public GameObject 投影屏幕;
    Material m_material;
    public GameObject m_Cube;
    public WebCamTexture cameraTexture;
    Texture2D rt;
    private string cameraName = "";
    private bool isPlay = true;
    static int mPreviewWidth = 320;//（这个分辨率可以自己调，分辨率越高越卡，我的电脑这个就刚刚好）  
    static int mPreviewHeight = 180;
    bool state = true;
    CascadeClassifier haarCascade;
    WebCamDevice[] devices;
    // Use this for initialization
    void Start()
    {
        m_material = 投影屏幕.GetComponent<MeshRenderer>().material;
        rt = new Texture2D(mPreviewWidth, mPreviewHeight, TextureFormat.RGB565, false);
        temp = new Texture2D(mPreviewWidth, mPreviewHeight, TextureFormat.RGB565, false);
        StartCoroutine(Test());
        haarCascade = new CascadeClassifier(Application.streamingAssetsPath + "/haarcascades/haarcascade_frontalface_alt2.xml"); 
        //加载级联分类器 调用CascadeClassifier类成员函数load实现
        _camera = Camera.main;
    }

    // Update is called once per frame
    float timer;
    void Update()
    {
        timer += Time.deltaTime;
        if (cameraTexture != null)
        {
            haarResult = DetectFace(haarCascade, GetTexture2D(cameraTexture));
            bs = haarResult.ToBytes(".png");
            rt.LoadImage(bs);
            rt.Apply();
            m_material.mainTexture = rt;
            // print(center.X+","+center.Y);
            // m_Cube.transform.localPosition = Vector3.Slerp(m_Cube.transform.localPosition, new Vector3(Mathf.Abs(center.X - 360)*6, -center.Y*6, 0), 0.5f);
            m_Cube.transform.localPosition = new Vector3((center.X-100)*6 , (-ty +20)* 6 , 0);
            m_Cube.transform.localScale= new Vector3(Width*1.5f, Width*1.5f, 0);


        }
    }
    IEnumerator Test()
    {
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);//调用外部摄像头
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            devices = WebCamTexture.devices;
            if (devices==null)
            {
                Debug.LogError("没有找到摄像头！");
            }
            cameraName = devices[0].name;
            cameraTexture = new WebCamTexture(cameraName, mPreviewWidth, mPreviewHeight);
            cameraTexture.Play();
            isPlay = true;
        }
    }
    Mat haarResult;
    byte[] bs;
    
    Mat result;
    OpenCvSharp.Rect[] faces;
    Mat src;
    Mat gray = new Mat();
    Size axes = new Size();
    Point center = new Point();
    int Width;
    int ty;

    private Mat DetectFace(CascadeClassifier cascade, Texture2D t)
    {
        src = Mat.FromImageData(t.EncodeToPNG(), ImreadModes.Color);
        result = src.Clone();             
        Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
        src = null;
        // Detect faces
        //DetectMultiScale函数在输入图像的不同尺度中检测物体，参数image为输入的灰度图像，
        //objects为得到被检测物体的矩形框向量组，
        //scaleFactor为每一个图像尺度中的尺度参数，默认值为1.1，
        //minNeighbors参数为每一个级联矩形应该保留的邻近个数（没能理解这个参数，-_-|||），默认为3，flags对于新的分类器没有用
        faces = cascade.DetectMultiScale(gray, 1.08, 2, HaarDetectionType.ScaleImage, new Size(30, 30));

        // Render all detected faces
        for (int i = 0; i < faces.Length; i++)
        {
            Width = (int)faces[0].Width;
            ty = (int)faces[0].Y;
            center.X = (int)(faces[0].X + faces[0].Width * 0.5); 
            center.Y = (int)(faces[0].Y + faces[0].Height * 0.5);
            axes.Width = (int)(faces[0].Width * 0.5);
            axes.Height = (int)(faces[0].Height * 0.5);
           // Cv2.Ellipse(result, center,
           //     axes, //长轴短轴
             //   0, 0, 360,   //旋转角度
            //    new Scalar(255, 0, 255), 4    //颜色线宽
            //    );//显示人脸范围
        }
        return result;
    }
    Texture2D temp;
    Texture2D GetTexture2D(WebCamTexture wct)
    {
        temp.SetPixels(wct.GetPixels());
        temp.Apply();
        return temp;
    }
}
