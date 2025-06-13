using System;
using System.Drawing;
using OpenCvSharp.Extensions;
using OpenCvSharp;

namespace Test_软包电池定位极耳中心
{
    internal class ImageRotate
    {
        public static Mat Rotate(Mat srcImg, double angle)
        {
            if (srcImg == null)
                throw new Exception("输入图像为null！");
            // 计算旋转矩阵
            var center = new Point2f(srcImg.Width / 2, srcImg.Height / 2);
            var rotationMatrix = Cv2.GetRotationMatrix2D(center, angle, 1.0);

            // 计算旋转后的图像的边界框大小
            double cos = Math.Abs(rotationMatrix.At<double>(0, 0));
            double sin = Math.Abs(rotationMatrix.At<double>(0, 1));
            int newWidth = (int)(srcImg.Height * sin + srcImg.Width * cos);
            int newHeight = (int)(srcImg.Width * sin + srcImg.Height * cos);

            // 调整旋转矩阵的平移部分，以确保图像居中
            rotationMatrix.Set(0, 2, rotationMatrix.At<double>(0, 2) + (newWidth - srcImg.Width) / 2);
            rotationMatrix.Set(1, 2, rotationMatrix.At<double>(1, 2) + (newHeight - srcImg.Height) / 2);

            // 创建目标图像矩阵，并应用旋转变换
            Mat rotatedImage = new Mat();
            Cv2.WarpAffine(srcImg, rotatedImage, rotationMatrix, new OpenCvSharp.Size(newWidth, newHeight));

            return rotatedImage;
        }
    }
}
