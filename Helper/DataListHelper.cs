namespace QQ_piracy.Helper
{
    using System.Collections.Generic;
    using System.IO;

    public static class DataListHelper
    {
        private static string[] starList = null;
        private static string[] bloodTypeList = null;

        private static string starTextPath = System.IO.Directory.GetCurrentDirectory() + @"\star.txt";
        private static string bloodTypeTextPath = System.IO.Directory.GetCurrentDirectory() + @"\bloodtype.txt";

        /// <summary>
        /// 获取星座列表
        /// </summary>
        public static string[] StarList
        {
            get
            {
                if (starList == null)
                {
                    starList = File.ReadAllLines(starTextPath);
                }

                return starList;
            }
        }

        /// <summary>
        /// 获取血型列表
        /// </summary>
        public static string[] BloodTypeList
        {
            get
            {
                if (bloodTypeList == null)
                {
                    bloodTypeList = File.ReadAllLines(bloodTypeTextPath);
                }

                return bloodTypeList;
            }
        }
    }
}
