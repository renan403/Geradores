using static Geradores.GerarCPF;
using static Geradores.GerarSenha;


int option, lenght;
string generatedPwd = string.Empty;
do
{
    ShowGeneratorsOptions();
    Console.Write("Opção: ");
    var select = Console.ReadLine();

    if (!int.TryParse(select, out option))
    {
        Console.Clear();
        ShowGeneratorsOptions();
        ChangeColorFont("Opção invalida.", ConsoleColor.Green);
        option = 9999999;
    }
    else
        switch (option)
        {
            case 0:
                // exit loop
                break;
            case 1:
                Console.WriteLine("Qual quantidade de caracteres?");

                while (!int.TryParse(Console.ReadLine(), out lenght))
                    ChangeColorFont("Apenas numero é permitido.",ConsoleColor.Green);

                ShowComplexityPwdOptions();

                switch (Console.ReadLine())
                {
                    case "1":
                        SenhaRandom(option, lenght, complexityPwd.easy, out generatedPwd);
                        break;
                    case "2":
                        SenhaRandom(option, lenght, complexityPwd.medium, out generatedPwd);
                        break;
                    case "3":
                        SenhaRandom(option, lenght, complexityPwd.hard, out generatedPwd);
                        break;
                    default:
                        ChangeColorFont("Apenas numero é permitido.", ConsoleColor.Green);
                        break;
                }
                Console.Clear();
                ChangeColorFont($"Sua senha: {generatedPwd} \n", ConsoleColor.Yellow);
                ShowGeneratorsOptions();
                break;
            case 2:
                Console.Clear();
                ChangeColorFont($"CPF: {Gerar()} \n", ConsoleColor.Yellow);
                break;
            default:
                Console.Clear();
                ShowGeneratorsOptions();
                ChangeColorFont("Opção invalida.", ConsoleColor.Green);

                break;
        }

} while (option != 0);


void ShowComplexityPwdOptions()
{
    Console.WriteLine("Comprexidade da senha");
    Console.WriteLine("1 - facil (apenas letras)");
    Console.WriteLine("2 - media (letras e numero)");
    Console.WriteLine("3 - dificil (letras, numeros e caracteres especiais)");
}
void ShowGeneratorsOptions()
{
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("\nQual gerador deseja utilizar?");
    Console.WriteLine("1 - Gerador de senha");
    Console.WriteLine("2 - Gerador de CPF");
    Console.WriteLine("0 - Sair ou CTRL + C");
}
void ChangeColorFont(string message, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(message);
    Console.ForegroundColor = ConsoleColor.White;
}