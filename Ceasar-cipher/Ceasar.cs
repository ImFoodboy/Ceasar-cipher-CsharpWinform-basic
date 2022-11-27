using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar_cipher
{
    class Ceasar
    {
        private string key = "0";
        private string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public bool isNumber(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] < '0' || s[i] > '9')
                {
                    return false;
                }
            }
            return true;
        }
        public void SetKey(string s)
        {
            if (isNumber(s))
            {
                key = s;
            }
        }

        public string Encrypt(string input)
        {
            string result = "";
            foreach (char ch in input)
            {
                int i = alphabet.IndexOf(Char.ToLower(ch));
                if (i != -1)
                {
                    result += alphabet[(i + Int32.Parse(key)) % alphabet.Length];
                }
                else
                {
                    result += ch;
                }
            }
            return result;
        }

        public string Decrypt(string input)
        {
            string result = "";
            foreach (char ch in input)
            {
                int i = alphabet.IndexOf(Char.ToLower(ch));
                if (i != -1)
                {
                    //result += alphabet[(i - Int32.Parse(key)) % alphabet.Length];
                    //result += Convert.ToString((i - Int32.Parse(key)) % alphabet.Length) + " ";
                    if(i - Int32.Parse(key) < 0)
                    {
                        i = alphabet.Length + i - Int32.Parse(key);
                        result += Convert.ToString(alphabet[i]);
                    }
                    else
                    {
                        result += alphabet[(i - Int32.Parse(key)) % alphabet.Length];
                    }                    
                }
                else
                {
                    result += ch;
                }
            }
            return result;
        }
        public string Detective(string input)
        {
            string result = "";
            return result;
        }
    }
}
