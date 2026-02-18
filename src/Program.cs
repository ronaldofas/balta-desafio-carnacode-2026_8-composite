using System;
using DesignPatternChallenge;
using C = DesignPatternChallenge.Composite;

namespace DesignPatternChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n=== DESAFIO COMPOSITE ===");
                Console.WriteLine("1. Executar Solução Original (Legacy)");
                Console.WriteLine("2. Executar Solução com Padrão Composite");
                Console.WriteLine("0. Sair");
                Console.Write("Escolha uma opção: ");

                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine("\n--- EXECUTANDO LEGADO ---\n");
                        LegacyProgram.Main(args);
                        break;
                    case "2":
                        Console.WriteLine("\n--- EXECUTANDO COMPOSITE ---\n");
                        RunCompositeSolution();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        static void RunCompositeSolution()
        {
            Console.WriteLine("=== Sistema de Menus CMS (Composite Pattern) ===\n");

            // No padrão Composite, não precisamos de listas separadas para Itens e Grupos
            // Tudo é um MenuComponent
            var root = new C.MenuGroup("Menu Principal");

            // Item simples no nível raiz
            root.Add(new C.MenuItem("Home", "/", "🏠"));

            // Grupo com itens
            var productsMenu = new C.MenuGroup("Produtos", "📦");
            productsMenu.Add(new C.MenuItem("Todos", "/produtos"));
            productsMenu.Add(new C.MenuItem("Categorias", "/categorias"));
            productsMenu.Add(new C.MenuItem("Ofertas", "/ofertas"));

            // Subgrupo dentro de grupo
            var clothingMenu = new C.MenuGroup("Roupas", "👕");
            clothingMenu.Add(new C.MenuItem("Camisetas", "/roupas/camisetas"));
            clothingMenu.Add(new C.MenuItem("Calças", "/roupas/calcas"));
            
            // Adicionando subgrupo ao grupo
            productsMenu.Add(clothingMenu);

            // Adicionando grupo à raiz
            root.Add(productsMenu);

            // Outro grupo
            var adminMenu = new C.MenuGroup("Administração", "⚙️");
            adminMenu.Add(new C.MenuItem("Usuários", "/admin/usuarios"));
            adminMenu.Add(new C.MenuItem("Configurações", "/admin/config"));
            
            root.Add(adminMenu);

            // Renderização unificada
            root.Render();

            Console.WriteLine($"\nTotal de itens no menu: {root.CountItems()}");

            Console.WriteLine("\n=== BENEFÍCIOS ===");
            Console.WriteLine("✓ Interface única (MenuComponent) para itens e grupos");
            Console.WriteLine("✓ Recursividade transparente no Render e CountItems");
            Console.WriteLine("✓ Cliente não precisa saber se é folha ou nó");
            Console.WriteLine("✓ Fácil adicionar novos tipos de componentes");
        }
    }
}
