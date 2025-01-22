using System;
using System.IO;
using System.Linq;
using System.Text;

class GeradorDeSenhas
{
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=== Gerador de Senhas Seguras ===\n");
        Console.ResetColor();

        // Solicitar tamanho da senha
        int tamanho;
        while (true)
        {
            Console.Write("Informe o tamanho da senha desejada (mínimo 4 caracteres): ");
            if (int.TryParse(Console.ReadLine(), out tamanho) && tamanho >= 4)
                break;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Entrada inválida. Digite um número inteiro maior ou igual a 4.");
            Console.ResetColor();
        }

        // Solicitar tipo de senha
        int escolha;
        while (true)
        {
            Console.WriteLine("\nEscolha o tipo de senha:");
            Console.WriteLine("1 - Apenas números");
            Console.WriteLine("2 - Letras e números");
            Console.WriteLine("3 - Letras, números e caracteres especiais (@, !, #, -)");
            Console.Write("Sua escolha: ");
            if (int.TryParse(Console.ReadLine(), out escolha) && (escolha >= 1 && escolha <= 3))
                break;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Escolha inválida. Digite 1, 2 ou 3.");
            Console.ResetColor();
        }

        // Gerar senha
        string senhaGerada = GerarSenha(tamanho, escolha);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"\nSenha Gerada: {senhaGerada}\n");
        Console.ResetColor();

        // Salvar senha em arquivo
        SalvarSenha(senhaGerada);

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Senha salva em 'bkp.TXT'.");
        Console.WriteLine("Pressione qualquer tecla para sair.");
        Console.ResetColor();
        Console.ReadKey();
    }

    /// <summary>
    /// Gera uma senha de acordo com o tamanho e tipo escolhidos.
    /// </summary>
    static string GerarSenha(int tamanho, int tipo)
    {
        const string numeros = "0123456789";
        const string letras = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string especiais = "@!#-";

        // Determina o conjunto de caracteres com base na escolha do usuário
        string caracteres = tipo switch
        {
            1 => numeros,
            2 => numeros + letras,
            3 => numeros + letras + especiais,
            _ => throw new ArgumentException("Tipo inválido")
        };

        // Gera a senha aleatória
        Random random = new Random();
        StringBuilder senha = new StringBuilder();

        for (int i = 0; i < tamanho; i++)
        {
            senha.Append(caracteres[random.Next(caracteres.Length)]);
        }

        return senha.ToString();
    }

    /// <summary>
    /// Salva a senha gerada em um arquivo texto.
    /// </summary>
    static void SalvarSenha(string senha)
    {
        string caminho = "bkp.TXT";

        try
        {
            using (StreamWriter sw = new StreamWriter(caminho, true, Encoding.UTF8))
            {
                sw.WriteLine(senha);
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Erro ao salvar a senha: {ex.Message}");
            Console.ResetColor();
        }
    }
}
