namespace Geradores
{
    internal class GerarSenha
    {
        public enum complexityPwd
        {
            easy,
            medium,
            hard 
        }
        public static void SenhaRandom(int option,int lenght, complexityPwd complexity, out string result) 
        {
            Random rand = new ();
            switch (complexity)
            {
                case complexityPwd.easy:
                    string letters = "abcdefghijklmnopqrstuvwxyz";

                    result = new string(Enumerable.Repeat(letters, lenght).Select(p => p[rand.Next(p.Length)]).ToArray());
                    var s = Gerar(letters,lenght,new Random());

                    return;
                case complexityPwd.medium:
                    string lettersNumbers = "abcdefghijklmnopqrstuvwxyz1234567890";
                    result = new string(Enumerable.Repeat(lettersNumbers, lenght).Select(p => p[rand.Next(p.Length)]).ToArray());
                    return;
                case complexityPwd.hard:
                    string lettersNumbersCharacteres = "abcdefghijklmnopqrstuvwxyz1234567890!@#$%¨&*()_+-[]}{.<>";
                    result = new string(Enumerable.Repeat(lettersNumbersCharacteres, lenght).Select(p => p[rand.Next(p.Length)]).ToArray());
                    return;
            }
          result = string.Empty;
        }
        private static string Gerar(string characteres, int lenght, Random rand) => (new string(Enumerable.Repeat(characteres, lenght).Select(p => p[rand.Next(p.Length)]).ToArray()));
    }
}
