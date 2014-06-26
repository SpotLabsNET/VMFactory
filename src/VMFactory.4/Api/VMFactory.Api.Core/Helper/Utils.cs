using System;

namespace VMFactory.Api.Core.Helper
{
    public class Utils
    {

        /// <summary>
        /// Simply a file reader that returns a string.
        /// </summary>
        /// <returns></returns>
        public static String ReadScriptAsString(string scriptPath) { String s; try { s = System.IO.File.ReadAllText(scriptPath); } catch (Exception e) { throw new Exception("Error Reading Script: " + e.Message); } return s; }

    }
}
