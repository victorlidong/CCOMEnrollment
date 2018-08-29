using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace university.Common
{
    public class BaiduMap
    {
        private const string BaiduGeocodingAPI = "http://api.map.baidu.com/geocoder/v2/";
        private const string BaiduLocationTransferAPI = "http://api.map.baidu.com/geoconv/v1/";
        private const string BaiduAskKey = "A91c73f40a66de01b96db17d9a3b5e76";

        /// <summary>
        /// 将百度地图的经纬度转化为对应的地址
        /// </summary>
        /// <param name="lat">百度地图的纬度</param>
        /// <param name="lng">百度地图的经度</param>
        /// <returns>返回解析后的地址；若解析失败，返回空串</returns>
        public static String ConvertLatLngToAddress(String lat, String lng)
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("ak=").Append(BaiduAskKey).Append("&");
                sb.Append("location=").Append(lat).Append(",").Append(lng).Append("&");
                sb.Append("output=json&pois=0");
                var result = Utils.HttpPost(BaiduGeocodingAPI, sb.ToString());
                JObject json = JObject.Parse(result);
                if (json["status"].ToString() == "0")
                {
                    string place = json["result"]["formatted_address"].ToString();
                    return place;
                }
            }
            catch{}
            return "";
        }

    }
}
