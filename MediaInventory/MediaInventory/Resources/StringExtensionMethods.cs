using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaInventory.Resources
{
    public static class StringExtensionMethods
    {
        #region Fields
        static bool _invalidEmail = false;
        #endregion Fields
        #region Methods
        public static string AddSpaces(this string camelHumpedString)
        {
            if (!camelHumpedString.HasContent())
                return string.Empty;
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < camelHumpedString.Length; i++)
            {
                var currentChar = camelHumpedString[i];
                char nextChar = 'a';
                if (i < camelHumpedString.Length - 1)
                    nextChar = camelHumpedString[i + 1];
                stringBuilder.Append(currentChar);
                if (char.IsLower(currentChar) && char.IsUpper(nextChar))
                    stringBuilder.Append(" ");
            }
            return stringBuilder.ToString();
        }
        public static bool EqualityCheckWithNull(this string value1, string value2)
        {
            if (string.IsNullOrEmpty(value1) && string.IsNullOrEmpty(value2))
                return true;
            return (value1 == value2);
        }
        public static bool DoesDirectoryExist(this string directory, int millisecondTimeout = 0)
        {
            if (millisecondTimeout <= 0)
                return Directory.Exists(directory);
            var task = new Task<bool>(() => Directory.Exists(directory));
            task.Start();
            return task.Wait(millisecondTimeout) && task.Result;
        }
        public static string ExtractGenericMethodName(this string methodName)
        {
            if (string.IsNullOrEmpty(methodName))
                return methodName;
            var indexOfLeftBrace = methodName.IndexOf('<');
            if (indexOfLeftBrace < 0)
                return methodName;
            var indexOfRightBrace = methodName.IndexOf('>');
            if (indexOfRightBrace < 0 || indexOfRightBrace < indexOfLeftBrace)
                return methodName;
            return methodName.Substring(indexOfLeftBrace + 1, indexOfRightBrace - indexOfLeftBrace - 1);
        }
        public static Dictionary<string, string> ExtractQueryStringVariables(this string value)
        {
            if (value.HasContent() == false)
                return new Dictionary<string, string>();
            if (value.StartsWith("?"))
                value = value.Remove(0, 1);
            var variables = new Dictionary<string, string>();
            var queryVariables = value.Split('&');
            Parallel.ForEach(queryVariables, (potentialVariable) =>
            {
                var deconstruct = potentialVariable.Split('=');
                if (deconstruct.Count() == 2)
                    variables.Add(deconstruct.ElementAt(0), deconstruct.ElementAt(1));
            });
            return variables;
        }
        public static string GetDirectoryName(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return string.Empty;
            try
            {
                var info = new FileInfo(fileName);
                return info.DirectoryName;
            }
            catch { return string.Empty; }
        }
        /// <summary>
        /// Determines whether the specified string has characters other than whitepace.
        /// </summary>
        /// <param name="checkString">The check string.</param>
        /// <returns>
        /// 	<c>true</c> if the specified check string has content; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasContent(this string checkString)
        {
            return !(string.IsNullOrEmpty(checkString) || checkString.Trim().Length == 0);
        }
        public static bool HasInvalidFileCharacters(this string value)
        {
            string tmpValue = RemoveSpecialCharacters(value);
            return (tmpValue != value);
        }
        public static bool HasLetter(this string value)
        {
            if (value == null)
                return false;
            else
                return value.Count(ch => char.IsLetter(ch)) > 0;
        }
        public static bool HasNumber(this string value)
        {
            return NumeralCount(value) > 0;
        }
        public static byte[] HexToByteArray(this string hexString)
        {
            if (string.IsNullOrWhiteSpace(hexString))
                return null;
            if ((hexString.Length & 0x01) == 0x01)
                return null;
            if (hexString.Length > 2 && string.Equals(hexString.Substring(0, 2), "0x", StringComparison.InvariantCultureIgnoreCase))
                hexString = hexString.Substring(2);
            if (hexString.Any(ch => !(char.IsNumber(ch) || (char.ToUpper(ch) >= 'A' && char.ToUpper(ch) <= 'F'))))
                return null;
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < hexString.Length; i += 2)
                bytes[i / 2] = byte.Parse(hexString.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
            return bytes;
        }
        /// <summary>
        /// Determines whether the specified text is like the search pattern.  Use * for multiple characters and $ for single characters.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="pattern">The pattern.</param>
        /// <param name="caseSensitive">if set to <c>true</c> [case sensitive].</param>
        /// <returns><c>true</c> if the specified text is like; otherwise, <c>false</c>.</returns>
        public static bool IsLike(this string text, string pattern, bool caseSensitive = false)
        {
            pattern = pattern.Replace(".", @"\.");
            pattern = pattern.Replace("?", ".");
            pattern = pattern.Replace("*", ".*?");
            pattern = pattern.Replace(@"\", @"\\");
            pattern = pattern.Replace(" ", @"\s");
            return new Regex(pattern, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase).IsMatch(text);
        }
        public static bool IsRewardCardTrackData(this string trackData)
        {
            if (trackData == null)
                return false;
            return string.IsNullOrWhiteSpace(trackData.ParseRewardCardTrackData()) == false;
        }
        public static bool IsValidEmail(this string strIn)
        {
            _invalidEmail = false;
            if (string.IsNullOrEmpty(strIn))
                return false;
            // Use IdnMapping class to convert Unicode domain names.
            strIn = Regex.Replace(strIn, @"(@)(.+)$", DomainMapper);
            if (_invalidEmail)
                return false;
            // Return true if strIn is in valid e-mail format.
            return Regex.IsMatch(strIn, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase);
        }
        public static bool IsValidFilePath(this string filePath)
        {
            return IsValidFilePath(filePath, false);
        }
        public static bool IsValidFilePath(this string filePath, bool requireRootedPath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                return false;
            try
            {
                if (requireRootedPath && Path.IsPathRooted(filePath) == false)
                    return false;
                //This will error if the format is incorrect, path is too long or invalid characters are present
                var testParse = Path.GetFullPath(filePath);
                return true;
            }
            catch { return false; }
        }
        //public static bool IsLink(this string link) => string.IsNullOrWhiteSpace(link) == false && (link.IsValidEmail() || Uri.IsWellFormedUriString(link, UriKind.Absolute));
        public static bool IsLink(this string link)
        {
            return string.IsNullOrWhiteSpace(link) == false && (link.IsValidEmail() || Uri.IsWellFormedUriString(link, UriKind.Absolute));
        }
        public static List<Tuple<int, string>> GetLinkWords(this string text)
        {
            var linkWords = new List<Tuple<int, string>>();
            var startIndex = -1;
            var endIndex = -1;
            //Go character by character breaking at whitespace looking for words that can be converted into links.  Track the word and the index into the string.  Could do this with RegEx but I am assuming a O(n) algorithm will be faster
            for (var i = 0; i < text.Length; i++)
            {
                var ch = text[i];
                if (char.IsWhiteSpace(ch))
                {
                    if (startIndex == -1)
                        continue;
                    var word = text.Substring(startIndex, endIndex - startIndex + 1);
                    if (word.IsLink())
                        linkWords.Add(new Tuple<int, string>(startIndex, word));
                    startIndex = endIndex = -1;
                }
                else
                {
                    if (startIndex == -1)
                        startIndex = endIndex = i;
                    else
                        endIndex += 1;
                }
            }
            //Check to see if the string ends on a link word
            if (startIndex > -1 && endIndex > startIndex)
            {
                var word = text.Substring(startIndex, endIndex - startIndex + 1);
                if (word.IsLink())
                    linkWords.Add(new Tuple<int, string>(startIndex, word));
            }
            return linkWords;
        }
        public static bool IsValidRoutingNumber(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;
            if (value.Where(ch => char.IsNumber(ch)).Count() != 9 ||
                value.Length != 9)
                return false;
            if (value[0] == '5')
                return false;
            if (!PassesMod10RoutingValidation(value))
                return false;
            return true;
        }
        /// <summary>
        /// Determines whether the value is a valid US zip code.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid zip code] [the specified value]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidZipCode(this string value)
        {
            var containsInvalidCharacters = (value ?? string.Empty).Count(ch => char.IsNumber(ch) == false && ch != '-') > 0;
            if (containsInvalidCharacters)
                return false;
            var numeralCount = (value ?? string.Empty).Count(char.IsNumber);
            return numeralCount == 5 || numeralCount == 9;
        }
        /// <summary>
        /// Counts the number of numeric characters
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int NumeralCount(this string value)
        {
            return (value ?? string.Empty).Count(ch => char.IsNumber(ch));
        }
        public static string ParseRewardCardTrackData(this string trackData)
        {
            if (string.IsNullOrWhiteSpace(trackData))
                return string.Empty;
            var trimmedCardData = trackData.Trim();
            //Special case for practice genius cards and other generic cards.  Allow the cards if the track data starts with a ;, ends with a ? and contains no alpha characters ex:  allow track data that is formatted as such ;2811329139307876?
            if (trimmedCardData.First() == ';' && trimmedCardData.Last() == '?' && trimmedCardData.Any(char.IsLetter) == false)
                return trimmedCardData;
            if (!trackData.Contains(";") || !trackData.Contains("?") || !trackData.StartsWith("%") || !trackData.EndsWith("?"))
                return string.Empty;
            var cardNumberBegin = trackData.LastIndexOf(";", System.StringComparison.Ordinal);
            var cardNumberTerminator = trackData.LastIndexOf("?", System.StringComparison.Ordinal);
            trackData = trackData.Substring(cardNumberBegin + 1, cardNumberTerminator - cardNumberBegin - 1);
            var startingNumbersCount = trackData.TakeWhile(char.IsNumber).Count();
            if (startingNumbersCount == 15 || startingNumbersCount == 16)
                trackData = trackData.Substring(startingNumbersCount - 4).PadLeft(trackData.Length, '*');
            return trackData;
        }
        /// <summary>
        /// Removes the non numeric characters from the string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string RemoveNonNumeric(this string value)
        {
            return new string((value ?? string.Empty).Where(char.IsNumber).ToArray());
        }
        public static string RemoveSpecialCharacters(this string value)
        {
            // removes all but the listed characters
            return Regex.Replace(value, @"[^A-Za-z0-9\.,@!#$%^()_+=~ -]", "");
        }
        public static string Replace(this string source, string oldString, string newString, StringComparison comp)
        {
            int index = source.IndexOf(oldString, comp);
            // Determine if we found a match
            bool MatchFound = index >= 0;
            if (MatchFound)
            {
                // Remove the old text
                source = source.Remove(index, oldString.Length);
                // Add the replacemenet text
                source = source.Insert(index, newString);
            }
            return source;
        }
        /// <summary>
        /// Replaces any environment variables in the string with the actual value of the variable.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public static string ReplaceEnvironmentVariables(this string path)
        {
            if (path.HasContent() == false)
                return path;
            var indexes = new List<int>();
            for (int i = 0; i < path.Length; i++)
                if (path[i] == '%')
                    indexes.Add(i);
            if (indexes.Count < 2)
                return path;
            int startIndex = 0, endIndex = 0;
            for (int i = 0; i < indexes.Count; i++)
            {
                var index = indexes[i];
                if ((i % 2) == 0)
                    startIndex = index;
                else
                    endIndex = index;
                if (endIndex > (startIndex + 1))
                {
                    var environmentVariable = path.Substring(startIndex + 1, endIndex - startIndex - 1);
                    var variableValue = Environment.GetEnvironmentVariable(environmentVariable);
                    if (variableValue.HasContent())
                        path = path.Remove(startIndex, endIndex - startIndex + 1).Insert(startIndex, variableValue);
                    startIndex = endIndex = 0;
                }
            }
            return path;
        }
        /// <summary>
        /// Strips the specified value of all characters to make a string.  If no numbers than returns 0. Stops at the first non-number
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static int Strip(this string value)
        {
            if (value == null)
                return 0;
            string returnVal = string.Empty;
            foreach (var item in value.ToCharArray())
                if (Regex.IsMatch(item.ToString(), "[0-9+-]"))
                    returnVal += item.ToString();
                else
                    break;
            if (returnVal.Length == 0)
                returnVal = "0";
            try { return Convert.ToInt32(returnVal); }
            catch (Exception) { return 0; }
        }
        public static DateTime? ToCreditCardExpirationDate(this string value)
        {
            if (value.HasContent() == false)
                return null;
            try
            {
                int month = 0, day = 0, year = 0;
                var dateParts = value.Split('/');
                if (dateParts.Count() == 3) // Month/Day/Year
                {
                    if (int.TryParse(dateParts[0], out month) == false || int.TryParse(dateParts[1], out day) == false || int.TryParse(dateParts[2], out year) == false)
                        return null;
                }
                else if (dateParts.Count() == 2) // Month/Year
                {
                    if (int.TryParse(dateParts[0], out month) == false || int.TryParse(dateParts[1], out year) == false)
                        return null;
                    day = DateTime.DaysInMonth(year, month);
                }
                else if (dateParts.Count() == 1) //No forward slash delimiter
                {
                    if (dateParts[0].Length != 4 && dateParts[0].Length != 6) //Assume the first two characters are the month and the last 2 or 4 are the year
                        return null;
                    if (int.TryParse(dateParts[0].Substring(0, 2), out month) == false || int.TryParse(dateParts[0].Substring(2, dateParts[0].Length - 2), out year) == false)
                        return null;
                    //Correct for 2-digit year
                    if (year < 2000)
                        year += 2000;
                    day = DateTime.DaysInMonth(year, month);
                }
                else
                    return null;
                var expirationDate = DateTime.SpecifyKind(new DateTime(year, month, day), DateTimeKind.Unspecified);
                return expirationDate;
            }
            catch (Exception) { return null; }
        }
        /// <summary>
        /// Trims to length.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="maxLength">Length of the max.</param>
        /// <returns></returns>
        public static string TrimToLength(this string value, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length <= maxLength)
                return value;
            return value.Substring(0, maxLength);
        }
        private static string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();
            string domainName = match.Groups[2].Value;
            try { domainName = idn.GetAscii(domainName); }
            catch (ArgumentException) { _invalidEmail = true; }
            return match.Groups[1].Value + domainName;
        }
        private static bool PassesMod10RoutingValidation(string routingNumber)
        {
            //http://en.wikipedia.org/wiki/Routing_transit_number#Check_digit
            var digits = routingNumber.Select(ch => (int)char.GetNumericValue(ch)).ToArray();
            //Make sure the weights of the digits are correct
            var passesWeightCheck = ((3 * (digits[0] + digits[3] + digits[6]) + 7 * (digits[1] + digits[4] + digits[7]) + (digits[2] + digits[5] + digits[8])) % 10) == 0;
            if (passesWeightCheck == false)
                return false;
            //Examine the check digit
            return digits[8] == ((7 * (digits[0] + digits[3] + digits[6]) + 3 * (digits[1] + digits[4] + digits[7]) + 9 * (digits[2] + digits[5])) % 10);
        }
        #endregion Methods 
    }
}