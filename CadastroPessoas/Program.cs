using CadastroPessoas;
using System.Text.Json;

namespace CadastroPessoa;

class Program
{
    static void Main(string[] args)
    {
        var user = new List<Usuario>();
        var fornecedor = new List<Fornecedor>();

        int opc = 0;
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Escolha uma das opções abaixo: \n1- Cadastrar Usuário\n2- Cadastrar Fornecedor\n"+
                "3- Listar todos\n4- Sair");
            int.TryParse(Console.ReadLine(), out opc );

            switch (opc)
            {
                case 1:
                    cadastrarUsuario(user);
                    break;
                case 2:
                    cadastrarFornecedor(fornecedor);
                    break;
                case 3:
                    listarCadastros(user, fornecedor);
                    break;
                case 4:
                    Console.WriteLine("Saindo do sistema...");
                    return;
                default:
                    break;
            }
        }
    }

    private static void cadastrarUsuario(List<Usuario> usuario)
    {
        var user = new Usuario();

        Console.Clear();

        user.IdUsuario = usuario.Count() + 1;

        Console.WriteLine("Digite o nome da pessoa: ");
        user.Nome = Console.ReadLine();

        Console.WriteLine("Digite o CPF da pessoa: ");
        user.Cpf = Console.ReadLine();

        usuario.Add(user);

        string jsonPessoas = JsonSerializer.Serialize(usuario);

        string arquivoJson = "Pessoas.json";
        File.WriteAllText(arquivoJson, jsonPessoas);

        Console.Clear();
        Console.WriteLine(jsonPessoas);
        Console.WriteLine("Pessoa cadastrada com sucesso");
        Thread.Sleep(2000);
    }
    private static void cadastrarFornecedor(List<Fornecedor> fornecedor)
    {
        var forn = new Fornecedor();

        Console.Clear();

        forn.IdFornecedor = fornecedor.Count() + 1;

        Console.WriteLine("Digite o nome da pessoa: ");
        forn.RazaoSocial = Console.ReadLine();

        Console.WriteLine("Digite o CPF da pessoa: ");
        forn.Cnpj = Console.ReadLine();

        fornecedor.Add(forn);

        Console.Clear();
        Console.WriteLine("Fornecedor cadastrado com sucesso");
        Thread.Sleep(2000);
    }

    private static void listarCadastros(List<Usuario> usuario, List<Fornecedor> fornecedor)
    {
        Console.Clear();

        if(usuario.Count() == 0 && fornecedor.Count() == 0)
        {
            Console.WriteLine("Nenhum cadastro feito até o momento");
            Thread.Sleep(3000);
            return;
        }

        if (usuario.Count() == 0)
        {
            Console.WriteLine("Nenhuma pessoa cadastrada");
        }
        else
        {
            foreach (var user in usuario)
            {
                Console.WriteLine($"ID: {user.IdUsuario}\nNome: {user.Nome}\nDocumento: {user.Cpf}\nTipo: ");
                Console.WriteLine("-----------------------");
            }
        }

        Console.WriteLine("=======================================");

        if (fornecedor.Count() == 0)
        {
            Console.WriteLine("Nenhum fornecedor cadastrado");
        }
        else
        {
            foreach (var forn in fornecedor)
            {
                Console.WriteLine($"ID: {forn.IdFornecedor}\nNome: {forn.RazaoSocial}\nDocumento: {forn.Cnpj}\nTipo: ");
                Console.WriteLine("-----------------------");
            }
        }
        Thread.Sleep(7000);
    }
}