using System;
using System.Text;

namespace XorGate;

/// <summary>
/// Reusable XOR cryptography class for encrypting and decrypting data
/// </summary>
public class XorCrypto
{
    private readonly byte[] _key;

    /// <summary>
    /// Constructor with a string key
    /// </summary>
    /// <param name="key">The encryption key</param>
    public XorCrypto(string key)
    {
        if (string.IsNullOrEmpty(key))
            throw new ArgumentException("Key can't be null or empty", nameof(key));

        _key = Encoding.UTF8.GetBytes(key);
    }

    /// <summary>
    /// Constructor with a byte array key
    /// </summary>
    /// <param name="key">The encryption key as bytes</param>
    public XorCrypto(byte[] key)
    {
        if (key == null || key.Length == 0)
            throw new ArgumentException("Key can't be null or empty", nameof(key));

        _key = (byte[])key.Clone();
    }

    /// <summary>
    /// Encrypts or decrypts a string (XOR is symmetric)
    /// </summary>
    /// <param name="text">The text to process (plain or encrypted Base64)</param>
    /// <returns>The result as Base64 (if encrypting) or plain text (if decrypting)</returns>
    public string Process(string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        try
        {
            // Try to decode as Base64 (decrypt)
            byte[] encrypted = Convert.FromBase64String(text);
            byte[]? decrypted = Process(encrypted);
            return decrypted != null ? Encoding.UTF8.GetString(decrypted) : string.Empty;
        }
        catch
        {
            // Not Base64, treat as plain text (encrypt)
            byte[] plainBytes = Encoding.UTF8.GetBytes(text);
            byte[]? encrypted = Process(plainBytes);
            return encrypted != null ? Convert.ToBase64String(encrypted) : string.Empty;
        }
    }

    /// <summary>
    /// Encrypts or decrypts a byte array (XOR is symmetric)
    /// </summary>
    /// <param name="data">The data to process</param>
    /// <returns>The processed data</returns>
    public byte[]? Process(byte[]? data)
    {
        if (data == null || data.Length == 0)
            return data;

        byte[] result = new byte[data.Length];

        for (int i = 0; i < data.Length; i++)
        {
            result[i] = (byte)(data[i] ^ _key[i % _key.Length]);
        }

        return result;
    }
}
