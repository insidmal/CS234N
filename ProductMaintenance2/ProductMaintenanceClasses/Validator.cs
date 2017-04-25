using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProductMaintenanceClasses
{
    // This application is described in chapter 12 of
    // "Murach's C# 2010" by Joel Murach
    // (c) 2010 by Mike Murach & Associates, Inc. 
    // www.murach.com

    public static class Validator
	{
		private static string title = "Entry Error";

		public static string Title
		{
			get
			{
				return title;
			}
			set
			{
				title = value;
			}
		}

		public static bool IsPresent(TextBox textBox)
		{
			if (textBox.Text == "")
			{
				MessageBox.Show(textBox.Tag + " is a required field.", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}

		public static bool IsDecimal(TextBox textBox)
		{
			try
			{
				Convert.ToDecimal(textBox.Text);
				return true;
			}
			catch (FormatException)
			{
				MessageBox.Show(textBox.Tag + " must be a decimal number.", Title);
				textBox.Focus();
				return false;
			}
		}

		// The IsInt32 and IsWithinRange methods were omitted from figure 12-15.
		public static bool IsInt32(TextBox textBox)
		{
			try
			{
				Convert.ToInt32(textBox.Text);
				return true;
			}
			catch (FormatException)
			{
				MessageBox.Show(textBox.Tag + " must be an integer.", Title);
				textBox.Focus();
				return false;
			}
		}

		public static bool IsWithinRange(TextBox textBox, decimal min, decimal max)
		{
			decimal number = Convert.ToDecimal(textBox.Text);
			if (number < min || number > max)
			{
				MessageBox.Show(textBox.Tag + " must be between " + min
					+ " and " + max + ".", Title);
				textBox.Focus();
				return false;
			}
			return true;
		}
	}
}
