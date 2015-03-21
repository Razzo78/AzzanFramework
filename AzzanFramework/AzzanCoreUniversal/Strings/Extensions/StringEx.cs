#region Using directives
using System;
using System.Collections;
using System.Text.RegularExpressions;
#endregion

namespace System
{
	/// <summary>
	/// String extensions
	/// </summary>
	public static class StringEx
	{
		/// <summary>
        /// Verify if a string is null or empty without considering the presence of spaces
		/// </summary>
		/// <param name="pValue">Stringa to check</param>
		/// <returns>
        /// 	<c>true</c> if the string is null, empty or if it not contains characters different of space otherwise, <c>false</c>.
		/// </returns>
		public static bool IsNullOrTrimEmpty(this String pValue)
		{
			return (pValue == null || pValue.Trim().Length == 0);
		}

		/// <summary>
		/// Check if the supplied string is a float number
		/// </summary>
		/// <param name="pValue">String to check</param>
		/// <returns>
		/// 	<c>true</c> if the string is a float number othertwise, <c>false</c>.
		/// </returns>
		public static bool IsNumericFloatingPoint(this String pValue)
		{
			bool isNum;
			double retNum;
			isNum = Double.TryParse(pValue, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out retNum);
			return isNum;
		}

		/// <summary>
		/// Check if the supplied stirng is an integer number
		/// </summary>
		/// <param name="pValue">String to check</param>
		/// <returns>
		/// 	<c>true</c> if the string is an integer number, otherwise <c>false</c>.
		/// </returns>
		public static bool IsNumericInteger(this String pValue)
		{
			bool isNum;
			Int64 retNum;
			isNum = Int64.TryParse(pValue, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out retNum);
			return isNum;
		}

        /// <summary>
        /// Formatting string
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Formatting(this String pValue, params object[] args)
        {
            return String.Format(pValue, args);
        }

        /// <summary>
        /// Formatting string
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Formatting(this String pValue, IFormatProvider format, params object[] args)
        {
            return String.Format(format, pValue, args);
        }

        /// <summary>
        /// Remove escape chars
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static string ToStringNoEscape(this String pValue)
        {
            string ret = null;

            if (pValue != null)
            {
                ret = pValue.Replace(@"\", @"\\");
                return ret.Replace("\"", "\\\"");
            }

            return ret;
        }

        /// <summary>
        /// Check if the supplied string is a GUID
        /// </summary>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public static bool IsGuid(this String pValue)
        {
            Regex guidRegEx = new Regex(@"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$");
            return guidRegEx.IsMatch(pValue);
        }

        /// <summary>
        /// String to bit array.
        /// </summary>
        /// <returns>The bit array.</returns>
        /// <param name="pValue">String to convert</param>
        public static BitArray ToBitArray(this String pValue)
        {
            bool[] lst = new bool[pValue.Length];

            for (int i = 0; i < pValue.Length; i++)
            {
                lst[i] = pValue[i] != '0';
            }

            return new BitArray(lst);
        }
	}
}
