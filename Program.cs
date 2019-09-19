using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Cliente {
        private string nome;
        private float dinheiro;
        public Cliente(string name, float money) {
            nome = name;
            dinheiro = money;
        }
        public string getNome() { return nome; }
        public float getDinheiro() { return dinheiro; }

        public void cobrar(float valor) {
            dinheiro -= valor;    
        }
    }

    class Quarto {
        private short id;
        private float preco;
        private Boolean ocupado;
        public Quarto(short id, float preco) {
            this.id = id;
            this.preco = preco;
            ocupado = false;
        }
        public short getId() { return id; }
        public float getPreco() { return preco; }
        public Boolean getOcupado() { return ocupado; }
        public void setOcupado(Boolean ocupado) { this.ocupado = ocupado; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Cliente> clientes= new List<Cliente>();
            List<Quarto> quartos = new List<Quarto>();
            ConsoleKeyInfo choose;
            while (true) {
                Console.WriteLine("_______________");
                Console.WriteLine("1-Registrar Cliente");
                Console.WriteLine("2-Hospedar Cliente");
                Console.WriteLine("3-Registrar Quarto");
                Console.WriteLine("4-Sair :c");
                Console.WriteLine("_______________");
                choose=Console.ReadKey();
                Console.WriteLine();
                if (choose.Key == ConsoleKey.D4) {
                    break;
                }
                switch (choose.Key) {
                    case ConsoleKey.D1:
                        Console.Clear();
                        Console.WriteLine("Digite o nome do novo cliente");
                        string nome=Console.ReadLine();
                        Console.WriteLine("Quanto gostaria de depositar?");
                        float dinheiro = float.Parse(Console.ReadLine());
                        clientes.Add(new Cliente(nome, dinheiro));
                        Console.WriteLine("Cliente cadastrado, pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        Console.WriteLine("Selecione um cliente");
                        for (int i = 0; i < clientes.Count(); i++) {
                            Console.WriteLine(i.ToString() + " : ");
                            Console.WriteLine("Nome: "+clientes[i].getNome());
                            Console.WriteLine("Crédito: " + clientes[i].getDinheiro());
                            Console.WriteLine();
                        }
                        byte index = byte.Parse(Console.ReadLine());
                        Console.Clear();
                        Console.WriteLine("Quartos livres que o cliente pode pagar:");
                        for (int i = 0; i < quartos.Count(); i++)
                        {
                            if (quartos[i].getPreco() <= clientes[index].getDinheiro() && quartos[i].getOcupado() == false)
                            {
                                Console.WriteLine();
                                Console.WriteLine("Numero: " + quartos[i].getId().ToString());
                                Console.WriteLine("Preço: " + quartos[i].getPreco().ToString());
                                Console.WriteLine();
                            }
                        }
                        Console.WriteLine("Digite o número do quarto desejado");
                        short num = short.Parse(Console.ReadLine());
                        for (int i = 0; i < quartos.Count(); i++)
                        {
                            if (quartos[i].getPreco() <= clientes[index].getDinheiro() && quartos[i].getOcupado() == false && quartos[i].getId() == num)
                            {
                                quartos[i].setOcupado(true);
                                clientes[index].cobrar(quartos[i].getPreco());
                                break;
                            }
                                
                           
                        }

                        break;
                    case ConsoleKey.D3:
                        Console.Clear();
                        Console.WriteLine("Digite o número do novo quarto");
                        short id = short.Parse(Console.ReadLine());
                        Console.WriteLine("Digite o preço da diária");
                        float preco = float.Parse(Console.ReadLine());
                        quartos.Add(new Quarto(id, preco));
                        Console.WriteLine("Quarto cadastrado, pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
