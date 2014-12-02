using System;
using System.Configuration;

namespace DotNet.Utilities
{
	/// <summary>
	/// web.config操作类
	/// </summary>
	public sealed class ConfigHelper
	{
		/// <summary>
		/// 得到AppSettings中的配置字符串信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static string GetConfigString(string key)
		{
            string CacheKey = "AppSettings-" + key;
            object objModel=null;
            
            try
            {
                objModel = ConfigurationManager.AppSettings[key];
            }
            catch (Exception e)
            {
                ShowException.ShowtheException("ConfigError", e);
            }
            return objModel.ToString();
		}

		/// <summary>
		/// 得到AppSettings中的配置Bool信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static bool GetConfigBool(string key)
		{
			bool result = false;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = bool.Parse(cfgVal);
				}
				catch(FormatException e)
				{
                        ShowException.ShowtheException("ConfigError", e);
				}
			}
			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置Decimal信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static decimal GetConfigDecimal(string key)
		{
			decimal result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = decimal.Parse(cfgVal);
				}
                catch (FormatException e)
                {

                    ShowException.ShowtheException("ConfigError", e);

                }
			}

			return result;
		}
		/// <summary>
		/// 得到AppSettings中的配置int信息
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public static int GetConfigInt(string key)
		{
			int result = 0;
			string cfgVal = GetConfigString(key);
			if(null != cfgVal && string.Empty != cfgVal)
			{
				try
				{
					result = int.Parse(cfgVal);
				}
                catch (FormatException e)
                {

                    ShowException.ShowtheException("ConfigError", e);

                }
			}

			return result;
		}

        /// <summary>
        /// 修改AppSettings中的string信息
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="key"></param>
        public static void SetConfigString(string Value, string key)
        {
            
        }
        
	}
}
