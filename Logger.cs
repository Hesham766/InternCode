using System;

namespace School_Management_System
{
    /// <summary>
    /// Global static logger class that provides simple wrapper methods for console logging
    /// with color-coded output for different message types.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        /// Logs an informational message in white color.
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void Info(string message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[INFO] {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Logs a success message in green color.
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void Success(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SUCCESS] {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Logs an error message in red color.
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Logs a warning message in yellow color.
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void Warning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Logs a debug message in cyan color.
        /// </summary>
        /// <param name="message">The message to log</param>
        public static void Debug(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[DEBUG] {message}");
            Console.ResetColor();
        }
    }
}
