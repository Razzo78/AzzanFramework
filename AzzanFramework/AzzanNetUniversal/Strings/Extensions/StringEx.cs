#region Using directives
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
#endregion

namespace System.Net.Mail
{
	/// <summary>
	/// Net Mail extensions
	/// </summary>
	public static class StringEx
	{
		/// <summary>
		/// Check the validity of e-mail address
		/// </summary>
		/// <param name="pMailAddress">E-mail address</param>
		/// <returns>
		/// 	<c>true</c> if [is valid email] [the specified p TXT]; otherwise, <c>false</c>.
		/// </returns>
		/// <remarks>
		/// V.1.0
		/// </remarks>
		public static bool IsValidEmail(this String pMailAddress)
		{
		    
			bool foundMatch = false;

			foundMatch = Regex.IsMatch(pMailAddress, @"\A(?:^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,10}|[0-9]{1,3})(\]?)$)\z",
					RegexOptions.IgnoreCase);

			return foundMatch;
		}
	}
}

