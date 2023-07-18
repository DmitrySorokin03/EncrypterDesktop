using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EncrypterDesktop
{
    internal static class Program
    {
        private static readonly int s_keyIndexOfValidIndex = -1;

        public static readonly int KeyMaxLength = 32;
        public static readonly int KeyMinLength = 8;

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }

        public static bool IsSecretKeyValid(string key) => ((key.IndexOf(' ') == s_keyIndexOfValidIndex) && ((key.Length >= KeyMinLength) && (key.Length <= KeyMaxLength)));

        public static void EncryptAES256(string filePath, string encryptionKey)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey);

                using (Aes _aesAlg = Aes.Create())
                {
                    _aesAlg.Key = keyBytes;
                    _aesAlg.GenerateIV();

                    ICryptoTransform _encryptor = _aesAlg.CreateEncryptor(_aesAlg.Key, _aesAlg.IV);

                    SaveFileDialog _saveFileDialog = new SaveFileDialog();
                    _saveFileDialog.Filter = "Encrypted File (*.enc)|*.enc";
                    _saveFileDialog.FileName = Path.GetFileNameWithoutExtension(filePath) + ".enc";

                    if (_saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string _encryptedFilePath = _saveFileDialog.FileName;

                        using (FileStream _fsEncrypt = new FileStream(_encryptedFilePath, FileMode.Create))
                        {
                            _fsEncrypt.Write(_aesAlg.IV, 0, _aesAlg.IV.Length);

                            using (CryptoStream _csEncrypt = new CryptoStream(_fsEncrypt, _encryptor, CryptoStreamMode.Write))
                            {
                                using (FileStream _fsSource = new FileStream(filePath, FileMode.Open))
                                {
                                    _fsSource.CopyTo(_csEncrypt);
                                }
                            }
                        }

                        MessageBox.Show($"Файл успешно зашифрован: {_encryptedFilePath}", "Уведомление об успешном шифровании");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при шифровании файла: {ex.Message}", "Уведомление об ошибке");
            }
        }

        public static void DecryptAES256(string filePath, string encryptionKey)
        {
            try
            {
                byte[] _keyBytes = Encoding.UTF8.GetBytes(encryptionKey);

                using (Aes _aesAlg = Aes.Create())
                {
                    _aesAlg.Key = _keyBytes;

                    byte[] _iv = new byte[_aesAlg.BlockSize / 8];

                    using (FileStream _fsDecrypt = new FileStream(filePath, FileMode.Open))
                    {
                        _fsDecrypt.Read(_iv, 0, _iv.Length);

                        ICryptoTransform _decryptor = _aesAlg.CreateDecryptor(_aesAlg.Key, _iv);

                        SaveFileDialog _saveFileDialog = new SaveFileDialog();
                        _saveFileDialog.Filter = "Decrypted File (*.dec)|*.dec";
                        _saveFileDialog.FileName = Path.GetFileNameWithoutExtension(filePath) + ".dec";

                        if (_saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            string _decryptedFilePath = _saveFileDialog.FileName;

                            using (FileStream _fsDecrypted = new FileStream(_decryptedFilePath, FileMode.Create))
                            {
                                using (CryptoStream _csDecrypt = new CryptoStream(_fsDecrypted, _decryptor, CryptoStreamMode.Write))
                                {
                                    _fsDecrypt.CopyTo(_csDecrypt);
                                }
                            }

                            MessageBox.Show($"Файл успешно расшифрован: {_decryptedFilePath}", "Уведомление об успешном расшифровании");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расшифровке файла: {ex.Message}", "Уведомление об ошибке");
            }
        }

        public static byte[] ConvertToAES256Key(string str)
        {
            using (SHA256 _sha256 = SHA256.Create())
            {
                byte[] _userKeyBytes = Encoding.UTF8.GetBytes(str);
                byte[] _hash = _sha256.ComputeHash(_userKeyBytes);

                byte[] _key = new byte[32];
                Array.Copy(_hash, _key, 32);

                return _key;
            }
        }
    }
}