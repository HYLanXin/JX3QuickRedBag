
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace JX3QuickRedBag
{
    public class ImageSearch
    {
        public Point FindTemplateInImage(Bitmap MainImage, string templatePath)
        {


            // 加载主图片和模板图片
            Mat mainImage = BitmapExtension.ToMat(MainImage);
            Mat template = BitmapExtension.ToMat(new Bitmap(templatePath));

            // 进行模板匹配
            Mat result = new Mat();
            CvInvoke.MatchTemplate(mainImage, template, result, TemplateMatchingType.CcoeffNormed);

            //double minValue, maxValue;
            //Point minLocation, maxLocation;
            result.MinMax(out var minValue, out var maxValue, out var minLocation, out var maxLocation);

            if (maxValue[maxValue.Length - 1] >= 0.8) // 设置匹配阈值
            {
                return maxLocation[maxLocation.Length - 1]; // 返回找到的坐标
            }
            else
            {
                return Point.Empty; // 未找到匹配
            }
        }
    }
}
