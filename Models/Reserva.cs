
namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        private string tipo = "";
        private int capacidade = 0;
        private decimal valorDiaria = 0;
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        private List<string> hospedesCadastrados = new List<string>();

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public Reserva(string tipo, int capacidade, decimal valorDiaria)
        {
            this.tipo = tipo;
            this.capacidade = capacidade;
            this.valorDiaria = valorDiaria;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (Hospedes == null)
            {
                Hospedes = new List<Pessoa>();
            }

            Console.WriteLine("Digite o nome do hóspede a ser cadastrado:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o sobrenome do hóspede a ser cadastrado:");
            string sobrenome = Console.ReadLine();

            Hospedes.Add(new Pessoa { Nome = nome, Sobrenome = sobrenome });

            if (Hospedes.Count() > Suite.Capacidade)
            {
                throw new Exception("A quantidade de hóspedes não pode exceder à capacidade da suíte.");
            }
        }


        public void CadastrarSuite(Suite suite)
        {
            Suite = new Suite { TipoSuite = tipo, Capacidade = capacidade, ValorDiaria = valorDiaria };
        }

        public int ObterQuantidadeHospedes()
        {
            int quantidade = Hospedes.Count();
            Console.WriteLine($"Hóspedes cadastrados: {quantidade}");
            return quantidade;
        }

        public decimal CalcularValorDiaria()
        {
            Console.WriteLine("Digite a quantidade de dias que deseja reservar: ");

            int DiasReservados = 0;
            decimal valor = 0;

            DiasReservados = int.Parse(Console.ReadLine());

            valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor = DiasReservados * Suite.ValorDiaria * 0.9M;
            }

            ObterQuantidadeHospedes();
            Console.WriteLine($"O valor total da estadia é:  {valor:C}");
            return valor;
        }
    }
}