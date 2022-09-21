using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFistDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new LojaEntities())
            {
                //criando clientes e pedidos

                Cliente cliente1 = new Cliente()
                {
                    Nome = "Smeagol",
                    Email = "Smeagol@gmail.com"
                };
                db.Clientes.Add(cliente1);
                db.SaveChanges();

                //criando Cliente 2

                Cliente cliente2 = new Cliente()
                {
                    Nome = "Ramon",
                    Email = "ramon.oliveirarpdo@gmail.com"
                };
                db.Clientes.Add(cliente2);
                db.SaveChanges();

                Cliente cliente3 = new Cliente()
                {
                    Nome = "Kadu",
                    Email = "Kadu@gmail.com"
                };
                db.Clientes.Add(cliente3);
                db.SaveChanges();

                cliente1.Pedidoes.Add(new Pedido
                {
                    Item = "Precioso",
                    Preco = 1000
                });

                cliente2.Pedidoes.Add(new Pedido
                {
                    Item = "Carro",
                    Preco = 50000
                });

                cliente3.Pedidoes.Add(new Pedido
                {
                    Item = "Moto",
                    Preco = 20000
                });
                db.SaveChanges();

                //LINQ = LANGUAGE INTEGRATED QUERY

                var query = from c in db.Clientes.Include("Pedidoes")
                            select c;

                foreach (var Cliente in query)
                {
                    Console.WriteLine("Nova Consulta: ");
                    Console.WriteLine($"Cliente: {Cliente.Nome}");
                    Console.WriteLine("Pedidoes");
                    Console.WriteLine("========");
                    foreach (var p in cliente1.Pedidoes)
                    {
                        Console.WriteLine($"Item: {p.Item}, Preço: {p.Preco}");
                    }
                }

                Console.WriteLine("Presione qualquer tecla...");
                Console.ReadKey();

            }
        }
    }
}
