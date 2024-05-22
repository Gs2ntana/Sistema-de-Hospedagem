using System.Text;
using SistemaDeHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

/* Cria lista de hospedes e adiciona flag */
List<Pessoa> hospedes = new List<Pessoa>();
string flag = string.Empty;

/* Cria hospedes e adiciona a lista */
while(flag?.ToUpper() != "RESERVAR")
{
    Console.WriteLine("Informe seu nome:");
    string nome = Console.ReadLine(); 

    Console.WriteLine("Informe seu sobrenome:");
    string sobrenome = Console.ReadLine(); 

    Pessoa hospede = new Pessoa(nome,sobrenome);
    hospedes.Add(hospede);

    Console.WriteLine($"Hospede adicionado {hospede.NomeCompleto}");
    Console.WriteLine("Para realizar a reserva digite 'reservar' ou pressione 'Enter' para adicionar mais hospedes");
    flag = Console.ReadLine();

    // Trata o caso onde flag pode ser null
    if (string.IsNullOrWhiteSpace(flag))
    {
        flag = string.Empty;
    }
}

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Console.WriteLine("Informe a quantidade de dias");
int dias = Convert.ToInt32(Console.ReadLine());
Reserva reserva = new Reserva(diasReservados: dias);
reserva.CadastrarSuite(suite);
reserva.CadastrarHospedes(hospedes);

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");