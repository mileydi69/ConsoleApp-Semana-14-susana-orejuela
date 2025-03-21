using System;

// Clase para representar un nodo del árbol binario
public class Nodo
{
    public char Valor { get; set; }
    public Nodo Izquierda { get; set; }
    public Nodo Derecha { get; set; }

    public Nodo(char valor)
    {
        Valor = valor;
        Izquierda = null;
        Derecha = null;
    }
}

// Clase para el árbol binario
public class ArbolBinario
{
    public Nodo Raiz { get; private set; }

    public ArbolBinario()
    {
        Raiz = null;
    }

    // Método para insertar un valor en el árbol
    public void Insertar(char valor)
    {
        if (Raiz == null)
        {
            Raiz = new Nodo(valor);
        }
        else
        {
            InsertarRecursivo(Raiz, valor);
        }
    }

    private void InsertarRecursivo(Nodo nodo, char valor)
    {
        if (valor < nodo.Valor)
        {
            if (nodo.Izquierda == null)
            {
                nodo.Izquierda = new Nodo(valor);
            }
            else
            {
                InsertarRecursivo(nodo.Izquierda, valor);
            }
        }
        else
        {
            if (nodo.Derecha == null)
            {
                nodo.Derecha = new Nodo(valor);
            }
            else
            {
                InsertarRecursivo(nodo.Derecha, valor);
            }
        }
    }

    // Método para recorrer el árbol en preorden
    public void RecorridoPreorden()
    {
        Console.WriteLine("Recorrido Preorden:");
        PreordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void PreordenRecursivo(Nodo nodo)
    {
        if (nodo == null) return;
        Console.Write(nodo.Valor + " ");
        PreordenRecursivo(nodo.Izquierda);
        PreordenRecursivo(nodo.Derecha);
    }

    // Método para recorrer el árbol en inorden
    public void RecorridoInorden()
    {
        Console.WriteLine("Recorrido Inorden:");
        InordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void InordenRecursivo(Nodo nodo)
    {
        if (nodo == null) return;
        InordenRecursivo(nodo.Izquierda);
        Console.Write(nodo.Valor + " ");
        InordenRecursivo(nodo.Derecha);
    }

    // Método para recorrer el árbol en postorden
    public void RecorridoPostorden()
    {
        Console.WriteLine("Recorrido Postorden:");
        PostordenRecursivo(Raiz);
        Console.WriteLine();
    }

    private void PostordenRecursivo(Nodo nodo)
    {
        if (nodo == null) return;
        PostordenRecursivo(nodo.Izquierda);
        PostordenRecursivo(nodo.Derecha);
        Console.Write(nodo.Valor + " ");
    }

    // Método para buscar un valor en el árbol
    public bool Buscar(char valor)
    {
        return BuscarRecursivo(Raiz, valor);
    }

    private bool BuscarRecursivo(Nodo nodo, char valor)
    {
        if (nodo == null) return false;

        if (nodo.Valor == valor) return true;

        if (valor < nodo.Valor)
            return BuscarRecursivo(nodo.Izquierda, valor);

        return BuscarRecursivo(nodo.Derecha, valor);
    }
}

class Program
{
    static void MostrarMenu()
    {
        Console.WriteLine("\nMenú de Operaciones del Árbol Binario:");
        Console.WriteLine("1. Insertar valores");
        Console.WriteLine("2. Recorrido preorden");
        Console.WriteLine("3. Recorrido inorden");
        Console.WriteLine("4. Recorrido postorden");
        Console.WriteLine("5. Buscar un valor");
        Console.WriteLine("0. Salir");
    }

    static void Main(string[] args)
    {
        ArbolBinario arbol = new ArbolBinario();

        while (true)
        {
            MostrarMenu();
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    foreach (char letra in "abcdefghijk")
                    {
                        arbol.Insertar(letra); // Inserta las letras de 'a' a 'k'
                    }
                    Console.WriteLine("Valores de 'a' a 'k' insertados correctamente.");
                    break;

                case "2":
                    arbol.RecorridoPreorden();
                    break;

                case "3":
                    arbol.RecorridoInorden();
                    break;

                case "4":
                    arbol.RecorridoPostorden();
                    break;

                case "5":
                    Console.Write("Ingrese la letra a buscar: ");
                    char letraBuscar = Convert.ToChar(Console.ReadLine());
                    if (arbol.Buscar(letraBuscar))
                    {
                        Console.WriteLine($"La letra '{letraBuscar}' fue encontrada.");
                    }
                    else
                    {
                        Console.WriteLine($"La letra '{letraBuscar}' no está en el árbol.");
                    }
                    break;

                case "0":
                    Console.WriteLine("Saliendo del programa...");
                    return;

                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }
}
