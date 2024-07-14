namespace Geradores
{
    internal class GerarCPF
    {
        public static string Gerar()
        {
            var rand = new Random();
            return UltimosDigCpf(new string(Enumerable.Repeat("0123456789", 9).Select(x => x[rand.Next(9)]).ToArray()));
        }
        private static string UltimosDigCpf(string cpf)
        {
            string retornarCpfCompleto = string.Empty;
            var cpfIncompleto = UltimosDig(9, [.. cpf]);
            var cpfCompleto = UltimosDig(10, cpfIncompleto);
            return string.Join("", cpfCompleto.Select(n => n.ToString()).ToArray());
        }
        private static List<char> UltimosDig(int length, List<char> listaNums)
        {
            int dig;
            var soma = Calcular(length, listaNums);
         
            var resto = soma % 11;
            if (resto < 2)
                dig = 0;
            else
                dig = 11 - resto;
            listaNums.Add(char.Parse(dig.ToString()));
            return listaNums;
        }
        private static int Calcular(int lenght, List<char> nums)
        {
            int[] retorno = new int [lenght];
            int soma = 0;
            int multi = nums.Count + 1;
            int rt = 0;
            foreach (var i in nums)
            {
                if (!int.TryParse(i.ToString(), out int num))
                    throw new Exception("erro ao converter numero");   
                
                retorno[rt] = num * multi;
                multi--;
                rt++;
            }
            foreach (var i in retorno)
                soma += i;
            return soma;
        } 
    }
}
