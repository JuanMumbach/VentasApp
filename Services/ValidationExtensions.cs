using System;

namespace VentasApp.Services
{
    /// <summary>
    /// Extension methods for common validation operations.
    /// Provides reusable validation logic across the application.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Validates that a string is not null, empty, or whitespace.
        /// </summary>
        public static bool IsNullOrWhiteSpace(this string? value)
        {
        return string.IsNullOrWhiteSpace(value);
        }

      /// <summary>
  /// Validates that a decimal value is within a specified range.
  /// </summary>
   public static bool IsInRange(this decimal value, decimal min, decimal max)
        {
  return value >= min && value <= max;
    }

        /// <summary>
        /// Validates that an integer value is positive.
        /// </summary>
        public static bool IsPositive(this int value)
     {
            return value > 0;
        }

 /// <summary>
        /// Validates that a decimal value is positive.
        /// </summary>
        public static bool IsPositive(this decimal value)
        {
        return value > 0;
        }

        /// <summary>
 /// Validates that an integer value is non-negative.
        /// </summary>
        public static bool IsNonNegative(this int value)
   {
            return value >= 0;
      }

     /// <summary>
        /// Validates an email address format.
   /// </summary>
        public static bool IsValidEmail(this string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
            return false;

       try
            {
    var addr = new System.Net.Mail.MailAddress(email);
         return addr.Address == email;
   }
            catch
          {
       return false;
  }
        }

        /// <summary>
        /// Validates a phone number format (basic validation).
    /// </summary>
        public static bool IsValidPhoneNumber(this string? phoneNumber)
        {
         if (string.IsNullOrWhiteSpace(phoneNumber))
   return false;

            // Basic validation: should contain only digits, spaces, parentheses, hyphens, and plus sign
            return System.Text.RegularExpressions.Regex.IsMatch(
    phoneNumber, 
                @"^[\d\s\(\)\-\+]+$"
     );
        }

        /// <summary>
 /// Truncates a string to a maximum length, adding ellipsis if needed.
   /// </summary>
        public static string Truncate(this string? value, int maxLength, bool addEllipsis = true)
        {
            if (string.IsNullOrEmpty(value))
         return string.Empty;

  if (value.Length <= maxLength)
         return value;

    if (addEllipsis && maxLength > 3)
      return value.Substring(0, maxLength - 3) + "...";

            return value.Substring(0, maxLength);
    }
    }
}
