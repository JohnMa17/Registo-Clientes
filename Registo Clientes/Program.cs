using System;
using System.Collections.Generic;

namespace Registro_clientes
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;

            do
            {
                Console.WriteLine("\n MENU PRINCIPAL: \n");
                Console.WriteLine("\n(1) Sistema de Registro de Clientes " +
                                  "\n(2) Sistema de Seguimiento de Tareas  " +
                                  "\n(3) Cerrar el programa\n");

                int seleccion = int.Parse(Console.ReadLine());

                switch (seleccion)
                {
                    case 1:

                        RegistroClientes();
                        break;

                    case 2:

                        SeguimientoTareas();
                        break;

                    case 3:

                        continuar = false;
                        Console.WriteLine("Programa cerrado.");
                        break;

                    default:
                     
                        Console.WriteLine("Selección no válida. Inténtelo de nuevo.");
                        break;

                }
            }
            while (continuar);
        }

        static void RegistroClientes()
        {

            List<Cliente> listaClientes = new List<Cliente>();
            bool continuarClientes = true;

            while (continuarClientes)
            {
               
                Console.WriteLine("\nSistema de Registro de Clientes:");
                Console.WriteLine("\n(1) Agregar Cliente " +
                                  "\n(2) Mostrar Clientes " +
                                  "\n(3) Volver al menú principal\n");

                int opcionClientes = int.Parse(Console.ReadLine());

                switch (opcionClientes)
                {

                    case 1:

                        Console.Write("Ingrese el nombre del cliente: ");
                        string nombre = Console.ReadLine();
                        Console.Write("Ingrese la edad del cliente: ");
                        int edad = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el correo del cliente: ");
                        string correo = Console.ReadLine();

                        Console.Write("¿El cliente es corporativo? (s/n): ");
                        string esCorporativo = Console.ReadLine().ToLower();

                        if (esCorporativo == "s")
                        {
                            Console.Write("Ingrese el nombre de la empresa: ");
                            string nombreEmpresa = Console.ReadLine();
                            Cliente cliente = new ClienteCorporativo(nombre, edad, correo, nombreEmpresa);
                            listaClientes.Add(cliente);
                        }
                        else
                        {
                            Cliente cliente = new Cliente(nombre, edad, correo);
                            listaClientes.Add(cliente);
                        }

                        Console.WriteLine("Cliente agregado con éxito.");
                        break;

                    case 2:

                        Console.WriteLine("\nLista de Clientes:");
                        foreach (Cliente cliente in listaClientes)
                        {
                            cliente.MostrarInformacion();
                            Console.WriteLine();
                        }
                        break;

                   
                    case 3:

                        continuarClientes = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;

                }
            }
        }

        static void SeguimientoTareas()
        {
            List<Tarea> listaTareas = new List<Tarea>();
            bool continuarTareas = true;

            do
            {
                Console.WriteLine("\nSistema de Seguimiento de Tareas:");
                Console.WriteLine("\n(1) Agregar Tarea " +
                                  "\n(2) Mostrar Tareas " +
                                  "\n(3) Volver al menú principal\n");

                int opcionTareas = int.Parse(Console.ReadLine());

                switch (opcionTareas)
                {
                    case 1:
                        Console.Write("Ingrese el título de la tarea: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese la descripción de la tarea: ");
                        string descripcion = Console.ReadLine();
                        Console.Write("Ingrese la fecha límite (dd-mm-aaaa): ");
                        DateTime fechaLimite = DateTime.Parse(Console.ReadLine());

                        Console.Write("¿La tarea es urgente? (s/n): ");
                        string esUrgente = Console.ReadLine().ToLower();

                        if (esUrgente == "s")
                        {
                            Console.Write("Ingrese el nivel de urgencia: ");
                            string nivelUrgencia = Console.ReadLine();
                            Tarea tarea = new TareaUrgente(titulo, descripcion, fechaLimite, nivelUrgencia);
                            listaTareas.Add(tarea);
                        }
                        else
                        {
                            Tarea tarea = new Tarea(titulo, descripcion, fechaLimite);
                            listaTareas.Add(tarea);
                        }

                        Console.WriteLine("Tarea agregada con éxito.");
                        break;
                    case 2:
                        Console.WriteLine("\nLista de Tareas:");
                        foreach (Tarea tarea in listaTareas)
                        {
                            tarea.MostrarDetalles();
                            Console.WriteLine();
                        }
                        break;
                    case 3:
                        continuarTareas = false;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Inténtelo de nuevo.");
                        break;
                }
            }
            while (continuarTareas);
        }
    }

    class Cliente
    {
        private string nombre;
        private int edad;
        private string correo;

        public Cliente(string nombre, int edad, string correo)
        {
            this.nombre = nombre;
            this.edad = edad;
            this.correo = correo;
        }

        public void SetNombre(string nombre) { this.nombre = nombre; }
        public string GetNombre() { return nombre; }

        public void SetEdad(int edad) { this.edad = edad; }

        public int GetEdad() { return edad; }

        public void SetCorreo(string correo) { this.correo = correo; }

        public string GetCorreo() { return correo; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {nombre}, Edad: {edad}, Correo: {correo}");
        }
    }

    class ClienteCorporativo : Cliente
    {
        private string nombreEmpresa;

        public ClienteCorporativo(string nombre, int edad, string correo, string nombreEmpresa)
            : base(nombre, edad, correo)
        {
            this.nombreEmpresa = nombreEmpresa;
        }

        public void SetNombreEmpresa(string nombreEmpresa) { this.nombreEmpresa = nombreEmpresa; }

        public string GetNombreEmpresa() { return nombreEmpresa; }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Nombre de la Empresa: {nombreEmpresa}");
        }
    }

    class Tarea
    {
        private string titulo;
        private string descripcion;
        private DateTime fechaLimite;

        public Tarea(string titulo, string descripcion, DateTime fechaLimite)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fechaLimite = fechaLimite;
        }

        public void SetTitulo(string titulo) { this.titulo = titulo; }

        public string GetTitulo() { return titulo; }

        public void SetDescripcion(string descripcion) { this.descripcion = descripcion; }

        public string GetDescripcion() { return descripcion; }

        public void SetFechaLimite(DateTime fechaLimite) { this.fechaLimite = fechaLimite; }

        public DateTime GetFechaLimite() { return fechaLimite; }

        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"Título: {titulo}, Descripción: {descripcion}, Fecha Límite: {fechaLimite.ToShortDateString()}");
        }
    }

    class TareaUrgente : Tarea
    {
        private string nivelUrgencia;

        public TareaUrgente(string titulo, string descripcion, DateTime fechaLimite, string nivelUrgencia)
            : base(titulo, descripcion, fechaLimite)
        {
            this.nivelUrgencia = nivelUrgencia;
        }

        public void SetNivelUrgencia(string nivelUrgencia) { this.nivelUrgencia = nivelUrgencia; }

        public string GetNivelUrgencia() { return nivelUrgencia; }

        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Nivel de Urgencia: {nivelUrgencia}");
        }
    }
}