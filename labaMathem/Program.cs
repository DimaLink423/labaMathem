// See https://aka.ms/new-console-template for more information






class VigenereCipher
{
    static void Main()
    {

        string plaintext = "ЦЕКРИПТ";
        string key = "КЛЮЧ";

        Console.Write("Введіть слово: ");
        plaintext = Console.ReadLine();
        string encryptedText = EncryptVigenere(plaintext, key);
        Console.WriteLine("Зашифрований текст: " + encryptedText);

        string decryptedText = DecryptVigenere(encryptedText, key);
        Console.WriteLine("Розшифрований текст: " + decryptedText);
    }

    static string EncryptVigenere(string text, string key)
    {
        string ukrainianAlphabet = "АБВГҐДЕЄЖЗИІЇКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        text = text.ToUpper();
        key = key.ToUpper();
        int textLength = text.Length;
        int keyLength = key.Length;
        string encryptedText = "";

        for (int i = 0; i < textLength; i++)
        {
            char textChar = text[i];
            if (ukrainianAlphabet.Contains(textChar.ToString()))
            {
                int textIndex = ukrainianAlphabet.IndexOf(textChar);
                int keyIndex = ukrainianAlphabet.IndexOf(key[i % keyLength]);
                int encryptedIndex = (textIndex + keyIndex) % ukrainianAlphabet.Length;
                encryptedText += ukrainianAlphabet[encryptedIndex];
            }
            else
            {
                encryptedText += textChar;
            }
        }

        return encryptedText;
    }

    static string DecryptVigenere(string ciphertext, string key)
    {
        string ukrainianAlphabet = "АБВГҐДЕЄЖЗИІЇКЛМНОПРСТУФХЦЧШЩЬЮЯ";
        ciphertext = ciphertext.ToUpper();
        key = key.ToUpper();
        int ciphertextLength = ciphertext.Length;
        int keyLength = key.Length;
        string decryptedText = "";

        for (int i = 0; i < ciphertextLength; i++)
        {
            char ciphertextChar = ciphertext[i];
            if (ukrainianAlphabet.Contains(ciphertextChar.ToString()))
            {
                int ciphertextIndex = ukrainianAlphabet.IndexOf(ciphertextChar);
                int keyIndex = ukrainianAlphabet.IndexOf(key[i % keyLength]);
                int decryptedIndex = (ciphertextIndex - keyIndex + ukrainianAlphabet.Length) % ukrainianAlphabet.Length;
                decryptedText += ukrainianAlphabet[decryptedIndex];
            }
            else
            {
                decryptedText += ciphertextChar;
            }
        }

        return decryptedText;
    }
}