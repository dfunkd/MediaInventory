using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Media;
using MediaInventory.Data;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MediaInventory.Resources
{
    public static class Helpers
    {
        public static Inventory InventoryWindow;
        public static T TryFindParent<T>(this DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = GetParentObject(child);
            if (parentObject == null)
                return null;
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return TryFindParent<T>(parentObject);
        }
        public static DependencyObject GetParentObject(this DependencyObject child)
        {
            if (child == null)
                return null;
            ContentElement contentElement = child as ContentElement;
            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement);
                if (parent != null)
                    return parent;
                FrameworkContentElement fce = contentElement as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }
            FrameworkElement frameworkElement = child as FrameworkElement;
            if (frameworkElement != null)
            {
                DependencyObject parent = frameworkElement.Parent;
                if (parent != null) return parent;
            }
            return VisualTreeHelper.GetParent(child);
        }
        public static string RandomEncryptionOrderGenerator()
        {
            var encryptionOrder = string.Empty;
            var one = false;
            var two = false;
            var three = false;
            var four = false;

            Random random = new Random();
            while (!one || !two || !three || !four)
            {
                var randomNumber = random.Next(0, 1000);
                if (randomNumber % 4 == 0 && !four)
                {
                    encryptionOrder += 4;
                    four = true;
                }
                else if (randomNumber % 3 == 0 && !three)
                {
                    encryptionOrder += 3;
                    three = true;
                }
                else if (randomNumber % 2 == 0 && !two)
                {
                    encryptionOrder += 2;
                    two = true;
                }
                else if (randomNumber % 1 == 0 && !one)
                {
                    encryptionOrder += 1;
                    one = true;
                }
            }
            return encryptionOrder;
        }
        // This constant is used to determine the keysize of the encryption algorithm in bits.
        // We divide this by 8 within the code below to get the equivalent number of bytes.
        private const int Keysize = 256;
        // This constant determines the number of iterations for the password bytes generation function.
        private const int DerivationIterations = 1000;
        private const string saltString = "Samuelxf1104!";
        public static string Encrypt(string plainText)
        {
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(saltString, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }
        public static string Decrypt(string cipherText)
        {
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();
            using (var password = new Rfc2898DeriveBytes(saltString, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 256;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }
        public static T FindVisualParent<T>(UIElement element) where T : UIElement
        {
            UIElement parent = element;
            while (parent != null)
            {
                T correctlyTyped = parent as T;
                if (correctlyTyped != null)
                    return correctlyTyped;
                parent = VisualTreeHelper.GetParent(parent) as UIElement;
            }
            return null;
        }
        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[32]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider()) // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            return randomBytes;
        }
        public static void PopulateTMDbData(Movie SelectedMovie)
        {
            if (!string.IsNullOrWhiteSpace(SelectedMovie.IMDbId))
            {
                var extMovie = App.Client.GetMovie(SelectedMovie.IMDbId);
                SelectedMovie.Adult = extMovie.Adult;
                SelectedMovie.AlternativeTitles = extMovie.AlternativeTitles;
                SelectedMovie.BackdropPath = !string.IsNullOrWhiteSpace(extMovie.BackdropPath) ? App.Client.GetImageUrl("original", extMovie.BackdropPath).AbsoluteUri : string.Empty;
                SelectedMovie.BelongsToCollection = extMovie.BelongsToCollection;
                SelectedMovie.Budget = extMovie.Budget;
                SelectedMovie.Changes = extMovie.Changes;
                SelectedMovie.Credits = extMovie.Credits;
                SelectedMovie.Format = Helpers.InventoryWindow.InventoryEntity.Formats.Where(w => w.Id == SelectedMovie.FORId).FirstOrDefault();
                SelectedMovie.Genres = extMovie.Genres;
                SelectedMovie.Homepage = extMovie.Homepage;
                SelectedMovie.Images = extMovie.Images;
                SelectedMovie.Keywords = extMovie.Keywords;
                SelectedMovie.Lists = extMovie.Lists;
                SelectedMovie.OriginalTitle = extMovie.OriginalTitle;
                SelectedMovie.Overview = extMovie.Overview;
                SelectedMovie.Popularity = extMovie.Popularity;
                SelectedMovie.PosterPath = !string.IsNullOrWhiteSpace(extMovie.PosterPath) ? App.Client.GetImageUrl("original", extMovie.PosterPath).AbsoluteUri : string.Empty;
                SelectedMovie.ProductionCompanies = extMovie.ProductionCompanies;
                SelectedMovie.ProductionCountries = extMovie.ProductionCountries;
                SelectedMovie.ReleaseDate = extMovie.ReleaseDate;
                SelectedMovie.Releases = extMovie.Releases;
                SelectedMovie.Revenue = extMovie.Revenue;
                SelectedMovie.Runtime = extMovie.Runtime;
                SelectedMovie.SpokenLanguages = extMovie.SpokenLanguages;
                SelectedMovie.Status = extMovie.Status;
                SelectedMovie.Tagline = extMovie.Tagline;
                SelectedMovie.Title = extMovie.Title;
                SelectedMovie.Translations = extMovie.Translations;
                SelectedMovie.VoteAverage = extMovie.VoteAverage;
                SelectedMovie.VoteCount = extMovie.VoteCount;
            }
        }
        public static Color HexToColor(string hexColor)
        {
            if (hexColor.IndexOf('#') != -1) //Remove # if present
                hexColor = hexColor.Replace("#", "");
            byte red = 0;
            byte green = 0;
            byte blue = 0;
            if (hexColor.Length == 8) //We need to remove the preceding FF
                hexColor = hexColor.Substring(2);
            if (hexColor.Length == 6) //#RRGGBB
            {
                red = byte.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
                green = byte.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
                blue = byte.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
            }
            else if (hexColor.Length == 3) //#RGB
            {
                red = byte.Parse(hexColor[0].ToString() + hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
                green = byte.Parse(hexColor[1].ToString() + hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
                blue = byte.Parse(hexColor[2].ToString() + hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
            }
            return Color.FromRgb(red, green, blue);
        }
        public static SolidColorBrush InvertColor(string value)
        {
            if (value != null)
            {
                Color ColorToConvert = HexToColor(value);
                Color invertedColor = Color.FromRgb((byte)~ColorToConvert.R, (byte)~ColorToConvert.G, (byte)~ColorToConvert.B);
                return new SolidColorBrush(invertedColor);
            }
            return new SolidColorBrush(Color.FromRgb(0, 0, 0));
        }
        public static T GetFirstChildByType<T>(DependencyObject prop) where T : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(prop); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild((prop), i) as DependencyObject;
                if (child == null)
                    continue;
                T castedProp = child as T;
                if (castedProp != null)
                    return castedProp;
                castedProp = GetFirstChildByType<T>(child);
                if (castedProp != null)
                    return castedProp;
            }
            return null;
        }
        public static void SelectRowDetails(object sender)
        {
            var row = sender as DataGridRow;
            row.Focusable = true;
            bool focused = row.Focus();
            // Creating a FocusNavigationDirection object and setting it to a local field that contains the direction selected.
            FocusNavigationDirection focusDirection = FocusNavigationDirection.Next;
            // MoveFocus takes a TraveralReqest as its argument.
            TraversalRequest request = new TraversalRequest(focusDirection);
            // Gets the element with keyboard focus.
            UIElement elementWithFocus = Keyboard.FocusedElement as UIElement;
            // Change keyboard focus.
            if (elementWithFocus != null)
                elementWithFocus.MoveFocus(request);
        }
        public static BitmapImage BytesToImageSource(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }
        public static byte[] ImageSourceToBytes(BitmapEncoder encoder, ImageSource source)
        {
            byte[] bytes = null;
            var bitmapSource = source as BitmapSource;
            if (bitmapSource != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                using (var ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    bytes = ms.ToArray();
                }
            }
            return bytes;
        }
    }
}