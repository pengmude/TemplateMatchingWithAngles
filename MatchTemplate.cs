using System;
using System.Drawing;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using Size = OpenCvSharp.Size;
using Point = OpenCvSharp.Point;
using System.Collections.Generic;
using System.Linq;

namespace Test_软包电池定位极耳中心
{
    /// <summary>
    /// 模版匹配
    /// </summary>
    internal class MatchTemplate
    {
        /// <summary>
        /// 模版匹配结果
        /// </summary>
        public struct MatchTemplateResult
        {
            public Bitmap Image; // 匹配结果图像
            public RotatedRect Rect; // 匹配区域
            public double Score; // 匹配得分
            public bool IsOk; // 是否匹配成功
            public long TimeCost; // 耗时毫秒
            public MatchTemplateResult(Bitmap resultBitmap, RotatedRect rect, double score, bool isOk, long timeCost)
            {
                Image = resultBitmap;
                Rect = rect;
                Score = score;
                IsOk = isOk;
                TimeCost = timeCost;
            }
        }
        /// <param name="sourceImage"></param>
        /// <param name="templateImage"></param>
        /// <param name="scale"></param>
        /// <param name="show">是否更新显示，节点运行时设为false降低耗时</param>
        /// <returns></returns>
        public static MatchTemplateResult Match(Bitmap src, Bitmap templateImage, float scale, float score)
        {
            try
            {
                DateTime startTime = DateTime.Now;
                Bitmap sourceImage = (Bitmap)src.Clone();

                // 检查图像是否为空
                if (sourceImage == null || templateImage == null)
                    throw new ArgumentException("源图像或模板图像不能为空");

                // 将Bitmap转换为Mat，并确保它们是灰度图像
                using (Mat sourceMat = BitmapToGrayMat(sourceImage))
                using (Mat templateMat = BitmapToGrayMat(templateImage))
                {
                    // 检查图像是否成功转换
                    if (sourceMat.Empty() || templateMat.Empty())
                        throw new ArgumentException("无法将图像转换为灰度图像");

                    // 缩小图像
                    Size scaledSourceSize = new Size((int)(sourceMat.Cols / scale), (int)(sourceMat.Rows / scale));
                    Size scaledTemplateSize = new Size((int)(templateMat.Cols / scale), (int)(templateMat.Rows / scale));
                    using (Mat scaledSource = new Mat())
                    using (Mat scaledTemplate = new Mat())
                    {
                        Cv2.Resize(sourceMat, scaledSource, scaledSourceSize);
                        Cv2.Resize(templateMat, scaledTemplate, scaledTemplateSize);

                        // 执行模板匹配
                        using (Mat result = new Mat())
                        {
                            Cv2.MatchTemplate(scaledSource, scaledTemplate, result, TemplateMatchModes.CCoeffNormed);

                            // 获取最佳匹配位置
                            Point matchLocation;
                            double minVal, maxVal;
                            Cv2.MinMaxLoc(result, out minVal, out maxVal, out _, out matchLocation);


                            // 计算未缩放前的矩形区域
                            int top = (int)(matchLocation.Y * scale);
                            int left = (int)(matchLocation.X * scale);
                            int width = (int)(scaledTemplate.Cols * scale);
                            int height = (int)(scaledTemplate.Rows * scale);

                            // 根据得分判断是否真正匹配到目标，而不是误匹配
                            using (Mat originalSourceMat = BitmapToColorMat(sourceImage))
                            {
                                bool isOk = false;
                                if (maxVal * 100 >= score)
                                    isOk = true;
                                else
                                    isOk = false;
                                var bitmap = BitmapConverter.ToBitmap(originalSourceMat);
                                long elapsedMi11iseconds = (long)(DateTime.Now - startTime).TotalMilliseconds;

                                // 计算矩形中心点坐标
                                Point2f center = new Point2f(left + width / 2.0f, top + height / 2.0f);
                                RotatedRect rect = new RotatedRect(center, new Size2f(width, height), 0);
                                return new MatchTemplateResult(bitmap, rect, maxVal * 100, isOk, elapsedMi11iseconds);
                            }


                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 模版旋转匹配，输出最佳匹配的角度
        /// </summary>
        /// <param name="src"></param>
        /// <param name="templateImage"></param>
        /// <param name="scale"></param>
        /// <param name="score"></param>
        /// <param name="angleStart">旋转起始角度</param>
        /// <param name="angleEnd">旋转结束角度</param>
        /// <param name="step">选择角度步长</param>
        /// <returns></returns>
        public static MatchTemplateResult Match(Bitmap src, Bitmap templateImage, float scale, float score, double angleStart, double angleEnd, double step)
        {
            List<MatchTemplateResult> results = new List<MatchTemplateResult>();
            try
            {
                DateTime startTime = DateTime.Now;
                Bitmap sourceImage = (Bitmap)src.Clone();

                // 检查图像是否为空
                if (sourceImage == null || templateImage == null)
                    throw new ArgumentException("源图像或模板图像不能为空");

                // 将Bitmap转换为Mat，并确保它们是灰度图像
                using (Mat sourceMat = BitmapToGrayMat(sourceImage))
                using (Mat templateMat = BitmapToGrayMat(templateImage))
                {
                    // 检查图像是否成功转换
                    if (sourceMat.Empty() || templateMat.Empty())
                        throw new ArgumentException("无法将图像转换为灰度图像");

                    // 缩小图像
                    Size scaledSourceSize = new Size((int)(sourceMat.Cols / scale), (int)(sourceMat.Rows / scale));
                    Size scaledTemplateSize = new Size((int)(templateMat.Cols / scale), (int)(templateMat.Rows / scale));
                    using (Mat scaledSource = new Mat())
                    using (Mat scaledTemplate = new Mat())
                    {
                        Cv2.Resize(sourceMat, scaledSource, scaledSourceSize);
                        Cv2.Resize(templateMat, scaledTemplate, scaledTemplateSize);

                        #region 旋转多个角度进行模板匹配

                        for (double i = angleStart; i < angleEnd; i += step)
                        {
                            // 执行模板匹配
                            using (Mat rotateTemplate = ImageRotate.Rotate(scaledTemplate, i), result = new Mat())
                            {
                                Cv2.MatchTemplate(scaledSource, rotateTemplate, result, TemplateMatchModes.CCoeffNormed);

                                // 获取最佳匹配位置
                                Point matchLocation;
                                double minVal, maxVal;
                                Cv2.MinMaxLoc(result, out minVal, out maxVal, out _, out matchLocation);


                                // 计算未缩放前的矩形区域
                                int top = (int)(matchLocation.Y * scale);
                                int left = (int)(matchLocation.X * scale);
                                int width = (int)(scaledTemplate.Cols * scale);
                                int height = (int)(scaledTemplate.Rows * scale);

                                // 根据得分判断是否真正匹配到目标，而不是误匹配
                                using (Mat originalSourceMat = BitmapToColorMat(sourceImage))
                                {
                                    bool isOk = false;
                                    if (maxVal * 100 >= score)
                                        isOk = true;
                                    else
                                        isOk = false;
                                    var bitmap = BitmapConverter.ToBitmap(originalSourceMat);
                                    long elapsedMi11iseconds = (long)(DateTime.Now - startTime).TotalMilliseconds;

                                    // 计算矩形中心点坐标
                                    Point2f center = new Point2f(left + width / 2.0f, top + height / 2.0f);
                                    RotatedRect rect = new RotatedRect(center, new Size2f(width, height), float.Parse((-i).ToString("F2")));
                                    results.Add(new MatchTemplateResult(bitmap, rect, maxVal * 100, isOk, elapsedMi11iseconds));
                                }
                            }
                        }

                        #endregion
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            // 释放资源
            var res = results.OrderByDescending(r => r.Score).FirstOrDefault();
            foreach (var result in results)
            {
                if (!result.Equals(res))
                    result.Image.Dispose(); // 释放不需要的图像资源
            }
            // 按照得分降序排列结果，并返回得分最高的结果
            return res;
        }
        /// <summary>
        /// 绘制匹配结果
        /// </summary>
        /// <param name="result"></param>
        public static Bitmap DrawResult(MatchTemplateResult result, double fontScale, int lineWidth)
        {
            Mat mat = BitmapToColorMat(result.Image);

            // 获取旋转矩形的四个顶点（浮点类型）
            Point2f[] vertices2f = result.Rect.Points();

            // 转换为整数坐标 Point[]
            Point[] vertices = vertices2f.Select(p => new Point(
                (int)Math.Round(p.X),
                (int)Math.Round(p.Y)
            )).ToArray();

            // 画笔颜色
            Scalar color = Scalar.Red;
            if (result.IsOk)
                color = Scalar.Green;

            // 绘制带角度的矩形
            for (int i = 0; i < 4; i++)
            {
                Cv2.Line(mat, vertices[i], vertices[(i + 1) % 4], color, 2);
            }
            var (top, left) = GetRotatedRectTopLeft(result.Rect);
            Cv2.PutText(mat, $"Score: {result.Score:F2}", new Point(left, top - 30), HersheyFonts.HersheySimplex, fontScale, color, lineWidth);
            return BitmapConverter.ToBitmap(mat);
        }
        /// <summary>
        /// 获取旋转矩形的左上角坐标，留出空间用于绘制文字
        /// </summary>
        /// <param name="rotatedRect"></param>
        /// <returns></returns>
        private static (int, int) GetRotatedRectTopLeft(RotatedRect rotatedRect)
        {
            // 获取旋转矩形的四个顶点
            Point2f[] vertices = rotatedRect.Points();

            // 计算这些顶点的边界框，找到最小的x和y值以确定左上角位置
            float minX = float.MaxValue, minY = float.MaxValue;
            foreach (var vertex in vertices)
            {
                if (vertex.X < minX) minX = vertex.X;
                if (vertex.Y < minY) minY = vertex.Y;
            }
            int left = (int)minX;
            int top = (int)minY - 30; // 向上移动30像素为文字留出空间
            return (left, top);
        }
        /// <summary>
        /// Bitmap转灰度Mat
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private static Mat BitmapToGrayMat(Bitmap bitmap)
        {
            using (Mat mat = BitmapConverter.ToMat(bitmap))
            {
                if (mat.Channels() == 1)
                    return mat.Clone();
                Mat grayMat = new Mat();
                Cv2.CvtColor(mat, grayMat, ColorConversionCodes.BGR2GRAY);
                return grayMat;
            }
        }
        /// <summary>
        /// Bitmap转彩色Mat
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        private static Mat BitmapToColorMat(Bitmap bitmap)
        {
            return BitmapConverter.ToMat(bitmap);
        }
    }
}
